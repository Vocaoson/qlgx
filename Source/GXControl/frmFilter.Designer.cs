namespace GxControl
{
    partial class frmFilter
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
            this.gxCommand1 = new GxControl.GxCommand();
            this.filterEditor1 = new GxControl.GxFilter();
            this.SuspendLayout();
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 176);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(598, 45);
            this.gxCommand1.TabIndex = 0;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // filterEditor1
            // 
            this.filterEditor1.BackColor = System.Drawing.Color.Transparent;
            this.filterEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterEditor1.FilterParameter = null;
            this.filterEditor1.GrdData = null;
            this.filterEditor1.Location = new System.Drawing.Point(0, 0);
            this.filterEditor1.Name = "filterEditor1";
            this.filterEditor1.Size = new System.Drawing.Size(598, 176);
            this.filterEditor1.TabIndex = 1;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 221);
            this.Controls.Add(this.filterEditor1);
            this.Controls.Add(this.gxCommand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFilter";
            this.Text = "Đặt điều kiện lọc dữ liệu";
            this.ResumeLayout(false);

        }

        #endregion

        private GxCommand gxCommand1;
        private GxFilter filterEditor1;
    }
}