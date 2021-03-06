using GxControl;
namespace GiaoXu
{
    partial class frmLinhMuc
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
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.dtDenNgay = new GxControl.GxDateField();
            this.dtTuNgay = new GxControl.GxDateField();
            this.txtMaLinhMuc = new GxControl.GxTextField();
            this.txtHoTen = new GxControl.GxTextField();
            this.txtTenThanh = new GxControl.GxTextField();
            this.dtNgaySinh = new GxControl.GxDateField();
            this.txtDienThoai = new GxControl.GxTextField();
            this.txtEmail = new GxControl.GxTextField();
            this.txtGhiChu = new GxControl.GxTextField();
            this.cbChucVu = new GxControl.GxComboField();
            this.gxCommand1 = new GxControl.GxCommand();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.dtDenNgay);
            this.uiGroupBox1.Controls.Add(this.dtTuNgay);
            this.uiGroupBox1.Controls.Add(this.txtMaLinhMuc);
            this.uiGroupBox1.Controls.Add(this.txtHoTen);
            this.uiGroupBox1.Controls.Add(this.txtTenThanh);
            this.uiGroupBox1.Controls.Add(this.dtNgaySinh);
            this.uiGroupBox1.Controls.Add(this.txtDienThoai);
            this.uiGroupBox1.Controls.Add(this.txtEmail);
            this.uiGroupBox1.Controls.Add(this.txtGhiChu);
            this.uiGroupBox1.Controls.Add(this.cbChucVu);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(427, 373);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin cá nhân";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.AutoUpperFirstChar = false;
            this.dtDenNgay.BoxLeft = 90;
            this.dtDenNgay.EditEnabled = true;
            this.dtDenNgay.FullInputRequired = false;
            this.dtDenNgay.IsNullDate = false;
            this.dtDenNgay.Label = "Đến ngày";
            this.dtDenNgay.Location = new System.Drawing.Point(12, 203);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(210, 26);
            this.dtDenNgay.TabIndex = 6;
            this.dtDenNgay.Value = "15/04/2009";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.AutoUpperFirstChar = false;
            this.dtTuNgay.BoxLeft = 90;
            this.dtTuNgay.EditEnabled = true;
            this.dtTuNgay.FullInputRequired = false;
            this.dtTuNgay.IsNullDate = false;
            this.dtTuNgay.Label = "Từ ngày";
            this.dtTuNgay.Location = new System.Drawing.Point(12, 172);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(210, 26);
            this.dtTuNgay.TabIndex = 5;
            this.dtTuNgay.Value = "15/04/2009";
            // 
            // txtMaLinhMuc
            // 
            this.txtMaLinhMuc.AutoCompleteEnabled = true;
            this.txtMaLinhMuc.AutoUpperFirstChar = false;
            this.txtMaLinhMuc.BoxLeft = 90;
            this.txtMaLinhMuc.EditEnabled = false;
            this.txtMaLinhMuc.Label = "Mã Linh mục";
            this.txtMaLinhMuc.Location = new System.Drawing.Point(12, 20);
            this.txtMaLinhMuc.MaxLength = 32767;
            this.txtMaLinhMuc.MultiLine = false;
            this.txtMaLinhMuc.Name = "txtMaLinhMuc";
            this.txtMaLinhMuc.NumberInputRequired = true;
            this.txtMaLinhMuc.NumberMode = false;
            this.txtMaLinhMuc.ReadOnly = false;
            this.txtMaLinhMuc.Size = new System.Drawing.Size(189, 25);
            this.txtMaLinhMuc.TabIndex = 0;
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoCompleteEnabled = true;
            this.txtHoTen.AutoUpperFirstChar = true;
            this.txtHoTen.BoxLeft = 90;
            this.txtHoTen.EditEnabled = true;
            this.txtHoTen.Label = "Họ tên";
            this.txtHoTen.Location = new System.Drawing.Point(12, 78);
            this.txtHoTen.MaxLength = 255;
            this.txtHoTen.MultiLine = false;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.NumberInputRequired = true;
            this.txtHoTen.NumberMode = false;
            this.txtHoTen.ReadOnly = false;
            this.txtHoTen.Size = new System.Drawing.Size(323, 25);
            this.txtHoTen.TabIndex = 2;
            // 
            // txtTenThanh
            // 
            this.txtTenThanh.AutoCompleteEnabled = true;
            this.txtTenThanh.AutoUpperFirstChar = true;
            this.txtTenThanh.BoxLeft = 90;
            this.txtTenThanh.EditEnabled = true;
            this.txtTenThanh.Label = "Tên thánh";
            this.txtTenThanh.Location = new System.Drawing.Point(12, 49);
            this.txtTenThanh.MaxLength = 255;
            this.txtTenThanh.MultiLine = false;
            this.txtTenThanh.Name = "txtTenThanh";
            this.txtTenThanh.NumberInputRequired = true;
            this.txtTenThanh.NumberMode = false;
            this.txtTenThanh.ReadOnly = false;
            this.txtTenThanh.Size = new System.Drawing.Size(323, 25);
            this.txtTenThanh.TabIndex = 1;
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.AutoUpperFirstChar = false;
            this.dtNgaySinh.BoxLeft = 90;
            this.dtNgaySinh.EditEnabled = true;
            this.dtNgaySinh.FullInputRequired = false;
            this.dtNgaySinh.IsNullDate = false;
            this.dtNgaySinh.Label = "Ngày sinh";
            this.dtNgaySinh.Location = new System.Drawing.Point(12, 141);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(210, 26);
            this.dtNgaySinh.TabIndex = 4;
            this.dtNgaySinh.Value = "05/04/2009";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.AutoCompleteEnabled = true;
            this.txtDienThoai.AutoUpperFirstChar = false;
            this.txtDienThoai.BoxLeft = 90;
            this.txtDienThoai.EditEnabled = true;
            this.txtDienThoai.Label = "Điện thoại";
            this.txtDienThoai.Location = new System.Drawing.Point(12, 234);
            this.txtDienThoai.MaxLength = 20;
            this.txtDienThoai.MultiLine = false;
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.NumberInputRequired = true;
            this.txtDienThoai.NumberMode = false;
            this.txtDienThoai.ReadOnly = false;
            this.txtDienThoai.Size = new System.Drawing.Size(323, 25);
            this.txtDienThoai.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoCompleteEnabled = true;
            this.txtEmail.AutoUpperFirstChar = false;
            this.txtEmail.BoxLeft = 90;
            this.txtEmail.EditEnabled = true;
            this.txtEmail.Label = "Email";
            this.txtEmail.Location = new System.Drawing.Point(12, 268);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.MultiLine = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.NumberInputRequired = true;
            this.txtEmail.NumberMode = false;
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(323, 25);
            this.txtEmail.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.AutoCompleteEnabled = true;
            this.txtGhiChu.AutoUpperFirstChar = false;
            this.txtGhiChu.BoxLeft = 90;
            this.txtGhiChu.EditEnabled = true;
            this.txtGhiChu.Label = "Ghi chú";
            this.txtGhiChu.Location = new System.Drawing.Point(12, 299);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.MultiLine = false;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.NumberInputRequired = true;
            this.txtGhiChu.NumberMode = false;
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.Size = new System.Drawing.Size(323, 25);
            this.txtGhiChu.TabIndex = 9;
            // 
            // cbChucVu
            // 
            this.cbChucVu.AutoUpperFirstChar = false;
            this.cbChucVu.BoxLeft = 90;
            this.cbChucVu.EditEnabled = true;
            this.cbChucVu.Label = "Chức vụ";
            this.cbChucVu.Location = new System.Drawing.Point(12, 109);
            this.cbChucVu.MaxLength = 255;
            this.cbChucVu.Name = "cbChucVu";
            this.cbChucVu.SelectedIndex = -1;
            this.cbChucVu.SelectedText = "";
            this.cbChucVu.SelectedValue = null;
            this.cbChucVu.Size = new System.Drawing.Size(189, 26);
            this.cbChucVu.TabIndex = 3;
            // 
            // gxCommand1
            // 
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 330);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(427, 43);
            this.gxCommand1.TabIndex = 10;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnOK += new System.EventHandler(this.btnOK_Click);
            // 
            // frmLinhMuc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(427, 373);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLinhMuc";
            this.Text = "Nhập Linh mục";
            this.Load += new System.EventHandler(this.frmLinhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GxTextField txtHoTen;
        private GxTextField txtTenThanh;
        private GxComboField cbChucVu;
        private GxDateField dtNgaySinh;
        private GxTextField txtGhiChu;
        private GxControl.GxGroupBox uiGroupBox1;
        private GxCommand gxCommand1;
        private GxTextField txtMaLinhMuc;
        private GxDateField dtDenNgay;
        private GxDateField dtTuNgay;
        private GxTextField txtDienThoai;
        private GxTextField txtEmail;
    }
}