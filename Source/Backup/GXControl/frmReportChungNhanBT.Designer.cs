namespace GxControl
{
    partial class frmReportChungNhanBT
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
            this.cbChaGui = new GxControl.GxComboField();
            this.txtGiaoDan = new GxControl.GxTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.txtGiaoXuNhan = new GxControl.GxTextField();
            this.txtChaNhan = new GxControl.GxTextField();
            this.gxCommand1 = new GxControl.GxCommand();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cbChaGui);
            this.uiGroupBox1.Controls.Add(this.txtGiaoDan);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtLyDo);
            this.uiGroupBox1.Controls.Add(this.txtGiaoXuNhan);
            this.uiGroupBox1.Controls.Add(this.txtChaNhan);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(461, 287);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin báo cáo";
            // 
            // cbChaGui
            // 
            this.cbChaGui.AutoUpperFirstChar = true;
            this.cbChaGui.BoxLeft = 90;
            this.cbChaGui.EditEnabled = true;
            this.cbChaGui.Label = "Linh mục chứng:";
            this.cbChaGui.Location = new System.Drawing.Point(6, 212);
            this.cbChaGui.MaxLength = 255;
            this.cbChaGui.Name = "cbChaGui";
            this.cbChaGui.SelectedIndex = -1;
            this.cbChaGui.SelectedText = "";
            this.cbChaGui.SelectedValue = null;
            this.cbChaGui.Size = new System.Drawing.Size(440, 26);
            this.cbChaGui.TabIndex = 4;
            // 
            // txtGiaoDan
            // 
            this.txtGiaoDan.AutoCompleteEnabled = true;
            this.txtGiaoDan.AutoUpperFirstChar = false;
            this.txtGiaoDan.BoxLeft = 90;
            this.txtGiaoDan.EditEnabled = true;
            this.txtGiaoDan.Label = "Chứng nhận cho:";
            this.txtGiaoDan.Location = new System.Drawing.Point(6, 19);
            this.txtGiaoDan.MaxLength = 32767;
            this.txtGiaoDan.MultiLine = false;
            this.txtGiaoDan.Name = "txtGiaoDan";
            this.txtGiaoDan.NumberInputRequired = true;
            this.txtGiaoDan.NumberMode = false;
            this.txtGiaoDan.ReadOnly = true;
            this.txtGiaoDan.Size = new System.Drawing.Size(440, 25);
            this.txtGiaoDan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lý do cấp chứng nhận bí tích:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(99, 150);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(347, 56);
            this.txtLyDo.TabIndex = 3;
            // 
            // txtGiaoXuNhan
            // 
            this.txtGiaoXuNhan.AutoCompleteEnabled = true;
            this.txtGiaoXuNhan.AutoUpperFirstChar = true;
            this.txtGiaoXuNhan.BoxLeft = 90;
            this.txtGiaoXuNhan.EditEnabled = true;
            this.txtGiaoXuNhan.Label = "Giáo phận:";
            this.txtGiaoXuNhan.Location = new System.Drawing.Point(6, 81);
            this.txtGiaoXuNhan.MaxLength = 255;
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
            this.txtChaNhan.AutoCompleteEnabled = true;
            this.txtChaNhan.AutoUpperFirstChar = true;
            this.txtChaNhan.BoxLeft = 90;
            this.txtChaNhan.EditEnabled = true;
            this.txtChaNhan.Label = "Kính gửi cha xứ:";
            this.txtChaNhan.Location = new System.Drawing.Point(6, 50);
            this.txtChaNhan.MaxLength = 255;
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
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 242);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(461, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // frmReportChungNhanBT
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(461, 287);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmReportChungNhanBT";
            this.Text = "Xuat chung nhan bi tich";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxTextField txtGiaoXuNhan;
        private GxTextField txtChaNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLyDo;
        private GxCommand gxCommand1;
        private GxTextField txtGiaoDan;
        private GxComboField cbChaGui;
    }
}