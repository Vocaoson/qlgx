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
    public partial class frmGiaoDanList : frmBase
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

        public int MaGiaoHo
        {
            get { return cbGiaoHo.MaGiaoHo; }
            set
            {
                cbGiaoHo.AutoLoadGrid = false;
                cbGiaoHo.MaGiaoHo = value;
                cbGiaoHo.AutoLoadGrid = true;
            }
        }

        public frmGiaoDanList()
        {
            InitializeComponent();

            this.HelpKey = "giao_dan";

            //gxAddEdit1.PrintButton.Text = "&In danh sách giáo dân";
            gxAddEdit1.PrintButton.Click += new EventHandler(btnInDanhSach_Click);

            gxAddEdit1.Button1.Text = "In chứng nhận &bí tích";
            gxAddEdit1.Button1.Click += new EventHandler(btnInChungNhanBiTich_Click);

            gxAddEdit1.Button2.Text = "In giới thiệu &hôn phối";
            gxAddEdit1.Button2.Click += new EventHandler(btnInGioiThieuHonPhoi_Click);
            gxAddEdit1.FindButton.Enabled = false;

            //gxAddEdit1.ReloadButton.Text = "&Tải lại dữ liệu";
            gxAddEdit1.ReloadButton.Visible = true;
            gxAddEdit1.GridData = gxGiaoDanList1;

            //gxAddEdit1.FindButton.Text = "Tìm &kiếm trên lưới";
            //gxAddEdit1.FindButton.Click += new EventHandler(FindButton_Click);

            gxAddEdit1.DisplayMode = DisplayMode.Full;

            gxAddEdit1.SelectButton.Visible = false;

            gxCommand1.OKButton.Visible = false;
            gxCommand1.CancelButton.Text = "Đó&ng";
            cbGiaoHo.GridGiaoDan = gxGiaoDanList1;

            gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);
            gxGiaoDanList1.FilterApplied += new EventHandler(gxGiaoDanList1_FilterApplied);
            gxGiaoDanList1.RowCountChanged += new EventHandler(gxGiaoDanList1_RowCountChanged);

            lblTotal.Text = "";
            cbGiaoHo.AutoLoadGrid = false;
            cbGiaoHo.IsAo = Janus.Windows.GridEX.TriState.False;
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

        public GxGiaoDanList GiaoDanList
        {
            get { return gxGiaoDanList1; }
            set { gxGiaoDanList1 = value; }
        }

        private void gxGiaoDanList1_FilterApplied(object sender, EventArgs e)
        {
            
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gxAddEdit1.ReloadButton.Enabled = true;
            gxAddEdit1.FindButton.Enabled = true;
        }

        protected virtual void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
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

        protected override void OnLoad(EventArgs e)
        {
            gxGiaoDanList1.FormatGrid();
            //Show "Tất cả" item and Load default data
            cbGiaoHo.HasShowAll = true;
            cbGiaoHo.AutoLoadGrid = true;
            if (Memory.Instance.GetMemory(GxConstants.DangTimKiemGiaDinhGiaoDan) == null)
            {
                if (Memory.CurrentGiaoHo > 0)
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
                        gxGiaoDanList1.FindAll(gxGiaoDanList1.RootTable.Columns[0], Janus.Windows.GridEX.ConditionOperator.Equal, frm.DataReturn[GiaoDanConst.MaGiaoDan]);
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
                DialogResult rs = MessageBox.Show("Bạn muốn xóa vĩnh viễn giáo dân được chọn không?\r\nChọn [Yes] để xóa vĩnh viễn.\r\nChọn [No] để đưa vào hồ sơ lưu trữ.\r\nChọn [Cancel] hủy bỏ việc xóa.", "Xác nhận xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.Cancel) return;

                int maGiaoDan = (int)(gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row[GiaoDanConst.MaGiaoDan];
                if (rs == DialogResult.No)
                {
                    Memory.ExecuteSqlCommand(SqlConstants.DELETE_GIAODAN,
                                                        new object[] { maGiaoDan });
                    if (Memory.ShowError())
                    {
                        return;
                    }
                }
                else if (rs == DialogResult.Yes)
                {
                    Memory.ExecuteSqlCommand("DELETE FROM GiaoDan WHERE MaGiaoDan=?",
                                                        new object[] { maGiaoDan });
                    if (Memory.ShowError())
                    {
                        return;
                    }
                    Memory.ExecuteSqlCommand("DELETE FROM ThanhVienGiaDinh WHERE MaGiaoDan=?",
                                                        new object[] { maGiaoDan });
                    if (Memory.ShowError())
                    {
                        return;
                    }
                    Memory.ExecuteSqlCommand("DELETE FROM BiTichChiTiet WHERE MaGiaoDan=?",
                                                        new object[] { maGiaoDan });
                    if (Memory.ShowError())
                    {
                        return;
                    }
                    Memory.ExecuteSqlCommand("DELETE FROM ChiTietLopGiaoLy WHERE MaGiaoDan=?",
                                                        new object[] { maGiaoDan });
                    if (Memory.ShowError())
                    {
                        return;
                    }
                }
                Janus.Windows.GridEX.GridEXRow item = gxGiaoDanList1.GetRow(gxGiaoDanList1.SelectedItems[0].Position);
                item.Delete();

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

        private void frmGiaoDanList_Load(object sender, EventArgs e)
        {
            
        }
    }
}