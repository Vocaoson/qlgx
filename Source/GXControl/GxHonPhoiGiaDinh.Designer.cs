namespace GxControl
{
    partial class GxHonPhoiGiaDinh
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLinhMuc = new GxControl.GxLinhMuc();
            this.cbCachThuc = new GxControl.GxCachThucHonPhoi();
            this.dtNgayHonPhoi = new GxControl.GxDateField();
            this.txtSoHonPhoi = new GxControl.GxTextField();
            this.txtNguoiChung2 = new GxControl.GxTextField();
            this.txtNoiHonPhoi = new GxControl.GxTextField();
            this.txtNguoiChung1 = new GxControl.GxTextField();
            this.txtGhiChu = new GxControl.GxTextField();
            this.SuspendLayout();
            // 
            // txtLinhMuc
            // 
            this.txtLinhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLinhMuc.AutoCompleteEnabled = true;
            this.txtLinhMuc.AutoLoadData = true;
            this.txtLinhMuc.AutoUpperFirstChar = true;
            this.txtLinhMuc.BoxLeft = 100;
            this.txtLinhMuc.EditEnabled = true;
            this.txtLinhMuc.Label = "Linh mục chứng";
            this.txtLinhMuc.Location = new System.Drawing.Point(0, 52);
            this.txtLinhMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLinhMuc.MaxLength = 255;
            this.txtLinhMuc.MultiLine = false;
            this.txtLinhMuc.Name = "txtLinhMuc";
            this.txtLinhMuc.NumberInputRequired = true;
            this.txtLinhMuc.NumberMode = false;
            this.txtLinhMuc.ReadOnly = false;
            this.txtLinhMuc.Size = new System.Drawing.Size(431, 25);
            this.txtLinhMuc.TabIndex = 3;
            // 
            // cbCachThuc
            // 
            this.cbCachThuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCachThuc.AutoUpperFirstChar = true;
            this.cbCachThuc.BoxLeft = 100;
            this.cbCachThuc.EditEnabled = true;
            this.cbCachThuc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCachThuc.Label = "Tình trạng hôn phối";
            this.cbCachThuc.Location = new System.Drawing.Point(0, 125);
            this.cbCachThuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCachThuc.MaxLength = 0;
            this.cbCachThuc.Name = "cbCachThuc";
            this.cbCachThuc.SelectedIndex = 0;
            this.cbCachThuc.SelectedText = "";
            this.cbCachThuc.SelectedValue = null;
            this.cbCachThuc.Size = new System.Drawing.Size(431, 26);
            this.cbCachThuc.TabIndex = 6;
            // 
            // dtNgayHonPhoi
            // 
            this.dtNgayHonPhoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgayHonPhoi.AutoUpperFirstChar = false;
            this.dtNgayHonPhoi.BoxLeft = 80;
            this.dtNgayHonPhoi.EditEnabled = true;
            this.dtNgayHonPhoi.FullInputRequired = false;
            this.dtNgayHonPhoi.IsNullDate = false;
            this.dtNgayHonPhoi.Label = "Ngày hôn phối";
            this.dtNgayHonPhoi.Location = new System.Drawing.Point(234, 1);
            this.dtNgayHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtNgayHonPhoi.Name = "dtNgayHonPhoi";
            this.dtNgayHonPhoi.Size = new System.Drawing.Size(197, 26);
            this.dtNgayHonPhoi.TabIndex = 1;
            this.dtNgayHonPhoi.Value = "06/04/2009";
            // 
            // txtSoHonPhoi
            // 
            this.txtSoHonPhoi.AutoCompleteEnabled = false;
            this.txtSoHonPhoi.AutoUpperFirstChar = false;
            this.txtSoHonPhoi.BoxLeft = 80;
            this.txtSoHonPhoi.EditEnabled = true;
            this.txtSoHonPhoi.Label = "Số hôn phối";
            this.txtSoHonPhoi.Location = new System.Drawing.Point(21, 1);
            this.txtSoHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoHonPhoi.MaxLength = 255;
            this.txtSoHonPhoi.MultiLine = false;
            this.txtSoHonPhoi.Name = "txtSoHonPhoi";
            this.txtSoHonPhoi.NumberInputRequired = true;
            this.txtSoHonPhoi.NumberMode = false;
            this.txtSoHonPhoi.ReadOnly = false;
            this.txtSoHonPhoi.Size = new System.Drawing.Size(177, 26);
            this.txtSoHonPhoi.TabIndex = 0;
            // 
            // txtNguoiChung2
            // 
            this.txtNguoiChung2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNguoiChung2.AutoCompleteEnabled = true;
            this.txtNguoiChung2.AutoUpperFirstChar = true;
            this.txtNguoiChung2.BoxLeft = 100;
            this.txtNguoiChung2.EditEnabled = true;
            this.txtNguoiChung2.Label = "Người chứng 2";
            this.txtNguoiChung2.Location = new System.Drawing.Point(0, 101);
            this.txtNguoiChung2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiChung2.MaxLength = 255;
            this.txtNguoiChung2.MultiLine = false;
            this.txtNguoiChung2.Name = "txtNguoiChung2";
            this.txtNguoiChung2.NumberInputRequired = true;
            this.txtNguoiChung2.NumberMode = false;
            this.txtNguoiChung2.ReadOnly = false;
            this.txtNguoiChung2.Size = new System.Drawing.Size(431, 24);
            this.txtNguoiChung2.TabIndex = 5;
            // 
            // txtNoiHonPhoi
            // 
            this.txtNoiHonPhoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiHonPhoi.AutoCompleteEnabled = true;
            this.txtNoiHonPhoi.AutoUpperFirstChar = true;
            this.txtNoiHonPhoi.BoxLeft = 100;
            this.txtNoiHonPhoi.EditEnabled = true;
            this.txtNoiHonPhoi.Label = "Nơi hôn phối";
            this.txtNoiHonPhoi.Location = new System.Drawing.Point(0, 27);
            this.txtNoiHonPhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoiHonPhoi.MaxLength = 255;
            this.txtNoiHonPhoi.MultiLine = false;
            this.txtNoiHonPhoi.Name = "txtNoiHonPhoi";
            this.txtNoiHonPhoi.NumberInputRequired = true;
            this.txtNoiHonPhoi.NumberMode = false;
            this.txtNoiHonPhoi.ReadOnly = false;
            this.txtNoiHonPhoi.Size = new System.Drawing.Size(431, 24);
            this.txtNoiHonPhoi.TabIndex = 2;
            // 
            // txtNguoiChung1
            // 
            this.txtNguoiChung1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNguoiChung1.AutoCompleteEnabled = true;
            this.txtNguoiChung1.AutoUpperFirstChar = true;
            this.txtNguoiChung1.BoxLeft = 100;
            this.txtNguoiChung1.EditEnabled = true;
            this.txtNguoiChung1.Label = "Người chứng 1";
            this.txtNguoiChung1.Location = new System.Drawing.Point(0, 75);
            this.txtNguoiChung1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiChung1.MaxLength = 255;
            this.txtNguoiChung1.MultiLine = false;
            this.txtNguoiChung1.Name = "txtNguoiChung1";
            this.txtNguoiChung1.NumberInputRequired = true;
            this.txtNguoiChung1.NumberMode = false;
            this.txtNguoiChung1.ReadOnly = false;
            this.txtNguoiChung1.Size = new System.Drawing.Size(431, 24);
            this.txtNguoiChung1.TabIndex = 4;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.AutoCompleteEnabled = true;
            this.txtGhiChu.AutoUpperFirstChar = true;
            this.txtGhiChu.BoxLeft = 100;
            this.txtGhiChu.EditEnabled = true;
            this.txtGhiChu.Label = "Ghi chú hôn phối";
            this.txtGhiChu.Location = new System.Drawing.Point(0, 152);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.MultiLine = false;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.NumberInputRequired = true;
            this.txtGhiChu.NumberMode = false;
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.Size = new System.Drawing.Size(431, 25);
            this.txtGhiChu.TabIndex = 7;
            // 
            // GxHonPhoiGiaDinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtLinhMuc);
            this.Controls.Add(this.cbCachThuc);
            this.Controls.Add(this.dtNgayHonPhoi);
            this.Controls.Add(this.txtSoHonPhoi);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtNguoiChung2);
            this.Controls.Add(this.txtNoiHonPhoi);
            this.Controls.Add(this.txtNguoiChung1);
            this.Name = "GxHonPhoiGiaDinh";
            this.Size = new System.Drawing.Size(434, 181);
            this.ResumeLayout(false);

        }

        #endregion

        private GxLinhMuc txtLinhMuc;
        private GxCachThucHonPhoi cbCachThuc;
        private GxDateField dtNgayHonPhoi;
        private GxTextField txtSoHonPhoi;
        private GxTextField txtNguoiChung2;
        private GxTextField txtNoiHonPhoi;
        private GxTextField txtNguoiChung1;
        private GxTextField txtGhiChu;
    }
}
