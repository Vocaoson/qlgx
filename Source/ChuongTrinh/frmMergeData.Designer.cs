namespace GiaoXu
{
    partial class frmMergeData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMergeData));
            this.btnStop = new GxControl.GxButton();
            this.btnStart = new GxControl.GxButton();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtErrorOutput = new System.Windows.Forms.TextBox();
            this.btnSelectDB = new GxControl.GxButton();
            this.txtDB = new GxControl.GxTextField();
            this.gxCommand1 = new GxControl.GxCommand();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbHonPhoi = new Janus.Windows.EditControls.UIGroupBox();
            this.cbGiaoHoGiaDinh = new GxControl.GxGiaoHo();
            this.grbGiaoHo = new GxControl.GxGroupBox();
            this.radOverrideGiaoHo = new GxControl.GxRadioBox();
            this.gxGroupBox1 = new GxControl.GxGroupBox();
            this.radOverrideDotBiTich = new GxControl.GxRadioBox();
            this.gxGroupBox2 = new GxControl.GxGroupBox();
            this.radForceOverrideHonPhoi = new GxControl.GxRadioBox();
            this.radOverrideHonPhoi = new GxControl.GxRadioBox();
            this.grbGiaDinh = new GxControl.GxGroupBox();
            this.radForceOverrideGiaDinh = new GxControl.GxRadioBox();
            this.radOverrideGiaDinh = new GxControl.GxRadioBox();
            this.grbGiaoDan = new GxControl.GxGroupBox();
            this.radForceOverrideGiaoDan = new GxControl.GxRadioBox();
            this.radOverrideGiaoDan = new GxControl.GxRadioBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.gxGiaoDanList1 = new GxControl.GxGiaoDanImportList();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.gxGiaDinhList1 = new GxControl.GxGiaDinhImportList();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gxRadioBox1 = new GxControl.GxRadioBox();
            this.gxRadioBox2 = new GxControl.GxRadioBox();
            this.gxRadioBox3 = new GxControl.GxRadioBox();
            this.gxRadioBox4 = new GxControl.GxRadioBox();
            ((System.ComponentModel.ISupportInitialize)(this.grbHonPhoi)).BeginInit();
            this.grbHonPhoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGiaoHo)).BeginInit();
            this.grbGiaoHo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox1)).BeginInit();
            this.gxGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox2)).BeginInit();
            this.gxGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGiaDinh)).BeginInit();
            this.grbGiaDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGiaoDan)).BeginInit();
            this.grbGiaoDan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).BeginInit();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(817, 151);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Hủy bỏ";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(736, 151);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(677, 294);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(55, 13);
            this.lblPercent.TabIndex = 4;
            this.lblPercent.Text = "0%";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPercent.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 294);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Tiến trình";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 314);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(712, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // txtErrorOutput
            // 
            this.txtErrorOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrorOutput.Location = new System.Drawing.Point(0, 0);
            this.txtErrorOutput.Multiline = true;
            this.txtErrorOutput.Name = "txtErrorOutput";
            this.txtErrorOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorOutput.Size = new System.Drawing.Size(907, 124);
            this.txtErrorOutput.TabIndex = 2;
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectDB.BackgroundImage")));
            this.btnSelectDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectDB.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSelectDB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSelectDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSelectDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectDB.Location = new System.Drawing.Point(578, 25);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDB.TabIndex = 1;
            this.btnSelectDB.Text = "Chọn";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // txtDB
            // 
            this.txtDB.AutoCompleteEnabled = true;
            this.txtDB.AutoUpperFirstChar = false;
            this.txtDB.BoxLeft = 80;
            this.txtDB.EditEnabled = true;
            this.txtDB.Label = "Chọn tập tin";
            this.txtDB.Location = new System.Drawing.Point(9, 25);
            this.txtDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDB.MaxLength = 32767;
            this.txtDB.MultiLine = false;
            this.txtDB.Name = "txtDB";
            this.txtDB.NumberInputRequired = true;
            this.txtDB.NumberMode = false;
            this.txtDB.ReadOnly = false;
            this.txtDB.Size = new System.Drawing.Size(563, 25);
            this.txtDB.TabIndex = 0;
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 505);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(911, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnCancel += new System.EventHandler(this.gxCommand1_OnCancel);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "ZIP File|*.zip|MS Access File (*.mdb)|*.mdb|All files (*.*)|*.*";
            // 
            // grbHonPhoi
            // 
            this.grbHonPhoi.Controls.Add(this.cbGiaoHoGiaDinh);
            this.grbHonPhoi.Controls.Add(this.grbGiaoHo);
            this.grbHonPhoi.Controls.Add(this.gxGroupBox1);
            this.grbHonPhoi.Controls.Add(this.gxGroupBox2);
            this.grbHonPhoi.Controls.Add(this.grbGiaDinh);
            this.grbHonPhoi.Controls.Add(this.grbGiaoDan);
            this.grbHonPhoi.Controls.Add(this.btnSelectDB);
            this.grbHonPhoi.Controls.Add(this.txtDB);
            this.grbHonPhoi.Controls.Add(this.progressBar1);
            this.grbHonPhoi.Controls.Add(this.label2);
            this.grbHonPhoi.Controls.Add(this.label3);
            this.grbHonPhoi.Controls.Add(this.label5);
            this.grbHonPhoi.Controls.Add(this.label4);
            this.grbHonPhoi.Controls.Add(this.label1);
            this.grbHonPhoi.Controls.Add(this.lblStatus);
            this.grbHonPhoi.Controls.Add(this.btnStop);
            this.grbHonPhoi.Controls.Add(this.lblPercent);
            this.grbHonPhoi.Controls.Add(this.btnStart);
            this.grbHonPhoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbHonPhoi.Location = new System.Drawing.Point(0, 0);
            this.grbHonPhoi.Name = "grbHonPhoi";
            this.grbHonPhoi.Size = new System.Drawing.Size(911, 357);
            this.grbHonPhoi.TabIndex = 7;
            this.grbHonPhoi.Text = "Nhập dữ liệu từ cùng chương trình";
            // 
            // cbGiaoHoGiaDinh
            // 
            this.cbGiaoHoGiaDinh.AutoLoadGrid = false;
            this.cbGiaoHoGiaDinh.AutoUpperFirstChar = false;
            this.cbGiaoHoGiaDinh.BoxLeft = 230;
            this.cbGiaoHoGiaDinh.EditEnabled = true;
            this.cbGiaoHoGiaDinh.Enabled = false;
            this.cbGiaoHoGiaDinh.GridGiaDinh = null;
            this.cbGiaoHoGiaDinh.GridGiaoDan = null;
            this.cbGiaoHoGiaDinh.HasShowAll = true;
            this.cbGiaoHoGiaDinh.IsAo = Janus.Windows.GridEX.TriState.Empty;
            this.cbGiaoHoGiaDinh.IsLuuTru = false;
            this.cbGiaoHoGiaDinh.Label = "Chỉ nhập gia đình trong máy phụ thuộc giáo họ";
            this.cbGiaoHoGiaDinh.Location = new System.Drawing.Point(21, 151);
            this.cbGiaoHoGiaDinh.MaGiaoHo = -1;
            this.cbGiaoHoGiaDinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGiaoHoGiaDinh.Name = "cbGiaoHoGiaDinh";
            this.cbGiaoHoGiaDinh.SelectedValue = null;
            this.cbGiaoHoGiaDinh.ShowNgoaiXu = true;
            this.cbGiaoHoGiaDinh.Size = new System.Drawing.Size(459, 27);
            this.cbGiaoHoGiaDinh.TabIndex = 8;
            this.cbGiaoHoGiaDinh.WhereSQL = "";
            // 
            // grbGiaoHo
            // 
            this.grbGiaoHo.Controls.Add(this.gxRadioBox1);
            this.grbGiaoHo.Controls.Add(this.radOverrideGiaoHo);
            this.grbGiaoHo.Location = new System.Drawing.Point(18, 58);
            this.grbGiaoHo.Name = "grbGiaoHo";
            this.grbGiaoHo.Size = new System.Drawing.Size(355, 40);
            this.grbGiaoHo.TabIndex = 7;
            this.grbGiaoHo.Text = "Giáo họ";
            // 
            // radOverrideGiaoHo
            // 
            this.radOverrideGiaoHo.AutoSize = true;
            this.radOverrideGiaoHo.Checked = true;
            this.radOverrideGiaoHo.Location = new System.Drawing.Point(109, 17);
            this.radOverrideGiaoHo.Name = "radOverrideGiaoHo";
            this.radOverrideGiaoHo.Size = new System.Drawing.Size(125, 17);
            this.radOverrideGiaoHo.TabIndex = 7;
            this.radOverrideGiaoHo.TabStop = true;
            this.radOverrideGiaoHo.Text = "Chép đè bình thường";
            this.radOverrideGiaoHo.UseVisualStyleBackColor = true;
            // 
            // gxGroupBox1
            // 
            this.gxGroupBox1.Controls.Add(this.gxRadioBox4);
            this.gxGroupBox1.Controls.Add(this.radOverrideDotBiTich);
            this.gxGroupBox1.Location = new System.Drawing.Point(659, 58);
            this.gxGroupBox1.Name = "gxGroupBox1";
            this.gxGroupBox1.Size = new System.Drawing.Size(233, 40);
            this.gxGroupBox1.TabIndex = 7;
            this.gxGroupBox1.Text = "Đợt bí tích";
            // 
            // radOverrideDotBiTich
            // 
            this.radOverrideDotBiTich.AutoSize = true;
            this.radOverrideDotBiTich.Checked = true;
            this.radOverrideDotBiTich.Location = new System.Drawing.Point(102, 14);
            this.radOverrideDotBiTich.Name = "radOverrideDotBiTich";
            this.radOverrideDotBiTich.Size = new System.Drawing.Size(125, 17);
            this.radOverrideDotBiTich.TabIndex = 7;
            this.radOverrideDotBiTich.TabStop = true;
            this.radOverrideDotBiTich.Text = "Chép đè bình thường";
            this.radOverrideDotBiTich.UseVisualStyleBackColor = true;
            // 
            // gxGroupBox2
            // 
            this.gxGroupBox2.Controls.Add(this.gxRadioBox2);
            this.gxGroupBox2.Controls.Add(this.radForceOverrideHonPhoi);
            this.gxGroupBox2.Controls.Add(this.radOverrideHonPhoi);
            this.gxGroupBox2.Location = new System.Drawing.Point(379, 104);
            this.gxGroupBox2.Name = "gxGroupBox2";
            this.gxGroupBox2.Size = new System.Drawing.Size(513, 40);
            this.gxGroupBox2.TabIndex = 7;
            this.gxGroupBox2.Text = "Hôn phối";
            // 
            // radForceOverrideHonPhoi
            // 
            this.radForceOverrideHonPhoi.AutoSize = true;
            this.radForceOverrideHonPhoi.Location = new System.Drawing.Point(280, 14);
            this.radForceOverrideHonPhoi.Name = "radForceOverrideHonPhoi";
            this.radForceOverrideHonPhoi.Size = new System.Drawing.Size(108, 17);
            this.radForceOverrideHonPhoi.TabIndex = 7;
            this.radForceOverrideHonPhoi.TabStop = true;
            this.radForceOverrideHonPhoi.Text = "Chép đè ép buộc";
            this.radForceOverrideHonPhoi.UseVisualStyleBackColor = true;
            // 
            // radOverrideHonPhoi
            // 
            this.radOverrideHonPhoi.AutoSize = true;
            this.radOverrideHonPhoi.Checked = true;
            this.radOverrideHonPhoi.Location = new System.Drawing.Point(149, 14);
            this.radOverrideHonPhoi.Name = "radOverrideHonPhoi";
            this.radOverrideHonPhoi.Size = new System.Drawing.Size(125, 17);
            this.radOverrideHonPhoi.TabIndex = 7;
            this.radOverrideHonPhoi.TabStop = true;
            this.radOverrideHonPhoi.Text = "Chép đè bình thường";
            this.radOverrideHonPhoi.UseVisualStyleBackColor = true;
            // 
            // grbGiaDinh
            // 
            this.grbGiaDinh.Controls.Add(this.gxRadioBox3);
            this.grbGiaDinh.Controls.Add(this.radForceOverrideGiaDinh);
            this.grbGiaDinh.Controls.Add(this.radOverrideGiaDinh);
            this.grbGiaDinh.Location = new System.Drawing.Point(18, 104);
            this.grbGiaDinh.Name = "grbGiaDinh";
            this.grbGiaDinh.Size = new System.Drawing.Size(355, 40);
            this.grbGiaDinh.TabIndex = 7;
            this.grbGiaDinh.Text = "Gia đình";
            // 
            // radForceOverrideGiaDinh
            // 
            this.radForceOverrideGiaDinh.AutoSize = true;
            this.radForceOverrideGiaDinh.Location = new System.Drawing.Point(237, 14);
            this.radForceOverrideGiaDinh.Name = "radForceOverrideGiaDinh";
            this.radForceOverrideGiaDinh.Size = new System.Drawing.Size(108, 17);
            this.radForceOverrideGiaDinh.TabIndex = 7;
            this.radForceOverrideGiaDinh.TabStop = true;
            this.radForceOverrideGiaDinh.Text = "Chép đè ép buộc";
            this.radForceOverrideGiaDinh.UseVisualStyleBackColor = true;
            // 
            // radOverrideGiaDinh
            // 
            this.radOverrideGiaDinh.AutoSize = true;
            this.radOverrideGiaDinh.Checked = true;
            this.radOverrideGiaDinh.Location = new System.Drawing.Point(109, 14);
            this.radOverrideGiaDinh.Name = "radOverrideGiaDinh";
            this.radOverrideGiaDinh.Size = new System.Drawing.Size(125, 17);
            this.radOverrideGiaDinh.TabIndex = 7;
            this.radOverrideGiaDinh.TabStop = true;
            this.radOverrideGiaDinh.Text = "Chép đè bình thường";
            this.radOverrideGiaDinh.UseVisualStyleBackColor = true;
            // 
            // grbGiaoDan
            // 
            this.grbGiaoDan.Controls.Add(this.radForceOverrideGiaoDan);
            this.grbGiaoDan.Controls.Add(this.radOverrideGiaoDan);
            this.grbGiaoDan.Location = new System.Drawing.Point(379, 58);
            this.grbGiaoDan.Name = "grbGiaoDan";
            this.grbGiaoDan.Size = new System.Drawing.Size(274, 40);
            this.grbGiaoDan.TabIndex = 7;
            this.grbGiaoDan.Text = "Giáo dân";
            // 
            // radForceOverrideGiaoDan
            // 
            this.radForceOverrideGiaoDan.AutoSize = true;
            this.radForceOverrideGiaoDan.Location = new System.Drawing.Point(149, 14);
            this.radForceOverrideGiaoDan.Name = "radForceOverrideGiaoDan";
            this.radForceOverrideGiaoDan.Size = new System.Drawing.Size(108, 17);
            this.radForceOverrideGiaoDan.TabIndex = 7;
            this.radForceOverrideGiaoDan.TabStop = true;
            this.radForceOverrideGiaoDan.Text = "Chép đè ép buộc";
            this.radForceOverrideGiaoDan.UseVisualStyleBackColor = true;
            // 
            // radOverrideGiaoDan
            // 
            this.radOverrideGiaoDan.AutoSize = true;
            this.radOverrideGiaoDan.Checked = true;
            this.radOverrideGiaoDan.Location = new System.Drawing.Point(18, 14);
            this.radOverrideGiaoDan.Name = "radOverrideGiaoDan";
            this.radOverrideGiaoDan.Size = new System.Drawing.Size(125, 17);
            this.radOverrideGiaoDan.TabIndex = 7;
            this.radOverrideGiaoDan.TabStop = true;
            this.radOverrideGiaoDan.Text = "Chép đè bình thường";
            this.radOverrideGiaoDan.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(15, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(720, 11);
            this.label2.TabIndex = 4;
            this.label2.Text = "* Chép đè ép buộc: luôn lấy tất cả dữ liệu của máy con đè vào dữ liệu tương ứng t" +
    "rong máy chính, không xét thêm điều kiện gì khác.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(15, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 11);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ghi chú:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(15, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 11);
            this.label5.TabIndex = 4;
            this.label5.Text = "* Bấm phím F1 để xem thêm hướng dẫn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(15, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(787, 11);
            this.label4.TabIndex = 4;
            this.label4.Text = "* Khi chọn chép đè giáo dân hay gia đình, hãy lưu ý có cần chọn chép đè hôn phối " +
    "hay không. Vì hôn phối thường đi kèm với giáo dân, gia đình.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(15, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 11);
            this.label1.TabIndex = 4;
            this.label1.Text = "* Chép đè bình thường: chép đè có chọn lọc, trộn dữ liệu giữa 2 máy.";
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Location = new System.Drawing.Point(0, 357);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(911, 148);
            this.uiTab1.TabIndex = 8;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2,
            this.uiTabPage3});
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.txtErrorOutput);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(907, 124);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Thông báo kết quả chung";
            // 
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.gxGiaoDanList1);
            this.uiTabPage2.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage2.Name = "uiTabPage2";
            this.uiTabPage2.Size = new System.Drawing.Size(907, 246);
            this.uiTabPage2.TabStop = true;
            this.uiTabPage2.Text = "Báo cáo dữ liệu giáo dân";
            // 
            // gxGiaoDanList1
            // 
            this.gxGiaoDanList1.AllowContextMenu = true;
            this.gxGiaoDanList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxGiaoDanList1.AllowEditGiaoDan = true;
            this.gxGiaoDanList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaoDanList1.AllowShowForm = true;
            this.gxGiaoDanList1.Arguments = null;
            this.gxGiaoDanList1.AutoLoadGridFormat = true;
            this.gxGiaoDanList1.ColumnAutoResize = true;
            this.gxGiaoDanList1.DisableParentOnLoadData = true;
            this.gxGiaoDanList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxGiaoDanList1.DynamicFiltering = true;
            this.gxGiaoDanList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaoDanList1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaoDanList1.GroupByBoxVisible = false;
            this.gxGiaoDanList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaoDanList1.Location = new System.Drawing.Point(0, 0);
            this.gxGiaoDanList1.Name = "gxGiaoDanList1";
            this.gxGiaoDanList1.QueryString = "";
            this.gxGiaoDanList1.RecordNavigator = true;
            this.gxGiaoDanList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaoDanList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gxGiaoDanList1.Size = new System.Drawing.Size(907, 246);
            this.gxGiaoDanList1.TabIndex = 0;
            this.gxGiaoDanList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaoDanList1.WhereSQL = "";
            // 
            // uiTabPage3
            // 
            this.uiTabPage3.Controls.Add(this.gxGiaDinhList1);
            this.uiTabPage3.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage3.Name = "uiTabPage3";
            this.uiTabPage3.Size = new System.Drawing.Size(897, 124);
            this.uiTabPage3.TabStop = true;
            this.uiTabPage3.Text = "Báo cáo dữ liệu gia đình";
            // 
            // gxGiaDinhList1
            // 
            this.gxGiaDinhList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxGiaDinhList1.AllowEditGiaDinh = true;
            this.gxGiaDinhList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaDinhList1.Arguments = null;
            this.gxGiaDinhList1.AutoLoadGridFormat = true;
            this.gxGiaDinhList1.ColumnAutoResize = true;
            this.gxGiaDinhList1.DisableParentOnLoadData = true;
            this.gxGiaDinhList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxGiaDinhList1.DynamicFiltering = true;
            this.gxGiaDinhList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaDinhList1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaDinhList1.GroupByBoxVisible = false;
            this.gxGiaDinhList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaDinhList1.Location = new System.Drawing.Point(0, 0);
            this.gxGiaDinhList1.Name = "gxGiaDinhList1";
            this.gxGiaDinhList1.Operation = GxGlobal.GxOperation.EDIT;
            this.gxGiaDinhList1.QueryString = "SELECT * FROM SELECT_GIADINH_LIST WHERE MaGiaDinh<>NULL ";
            this.gxGiaDinhList1.RecordNavigator = true;
            this.gxGiaDinhList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaDinhList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gxGiaDinhList1.Size = new System.Drawing.Size(897, 124);
            this.gxGiaDinhList1.TabIndex = 0;
            this.gxGiaDinhList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaDinhList1.WhereSQL = "";
            // 
            // gxRadioBox1
            // 
            this.gxRadioBox1.AutoSize = true;
            this.gxRadioBox1.Location = new System.Drawing.Point(20, 17);
            this.gxRadioBox1.Name = "gxRadioBox1";
            this.gxRadioBox1.Size = new System.Drawing.Size(83, 17);
            this.gxRadioBox1.TabIndex = 7;
            this.gxRadioBox1.TabStop = true;
            this.gxRadioBox1.Text = "Không nhập";
            this.gxRadioBox1.UseVisualStyleBackColor = true;
            // 
            // gxRadioBox2
            // 
            this.gxRadioBox2.AutoSize = true;
            this.gxRadioBox2.Location = new System.Drawing.Point(18, 17);
            this.gxRadioBox2.Name = "gxRadioBox2";
            this.gxRadioBox2.Size = new System.Drawing.Size(83, 17);
            this.gxRadioBox2.TabIndex = 7;
            this.gxRadioBox2.TabStop = true;
            this.gxRadioBox2.Text = "Không nhập";
            this.gxRadioBox2.UseVisualStyleBackColor = true;
            // 
            // gxRadioBox3
            // 
            this.gxRadioBox3.AutoSize = true;
            this.gxRadioBox3.Location = new System.Drawing.Point(20, 14);
            this.gxRadioBox3.Name = "gxRadioBox3";
            this.gxRadioBox3.Size = new System.Drawing.Size(83, 17);
            this.gxRadioBox3.TabIndex = 7;
            this.gxRadioBox3.TabStop = true;
            this.gxRadioBox3.Text = "Không nhập";
            this.gxRadioBox3.UseVisualStyleBackColor = true;
            // 
            // gxRadioBox4
            // 
            this.gxRadioBox4.AutoSize = true;
            this.gxRadioBox4.Location = new System.Drawing.Point(13, 14);
            this.gxRadioBox4.Name = "gxRadioBox4";
            this.gxRadioBox4.Size = new System.Drawing.Size(83, 17);
            this.gxRadioBox4.TabIndex = 7;
            this.gxRadioBox4.TabStop = true;
            this.gxRadioBox4.Text = "Không nhập";
            this.gxRadioBox4.UseVisualStyleBackColor = true;
            // 
            // frmMergeData
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 550);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.grbHonPhoi);
            this.Name = "frmMergeData";
            this.Text = "Nhap du lieu cung chuong trinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMergeData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grbHonPhoi)).EndInit();
            this.grbHonPhoi.ResumeLayout(false);
            this.grbHonPhoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGiaoHo)).EndInit();
            this.grbGiaoHo.ResumeLayout(false);
            this.grbGiaoHo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox1)).EndInit();
            this.gxGroupBox1.ResumeLayout(false);
            this.gxGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox2)).EndInit();
            this.gxGroupBox2.ResumeLayout(false);
            this.gxGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGiaDinh)).EndInit();
            this.grbGiaDinh.ResumeLayout(false);
            this.grbGiaDinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGiaoDan)).EndInit();
            this.grbGiaoDan.ResumeLayout(false);
            this.grbGiaoDan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            this.uiTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).EndInit();
            this.uiTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxButton btnSelectDB;
        private GxControl.GxTextField txtDB;
        private GxControl.GxCommand gxCommand1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtErrorOutput;
        private GxControl.GxButton btnStop;
        private GxControl.GxButton btnStart;
        private System.Windows.Forms.Label lblPercent;
        private Janus.Windows.EditControls.UIGroupBox grbHonPhoi;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private GxControl.GxGiaoDanImportList gxGiaoDanList1;
        private GxControl.GxGiaDinhImportList gxGiaDinhList1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GxControl.GxGroupBox grbGiaoDan;
        private GxControl.GxRadioBox radForceOverrideGiaoDan;
        private GxControl.GxRadioBox radOverrideGiaoDan;
        private GxControl.GxGroupBox gxGroupBox2;
        private GxControl.GxRadioBox radForceOverrideHonPhoi;
        private GxControl.GxRadioBox radOverrideHonPhoi;
        private GxControl.GxGroupBox grbGiaDinh;
        private GxControl.GxRadioBox radForceOverrideGiaDinh;
        private GxControl.GxRadioBox radOverrideGiaDinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private GxControl.GxGiaoHo cbGiaoHoGiaDinh;
        private System.Windows.Forms.Label label5;
        private GxControl.GxGroupBox gxGroupBox1;
        private GxControl.GxRadioBox radOverrideDotBiTich;
        private GxControl.GxGroupBox grbGiaoHo;
        private GxControl.GxRadioBox radOverrideGiaoHo;
        private GxControl.GxRadioBox gxRadioBox1;
        private GxControl.GxRadioBox gxRadioBox4;
        private GxControl.GxRadioBox gxRadioBox2;
        private GxControl.GxRadioBox gxRadioBox3;
    }
}