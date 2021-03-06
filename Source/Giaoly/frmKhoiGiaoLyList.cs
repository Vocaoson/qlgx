using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using GxControl;

namespace GiaoLy
{
    public partial class frmKhoiGiaoLyList : frmBase
    {
        private string SELECT_KHOGIAOLY = @"SELECT KhoiGiaoLy.MaKhoi,KhoiGiaoLy.TenKhoi,KhoiGiaoLy.GhiChu, GiaoDan.TenThanh + ' ' + GiaoDan.HoTen AS NguoiQuanLy 
                                            FROM KhoiGiaoLy LEFT JOIN GiaoDan ON KhoiGiaoLy.NguoiQuanLy = GiaoDan.MaGiaoDan WHERE 1 ";


        public GxKhoiGiaoLyList KhoiGiaoLyList
        {
            get { return gxKhoiGiaoLyList1; }
            set { gxKhoiGiaoLyList1 = value; }
        }

        public frmKhoiGiaoLyList()
        {
            InitializeComponent();
            this.HelpKey = "giao_ly";
            gxAddEdit1.PrintButton.Visible = true;

            gxAddEdit1.ReloadButton.Visible = false;
            gxAddEdit1.GridData = gxKhoiGiaoLyList1;

            
            gxAddEdit1.Button1.Visible = false;
            
            gxAddEdit1.Button2.Visible = false;
            
            gxAddEdit1.FindButton.Visible = false;
            

            gxAddEdit1.ReloadButton.Enabled = false;

        }

        private void gxGiaDinhList1_RowCountChanged(object sender, EventArgs e)
        {
        }

        private void gxAddEdit1_Button1Click(object sender, EventArgs e)
        {
            //gxKhoiGiaoLyList1.XuatChungNhanHonPhoi();
        }

        private void gxAddEdit1_Button2Click(object sender, EventArgs e)
        {
            
        }

        private void gxGiaDinhList1_FilterApplied(object sender, EventArgs e)
        {
            
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gxAddEdit1.ReloadButton.Enabled = true;
        }

        private void frmKhoiGiaoLyList_Load(object sender, EventArgs e)
        {
            //Show "Tất cả" item and Load default data
            gxKhoiGiaoLyList1.FormatGrid();
            loadNam();
            gxKhoiGiaoLyList1.LoadData(SELECT_KHOGIAOLY, null);
            //if (operation != GxOperation.EDIT) gxCommand1.Visible = false;
            //Memory.Instance.SetMemory(GxConstants.DangTimKiemGiaDinhGiaoDan, null);
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            frmKhoiGiaoLy frm = new frmKhoiGiaoLy();
            frm.NamGiaoLy = Convert.ToInt32(cbNam.SelectedItem.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    //Khoan delete start
                    //DataTable tbl = Memory.GetData(string.Concat("SELECT * FROM KhoiGiaoLy WHERE MaKhoi=" + frm.DataReturn["MaKhoi"].ToString()));
                    //if (tbl != null && tbl.Rows.Count > 0)
                    //{
                    //    DataTable sourceTbl = (DataTable)gxKhoiGiaoLyList1.DataSource;
                    //    if (sourceTbl != null)
                    //    {                            
                    //        sourceTbl.ImportRow(frm.DataReturn);
                    //        gxKhoiGiaoLyList1.FindAll(gxKhoiGiaoLyList1.RootTable.Columns[0], Janus.Windows.GridEX.ConditionOperator.Equal, frm.DataReturn["MaKhoi"]);
                    //    }
                    //    else
                    //    {
                    //        gxKhoiGiaoLyList1.DataSource = tbl;
                    //    }
                    //}
                    //Khoan delete end

                    //Khoan modify start
                    DataTable tbl = Memory.GetData(SELECT_KHOGIAOLY);
                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        gxKhoiGiaoLyList1.DataSource = tbl;
                        gxKhoiGiaoLyList1.FindAll(gxKhoiGiaoLyList1.RootTable.Columns[0], Janus.Windows.GridEX.ConditionOperator.Equal, frm.DataReturn["MaKhoi"]);
                    }
                    //Khoan modify end
                }
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            EditRow();
        }

        /// <summary>
        /// Truong hop xoa 1 khoi giao ly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (gxKhoiGiaoLyList1.CurrentRow != null && (gxKhoiGiaoLyList1.CurrentRow.DataRow as DataRowView)!=null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa khối giáo lý này? Các lớp giáo lý thuộc khối này sẽ bị xóa theo", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int count = gxKhoiGiaoLyList1.SelectedItems.Count;
                List<int> lstDelete = new List<int>();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in gxKhoiGiaoLyList1.SelectedItems)
                {
                    lstDelete.Add(item.Position);
                }
                for (int i = 0; i < count;i++ )
                {
                    Janus.Windows.GridEX.GridEXRow item = gxKhoiGiaoLyList1.GetRow(lstDelete[i] - i);
                    
                    Memory.ExecuteSqlCommand("Delete from ChiTietLopGiaoLy where MaLop in (select MaLop from LopGiaoLy where MaKhoi = ?)",                                                   new object[] { (item.DataRow as DataRowView).Row["MaKhoi"] });
                    Memory.ExecuteSqlCommand("Delete from LopGiaoLy where MaKhoi = ?",
                                                        new object[] { (item.DataRow as DataRowView).Row["MaKhoi"] });
                    Memory.ExecuteSqlCommand("Delete from KhoiGiaoLy where MaKhoi = ?",
                                                        new object[] { (item.DataRow as DataRowView).Row["MaKhoi"] });

                    if (Memory.ShowError())
                    {
                        return;
                    }
                    gxKhoiGiaoLyList1.CurrentRow.Delete();
                    item.Delete();
                }
            }
        }

        private void gxGiaDinhList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            EditRow();
        }

        protected virtual void EditRow()
        {
            if (gxKhoiGiaoLyList1.CurrentRow == null || (gxKhoiGiaoLyList1.CurrentRow.DataRow as DataRowView) == null)
            {
                return;
            }
            frmKhoiGiaoLy frm = new frmKhoiGiaoLy();
            frm.Operation = GxOperation.EDIT;
            DataRow row = (gxKhoiGiaoLyList1.CurrentRow.DataRow as DataRowView).Row;
            frm.Id = (int)row["MaKhoi"];
            frm.NamGiaoLy = Convert.ToInt32(cbNam.SelectedItem.Text);
            frm.AssignControlData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = Memory.GetData(string.Concat("SELECT * FROM KhoiGiaoLy WHERE MaKhoi=" + frm.DataReturn["MaKhoi"].ToString()));
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
                    }
                }
            }
            
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.Export.GridEXExporter ex = new Janus.Windows.GridEX.Export.GridEXExporter();
            ex.GridEX = gxKhoiGiaoLyList1;

            string filePath = System.IO.Path.GetRandomFileName() + ".xls";
            filePath = Memory.GetTempPath(filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            System.IO.FileStream stream = file.OpenWrite();
            ex.Export((System.IO.Stream)stream);
            stream.Close();
            System.Diagnostics.Process.Start(filePath);
        }

        private void loadNam()
        {
            int i;
            for (i = 2000; i < 2050; i++)
            {
                cbNam.Items.Add(i.ToString());
                if (i == DateTime.Now.Year)
                {
                    cbNam.SelectedIndex = i-2000;
                }
            }
            
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int namSelected = Convert.ToInt32(cbNam.SelectedItem.Text);
            //LoadKhoiGiaoLyList(namSelected);
        }
    }
}