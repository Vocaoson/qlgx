namespace GiaoLy
{
    partial class frmHocSinh
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
            this.txtGhiChu = new GxControl.GxTextField();
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.txtHoTen = new GxControl.GxTextField();
            this.gxCommand1 = new GxControl.GxCommand();
            this.txtTenThanh = new GxControl.GxTextField();
            this.txtNgaySinh = new GxControl.GxTextField();
            this.txtPhai = new GxControl.GxTextField();
            this.rabDa = new Janus.Windows.EditControls.UIRadioButton();
            this.lblHoanThanh = new System.Windows.Forms.Label();
            this.rabChua = new Janus.Windows.EditControls.UIRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AutoCompleteEnabled = true;
            this.txtGhiChu.AutoUpperFirstChar = false;
            this.txtGhiChu.BoxLeft = 80;
            this.txtGhiChu.EditEnabled = true;
            this.txtGhiChu.Label = "Ghi chú";
            this.txtGhiChu.Location = new System.Drawing.Point(33, 162);
            this.txtGhiChu.MaxLength = 32767;
            this.txtGhiChu.MultiLine = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.NumberInputRequired = true;
            this.txtGhiChu.NumberMode = false;
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.Size = new System.Drawing.Size(824, 58);
            this.txtGhiChu.TabIndex = 14;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.rabDa);
            this.uiGroupBox1.Controls.Add(this.lblHoanThanh);
            this.uiGroupBox1.Controls.Add(this.rabChua);
            this.uiGroupBox1.Controls.Add(this.txtPhai);
            this.uiGroupBox1.Controls.Add(this.txtNgaySinh);
            this.uiGroupBox1.Controls.Add(this.txtTenThanh);
            this.uiGroupBox1.Controls.Add(this.txtHoTen);
            this.uiGroupBox1.Controls.Add(this.txtGhiChu);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(863, 226);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin khối giáo lý";
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoCompleteEnabled = true;
            this.txtHoTen.AutoUpperFirstChar = false;
            this.txtHoTen.BoxLeft = 80;
            this.txtHoTen.EditEnabled = true;
            this.txtHoTen.Label = "Họ tên";
            this.txtHoTen.Location = new System.Drawing.Point(33, 47);
            this.txtHoTen.MaxLength = 255;
            this.txtHoTen.MultiLine = false;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.NumberInputRequired = false;
            this.txtHoTen.NumberMode = false;
            this.txtHoTen.ReadOnly = false;
            this.txtHoTen.Size = new System.Drawing.Size(267, 25);
            this.txtHoTen.TabIndex = 0;
            // 
            // gxCommand1
            // 
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 223);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(863, 47);
            this.gxCommand1.TabIndex = 2;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "";
            this.gxCommand1.ToolTipOK = "";
            this.gxCommand1.OnCancel += new System.EventHandler(this.gxCommand1_OnCancel);
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // txtTenThanh
            // 
            this.txtTenThanh.AutoCompleteEnabled = true;
            this.txtTenThanh.AutoUpperFirstChar = false;
            this.txtTenThanh.BoxLeft = 80;
            this.txtTenThanh.EditEnabled = true;
            this.txtTenThanh.Label = "Tên thánh";
            this.txtTenThanh.Location = new System.Drawing.Point(33, 19);
            this.txtTenThanh.MaxLength = 255;
            this.txtTenThanh.MultiLine = false;
            this.txtTenThanh.Name = "txtTenThanh";
            this.txtTenThanh.NumberInputRequired = false;
            this.txtTenThanh.NumberMode = false;
            this.txtTenThanh.ReadOnly = false;
            this.txtTenThanh.Size = new System.Drawing.Size(267, 25);
            this.txtTenThanh.TabIndex = 15;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.AutoCompleteEnabled = true;
            this.txtNgaySinh.AutoUpperFirstChar = false;
            this.txtNgaySinh.BoxLeft = 80;
            this.txtNgaySinh.EditEnabled = true;
            this.txtNgaySinh.Label = "Ngày sinh";
            this.txtNgaySinh.Location = new System.Drawing.Point(33, 104);
            this.txtNgaySinh.MaxLength = 255;
            this.txtNgaySinh.MultiLine = false;
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.NumberInputRequired = false;
            this.txtNgaySinh.NumberMode = false;
            this.txtNgaySinh.ReadOnly = false;
            this.txtNgaySinh.Size = new System.Drawing.Size(267, 25);
            this.txtNgaySinh.TabIndex = 16;
            // 
            // txtPhai
            // 
            this.txtPhai.AutoCompleteEnabled = true;
            this.txtPhai.AutoUpperFirstChar = false;
            this.txtPhai.BoxLeft = 80;
            this.txtPhai.EditEnabled = true;
            this.txtPhai.Label = "Phái";
            this.txtPhai.Location = new System.Drawing.Point(33, 76);
            this.txtPhai.MaxLength = 255;
            this.txtPhai.MultiLine = false;
            this.txtPhai.Name = "txtPhai";
            this.txtPhai.NumberInputRequired = false;
            this.txtPhai.NumberMode = false;
            this.txtPhai.ReadOnly = false;
            this.txtPhai.Size = new System.Drawing.Size(267, 25);
            this.txtPhai.TabIndex = 17;
            // 
            // rabDa
            // 
            this.rabDa.Location = new System.Drawing.Point(226, 135);
            this.rabDa.Name = "rabDa";
            this.rabDa.Size = new System.Drawing.Size(104, 23);
            this.rabDa.TabIndex = 23;
            this.rabDa.Text = "Đã hoàn thành";
            // 
            // lblHoanThanh
            // 
            this.lblHoanThanh.AutoSize = true;
            this.lblHoanThanh.Location = new System.Drawing.Point(3, 139);
            this.lblHoanThanh.Name = "lblHoanThanh";
            this.lblHoanThanh.Size = new System.Drawing.Size(111, 13);
            this.lblHoanThanh.TabIndex = 21;
            this.lblHoanThanh.Text = "Hoàn thành khóa học";
            // 
            // rabChua
            // 
            this.rabChua.Location = new System.Drawing.Point(117, 135);
            this.rabChua.Name = "rabChua";
            this.rabChua.Size = new System.Drawing.Size(104, 23);
            this.rabChua.TabIndex = 22;
            this.rabChua.Text = "Chưa hoàn thành";
            // 
            // frmHocSinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(863, 270);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmHocSinh";
            this.Text = "Chi tiết khối giáo lý";
            this.Load += new System.EventHandler(this.frmHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private GxControl.GxTextField txtGhiChu;
        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxTextField txtHoTen;
        private GxControl.GxCommand gxCommand1;
        private GxControl.GxTextField txtTenThanh;
        private GxControl.GxTextField txtNgaySinh;
        private GxControl.GxTextField txtPhai;
        private Janus.Windows.EditControls.UIRadioButton rabDa;
        private System.Windows.Forms.Label lblHoanThanh;
        private Janus.Windows.EditControls.UIRadioButton rabChua;

    }
}

