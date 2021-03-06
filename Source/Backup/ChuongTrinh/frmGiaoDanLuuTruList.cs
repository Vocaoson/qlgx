using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using GxControl;

namespace GiaoXu
{
    public partial class frmGiaoDanLuuTruList : frmBase
    {
        public frmGiaoDanLuuTruList()
        {
            InitializeComponent();

            this.HelpKey = "giao_dan_luu_tru";

            gxAddEdit1.DeleteButton.Text = "&Xóa bỏ";

            //gxAddEdit1.PrintButton.Text = "&In danh sách giáo dân";
            gxAddEdit1.PrintButton.Click += new EventHandler(btnInDanhSach_Click);

            gxAddEdit1.Button1.Text = "In chứng nhận &bí tích";
            gxAddEdit1.Button1.Click += new EventHandler(btnInChungNhanBiTich_Click);

            gxAddEdit1.Button2.Text = "In giới thiệu &hôn phối";
            gxAddEdit1.Button2.Click += new EventHandler(btnInGioiThieuHonPhoi_Click);

            //gxAddEdit1.ReloadButton.Text = "&Tải lại dữ liệu";
            gxAddEdit1.ReloadButton.Visible = true;
            gxAddEdit1.GridData = gxGiaoDanList1;
            gxAddEdit1.FindButton.Enabled = false;

            //gxAddEdit1.FindButton.Text = "Tìm &kiếm trên lưới";
            //gxAddEdit1.FindButton.Click += new EventHandler(FindButton_Click);

            gxAddEdit1.DisplayMode = DisplayMode.Full;

            gxAddEdit1.SelectButton.Visible = false;
            gxAddEdit1.AddButton.Visible = false;

            gxCommand1.OKButton.Visible = false;
            gxCommand1.CancelButton.Text = "Đó&ng";
            cbGiaoHo.GridGiaoDan = gxGiaoDanList1;
            cbGiaoHo.IsLuuTru = true;

            gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);
            gxGiaoDanList1.FilterApplied += new EventHandler(gxGiaoDanList1_FilterApplied);
            gxGiaoDanList1.RowCountChanged += new EventHandler(gxGiaoDanList1_RowCountChanged);

            lblTotal.Text = "";
            cbGiaoHo.AutoLoadGrid = false;
            cbGiaoHo.IsAo = Janus.Windows.GridEX.TriState.False;
            cbGiaoHo.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);
            gxAddEdit1.ReloadButton.Enabled = false;
        }

        private void gxGiaoDanList1_RowCountChanged(object sender, EventArgs e)
        {
            lblTotal.Text = gxGiaoDanList1.RowCount.ToString() + " giáo dân";
        }

        private void gxGiaoDanList1_FilterApplied(object sender, EventArgs e)
        {
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gxAddEdit1.ReloadButton.Enabled = true;
            gxAddEdit1.FindButton.Enabled = true;
        }

        private void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            lblTotal.Text = gxGiaoDanList1.RowCount.ToString() + " giáo dân";
        }

        //void FindButton_Click(object sender, EventArgs e)
        //{
        //    frmFilter frm = new frmFilter();
        //    Dictionary<object, object> dic = new Dictionary<object, object>();
        //    dic.Add(GiaoDanConst.HoTen, "");
        //    frm.GrdData = this.gxGiaoDanList1;
        //    frm.FilterParameter = dic;
        //    frm.ShowDialog();
        //}
        private void btnInChungNhanBiTich_Click(object sender, EventArgs e)
        {
            gxGiaoDanList1.XuatChungNhanBiTich();
        }

        private void cbGiaoHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadGiaoDanList();
        }

        private void frmGiaoDanList_Load(object sender, EventArgs e)
        {
            gxGiaoDanList1.FormatGrid();
            //Show "Tất cả" item and Load default data
            cbGiaoHo.HasShowAll = true;
            cbGiaoHo.AutoLoadGrid = true;
            if (Memory.CurrentGiaoHo > 0) cbGiaoHo.MaGiaoHo = Memory.CurrentGiaoHo;
        }

        private void LoadGiaoDanList()
        {
            string where = " AND (DaXoa=-1 OR DaChuyenXu=-1) ";
            if (cbGiaoHo.MaGiaoHo > -1)
            {
                where = string.Format(" AND (MaGiaoHo={0}) ", cbGiaoHo.MaGiaoHo);
            }
            gxGiaoDanList1.LoadData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO + where, null);
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            //if (gxGiaoDanList1.CurrentRow == null || (gxGiaoDanList1.CurrentRow.DataRow as DataRowView) == null) return;
            frmGiaoDan frm = new frmGiaoDan();
        cont:
            if (frm is frmGiaoDan)
            {
                if (cbGiaoHo.MaGiaoHo > -1)
                {
                    ((frmGiaoDan)frm).MaGiaoHo = cbGiaoHo.MaGiaoHo;
                }
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = (DataTable)gxGiaoDanList1.DataSource;
                    if (tbl != null)
                    {
                        tbl.ImportRow(frm.DataReturn);
                        frm = new frmGiaoDan();
                        goto cont;
                    }
                }
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            gxGiaoDanList1.EditRow();
        }

        /// <summary>
        /// Truong hop xoa 1 gia dinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (gxGiaoDanList1.CurrentRow != null && (gxGiaoDanList1.CurrentRow.DataRow as DataRowView) != null)
            {
                if (MessageBox.Show("Nếu bạn chọn xóa giáo dân khỏi hồ sơ lưu trữ, giáo dân này sẽ vĩnh viễn bị xóa khỏi chương trình\r\nBạn có chắc muốn xóa giáo dân này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;

                object maGiaoDan = (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row[GiaoDanConst.MaGiaoDan];
                //Delete bi tich chi tiet
                Memory.DeleteRows(BiTichChiTietConst.TableName, BiTichChiTietConst.MaGiaoDan, maGiaoDan);
                if (Memory.ShowError()) return;
                //Delete thanh vien gia dinh
                Memory.DeleteRows(ThanhVienGiaDinhConst.TableName, ThanhVienGiaDinhConst.MaGiaoDan, maGiaoDan);
                if (Memory.ShowError()) return;
                //delete chuyen xu
                Memory.DeleteRows(ChuyenXuConst.TableName, ChuyenXuConst.MaGiaoDan, maGiaoDan);
                if (Memory.ShowError()) return;
                //delete giao dan hon phoi
                Memory.DeleteRows(GiaoDanHonPhoiConst.TableName, ChuyenXuConst.MaGiaoDan, maGiaoDan);
                //delete Tan Hien
                Memory.DeleteRows(TanHienConst.TableName, ChuyenXuConst.MaGiaoDan, maGiaoDan);
                if (Memory.ShowError()) return;
                //delete rao hon phoi
                string sql = @"DELETE FROM RaoHonPhoi
                                     WHERE MaGiaoDan1=?
                                        OR MaGiaoDan2=?";
                Memory.ExecuteSqlCommand(sql, new object[] { maGiaoDan, maGiaoDan });

                if (Memory.ShowError())
                {
                    return;
                }
                //delete giao dan
                Memory.DeleteRows(GiaoDanConst.TableName, GiaoDanConst.MaGiaoDan, maGiaoDan);
                if (Memory.ShowError()) return;
                
                gxGiaoDanList1.CurrentRow.Delete();

            }
        }

        private void gxGiaoDanList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            EditRow();
        }

        private void EditRow()
        {
            //if (gxGiaoDanList1.CurrentRow == null || (gxGiaoDanList1.CurrentRow.DataRow as DataRowView) == null) return;
            //frmGiaoDan frm = new frmGiaoDan();
            //frm.Operation = GxOperation.EDIT;
            //DataRow row = (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row;
            //frm.Id = (int)row[GiaoDanConst.MaGiaoDan];
            //frm.AssignControlData();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    if (frm.DataReturn != null)
            //    {
            //        row[GiaoDanConst.TenThanh] = frm.DataReturn[GiaoDanConst.TenThanh];
            //        row[GiaoDanConst.HoTen] = frm.DataReturn[GiaoDanConst.HoTen];
            //        row[GiaoDanConst.NgaySinh] = frm.DataReturn[GiaoDanConst.NgaySinh];
            //        row[GiaoDanConst.Phai] = frm.DataReturn[GiaoDanConst.Phai];
            //        row[GiaoHoConst.TenGiaoHo] = frm.DataReturn[GiaoHoConst.TenGiaoHo];
            //    }
            //}
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInGioiThieuHonPhoi_Click(object sender, EventArgs e)
        {
            gxGiaoDanList1.XuatGioiThieuHonPhoi();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.Export.GridEXExporter ex = new Janus.Windows.GridEX.Export.GridEXExporter();
            ex.GridEX = gxGiaoDanList1;

            string filePath = System.IO.Path.GetRandomFileName() + ".xls";
            filePath = Memory.GetTempPath(filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            System.IO.FileStream stream = file.OpenWrite();
            ex.Export((System.IO.Stream)stream);
            stream.Close();
            System.Diagnostics.Process.Start(filePath);
        }

        private void chkGiaoDanAo_CheckedChanged(object sender, EventArgs e)
        {
            cbGiaoHo.IsAo = chkGiaoDanAo.Checked ? Janus.Windows.GridEX.TriState.True : Janus.Windows.GridEX.TriState.False;
        }
    }
}