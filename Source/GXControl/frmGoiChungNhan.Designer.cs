namespace GxControl
{
    partial class frmGoiChungNhan
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaoPhanNhan = new GxControl.GxSearchBox();
            this.txtGiaoXuNhan = new GxControl.GxSearchBox();
            this.txtLinhMucNhan = new GxControl.GxSearchBox();
            this.gxCommand1 = new GxControl.GxCommand();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cbChaGui);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.txtLyDo);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtGiaoPhanNhan);
            this.uiGroupBox1.Controls.Add(this.txtGiaoXuNhan);
            this.uiGroupBox1.Controls.Add(this.txtLinhMucNhan);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(475, 228);
            this.uiGroupBox1.TabIndex = 0;
            // 
            // cbChaGui
            // 
            this.cbChaGui.AutoUpperFirstChar = true;
            this.cbChaGui.BoxLeft = 100;
            this.cbChaGui.EditEnabled = true;
            this.cbChaGui.Label = "Linh mục chứng";
            this.cbChaGui.Location = new System.Drawing.Point(24, 148);
            this.cbChaGui.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbChaGui.MaxLength = 255;
            this.cbChaGui.Name = "cbChaGui";
            this.cbChaGui.SelectedIndex = -1;
            this.cbChaGui.SelectedText = "";
            this.cbChaGui.SelectedValue = null;
            this.cbChaGui.Size = new System.Drawing.Size(430, 26);
            this.cbChaGui.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lý do cấp chứng nhận";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(127, 104);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(324, 37);
            this.txtLyDo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "* Các thông tin trên có thể để trống";
            // 
            // txtGiaoPhanNhan
            // 
            this.txtGiaoPhanNhan.AutoCompleteEnabled = true;
            this.txtGiaoPhanNhan.AutoUpperFirstChar = false;
            this.txtGiaoPhanNhan.BoxLeft = 100;
            this.txtGiaoPhanNhan.EditEnabled = true;
            this.txtGiaoPhanNhan.Label = "Thuộc giáo phận";
            this.txtGiaoPhanNhan.Location = new System.Drawing.Point(24, 50);
            this.txtGiaoPhanNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGiaoPhanNhan.MaxLength = 255;
            this.txtGiaoPhanNhan.MultiLine = false;
            this.txtGiaoPhanNhan.Name = "txtGiaoPhanNhan";
            this.txtGiaoPhanNhan.NumberInputRequired = true;
            this.txtGiaoPhanNhan.NumberMode = false;
            this.txtGiaoPhanNhan.ReadOnly = false;
            this.txtGiaoPhanNhan.Size = new System.Drawing.Size(430, 25);
            this.txtGiaoPhanNhan.TabIndex = 2;
            // 
            // txtGiaoXuNhan
            // 
            this.txtGiaoXuNhan.AutoCompleteEnabled = true;
            this.txtGiaoXuNhan.AutoUpperFirstChar = false;
            this.txtGiaoXuNhan.BoxLeft = 100;
            this.txtGiaoXuNhan.EditEnabled = true;
            this.txtGiaoXuNhan.Label = "Tên giáo xứ nhận";
            this.txtGiaoXuNhan.Location = new System.Drawing.Point(24, 19);
            this.txtGiaoXuNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGiaoXuNhan.MaxLength = 255;
            this.txtGiaoXuNhan.MultiLine = false;
            this.txtGiaoXuNhan.Name = "txtGiaoXuNhan";
            this.txtGiaoXuNhan.NumberInputRequired = true;
            this.txtGiaoXuNhan.NumberMode = false;
            this.txtGiaoXuNhan.ReadOnly = false;
            this.txtGiaoXuNhan.Size = new System.Drawing.Size(430, 25);
            this.txtGiaoXuNhan.TabIndex = 1;
            // 
            // txtLinhMucNhan
            // 
            this.txtLinhMucNhan.AutoCompleteEnabled = true;
            this.txtLinhMucNhan.AutoUpperFirstChar = false;
            this.txtLinhMucNhan.BoxLeft = 80;
            this.txtLinhMucNhan.EditEnabled = true;
            this.txtLinhMucNhan.Label = "Linh mục nhận";
            this.txtLinhMucNhan.Location = new System.Drawing.Point(24, 19);
            this.txtLinhMucNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLinhMucNhan.MaxLength = 255;
            this.txtLinhMucNhan.MultiLine = false;
            this.txtLinhMucNhan.Name = "txtLinhMucNhan";
            this.txtLinhMucNhan.NumberInputRequired = true;
            this.txtLinhMucNhan.NumberMode = false;
            this.txtLinhMucNhan.ReadOnly = false;
            this.txtLinhMucNhan.Size = new System.Drawing.Size(426, 25);
            this.txtLinhMucNhan.TabIndex = 0;
            this.txtLinhMucNhan.Visible = false;
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 228);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(475, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // frmGoiChungNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 273);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.gxCommand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGoiChungNhan";
            this.Text = "Xuất chứng nhận";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxCommand gxCommand1;
        private GxControl.GxSearchBox txtLinhMucNhan;
        private GxControl.GxSearchBox txtGiaoXuNhan;
        private GxControl.GxSearchBox txtGiaoPhanNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLyDo;
        private GxComboField cbChaGui;
    }
}