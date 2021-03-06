namespace GxControl
{
    partial class frmHonPhoi
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
            this.txtNguoiChong = new GxControl.GxGiaoDan();
            this.txtSoHonPhoi = new GxControl.GxTextField();
            this.txtNguoiVo = new GxControl.GxGiaoDan();
            this.txtNoiHonPhoi = new GxControl.GxTextField();
            this.dtNgayHonPhoi = new GxControl.GxDateField();
            this.txtNguoiChung1 = new GxControl.GxTextField();
            this.txtNguoiChung2 = new GxControl.GxTextField();
            this.cbCachThuc = new GxControl.GxComboField();
            this.txtGhiChu = new GxControl.GxTextField();
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.txtTenHonPhoi = new GxControl.GxTextField();
            this.txtLinhMuc = new GxControl.GxLinhMuc();
            this.txtMaHonPhoi = new GxControl.GxTextField();
            this.gxCommand1 = new GxControl.GxCommand();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNguoiChong
            // 
            this.txtNguoiChong.AutoCompleteEnabled = true;
            this.txtNguoiChong.AutoUpperFirstChar = true;
            this.txtNguoiChong.BoxLeft = 80;
            this.txtNguoiChong.CurrentRow = null;
            this.txtNguoiChong.DisplayMode = GxGlobal.DisplayMode.Full;
            this.txtNguoiChong.EditEnabled = true;
            this.txtNguoiChong.Label = "Người nam";
            this.txtNguoiChong.Location = new System.Drawing.Point(6, 54);
            this.txtNguoiChong.MaGiaoDan = -1;
            this.txtNguoiChong.MaGiaoHo = -1;
            this.txtNguoiChong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiChong.MaxLength = 255;
            this.txtNguoiChong.MultiLine = false;
            this.txtNguoiChong.Name = "txtNguoiChong";
            this.txtNguoiChong.NumberInputRequired = true;
            this.txtNguoiChong.NumberMode = false;
            this.txtNguoiChong.ReadOnly = true;
            this.txtNguoiChong.Size = new System.Drawing.Size(374, 26);
            this.txtNguoiChong.TabIndex = 0;
            this.txtNguoiChong.WhereSQL = "";
            this.txtNguoiChong.OnSelecting += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiChong_OnSelecting);
            this.txtNguoiChong.OnAdding += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiChong_OnSelecting);
            this.txtNguoiChong.OnEditing += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiChong_OnSelecting);
            // 
            // txtSoHonPhoi
            // 
            this.txtSoHonPhoi.AutoCompleteEnabled = true;
            this.txtSoHonPhoi.AutoUpperFirstChar = false;
            this.txtSoHonPhoi.BoxLeft = 80;
            this.txtSoHonPhoi.EditEnabled = true;
            this.txtSoHonPhoi.Label = "Số hôn phối";
            this.txtSoHonPhoi.Location = new System.Drawing.Point(6, 159);
            this.txtSoHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoHonPhoi.MaxLength = 255;
            this.txtSoHonPhoi.MultiLine = false;
            this.txtSoHonPhoi.Name = "txtSoHonPhoi";
            this.txtSoHonPhoi.NumberInputRequired = true;
            this.txtSoHonPhoi.NumberMode = false;
            this.txtSoHonPhoi.ReadOnly = false;
            this.txtSoHonPhoi.Size = new System.Drawing.Size(178, 25);
            this.txtSoHonPhoi.TabIndex = 3;
            // 
            // txtNguoiVo
            // 
            this.txtNguoiVo.AutoCompleteEnabled = true;
            this.txtNguoiVo.AutoUpperFirstChar = true;
            this.txtNguoiVo.BoxLeft = 80;
            this.txtNguoiVo.CurrentRow = null;
            this.txtNguoiVo.DisplayMode = GxGlobal.DisplayMode.Full;
            this.txtNguoiVo.EditEnabled = true;
            this.txtNguoiVo.Label = "Người nữ";
            this.txtNguoiVo.Location = new System.Drawing.Point(6, 90);
            this.txtNguoiVo.MaGiaoDan = -1;
            this.txtNguoiVo.MaGiaoHo = -1;
            this.txtNguoiVo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiVo.MaxLength = 255;
            this.txtNguoiVo.MultiLine = false;
            this.txtNguoiVo.Name = "txtNguoiVo";
            this.txtNguoiVo.NumberInputRequired = true;
            this.txtNguoiVo.NumberMode = false;
            this.txtNguoiVo.ReadOnly = true;
            this.txtNguoiVo.Size = new System.Drawing.Size(374, 26);
            this.txtNguoiVo.TabIndex = 1;
            this.txtNguoiVo.WhereSQL = "";
            this.txtNguoiVo.OnSelecting += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiVo_OnSelecting);
            this.txtNguoiVo.OnAdding += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiVo_OnSelecting);
            this.txtNguoiVo.OnEditing += new GxControl.GxGiaoDan.SelectingHandler(this.txtNguoiVo_OnSelecting);
            // 
            // txtNoiHonPhoi
            // 
            this.txtNoiHonPhoi.AutoCompleteEnabled = true;
            this.txtNoiHonPhoi.AutoUpperFirstChar = true;
            this.txtNoiHonPhoi.BoxLeft = 100;
            this.txtNoiHonPhoi.EditEnabled = true;
            this.txtNoiHonPhoi.Label = "Nơi hôn phối";
            this.txtNoiHonPhoi.Location = new System.Drawing.Point(383, 52);
            this.txtNoiHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoiHonPhoi.MaxLength = 255;
            this.txtNoiHonPhoi.MultiLine = false;
            this.txtNoiHonPhoi.Name = "txtNoiHonPhoi";
            this.txtNoiHonPhoi.NumberInputRequired = true;
            this.txtNoiHonPhoi.NumberMode = false;
            this.txtNoiHonPhoi.ReadOnly = false;
            this.txtNoiHonPhoi.Size = new System.Drawing.Size(349, 25);
            this.txtNoiHonPhoi.TabIndex = 6;
            // 
            // dtNgayHonPhoi
            // 
            this.dtNgayHonPhoi.AutoUpperFirstChar = false;
            this.dtNgayHonPhoi.BoxLeft = 80;
            this.dtNgayHonPhoi.EditEnabled = true;
            this.dtNgayHonPhoi.FullInputRequired = false;
            this.dtNgayHonPhoi.IsNullDate = false;
            this.dtNgayHonPhoi.Label = "Ngày hôn phối";
            this.dtNgayHonPhoi.Location = new System.Drawing.Point(6, 190);
            this.dtNgayHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtNgayHonPhoi.Name = "dtNgayHonPhoi";
            this.dtNgayHonPhoi.Size = new System.Drawing.Size(180, 26);
            this.dtNgayHonPhoi.TabIndex = 4;
            this.dtNgayHonPhoi.Value = "06/04/2009";
            // 
            // txtNguoiChung1
            // 
            this.txtNguoiChung1.AutoCompleteEnabled = true;
            this.txtNguoiChung1.AutoUpperFirstChar = true;
            this.txtNguoiChung1.BoxLeft = 100;
            this.txtNguoiChung1.EditEnabled = true;
            this.txtNguoiChung1.Label = "Người chứng 1";
            this.txtNguoiChung1.Location = new System.Drawing.Point(383, 122);
            this.txtNguoiChung1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiChung1.MaxLength = 255;
            this.txtNguoiChung1.MultiLine = false;
            this.txtNguoiChung1.Name = "txtNguoiChung1";
            this.txtNguoiChung1.NumberInputRequired = true;
            this.txtNguoiChung1.NumberMode = false;
            this.txtNguoiChung1.ReadOnly = false;
            this.txtNguoiChung1.Size = new System.Drawing.Size(349, 25);
            this.txtNguoiChung1.TabIndex = 8;
            // 
            // txtNguoiChung2
            // 
            this.txtNguoiChung2.AutoCompleteEnabled = true;
            this.txtNguoiChung2.AutoUpperFirstChar = true;
            this.txtNguoiChung2.BoxLeft = 100;
            this.txtNguoiChung2.EditEnabled = true;
            this.txtNguoiChung2.Label = "Người chứng 2";
            this.txtNguoiChung2.Location = new System.Drawing.Point(383, 153);
            this.txtNguoiChung2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiChung2.MaxLength = 255;
            this.txtNguoiChung2.MultiLine = false;
            this.txtNguoiChung2.Name = "txtNguoiChung2";
            this.txtNguoiChung2.NumberInputRequired = true;
            this.txtNguoiChung2.NumberMode = false;
            this.txtNguoiChung2.ReadOnly = false;
            this.txtNguoiChung2.Size = new System.Drawing.Size(349, 25);
            this.txtNguoiChung2.TabIndex = 9;
            // 
            // cbCachThuc
            // 
            this.cbCachThuc.AutoUpperFirstChar = true;
            this.cbCachThuc.BoxLeft = 100;
            this.cbCachThuc.EditEnabled = true;
            this.cbCachThuc.Label = "Tình trạng hôn phối";
            this.cbCachThuc.Location = new System.Drawing.Point(383, 184);
            this.cbCachThuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCachThuc.MaxLength = 0;
            this.cbCachThuc.Name = "cbCachThuc";
            this.cbCachThuc.SelectedIndex = -1;
            this.cbCachThuc.SelectedText = "";
            this.cbCachThuc.SelectedValue = null;
            this.cbCachThuc.Size = new System.Drawing.Size(349, 26);
            this.cbCachThuc.TabIndex = 10;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AutoCompleteEnabled = true;
            this.txtGhiChu.AutoUpperFirstChar = false;
            this.txtGhiChu.BoxLeft = 80;
            this.txtGhiChu.EditEnabled = true;
            this.txtGhiChu.Label = "Ghi chú";
            this.txtGhiChu.Location = new System.Drawing.Point(6, 222);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.MaxLength = 32767;
            this.txtGhiChu.MultiLine = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.NumberInputRequired = true;
            this.txtGhiChu.NumberMode = false;
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.Size = new System.Drawing.Size(725, 73);
            this.txtGhiChu.TabIndex = 14;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtTenHonPhoi);
            this.uiGroupBox1.Controls.Add(this.txtLinhMuc);
            this.uiGroupBox1.Controls.Add(this.txtMaHonPhoi);
            this.uiGroupBox1.Controls.Add(this.cbCachThuc);
            this.uiGroupBox1.Controls.Add(this.txtNguoiChong);
            this.uiGroupBox1.Controls.Add(this.dtNgayHonPhoi);
            this.uiGroupBox1.Controls.Add(this.txtNguoiVo);
            this.uiGroupBox1.Controls.Add(this.txtGhiChu);
            this.uiGroupBox1.Controls.Add(this.txtSoHonPhoi);
            this.uiGroupBox1.Controls.Add(this.txtNguoiChung2);
            this.uiGroupBox1.Controls.Add(this.txtNoiHonPhoi);
            this.uiGroupBox1.Controls.Add(this.txtNguoiChung1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(739, 325);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin đôi hôn phối";
            // 
            // txtTenHonPhoi
            // 
            this.txtTenHonPhoi.AutoCompleteEnabled = true;
            this.txtTenHonPhoi.AutoUpperFirstChar = true;
            this.txtTenHonPhoi.BoxLeft = 80;
            this.txtTenHonPhoi.EditEnabled = true;
            this.txtTenHonPhoi.Label = "Đôi hôn phối";
            this.txtTenHonPhoi.Location = new System.Drawing.Point(6, 126);
            this.txtTenHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenHonPhoi.MaxLength = 255;
            this.txtTenHonPhoi.MultiLine = false;
            this.txtTenHonPhoi.Name = "txtTenHonPhoi";
            this.txtTenHonPhoi.NumberInputRequired = true;
            this.txtTenHonPhoi.NumberMode = false;
            this.txtTenHonPhoi.ReadOnly = false;
            this.txtTenHonPhoi.Size = new System.Drawing.Size(374, 25);
            this.txtTenHonPhoi.TabIndex = 15;
            // 
            // txtLinhMuc
            // 
            this.txtLinhMuc.AutoCompleteEnabled = true;
            this.txtLinhMuc.AutoLoadData = true;
            this.txtLinhMuc.AutoUpperFirstChar = true;
            this.txtLinhMuc.BoxLeft = 100;
            this.txtLinhMuc.EditEnabled = true;
            this.txtLinhMuc.Label = "Linh mục chứng";
            this.txtLinhMuc.Location = new System.Drawing.Point(383, 87);
            this.txtLinhMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLinhMuc.MaxLength = 255;
            this.txtLinhMuc.MultiLine = false;
            this.txtLinhMuc.Name = "txtLinhMuc";
            this.txtLinhMuc.NumberInputRequired = true;
            this.txtLinhMuc.NumberMode = false;
            this.txtLinhMuc.ReadOnly = false;
            this.txtLinhMuc.Size = new System.Drawing.Size(349, 27);
            this.txtLinhMuc.TabIndex = 7;
            // 
            // txtMaHonPhoi
            // 
            this.txtMaHonPhoi.AutoCompleteEnabled = true;
            this.txtMaHonPhoi.AutoUpperFirstChar = false;
            this.txtMaHonPhoi.BoxLeft = 80;
            this.txtMaHonPhoi.EditEnabled = false;
            this.txtMaHonPhoi.Label = "Mã hôn phối";
            this.txtMaHonPhoi.Location = new System.Drawing.Point(6, 23);
            this.txtMaHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaHonPhoi.MaxLength = 9;
            this.txtMaHonPhoi.MultiLine = false;
            this.txtMaHonPhoi.Name = "txtMaHonPhoi";
            this.txtMaHonPhoi.NumberInputRequired = true;
            this.txtMaHonPhoi.NumberMode = false;
            this.txtMaHonPhoi.ReadOnly = false;
            this.txtMaHonPhoi.Size = new System.Drawing.Size(178, 25);
            this.txtMaHonPhoi.TabIndex = 0;
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 325);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(739, 45);
            this.gxCommand1.TabIndex = 2;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "";
            this.gxCommand1.ToolTipOK = "";
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            this.gxCommand1.OnCancel += new System.EventHandler(this.gxCommand1_OnCancel);
            this.gxCommand1.Button1Click += new System.EventHandler(this.gxCommand1_Button1Click);
            // 
            // frmHonPhoi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(739, 370);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.gxCommand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmHonPhoi";
            this.Text = "Nhập đôi hôn phối";
            this.Load += new System.EventHandler(this.frmHonPhoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private GxControl.GxGiaoDan txtNguoiChong;
        private GxControl.GxTextField txtSoHonPhoi;
        private GxControl.GxGiaoDan txtNguoiVo;
        private GxControl.GxTextField txtNoiHonPhoi;
        private GxControl.GxDateField dtNgayHonPhoi;
        private GxControl.GxTextField txtNguoiChung1;
        private GxControl.GxTextField txtNguoiChung2;
        private GxControl.GxComboField cbCachThuc;
        private GxControl.GxTextField txtGhiChu;
        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxCommand gxCommand1;
        private GxControl.GxTextField txtMaHonPhoi;
        private GxControl.GxLinhMuc txtLinhMuc;
        private GxControl.GxTextField txtTenHonPhoi;
    }
}

