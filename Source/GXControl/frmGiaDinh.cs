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

namespace GxControl
{
    public partial class frmGiaDinh : frmBase
    {
        DataTable tblChaMe = null;
        bool isShowChuyenXuMsg = true;
        bool isLoaded = false;
        bool choNhapMaRieng = false;
        bool daChonChuHo = false;
        bool giaDinhAoChange = false;
        public frmGiaDinh()
        {
            InitializeComponent();
            this.HelpKey = "gia_dinh";
            lblGhiChu.Text = "* Ghi chú: Những thành viên bị gạch ngang là những người đã qua đời, đã chuyển xứ hoặc đã lập gia đình riêng";
            gxCommand1.OKButton.Text = "&Cập nhật";
            gxCommand1.Button1.Text = "&In sổ gia đình";
            gxCommand1.Button1.Visible = true;
            gxCommand1.Button1.Click += new EventHandler(Button1_Click);
            gxCommand1.Button2.Visible = false;

            this.AcceptButton = gxCommand1.OKButton;
            
            dtNgayChuyen.IsNullDate = true;
            txtNguoiChong.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            txtNguoiVo.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NU.ToLower());
            gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);
            cbGiaoHo.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);

            txtNguoiChong.EditControl.ReloadButton.Visible = false;
            txtNguoiVo.EditControl.ReloadButton.Visible = false;

            gxCommand1.Button2.Text = "In &lý lịch cá nhân";
            gxCommand1.Button2.Visible = true;
            gxCommand1.Button2.Click += InLyLich_Click;
            gxCommand1.Button2.Image = gxCommand1.Button1.Image;
            //For linh muc control 
            Memory.Instance.SetMemory(GxConstants.LOAD_LINHMUC, null);
            
        }

        private void InLyLich_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Dictionary<int, int> danhSachIn = new Dictionary<int, int>();
                if (txtNguoiChong.MaGiaoDan != 0)
                {
                    danhSachIn.Add(txtNguoiChong.MaGiaoDan, GxConstants.VAITRO_CHONG);
                }
                if (txtNguoiVo.MaGiaoDan != 0)
                {
                    danhSachIn.Add(txtNguoiVo.MaGiaoDan, GxConstants.VAITRO_VO);
                }
                foreach (GridEXRow exRow in gxGiaoDanList1.GetRows())
                {
                    if ((exRow.DataRow as DataRowView) != null && (exRow.DataRow as DataRowView).Row != null)
                    {
                        danhSachIn.Add((int)(exRow.DataRow as DataRowView).Row[GiaoDanConst.MaGiaoDan], (int)(exRow.DataRow as DataRowView).Row[ThanhVienGiaDinhConst.VaiTro]);
                    }
                }
                if (danhSachIn.Count > 0)
                {
                    //foreach (var item in danhSachIn)
                    //{
                    //    GxGiaoDanList.XuatLyLichCaNhan(item);
                    //}
                    GxGiaoDanList.XuatLyLichCaNhan(danhSachIn);
                    MessageBox.Show(string.Format("Xuất lý lịch cá nhân các thành viên trong gia đình thành công!\r\nTổng cộng {0} thành viên.", danhSachIn.Count), "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("hông có thành viên nào trong gia đình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                Memory.ShowError(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (updateGiaDinh())
            {
                GxGiaDinhList.InSoGiaDinh(Id);
            }
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGiaoHo.SelectedValue != null && !giaDinhAoChange)
            {
                chkGiaDinhAo.Checked = cbGiaoHo.MaGiaoHo == 0;
            }
        }

        private void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            //if (sender != null)
            //{
            //    for (int i = 0; i < gxGiaoDanList1.RowCount; i++)
            //    {
            //        if ((this.gxGiaoDanList1.GetRow(i)) != null && this.gxGiaoDanList1.GetRow(i).DataRow != null)
            //        {
            //            DataRow row = (this.gxGiaoDanList1.GetRow(i).DataRow as DataRowView).Row;
            //            if(Memory.IsRedGiaoDan(row))
            //            {
            //                this.gxGiaoDanList1.GetRow(i).RowStyle = new GridEXFormatStyle();
            //                this.gxGiaoDanList1.GetRow(i).RowStyle.ForeColor = Color.Red;
            //                this.gxGiaoDanList1.GetRow(i).RowStyle.FontStrikeout = TriState.True;
            //            }
            //        }
            //    }
            //}
        }

        public int MaGiaoHo
        {
            get { return cbGiaoHo.MaGiaoHo; }
            set
            {
                if (value > -1)
                {
                    cbGiaoHo.MaGiaoHo = value;
                    txtNguoiChong.MaGiaoHo = value;
                    txtNguoiVo.MaGiaoHo = value;
                }
            }
        }

        private void frmGiaDinh_Load(object sender, EventArgs e)
        {
            choNhapMaRieng = (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIADINH) == GxConstants.CF_TRUE);

            //handle events
            this.txtNguoiChong.OnSelected += new System.EventHandler(this.txtNguoiChong_OnSelected);
            this.txtNguoiVo.OnSelected += new System.EventHandler(this.txtNguoiVo_OnSelected);

            #region format grid start
            gxGiaoDanList1.FormatGrid();
            gxGiaoDanList1.AllowEdit = InheritableBoolean.True;
            //gxGiaoDanList1.AllowAddNew = InheritableBoolean.True;
            
            foreach (GridEXColumn col in gxGiaoDanList1.RootTable.Columns)
            {
                col.EditType = EditType.NoEdit;
            }

            GridEXColumn colQuanHe = new GridEXColumn();
            colQuanHe.HasValueList = true;
            colQuanHe.Width = 80;
            colQuanHe.EditType = EditType.DropDownList;
            colQuanHe.FilterEditType = FilterEditType.Combo;
            colQuanHe.BoundMode = ColumnBoundMode.Bound;
            colQuanHe.DataMember = ThanhVienGiaDinhConst.VaiTro;
            colQuanHe.Key = ThanhVienGiaDinhConst.VaiTro;
            colQuanHe.Caption = "Quan hệ GĐ";
            GridEXValueListItemCollection vl = colQuanHe.ValueList;
            GxGiaDinhList.LoadQuanHeGDText(vl);
            gxGiaoDanList1.RootTable.Columns.Insert(0, colQuanHe);

            gxGiaoDanList1.RootTable.Columns[GiaoDanConst.DienThoai].Visible = false;

            //format condition
            GridEXFormatCondition con1 = new GridEXFormatCondition(gxGiaoDanList1.RootTable.Columns[GiaoDanConst.QuaDoi], ConditionOperator.Equal, -1);
            con1.FormatStyle = new GridEXFormatStyle();
            con1.FormatStyle.ForeColor = Color.Red;
            con1.FormatStyle.FontStrikeout = TriState.True;

            GridEXFormatCondition con2 = new GridEXFormatCondition(gxGiaoDanList1.RootTable.Columns[GiaoDanConst.DaCoGiaDinh], ConditionOperator.Equal, -1);
            con2.FormatStyle = new GridEXFormatStyle();
            con2.FormatStyle.ForeColor = Color.Red;
            con2.FormatStyle.FontStrikeout = TriState.True;

            GridEXFormatCondition con3 = new GridEXFormatCondition(gxGiaoDanList1.RootTable.Columns[GiaoDanConst.DaChuyenXu], ConditionOperator.Equal, -1);
            con3.FormatStyle = new GridEXFormatStyle();
            con3.FormatStyle.ForeColor = Color.Red;
            con3.FormatStyle.FontStrikeout = TriState.True;

            gxGiaoDanList1.RootTable.FormatConditions.Add(con1);
            gxGiaoDanList1.RootTable.FormatConditions.Add(con2);
            gxGiaoDanList1.RootTable.FormatConditions.Add(con3);

            #endregion format grid end
            
            if (this.operation == GxOperation.ADD)
            {
                id = Memory.Instance.GetNextId(GiaDinhConst.TableName, GiaDinhConst.MaGiaDinh, true);
                gxCommand1.Button2.Visible = false;
            }
            else
            {
                gxCommand1.Button2.Visible = true;
                if (this.Operation == GxOperation.VIEW)
                {
                    gxCommand1.OKButton.Visible = false;
                    gxCommand1.Button2.Visible = false;
                    gxGiaoDanList1.AllowEditGiaoDan = false;
                }
            }

            string sql = string.Format(SqlConstants.SELECT_THANHVIEN_GIADINH, SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO);
            gxGiaoDanList1.LoadData(sql + " AND ThanhVienGiaDinh.MaGiaDinh = ? AND ThanhVienGiaDinh.VaiTro <> 0 AND ThanhVienGiaDinh.VaiTro <> 1 ORDER BY ThanhVienGiaDinh.VaiTro, GiaoDan.NamSinh", new object[] { id });
            tblChaMe = Memory.GetData(sql + " AND ThanhVienGiaDinh.MaGiaDinh = ? AND ThanhVienGiaDinh.VaiTro <= 1", new object[] { id });
            if (!Memory.ShowError())
            {
                tblChaMe.TableName = ThanhVienGiaDinhConst.TableName;
            }
            txtMaGiaDinh.Text = id.ToString();

            if (choNhapMaRieng)
            {
                txtMaGiaDinh.Visible = false;
                txtMaGiaDinhRieng.Location = txtMaGiaDinh.Location;
                txtMaGiaDinhRieng.Visible = true;
            }
            else
            {
                txtMaGiaDinh.Visible = true;
                txtMaGiaDinhRieng.Visible = false;
            }

            isLoaded = true;
        }

        private DataRow chonNguoiConLai(int maGiaoDan)
        {
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_CHECK_VOCHONG + " ORDER BY HP1.SoThuTu DESC", new object[] { maGiaoDan });
            if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0)
            {
                return tbl.Rows[0];
            }
            return null;
        }

        private void ganNguoiConLai(int maGiaoDan, GxGiaoDan nguoiConLai)
        {
            DataRow row = chonNguoiConLai(maGiaoDan);
            if (row != null)
            {
                //Neu nguoi con lai tim duoc chua qua doi, ma khac nguoi da duoc chon thi thong bao
                if (nguoiConLai.MaGiaoDan > 0 && (bool)row[GiaoDanConst.QuaDoi] == false && (int)row[GiaoDanConst.MaGiaoDan] != nguoiConLai.MaGiaoDan)
                {
                    string tenNguoiConLai = (row[GiaoDanConst.TenThanh].ToString() + row[GiaoDanConst.HoTen].ToString()).Trim();
                    if (MessageBox.Show("Người được chọn đã kết hôn với [" + tenNguoiConLai + "] (hiện còn sống)\r\n" +
                                        "Bạn có muốn chương trình tự động chọn [" + tenNguoiConLai + "] là người còn lại không?\r\n", 
                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                nguoiConLai.SetMaGiaoDan((int)row[GiaoDanConst.MaGiaoDan]);
                string ten = row[GiaoDanConst.TenThanh].ToString() + " " + row[GiaoDanConst.HoTen].ToString();
                nguoiConLai.Text = ten.Trim();
            }
            
        }

        private void txtNguoiChong_OnSelected(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            ganNguoiConLai(txtNguoiChong.MaGiaoDan, txtNguoiVo);

            string tenChong = Memory.GetName(txtNguoiChong.Text).Trim();
            string tenVo = Memory.GetName(txtNguoiVo.Text).Trim();
            txtTenGiaDinh.Text = tenChong + (tenChong == "" || tenVo == "" ? "" : " - ") + tenVo;
            loadHonPhoi();
        }

        private void txtNguoiVo_OnSelected(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            ganNguoiConLai(txtNguoiVo.MaGiaoDan, txtNguoiChong);

            string tenChong = Memory.GetName(txtNguoiChong.Text).Trim();
            string tenVo = Memory.GetName(txtNguoiVo.Text).Trim();
            txtTenGiaDinh.Text = tenChong + (tenChong == "" || tenVo == "" ? "" : " - ") + tenVo;
            loadHonPhoi();
        }

        private void txtNguoiVo_OnSelecting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoaded) return;
            DataRow row = (DataRow)sender;
            if (row[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NAM.ToLower())
            {
                MessageBox.Show("Người vợ không thể là nam!");
                e.Cancel = true;
                return;
            }
            //kiem tra tuoi hop le
            int tuoi = GxConstants.TUOI_HON_PHOI_NAM;
            if ((sender as DataRow)[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NU.ToLower())
            {
                tuoi = GxConstants.TUOI_HON_PHOI_NU;
            }
            if (Memory.KiemTraTuoiKhongHopLe((sender as DataRow)[GiaoDanConst.NgaySinh], DateTime.Now.ToString("dd/MM/yyyy"), tuoi))
            {
                if (MessageBox.Show(string.Format("Giáo dân được chọn chưa đến tuổi được phép kết hôn (vì nhỏ hơn {0} tuồi.\r\nB ạn có chắc chọn giáo dân này không?", tuoi),
                                     "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            //kiem tra vo chong
            if (((int)row[GiaoDanConst.MaGiaoDan] != txtNguoiVo.MaGiaoDan) &&  Memory.KiemTraVoChong((int)row[GiaoDanConst.MaGiaoDan]) == 0)
            {
                e.Cancel = true;
                return;
            }
            //if ((bool)row[GiaoDanConst.QuaDoi] || (Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) &&
            //                           int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
            //{
            //    txtNguoiVo.TextBox.ForeColor = Color.Red;
            //    txtNguoiVo.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Strikeout);
            //}
            //else
            //{
            //    txtNguoiVo.TextBox.ForeColor = Color.Black;
            //    txtNguoiVo.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Regular);
            //}
        }

        private void txtNguoiChong_OnSelecting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoaded) return;
            DataRow row = (DataRow)sender;
            if (row[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NU.ToLower())
            {
                MessageBox.Show("Người chồng không thể là nữ!");
                e.Cancel = true;
                return;
            }
            //kiem tra tuoi hop le
            int tuoi = GxConstants.TUOI_HON_PHOI_NAM;
            if ((sender as DataRow)[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NU.ToLower())
            {
                tuoi = GxConstants.TUOI_HON_PHOI_NU;
            }
            if (Memory.KiemTraTuoiKhongHopLe((sender as DataRow)[GiaoDanConst.NgaySinh], DateTime.Now.ToString("dd/MM/yyyy"), tuoi))
            {
                if (MessageBox.Show(string.Format("Giáo dân được chọn chưa đến tuổi được phép kết hôn (vì nhỏ hơn {0} tuồi.\r\nB ạn có chắc chọn giáo dân này không?", tuoi),
                                     "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (((int)row[GiaoDanConst.MaGiaoDan] != txtNguoiChong.MaGiaoDan) && Memory.KiemTraVoChong((int)row[GiaoDanConst.MaGiaoDan]) == 0)
            {
                e.Cancel = true;
                return;
            }
            //if ((bool)row[GiaoDanConst.QuaDoi] || (Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) &&
            //                            int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
            //{
            //    txtNguoiChong.TextBox.ForeColor = Color.Red;
            //    txtNguoiChong.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Strikeout);
            //}
            //else
            //{
            //    txtNguoiChong.TextBox.ForeColor = Color.Black;
            //    txtNguoiChong.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Regular);
            //}
        }

        private void loadHonPhoi()
        {
            if (txtNguoiChong.MaGiaoDan > 0 && txtNguoiVo.MaGiaoDan > -1)
            {
                string tenNam = Memory.GetName(txtNguoiChong.Text);
                string tenNu = Memory.GetName(txtNguoiVo.Text);
                gxXemHonPhoi1.TenHonPhoi = string.Format("{0} - {1}", tenNam, tenNu);
                gxXemHonPhoi1.GetHonPhoi(txtNguoiVo.MaGiaoDan, txtNguoiChong.MaGiaoDan);
            }
        }

        private void gxGiaoDanList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            EditConCaiRow();
        }

        private void EditConCaiRow()
        {
            if (gxGiaoDanList1.CurrentRow == null || (gxGiaoDanList1.CurrentRow.DataRow as DataRowView) == null) return;
            DataRow row = (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row;
            int maGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO + " AND MaGiaoDan=" + maGiaoDan.ToString());
            if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0)
            {
                if (Memory.IsRedGiaoDan(tbl.Rows[0]))
                {
                    gxGiaoDanList1.CurrentRow.RowStyle = new GridEXFormatStyle();
                    gxGiaoDanList1.CurrentRow.RowStyle.FontStrikeout = TriState.True;
                    gxGiaoDanList1.CurrentRow.RowStyle.ForeColor = Color.Red;
                }
                else
                {
                    gxGiaoDanList1.CurrentRow.RowStyle = new GridEXFormatStyle();
                    gxGiaoDanList1.CurrentRow.RowStyle.FontStrikeout = TriState.False;
                    gxGiaoDanList1.CurrentRow.RowStyle.ForeColor = Color.Black;
                }
            }
            if (Memory.Instance.GetMemory(ThanhVienGiaDinhConst.VaiTro) != null)
            {
                gxGiaoDanList1.CurrentRow.Cells[0].Value = Memory.Instance.GetMemory(ThanhVienGiaDinhConst.VaiTro);
                Memory.Instance.SetMemory(ThanhVienGiaDinhConst.VaiTro, null);
            }
        }

        private void gxAddEdit1_SelectClick(object sender, EventArgs e)
        {
            //frmChonDuLieu frm = new frmChonDuLieu();
            //bool rs = addGiaoDan(frm, false);
            //if (rs)
            //{
            //    gxGiaoDanList1.Row = gxGiaoDanList1.RowCount - 1;
            //    EditConCaiRow();
            //}

            frmChonGiaoDan frm = new frmChonGiaoDan();
            bool rs = addGiaoDan(frm, false);
            if (rs)
            {
                gxGiaoDanList1.Row = gxGiaoDanList1.RowCount - 1;
                EditConCaiRow();
            }
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            frmGiaoDan frm = new frmGiaoDan();
            bool rs = addGiaoDan(frm, true);
            if (rs)
            {
                gxGiaoDanList1.Row = gxGiaoDanList1.RowCount - 1;
                EditConCaiRow();
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            gxGiaoDanList1.EditRow();
            EditConCaiRow();
        }

        private bool addGiaoDan(frmBase frm, bool isAdd)
        {
            cont:
            if (frm is frmGiaoDan)
            {
                ((frmGiaoDan)frm).MaGiaoHo = MaGiaoHo;
                ((frmGiaoDan)frm).FromGiaDinhForm = true;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    frm.DataReturn.Table.Columns.Add(ThanhVienGiaDinhConst.ChuHo, typeof(bool));
                    DataTable tbl = (DataTable)gxGiaoDanList1.DataSource;
                    if (tbl != null)
                    {
                        int maGiaoDan = (int)frm.DataReturn[GiaoDanConst.MaGiaoDan];
                        if (maGiaoDan == txtNguoiChong.MaGiaoDan || maGiaoDan == txtNguoiVo.MaGiaoDan)
                        {
                            MessageBox.Show("Giáo dân này đã có trong gia đình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        //check ton tai trong danh sach
                        DataRow[] rows = tbl.Select("MaGiaoDan=" + maGiaoDan.ToString());
                        if (rows != null && rows.Length > 0)
                        {
                            MessageBox.Show("Giáo dân này đã tồn tại trong danh sách thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        //check da thuoc gia dinh nao chua
                        DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_THANHVIEN_GIADINH_LIST + " AND GiaDinh.DaXoa=0 AND GiaDinh.DaChuyenXu=0 AND MaGiaoDan = ? AND VaiTro>1", new object[] { maGiaoDan });
                        if (Memory.ShowError()) return false;
                        if (tblCheck != null && tblCheck.Rows.Count > 0)
                        {
                            string tenGiaDinh = tblCheck.Rows[0][GiaDinhConst.TenGiaDinh].ToString();
                            MessageBox.Show("Giáo dân này đã thuộc về gia đình [" + tenGiaDinh + "].\r\nBạn có thể sử dụng chức năng [tìm gia đình của giáo dân] để biết giáo dân này đã thuộc về những gia đình nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;                            
                        }

                        frm.DataReturn.Table.Columns.Add(GiaDinhConst.MaGiaDinh, typeof(int));
                        frm.DataReturn.Table.Columns.Add(ThanhVienGiaDinhConst.VaiTro, typeof(int));
                        frm.DataReturn[ThanhVienGiaDinhConst.VaiTro] = 2;
                        frm.DataReturn.AcceptChanges();
                        frm.DataReturn.SetAdded();
                        tbl.ImportRow(frm.DataReturn);

                        gxGiaoDanList1.Row = gxGiaoDanList1.RowCount - 1;
                        if (Memory.IsRedGiaoDan(frm.DataReturn))
                        {
                            gxGiaoDanList1.CurrentRow.RowStyle = new GridEXFormatStyle();
                            gxGiaoDanList1.CurrentRow.RowStyle.FontStrikeout = TriState.True;
                            gxGiaoDanList1.CurrentRow.RowStyle.ForeColor = Color.Red;
                        }

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
            if (gxGiaoDanList1.CurrentRow != null && gxGiaoDanList1.CurrentRow.DataRow != null 
                && (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row.RowState != DataRowState.Deleted)
            {
                
                gxGiaoDanList1.CurrentRow.Delete();
                gxGiaoDanList1.Refetch();
                gxGiaoDanList1.Refresh();
            }
        }

        private bool checkInput()
        {
            if (!Validator.IsNumber(txtMaGiaDinh.Text))
            {
                MessageBox.Show("Mã gia đình phải được nhập số");
                txtMaGiaDinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNguoiChong.Text.Trim()) && string.IsNullOrEmpty(txtNguoiVo.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập ít nhất người nam hoặc người nữ!");
                txtNguoiChong.Focus();
                return false;
            }

            if (operation == GxOperation.ADD && txtNguoiChong.MaGiaoDan > 0 && txtNguoiVo.MaGiaoDan > 0)
            {
                DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_CHECK_GIADINH_THEO_VOCHONG, txtNguoiChong.MaGiaoDan, txtNguoiVo.MaGiaoDan);
                if (Memory.ShowError() || (tblCheck != null && tblCheck.Rows.Count > 0))
                {
                    MessageBox.Show("Người nam và người nữ này đã từng được lập thành một gia đình.\r\n(Mã gia đình: " + tblCheck.Rows[0][ThanhVienGiaDinhConst.MaGiaDinh].ToString() + ")" +
                    "\r\nKhông thể lập thêm 1 gia đình cho cùng 2 người này!");
                    txtNguoiChong.Focus();
                    return false;
                }
            }

            if (choNhapMaRieng && string.IsNullOrEmpty(txtMaGiaDinhRieng.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập mã gia đình!");
                txtMaGiaDinhRieng.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenGiaDinh.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập tên gia đình!");
                txtTenGiaDinh.Focus();
                return false;
            }

            if (cbGiaoHo.Combo.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn một giáo họ!");
                cbGiaoHo.Focus();
                return false;
            }

            if (currentRow != null && cbGiaoHo.SelectedValue != null && currentRow[GiaoDanConst.MaGiaoHo].ToString() != cbGiaoHo.SelectedValue.ToString())
            {
                if (MessageBox.Show("Nếu chọn chuyển họ cho gia đình này thì tất cả các thành viên trong gia đình cũng sẽ bị chuyển theo" + 
                    "\r\nBạn có chắc chuyển họ cho gia đình này không?" +
                    "\r\nChọn [Yes]: Đóng màn hình và lưu thông tin được nhập" + 
                    "\r\nChọn [No]: không đóng màn hình và nhập lại thông tin" 
                    , "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    //cbGiaoHo.SelectedValue = (int)currentRow[GiaoDanConst.MaGiaoHo];
                    return false;
                }
            }

            if ((int)cbGiaoHo.Combo.SelectedValue <= 0 && !chkGiaDinhAo.Checked)
            {
                if (MessageBox.Show("Thường thì chỉ có gia đình không được thống kê mới chọn giáo họ là [Ngoài xứ]\r\nBạn có chắc chọn giáo họ [" + cbGiaoHo.Text + "] cho gia đình không?" + Environment.NewLine +
                    "Chọn [Yes] đóng màn hình và lưu thông tin đã nhập\r\nChọn [No] không đóng màn hình và nhập lại thông tin", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cbGiaoHo.Focus();
                    return false;
                }
            }

            if ((int)cbGiaoHo.Combo.SelectedValue > 0 && chkGiaDinhAo.Checked)
            {
                if (MessageBox.Show("Thường thì gia đình không được thống kê sẽ được chọn giáo họ là [Ngoài xứ]\r\nBạn có chắc chọn giáo họ [" + cbGiaoHo.Text + "] cho gia đình không được thống kê này không?" + Environment.NewLine +
                    "Chọn [Yes] đóng màn hình và lưu thông tin đã nhập\r\nChọn [No] không đóng màn hình và nhập lại thông tin", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cbGiaoHo.Focus();
                    return false;
                }
            }

            //check ma gia dinh
            if (!choNhapMaRieng)
            {
                if (operation == GxOperation.ADD && Memory.IsExistedData(SqlConstants.SELECT_GIADINH_THEO_ID, new object[] { txtMaGiaDinh.Text }))
                {
                    txtMaGiaDinh.Text = Memory.Instance.GetNextId(GiaDinhConst.TableName, GiaDinhConst.MaGiaDinh, true).ToString();
                }
            }
            else
            {
                if (Memory.IsExistedData("SELECT * FROM GiaDinh WHERE MaGiaDinhRieng=? AND MaGiaDinh<>?", new object[] { txtMaGiaDinhRieng.Text, txtMaGiaDinh.Text }))
                {
                    MessageBox.Show("Mã gia đình này đã tồn tại. Hãy nhập mã khác!");
                    txtMaGiaDinhRieng.Focus();
                    return false;
                }
            }

            //check chu ho
            DialogResult rs = DialogResult.OK;
            #region Check chu ho
            if (txtNguoiChong.CurrentRow != null && txtNguoiVo.CurrentRow == null)
            {
                rdChuHoNam.Checked = true;
            }
            else if (txtNguoiChong.CurrentRow == null && txtNguoiVo.CurrentRow != null)
            {
                rdChuHoNu.Checked = true;
            }
            else
            {
                if (!daChonChuHo)
                {
                    if ((bool)txtNguoiChong.CurrentRow[GiaoDanConst.QuaDoi] == true
                        && (bool)txtNguoiVo.CurrentRow[GiaoDanConst.QuaDoi] != true) // neu nguoi nam qua doi ma nguoi nu chua qua doi
                    {
                        rs = MessageBox.Show("Vì người nam đã qua đời và người nữ còn sống, chương trình sẽ tự chọn chủ hộ là người nữ.\r\nChọn [Yes] để lưu chủ hộ là người nữ\r\n\r\nChọn [No] để lưu chủ hộ như đang chọn.\r\nChọn [Cancel] để giữ lại màn hình này và xem lại",
                             "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                        {
                            rdChuHoNu.Checked = true;
                        }
                        else if (rs == DialogResult.Cancel)
                        {
                            return false;
                        }
                    }
                    else if (rdChuHoNu.Checked && (bool)txtNguoiVo.CurrentRow[GiaoDanConst.QuaDoi] == true
                        && (bool)txtNguoiChong.CurrentRow[GiaoDanConst.QuaDoi] == false) // truong hop nguoi nu la chu ho nhung da qua doi nhung nguoi nam chua qua doi
                    {
                        rs = MessageBox.Show("Vì người nữ là chủ hộ nhưng đã qua đời, chương trình sẽ tự chọn chủ hộ là người nam.\r\nChọn [Yes] để lưu chủ hộ là người nam\r\nChọn [No] để lưu chủ hộ như đang chọn.\r\nChọn [Cancel] để giữ lại màn hình này và xem lại",
                             "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                        {
                            rdChuHoNam.Checked = true;
                        }
                        else if (rs == DialogResult.Cancel)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if ((bool)txtNguoiChong.CurrentRow[GiaoDanConst.QuaDoi] == true
                                && (bool)txtNguoiVo.CurrentRow[GiaoDanConst.QuaDoi] == true) // neu ca 2 nguoi cung qua doi
                        {
                            if (!rdChuHoNam.Checked)
                            {
                                rs = MessageBox.Show("Vì cả người nam và người nữ đã qua đời, chương trình sẽ tự chọn chủ hộ là người nam.\r\nChọn [Yes] để lưu chủ hộ là người nam\r\nChọn [No] để lưu chủ hộ như đang chọn.\r\nChọn [Cancel] để giữ lại màn hình này và xem lại",
                                     "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if (rs == DialogResult.Yes)
                                {
                                    rdChuHoNam.Checked = true;
                                }
                                else if (rs == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                        if (!rdChuHoNam.Checked && !rdChuHoNu.Checked)
                        {
                            rs = MessageBox.Show("Bạn chưa chọn chủ hộ, trong trường hợp người nam chưa qua đời hoặc cả người nam và người nữ đều qua đời chương trình sẽ tự chọn chủ hộ là người nam.\r\nChọn [Yes] để lưu chủ hộ là người nam\r\nChọn [No] để lưu chủ hộ như đang chọn.\r\nChọn [Cancel] để giữ lại màn hình này và xem lại",
                                     "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (rs == DialogResult.Yes)
                            {
                                rdChuHoNam.Checked = true;
                            }
                            else if (rs == DialogResult.Cancel)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            #endregion

            return true; ;
        }


        private void AssignDataSource(DataRow row)
        {
            row[GiaDinhConst.MaGiaDinh] = int.Parse(txtMaGiaDinh.Text);
            row[GiaDinhConst.MaGiaDinhRieng] = txtMaGiaDinhRieng.Text;
            row[GiaDinhConst.MaGiaoHo] = cbGiaoHo.SelectedValue;
            row[GiaDinhConst.TenGiaDinh] = txtTenGiaDinh.Text.Trim(new char[] { '-' });
            //row[GiaDinhConst.TenChong] = txtNguoiChong.Text;
            //row[GiaDinhConst.TenVo] = txtNguoiVo.Text;
            row[GiaDinhConst.GhiChu] = txtGhiChu.Text;
            row[GiaDinhConst.DiaChi] = txtDiaChi.Text;
            row[GiaDinhConst.DienThoai] = txtDienThoai.Text;
            row[GiaDinhConst.GiaDinhAo] = chkGiaDinhAo.Checked;
            row[GiaDinhConst.DaChuyenXu] = chkChuyenXu.Checked;
            if (chkChuyenXu.Checked)
            {
                row[GiaDinhConst.NgayChuyen] = dtNgayChuyen.Value;
                row[GiaDinhConst.NoiChuyen] = txtNoiChuyen.Text;
            }
            else
            {
                row[GiaDinhConst.NgayChuyen] = null;
                row[GiaDinhConst.NoiChuyen] = "";
            }
            if (chkDelete.Visible)
            {
                row[GiaDinhConst.DaXoa] = chkDelete.Checked;
            }
            if (Memory.IsNullOrEmpty(row[GiaDinhConst.MaNhanDang]))
            {
                row[GiaDinhConst.MaNhanDang] = Memory.GetGiaDinhKey(row[GiaDinhConst.MaGiaDinh]);
            }
            row[GiaDinhConst.UpdateDate] = Memory.Instance.GetServerDateTime();
        }

        public void AssignControlData()
        {
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIADINH_THEO_ID, new object[] { Id });
            string sql = string.Format(SqlConstants.SELECT_CHA_ME_THEO_GIADINH, SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO);
            DataTable tblVoChong = Memory.GetData(sql, new object[] { Id });
            if (tbl != null && tbl.Rows.Count > 0)
            {
                AssignControlData(tbl.Rows[0], tblVoChong);
            }
        }

        public void AssignControlData(DataRow row, DataTable tblVoChong)
        {
            id = (int)row[GiaDinhConst.MaGiaDinh];
            txtMaGiaDinh.Text = id.ToString();
            txtMaGiaDinhRieng.Text = row[GiaDinhConst.MaGiaDinhRieng].ToString();
            txtTenGiaDinh.Text = row[GiaDinhConst.TenGiaDinh].ToString();

            if (tblVoChong != null && tblVoChong.Rows.Count > 0)
            {
                DataRow[] rowChong = tblVoChong.Select("VaiTro = " + GxConstants.VAITRO_CHONG);
                if (rowChong != null && rowChong.Length > 0)
                {
                    txtNguoiChong.MaGiaoDan = (int)rowChong[0][GiaoDanConst.MaGiaoDan];
                    txtNguoiChong.Text = rowChong[0][GiaoDanConst.TenThanh].ToString() + " " + rowChong[0][GiaoDanConst.HoTen].ToString();
                    if ((bool)rowChong[0][GiaoDanConst.QuaDoi] || (Validator.IsNumber(rowChong[0][GiaoDanConst.DaChuyenXu].ToString()) &&
                            int.Parse(rowChong[0][GiaoDanConst.DaChuyenXu].ToString()) == -1))
                    {
                        txtNguoiChong.TextBox.ForeColor = Color.Red;
                        txtNguoiChong.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Strikeout);
                    }
                    if ((bool)rowChong[0][ThanhVienGiaDinhConst.ChuHo])
                    {
                        rdChuHoNam.Checked = true;
                    }
                }

                DataRow[] rowVo = tblVoChong.Select("VaiTro = " + GxConstants.VAITRO_VO);
                if (rowVo != null && rowVo.Length > 0)
                {
                    txtNguoiVo.MaGiaoDan = (int)rowVo[0][GiaoDanConst.MaGiaoDan];
                    txtNguoiVo.Text = rowVo[0][GiaoDanConst.TenThanh].ToString() + " " + rowVo[0][GiaoDanConst.HoTen].ToString();
                    if ((bool)rowVo[0][GiaoDanConst.QuaDoi] || (Validator.IsNumber(rowVo[0][GiaoDanConst.DaChuyenXu].ToString()) &&
                            int.Parse(rowVo[0][GiaoDanConst.DaChuyenXu].ToString()) == -1))
                    {
                        txtNguoiVo.TextBox.ForeColor = Color.Red;
                        txtNguoiVo.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Strikeout);
                    }
                    if ((bool)rowVo[0][ThanhVienGiaDinhConst.ChuHo] && !rdChuHoNam.Checked)
                    {
                        rdChuHoNu.Checked = true;
                    }
                }
            }

            cbGiaoHo.SelectedValue = row[GiaDinhConst.MaGiaoHo];
            txtGhiChu.Text = row[GiaDinhConst.GhiChu].ToString();
            txtDiaChi.Text = row[GiaDinhConst.DiaChi].ToString();
            txtDienThoai.Text = row[GiaDinhConst.DienThoai].ToString();
            chkGiaDinhAo.Checked = (bool)row[GiaDinhConst.GiaDinhAo];
            isShowChuyenXuMsg = false;
            chkChuyenXu.Checked = (bool)row[GiaDinhConst.DaChuyenXu];
            if ((bool)row[GiaDinhConst.DaChuyenXu])
            {
                //chkChuyenXu.Enabled = false;
                dtNgayChuyen.Value = row[GiaDinhConst.NgayChuyen];
                txtNoiChuyen.Text = row[GiaDinhConst.NoiChuyen].ToString();
            }
            if ((bool)row[GiaDinhConst.DaXoa])
            {
                chkDelete.Checked = (bool)row[GiaDinhConst.DaXoa];
                chkDelete.Visible = true;
            }
            currentRow = row;
            loadHonPhoi();
            isShowChuyenXuMsg = true;
            daChonChuHo = false;
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            if (updateGiaDinh())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool updateGiaDinh()
        {
            try
            {
                if (!checkInput()) return false;
                //For master
                //if (this.operation == GxOperation.ADD)
                //    id = Memory.Instance.GetMaxId(GiaDinhConst.TableName, GiaDinhConst.MaGiaDinh, true);
                DataTable tblGiaDinh = Memory.GetData(SqlConstants.SELECT_GIADINH_THEO_ID, new object[] { Id });
                if (Memory.ShowError())
                {
                    return false;
                }
                tblGiaDinh.TableName = GiaDinhConst.TableName;
                bool daChuyenXuTruocDay = false;
                if (operation == GxOperation.ADD)
                {
                    dataReturn = tblGiaDinh.NewRow();
                    AssignDataSource(dataReturn);
                    tblGiaDinh.Rows.Add(dataReturn);
                }
                else
                {
                    if (tblGiaDinh.Rows.Count > 0)
                    {
                        dataReturn = tblGiaDinh.Rows[0];
                        daChuyenXuTruocDay = (bool)dataReturn[GiaDinhConst.DaChuyenXu];
                        if(daChuyenXuTruocDay && !chkChuyenXu.Checked)
                        {
                            if(MessageBox.Show("Tất cả các thành viên trong gia đình này sẽ được chuyển về lại xứ. Bạn có chắc không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                            {
                                return false;
                            }
                        }
                            
                        AssignDataSource(dataReturn);
                    }
                }

                //For childs
                DataSet ds = new DataSet();
                DataTable tblChilds = (DataTable)gxGiaoDanList1.DataSource;
                DataTable tblThongTinConCai = null;
                //Update con cai
                if (tblChilds != null)
                {
                    tblChilds.TableName = ThanhVienGiaDinhConst.TableName;
                    string sqlUpdateChaMe = "SELECT * FROM GiaoDan WHERE 1=2  ";
                    bool hasChild = false;
                    string maGiaoDanSetList = "";
                    foreach (DataRow crow in tblChilds.Rows)
                    {
                        if (crow.RowState != DataRowState.Deleted)
                        {
                            crow[ThanhVienGiaDinhConst.MaGiaDinh] = int.Parse(txtMaGiaDinh.Text); ;
                            if ((int)crow[ThanhVienGiaDinhConst.VaiTro] == GxConstants.VAITRO_CON)
                            {
                                maGiaoDanSetList += " OR MaGiaoDan=" + crow[ThanhVienGiaDinhConst.MaGiaoDan].ToString();
                                hasChild = true;
                            }
                            crow[ThanhVienGiaDinhConst.ChuHo] = false;
                        }
                    }
                    if (hasChild)
                    {
                        System.Collections.ArrayList arr = new System.Collections.ArrayList();
                        sqlUpdateChaMe += maGiaoDanSetList;
                        tblThongTinConCai = Memory.GetData(sqlUpdateChaMe, arr.ToArray());
                        if (Memory.ShowError())
                        {
                            return false;
                        }
                        tblThongTinConCai.TableName = GiaoDanConst.TableName;
                        if (tblThongTinConCai != null)
                        {
                            foreach (DataRow rowConCai in tblThongTinConCai.Rows)
                            {
                                //update thong tin nguoi cha neu chua co thong tin nguoi cha
                                if (txtNguoiChong.MaGiaoDan > 0 && Memory.IsNullOrEmpty(rowConCai[GiaoDanConst.HoTenCha]))
                                {
                                    rowConCai[GiaoDanConst.HoTenCha] = txtNguoiChong.Text;
                                }
                                //update thong tin nguoi me neu chua co thong tin nguoi me
                                if (txtNguoiVo.MaGiaoDan > 0 && Memory.IsNullOrEmpty(rowConCai[GiaoDanConst.HoTenMe]))
                                {
                                    rowConCai[GiaoDanConst.HoTenMe] = txtNguoiVo.Text;
                                }
                            }
                            ds.Tables.Add(tblThongTinConCai);
                        }
                    }
                    ds.Tables.Add(tblChilds);
                }

                ds.Tables.Add(tblGiaDinh);
                //Update UpdateDate field
                foreach (DataRow rowTmp in tblGiaDinh.Rows)
                {
                    rowTmp[GiaoDanConst.UpdateDate] = Memory.Instance.GetServerDateTime();
                }
                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblGiaDinh);
                if(ds.Tables.Contains(tblChilds.TableName)) ds.Tables.Remove(tblChilds);
                if (tblThongTinConCai != null && ds.Tables.Contains(tblThongTinConCai.TableName)) ds.Tables.Remove(tblThongTinConCai);
                if (Memory.ShowError())
                {
                    return false;
                }
                if (chkChuyenXu.Checked)
                {
                    updateChuyenXuGiaoDan(GxConstants.LOAI_CHUYENXU_DI);
                }
                else if(daChuyenXuTruocDay)
                {
                    updateChuyenXuGiaoDan(GxConstants.LOAI_CHUYENXU_DEN);
                }

                bool capNhatHonPhoi = gxXemHonPhoi1.UpdateHonPhoi();
                if (operation == GxOperation.EDIT && !capNhatHonPhoi)
                {
                    return false;
                }

                //Update cha me start
                //Delete old data
                string sqlDeleteChaMe = "DELETE FROM ThanhVienGiaDinh WHERE MaGiaDinh=? AND (VaiTro=0 OR VaiTro=1)";
                Memory.ExecuteSqlCommand(sqlDeleteChaMe, new object[] { txtMaGiaDinh.Text });
                if (Memory.ShowError())
                {
                    return false;
                }
                //Insert new data
                string sqlInsertChaMe = "INSERT INTO ThanhVienGiaDinh VALUES(?, ?, ?, ?)";
                if (txtNguoiChong.MaGiaoDan > -1)
                {
                    Memory.ExecuteSqlCommand(sqlInsertChaMe, new object[] { txtMaGiaDinh.Text, txtNguoiChong.MaGiaoDan, GxConstants.VAITRO_CHONG, rdChuHoNam.Checked, Memory.Instance.GetServerDateTime() });
                    if (Memory.ShowError())
                    {
                        return false;
                    }
                }
                if (txtNguoiVo.MaGiaoDan > -1)
                {
                    Memory.ExecuteSqlCommand(sqlInsertChaMe, new object[] { txtMaGiaDinh.Text, txtNguoiVo.MaGiaoDan, GxConstants.VAITRO_VO, rdChuHoNu.Checked, Memory.Instance.GetServerDateTime() });
                    if (Memory.ShowError())
                    {
                        return false;
                    }
                }
                ////update DaCoGiaDinh field for Cha Me
                //string sqlUpdateDaCoGiaDinh = "UPDATE GiaoDan SET DaCoGiaDinh=? WHERE MaGiaoDan=? OR MaGiaoDan=?";
                //Memory.ExecuteSqlCommand(sqlUpdateDaCoGiaDinh, new object[] { true, txtNguoiChong.MaGiaoDan, txtNguoiVo.MaGiaoDan });
                //if (Memory.ShowError())
                //{
                //    return false;
                //}
                ////Update cha me end

                if (currentRow != null && cbGiaoHo.SelectedValue != null && currentRow[GiaoDanConst.MaGiaoHo].ToString() != cbGiaoHo.SelectedValue.ToString())
                {
                    updateGiaoHo();
                }

                //Update dia chi cho tung thanh vien trong gia dinh
                if (dataReturn[GiaDinhConst.DiaChi].ToString().Trim() != txtDiaChi.Text.Trim() && gxGiaoDanList1.RowCount > 0 &&
                    MessageBox.Show("Bạn có muốn cập nhật địa chỉ gia đình cho tất cả các thành viên trong gia đình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    updateDiaChi(dataReturn);
                }

                if (giaDinhAoChange &&
                    MessageBox.Show("Bạn có muốn cập nhật tất cả các thành viên trong gia đình thành " + (chkGiaDinhAo.Checked ? "không được thống kê" : "được thống kê" ) + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    updateGiaoDanAo();
                }

                return true;
                //for (int i = 0; i < ds.Tables.Count; i++)
                //{
                //    ds.Tables.Remove(ds.Tables[i]);
                //    i--;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmGiaDinh, gxCommand1_OnOK)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool updateDiaChi(DataRow rowGiaDinh)
        {
            try
            {
                DataTable tblGiaoDan = Memory.GetData(@"SELECT GD.* FROM GiaoDan GD INNER JOIN ThanhVienGiaDinh TVGD ON GD.MaGiaoDan = TVGD.MaGiaoDan
                                                    WHERE  MaGiaDinh=" + rowGiaDinh[GiaDinhConst.MaGiaDinh].ToString());
                tblGiaoDan.TableName = GiaoDanConst.TableName;
                if (tblGiaoDan.Rows.Count > 0)
                {
                    foreach (DataRow row in tblGiaoDan.Rows)
                    {
                        row[GiaoDanConst.DiaChi] = txtDiaChi.Text;
                    }
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblGiaoDan);

                    Memory.UpdateDataSet(ds);
                }

                return true;
            }
            catch (Exception ex)
            {
                Memory.ShowError(ex.Message);
                return false;
            }
            
        }

        private bool updateGiaoHo()
        {
            try
            {
                string sql = string.Format("UPDATE GiaoDan SET {0}={1} WHERE 1 ", GiaoDanConst.MaGiaoHo, cbGiaoHo.SelectedValue);
                string where = " AND (";
                if (txtNguoiChong.MaGiaoDan > -1) where += " MaGiaoDan=" + txtNguoiChong.MaGiaoDan.ToString() + " OR ";
                if (txtNguoiVo.MaGiaoDan > -1) where += " MaGiaoDan=" + txtNguoiVo.MaGiaoDan.ToString() + " OR ";
                DataTable tbl = (DataTable)gxGiaoDanList1.DataSource;
                if (tbl != null)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        if (!(bool)row[GiaoDanConst.DaCoGiaDinh] && !(Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) && int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
                        {
                            where += string.Format(" MaGiaoDan={0} OR ", row[GiaoDanConst.MaGiaoDan]);
                        }
                    }
                }
                where += " 1=2)";
                Memory.ExecuteSqlCommand(sql + where);
                if (Memory.ShowError())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmGiaDinh, updateGiaoHo)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool updateGiaoDanAo()
        {
            try
            {
                string sql = string.Format("UPDATE GiaoDan SET {0}={1} WHERE 1 ", GiaoDanConst.GiaoDanAo, chkGiaDinhAo.Checked);
                string where = " AND (";
                if (txtNguoiChong.MaGiaoDan > -1) where += " MaGiaoDan=" + txtNguoiChong.MaGiaoDan.ToString() + " OR ";
                if (txtNguoiVo.MaGiaoDan > -1) where += " MaGiaoDan=" + txtNguoiVo.MaGiaoDan.ToString() + " OR ";
                DataTable tbl = (DataTable)gxGiaoDanList1.DataSource;
                if (tbl != null)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        if (!(bool)row[GiaoDanConst.DaCoGiaDinh] && !(Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) && int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
                        {
                            where += string.Format(" MaGiaoDan={0} OR ", row[GiaoDanConst.MaGiaoDan]);
                        }
                    }
                }
                where += " 1=2)";
                Memory.ExecuteSqlCommand(sql + where);
                if (Memory.ShowError())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmGiaDinh, updateGiaoHo)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool updateChuyenXuGiaoDan(int loaiChuyen)
        {
            List<int> lstGiaoDan = new List<int>();
            if (txtNguoiChong.MaGiaoDan > 0)
            {
                lstGiaoDan.Add(txtNguoiChong.MaGiaoDan);
            }

            if (txtNguoiVo.MaGiaoDan > 0)
            {
                lstGiaoDan.Add(txtNguoiVo.MaGiaoDan);
            }

            DataTable tblConCai = (DataTable)gxGiaoDanList1.DataSource;
            if (tblConCai != null)
            {
                foreach (DataRow row in tblConCai.Rows)
                {
                    lstGiaoDan.Add((int)row[GiaoDanConst.MaGiaoDan]);
                }
            }

            DataTable tblChuyenXu = Memory.GetTableStruct(ChuyenXuConst.TableName);
            if (!Memory.ShowError())
            {
                foreach (int maGiaoDan in lstGiaoDan)
                {
                    DataTable tblGiaoDan = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID, new object[] { maGiaoDan });
                    if (tblGiaoDan != null && tblGiaoDan.Rows.Count > 0)
                    {
                        DataRow rowGiaoDan = frmGiaoDan.GetGiaoDanRowByChuyenXu(tblGiaoDan);
                        DataTable tblTemp = frmGiaoDan.GetChuyenXuInfo(rowGiaoDan, maGiaoDan, loaiChuyen, dtNgayChuyen.Value, txtNoiChuyen.Text, "");
                        if (tblTemp != null && tblTemp.Rows.Count > 0)
                        {
                            tblChuyenXu.ImportRow(tblTemp.Rows[0]);
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            DataSet ds = new DataSet();
            tblChuyenXu.TableName = ChuyenXuConst.TableName;
            ds.Tables.Add(tblChuyenXu);
            Memory.UpdateDataSet(ds);
            if (Memory.HasError())
            {
                MessageBox.Show("Có lỗi không mong muốn xảy ra.\r\nCập nhật chuyển xứ cho các thành viên trong gia đình thất bại\r\nXin vui lòng thử lại lần nữa hoặc liên hệ với tác giả để được khắc phục\r\nThành thật xin lỗi quý vị!\r\n" + Memory.Instance.Error.Message, "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            if (this.Operation == GxOperation.ADD && (txtNguoiChong.MaGiaoDan > 0 || txtNguoiVo.MaGiaoDan > 0 || gxGiaoDanList1.RowCount > 0))
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn lưu gia đình này không?\r\nChọn [Yes] để lưu và đóng màn hình.\r\nChọn [No] để đóng màn hình và không lưu.\r\nChọn [Cancel] để quay trở lại màn hình này và xem lại.",
                    "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    gxCommand1_OnOK(sender, e);
                    return;
                }
                else if(rs == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void chkChuyenXu_CheckedChanged(object sender, EventArgs e)
        {
            if (isShowChuyenXuMsg && chkChuyenXu.Checked)
            {
                if (MessageBox.Show("Nếu chọn chuyển xứ cho gia đình này thì tất cả các thành viên trong gia đình cũng sẽ bị chuyển đi\r\nBạn có chắc chuyển xứ cho gia đình này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    chkChuyenXu.Checked = false;
                    return;
                }
            }
            
            dtNgayChuyen.Visible = chkChuyenXu.Checked;
            txtNoiChuyen.Visible = chkChuyenXu.Checked;
        }

        private void chkGiaDinhAo_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoaded && !giaDinhAoChange && chkGiaDinhAo.Checked)
            {
                cbGiaoHo.SelectedValue = 0;
            }
            if(isLoaded) giaDinhAoChange = true;
        }

        private void rdChuHoNam_CheckedChanged(object sender, EventArgs e)
        {
            daChonChuHo = true;
        }

        private void rdChuHoNu_CheckedChanged(object sender, EventArgs e)
        {
            daChonChuHo = true;
        }

        private void gxGiaoDanList1_CellEdited(object sender, ColumnActionEventArgs e)
        {

        }

        private void gxGiaoDanList1_CellUpdated(object sender, ColumnActionEventArgs e)
        {

        }
    }
}