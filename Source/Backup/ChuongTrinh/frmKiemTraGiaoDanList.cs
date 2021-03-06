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
    public partial class frmKiemTraGiaoDanList : frmBase
    {
        private object[] arguments = null;

        public object[] Arguments
        {
            get { return arguments; }
            set
            {
                arguments = value;
                gxGiaoDanList1.Arguments = value;
            }
        }

        private string queryString = "";

        public string QueryString
        {
            get { return queryString; }
            set
            {
                queryString = value;
                gxGiaoDanList1.QueryString = value;
            }
        }

        public frmKiemTraGiaoDanList()
        {
            InitializeComponent();

            this.HelpKey = "kiem_tra_du_lieu";

            gxAddEdit1.AddButton.Visible = false;

            gxAddEdit1.DeleteButton.Visible = true;

            gxAddEdit1.PrintButton.Visible = true;
            gxAddEdit1.PrintButton.Text = "&In danh sách";
            gxAddEdit1.PrintButton.Click += new EventHandler(btnInDanhSach_Click);

            gxAddEdit1.FindButton.Visible = true;
            gxAddEdit1.FindButton.Text = "Tìm &kiếm trên lưới";

            gxAddEdit1.EditButton.Visible = true;

            gxAddEdit1.SelectButton.Visible = false;

            gxCommand1.OKButton.Visible = false;
            gxCommand1.CancelButton.Text = "Đó&ng";
            cbGiaoHo.GridGiaoDan = gxGiaoDanList1;

            gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);
            gxGiaoDanList1.FilterApplied += new EventHandler(gxGiaoDanList1_FilterApplied);
            gxGiaoDanList1.RowCountChanged += new EventHandler(gxGiaoDanList1_RowCountChanged);

            lblTotal.Text = "";
            cbGiaoHo.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);
            gxAddEdit1.ReloadButton.Enabled = false;
        }

        public void LoadGiaoDanList(string sql)
        {
            gxGiaoDanList1.LoadData(sql, null);
        }

        public void LoadGiaoDanList(string sql, object[] arguments)
        {
            gxGiaoDanList1.LoadData(sql, arguments);
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
            if (Memory.Instance.GetMemory(GxConstants.DangTimKiemGiaDinhGiaoDan) == null)
            {
                if (Memory.CurrentGiaoHo > -1)
                {
                    cbGiaoHo.MaGiaoHo = Memory.CurrentGiaoHo;
                }
            }
            else
            {
                gxGiaoDanList1.LoadData();
            }
            Memory.Instance.SetMemory(GxConstants.DangTimKiemGiaDinhGiaoDan, null);
        }

        private void LoadGiaoDanList()
        {
            string where = " AND DaXoa=0 AND DaChuyenXu=0 ";
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
                if (MessageBox.Show("Bạn có chắc muốn xóa giáo dân này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                Memory.ExecuteSqlCommand(SqlConstants.DELETE_GIAODAN, 
                                                    new object[] { (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row[GiaoDanConst.MaGiaoDan] });
                if (Memory.ShowError())
                {
                    return;
                }
                gxGiaoDanList1.CurrentRow.Delete();
            }
        }

        private void gxGiaoDanList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //EditRow();
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

        private void gxButton1_Click(object sender, EventArgs e)
        {
            if (cbGiaoHo.Combo.Text == "")
            {
                MessageBox.Show("Hãy chọn giáo họ cần kiểm tra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbGiaoHo.Focus();
                return;
            }
            if (!chkKhongCoNgayThang.Checked &&
                !chkKhongThuocGiaDinh.Checked &&
                !chkRuocLeTruocTuoi.Checked &&
                !chkSaiQuanHeNgayThang.Checked &&
                !chkThuocNhieuGiaDinh.Checked && 
                !chkNhieuHonPhoi.Checked)
            {
                MessageBox.Show("Hãy chọn ít nhất 1 loại kiểm tra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmProcess frmUpdate = new frmProcess();
            frmUpdate.LabelStart = "Đang kiểm tra dữ liệu giáo dân...";
            frmUpdate.LableFinished = "Đã kiểm tra xong!";
            frmUpdate.Text = "Đang kiểm tra dữ liệu giáo dân. Có thể mất vài phút. Xin vui lòng đợi...";
            ReviewGiaoDanProcess ProcessClass = new ReviewGiaoDanProcess();
            ProcessClass.KiemTraKhongNgayThang = chkKhongCoNgayThang.Checked;
            ProcessClass.KiemTraKhongThuocGiaDinh = chkKhongThuocGiaDinh.Checked;
            ProcessClass.KiemTraNhieuGiaDinh = chkThuocNhieuGiaDinh.Checked;
            ProcessClass.KiemTraRuaToiTruocTuoi = chkRuocLeTruocTuoi.Checked;
            ProcessClass.KiemTraSaiQuanHeNgayThang = chkSaiQuanHeNgayThang.Checked;
            ProcessClass.KiemTraNhieuHonPhoi = chkNhieuHonPhoi.Checked;

            ProcessClass.MaGiaoHo = (int)cbGiaoHo.SelectedValue;
            frmUpdate.ProcessClass = ProcessClass;
            frmUpdate.FinishedFunction = new EventHandler(reviewFinished);
            frmUpdate.ShowDialog();
        }

        private void reviewFinished(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if ((sender as DataTable).Rows.Count == 0)
                {
                    if (gxGiaoDanList1.DataSource != null)
                    {
                        (gxGiaoDanList1.DataSource as DataTable).Rows.Clear();
                    }
                    MessageBox.Show("Không tìm thấy lỗi dữ liệu của giáo dân nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    gxGiaoDanList1.DataSource = sender;
                    //string s = (sender as DataTable).Rows[0]["NguyenNhan"].ToString();
                    //MessageBox.Show(s.Substring(s.Length - 2));
                }
            }
        }
    }
}