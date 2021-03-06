namespace GxControl
{
    partial class GxHonPhoi
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
            this.gxHonPhoiList1 = new GxControl.GxHonPhoiList();
            this.uiGroupBox3 = new GxControl.GxGroupBox();
            this.gxAddEdit1 = new GxControl.GxAddEdit();
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNguoiVo = new GxControl.GxGiaoDan();
            this.txtNguoiChong = new GxControl.GxGiaoDan();
            this.txtMaHonPhoi = new GxControl.GxTextField();
            this.cbCachThuc = new GxControl.GxCachThucHonPhoi();
            this.txtLinhMuc = new GxControl.GxLinhMuc();
            this.txtNguoiChung2 = new GxControl.GxTextField();
            this.txtNguoiChung1 = new GxControl.GxTextField();
            this.dtNgayHonPhoi = new GxControl.GxDateField();
            this.txtNoiHonPhoi = new GxControl.GxTextField();
            this.txtSoHonPhoi = new GxControl.GxTextField();
            this.txtSoThuTu = new GxControl.GxTextField();
            this.txtTenHonPhoi = new GxControl.GxTextField();
            this.txtGhiChu = new GxControl.GxTextField();
            ((System.ComponentModel.ISupportInitialize)(this.gxHonPhoiList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gxHonPhoiList1
            // 
            this.gxHonPhoiList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxHonPhoiList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxHonPhoiList1.Arguments = null;
            this.gxHonPhoiList1.AutoLoadGridFormat = true;
            this.gxHonPhoiList1.ColumnAutoResize = true;
            this.gxHonPhoiList1.DisableParentOnLoadData = true;
            this.gxHonPhoiList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxHonPhoiList1.DynamicFiltering = true;
            this.gxHonPhoiList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxHonPhoiList1.GroupByBoxVisible = false;
            this.gxHonPhoiList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxHonPhoiList1.ListMode = 1;
            this.gxHonPhoiList1.Location = new System.Drawing.Point(0, 313);
            this.gxHonPhoiList1.MaGiaoDan = -1;
            this.gxHonPhoiList1.Name = "gxHonPhoiList1";
            this.gxHonPhoiList1.Phai = "";
            this.gxHonPhoiList1.QueryString = "";
            this.gxHonPhoiList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxHonPhoiList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gxHonPhoiList1.Size = new System.Drawing.Size(760, 144);
            this.gxHonPhoiList1.TabIndex = 4;
            this.gxHonPhoiList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxHonPhoiList1.WhereSQL = "";
            this.gxHonPhoiList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gxHonPhoiList1_MouseClick);
            this.gxHonPhoiList1.SelectionChanged += new System.EventHandler(this.gxHonPhoiList1_SelectionChanged);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground;
            this.uiGroupBox3.Controls.Add(this.gxAddEdit1);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox3.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox3.Location = new System.Drawing.Point(0, 280);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(760, 33);
            this.uiGroupBox3.TabIndex = 3;
            // 
            // gxAddEdit1
            // 
            this.gxAddEdit1.BackColor = System.Drawing.Color.Transparent;
            this.gxAddEdit1.CaptionDisplayMode = GxGlobal.CaptionDisplayMode.Full;
            this.gxAddEdit1.DisplayMode = GxGlobal.DisplayMode.Mode3;
            this.gxAddEdit1.GridData = null;
            this.gxAddEdit1.Location = new System.Drawing.Point(5, 3);
            this.gxAddEdit1.Name = "gxAddEdit1";
            this.gxAddEdit1.Size = new System.Drawing.Size(213, 29);
            this.gxAddEdit1.TabIndex = 12;
            this.gxAddEdit1.ToolTipAdd = "Thêm gia đình";
            this.gxAddEdit1.ToolTipButton1 = "";
            this.gxAddEdit1.ToolTipButton2 = "";
            this.gxAddEdit1.ToolTipDelete = "Loại bỏ hôn phối được chọn khỏi danh sách hôn phối của người này";
            this.gxAddEdit1.ToolTipEdit = "Sửa hôn phối được chọn";
            this.gxAddEdit1.ToolTipFind = "";
            this.gxAddEdit1.ToolTipPrint = "";
            this.gxAddEdit1.ToolTipReload = "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
                "ếm";
            this.gxAddEdit1.ToolTipSelect = "In danh sách hôn phối trong lưới hiện tại";
            this.gxAddEdit1.DeleteClick += new System.EventHandler(this.gxAddEdit1_DeleteClick);
            this.gxAddEdit1.EditClick += new System.EventHandler(this.gxAddEdit1_EditClick);
            this.gxAddEdit1.AddClick += new System.EventHandler(this.gxAddEdit1_AddClick);
            this.gxAddEdit1.SelectClick += new System.EventHandler(this.gxAddEdit1_UpdateClick);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.tableLayoutPanel1);
            this.uiGroupBox1.Controls.Add(this.txtGhiChu);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(760, 280);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin đôi hôn phối";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtNguoiVo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNguoiChong, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMaHonPhoi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbCachThuc, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtLinhMuc, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNguoiChung2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNguoiChung1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtNgayHonPhoi, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtNoiHonPhoi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSoHonPhoi, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSoThuTu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTenHonPhoi, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 188);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // txtNguoiVo
            // 
            this.txtNguoiVo.AutoCompleteEnabled = true;
            this.txtNguoiVo.AutoUpperFirstChar = true;
            this.txtNguoiVo.BoxLeft = 80;
            this.txtNguoiVo.CurrentRow = null;
            this.txtNguoiVo.DisplayMode = GxGlobal.DisplayMode.Full;
            this.txtNguoiVo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNguoiVo.EditEnabled = true;
            this.txtNguoiVo.Label = "Người nữ";
            this.txtNguoiVo.Location = new System.Drawing.Point(3, 65);
            this.txtNguoiVo.MaGiaoDan = -1;
            this.txtNguoiVo.MaGiaoHo = -1;
            this.txtNguoiVo.MaxLength = 255;
            this.txtNguoiVo.MultiLine = false;
            this.txtNguoiVo.Name = "txtNguoiVo";
            this.txtNguoiVo.NumberInputRequired = true;
            this.txtNguoiVo.NumberMode = false;
            this.txtNguoiVo.ReadOnly = true;
            this.txtNguoiVo.Size = new System.Drawing.Size(371, 25);
            this.txtNguoiVo.TabIndex = 2;
            this.txtNguoiVo.WhereSQL = "";
            this.txtNguoiVo.OnSelecting += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiVo_OnSelecting);
            this.txtNguoiVo.OnAdding += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiVo_OnSelecting);
            this.txtNguoiVo.OnEditing += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiVo_OnSelecting);
            // 
            // txtNguoiChong
            // 
            this.txtNguoiChong.AutoCompleteEnabled = true;
            this.txtNguoiChong.AutoUpperFirstChar = true;
            this.txtNguoiChong.BoxLeft = 80;
            this.txtNguoiChong.CurrentRow = null;
            this.txtNguoiChong.DisplayMode = GxGlobal.DisplayMode.Full;
            this.txtNguoiChong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNguoiChong.EditEnabled = true;
            this.txtNguoiChong.Label = "Người nam";
            this.txtNguoiChong.Location = new System.Drawing.Point(3, 34);
            this.txtNguoiChong.MaGiaoDan = -1;
            this.txtNguoiChong.MaGiaoHo = -1;
            this.txtNguoiChong.MaxLength = 255;
            this.txtNguoiChong.MultiLine = false;
            this.txtNguoiChong.Name = "txtNguoiChong";
            this.txtNguoiChong.NumberInputRequired = true;
            this.txtNguoiChong.NumberMode = false;
            this.txtNguoiChong.ReadOnly = true;
            this.txtNguoiChong.Size = new System.Drawing.Size(371, 25);
            this.txtNguoiChong.TabIndex = 1;
            this.txtNguoiChong.WhereSQL = "";
            this.txtNguoiChong.OnSelecting += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiChong_OnSelecting);
            this.txtNguoiChong.OnAdding += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiChong_OnSelecting);
            this.txtNguoiChong.OnEditing += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiChong_OnSelecting);
            // 
            // txtMaHonPhoi
            // 
            this.txtMaHonPhoi.AutoCompleteEnabled = false;
            this.txtMaHonPhoi.AutoUpperFirstChar = false;
            this.txtMaHonPhoi.BoxLeft = 100;
            this.txtMaHonPhoi.EditEnabled = false;
            this.txtMaHonPhoi.Label = "Mã hôn phối";
            this.txtMaHonPhoi.Location = new System.Drawing.Point(380, 3);
            this.txtMaHonPhoi.MaxLength = 9;
            this.txtMaHonPhoi.MultiLine = false;
            this.txtMaHonPhoi.Name = "txtMaHonPhoi";
            this.txtMaHonPhoi.NumberInputRequired = true;
            this.txtMaHonPhoi.NumberMode = false;
            this.txtMaHonPhoi.ReadOnly = false;
            this.txtMaHonPhoi.Size = new System.Drawing.Size(167, 25);
            this.txtMaHonPhoi.TabIndex = 0;
            this.txtMaHonPhoi.Visible = false;
            // 
            // cbCachThuc
            // 
            this.cbCachThuc.AutoUpperFirstChar = true;
            this.cbCachThuc.BoxLeft = 100;
            this.cbCachThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCachThuc.EditEnabled = true;
            this.cbCachThuc.Label = "Tình trạng hôn phối";
            this.cbCachThuc.Location = new System.Drawing.Point(380, 158);
            this.cbCachThuc.MaxLength = 0;
            this.cbCachThuc.Name = "cbCachThuc";
            this.cbCachThuc.SelectedIndex = 0;
            this.cbCachThuc.SelectedText = "";
            this.cbCachThuc.SelectedValue = null;
            this.cbCachThuc.Size = new System.Drawing.Size(371, 27);
            this.cbCachThuc.TabIndex = 10;
            // 
            // txtLinhMuc
            // 
            this.txtLinhMuc.AutoCompleteEnabled = true;
            this.txtLinhMuc.AutoLoadData = true;
            this.txtLinhMuc.AutoUpperFirstChar = true;
            this.txtLinhMuc.BoxLeft = 100;
            this.txtLinhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLinhMuc.EditEnabled = true;
            this.txtLinhMuc.Label = "Linh mục chứng";
            this.txtLinhMuc.Location = new System.Drawing.Point(380, 65);
            this.txtLinhMuc.MaxLength = 255;
            this.txtLinhMuc.MultiLine = false;
            this.txtLinhMuc.Name = "txtLinhMuc";
            this.txtLinhMuc.NumberInputRequired = true;
            this.txtLinhMuc.NumberMode = false;
            this.txtLinhMuc.ReadOnly = false;
            this.txtLinhMuc.Size = new System.Drawing.Size(371, 25);
            this.txtLinhMuc.TabIndex = 7;
            // 
            // txtNguoiChung2
            // 
            this.txtNguoiChung2.AutoCompleteEnabled = true;
            this.txtNguoiChung2.AutoUpperFirstChar = true;
            this.txtNguoiChung2.BoxLeft = 100;
            this.txtNguoiChung2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNguoiChung2.EditEnabled = true;
            this.txtNguoiChung2.Label = "Người chứng 2";
            this.txtNguoiChung2.Location = new System.Drawing.Point(380, 127);
            this.txtNguoiChung2.MaxLength = 255;
            this.txtNguoiChung2.MultiLine = false;
            this.txtNguoiChung2.Name = "txtNguoiChung2";
            this.txtNguoiChung2.NumberInputRequired = true;
            this.txtNguoiChung2.NumberMode = false;
            this.txtNguoiChung2.ReadOnly = false;
            this.txtNguoiChung2.Size = new System.Drawing.Size(371, 25);
            this.txtNguoiChung2.TabIndex = 9;
            // 
            // txtNguoiChung1
            // 
            this.txtNguoiChung1.AutoCompleteEnabled = true;
            this.txtNguoiChung1.AutoUpperFirstChar = true;
            this.txtNguoiChung1.BoxLeft = 100;
            this.txtNguoiChung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNguoiChung1.EditEnabled = true;
            this.txtNguoiChung1.Label = "Người chứng 1";
            this.txtNguoiChung1.Location = new System.Drawing.Point(380, 96);
            this.txtNguoiChung1.MaxLength = 255;
            this.txtNguoiChung1.MultiLine = false;
            this.txtNguoiChung1.Name = "txtNguoiChung1";
            this.txtNguoiChung1.NumberInputRequired = true;
            this.txtNguoiChung1.NumberMode = false;
            this.txtNguoiChung1.ReadOnly = false;
            this.txtNguoiChung1.Size = new System.Drawing.Size(371, 25);
            this.txtNguoiChung1.TabIndex = 8;
            // 
            // dtNgayHonPhoi
            // 
            this.dtNgayHonPhoi.AutoUpperFirstChar = false;
            this.dtNgayHonPhoi.BoxLeft = 80;
            this.dtNgayHonPhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNgayHonPhoi.EditEnabled = true;
            this.dtNgayHonPhoi.FullInputRequired = false;
            this.dtNgayHonPhoi.IsNullDate = false;
            this.dtNgayHonPhoi.Label = "Ngày hôn phối";
            this.dtNgayHonPhoi.Location = new System.Drawing.Point(3, 158);
            this.dtNgayHonPhoi.Name = "dtNgayHonPhoi";
            this.dtNgayHonPhoi.Size = new System.Drawing.Size(371, 26);
            this.dtNgayHonPhoi.TabIndex = 5;
            this.dtNgayHonPhoi.Value = "06/04/2009";
            // 
            // txtNoiHonPhoi
            // 
            this.txtNoiHonPhoi.AutoCompleteEnabled = true;
            this.txtNoiHonPhoi.AutoUpperFirstChar = true;
            this.txtNoiHonPhoi.BoxLeft = 100;
            this.txtNoiHonPhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiHonPhoi.EditEnabled = true;
            this.txtNoiHonPhoi.Label = "Nơi hôn phối";
            this.txtNoiHonPhoi.Location = new System.Drawing.Point(380, 34);
            this.txtNoiHonPhoi.MaxLength = 255;
            this.txtNoiHonPhoi.MultiLine = false;
            this.txtNoiHonPhoi.Name = "txtNoiHonPhoi";
            this.txtNoiHonPhoi.NumberInputRequired = true;
            this.txtNoiHonPhoi.NumberMode = false;
            this.txtNoiHonPhoi.ReadOnly = false;
            this.txtNoiHonPhoi.Size = new System.Drawing.Size(371, 25);
            this.txtNoiHonPhoi.TabIndex = 6;
            // 
            // txtSoHonPhoi
            // 
            this.txtSoHonPhoi.AutoCompleteEnabled = false;
            this.txtSoHonPhoi.AutoUpperFirstChar = false;
            this.txtSoHonPhoi.BoxLeft = 80;
            this.txtSoHonPhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoHonPhoi.EditEnabled = true;
            this.txtSoHonPhoi.Label = "Số hôn phối";
            this.txtSoHonPhoi.Location = new System.Drawing.Point(3, 127);
            this.txtSoHonPhoi.MaxLength = 255;
            this.txtSoHonPhoi.MultiLine = false;
            this.txtSoHonPhoi.Name = "txtSoHonPhoi";
            this.txtSoHonPhoi.NumberInputRequired = true;
            this.txtSoHonPhoi.NumberMode = false;
            this.txtSoHonPhoi.ReadOnly = false;
            this.txtSoHonPhoi.Size = new System.Drawing.Size(371, 25);
            this.txtSoHonPhoi.TabIndex = 4;
            // 
            // txtSoThuTu
            // 
            this.txtSoThuTu.AutoCompleteEnabled = false;
            this.txtSoThuTu.AutoUpperFirstChar = true;
            this.txtSoThuTu.BoxLeft = 80;
            this.txtSoThuTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoThuTu.EditEnabled = true;
            this.txtSoThuTu.Label = "Số thứ tự";
            this.txtSoThuTu.Location = new System.Drawing.Point(3, 3);
            this.txtSoThuTu.MaxLength = 255;
            this.txtSoThuTu.MultiLine = false;
            this.txtSoThuTu.Name = "txtSoThuTu";
            this.txtSoThuTu.NumberInputRequired = true;
            this.txtSoThuTu.NumberMode = true;
            this.txtSoThuTu.ReadOnly = false;
            this.txtSoThuTu.Size = new System.Drawing.Size(371, 25);
            this.txtSoThuTu.TabIndex = 0;
            this.txtSoThuTu.Load += new System.EventHandler(this.txtSoThuTu_Load);
            // 
            // txtTenHonPhoi
            // 
            this.txtTenHonPhoi.AutoCompleteEnabled = true;
            this.txtTenHonPhoi.AutoUpperFirstChar = true;
            this.txtTenHonPhoi.BoxLeft = 80;
            this.txtTenHonPhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenHonPhoi.EditEnabled = true;
            this.txtTenHonPhoi.Label = "Đôi hôn phối";
            this.txtTenHonPhoi.Location = new System.Drawing.Point(3, 96);
            this.txtTenHonPhoi.MaxLength = 255;
            this.txtTenHonPhoi.MultiLine = false;
            this.txtTenHonPhoi.Name = "txtTenHonPhoi";
            this.txtTenHonPhoi.NumberInputRequired = true;
            this.txtTenHonPhoi.NumberMode = false;
            this.txtTenHonPhoi.ReadOnly = false;
            this.txtTenHonPhoi.Size = new System.Drawing.Size(371, 25);
            this.txtTenHonPhoi.TabIndex = 3;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AutoCompleteEnabled = true;
            this.txtGhiChu.AutoUpperFirstChar = false;
            this.txtGhiChu.BoxLeft = 80;
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtGhiChu.EditEnabled = true;
            this.txtGhiChu.Label = "Ghi chú";
            this.txtGhiChu.Location = new System.Drawing.Point(3, 204);
            this.txtGhiChu.MaxLength = 32767;
            this.txtGhiChu.MultiLine = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.NumberInputRequired = true;
            this.txtGhiChu.NumberMode = false;
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.Size = new System.Drawing.Size(754, 73);
            this.txtGhiChu.TabIndex = 11;
            // 
            // GxHonPhoi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gxHonPhoiList1);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "GxHonPhoi";
            this.Size = new System.Drawing.Size(760, 457);
            this.Load += new System.EventHandler(this.GxHonPhoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gxHonPhoiList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private GxControl.GxGiaoDan txtNguoiChong;
        private GxControl.GxTextField txtSoHonPhoi;
        private GxControl.GxGiaoDan txtNguoiVo;
        private GxControl.GxTextField txtNoiHonPhoi;
        private GxControl.GxTextField txtNguoiChung1;
        private GxControl.GxTextField txtNguoiChung2;
        private GxControl.GxTextField txtGhiChu;
        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxTextField txtMaHonPhoi;
        private GxControl.GxLinhMuc txtLinhMuc;
        private GxControl.GxTextField txtTenHonPhoi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GxCachThucHonPhoi cbCachThuc;
        private GxDateField dtNgayHonPhoi;
        protected GxGroupBox uiGroupBox3;
        protected GxAddEdit gxAddEdit1;
        private GxHonPhoiList gxHonPhoiList1;
        private GxTextField txtSoThuTu;

    }
}

