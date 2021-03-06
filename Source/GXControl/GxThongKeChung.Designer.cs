namespace GxControl
{
    partial class GxThongKeChung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GxThongKeChung));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.cbGiaoHo = new GxControl.GxGiaoHo();
            this.chkLuuTru = new GxControl.GxCheckBox();
            this.chkNullAccept = new GxControl.GxCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFilter = new GxControl.GxButton();
            this.btnPrint = new GxControl.GxButton();
            this.btnSearch = new GxControl.GxButton();
            this.rdTanTong = new GxControl.GxRadioBox();
            this.rdGiaDinh = new GxControl.GxRadioBox();
            this.rdConSong = new GxControl.GxRadioBox();
            this.rdQuaDoi = new GxControl.GxRadioBox();
            this.rdHonPhoi = new GxControl.GxRadioBox();
            this.rdThemSuc = new GxControl.GxRadioBox();
            this.rdRuocLe = new GxControl.GxRadioBox();
            this.rdRuaToi = new GxControl.GxRadioBox();
            this.rdSinhRa = new GxControl.GxRadioBox();
            this.dtDateTo = new GxControl.GxDateField();
            this.dtDateFrom = new GxControl.GxDateField();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.gxHonPhoiList1 = new GxControl.GxHonPhoiList();
            this.gxGiaDinhList1 = new GxControl.GxGiaDinhList();
            this.gxGiaoDanList1 = new GxControl.GxGiaoDanList();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxHonPhoiList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cbGiaoHo);
            this.uiGroupBox1.Controls.Add(this.chkLuuTru);
            this.uiGroupBox1.Controls.Add(this.chkNullAccept);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.lblTotal);
            this.uiGroupBox1.Controls.Add(this.btnFilter);
            this.uiGroupBox1.Controls.Add(this.btnPrint);
            this.uiGroupBox1.Controls.Add(this.btnSearch);
            this.uiGroupBox1.Controls.Add(this.rdTanTong);
            this.uiGroupBox1.Controls.Add(this.rdGiaDinh);
            this.uiGroupBox1.Controls.Add(this.rdConSong);
            this.uiGroupBox1.Controls.Add(this.rdQuaDoi);
            this.uiGroupBox1.Controls.Add(this.rdHonPhoi);
            this.uiGroupBox1.Controls.Add(this.rdThemSuc);
            this.uiGroupBox1.Controls.Add(this.rdRuocLe);
            this.uiGroupBox1.Controls.Add(this.rdRuaToi);
            this.uiGroupBox1.Controls.Add(this.rdSinhRa);
            this.uiGroupBox1.Controls.Add(this.dtDateTo);
            this.uiGroupBox1.Controls.Add(this.dtDateFrom);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(770, 214);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Điều kiện thống kê";
            // 
            // cbGiaoHo
            // 
            this.cbGiaoHo.AutoLoadGrid = false;
            this.cbGiaoHo.AutoUpperFirstChar = false;
            this.cbGiaoHo.BoxLeft = 60;
            this.cbGiaoHo.EditEnabled = true;
            this.cbGiaoHo.GridGiaDinh = null;
            this.cbGiaoHo.GridGiaoDan = this.gxGiaoDanList1;
            this.cbGiaoHo.HasShowAll = true;
            this.cbGiaoHo.IsAo = Janus.Windows.GridEX.TriState.Empty;
            this.cbGiaoHo.IsLuuTru = false;
            this.cbGiaoHo.Label = "Giáo họ";
            this.cbGiaoHo.Location = new System.Drawing.Point(27, 48);
            this.cbGiaoHo.MaGiaoHo = -1;
            this.cbGiaoHo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbGiaoHo.Name = "cbGiaoHo";
            this.cbGiaoHo.SelectedValue = null;
            this.cbGiaoHo.ShowNgoaiXu = false;
            this.cbGiaoHo.Size = new System.Drawing.Size(282, 25);
            this.cbGiaoHo.TabIndex = 11;
            this.cbGiaoHo.WhereSQL = "";
            // 
            // chkLuuTru
            // 
            this.chkLuuTru.AutoSize = true;
            this.chkLuuTru.Location = new System.Drawing.Point(49, 149);
            this.chkLuuTru.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkLuuTru.Name = "chkLuuTru";
            this.chkLuuTru.Size = new System.Drawing.Size(152, 17);
            this.chkLuuTru.TabIndex = 10;
            this.chkLuuTru.Text = "Tính cả trong hồ sơ lưu trữ";
            this.chkLuuTru.UseVisualStyleBackColor = true;
            // 
            // chkNullAccept
            // 
            this.chkNullAccept.AutoSize = true;
            this.chkNullAccept.Location = new System.Drawing.Point(245, 149);
            this.chkNullAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkNullAccept.Name = "chkNullAccept";
            this.chkNullAccept.Size = new System.Drawing.Size(235, 17);
            this.chkNullAccept.TabIndex = 10;
            this.chkNullAccept.Text = "Tính cả những dữ liệu không có ngày tháng";
            this.chkNullAccept.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nếu nhập [Từ năm] = [Đến năm] thì xem như chỉ thống kê trong 1 năm";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotal.Location = new System.Drawing.Point(389, 178);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(62, 11);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Tổng cộng:";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter.BackgroundImage")));
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilter.Enabled = false;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(217, 173);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(101, 22);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.Text = "&Lọc lại trên lưới";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Location = new System.Drawing.Point(130, 173);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 22);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "&In danh sách";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(49, 173);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 22);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Thống kê";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdTanTong
            // 
            this.rdTanTong.AutoSize = true;
            this.rdTanTong.Location = new System.Drawing.Point(392, 126);
            this.rdTanTong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdTanTong.Name = "rdTanTong";
            this.rdTanTong.Size = new System.Drawing.Size(201, 17);
            this.rdTanTong.TabIndex = 9;
            this.rdTanTong.TabStop = true;
            this.rdTanTong.Text = "Tân tòng (thống kê theo ngày rửa tội)";
            this.rdTanTong.UseVisualStyleBackColor = true;
            this.rdTanTong.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdGiaDinh
            // 
            this.rdGiaDinh.AutoSize = true;
            this.rdGiaDinh.Location = new System.Drawing.Point(392, 103);
            this.rdGiaDinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdGiaDinh.Name = "rdGiaDinh";
            this.rdGiaDinh.Size = new System.Drawing.Size(263, 17);
            this.rdGiaDinh.TabIndex = 8;
            this.rdGiaDinh.TabStop = true;
            this.rdGiaDinh.Text = "Tổng số gia đình (không phụ thuộc năm thống kê)";
            this.rdGiaDinh.UseVisualStyleBackColor = true;
            this.rdGiaDinh.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdConSong
            // 
            this.rdConSong.AutoSize = true;
            this.rdConSong.Location = new System.Drawing.Point(392, 80);
            this.rdConSong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdConSong.Name = "rdConSong";
            this.rdConSong.Size = new System.Drawing.Size(108, 17);
            this.rdConSong.TabIndex = 8;
            this.rdConSong.TabStop = true;
            this.rdConSong.Text = "Tổng số giáo dân";
            this.rdConSong.UseVisualStyleBackColor = true;
            this.rdConSong.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdQuaDoi
            // 
            this.rdQuaDoi.AutoSize = true;
            this.rdQuaDoi.Location = new System.Drawing.Point(246, 126);
            this.rdQuaDoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdQuaDoi.Name = "rdQuaDoi";
            this.rdQuaDoi.Size = new System.Drawing.Size(63, 17);
            this.rdQuaDoi.TabIndex = 7;
            this.rdQuaDoi.TabStop = true;
            this.rdQuaDoi.Text = "Qua đời";
            this.rdQuaDoi.UseVisualStyleBackColor = true;
            this.rdQuaDoi.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdHonPhoi
            // 
            this.rdHonPhoi.AutoSize = true;
            this.rdHonPhoi.Location = new System.Drawing.Point(246, 103);
            this.rdHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdHonPhoi.Name = "rdHonPhoi";
            this.rdHonPhoi.Size = new System.Drawing.Size(68, 17);
            this.rdHonPhoi.TabIndex = 6;
            this.rdHonPhoi.TabStop = true;
            this.rdHonPhoi.Text = "Hôn phối";
            this.rdHonPhoi.UseVisualStyleBackColor = true;
            this.rdHonPhoi.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdThemSuc
            // 
            this.rdThemSuc.AutoSize = true;
            this.rdThemSuc.Location = new System.Drawing.Point(246, 80);
            this.rdThemSuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdThemSuc.Name = "rdThemSuc";
            this.rdThemSuc.Size = new System.Drawing.Size(72, 17);
            this.rdThemSuc.TabIndex = 5;
            this.rdThemSuc.TabStop = true;
            this.rdThemSuc.Text = "Thêm sức";
            this.rdThemSuc.UseVisualStyleBackColor = true;
            this.rdThemSuc.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdRuocLe
            // 
            this.rdRuocLe.AutoSize = true;
            this.rdRuocLe.Location = new System.Drawing.Point(49, 126);
            this.rdRuocLe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdRuocLe.Name = "rdRuocLe";
            this.rdRuocLe.Size = new System.Drawing.Size(144, 17);
            this.rdRuocLe.TabIndex = 4;
            this.rdRuocLe.TabStop = true;
            this.rdRuocLe.Text = "Xưng tội - rước lễ lần đầu";
            this.rdRuocLe.UseVisualStyleBackColor = true;
            this.rdRuocLe.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdRuaToi
            // 
            this.rdRuaToi.AutoSize = true;
            this.rdRuaToi.Location = new System.Drawing.Point(49, 103);
            this.rdRuaToi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdRuaToi.Name = "rdRuaToi";
            this.rdRuaToi.Size = new System.Drawing.Size(59, 17);
            this.rdRuaToi.TabIndex = 3;
            this.rdRuaToi.TabStop = true;
            this.rdRuaToi.Text = "Rửa tội";
            this.rdRuaToi.UseVisualStyleBackColor = true;
            this.rdRuaToi.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rdSinhRa
            // 
            this.rdSinhRa.AutoSize = true;
            this.rdSinhRa.Location = new System.Drawing.Point(49, 80);
            this.rdSinhRa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdSinhRa.Name = "rdSinhRa";
            this.rdSinhRa.Size = new System.Drawing.Size(58, 17);
            this.rdSinhRa.TabIndex = 2;
            this.rdSinhRa.TabStop = true;
            this.rdSinhRa.Text = "Sinh ra";
            this.rdSinhRa.UseVisualStyleBackColor = true;
            this.rdSinhRa.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // dtDateTo
            // 
            this.dtDateTo.AutoUpperFirstChar = false;
            this.dtDateTo.BoxLeft = 60;
            this.dtDateTo.EditEnabled = true;
            this.dtDateTo.FullInputRequired = false;
            this.dtDateTo.IsNullDate = true;
            this.dtDateTo.Label = "Đến ngày";
            this.dtDateTo.Location = new System.Drawing.Point(207, 20);
            this.dtDateTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(182, 26);
            this.dtDateTo.TabIndex = 1;
            this.dtDateTo.Value = ((object)(resources.GetObject("dtDateTo.Value")));
            this.dtDateTo.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.AutoUpperFirstChar = false;
            this.dtDateFrom.BoxLeft = 60;
            this.dtDateFrom.EditEnabled = true;
            this.dtDateFrom.FullInputRequired = false;
            this.dtDateFrom.IsNullDate = true;
            this.dtDateFrom.Label = "Từ ngày";
            this.dtDateFrom.Location = new System.Drawing.Point(27, 19);
            this.dtDateFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(178, 26);
            this.dtDateFrom.TabIndex = 0;
            this.dtDateFrom.Value = ((object)(resources.GetObject("dtDateFrom.Value")));
            this.dtDateFrom.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.gxHonPhoiList1);
            this.uiGroupBox2.Controls.Add(this.gxGiaDinhList1);
            this.uiGroupBox2.Controls.Add(this.gxGiaoDanList1);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 214);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(770, 310);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "Kết quả thống kê";
            // 
            // gxHonPhoiList1
            // 
            this.gxHonPhoiList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxHonPhoiList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxHonPhoiList1.Arguments = null;
            this.gxHonPhoiList1.AutoLoadGridFormat = true;
            this.gxHonPhoiList1.ColumnAutoResize = true;
            this.gxHonPhoiList1.DisableParentOnLoadData = true;
            this.gxHonPhoiList1.DynamicFiltering = true;
            this.gxHonPhoiList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxHonPhoiList1.GroupByBoxVisible = false;
            this.gxHonPhoiList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxHonPhoiList1.ListMode = 1;
            this.gxHonPhoiList1.Location = new System.Drawing.Point(27, 37);
            this.gxHonPhoiList1.MaGiaoDan = -1;
            this.gxHonPhoiList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gxHonPhoiList1.Name = "gxHonPhoiList1";
            this.gxHonPhoiList1.Phai = "";
            this.gxHonPhoiList1.QueryString = "";
            this.gxHonPhoiList1.RecordNavigator = true;
            this.gxHonPhoiList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxHonPhoiList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gxHonPhoiList1.Size = new System.Drawing.Size(585, 79);
            this.gxHonPhoiList1.TabIndex = 2;
            this.gxHonPhoiList1.Visible = false;
            this.gxHonPhoiList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxHonPhoiList1.WhereSQL = "";
            this.gxHonPhoiList1.LoadDataFinished += new System.EventHandler(this.gxHonPhoiList1_LoadDataFinished);
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
            this.gxGiaDinhList1.DynamicFiltering = true;
            this.gxGiaDinhList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaDinhList1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gxGiaDinhList1.GroupByBoxVisible = false;
            this.gxGiaDinhList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaDinhList1.Location = new System.Drawing.Point(6, 150);
            this.gxGiaDinhList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gxGiaDinhList1.Name = "gxGiaDinhList1";
            this.gxGiaDinhList1.Operation = GxGlobal.GxOperation.EDIT;
            this.gxGiaDinhList1.QueryString = "SELECT * FROM SELECT_GIADINH_LIST WHERE 1 ";
            this.gxGiaDinhList1.RecordNavigator = true;
            this.gxGiaDinhList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaDinhList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaDinhList1.Size = new System.Drawing.Size(719, 152);
            this.gxGiaDinhList1.TabIndex = 1;
            this.gxGiaDinhList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaDinhList1.WhereSQL = "";
            this.gxGiaDinhList1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gxGiaDinhList1_RowDoubleClick);
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
            this.gxGiaoDanList1.DynamicFiltering = true;
            this.gxGiaoDanList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaoDanList1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaoDanList1.GroupByBoxVisible = false;
            this.gxGiaoDanList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaoDanList1.Location = new System.Drawing.Point(3, 17);
            this.gxGiaoDanList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gxGiaoDanList1.Name = "gxGiaoDanList1";
            this.gxGiaoDanList1.QueryString = "";
            this.gxGiaoDanList1.RecordNavigator = true;
            this.gxGiaoDanList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaoDanList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaoDanList1.Size = new System.Drawing.Size(705, 121);
            this.gxGiaoDanList1.TabIndex = 0;
            this.gxGiaoDanList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaoDanList1.WhereSQL = "";
            // 
            // GxThongKeChung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GxThongKeChung";
            this.Size = new System.Drawing.Size(770, 524);
            this.Load += new System.EventHandler(this.frmThongKeChung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxHonPhoiList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxDateField dtDateFrom;
        private GxControl.GxRadioBox rdThemSuc;
        private GxControl.GxRadioBox rdRuocLe;
        private GxControl.GxRadioBox rdRuaToi;
        private GxControl.GxRadioBox rdSinhRa;
        private GxControl.GxRadioBox rdHonPhoi;
        private GxControl.GxButton btnSearch;
        private GxControl.GxRadioBox rdQuaDoi;
        private GxControl.GxGiaoDanList gxGiaoDanList1;
        private GxControl.GxGiaDinhList gxGiaDinhList1;
        private System.Windows.Forms.Label lblTotal;
        private GxControl.GxRadioBox rdConSong;
        private GxControl.GxDateField dtDateTo;
        private System.Windows.Forms.Label label1;
        private GxControl.GxRadioBox rdGiaDinh;
        private GxControl.GxButton btnPrint;
        private GxControl.GxCheckBox chkNullAccept;
        private GxControl.GxCheckBox chkLuuTru;
        protected GxControl.GxGiaoHo cbGiaoHo;
        private GxControl.GxRadioBox rdTanTong;
        private GxControl.GxButton btnFilter;
        private GxControl.GxHonPhoiList gxHonPhoiList1;
    }
}