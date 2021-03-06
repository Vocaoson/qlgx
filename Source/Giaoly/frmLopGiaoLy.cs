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
using GiaoLy;
using System.Reflection;
using System.IO;

namespace GiaoLy
{
    public partial class frmLopGiaoLyList : frmBase
    {
        DataTable tblHocSinh;
        DataTable tblGiaoLyVien;
        List<int> lstHSDel = new List<int>();
        List<Object> lstHSUp = new List<Object>();
        List<int> lstGLVDel = new List<int>();
        public frmLopGiaoLyList()
        {
            InitializeComponent();
            this.HelpKey = "lop_giao_ly";

            gxCommand1.OKButton.Text = "&Cập nhật";
            gxAddEdit1.PrintButton.Visible = true;
            gxAddEdit1.ReloadButton.Visible = false;
            gxAddEdit1.EditButton.Text = "&Xem chi tiết";

            gxAddEdit2.PrintButton.Visible = true;
            gxAddEdit2.ReloadButton.Visible = false;
            gxAddEdit2.EditButton.Text = "&Xem chi tiết";
            this.AcceptButton = gxCommand1.OKButton;

            //txtGiaolyvien1.WhereSQL = string.Format(" AND Quadoi=0");
            //txtGiaolyvien1.EditControl.ReloadButton.Visible = false;
            
            //txtGiaolyvien2.WhereSQL = string.Format(" AND Quadoi=0");
            //txtGiaolyvien2.EditControl.ReloadButton.Visible = false;
            

        }

        private int idKhoi = 0;

        public int IDKhoi
        {
            get { return idKhoi; }
            set
            {
                idKhoi = value;
            }
        }

        private int namGLy = 0;

        public int NamGiaoLy
        {
            get { return namGLy; }
            set
            {
                namGLy = value;
            }
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            if (sender != null)
            {
                
            }
        }       

        private void frmLopGiaoLy_Load(object sender, EventArgs e)
        {
            loadNam();
            string sqlHocSinh = string.Format("SELECT aa.SoThuTu, aa.TenThanh, aa.HoTen, aa.Phai, aa.NgaySinh, aa.HoanThanh, aa.GhiChuGLy,aa.MaGiaoDan,aa.MaLop FROM (SELECT b.*,a.HoanThanh,a.GhiChuGLy,a.SoThuTu,a.MaLop FROM ChiTietLopGiaoLy a  INNER JOIN GiaoDan b ON a.MaGiaoDan = b.MaGiaoDan WHERE (a.Malop = ?)) aa LEFT OUTER JOIN GiaoHo ON aa.MaGiaoHo = GiaoHo.MaGiaoHo WHERE (aa.DaXoa = 0)");
            string sqlGiaoLyVien ="select giaolyvien.magiaodan,giaodan.tenthanh,giaodan.hoten from giaolyvien inner join giaodan on giaolyvien.magiaodan=giaodan.magiaodan where giaolyvien.malop = ?";
            DataTable tbl_tmp;
            gxHocSinhList1.FormatGrid();
            gxHocSinhList1.AllowEdit = InheritableBoolean.True;
            gxHocSinhList1.MaLop = id;
            gxHocSinhList1.LoadData(sqlHocSinh, new object[] { id });

            gxGiaoLyVien1.LoadData(sqlGiaoLyVien, new object[] { id });
            gxGiaoLyVien1.AllowEdit = InheritableBoolean.False;
            gxGiaoLyVien1.FilterMode = FilterMode.None;

            tbl_tmp = Memory.GetData(sqlHocSinh, new object[] { id });
            lblTotal.Text = tbl_tmp.Rows.Count.ToString();
            //tblHocSinh = Memory.GetData("SELECT * from ChiTietLopGiaoLy where MaLop = ?", new object[] { id });
            //tblHocSinh.TableName = "ChiTietLopGiaoLy";
            tblGiaoLyVien = Memory.GetData("select * from giaolyvien where malop = ?", new object[] { id });
            tblGiaoLyVien.TableName = "GiaoLyVien";
            if (this.operation == GxOperation.ADD)
            {
                id = Memory.Instance.GetNextId("KhoiGiaoLy", "MaGiaDinh", true);
                uiGroupBox2.Visible = false;
                this.Text = "Thêm lớp giáo lý";
                this.Height = 250;
                this.gxCommand1.Top = 224;
                
            }
            else if (this.operation == GxOperation.EDIT)
            {

            }
            gxAddEdit1.ReloadButton.Visible = false;
            gxAddEdit1.Button1.Text = "Xem mẫu Excel";
            gxAddEdit1.Button1.Image = gxAddEdit1.ImageList.Images["ExportExcel"];
            gxAddEdit1.Button1.Visible = true;
            gxAddEdit1.Button1.Click += GetExcelTemplate_Click;

            gxAddEdit1.Button2.Text = "Nhập từ Excel";
            gxAddEdit1.Button2.Image = gxAddEdit1.ImageList.Images["ExportExcel"];
            gxAddEdit1.Button2.Visible = true;
            gxAddEdit1.Button2.Click += ImportExcel_Click;
        }

        void GetExcelTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(Memory.AppPath + "Giaoxu.exe");
                using (Stream stream = assembly.GetManifestResourceStream("GiaoXu.Resources.MauNhapHocVien.xls"))
                {
                    string tempFile = Memory.GetTempPath("mau_nhap_lop_giao_ly.xls");
                    FileStream file = new FileStream(tempFile, FileMode.CreateNew, FileAccess.Write);
                    int length = 256;
                    Byte[] buffer = new Byte[length];
                    int bytesRead = 0;
                    // write the required bytes
                    do
                    {
                        bytesRead = stream.Read(buffer, 0, length);
                        file.Write(buffer, 0, bytesRead);
                    }
                    while (bytesRead == length);
                    file.Close();
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "MS Excel (*.xls)|*.xls";
                    saveFile.FileName = "mau_nhap_lop_giao_ly.xls";
                    if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        File.Move(tempFile, saveFile.FileName);
                        try
                        {
                            System.Diagnostics.Process.Start(saveFile.FileName);
                        }
                        catch (Exception)
                        {
                            
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy file Excel mẫu\r\n" + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ImportExcel_Click(object sender, EventArgs e)
        {
            frmImportHocVien frm = new frmImportHocVien();
            frm.MaLop = id;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && frm.ImportedData != null)
            {
                this.gxHocSinhList1.DataSource = frm.ImportedData;
            }
        }

       
        private void gxAddEdit1_SelectClick(object sender, EventArgs e)
        {
            frmChonDuLieu frm = new frmChonDuLieu();
            bool rs = addGiaoDan(frm, false);
            if (rs)
            {
                gxHocSinhList1.Row = gxHocSinhList1.RowCount - 1;
                
            }
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            frmGiaoDan frm = new frmGiaoDan();

            bool rs = addGiaoDan(frm, true);
            if (rs)
            {
                gxHocSinhList1.Row = gxHocSinhList1.RowCount - 1;
                
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {            
            //frmHocSinh frm = new frmHocSinh();
            //DataRow row = (gxHocSinhList1.CurrentRow.DataRow as DataRowView).Row;
            
            //frm.MaGiaoDan = (int)row["MaGiaoDan"];
            //frm.MaLop = id;
            //frm.TenThanh = row["TenThanh"].ToString();
            //frm.HoTen = row["HoTen"].ToString();
            //frm.NgaySinh = row["NgaySinh"].ToString();
            //frm.Phai = row["Phai"].ToString();
            //try
            //{
            //    frm.HoanThanh = (bool)row["HoanThanh"];
            //    frm.GhiChu = row["GhiChuGLy"].ToString();
            //}
            //catch (Exception ex)
            //{ }
            //frm.AssignControlData();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    if (frm.DataReturn != null)
            //    {
            //        row["HoanThanh"] = frm.DataReturn["HoanThanh"];
            //        row["GhiChuGLy"] = frm.DataReturn["GhiChuGLy"];
            //        Giaoly.GhiChuGlyCls item = new Giaoly.GhiChuGlyCls();
            //        item.MaGiaoDan = frm.MaGiaoDan;
            //        item.HoanThanh = (bool)frm.DataReturn["HoanThanh"];
            //        item.GhiChu = frm.DataReturn["GhiChuGLy"].ToString();
            //        lstHSUp.Add(item);
            //    }
            //}
            gxHocSinhList1.EditRow();
        }

        private bool addGiaoDan(frmBase frm, bool isAdd)
        {
            cont:
            if (frm is frmGiaoDan)
            {                
                ((frmGiaoDan)frm).FromGiaDinhForm = true;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = (DataTable)gxHocSinhList1.DataSource;
                    if (tbl != null)
                    {
                        int maGiaoDan = (int)frm.DataReturn[GiaoDanConst.MaGiaoDan];
                        

                        //check ton tai trong danh sac
                        DataRow[] rows = tbl.Select("MaGiaoDan=" + maGiaoDan.ToString());
                        if (rows != null && rows.Length > 0)
                        {
                            MessageBox.Show("Giáo dân này đã tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        //check da thuoc ve lop giao ly nao chua
                        DataTable tblCheck = Memory.GetData("select * from ChiTietLopGiaoLy where MaGiaoDan = ? and MaLop in (select MaLop from LopGiaoLy where MaKhoi = ?)", new object[] { maGiaoDan,idKhoi });
                        if (Memory.ShowError()) return false;
                        if (tblCheck != null && tblCheck.Rows.Count > 0)
                        {
                            //string tenGiaDinh = tblCheck.Rows[0][GiaDinhConst.TenGiaDinh].ToString();
                            MessageBox.Show("Giáo dân này đã thuộc về lớp khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;                            
                        }

                        frm.DataReturn.AcceptChanges();
                        frm.DataReturn.SetAdded();
                        frm.DataReturn.Table.Columns.Add("HoanThanh", System.Type.GetType("System.Boolean"));
                        frm.DataReturn.Table.Columns.Add("GhiChuGLy", System.Type.GetType("System.String"));
                        frm.DataReturn.Table.Columns.Add("SoThuTu", System.Type.GetType("System.Int32"));
                        frm.DataReturn["HoanThanh"] = false;
                        frm.DataReturn["GhiChuGLy"] = "";
                        frm.DataReturn["SoThuTu"] = getNextSoThuTu();
                        tbl.ImportRow(frm.DataReturn);
                        //DataRow drHS = tblHocSinh.NewRow();
                        //drHS["MaLop"] = id;
                        //drHS["MaGiaoDan"] = maGiaoDan;
                        //drHS["SoThuTu"] = frm.DataReturn["SoThuTu"];
                        //drHS["HoanThanh"] = false;
                        //drHS["GhiChuGLy"] = "";
                        //tblHocSinh.Rows.Add(drHS);
                        gxHocSinhList1.Row = gxHocSinhList1.RowCount - 1;

                        if (isAdd)
                        {
                            frm = new frmGiaoDan();
                            goto cont;
                        }
                    }
                    else return false;
                }
                else return false;
            }
            else return false;

            return true;
        }

        private bool addGiaoLyVien(frmBase frm, bool isAdd)
        {
        cont:
            if (frm is frmGiaoDan)
            {
                ((frmGiaoDan)frm).FromGiaDinhForm = true;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = (DataTable)gxGiaoLyVien1.DataSource;
                    if (tbl != null)
                    {
                        int maGiaoDan = (int)frm.DataReturn[GiaoDanConst.MaGiaoDan];


                        //check ton tai trong danh sac
                        DataRow[] rows = tbl.Select("MaGiaoDan=" + maGiaoDan.ToString());
                        if (rows != null && rows.Length > 0)
                        {
                            MessageBox.Show("Giáo lý viên này đã tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }                        

                        //frm.DataReturn.AcceptChanges();
                        //frm.DataReturn.SetAdded();
                        tbl.ImportRow(frm.DataReturn);
                        DataRow drGLV = tblGiaoLyVien.NewRow();
                        if (operation == GxOperation.ADD)
                        {
                            drGLV["MaLop"] = Memory.Instance.GetNextId("LopGiaoLy", "malop", true);
                        }
                        else
                        {
                            drGLV["MaLop"] = id;
                        } 

                        drGLV["MaGiaoDan"] = maGiaoDan;
                        tblGiaoLyVien.Rows.Add(drGLV);
                        gxGiaoLyVien1.Row = gxGiaoLyVien1.RowCount - 1;

                        if (isAdd)
                        {
                            frm = new frmGiaoDan();
                            goto cont;
                        }
                    }
                    else return false;
                }
                else return false;
            }
            else return false;

            return true;
        }
        /// <summary>
        /// Dùng trong trường hợp xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            if (gxHocSinhList1.CurrentRow != null)
            {
                int count = gxHocSinhList1.SelectedItems.Count;
                List<int> lstDelete = new List<int>();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in gxHocSinhList1.SelectedItems)
                {
                    lstDelete.Add(item.Position);
                }
                for (int i = 0; i < count; i++)
                {
                    Janus.Windows.GridEX.GridEXRow item = gxHocSinhList1.GetRow(lstDelete[i] - i);
                    DataRowView dtrv = (DataRowView)item.DataRow;
                    if (dtrv != null)
                        lstHSDel.Add(Convert.ToInt32(dtrv.Row["MaGiaoDan"]));
                    
                }
                if (gxHocSinhList1.CurrentRow != null) gxHocSinhList1.CurrentRow.Delete();
                
            }

        }

        private bool checkInput()
        {
            if (txtTenLop.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Hãy nhập tên lớp giáo lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLop.Focus();
                return false;
            }

            //if (txtGiaolyvien1.Text.Trim().Equals(String.Empty))
            //{
            //    MessageBox.Show("Hãy chọn giáo lý viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtGiaolyvien1.Focus();
            //    return false;
            //}
            return true; 
        }


        private void AssignDataSource(DataRow row)
        {
            if (operation == GxOperation.ADD)
            {
                row["malop"] = Memory.Instance.GetNextId("LopGiaoLy", "malop", true);
            }
            else
            {
                row["malop"] = id;
            }            
            row["tenlop"] = txtTenLop.Text;
            row["makhoi"] = idKhoi;
            row["PhongHoc"] = txtPhongHoc.Text;//Khoan add
            row["Nam"] = cbNam.Text;//Khoan add
            row["ghichu"] = txtGhiChu.Text;
        }

        public void AssignControlData()
        {
            DataTable tbl = Memory.GetData(string.Concat("SELECT * FROM LopGiaoLy WHERE MaLop=" + Id));
            //Memory.GetData(string.Concat("SELECT * FROM KhoiGiaoLy WHERE MaKhoi=" + frm.DataReturn["MaKhoi"].ToString()));
            if (tbl != null && tbl.Rows.Count > 0)
            {
                txtTenLop.Text = tbl.Rows[0]["TenLop"].ToString();
                //txtGiaolyvien1.Text = tbl.Rows[0]["GiaoLyVien"].ToString();
                //if (!txtGiaolyvien1.Text.Equals(string.Empty))
                //{
                //    txtGiaolyvien1.MaGiaoDan = 200022;//enalble deletebutton
                //}
                //txtGiaolyvien2.Text = tbl.Rows[0]["GiaoLyVien2"].ToString();
                //if (!txtGiaolyvien2.Text.Equals(string.Empty))
                //{
                //    txtGiaolyvien2.MaGiaoDan = 200022;//enalble deletebutton
                //}
                txtGhiChu.Text = tbl.Rows[0]["GhiChu"].ToString();
                txtPhongHoc.Text = tbl.Rows[0]["PhongHoc"].ToString();//Khoan add
                string where = " and malop=" + Id;
                gxHocSinhList1.LoadData(string.Concat("SELECT * FROM ChiTietLopGiaoLy WHERE 1", where), null);
            }
        }

        
        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            if (!updateLopGiaoLy())
            {
                //this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool updateLopGiaoLy()
        {
            try
            {
                if (!checkInput()) return false;

                DataTable tblLopGiaoLy = Memory.GetData("SELECT * FROM LopGiaoLy WHERE MaLop = ?", new object[] { Id });
                if (Memory.ShowError())
                {
                    return false;
                }
                tblLopGiaoLy.TableName = "LopGiaoLy";

                if (operation == GxOperation.ADD)
                {
                    dataReturn = tblLopGiaoLy.NewRow();
                    AssignDataSource(dataReturn);
                    tblLopGiaoLy.Rows.Add(dataReturn);
                }
                else
                {
                    if (tblLopGiaoLy.Rows.Count > 0)
                    {
                        dataReturn = tblLopGiaoLy.Rows[0];
                        AssignDataSource(dataReturn);
                    }
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(tblLopGiaoLy);
                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblLopGiaoLy);
                ds = new DataSet();
                tblHocSinh = (DataTable)gxHocSinhList1.DataSource;
                //Khoan add start
                foreach (DataRow row in tblHocSinh.Rows)
                {
                    row["MaLop"] = id;
                }
                //Khoan add end
                tblHocSinh.TableName = "ChiTietLopGiaoLy";
                //Khoan delete start
                //tblHocSinh.Columns.Remove("TenThanh");
                //tblHocSinh.Columns.Remove("HoTen");
                //tblHocSinh.Columns.Remove("Phai");
                //tblHocSinh.Columns.Remove("NgaySinh");
                //Khoan delete end
                ds.Tables.Add(tblHocSinh);
                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblHocSinh);
                if (Memory.ShowError())
                {
                    return false;
                }              

                //xoa hoc sinh trong database (co trong lstHSDel)
                foreach (int HSiD in lstHSDel)
                {
                    Memory.ExecuteSqlCommand("delete from ChiTietLopGiaoLy where MaLop = ? and MaGiaoDan = ?", new object[] {id,HSiD});
                }

                //cap nhat hoc sinh trong database (co trong lstHSUp)
                foreach (Giaoly.GhiChuGlyCls item in lstHSUp)
                {
                    Memory.ExecuteSqlCommand("update ChiTietLopGiaoLy set hoanthanh = ?, ghichugly = ? where MaLop = ? and MaGiaoDan = ?", new object[] { item.HoanThanh,item.GhiChu, id, item.MaGiaoDan });
                }
                //cap nhat giao ly vien
                ds = new DataSet();
                ds.Tables.Add(tblGiaoLyVien);
                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblGiaoLyVien);
                //xoa giao ly vien trong database (co trong lstGLVDel)
                foreach (int GLViD in lstGLVDel)
                {
                    Memory.ExecuteSqlCommand("delete from GiaoLyVien where MaLop = ? and MaGiaoDan = ?", new object[] { id, GLViD });
                }
                if (Memory.ShowError())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmLopGiaoLy, gxCommand1_OnOK)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.Export.GridEXExporter ex = new Janus.Windows.GridEX.Export.GridEXExporter();
            ex.GridEX = gxHocSinhList1;

            string filePath = System.IO.Path.GetRandomFileName() + ".xls";
            filePath = Memory.GetTempPath(filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            System.IO.FileStream stream = file.OpenWrite();
            ex.Export((System.IO.Stream)stream);
            stream.Close();
            System.Diagnostics.Process.Start(filePath);
        }
        /// <summary>
        /// lay so thu tu tiep theo cho hoc sinh trong lop
        /// </summary>
        /// <returns>sothutu</returns>
        private int getNextSoThuTu()
        {
            int maxSTT = 1;
            foreach (GridEXRow row in gxHocSinhList1.GetDataRows())
            {
                if (!row.Cells[0].Text.Equals(String.Empty) && Convert.ToInt32(row.Cells[0].Text) >= maxSTT)
                {
                    maxSTT = Convert.ToInt32(row.Cells[0].Text) + 1;
                }
            }

            return maxSTT;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            frmChuyenLop frm = new frmChuyenLop();
            frm.MaLop = id;
            frm.NamGiaoLy = namGLy;
            frm.ShowDialog();            
        }

        private void gxAddEdit2_EditClick(object sender, EventArgs e)
        {
            gxGiaoLyVien1.EditRow();
        }

        private void gxAddEdit2_AddClick(object sender, EventArgs e)
        {
            
            frmGiaoDan frm = new frmGiaoDan();

            bool rs = addGiaoLyVien(frm, true);
            if (rs)
            {
                gxGiaoLyVien1.Row = gxGiaoLyVien1.RowCount - 1;

            }
        }

        private void gxAddEdit2_DeleteClick(object sender, EventArgs e)
        {
            if (gxGiaoLyVien1.CurrentRow != null)
            {
                int count = gxGiaoLyVien1.SelectedItems.Count;
                List<int> lstDelete = new List<int>();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in gxGiaoLyVien1.SelectedItems)
                {
                    lstDelete.Add(item.Position);
                }
                for (int i = 0; i < count; i++)
                {
                    Janus.Windows.GridEX.GridEXRow item = gxGiaoLyVien1.GetRow(lstDelete[i] - i);
                    DataRowView dtrv = (DataRowView)item.DataRow;
                    lstGLVDel.Add(Convert.ToInt32(dtrv.Row["MaGiaoDan"]));

                }
                gxGiaoLyVien1.CurrentRow.Delete();

            }
        }

        private void gxAddEdit2_PrintClick(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.Export.GridEXExporter ex = new Janus.Windows.GridEX.Export.GridEXExporter();
            ex.GridEX = gxGiaoLyVien1;

            string filePath = System.IO.Path.GetRandomFileName() + ".xls";
            filePath = Memory.GetTempPath(filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            System.IO.FileStream stream = file.OpenWrite();
            ex.Export((System.IO.Stream)stream);
            stream.Close();
            System.Diagnostics.Process.Start(filePath);
        }

        private void gxAddEdit2_SelectClick(object sender, EventArgs e)
        {
            frmChonDuLieu frm = new frmChonDuLieu();
            bool rs = addGiaoLyVien(frm, false);
            if (rs)
            {
                gxGiaoLyVien1.Row = gxGiaoLyVien1.RowCount - 1;

            }
        }
    }
}