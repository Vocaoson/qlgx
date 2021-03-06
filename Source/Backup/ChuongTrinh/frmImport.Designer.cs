namespace GiaoXu
{
    partial class frmImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.btnStop = new GxControl.GxButton();
            this.btnStart = new GxControl.GxButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtErrorOutput = new System.Windows.Forms.TextBox();
            this.btnSelectDB = new GxControl.GxButton();
            this.txtDB = new GxControl.GxTextField();
            this.gxCommand1 = new GxControl.GxCommand();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.btnStop);
            this.uiGroupBox1.Controls.Add(this.btnStart);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.lblPercent);
            this.uiGroupBox1.Controls.Add(this.lblStatus);
            this.uiGroupBox1.Controls.Add(this.progressBar1);
            this.uiGroupBox1.Controls.Add(this.txtErrorOutput);
            this.uiGroupBox1.Controls.Add(this.btnSelectDB);
            this.uiGroupBox1.Controls.Add(this.txtDB);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(613, 387);
            this.uiGroupBox1.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(99, 63);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Hủy bỏ";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(18, 63);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 11);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thông báo lỗi";
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(538, 94);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(55, 13);
            this.lblPercent.TabIndex = 4;
            this.lblPercent.Text = "0%";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPercent.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 94);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 11);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Trạng thái";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(575, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // txtErrorOutput
            // 
            this.txtErrorOutput.Location = new System.Drawing.Point(18, 164);
            this.txtErrorOutput.Multiline = true;
            this.txtErrorOutput.Name = "txtErrorOutput";
            this.txtErrorOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorOutput.Size = new System.Drawing.Size(575, 208);
            this.txtErrorOutput.TabIndex = 2;
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectDB.BackgroundImage")));
            this.btnSelectDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectDB.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSelectDB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSelectDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSelectDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectDB.Location = new System.Drawing.Point(518, 33);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDB.TabIndex = 1;
            this.btnSelectDB.Text = "Chọn";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // txtDB
            // 
            this.txtDB.AutoCompleteEnabled = true;
            this.txtDB.AutoUpperFirstChar = false;
            this.txtDB.BoxLeft = 80;
            this.txtDB.EditEnabled = true;
            this.txtDB.Label = "Chọn tập tin";
            this.txtDB.Location = new System.Drawing.Point(0, 31);
            this.txtDB.MaxLength = 32767;
            this.txtDB.MultiLine = false;
            this.txtDB.Name = "txtDB";
            this.txtDB.NumberInputRequired = true;
            this.txtDB.NumberMode = false;
            this.txtDB.ReadOnly = false;
            this.txtDB.Size = new System.Drawing.Size(512, 25);
            this.txtDB.TabIndex = 0;
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 387);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(613, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            this.gxCommand1.OnCancel += new System.EventHandler(this.gxCommand1_OnCancel);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "MS Excel | *.xls| MS Access File (*.mdb)|*.mdb|All files (*.*)|*.*";
            // 
            // frmImport
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(613, 432);
            this.ControlBox = false;
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.gxCommand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImport";
            this.Text = "Nhap du lieu tu chuong trinh khac";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxButton btnSelectDB;
        private GxControl.GxTextField txtDB;
        private GxControl.GxCommand gxCommand1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtErrorOutput;
        private GxControl.GxButton btnStop;
        private GxControl.GxButton btnStart;
        private System.Windows.Forms.Label lblPercent;
    }
}