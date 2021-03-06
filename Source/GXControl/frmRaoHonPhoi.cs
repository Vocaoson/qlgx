using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;

namespace GxControl
{
    public partial class frmRaoHonPhoi : frmBase
    {
        public frmRaoHonPhoi()
        {
            InitializeComponent();
            gxCommand1.OKButton.Left = gxCommand1.CancelButton.Left - GxConstants.CONTROL_DIS - gxCommand1.OKButton.Width;
            this.AcceptButton = gxCommand1.OKButton;
            //load linh muc combobox
            DataTable tblLinhMuc = Memory.GetData(SqlConstants.SELECT_LINHMUC_LIST + " AND DenNgay IS NULL ");
            if (!Memory.ShowError() && tblLinhMuc != null)
            {
                foreach (DataRow row in tblLinhMuc.Rows)
                {
                    cbChaGui.Combo.Items.Add(row[LinhMucConst.TenThanh].ToString() + " " + row[LinhMucConst.HoTen].ToString());
                }
                if (cbChaGui.Combo.Items.Count > 0) cbChaGui.Combo.SelectedIndex = 0;
            }
            gxCommand1.OKIsAccept = true;
            txtNguoi1.OnSelected += new EventHandler(txtNguoi1_OnSelected);
            txtNguoi2.OnSelected += new EventHandler(txtNguoi2_OnSelected);
            txtNguoi1.OnSelecting += new GxGiaoDan.SelectingHandler(txtNguoi1_OnSelecting);
            txtNguoi2.OnSelecting += new GxGiaoDan.SelectingHandler(txtNguoi2_OnSelecting);
            dtNgayRao1.DateInput.OnOK += new EventHandler(NgayRaoLan1_DateInput_OnOK);
        }

        private int maRaoHonPhoi = -1;

        public int MaRaoHonPhoi
        {
            get { return maRaoHonPhoi; }
            set
            {
                maRaoHonPhoi = value;
                if (value > -1 && !Memory.IsDesignMode)
                {
                    DataTable tbl = Memory.GetData(SqlConstants.SELECT_RAOHONPHOI_LIST + " AND MaRaoHonPhoi=?", new object[] { value });
                    if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0)
                    {
                        AssignControlData(tbl.Rows[0]);
                    }
                }
            }
        }

        private bool usePrint = false;

        public bool UsePrint
        {
            get { return usePrint; }
            set 
            { 
                usePrint = value;
                uiGroupBox1.Visible = value;
                if (!value)
                {
                    this.Height -= uiGroupBox1.Height;
                    gxCommand1.OKButton.Text = "&Cập nhật";
                }
                else
                {
                    gxCommand1.OKButton.Text = "&Cập nhật và xuất tờ rao";
                    gxCommand1.ToolTipOK = "Xuất tờ rao hôn phối cho các giáo dân này ra excel";
                }
            }
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            if (usePrint && txtChaNhan.Text == "")
            {
                MessageBox.Show("Hãy nhập cha nhận điều tra hôn phối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChaNhan.Focus();
                return;
            }

            if (usePrint && txtGiaoXuNhan.Text == "")
            {
                MessageBox.Show("Hãy nhập giáo xứ nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaoXuNhan.Focus();
                return;
            }

            if (txtNguoi1.CurrentRow == null)
            {
                MessageBox.Show("Xin vui lòng nhập thông tin người thứ nhất cần rao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDoiRao.Text.Trim() == "")
            {
                MessageBox.Show("Xin vui lòng nhập [đôi rao]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNguoi2.CurrentRow == null)
            {
                MessageBox.Show("Xin vui lòng nhập thông tin người thứ hai cần rao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isValidDate(dtNgayRao1))
            {
                MessageBox.Show("Xin vui lòng kiểm tra lại ngày rao lần thứ nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayRao1.Focus();
                return;
            }

            if (!isValidDate(dtNgayRao2))
            {
                MessageBox.Show("Xin vui lòng kiểm tra lại ngày rao lần thứ hai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayRao2.Focus();
                return;
            }

            if (!isValidDate(dtNgayRao3))
            {
                MessageBox.Show("Xin vui lòng kiểm tra lại ngày rao lần thứ ba", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayRao3.Focus();
                return;
            }

            if (UpdateData())
            {
                if (usePrint && GetDataRaoHonPhoi(txtNguoi1.CurrentRow, txtNguoi2.CurrentRow))
                {
                    int rs = ExcelReport.ReportRaoHP.Export(DataObj);
                    Memory.ShowError();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
        }

        private bool isValidDate(GxDateField dt)
        {
            if (dt.DateInput.Day == "" || dt.DateInput.Month == "" || dt.DateInput.Year == ""
                || !Validator.IsDate(dt.DateInput.Year, dt.DateInput.Month, dt.DateInput.Day))
            {
                return false;
            }
            return true;
        }

        public bool GetDataRaoHonPhoi(DataRow row1, DataRow row2)
        {
            try
            {
                DataObj = new DataSet();
                //Get Giaoxu info
                //Get Giaoxu info
                DataTable tblGiaoXu = Memory.GetData(SqlConstants.SELECT_GIAOXU);
                if (Memory.ShowError())
                {
                    return false;
                }
                if (tblGiaoXu.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin giáo xứ. Vui lòng nhập thông tin giáo xứ trước khi sử dụng chức năng này.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                tblGiaoXu.TableName = GiaoXuConst.TableName;
                DataObj.Tables.Add(tblGiaoXu);

                //get main report data
                DataTable tblReportRaoHonPhoi = new DataTable(ReportRaoHonPhoiConst.TableName);
                //Add columns
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.HoTen1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.HoTen2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.AnhChi1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.AnhChi2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.Tuoi1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.Tuoi2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NgaySinh1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NgaySinh2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NgayThangNam);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NoiSinh1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NoiSinh2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenCha1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenCha2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoPhan1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoPhan2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoPhanTruoc1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoPhanTruoc2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoXu1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoXu2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoXuTruoc1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoXuTruoc2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenLinhMucGui);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenLinhMucNhan);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.GiaoXuNhan);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenMe1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenMe2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NgayRT1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NoiRT1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.SoRT1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NgayRT2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.NoiRT2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.SoRT2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoXuNQ1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoXuNQ2);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoPhanNQ1);
                tblReportRaoHonPhoi.Columns.Add(ReportRaoHonPhoiConst.TenGiaoPhanNQ2);
                //Assign value
                DataRow newRow = tblReportRaoHonPhoi.NewRow();
                newRow[ReportRaoHonPhoiConst.HoTen1] = string.Format("{0} {1}", row1[GiaoDanConst.TenThanh], row1[GiaoDanConst.HoTen]);
                newRow[ReportRaoHonPhoiConst.HoTen2] = string.Format("{0} {1}", row2[GiaoDanConst.TenThanh], row2[GiaoDanConst.HoTen]);
                newRow[ReportRaoHonPhoiConst.NgaySinh1] = row1[GiaoDanConst.NgaySinh];
                newRow[ReportRaoHonPhoiConst.NgaySinh2] = row2[GiaoDanConst.NgaySinh];

                newRow[ReportRaoHonPhoiConst.AnhChi1] = row1[GiaoDanConst.Phai].ToString() == GxConstants.NAM ? "anh" : "chị";
                newRow[ReportRaoHonPhoiConst.AnhChi2] = row2[GiaoDanConst.Phai].ToString() == GxConstants.NAM ? "anh" : "chị";

                newRow[ReportRaoHonPhoiConst.Tuoi1] = Memory.GetTuoi(row1[GiaoDanConst.NgaySinh].ToString());
                newRow[ReportRaoHonPhoiConst.Tuoi2] = Memory.GetTuoi(row2[GiaoDanConst.NgaySinh].ToString());

                if (Memory.GetConfig(GxConstants.CF_LANGUAGE) == GxConstants.LANG_EN)
                {
                    newRow[ReportRaoHonPhoiConst.NgayThangNam] = Memory.GetReportNgayThangNamEn();
                }
                else
                {
                    newRow[ReportRaoHonPhoiConst.NgayThangNam] = Memory.GetReportNgayThangNamVn();
                }
                newRow[ReportRaoHonPhoiConst.NoiSinh1] = row1[GiaoDanConst.NoiSinh];
                newRow[ReportRaoHonPhoiConst.NoiSinh2] = row2[GiaoDanConst.NoiSinh];

                newRow[ReportRaoHonPhoiConst.NgayRT1] = row1[GiaoDanConst.NgayRuaToi];
                newRow[ReportRaoHonPhoiConst.NoiRT1] = row1[GiaoDanConst.NoiRuaToi];
                newRow[ReportRaoHonPhoiConst.SoRT1] = row1[GiaoDanConst.SoRuaToi];

                newRow[ReportRaoHonPhoiConst.NgayRT2] = row2[GiaoDanConst.NgayRuaToi];
                newRow[ReportRaoHonPhoiConst.NoiRT2] = row2[GiaoDanConst.NoiRuaToi];
                newRow[ReportRaoHonPhoiConst.SoRT2] = row2[GiaoDanConst.SoRuaToi];

                newRow[ReportRaoHonPhoiConst.TenGiaoXuNQ1] = txtGiaoXuNQ1.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoPhanNQ1] = txtGiaoPhanNQ1.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoXuNQ2] = txtGiaoXuNQ2.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoPhanNQ2] = txtGiaoPhanNQ2.Text;

                newRow[ReportRaoHonPhoiConst.TenGiaoPhan1] = txtGiaoPhan1.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoPhan2] = txtGiaoPhan2.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoPhanTruoc1] = txtGiaoPhanTruoc1.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoPhanTruoc2] = txtGiaoPhanTruoc2.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoXu1] = txtGiaoXu1.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoXu2] = txtGiaoXu2.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoXuTruoc1] = txtGiaoXuTruoc1.Text;
                newRow[ReportRaoHonPhoiConst.TenGiaoXuTruoc2] = txtGiaoXuTruoc2.Text;
                newRow[ReportRaoHonPhoiConst.TenLinhMucGui] = cbChaGui.Text;
                newRow[ReportRaoHonPhoiConst.TenLinhMucNhan] = txtChaNhan.Text;
                newRow[ReportRaoHonPhoiConst.GiaoXuNhan] = txtGiaoXuNhan.Text;

                Dictionary<object, object> dicChaMe = GxGiaDinhList.GetTenChaMe((int)row1[GiaoDanConst.MaGiaoDan], row1[GiaoDanConst.HoTenCha], row1[GiaoDanConst.HoTenMe]);
                newRow[ReportRaoHonPhoiConst.TenCha1] = dicChaMe[GxConstants.VAITRO_CHONG];
                newRow[ReportRaoHonPhoiConst.TenMe1] = dicChaMe[GxConstants.VAITRO_VO];

                dicChaMe = GxGiaDinhList.GetTenChaMe((int)row2[GiaoDanConst.MaGiaoDan], row2[GiaoDanConst.HoTenCha], row2[GiaoDanConst.HoTenMe]);
                newRow[ReportRaoHonPhoiConst.TenCha2] = dicChaMe[GxConstants.VAITRO_CHONG];
                newRow[ReportRaoHonPhoiConst.TenMe2] = dicChaMe[GxConstants.VAITRO_VO];

                tblReportRaoHonPhoi.Rows.Add(newRow);
                DataObj.Tables.Add(tblReportRaoHonPhoi);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateData()
        {
            DataTable tblRaoHonPhoi = Memory.GetTable(RaoHonPhoiConst.TableName, "AND MaRaoHonPhoi=" + maRaoHonPhoi.ToString());
            if (!Memory.ShowError() && tblRaoHonPhoi != null)
            {
                DataRow row = null;
                if (operation == GxOperation.EDIT && tblRaoHonPhoi.Rows.Count > 0)
                {
                    row = tblRaoHonPhoi.Rows[0];
                    AssignDataSource(row);
                }
                else
                {
                    row = tblRaoHonPhoi.NewRow();
                    maRaoHonPhoi = Memory.Instance.GetNextId(RaoHonPhoiConst.TableName, RaoHonPhoiConst.MaRaoHonPhoi, true);
                    AssignDataSource(row);
                    tblRaoHonPhoi.Rows.Add(row);
                }
                DataReturn = row;
                if (tblRaoHonPhoi.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    tblRaoHonPhoi.TableName = RaoHonPhoiConst.TableName;
                    ds.Tables.Add(tblRaoHonPhoi);
                    Memory.UpdateDataSet(ds);
                    if (Memory.ShowError())
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public void AssignDataSource(DataRow row)
        {
            row[RaoHonPhoiConst.MaRaoHonPhoi] = maRaoHonPhoi;
            row[RaoHonPhoiConst.TenRaoHonPhoi] = txtDoiRao.Text;
            row[RaoHonPhoiConst.MaGiaoDan1] = txtNguoi1.MaGiaoDan;
            row[RaoHonPhoiConst.MaGiaoDan2] = txtNguoi2.MaGiaoDan;
            row[RaoHonPhoiConst.GhiChu] = txtGhiChu.Text;
            row[RaoHonPhoiConst.GiaoPhan1] = txtGiaoPhan1.Text;
            row[RaoHonPhoiConst.GiaoPhan2] = txtGiaoPhan2.Text;
            row[RaoHonPhoiConst.GiaoPhanTruoc1] = txtGiaoPhanTruoc1.Text;
            row[RaoHonPhoiConst.GiaoPhanTruoc2] = txtGiaoPhanTruoc2.Text;
            row[RaoHonPhoiConst.GiaoXu1] = txtGiaoXu1.Text;
            row[RaoHonPhoiConst.GiaoXu2] = txtGiaoXu2.Text;
            row[RaoHonPhoiConst.GiaoXuNhan] = txtGiaoXuNhan.Text;
            row[RaoHonPhoiConst.GiaoXuTruoc1] = txtGiaoXuTruoc1.Text;
            row[RaoHonPhoiConst.GiaoXuTruoc2] = txtGiaoXuTruoc2.Text;
            row[RaoHonPhoiConst.LinhMucNhan] = txtChaNhan.Text;
            row[RaoHonPhoiConst.NgayRaoLan1] = dtNgayRao1.Value;
            row[RaoHonPhoiConst.NgayRaoLan2] = dtNgayRao2.Value;
            row[RaoHonPhoiConst.NgayRaoLan3] = dtNgayRao3.Value;
            row[RaoHonPhoiConst.UpdateDate] = Memory.Instance.GetServerDateTime();

            row[RaoHonPhoiConst.GiaoXuNQ1] = txtGiaoXuNQ1.Text;
            row[RaoHonPhoiConst.GiaoPhanNQ1] = txtGiaoPhanNQ1.Text;
            row[RaoHonPhoiConst.GiaoXuNQ2] = txtGiaoXuNQ2.Text;
            row[RaoHonPhoiConst.GiaoPhanNQ2] = txtGiaoPhanNQ2.Text;

        }

        public void AssignControlData(DataRow row)
        {
            maRaoHonPhoi = (int)row[RaoHonPhoiConst.MaRaoHonPhoi];
            txtDoiRao.Text = row[RaoHonPhoiConst.TenRaoHonPhoi].ToString();
            txtNguoi1.MaGiaoDan = (int)row[RaoHonPhoiConst.MaGiaoDan1];
            txtNguoi2.MaGiaoDan = (int)row[RaoHonPhoiConst.MaGiaoDan2];
            txtGhiChu.Text = row[RaoHonPhoiConst.GhiChu].ToString();
            txtGiaoPhan1.Text = row[RaoHonPhoiConst.GiaoPhan1].ToString();
            txtGiaoPhan2.Text = row[RaoHonPhoiConst.GiaoPhan2].ToString();
            txtGiaoPhanTruoc1.Text = row[RaoHonPhoiConst.GiaoPhanTruoc1].ToString();
            txtGiaoPhanTruoc2.Text = row[RaoHonPhoiConst.GiaoPhanTruoc2].ToString();
            txtGiaoXu1.Text = row[RaoHonPhoiConst.GiaoXu1].ToString();
            txtGiaoXu2.Text = row[RaoHonPhoiConst.GiaoXu2].ToString();
            txtGiaoXuNhan.Text = row[RaoHonPhoiConst.GiaoXuNhan].ToString();
            txtGiaoXuTruoc1.Text = row[RaoHonPhoiConst.GiaoXuTruoc1].ToString();
            txtGiaoXuTruoc2.Text = row[RaoHonPhoiConst.GiaoXuTruoc2].ToString();
            txtChaNhan.Text = row[RaoHonPhoiConst.LinhMucNhan].ToString();
            dtNgayRao1.Value = row[RaoHonPhoiConst.NgayRaoLan1];
            dtNgayRao2.Value = row[RaoHonPhoiConst.NgayRaoLan2];
            dtNgayRao3.Value = row[RaoHonPhoiConst.NgayRaoLan3];

            txtGiaoXuNQ1.Text = row[RaoHonPhoiConst.GiaoXuNQ1].ToString();
            txtGiaoPhanNQ1.Text = row[RaoHonPhoiConst.GiaoPhanNQ1].ToString();
            txtGiaoXuNQ2.Text = row[RaoHonPhoiConst.GiaoXuNQ2].ToString();
            txtGiaoPhanNQ2.Text = row[RaoHonPhoiConst.GiaoPhanNQ2].ToString();
        }

        private void frmReportRaoHP_Load(object sender, EventArgs e)
        {
            if (maRaoHonPhoi == -1)
            {
                txtNguoi1.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            }
        }

        private void assignNguoi1(DataRow row)
        {
            txtNguoi1.CurrentRow = row;
        }

        private void txtNguoi1_OnSelected(object sender, EventArgs e)
        {
            if (sender == null) return;

            DataRow row = (DataRow)sender;
            txtGiaoXu1.Text = Memory.GetThuocXu(row);
            if ((int)row[GiaoDanConst.MaGiaoHo] > 0 && Memory.GiaoXuInfo != null) //Neu thuoc trong xu
            {
                txtGiaoPhan1.Text = Memory.GiaoXuInfo[GiaoPhanConst.TenGiaoPhan].ToString();
            }
            //Lay thong tin giao xu truoc
            DataTable tblChuyenXu = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID + " AND ChuyenXu.LoaiChuyen =?",
                new object[] { row[GiaoDanConst.MaGiaoDan], (int)LoaiChuyenXu.ChuyenDen });
            if (!Memory.ShowError())
            {
                if (tblChuyenXu != null && tblChuyenXu.Rows.Count > 0)
                {
                    txtGiaoXuTruoc1.Text = tblChuyenXu.Rows[0][ChuyenXuConst.NoiChuyen].ToString();
                }
            }
            string phai = (sender as DataRow)[GiaoDanConst.Phai].ToString();
            if (string.Compare(phai, GxConstants.NU, true) == 0)
            {
                txtNguoi2.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            }
            else
            {
                txtNguoi2.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NU.ToLower());
            }
            //set doi rao name
            if (Operation == GxOperation.ADD)
            {
                string tenNguoi1 = Memory.GetName(txtNguoi1.Text);
                string tenNguoi2 = Memory.GetName(txtNguoi2.Text);
                txtDoiRao.Text = string.Concat(tenNguoi1, " - ", tenNguoi2);
            }
        }

        private void assignNguoi2(DataRow row)
        {
            txtNguoi2.CurrentRow = row;
        }

        private void txtNguoi2_OnSelected(object sender, EventArgs e)
        {
            if (sender == null) return;

            DataRow row = (DataRow)sender;
            txtGiaoXu2.Text = Memory.GetThuocXu(row);
            if ((int)row[GiaoDanConst.MaGiaoHo] > 0 && Memory.GiaoXuInfo != null) //Neu thuoc trong xu
            {
                txtGiaoPhan2.Text = Memory.GiaoXuInfo[GiaoPhanConst.TenGiaoPhan].ToString();
            }
            //Lay thong tin giao xu truoc
            DataTable tblChuyenXu = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID + " AND ChuyenXu.LoaiChuyen =?",
                new object[] { row[GiaoDanConst.MaGiaoDan], (int)LoaiChuyenXu.ChuyenDen });
            if (!Memory.ShowError())
            {
                if (tblChuyenXu != null && tblChuyenXu.Rows.Count > 0)
                {
                    txtGiaoXuTruoc2.Text = tblChuyenXu.Rows[0][ChuyenXuConst.NoiChuyen].ToString();
                }
            }
            //set where sql
            string phai = (sender as DataRow)[GiaoDanConst.Phai].ToString();
            if (string.Compare(phai, GxConstants.NU, true) == 0)
            {
                txtNguoi1.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            }
            else
            {
                txtNguoi1.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NU.ToLower());
            }
            //set doi rao name
            if (Operation == GxOperation.ADD)
            {
                string tenNguoi1 = Memory.GetName(txtNguoi1.Text);
                string tenNguoi2 = Memory.GetName(txtNguoi2.Text);
                txtDoiRao.Text = string.Concat(tenNguoi1, " - ", tenNguoi2);
            }
        }

        private void txtNguoi2_OnSelecting(object sender, CancelEventArgs e)
        {
            OnGiaoDanSelecting(sender, e, txtNguoi1);
        }

        private void txtNguoi1_OnSelecting(object sender, CancelEventArgs e)
        {
            OnGiaoDanSelecting(sender, e, txtNguoi2);
        }

        private void OnGiaoDanSelecting(object sender, CancelEventArgs e, GxGiaoDan nguoikia)
        {
            if (sender != null && sender is DataRow)
            {
                DataRow row = (sender as DataRow);
                if ((bool)row[GiaoDanConst.DaCoGiaDinh])
                {
                    if (MessageBox.Show("Giáo dân này đã từng lập gia đình.\r\nBạn có chắc muốn rao  hôn phối cho giáo dân này không?",
                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (nguoikia.CurrentRow != null)
                {
                    string phai1 = row[GiaoDanConst.Phai].ToString();
                    string phai2 = nguoikia.CurrentRow[GiaoDanConst.Phai].ToString();
                    if (string.Compare(phai1, phai2, true) == 0)
                    {
                        MessageBox.Show("Hãy chọn người khác phái!",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                //kiem tra da tung lap to rao chua
                DataTable tmp = Memory.GetData(SqlConstants.CHECK_DA_RAOHONPHOI,
                                        new object[] { row[GiaoDanConst.MaGiaoDan], row[GiaoDanConst.MaGiaoDan] });
                if (!Memory.ShowError())
                {
                    if (tmp != null && tmp.Rows.Count > 0)
                    {
                        if (MessageBox.Show("Giáo dân được chọn đã từng được lập tờ rao hôn phối.\r\nBạn có chắc chọn tiếp giáo dân này không?",
                                         "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                else
                {
                    //if has error
                    return;
                }
                //kiem tra du tuoi
                int tuoi = GxConstants.TUOI_HON_PHOI_NAM;
                if (row[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NU.ToLower())
                {
                    tuoi = GxConstants.TUOI_HON_PHOI_NU;
                }
                if (Memory.KiemTraTuoiKhongHopLe(row[GiaoDanConst.NgaySinh], DateTime.Now.ToString("dd/MM/yyyy"), tuoi))
                {
                    if (MessageBox.Show(string.Format("Giáo dân được chọn chưa đến tuổi được phép kết hôn (vì nhỏ hơn {0} tuồi).\r\nBạn có chắc chọn giáo dân này không?", tuoi),
                                         "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void NgayRaoLan1_DateInput_OnOK(object sender, EventArgs e)
        {
            try
            {
                DateTime d = Memory.GetDateFromString(dtNgayRao1.Value.ToString());
                if (Memory.IsNullOrEmpty(dtNgayRao2.Value))
                {
                    dtNgayRao2.Value = d.AddDays(7);
                }
                if (Memory.IsNullOrEmpty(dtNgayRao3.Value))
                {
                    dtNgayRao3.Value = d.AddDays(14);
                }
            }
            catch
            { }
            
        }

    }
}