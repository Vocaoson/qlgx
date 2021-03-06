namespace GiaoXu
{
    partial class frmChuyenHoGiaoDan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenHoGiaoDan));
            this.btnChonGiaoDan = new GxControl.GxButton();
            this.cbGiaoHoDich = new GxControl.GxGiaoHo();
            this.btnBatDauChuyen = new GxControl.GxButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).BeginInit();
            this.SuspendLayout();
            // 
            // gxAddEdit1
            // 
            this.gxAddEdit1.Size = new System.Drawing.Size(820, 29);
            // 
            // cbGiaoHo
            // 
            this.cbGiaoHo.AutoLoadGrid = true;
            this.cbGiaoHo.HasShowAll = true;
            this.cbGiaoHo.Size = new System.Drawing.Size(258, 25);
            // 
            // chkGiaoDanAo
            // 
            this.toolTip1.SetToolTip(this.chkGiaoDanAo, "Giáo dân không được thống kê là giáo dân ngoài xứ, không được tính trong các mục thống kê");
            // 
            // btnChonGiaoDan
            // 
            this.btnChonGiaoDan.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChonGiaoDan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonGiaoDan.BackgroundImage")));
            this.btnChonGiaoDan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChonGiaoDan.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnChonGiaoDan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnChonGiaoDan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnChonGiaoDan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChonGiaoDan.Location = new System.Drawing.Point(271, 19);
            this.btnChonGiaoDan.Name = "btnChonGiaoDan";
            this.btnChonGiaoDan.Size = new System.Drawing.Size(128, 23);
            this.btnChonGiaoDan.TabIndex = 2;
            this.btnChonGiaoDan.Text = "Chọn / bỏ chọn tất cả";
            this.btnChonGiaoDan.UseVisualStyleBackColor = true;
            this.btnChonGiaoDan.Click += new System.EventHandler(this.btnChonGiaoDan_Click);
            // 
            // cbGiaoHoDich
            // 
            this.cbGiaoHoDich.AutoLoadGrid = true;
            this.cbGiaoHoDich.AutoUpperFirstChar = false;
            this.cbGiaoHoDich.BoxLeft = 80;
            this.cbGiaoHoDich.EditEnabled = true;
            this.cbGiaoHoDich.GridGiaDinh = null;
            this.cbGiaoHoDich.GridGiaoDan = null;
            this.cbGiaoHoDich.HasShowAll = false;
            this.cbGiaoHoDich.IsAo = Janus.Windows.GridEX.TriState.Empty;
            this.cbGiaoHoDich.IsLuuTru = false;
            this.cbGiaoHoDich.Label = "Giáo họ đích";
            this.cbGiaoHoDich.Location = new System.Drawing.Point(405, 15);
            this.cbGiaoHoDich.MaGiaoHo = -1;
            this.cbGiaoHoDich.Name = "cbGiaoHoDich";
            this.cbGiaoHoDich.SelectedValue = null;
            this.cbGiaoHoDich.ShowNgoaiXu = true;
            this.cbGiaoHoDich.Size = new System.Drawing.Size(278, 27);
            this.cbGiaoHoDich.TabIndex = 3;
            this.cbGiaoHoDich.WhereSQL = "";
            // 
            // btnBatDauChuyen
            // 
            this.btnBatDauChuyen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBatDauChuyen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBatDauChuyen.BackgroundImage")));
            this.btnBatDauChuyen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBatDauChuyen.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnBatDauChuyen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnBatDauChuyen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnBatDauChuyen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBatDauChuyen.Location = new System.Drawing.Point(689, 18);
            this.btnBatDauChuyen.Name = "btnBatDauChuyen";
            this.btnBatDauChuyen.Size = new System.Drawing.Size(99, 23);
            this.btnBatDauChuyen.TabIndex = 4;
            this.btnBatDauChuyen.Text = "Bắt đầu chuyển";
            this.btnBatDauChuyen.UseVisualStyleBackColor = true;
            this.btnBatDauChuyen.Click += new System.EventHandler(this.btnBatDauChuyen_Click);
            // 
            // frmChuyenHoGiaoDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 598);
            this.Controls.Add(this.btnBatDauChuyen);
            this.Controls.Add(this.cbGiaoHoDich);
            this.Controls.Add(this.btnChonGiaoDan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmChuyenHoGiaoDan";
            this.Text = "Chuyển họ cho danh sách giáo dân";
            this.Controls.SetChildIndex(this.uiGroupBox2, 0);
            this.Controls.SetChildIndex(this.uiGroupBox1, 0);
            this.Controls.SetChildIndex(this.gxCommand1, 0);
            this.Controls.SetChildIndex(this.btnChonGiaoDan, 0);
            this.Controls.SetChildIndex(this.cbGiaoHoDich, 0);
            this.Controls.SetChildIndex(this.btnBatDauChuyen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxButton btnChonGiaoDan;
        private GxControl.GxGiaoHo cbGiaoHoDich;
        private GxControl.GxButton btnBatDauChuyen;
    }
}