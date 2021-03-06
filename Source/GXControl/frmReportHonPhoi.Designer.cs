namespace GXControl
{
    partial class frmReportHonPhoi
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
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.cbChaGui = new GXControl.GxComboField();
            this.txtNguoi1 = new GXControl.GxTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNguoi2 = new System.Windows.Forms.TextBox();
            this.txtGiaoXuNhan = new GXControl.GxTextField();
            this.txtChaNhan = new GXControl.GxTextField();
            this.gxCommand1 = new GXControl.GXCommand();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cbChaGui);
            this.uiGroupBox1.Controls.Add(this.txtNguoi1);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtNguoi2);
            this.uiGroupBox1.Controls.Add(this.txtGiaoXuNhan);
            this.uiGroupBox1.Controls.Add(this.txtChaNhan);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(461, 242);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin báo cáo";
            // 
            // cbChaGui
            // 
            this.cbChaGui.AutoUpperFirstChar = true;
            this.cbChaGui.BoxLeft = 90;
            this.cbChaGui.EditEnabled = true;
            this.cbChaGui.Label = "Linh mục chứng:";
            this.cbChaGui.Location = new System.Drawing.Point(6, 157);
            this.cbChaGui.Name = "cbChaGui";
            this.cbChaGui.SelectedIndex = -1;
            this.cbChaGui.SelectedText = "";
            this.cbChaGui.SelectedValue = null;
            this.cbChaGui.Size = new System.Drawing.Size(440, 26);
            this.cbChaGui.TabIndex = 4;
            // 
            // txtNguoi1
            // 
            this.txtNguoi1.AutoUpperFirstChar = false;
            this.txtNguoi1.BoxLeft = 90;
            this.txtNguoi1.EditEnabled = true;
            this.txtNguoi1.Label = "Giời thiệu cho:";
            this.txtNguoi1.Location = new System.Drawing.Point(6, 19);
            this.txtNguoi1.MaxLength = 32767;
            this.txtNguoi1.MultiLine = false;
            this.txtNguoi1.Name = "txtNguoi1";
            this.txtNguoi1.NumberInputRequired = true;
            this.txtNguoi1.NumberMode = false;
            this.txtNguoi1.ReadOnly = true;
            this.txtNguoi1.Size = new System.Drawing.Size(440, 25);
            this.txtNguoi1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Muốn kết hôn theo phép đạo với:";
            // 
            // txtNguoi2
            // 
            this.txtNguoi2.Location = new System.Drawing.Point(99, 131);
            this.txtNguoi2.Name = "txtNguoi2";
            this.txtNguoi2.Size = new System.Drawing.Size(347, 20);
            this.txtNguoi2.TabIndex = 3;
            this.txtNguoi2.Leave += new System.EventHandler(this.txtNguoi2_Leave);
            // 
            // txtGiaoXuNhan
            // 
            this.txtGiaoXuNhan.AutoUpperFirstChar = true;
            this.txtGiaoXuNhan.BoxLeft = 90;
            this.txtGiaoXuNhan.EditEnabled = true;
            this.txtGiaoXuNhan.Label = "Giáo phận:";
            this.txtGiaoXuNhan.Location = new System.Drawing.Point(6, 81);
            this.txtGiaoXuNhan.MaxLength = 32767;
            this.txtGiaoXuNhan.MultiLine = false;
            this.txtGiaoXuNhan.Name = "txtGiaoXuNhan";
            this.txtGiaoXuNhan.NumberInputRequired = true;
            this.txtGiaoXuNhan.NumberMode = false;
            this.txtGiaoXuNhan.ReadOnly = false;
            this.txtGiaoXuNhan.Size = new System.Drawing.Size(440, 25);
            this.txtGiaoXuNhan.TabIndex = 2;
            // 
            // txtChaNhan
            // 
            this.txtChaNhan.AutoUpperFirstChar = true;
            this.txtChaNhan.BoxLeft = 90;
            this.txtChaNhan.EditEnabled = true;
            this.txtChaNhan.Label = "Kính gửi cha xứ:";
            this.txtChaNhan.Location = new System.Drawing.Point(6, 50);
            this.txtChaNhan.MaxLength = 32767;
            this.txtChaNhan.MultiLine = false;
            this.txtChaNhan.Name = "txtChaNhan";
            this.txtChaNhan.NumberInputRequired = true;
            this.txtChaNhan.NumberMode = false;
            this.txtChaNhan.ReadOnly = false;
            this.txtChaNhan.Size = new System.Drawing.Size(440, 25);
            this.txtChaNhan.TabIndex = 1;
            // 
            // gxCommand1
            // 
            this.gxCommand1.DisplayMode = GXGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 197);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.Size = new System.Drawing.Size(461, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // frmReportHonPhoi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(461, 242);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmReportHonPhoi";
            this.Text = "Xuat chung nhan bi tich";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private GxTextField txtGiaoXuNhan;
        private GxTextField txtChaNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNguoi2;
        private GXCommand gxCommand1;
        private GxTextField txtNguoi1;
        private GxComboField cbChaGui;
    }
}