namespace GiaoXu
{
    partial class frmOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOption));
            this.gxCommand1 = new GxControl.GxCommand();
            this.faTabStrip1 = new FarsiLibrary.Win.FATabStrip();
            this.faTabStripItem1 = new FarsiLibrary.Win.FATabStripItem();
            this.txtFontSize = new GxControl.GxTextField();
            this.btnResetFont = new GxControl.GxButton();
            this.cmbFontList = new GxControl.GxComboField();
            this.txtMaxBackup = new GxControl.GxTextField();
            this.chkTuNhapMa = new GxControl.GxCheckBox();
            this.chkUSName = new GxControl.GxCheckBox();
            this.chkAutoUpdate = new GxControl.GxCheckBox();
            this.cbReportLang = new GxControl.GxComboField();
            this.faTabStripItem2 = new FarsiLibrary.Win.FATabStripItem();
            this.chkInHoSoLuuTru = new GxControl.GxCheckBox();
            this.chkSoGiaDinhInNoiSinh = new GxControl.GxCheckBox();
            this.chkInMaGiaoDanThaySTT = new GxControl.GxCheckBox();
            this.chkInLapGiaDinh = new GxControl.GxCheckBox();
            this.chkInGachNgang = new GxControl.GxCheckBox();
            this.faTabStripItem3 = new FarsiLibrary.Win.FATabStripItem();
            this.gxGroupBox1 = new GxControl.GxGroupBox();
            this.rdChuanHoaUpperCaseFirstChar = new GxControl.GxRadioBox();
            this.rdChuanHoaLowerCase = new GxControl.GxRadioBox();
            this.rdChuanHoaNormal = new GxControl.GxRadioBox();
            this.rdChuanHoaUpperCase = new GxControl.GxRadioBox();
            this.gxGroupBox2 = new GxControl.GxGroupBox();
            this.chkTuChuanHoa = new GxControl.GxCheckBox();
            this.chkTuChuyenMa = new GxControl.GxCheckBox();
            this.chkChuanHoaTuDoiDau = new GxControl.GxCheckBox();
            this.faTabStripItem4 = new FarsiLibrary.Win.FATabStripItem();
            this.chkHienGiaoDanDaChiuBiTich = new GxControl.GxCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.faTabStrip1)).BeginInit();
            this.faTabStrip1.SuspendLayout();
            this.faTabStripItem1.SuspendLayout();
            this.faTabStripItem2.SuspendLayout();
            this.faTabStripItem3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox1)).BeginInit();
            this.gxGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox2)).BeginInit();
            this.gxGroupBox2.SuspendLayout();
            this.faTabStripItem4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 379);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(582, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // faTabStrip1
            // 
            this.faTabStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faTabStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.faTabStrip1.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.faTabStripItem1,
            this.faTabStripItem2,
            this.faTabStripItem3,
            this.faTabStripItem4});
            this.faTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.faTabStrip1.Name = "faTabStrip1";
            this.faTabStrip1.SelectedItem = this.faTabStripItem1;
            this.faTabStrip1.Size = new System.Drawing.Size(582, 379);
            this.faTabStrip1.TabIndex = 2;
            this.faTabStrip1.Text = "faTabStrip1";
            // 
            // faTabStripItem1
            // 
            this.faTabStripItem1.CanClose = false;
            this.faTabStripItem1.Controls.Add(this.txtFontSize);
            this.faTabStripItem1.Controls.Add(this.btnResetFont);
            this.faTabStripItem1.Controls.Add(this.cmbFontList);
            this.faTabStripItem1.Controls.Add(this.txtMaxBackup);
            this.faTabStripItem1.Controls.Add(this.chkTuNhapMa);
            this.faTabStripItem1.Controls.Add(this.chkUSName);
            this.faTabStripItem1.Controls.Add(this.chkAutoUpdate);
            this.faTabStripItem1.Controls.Add(this.cbReportLang);
            this.faTabStripItem1.IsDrawn = true;
            this.faTabStripItem1.Name = "faTabStripItem1";
            this.faTabStripItem1.Selected = true;
            this.faTabStripItem1.Size = new System.Drawing.Size(580, 358);
            this.faTabStripItem1.TabIndex = 0;
            this.faTabStripItem1.Title = "Tùy chọn chung";
            // 
            // txtFontSize
            // 
            this.txtFontSize.AutoCompleteEnabled = true;
            this.txtFontSize.AutoUpperFirstChar = false;
            this.txtFontSize.BoxLeft = 0;
            this.txtFontSize.EditEnabled = true;
            this.txtFontSize.Label = "Cỡ chữ";
            this.txtFontSize.Location = new System.Drawing.Point(276, 158);
            this.txtFontSize.MaxLength = 32767;
            this.txtFontSize.MultiLine = false;
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.NumberInputRequired = true;
            this.txtFontSize.NumberMode = false;
            this.txtFontSize.ReadOnly = false;
            this.txtFontSize.Size = new System.Drawing.Size(100, 26);
            this.txtFontSize.TabIndex = 12;
            // 
            // btnResetFont
            // 
            this.btnResetFont.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResetFont.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResetFont.BackgroundImage")));
            this.btnResetFont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetFont.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnResetFont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnResetFont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnResetFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetFont.Location = new System.Drawing.Point(382, 161);
            this.btnResetFont.Name = "btnResetFont";
            this.btnResetFont.Size = new System.Drawing.Size(122, 23);
            this.btnResetFont.TabIndex = 11;
            this.btnResetFont.Text = "Trở về font mặc định";
            this.btnResetFont.UseVisualStyleBackColor = true;
            this.btnResetFont.Click += new System.EventHandler(this.btnResetFont_Click);
            // 
            // cmbFontList
            // 
            this.cmbFontList.AutoUpperFirstChar = false;
            this.cmbFontList.BoxLeft = 0;
            this.cmbFontList.EditEnabled = true;
            this.cmbFontList.Label = "Font chữ";
            this.cmbFontList.Location = new System.Drawing.Point(22, 158);
            this.cmbFontList.MaxLength = 0;
            this.cmbFontList.Name = "cmbFontList";
            this.cmbFontList.SelectedIndex = -1;
            this.cmbFontList.SelectedText = "";
            this.cmbFontList.SelectedValue = null;
            this.cmbFontList.Size = new System.Drawing.Size(248, 26);
            this.cmbFontList.TabIndex = 10;
            // 
            // txtMaxBackup
            // 
            this.txtMaxBackup.AutoCompleteEnabled = true;
            this.txtMaxBackup.AutoUpperFirstChar = false;
            this.txtMaxBackup.BoxLeft = 0;
            this.txtMaxBackup.EditEnabled = true;
            this.txtMaxBackup.Label = "Số lượng tập tin sao lưu tối đa được giữ lại trong thư mục backup";
            this.txtMaxBackup.Location = new System.Drawing.Point(22, 113);
            this.txtMaxBackup.MaxLength = 32767;
            this.txtMaxBackup.MultiLine = false;
            this.txtMaxBackup.Name = "txtMaxBackup";
            this.txtMaxBackup.NumberInputRequired = true;
            this.txtMaxBackup.NumberMode = false;
            this.txtMaxBackup.ReadOnly = false;
            this.txtMaxBackup.Size = new System.Drawing.Size(402, 26);
            this.txtMaxBackup.TabIndex = 9;
            // 
            // chkTuNhapMa
            // 
            this.chkTuNhapMa.AutoSize = true;
            this.chkTuNhapMa.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkTuNhapMa.Location = new System.Drawing.Point(22, 93);
            this.chkTuNhapMa.Name = "chkTuNhapMa";
            this.chkTuNhapMa.Size = new System.Drawing.Size(197, 17);
            this.chkTuNhapMa.TabIndex = 7;
            this.chkTuNhapMa.Text = "Cho phép tự nhập mã gia đình riêng";
            this.chkTuNhapMa.UseVisualStyleBackColor = true;
            // 
            // chkUSName
            // 
            this.chkUSName.AutoSize = true;
            this.chkUSName.Enabled = false;
            this.chkUSName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkUSName.Location = new System.Drawing.Point(22, 68);
            this.chkUSName.Name = "chkUSName";
            this.chkUSName.Size = new System.Drawing.Size(275, 17);
            this.chkUSName.TabIndex = 6;
            this.chkUSName.Text = "In họ tên theo định dạng kiểu Mỹ (tên trước họ sau)";
            this.chkUSName.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkAutoUpdate.Location = new System.Drawing.Point(22, 21);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(227, 17);
            this.chkAutoUpdate.TabIndex = 4;
            this.chkAutoUpdate.Text = "Cho phép tự động cập nhật phiên bản mới";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // cbReportLang
            // 
            this.cbReportLang.AutoUpperFirstChar = false;
            this.cbReportLang.BoxLeft = 170;
            this.cbReportLang.EditEnabled = true;
            this.cbReportLang.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbReportLang.Label = "Ngôn ngữ mẫu báo cáo mặc định";
            this.cbReportLang.Location = new System.Drawing.Point(16, 38);
            this.cbReportLang.MaxLength = 0;
            this.cbReportLang.Name = "cbReportLang";
            this.cbReportLang.SelectedIndex = -1;
            this.cbReportLang.SelectedText = "";
            this.cbReportLang.SelectedValue = null;
            this.cbReportLang.Size = new System.Drawing.Size(279, 26);
            this.cbReportLang.TabIndex = 5;
            // 
            // faTabStripItem2
            // 
            this.faTabStripItem2.Controls.Add(this.chkInHoSoLuuTru);
            this.faTabStripItem2.Controls.Add(this.chkSoGiaDinhInNoiSinh);
            this.faTabStripItem2.Controls.Add(this.chkInMaGiaoDanThaySTT);
            this.faTabStripItem2.Controls.Add(this.chkInLapGiaDinh);
            this.faTabStripItem2.Controls.Add(this.chkInGachNgang);
            this.faTabStripItem2.IsDrawn = true;
            this.faTabStripItem2.Name = "faTabStripItem2";
            this.faTabStripItem2.Size = new System.Drawing.Size(580, 358);
            this.faTabStripItem2.TabIndex = 1;
            this.faTabStripItem2.Title = "Sổ gia đình";
            // 
            // chkInHoSoLuuTru
            // 
            this.chkInHoSoLuuTru.AutoSize = true;
            this.chkInHoSoLuuTru.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkInHoSoLuuTru.Location = new System.Drawing.Point(22, 21);
            this.chkInHoSoLuuTru.Name = "chkInHoSoLuuTru";
            this.chkInHoSoLuuTru.Size = new System.Drawing.Size(228, 17);
            this.chkInHoSoLuuTru.TabIndex = 5;
            this.chkInHoSoLuuTru.Text = "Cho phép in cả những giáo dân đã qua đời";
            this.chkInHoSoLuuTru.UseVisualStyleBackColor = true;
            // 
            // chkSoGiaDinhInNoiSinh
            // 
            this.chkSoGiaDinhInNoiSinh.AutoSize = true;
            this.chkSoGiaDinhInNoiSinh.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkSoGiaDinhInNoiSinh.Location = new System.Drawing.Point(22, 113);
            this.chkSoGiaDinhInNoiSinh.Name = "chkSoGiaDinhInNoiSinh";
            this.chkSoGiaDinhInNoiSinh.Size = new System.Drawing.Size(142, 17);
            this.chkSoGiaDinhInNoiSinh.TabIndex = 9;
            this.chkSoGiaDinhInNoiSinh.Text = "In nơi sinh và nơi rửa tội";
            this.chkSoGiaDinhInNoiSinh.UseVisualStyleBackColor = true;
            // 
            // chkInMaGiaoDanThaySTT
            // 
            this.chkInMaGiaoDanThaySTT.AutoSize = true;
            this.chkInMaGiaoDanThaySTT.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkInMaGiaoDanThaySTT.Location = new System.Drawing.Point(22, 90);
            this.chkInMaGiaoDanThaySTT.Name = "chkInMaGiaoDanThaySTT";
            this.chkInMaGiaoDanThaySTT.Size = new System.Drawing.Size(186, 17);
            this.chkInMaGiaoDanThaySTT.TabIndex = 8;
            this.chkInMaGiaoDanThaySTT.Text = "Thay số thứ tự bằng mã giáo dân";
            this.chkInMaGiaoDanThaySTT.UseVisualStyleBackColor = true;
            // 
            // chkInLapGiaDinh
            // 
            this.chkInLapGiaDinh.AutoSize = true;
            this.chkInLapGiaDinh.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkInLapGiaDinh.Location = new System.Drawing.Point(22, 67);
            this.chkInLapGiaDinh.Name = "chkInLapGiaDinh";
            this.chkInLapGiaDinh.Size = new System.Drawing.Size(274, 17);
            this.chkInLapGiaDinh.TabIndex = 7;
            this.chkInLapGiaDinh.Text = "Cho phép in cả những giáo dân đã lập gia đình riêng";
            this.chkInLapGiaDinh.UseVisualStyleBackColor = true;
            // 
            // chkInGachNgang
            // 
            this.chkInGachNgang.AutoSize = true;
            this.chkInGachNgang.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkInGachNgang.Location = new System.Drawing.Point(22, 44);
            this.chkInGachNgang.Name = "chkInGachNgang";
            this.chkInGachNgang.Size = new System.Drawing.Size(252, 17);
            this.chkInGachNgang.TabIndex = 6;
            this.chkInGachNgang.Text = "Những giáo dân đã qua đời bị gạch ngang khi in";
            this.chkInGachNgang.UseVisualStyleBackColor = true;
            // 
            // faTabStripItem3
            // 
            this.faTabStripItem3.Controls.Add(this.gxGroupBox1);
            this.faTabStripItem3.Controls.Add(this.gxGroupBox2);
            this.faTabStripItem3.IsDrawn = true;
            this.faTabStripItem3.Name = "faTabStripItem3";
            this.faTabStripItem3.Size = new System.Drawing.Size(580, 358);
            this.faTabStripItem3.TabIndex = 2;
            this.faTabStripItem3.Title = "Chuẩn hóa dữ liệu";
            // 
            // gxGroupBox1
            // 
            this.gxGroupBox1.Controls.Add(this.rdChuanHoaUpperCaseFirstChar);
            this.gxGroupBox1.Controls.Add(this.rdChuanHoaLowerCase);
            this.gxGroupBox1.Controls.Add(this.rdChuanHoaNormal);
            this.gxGroupBox1.Controls.Add(this.rdChuanHoaUpperCase);
            this.gxGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gxGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.Top;
            this.gxGroupBox1.Location = new System.Drawing.Point(0, 106);
            this.gxGroupBox1.Name = "gxGroupBox1";
            this.gxGroupBox1.Size = new System.Drawing.Size(580, 121);
            this.gxGroupBox1.TabIndex = 1;
            this.gxGroupBox1.Text = "Với các từ được đặt trong dấu ngoặc [ ] ( ) { }";
            // 
            // rdChuanHoaUpperCaseFirstChar
            // 
            this.rdChuanHoaUpperCaseFirstChar.AutoSize = true;
            this.rdChuanHoaUpperCaseFirstChar.Location = new System.Drawing.Point(19, 91);
            this.rdChuanHoaUpperCaseFirstChar.Name = "rdChuanHoaUpperCaseFirstChar";
            this.rdChuanHoaUpperCaseFirstChar.Size = new System.Drawing.Size(285, 17);
            this.rdChuanHoaUpperCaseFirstChar.TabIndex = 3;
            this.rdChuanHoaUpperCaseFirstChar.TabStop = true;
            this.rdChuanHoaUpperCaseFirstChar.Tag = "2";
            this.rdChuanHoaUpperCaseFirstChar.Text = "Chỉ chuyển ký tự đầu tiên của mỗi từ thành chữ in hoa";
            this.rdChuanHoaUpperCaseFirstChar.UseVisualStyleBackColor = true;
            // 
            // rdChuanHoaLowerCase
            // 
            this.rdChuanHoaLowerCase.AutoSize = true;
            this.rdChuanHoaLowerCase.Location = new System.Drawing.Point(19, 68);
            this.rdChuanHoaLowerCase.Name = "rdChuanHoaLowerCase";
            this.rdChuanHoaLowerCase.Size = new System.Drawing.Size(194, 17);
            this.rdChuanHoaLowerCase.TabIndex = 2;
            this.rdChuanHoaLowerCase.TabStop = true;
            this.rdChuanHoaLowerCase.Tag = "1";
            this.rdChuanHoaLowerCase.Text = "Chuyển thành chữ in thường tất cả";
            this.rdChuanHoaLowerCase.UseVisualStyleBackColor = true;
            // 
            // rdChuanHoaNormal
            // 
            this.rdChuanHoaNormal.AutoSize = true;
            this.rdChuanHoaNormal.Location = new System.Drawing.Point(19, 22);
            this.rdChuanHoaNormal.Name = "rdChuanHoaNormal";
            this.rdChuanHoaNormal.Size = new System.Drawing.Size(163, 17);
            this.rdChuanHoaNormal.TabIndex = 0;
            this.rdChuanHoaNormal.TabStop = true;
            this.rdChuanHoaNormal.Tag = "3";
            this.rdChuanHoaNormal.Text = "Để nguyên không thay đổi gì";
            this.rdChuanHoaNormal.UseVisualStyleBackColor = true;
            // 
            // rdChuanHoaUpperCase
            // 
            this.rdChuanHoaUpperCase.AutoSize = true;
            this.rdChuanHoaUpperCase.Location = new System.Drawing.Point(19, 45);
            this.rdChuanHoaUpperCase.Name = "rdChuanHoaUpperCase";
            this.rdChuanHoaUpperCase.Size = new System.Drawing.Size(177, 17);
            this.rdChuanHoaUpperCase.TabIndex = 1;
            this.rdChuanHoaUpperCase.TabStop = true;
            this.rdChuanHoaUpperCase.Tag = "0";
            this.rdChuanHoaUpperCase.Text = "Chuyển thành chữ in hoa tất cả";
            this.rdChuanHoaUpperCase.UseVisualStyleBackColor = true;
            // 
            // gxGroupBox2
            // 
            this.gxGroupBox2.Controls.Add(this.chkTuChuanHoa);
            this.gxGroupBox2.Controls.Add(this.chkTuChuyenMa);
            this.gxGroupBox2.Controls.Add(this.chkChuanHoaTuDoiDau);
            this.gxGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gxGroupBox2.FrameStyle = Janus.Windows.EditControls.FrameStyle.Top;
            this.gxGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.gxGroupBox2.Name = "gxGroupBox2";
            this.gxGroupBox2.Size = new System.Drawing.Size(580, 106);
            this.gxGroupBox2.TabIndex = 1;
            this.gxGroupBox2.Text = "Tùy chọn chung";
            // 
            // chkTuChuanHoa
            // 
            this.chkTuChuanHoa.AutoSize = true;
            this.chkTuChuanHoa.Location = new System.Drawing.Point(19, 26);
            this.chkTuChuanHoa.Name = "chkTuChuanHoa";
            this.chkTuChuanHoa.Size = new System.Drawing.Size(244, 17);
            this.chkTuChuanHoa.TabIndex = 0;
            this.chkTuChuanHoa.Text = "Cho phép tự động chuẩn hóa dữ liệu khi nhập";
            this.chkTuChuanHoa.UseVisualStyleBackColor = true;
            // 
            // chkTuChuyenMa
            // 
            this.chkTuChuyenMa.AutoSize = true;
            this.chkTuChuyenMa.Location = new System.Drawing.Point(19, 72);
            this.chkTuChuyenMa.Name = "chkTuChuyenMa";
            this.chkTuChuyenMa.Size = new System.Drawing.Size(287, 17);
            this.chkTuChuyenMa.TabIndex = 2;
            this.chkTuChuyenMa.Text = "Tự chuyển mã unicode tổ hợp thành unicode dựng sẵn";
            this.chkTuChuyenMa.UseVisualStyleBackColor = true;
            // 
            // chkChuanHoaTuDoiDau
            // 
            this.chkChuanHoaTuDoiDau.AutoSize = true;
            this.chkChuanHoaTuDoiDau.Location = new System.Drawing.Point(19, 49);
            this.chkChuanHoaTuDoiDau.Name = "chkChuanHoaTuDoiDau";
            this.chkChuanHoaTuDoiDau.Size = new System.Drawing.Size(185, 17);
            this.chkChuanHoaTuDoiDau.TabIndex = 1;
            this.chkChuanHoaTuDoiDau.Text = "Tự chuyển thành kiểu dấu òa, ùy";
            this.chkChuanHoaTuDoiDau.UseVisualStyleBackColor = true;
            // 
            // faTabStripItem4
            // 
            this.faTabStripItem4.Controls.Add(this.chkHienGiaoDanDaChiuBiTich);
            this.faTabStripItem4.IsDrawn = true;
            this.faTabStripItem4.Name = "faTabStripItem4";
            this.faTabStripItem4.Size = new System.Drawing.Size(580, 358);
            this.faTabStripItem4.TabIndex = 3;
            this.faTabStripItem4.Title = "Sổ bí tích";
            // 
            // chkHienGiaoDanDaChiuBiTich
            // 
            this.chkHienGiaoDanDaChiuBiTich.AutoSize = true;
            this.chkHienGiaoDanDaChiuBiTich.Location = new System.Drawing.Point(32, 18);
            this.chkHienGiaoDanDaChiuBiTich.Name = "chkHienGiaoDanDaChiuBiTich";
            this.chkHienGiaoDanDaChiuBiTich.Size = new System.Drawing.Size(364, 17);
            this.chkHienGiaoDanDaChiuBiTich.TabIndex = 0;
            this.chkHienGiaoDanDaChiuBiTich.Text = "Khi chọn giáo dân, cho phép hiện cả giáo dân đã chịu bí tích tương ứng";
            this.chkHienGiaoDanDaChiuBiTich.UseVisualStyleBackColor = true;
            // 
            // frmOption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(582, 424);
            this.Controls.Add(this.faTabStrip1);
            this.Controls.Add(this.gxCommand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.ShowInTaskbar = false;
            this.Text = "Tùy chọn";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.faTabStrip1)).EndInit();
            this.faTabStrip1.ResumeLayout(false);
            this.faTabStripItem1.ResumeLayout(false);
            this.faTabStripItem1.PerformLayout();
            this.faTabStripItem2.ResumeLayout(false);
            this.faTabStripItem2.PerformLayout();
            this.faTabStripItem3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox1)).EndInit();
            this.gxGroupBox1.ResumeLayout(false);
            this.gxGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox2)).EndInit();
            this.gxGroupBox2.ResumeLayout(false);
            this.gxGroupBox2.PerformLayout();
            this.faTabStripItem4.ResumeLayout(false);
            this.faTabStripItem4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxCommand gxCommand1;
        private FarsiLibrary.Win.FATabStrip faTabStrip1;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem1;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem2;
        private GxControl.GxCheckBox chkInHoSoLuuTru;
        private GxControl.GxCheckBox chkSoGiaDinhInNoiSinh;
        private GxControl.GxCheckBox chkInMaGiaoDanThaySTT;
        private GxControl.GxCheckBox chkInLapGiaDinh;
        private GxControl.GxCheckBox chkInGachNgang;
        private GxControl.GxCheckBox chkTuNhapMa;
        private GxControl.GxCheckBox chkUSName;
        private GxControl.GxCheckBox chkAutoUpdate;
        private GxControl.GxComboField cbReportLang;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem3;
        private GxControl.GxGroupBox gxGroupBox1;
        private GxControl.GxRadioBox rdChuanHoaUpperCaseFirstChar;
        private GxControl.GxRadioBox rdChuanHoaLowerCase;
        private GxControl.GxRadioBox rdChuanHoaNormal;
        private GxControl.GxRadioBox rdChuanHoaUpperCase;
        private GxControl.GxGroupBox gxGroupBox2;
        private GxControl.GxCheckBox chkChuanHoaTuDoiDau;
        private GxControl.GxCheckBox chkTuChuanHoa;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem4;
        private GxControl.GxCheckBox chkHienGiaoDanDaChiuBiTich;
        private GxControl.GxCheckBox chkTuChuyenMa;
        private GxControl.GxTextField txtMaxBackup;
        private GxControl.GxButton btnResetFont;
        private GxControl.GxComboField cmbFontList;
        private GxControl.GxTextField txtFontSize;
    }
}