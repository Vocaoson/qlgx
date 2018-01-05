using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using System.IO;

namespace GxControl
{
    public partial class frmGiaoDan : frmBase
    {
        int maGiaDinhMoi = -1;
        bool isLoaded = false;
        private bool giaoDanDaLuu = false;
        public frmGiaoDan()
        {
            InitializeComponent();
            this.HelpKey = "giao_dan";
            if (Memory.IsDesignMode) return;

            cbPhai.Combo.Items.Add("Nam");
            cbPhai.Combo.Items.Add("Nữ");

            cbVanHoa.Combo.Items.Add("Mẫu giáo");
            cbVanHoa.Combo.Items.Add("Cấp I");
            cbVanHoa.Combo.Items.Add("Cấp II");
            cbVanHoa.Combo.Items.Add("Cấp III");
            cbVanHoa.Combo.Items.Add("Trung học");
            cbVanHoa.Combo.Items.Add("Cao đẳng");
            cbVanHoa.Combo.Items.Add("Đại Học");
            cbVanHoa.Combo.Items.Add("Trên Đại học");

            cbNgheNghiep.Combo.Items.Add("Nông dân");
            cbNgheNghiep.Combo.Items.Add("Công nhân");
            cbNgheNghiep.Combo.Items.Add("Nhân viên");
            cbNgheNghiep.Combo.Items.Add("Buôn bán");
            cbNgheNghiep.Combo.Items.Add("Nội trợ");
            cbNgheNghiep.Combo.Items.Add("Nghề tự do");

            #region Load Item for combox Chuyen xu
            DataTable tblChuyenXu = new DataTable();
            tblChuyenXu.Columns.Add("Value", typeof(int));
            tblChuyenXu.Columns.Add("Text", typeof(string));

            //DataRow row0 = tblChuyenXu.NewRow();
            //row0["Value"] = GxConstants.LOAI_CHUYENXU_NGOAIXU; row0["Text"] = "";
            //tblChuyenXu.Rows.Add(row0);

            DataRow row1 = tblChuyenXu.NewRow();
            row1["Value"] = GxConstants.LOAI_CHUYENXU_TAIXU; row1["Text"] = GxConstants.CHUYENXU_TAIXU;
            tblChuyenXu.Rows.Add(row1);

            DataRow row2 = tblChuyenXu.NewRow();
            row2["Value"] = GxConstants.LOAI_CHUYENXU_DEN; row2["Text"] = GxConstants.CHUYENXU_DEN;
            tblChuyenXu.Rows.Add(row2);

            DataRow row3 = tblChuyenXu.NewRow();
            row3["Value"] = GxConstants.LOAI_CHUYENXU_DI; row3["Text"] = GxConstants.CHUYENXU_DI;
            tblChuyenXu.Rows.Add(row3);

            cbChuyenXu.Combo.DataSource = tblChuyenXu;
            cbChuyenXu.Combo.ValueMember = "Value";
            cbChuyenXu.Combo.DisplayMember = "Text";
            #endregion

            cbPhai.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChuyenXu.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            gxCommand1.OKButton.Text = "&Cập nhật";
            
            txtGhiChu.MultiLine = true;
            this.AcceptButton = gxCommand1.OKButton;
            btnChuyenXu.Visible = false;

            #region For TenCha, TenMe
            txtTenCha.EditControl.DisplayMode = DisplayMode.Mode4;
            txtTenCha.EditControl.AddButton.Visible = false;
            txtTenCha.EditControl.SelectButton.Visible = true;
            txtTenCha.EditControl.SelectButton.Text = "&Chọn";
            txtTenCha.TextBox.ReadOnly = false;

            txtTenMe.EditControl.DisplayMode = DisplayMode.Mode4;
            txtTenMe.EditControl.AddButton.Visible = false;
            txtTenMe.EditControl.SelectButton.Visible = true;
            txtTenMe.EditControl.SelectButton.Text = "&Chọn";
            txtTenMe.TextBox.ReadOnly = false;

            txtTenCha.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            txtTenMe.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NU.ToLower());
            #endregion

            //For linh muc control 
            //Memory.Instance.SetMemory(GxConstants.LOAD_LINHMUC, null);
            cbGiaoHo.Combo.SelectedIndexChanged += new EventHandler(cbGiaoHo_SelectedIndexChanged);
            gxHonPhoi1.HonPhoiChanged += new EventHandler(gxHonPhoi1_HonPhoiChanged);
            gxHonPhoi1.LoadDataFinished += new EventHandler(gxHonPhoi1_LoadDataFinished);
        }

        private bool fromGiaDinhForm = false;

        public bool FromGiaDinhForm
        {
            get { return fromGiaDinhForm; }
            set { fromGiaDinhForm = value; }
        }

        public int MaGiaoHo
        {
            get { return cbGiaoHo.MaGiaoHo; }
            set
            {
                cbGiaoHo.MaGiaoHo = value;
            }
        }

        private DataRow rowGiaDinh = null;

        /// <summary>
        /// Cho biết giáo dân này là con cái gia đình nào
        /// </summary>
        public DataRow RowGiaDinh
        {
            get { return rowGiaDinh; }
            set { rowGiaDinh = value; }
        }
        /// <summary>
        /// Gets or sets Ten giao dan
        /// </summary>
        public string TenGiaoDan
        {
            get { return txtHoTen.Text; }
            set { txtHoTen.Text = value; }
        }

        private void gxHonPhoi1_LoadDataFinished(object sender, EventArgs e)
        {
            if (gxHonPhoi1.TongSoHonPhoi > 0)
            {
                chkDaCoGiaDinh.Checked = true;
                chkDaCoGiaDinh.Enabled = false;
            }
            else
            {
                chkDaCoGiaDinh.Enabled = true;
            }
        }

        private void gxHonPhoi1_HonPhoiChanged(object sender, EventArgs e)
        {
            if (gxHonPhoi1.TongSoHonPhoi > 0)
            {
                chkDaCoGiaDinh.Checked = true;
                chkDaCoGiaDinh.Enabled = false;
            }
            else
            {
                chkDaCoGiaDinh.Enabled = true;
            }
        }

        private void frmGiaoDan_Load(object sender, EventArgs e)
        {
            if (Memory.IsDesignMode) return;
            
            if (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIAODAN) == GxConstants.CF_TRUE && operation == GxOperation.ADD)
            {
                txtMaGiaoDan.EditEnabled = true;
            }
            else
            {
                txtMaGiaoDan.EditEnabled = false;
            }
            if (operation == GxOperation.ADD)
            {
                id = Memory.Instance.GetNextId(GiaoDanConst.TableName, GiaoDanConst.MaGiaoDan, true);
                dtNgayRuaToi.DateInput.IsNullDate = true;
                dtNgayRuocLe.DateInput.IsNullDate = true;
                dtNgaySinh.DateInput.IsNullDate = true;
                dtNgayThemSuc.DateInput.IsNullDate = true;
                dtNgayQuaDoi.DateInput.IsNullDate = true;
            }
            else if (operation == GxOperation.VIEW)
            {
                //cbGiaoHo.Combo.ReadOnly = true;
                //cbChuyenXu.Combo.Enabled = false;
                //cbNgheNghiep.Enabled = false;
                //cbPhai.Enabled = false;
                //cbVanHoa.Enabled = false;
                this.gxCommand1.OKButton.Visible = false;
            }
            else if (operation == GxOperation.EDIT)
            {
                giaoDanDaLuu = true;
                gxHonPhoi1.MaGiaoDan = id;
                gxHonPhoi1.Phai = cbPhai.Text;
                gxHonPhoi1.LoadData();

                gxTanHien1.MaGiaoDan = this.Id;
                gxTanHien1.GiaoDanRow = this.CurrentRow;
                gxTanHien1.AssignControlData();
            }

            txtMaGiaoDan.Text = id.ToString();
            tabCaNhan.BackColor = this.BackColor;
            tabHonPhoi.BackColor = this.BackColor;
            tabOnGoi.BackColor = this.BackColor;

            txtTenCha.TextBox.ReadOnly = false;
            txtTenMe.TextBox.ReadOnly = false;
            
            isLoaded = true;
            txtTenThanh.Combobox.Focus();
            if (!txtTenThanh.Combobox.Focused)
                SendKeys.Send("\t");
            
        }

        private bool checkInput()
        {
            tabControl1.SelectedTab = tabCaNhan;
            if (!Validator.IsNumber(txtMaGiaoDan.Text))
            {
                MessageBox.Show("Mã giáo dân phải được nhập số", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGiaoDan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập Họ tên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbPhai.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập giới tính", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPhai.Focus();
                return false;
            }

            if (!dtNgaySinh.CheckInput(false))
            {
                MessageBox.Show("Hãy nhập ngày sinh hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgaySinh.Focus();
                return false;
            }

            if (cbGiaoHo.Combo.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn một giáo họ!");
                cbGiaoHo.Focus();
                return false;
            }

            if ((int)cbGiaoHo.Combo.SelectedValue <= 0 && !chkGiaoDanAo.Checked)
            {
                if (MessageBox.Show("Thường thì chỉ có giáo dân không được thống kê mới chọn giáo họ là [Ngoài xứ]\r\nBạn có chắc chọn giáo họ [" + cbGiaoHo.Text + "] cho giáo dân không?" + Environment.NewLine +
                    "Chọn [Yes] đóng màn hình và lưu thông tin đã nhập\r\nChọn [No] không đóng màn hình và nhập lại thông tin", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cbGiaoHo.Focus();
                    return false;
                }
            }

            if ((int)cbGiaoHo.Combo.SelectedValue > 0 && chkGiaoDanAo.Checked)
            {
                if (MessageBox.Show("Thường thì giáo dân không được thống kê sẽ được chọn giáo họ là [Ngoài xứ]\r\nBạn có chắc chọn giáo họ [" + cbGiaoHo.Text + "] cho giáo dân không được thống kê này không?" + Environment.NewLine +
                    "Chọn [Yes] đóng màn hình và lưu thông tin đã nhập\r\nChọn [No] không đóng màn hình và nhập lại thông tin", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cbGiaoHo.Focus();
                    return false;
                }
            }

            if (!dtNgayRuaToi.CheckInput(false))
            {
                MessageBox.Show("Hãy nhập ngày rửa tội hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayRuaToi.Focus();
                return false;
            }
            if (!dtNgayRuocLe.CheckInput(false))
            {
                MessageBox.Show("Hãy nhập ngày rước lễ hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayRuocLe.Focus();
                return false;
            }
            if (!dtNgayThemSuc.CheckInput(false))
            {
                MessageBox.Show("Hãy nhập ngày thêm sức hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayThemSuc.Focus();
                return false;
            }

            if (!dtNgayQuaDoi.CheckInput(false))
            {
                MessageBox.Show("Hãy nhập ngày qua đời hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayQuaDoi.Focus();
                return false;
            }

            if (!isValidDateInputRelations(dtNgaySinh.Value, dtNgayRuaToi.Value, dtNgayRuocLe.Value, dtNgayThemSuc.Value, dtNgayChuyen.Value, dtNgayQuaDoi.Value))
            {
                MessageBox.Show("Phải đảm bảo ngày sinh <= ngày rửa tội <= ngày rước lễ lần đầu <= ngày thêm sức.\r\nXin vui lòng xem lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgaySinh.Focus();
                return false;
            }

            if (Memory.KiemTraTuoiKhongHopLe(dtNgaySinh.Value, dtNgayRuocLe.Value, GxConstants.TUOI_RUOCLE))
            {
                if (MessageBox.Show("Giáo dân này rước lễ lần đầu khi chưa được " + GxConstants.TUOI_RUOCLE.ToString() + " tuổi.\r\nBạn có chắc không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    dtNgayRuocLe.Focus();
                    return false;
                }
            }

            if (operation == GxOperation.EDIT && ((int)cbChuyenXu.SelectedValue) > 0)
            {
                if (currentRow != null)
                {
                    if (currentRow[ChuyenXuConst.LoaiChuyen] != DBNull.Value
                        && int.Parse(currentRow["LoaiChuyen"].ToString()) > 0
                        && int.Parse(currentRow["LoaiChuyen"].ToString()) != (int)cbChuyenXu.SelectedValue)
                    {
                        if (Memory.IsExistedData(SqlConstants.SELECT_CHUYENXU_LIST + " AND MaGiaoDan = ? AND NgayChuyen = ?", new object[] { id, dtNgayChuyen.Value }))
                        {
                            MessageBox.Show("Đã có ngày chuyển xứ của giáo dân này trùng với ngày chuyển xứ bạn nhập\r\nXin vui lòng nhập ngày khác", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtNgayChuyen.Focus();
                            return false;
                        }
                    }
                }
            }

            //if (((int)cbChuyenXu.SelectedValue) > 0)
            //{
            //    if (dtNgayChuyen.Value is DBNull)
            //    {
            //        MessageBox.Show("Hãy nhập ngày chuyển xứ hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        dtNgayChuyen.Focus();
            //        return false;
            //    }
            //}

            return checkGiaoDan();
        }

        public static bool isValidDateInputRelations(object ngaySinh, object ngayRuaToi, object ngayRuocLe, object ngayThemSuc, object ngayChuyenXu, object ngayQuaDoi)
        {
            if (ngayChuyenXu != DBNull.Value && ngaySinh != DBNull.Value && !isValidRelation(ngaySinh.ToString(), ngayChuyenXu.ToString()))
            {
                return false;
            }

             List<string> lstDate = new List<string>();
            if (ngaySinh != DBNull.Value) lstDate.Add(ngaySinh.ToString());
            if (ngayRuaToi != DBNull.Value) lstDate.Add(ngayRuaToi.ToString());
            if (ngayRuaToi != DBNull.Value) lstDate.Add(ngayRuaToi.ToString());
            if (ngayRuaToi != DBNull.Value) lstDate.Add(ngayRuaToi.ToString());
            if (ngayRuaToi != DBNull.Value) lstDate.Add(ngayRuaToi.ToString());
            for (int i = 0; i <= lstDate.Count - 2; i++)
            {
                for (int j = i + 1; j <= lstDate.Count - 1; j++)
                {
                    if (!isValidRelation(lstDate[i], lstDate[j]))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public static bool isValidRelation(string compareDate1, string compareDate2)
        {
            DateTime d1;
            DateTime d2;
            if (compareDate1 != "" && compareDate2 != "")
            {
                d1 = Memory.GetDateFromString(compareDate1.ToString(), false);
                d2 = Memory.GetDateFromString(compareDate2.ToString(), true);
                if (d1.CompareTo(d2) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkGiaoDan()
        {
            //check ma giao dan
            if (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIAODAN) == GxConstants.CF_TRUE)
            {
                if (operation == GxOperation.ADD ||
                    (operation == GxOperation.EDIT && currentRow[GiaoDanConst.MaGiaoDan].ToString().ToUpper() != txtMaGiaoDan.Text.ToUpper()))
                {
                    if (Memory.IsExistedData(SqlConstants.SELECT_GIAODAN_THEO_ID, new object[] { txtMaGiaoDan.Text })
                        || Memory.IsExistedData("SELECT * FROM ChuyenXu WHERE MaGiaoDan=?", new object[] { txtMaGiaoDan.Text })
                        || Memory.IsExistedData("SELECT * FROM ThanhVienGiaDinh WHERE MaGiaoDan=?", new object[] { txtMaGiaoDan.Text })
                        || Memory.IsExistedData("SELECT * FROM BiTichChiTiet WHERE MaGiaoDan=?", new object[] { txtMaGiaoDan.Text })
                        )
                    {
                        DialogResult rs = MessageBox.Show("Mã giáo dân đã tồn tại. Vui lòng nhập mã khác!");
                        txtMaGiaoDan.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gxHonPhoi1.IsChanging)
            {
                bool rs = gxHonPhoi1.UpdateHonPhoi();
                if (!rs)
                {
                    this.tabControl1.SelectedTab = tabHonPhoi;
                    return;
                }
            }
            if (updateDataGiaoDan())
            {
                if (gxTanHien1.UpdateData())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.tabControl1.SelectedTab = tabOnGoi;
                }
            }
            else
            {
                //this.DialogResult = DialogResult.Cancel;
            }
        }


        private bool updateDataGiaoDan()
        {
            bool result = false;
            DataSet ds = new DataSet();
            try
            {
                if (!checkInput()) return false;

                //Check if duplicated information
                DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_CHECK_GIAODAN_TONTAI, new object[] { txtHoTen.Text, txtTenThanh.Text, dtNgaySinh.Value, Id });
                if (!Memory.HasError() && tblCheck != null && tblCheck.Rows.Count > 0)
                {
                    DialogResult rs = MessageBox.Show("Đã có giáo dân cùng họ tên, tên thánh và ngày sinh trong hệ thống." +
                        "\r\nBạn có muốn xem lại thông tin của giáo dân đã lưu trong chương trình trùng thông tin bạn nhập?" + 
                        "\r\n - Nhấp nút [Yes] để chương trình hiển thị thông tin của người đã tồn tại trong hệ thống có thông tin trùng thông tin bạn nhập, thông tin bạn vừa nhập sẽ bị bỏ qua" +
                        "\r\n - Nhấp nút [No] để lưu thông tin bạn vừa nhập thành một giáo dân mới và chấp nhận trùng thông tin giáo dân" +
                        "\r\n - Nhấp nút [Cancel] để quay lại màn hình nhập giáo dân để bạn kiểm tra lại thông tin và không lưu gì cả", "Cảnh báo", MessageBoxButtons.YesNoCancel);
                    if (rs == DialogResult.Yes)
                    {
                        //tblCheck = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID, new object[] { tblCheck.Rows[0][GiaoDanConst.MaGiaoDan] });
                        //if (!Memory.HasError() && tblCheck != null && tblCheck.Rows.Count > 0)
                        //{
                        //    operation = GxOperation.EDIT;
                        //    DataRow row1 = GetGiaoDanRowByChuyenXu(tblCheck);
                        //    AssignControlData(row1);
                        //}
                        //else
                        //{
                        //    Memory.ShowError("Rất tiếc, chương trình có lỗi và không thể lấy dữ liệu giáo dân đã tồn tại cho bạn xem.\r\n" +
                        //        "Xin vui lòng thử làm lại hoặc liên hệ tác giả để được giải quyết");
                        //}
                        Id = (int)tblCheck.Rows[0][GiaoDanConst.MaGiaoDan];
                        AssignControlData();
                        return false;
                    }
                    else if (rs == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                else if (Memory.ShowError())
                {
                    return false;
                }

                if (operation == GxOperation.ADD)
                {
                    if (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIAODAN) != GxConstants.CF_TRUE)
                    {
                        id = Memory.Instance.GetNextId(GiaoDanConst.TableName, GiaoDanConst.MaGiaoDan, true);
                    }
                }
                
                //Kiem tra chuyen xu
                if (operation == GxOperation.EDIT && (int)cbChuyenXu.SelectedValue == 0)
                {
                    if (currentRow[ChuyenXuConst.MaChuyenXu] != DBNull.Value)
                    {
                        Memory.DeleteRows(ChuyenXuConst.TableName, ChuyenXuConst.MaGiaoDan, id);
                        Memory.ShowError();
                    }
                }
                else
                {
                    if ((int)cbChuyenXu.SelectedValue > 0)
                    {
                        //Lay thong tin chuyen xu
                        DataTable tblChuyenXu = null;

                        tblChuyenXu = GetChuyenXuInfo(currentRow, Id, (int)cbChuyenXu.SelectedValue, dtNgayChuyen.Value, txtGiaoXuChuyen.Text, txtGhiChuChuyenXu.Text);
                        if (tblChuyenXu != null)
                        {
                            tblChuyenXu.TableName = ChuyenXuConst.TableName;
                            ds.Tables.Add(tblChuyenXu);
                        }
                    }
                }
                DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO + " AND MaGiaoDan = " + id.ToString());
                if (Memory.ShowError())
                {
                    result = false;
                    goto exitHandler;
                }
                tbl.TableName = GiaoDanConst.TableName;
                if (operation == GxOperation.ADD)
                {
                    dataReturn = tbl.NewRow();
                    AssignDataSource(dataReturn);
                    tbl.Rows.Add(dataReturn);
                }
                else
                {
                    dataReturn = tbl.Rows[0];
                    AssignDataSource(dataReturn);
                }

                //update thanh vien gia dinh neu cha me la 1 gia dinh
                if (!fromGiaDinhForm && maGiaDinhMoi > 0)
                {
                    if (MessageBox.Show("Bạn có muốn đưa giáo dân này vào danh sách con cái gia đình của Cha mẹ được chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataTable tblThanhVienGiaDinh = Memory.GetTable(ThanhVienGiaDinhConst.TableName, string.Format(" AND MaGiaoDan={0} AND VaiTro=2", id));
                        if (!Memory.ShowError() && tblThanhVienGiaDinh != null)
                        {
                            if (tblThanhVienGiaDinh.Rows.Count > 0)
                            {
                                MessageBox.Show(string.Format("Giáo dân này đã là con cái của gia đình có mã {0}. Không thể thêm giáo dân này vào gia đình của Cha mẹ được chọn", tblThanhVienGiaDinh.Rows[0][ThanhVienGiaDinhConst.MaGiaDinh]),
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DataRow rowThanhVien = tblThanhVienGiaDinh.NewRow();
                                rowThanhVien[ThanhVienGiaDinhConst.MaGiaDinh] = maGiaDinhMoi;
                                rowThanhVien[ThanhVienGiaDinhConst.MaGiaoDan] = id;
                                rowThanhVien[ThanhVienGiaDinhConst.VaiTro] = GxConstants.VAITRO_CON;
                                tblThanhVienGiaDinh.Rows.Add(rowThanhVien);
                                tblThanhVienGiaDinh.TableName = ThanhVienGiaDinhConst.TableName;
                                ds.Tables.Add(tblThanhVienGiaDinh);
                            }
                        }

                    }
                }

                ds.Tables.Add(tbl);
                Memory.UpdateDataSet(ds);

                if (!Memory.ShowError())
                {
                    //change thanh vien gia dinh, so bi tich, chuyen xu
                    if (operation == GxOperation.EDIT)
                    {
                        if (currentRow[GiaoDanConst.MaGiaoDan].ToString().ToUpper() != txtMaGiaoDan.Text.ToUpper())
                        {
                            Memory.ExecuteSqlCommand("UPDATE ThanhVienGiaDinh SET MaGiaoDan=? WHERE MaGiaoDan=?", new object[] { txtMaGiaoDan.Text, currentRow[GiaoDanConst.MaGiaoDan] });
                            Memory.ExecuteSqlCommand("UPDATE BiTichChiTiet SET MaGiaoDan=? WHERE MaGiaoDan=?", new object[] { txtMaGiaoDan.Text, currentRow[GiaoDanConst.MaGiaoDan] });
                            Memory.ExecuteSqlCommand("UPDATE ChuyenXu SET MaGiaoDan=? WHERE MaGiaoDan=?", new object[] { txtMaGiaoDan.Text, currentRow[GiaoDanConst.MaGiaoDan] });
                            if (!Memory.ShowError())
                            {
                                for (int i = ds.Tables.Count - 1; i >= 0; i--)
                                {
                                    ds.Tables.Remove(ds.Tables[i]);
                                }
                                result = true;
                                goto exitHandler;
                            }
                        }
                    }
                    gxTanHien1.MaGiaoDan = id;
                    gxTanHien1.GiaoDanRow = this.CurrentRow;
                    result = true;
                    goto exitHandler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmGiaoDan, btnOK_Click)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            result = false;

        exitHandler:

            if (result)
            {
                giaoDanDaLuu = true;
                Operation = GxOperation.EDIT;
                //AssignControlData();
                DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID, new object[] { id });
                if (tbl != null && tbl.Rows.Count > 0)
                {
                    currentRow = GetGiaoDanRowByChuyenXu(tbl);
                }
            }

            for (int i = ds.Tables.Count - 1; i >= 0; i--)
            {
                ds.Tables.Remove(ds.Tables[i]);
            }
            return result;
        }

        public static DataTable GetChuyenXuInfo(DataRow rowGiaoDan, int maGiaoDan, int loaiChuyen, object ngayChuyen, string noiChuyen, string ghiChu)
        {
            int maChuyenXu = 0;
            DataTable tblChuyenXu = null;
            if (rowGiaoDan != null)//if giao dan is existed in database
            {
                if (loaiChuyen > 0)
                {
                    if (rowGiaoDan != null && rowGiaoDan[ChuyenXuConst.MaChuyenXu] != DBNull.Value)
                    {
                        //Neu da co thong tin chuyen xu
                        maChuyenXu = int.Parse(rowGiaoDan[ChuyenXuConst.MaChuyenXu].ToString());
                    }
                    //Lay thong tin chuyen xu theo id
                    tblChuyenXu = Memory.GetData(SqlConstants.SELECT_CHUYENXU_THEOID, new object[] { maGiaoDan });
                    if (Memory.ShowError())
                    {
                        return null;
                    }
                    if (tblChuyenXu != null && tblChuyenXu.Rows.Count > 0)
                    {
                        //lay loai chuyen theo id neu da co thong tin chuyen xu
                        //loaiChuyenXu = int.Parse(tblChuyenXu.Rows[0][ChuyenXuConst.LoaiChuyen].ToString());
                        //if (loaiChuyenXu == loaiChuyen)
                        //{

                        //}
                        tblChuyenXu.Rows[0][ChuyenXuConst.LoaiChuyen] = loaiChuyen;
                        tblChuyenXu.Rows[0][ChuyenXuConst.NgayChuyen] = ngayChuyen;
                        tblChuyenXu.Rows[0][ChuyenXuConst.NoiChuyen] = noiChuyen;
                        tblChuyenXu.Rows[0][ChuyenXuConst.GhiChuChuyen] = ghiChu;
                        return tblChuyenXu;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                tblChuyenXu = Memory.GetTableStruct(ChuyenXuConst.TableName);
            }
            if (tblChuyenXu != null)
            {
                DataRow newRow = tblChuyenXu.NewRow();
                newRow[ChuyenXuConst.MaChuyenXu] = Memory.Instance.GetNextId(ChuyenXuConst.TableName, ChuyenXuConst.MaChuyenXu, false);
                newRow[ChuyenXuConst.MaGiaoDan] = maGiaoDan;
                newRow[ChuyenXuConst.LoaiChuyen] = loaiChuyen;
                newRow[ChuyenXuConst.NgayChuyen] = ngayChuyen;
                newRow[ChuyenXuConst.NoiChuyen] = noiChuyen;
                newRow[ChuyenXuConst.GhiChuChuyen] = ghiChu;
                newRow[ChuyenXuConst.UpdateDate] = Memory.Instance.GetServerDateTime();
                tblChuyenXu.Rows.Add(newRow);
            }
            return tblChuyenXu;
        }
        /// <summary>
        /// Gán dữ liệu từ form xuống
        /// </summary>
        /// <param name="row"></param>
        private void AssignDataSource(DataRow row)
        {
            row[GiaoDanConst.MaGiaoDan] = id;
            row[GiaoDanConst.ChaRuaToi] = (txtLinhMucRuaToi.Text);
            row[GiaoDanConst.ChaRuocLe] = (txtLinhMucRuocLe.Text);
            row[GiaoDanConst.ChaThemSuc] = (txtLinhMucThemSuc.Text);
            row[GiaoDanConst.ConHoc] = chkConHoc.Checked;
            row[GiaoDanConst.HoTen] = (txtHoTen.Text);
            row[GiaoDanConst.NgayRuaToi] = dtNgayRuaToi.Value;
            row[GiaoDanConst.NgayRuocLe] = dtNgayRuocLe.Value;
            row[GiaoDanConst.NgaySinh] = dtNgaySinh.Value;
            row[GiaoDanConst.NgayThemSuc] = dtNgayThemSuc.Value;
            row[GiaoDanConst.NgayQuaDoi] = dtNgayQuaDoi.Value;
            row[GiaoDanConst.NgheNghiep] = cbNgheNghiep.Text;
            row[GiaoDanConst.NguoiDoDauRuaToi] = (txtNguoiDoDauRuaToi.Text);
            row[GiaoDanConst.NguoiDoDauThemSuc] = (txtNguoiDoDauThemSuc.Text);
            row[GiaoDanConst.NoiRuaToi] = txtNoiRuaToi.Text;
            row[GiaoDanConst.NoiRuocLe] = txtNoiRuocLe.Text;
            row[GiaoDanConst.NoiSinh] = txtNoiSinh.Text;
            row[GiaoDanConst.NoiThemSuc] = txtNoiThemSuc.Text;
            row[GiaoDanConst.Phai] = cbPhai.Text;
            row[GiaoDanConst.QuaDoi] = chkQuaDoi.Checked;
            row[GiaoDanConst.TenThanh] = txtTenThanh.Text;
            row[GiaoDanConst.TrinhDoVanHoa] = cbVanHoa.Text;
            row[GiaoDanConst.DienThoai] = txtDienThoai.Text;
            row[GiaoDanConst.Email] = txtEmail.Text;
            row[GiaoDanConst.MaGiaoHo] = cbGiaoHo.MaGiaoHo;
            row[GiaoHoConst.TenGiaoHo] = cbGiaoHo.Text;
            row[GiaoDanConst.UpdateDate] = Memory.Instance.GetServerDateTime();
            row[GiaoDanConst.SoRuaToi] = txtSoRuaToi.Text;
            row[GiaoDanConst.SoRuocLe] = txtSoRuocLe.Text;
            row[GiaoDanConst.SoThemSuc] = txtSoThemSuc.Text;
            row[GiaoDanConst.GhiChu] = txtGhiChu.Text;
            row[GiaoDanConst.HoTenCha] = txtTenCha.Text;
            row[GiaoDanConst.HoTenMe] = txtTenMe.Text;
            row[GiaoDanConst.DaCoGiaDinh] = chkDaCoGiaDinh.Checked;
            row[GiaoDanConst.GiaoDanAo] = chkGiaoDanAo.Checked;
            row[GiaoDanConst.TanTong] = chkTanTong.Checked;
            row[GiaoDanConst.DaChuyenXu] = (int)cbChuyenXu.SelectedValue == 2 ? -1 : 0;
            row[GiaoDanConst.AnhDaiDien] = gxPictureField1.FileName;

            if (chkDelete.Visible)
            {
                row[GiaoDanConst.DaXoa] = chkDelete.Checked;
            }
            if (Memory.IsNullOrEmpty(row[GiaoDanConst.MaNhanDang]))
            {
                row[GiaoDanConst.MaNhanDang] = Memory.GetGiaoDanKey(row[GiaoDanConst.MaGiaoDan]);
            }
            row[GiaoDanConst.ThuocGiaoXu] = txtGiaoXu.Text;
            row[GiaoDanConst.ThuocGiaoPhan] = txtGiaoPhan.Text;
            row[GiaoDanConst.DiaChi] = txtDiaChi.Text;

            row[GiaoDanConst.DanToc] = cbDanToc.Text;
            row[GiaoDanConst.NoiQuaDoi] = txtNoiQuaDoi.Text;
            row[GiaoDanConst.SoAnTang] = txtSoAnTang.Text;
            row[GiaoDanConst.NoiAnTang] = txtNoiAnTang.Text;
        }

        public void AssignControlData()
        {
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID, new object[] { id });
            if (!Memory.HasError() && tbl != null && tbl.Rows.Count > 0)
            {
                DataRow row = GetGiaoDanRowByChuyenXu(tbl);
                AssignControlData(row);
            }
            else if(Memory.ShowError())
            {
                Memory.ShowError("Rất tiếc, chương trình có lỗi và không thể lấy dữ liệu giáo dân đã tồn tại cho bạn xem.\r\n" +
                    "Xin vui lòng thử làm lại hoặc liên hệ tác giả để được giải quyết");
            }
        }

        public static DataRow GetGiaoDanRowByChuyenXu(DataTable tbl)
        {
            DataRow row = null;
            if (tbl.Rows.Count == 1) row = tbl.Rows[0];
            else
            {
                DateTime d1 = Memory.GetDateFromString(tbl.Rows[0][ChuyenXuConst.NgayChuyen].ToString());
                int maxIdx = 0;
                for (int i = 1; i < tbl.Rows.Count; i++)
                {
                    DateTime d2 = Memory.GetDateFromString(tbl.Rows[i][ChuyenXuConst.NgayChuyen].ToString());
                    if (d1.CompareTo(d2) < 0)
                    {
                        d1 = d2;
                        maxIdx = i;
                    }
                }
                row = tbl.Rows[maxIdx];
            }
            return row;
        }
        /// <summary>
        /// Load dữ liệu lên form
        /// </summary>
        /// <param name="row"></param>
        public void AssignControlData(DataRow row)
        {
            id = (int)row[GiaoDanConst.MaGiaoDan];
            txtMaGiaoDan.Text = id.ToString();
            txtLinhMucRuaToi.Text = row[GiaoDanConst.ChaRuaToi].ToString();
            txtLinhMucRuocLe.Text = row[GiaoDanConst.ChaRuocLe].ToString();
            txtLinhMucThemSuc.Text = row[GiaoDanConst.ChaThemSuc].ToString();
            chkConHoc.Checked = (bool)row[GiaoDanConst.ConHoc];
            txtHoTen.Text = row[GiaoDanConst.HoTen].ToString();
            dtNgayRuaToi.Value = row[GiaoDanConst.NgayRuaToi];
            dtNgayRuocLe.Value = row[GiaoDanConst.NgayRuocLe];
            dtNgaySinh.Value = row[GiaoDanConst.NgaySinh];
            dtNgayThemSuc.Value = row[GiaoDanConst.NgayThemSuc];
            dtNgayQuaDoi.Value = row[GiaoDanConst.NgayQuaDoi];
            cbNgheNghiep.SelectedText = row[GiaoDanConst.NgheNghiep].ToString();
            txtNguoiDoDauRuaToi.Text = row[GiaoDanConst.NguoiDoDauRuaToi].ToString();
            txtNguoiDoDauThemSuc.Text = row[GiaoDanConst.NguoiDoDauThemSuc].ToString();
            txtNoiRuaToi.Text = row[GiaoDanConst.NoiRuaToi].ToString();
            txtNoiRuocLe.Text = row[GiaoDanConst.NoiRuocLe].ToString();
            txtNoiSinh.Text = row[GiaoDanConst.NoiSinh].ToString();
            txtNoiThemSuc.Text = row[GiaoDanConst.NoiThemSuc].ToString();
            cbPhai.SelectedText = row[GiaoDanConst.Phai].ToString();
            chkQuaDoi.Checked = (bool)row[GiaoDanConst.QuaDoi];
            txtTenThanh.Text = row[GiaoDanConst.TenThanh].ToString();
            cbVanHoa.SelectedText = row[GiaoDanConst.TrinhDoVanHoa].ToString();
            cbGiaoHo.SelectedValue = row[GiaoDanConst.MaGiaoHo];
            txtDienThoai.Text = row[GiaoDanConst.DienThoai].ToString();
            txtEmail.Text = row[GiaoDanConst.Email].ToString();
            txtSoRuaToi.Text = row[GiaoDanConst.SoRuaToi].ToString();
            txtSoRuocLe.Text = row[GiaoDanConst.SoRuocLe].ToString();
            txtSoThemSuc.Text = row[GiaoDanConst.SoThemSuc].ToString();
            txtGhiChu.Text = row[GiaoDanConst.GhiChu].ToString();
            if (File.Exists(string.Concat(Memory.AppPath, row[GiaoDanConst.AnhDaiDien].ToString())))
            {
                gxPictureField1.ImagePicture = Image.FromFile(string.Concat(Memory.AppPath,row[GiaoDanConst.AnhDaiDien].ToString()));
            }
            else
            {
                
            }
            txtTenCha.Text = row[GiaoDanConst.HoTenCha].ToString();
            txtTenMe.Text = row[GiaoDanConst.HoTenMe].ToString();
            chkDaCoGiaDinh.Checked = (bool)row[GiaoDanConst.DaCoGiaDinh];
            chkGiaoDanAo.Checked = (bool)row[GiaoDanConst.GiaoDanAo];
            chkTanTong.Checked = (bool)row[GiaoDanConst.TanTong];

            if(row[ChuyenXuConst.LoaiChuyen] != DBNull.Value) cbChuyenXu.SelectedValue = int.Parse(row[ChuyenXuConst.LoaiChuyen].ToString());
            if (row[ChuyenXuConst.NgayChuyen] != DBNull.Value) dtNgayChuyen.Value = row[ChuyenXuConst.NgayChuyen];
            if (row[ChuyenXuConst.NoiChuyen] != DBNull.Value) txtGiaoXuChuyen.Text = row[ChuyenXuConst.NoiChuyen].ToString();
            if (row[ChuyenXuConst.GhiChuChuyen] != DBNull.Value) txtGhiChuChuyenXu.Text = row[ChuyenXuConst.GhiChuChuyen].ToString();

            if ((bool)row[GiaoDanConst.DaXoa])
            {
                chkDelete.Checked = (bool)row[GiaoDanConst.DaXoa];
                chkDelete.Visible = true;
            }
            //find TenCha, TenMe if not exist in GiaoDan Table
            //Dictionary<int, string> chaMe = GXGiaDinhList.GetTenChaMe(Id, row[GiaoDanConst.HoTenCha].ToString(), row[GiaoDanConst.HoTenMe].ToString());
            //txtTenCha.Text = chaMe[GXConstants.VAITRO_CHONG];
            //txtTenMe.Text = chaMe[GXConstants.VAITRO_VO];

            if (rowGiaDinh == null)
            {
                rowGiaDinh = GxGiaDinhList.GetRowGiaDinh(id, GxConstants.VAITRO_CON);
            }
            if (rowGiaDinh != null)
            {
                if (txtTenCha.Text.Trim() == "")
                {
                    txtTenCha.Text = rowGiaDinh[GiaDinhConst.TenChong].ToString();
                }
                txtTenCha.DisplayMode = DisplayMode.Mode2;
                //txtTenCha.ReadOnly = true;
                //txtTenCha.EditControl.SelectButton.Visible = false;
                //txtTenCha.TextBox.Width = txtNoiSinh.TextBox.Width;
                if (txtTenMe.Text.Trim() == "")
                {
                    txtTenMe.Text = rowGiaDinh[GiaDinhConst.TenVo].ToString();
                }
                txtTenMe.DisplayMode = DisplayMode.Mode2;
                //txtTenMe.ReadOnly = true;
                //txtTenMe.EditControl.SelectButton.Visible = false;
                //txtTenMe.TextBox.Width = txtNoiSinh.TextBox.Width;
            }
            if (GxGiaoDanList.DaCoThongTinHonPhoi(id))
            {
                chkDaCoGiaDinh.Checked = true;
                chkDaCoGiaDinh.Enabled = false;
            }

            txtGiaoXu.Text = row[GiaoDanConst.ThuocGiaoXu].ToString();
            txtGiaoPhan.Text = row[GiaoDanConst.ThuocGiaoPhan].ToString();
            txtDiaChi.Text = row[GiaoDanConst.DiaChi].ToString();
            cbDanToc.SelectedText = row[GiaoDanConst.DanToc].ToString();
            txtNoiQuaDoi.Text = row[GiaoDanConst.NoiQuaDoi].ToString();
            txtSoAnTang.Text = row[GiaoDanConst.SoAnTang].ToString();
            txtNoiAnTang.Text = row[GiaoDanConst.NoiAnTang].ToString();

            currentRow = row;
        }

        private void chkQuaDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuaDoi.Checked)
            {
                dtNgayQuaDoi.Enabled = true;
                chkConHoc.Checked = false;
                txtNoiQuaDoi.Visible = true;
                txtNoiAnTang.Visible = true;
                dtNgayQuaDoi.Visible = true;
                txtSoAnTang.Visible = true;
            }
            else
            {
                dtNgayQuaDoi.Enabled = false;
                txtNoiQuaDoi.Visible = false;
                txtNoiAnTang.Visible = false;
                dtNgayQuaDoi.Visible = false;
                txtSoAnTang.Visible = false;
            }
        }

        private void cbChuyenXu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbChuyenXu.SelectedValue is int)) return;
            if (operation == GxOperation.EDIT && ((int)cbChuyenXu.SelectedValue) == 0)
            {
                if (currentRow != null)
                {
                    if (currentRow[ChuyenXuConst.MaChuyenXu] != DBNull.Value)
                    {
                        if (MessageBox.Show("[" + GxConstants.CHUYENXU_TAIXU + "] nghĩa là xưa này chưa từng chuyển xứ (cả đến và đi)" + Environment.NewLine +
                            "Bạn có chắc muốn thay đổi thông tin chuyển xứ cho giáo dân này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            cbChuyenXu.SelectedValue = currentRow[ChuyenXuConst.LoaiChuyen];
                            return;
                        }
                    }
                }
            }
            if ((int)cbChuyenXu.SelectedValue > 0)
            {
                //dtNgayChuyen.Visible = true;
                txtGiaoXuChuyen.Visible = true;
                //txtGhiChuChuyenXu.Visible = true;
                //btnChuyenXu.Visible = true;
            }
            else
            {
                dtNgayChuyen.Visible = false;
                txtGiaoXuChuyen.Visible = false;
                txtGhiChuChuyenXu.Visible = false;
                //btnChuyenXu.Visible = false;
            }
        }

        private void txtTenCha_OnSelected(object sender, EventArgs e)
        {
            if (txtTenCha.MaGiaoDan > 0)
            {
                Dictionary<object, object> dicChaMe = GxGiaDinhList.GetTenVoChong(txtTenCha.MaGiaoDan, GxConstants.VAITRO_CHONG);
                txtTenMe.Text = dicChaMe[GxConstants.VAITRO_VO].ToString();
                maGiaDinhMoi = (int)dicChaMe[GiaDinhConst.MaGiaDinh];
                if (maGiaDinhMoi > -1)
                {
                    getDiaChiGiaDinh();
                }
            }
        }

        private void getDiaChiGiaDinh()
        {
            DataTable tblGiaDinh = Memory.GetTable(GiaDinhConst.TableName, "AND MaGiaDinh=" + maGiaDinhMoi.ToString());
            if (!Memory.ShowError() && tblGiaDinh.Rows.Count > 0)
            {
                string diaChiMoi = tblGiaDinh.Rows[0][GiaDinhConst.DiaChi].ToString().Trim();
                if (diaChiMoi != "" && txtDiaChi.Text.Trim() == "")
                {
                    txtDiaChi.Text = tblGiaDinh.Rows[0][GiaDinhConst.DiaChi].ToString();
                    txtDiaChi.TextBox.BackColor = Color.Yellow;
                }                
            }
        }

        private void txtTenMe_OnSelected(object sender, EventArgs e)
        {
            if (txtTenMe.MaGiaoDan > 0)
            {
                Dictionary<object, object> dicChaMe = GxGiaDinhList.GetTenVoChong(txtTenMe.MaGiaoDan, GxConstants.VAITRO_VO);
                txtTenCha.Text = dicChaMe[GxConstants.VAITRO_CHONG].ToString();
                maGiaDinhMoi = (int)dicChaMe[GiaDinhConst.MaGiaDinh];
                if (maGiaDinhMoi > -1)
                {
                    getDiaChiGiaDinh();
                }
            }
        }

        private void chkGiaoDanAo_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoaded && chkGiaoDanAo.Checked)
            {
                cbGiaoHo.SelectedValue = 0;
            }
        }

        private void cbGiaoHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cbGiaoHo.SelectedValue == 0) //if ngoai xu
            {
                txtGiaoXu.Visible = true;
                txtGiaoPhan.Visible = true;
                uiGroupBox6.Visible = false;//An thong tin chuyen xu
            }
            else
            {
                txtGiaoXu.Visible = false;
                txtGiaoPhan.Visible = false;
                uiGroupBox6.Visible = true;//Hien thong tin chuyen xu
            }
        }

        //private void btnHonPhoi_Click(object sender, EventArgs e)
        //{
        //    frmHonPhoi frm = new frmHonPhoi();
        //    DataTable tbl = frm.GetHonPhoi(id);
        //    if (tbl == null)
        //    {
        //        if (cbPhai.Text.ToLower() == GxConstants.NAM.ToLower())
        //        {
        //            frm.MaNguoiNam = id;
        //        }
        //        else
        //        {
        //            frm.MaNguoiNu = id;
        //        }
        //    }
        //    frm.ShowDialog();
        //}

        private bool selectingTab = false;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            if (selectingTab) return;
            selectingTab = true;
            //uiTab1.SelectedTab.Name
            if (!giaoDanDaLuu && tabControl1.SelectedTab.Equals(tabHonPhoi))
            {
                if (this.operation == GxOperation.ADD)
                {
                    if (MessageBox.Show("Phải lưu thông tin cá nhân trước khi nhập thông tin hôn phối. Bạn có muốn lưu thông tin cá nhân không?", "Thông báo",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!updateDataGiaoDan())
                        {
                            tabControl1.SelectedTab = tabCaNhan;
                            selectingTab = false;
                            return;
                        }
                        else
                        {
                            tabControl1.SelectedTab = tabHonPhoi;
                        }
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabCaNhan;
                    }
                    gxHonPhoi1.MaGiaoDan = id;
                    gxHonPhoi1.Phai = cbPhai.Text;
                    gxHonPhoi1.LoadData();
                }
            }
            else if (!giaoDanDaLuu && tabControl1.SelectedTab.Equals(tabOnGoi))
            {
                if (this.operation == GxOperation.ADD)
                {
                    if (MessageBox.Show("Phải lưu thông tin cá nhân trước khi nhập thông tin ơn gọi. Bạn có muốn lưu thông tin cá nhân không?", "Thông báo",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!updateDataGiaoDan())
                        {
                            tabControl1.SelectedTab = tabCaNhan;
                            selectingTab = false;
                            return;
                        }
                        else
                        {
                            tabControl1.SelectedTab = tabOnGoi;
                        }
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabCaNhan;
                    }
                    gxTanHien1.MaGiaoDan = id;
                    gxTanHien1.GiaoDanRow = this.CurrentRow;
                    gxTanHien1.GetData(id);
                }
            }
            else
            {
                txtTenThanh.Focus();
            }
            selectingTab = false;
        }

        private void chkConHoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConHoc.Checked)
            {
                chkQuaDoi.Checked = false;
                dtNgayQuaDoi.Value = DBNull.Value;
            }
        }

        private void cbPhai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            DataRow row = GxGiaDinhList.GetRowGiaDinhVoChong(id);
            if (row != null)
            {
                isLoaded = false;
                Memory.ShowError("Giáo dân này đã được nhập là vợ/chồng trong một gia đình hoặc hôn phối. Không thể thay đổi giới tính cho giáo dân này.\r\n" +
                    "Để thay đổi giới tính, bạn phải tìm tất cả các gia đình hoặc hôn phối mà giáo dân này là vợ/chồng và bỏ đi quan hệ đó trước");
                if (cbPhai.SelectedIndex == 0) cbPhai.SelectedIndex = 1;
                else cbPhai.SelectedIndex = 0;
                isLoaded = true;
            }
        }

        private void frmGiaoDan_VisibleChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                
            }
        }

        private void txtTenCha_Load(object sender, EventArgs e)
        {

        }
    }
}