using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxControl;
using GxGlobal;
using Janus.Windows.GridEX;

namespace GiaoLy
{
    public partial class frmKhoiGiaoLy : frmBase
    {

        private int namGLy = 0;

        public int NamGiaoLy
        {
            get { return namGLy; }
            set
            {
                namGLy = value;
            }
        }

        public frmKhoiGiaoLy()
        {
            InitializeComponent();
            this.HelpKey = "khoi_giao_ly";

            gxCommand1.OKButton.Text = "&Cập nhật";
            gxAddEdit1.PrintButton.Visible = true;
            this.AcceptButton = gxCommand1.OKButton;

            txtNguoiQuanLy.WhereSQL = string.Format(" AND Quadoi=0");
            txtNguoiQuanLy.EditControl.ReloadButton.Visible = false;

            txtNguoiQuanLy.EditControl.ReloadButton.Visible = false;
            //For linh muc control 
            //Memory.Instance.SetMemory(GxConstants.LOAD_LINHMUC, null);
            
        }
     

        private void frmKhoiGiaoLy_Load(object sender, EventArgs e)
        {
            if (Memory.IsDesignMode) return;
            loadNam();
            gxLopGiaoLyList1.FormatGrid();
            if (this.operation == GxOperation.ADD)
            {
                id = Memory.Instance.GetNextId("KhoiGiaoLy", "MaKhoi", true);                
                
                uiGroupBox2.Visible = false;
                this.Height = 250;
                this.gxCommand1.Top = 224;
            }
            else if (this.operation == GxOperation.EDIT)
            {
                //loadLopGiaoLyList();
            }
            
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            frmLopGiaoLyList frm = new frmLopGiaoLyList();
            frm.IDKhoi = this.id;
            frm.NamGiaoLy = Convert.ToInt32(cbNam.SelectedItem.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = Memory.GetData(string.Concat("SELECT * FROM LopGiaoLy WHERE MaLop=" + frm.DataReturn["MaLop"].ToString()));
                    tbl.Columns.Add("GiaoLyVien", System.Type.GetType("System.String"));
                    foreach (DataRow dr in tbl.Rows)
                    {
                        string sqlGiaoLyVien = "select giaolyvien.magiaodan,giaodan.tenthanh,giaodan.hoten from giaolyvien inner join giaodan on giaolyvien.magiaodan=giaodan.magiaodan where giaolyvien.malop =" + dr["malop"].ToString();
                        DataTable tblglv = Memory.GetData(sqlGiaoLyVien);
                        if (tblglv.Rows.Count > 0)
                        {
                            sqlGiaoLyVien = "";
                            foreach (DataRow drglv in tblglv.Rows)
                            {
                                //Khoan modify start
                                //sqlGiaoLyVien += Memory.GetName(drglv["HoTen"].ToString()) + " - ";
                                sqlGiaoLyVien += drglv["HoTen"].ToString() + ", ";
                                //Khoan modify end
                            }

                            sqlGiaoLyVien = sqlGiaoLyVien.Substring(0, sqlGiaoLyVien.Length - 2);
                            dr["GiaoLyVien"] = sqlGiaoLyVien;
                        }

                    }
                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        DataTable sourceTbl = (DataTable)gxLopGiaoLyList1.DataSource;
                        if (sourceTbl != null)
                        {
                            //view giao ly vien
                            string sqlGLV = "select giaolyvien.magiaodan,giaodan.tenthanh,giaodan.hoten from giaolyvien inner join giaodan on giaolyvien.magiaodan=giaodan.magiaodan where giaolyvien.malop =" + frm.DataReturn["MaLop"].ToString();
                            DataTable tblglv = Memory.GetData(sqlGLV);
                            if (tblglv.Rows.Count > 0)
                            {
                                sqlGLV = "";
                                foreach (DataRow drglv in tblglv.Rows)
                                {
                                    //Khoan modify start
                                    //sqlGLV += Memory.GetName(drglv["HoTen"].ToString()) + " - ";
                                    sqlGLV += drglv["HoTen"].ToString() + ", ";
                                    //Khoan modify end
                                }

                                sqlGLV = sqlGLV.Substring(0, sqlGLV.Length - 2);
                                frm.DataReturn.Table.Columns.Add("GiaoLyVien", System.Type.GetType("System.String"));
                                frm.DataReturn["GiaoLyVien"] = sqlGLV;
                            }
                            sourceTbl.ImportRow(frm.DataReturn);
                            gxLopGiaoLyList1.FindAll(gxLopGiaoLyList1.RootTable.Columns[0], Janus.Windows.GridEX.ConditionOperator.Equal, frm.DataReturn["MaLop"]);
                        }
                        else
                        {
                            gxLopGiaoLyList1.DataSource = tbl;
                        }
                        
                    }
                }
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            if (gxLopGiaoLyList1.CurrentRow == null || (gxLopGiaoLyList1.CurrentRow.DataRow as DataRowView) == null)
            {
                return;
            }
            frmLopGiaoLyList frm = new frmLopGiaoLyList();
            frm.Operation = GxOperation.EDIT;
            DataRow row = (gxLopGiaoLyList1.CurrentRow.DataRow as DataRowView).Row;
            frm.Id = (int)row["MaLop"];
            frm.IDKhoi = id;
            frm.NamGiaoLy = Convert.ToInt32(cbNam.SelectedItem.Text);
            frm.AssignControlData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = Memory.GetData(string.Concat("SELECT * FROM LopGiaoLy WHERE MaLop=" + frm.DataReturn["MaLop"].ToString()));
                    if (Memory.ShowError()) return;
                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        foreach (DataColumn col in tbl.Columns)
                        {
                            if (row.Table.Columns.Contains(col.ColumnName))
                            {
                                row[col.ColumnName] = tbl.Rows[0][col.ColumnName];
                            }
                        }

                        string sqlGiaoLyVien = "select giaolyvien.magiaodan,giaodan.tenthanh,giaodan.hoten from giaolyvien inner join giaodan on giaolyvien.magiaodan=giaodan.magiaodan where giaolyvien.malop =" + frm.Id.ToString();
                        DataTable tblglv = Memory.GetData(sqlGiaoLyVien);
                        if (tblglv.Rows.Count > 0)
                        {
                            sqlGiaoLyVien = "";
                            foreach (DataRow drglv in tblglv.Rows)
                            {
                                //sqlGiaoLyVien += Memory.GetName(drglv["HoTen"].ToString()) + " - ";
                                sqlGiaoLyVien += drglv["HoTen"].ToString() + ", ";
                            }

                            sqlGiaoLyVien = sqlGiaoLyVien.Substring(0, sqlGiaoLyVien.Length - 2);
                            row["GiaoLyVien"] = sqlGiaoLyVien;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Dùng trong trường hợp xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (gxLopGiaoLyList1.CurrentRow != null && (gxLopGiaoLyList1.CurrentRow.DataRow as DataRowView) != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa lớp giáo lý này? Danh sách học sinh thuộc lớp giáo lý này sẽ bị xóa theo", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int count = gxLopGiaoLyList1.SelectedItems.Count;
                List<int> lstDelete = new List<int>();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in gxLopGiaoLyList1.SelectedItems)
                {
                    lstDelete.Add(item.Position);
                }
                for (int i = 0; i < count; i++)
                {
                    Janus.Windows.GridEX.GridEXRow item = gxLopGiaoLyList1.GetRow(lstDelete[i] - i);

                    Memory.ExecuteSqlCommand("Delete from ChiTietLopGiaoLy where MaLop  = ?", new object[] { (item.DataRow as DataRowView).Row["MaLop"] });
                    Memory.ExecuteSqlCommand("Delete from LopGiaoLy where MaLop = ?",
                                                        new object[] { (item.DataRow as DataRowView).Row["MaLop"] });               

                    if (Memory.ShowError())
                    {
                        return;
                    }
                    gxLopGiaoLyList1.CurrentRow.Delete();
                    item.Delete();
                }
            }
        }

        private bool checkInput()
        {
            if (txtTenKhoi.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Hãy nhập tên khối giáo lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhoi.Focus();
                return false;
            }

            if (txtNguoiQuanLy.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Hãy chọn người quản lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNguoiQuanLy.Focus();
                return false;
            }
           
            return true; 
        }


        private void AssignDataSource(DataRow row)
        {
            if (Memory.IsDesignMode) return;
            if (operation == GxOperation.ADD)
            {
                row["makhoi"] = Memory.Instance.GetNextId("KhoiGiaoLy", "makhoi", true);
            }
            else
            {
                row["makhoi"] = id;
            }
            row["tenkhoi"] = txtTenKhoi.Text;
            //row["nam"] = Convert.ToInt32(cbNam.SelectedItem.Text);
            row["nguoiquanly"] = txtNguoiQuanLy.MaGiaoDan;//Khoan modify         
            row["ghichu"] = txtGhiChu.Text;
        }

        public void AssignControlData()
        {
            if (Memory.IsDesignMode) return;
            DataTable tbl = Memory.GetData(string.Concat("SELECT * FROM KhoiGiaoLy WHERE MaKhoi=" + Id));

            if (tbl != null && tbl.Rows.Count > 0)
            {
                txtTenKhoi.Text = tbl.Rows[0]["TenKhoi"].ToString();
                txtNguoiQuanLy.MaGiaoDan = (int)tbl.Rows[0]["NguoiQuanLy"];
                //if (!txtNguoiQuanLy.Text.Equals(string.Empty))
                //{
                //    txtNguoiQuanLy.MaGiaoDan = 200022;//enalble deletebutton
                //}
                txtGhiChu.Text = tbl.Rows[0]["GhiChu"].ToString();
                string where = " and makhoi=" + Id.ToString() + " and Nam=" + NamGiaoLy.ToString();

                gxLopGiaoLyList1.QueryString = string.Concat("SELECT * FROM LopGiaoLy WHERE 1", where);
                gxLopGiaoLyList1.LoadData();

            }

        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            if (!updateKhoiGiaoLy())
            {
                //this.DialogResult = DialogResult.Cancel;

            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool updateKhoiGiaoLy()
        {
            try
            {
                if (!checkInput()) return false;

                DataTable tblKhoiGiaoLy = Memory.GetData("SELECT * FROM KhoiGiaoLy WHERE MaKhoi = ?", new object[] { Id });
                if (Memory.ShowError())
                {
                    return false;
                }
                tblKhoiGiaoLy.TableName = "KhoiGiaoLy";
                if (operation == GxOperation.ADD)
                {
                    dataReturn = tblKhoiGiaoLy.NewRow();
                    AssignDataSource(dataReturn);
                    tblKhoiGiaoLy.Rows.Add(dataReturn);
                }
                else
                {
                    if (tblKhoiGiaoLy.Rows.Count > 0)
                    {
                        dataReturn = tblKhoiGiaoLy.Rows[0];
                        AssignDataSource(dataReturn);
                    }
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(tblKhoiGiaoLy);
                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblKhoiGiaoLy);
                if (Memory.ShowError())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmKhoiGiaoLy, gxCommand1_OnOK)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

       


        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            
        }

        private void chkGiaDinhAo_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void loadNam()
        {
            int i;
            for (i = 2000; i < 2050; i++)
            {
                cbNam.Items.Add(i.ToString());
                if (i == NamGiaoLy)
                {
                    cbNam.SelectedIndex = i-2000;
                }
            }
            cbNam.Enabled = false;
        }

        private void loadLopGiaoLyList()
        {
            string where = " and makhoi=" + this.id;
            gxLopGiaoLyList1.LoadData(string.Concat("SELECT malop,tenlop,ghichu FROM LopGiaoLy WHERE 1", where), null);
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.Export.GridEXExporter ex = new Janus.Windows.GridEX.Export.GridEXExporter();
            ex.GridEX = gxLopGiaoLyList1;

            string filePath = System.IO.Path.GetRandomFileName() + ".xls";
            filePath = Memory.GetTempPath(filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            System.IO.FileStream stream = file.OpenWrite();
            ex.Export((System.IO.Stream)stream);
            stream.Close();
            System.Diagnostics.Process.Start(filePath);
        }
    }
}