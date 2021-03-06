namespace GiaoXu
{
    partial class frmChuyenHoGiaDinh
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
            Janus.Windows.GridEX.GridEXLayout gxGiaDinhList1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenHoGiaDinh));
            this.btnChonGiaDinh = new GxControl.GxButton();
            this.cbGiaoHoDich = new GxControl.GxGiaoHo();
            this.btnBatDauChuyen = new GxControl.GxButton();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gxGiaDinhList1
            // 
            gxGiaDinhList1_DesignTimeLayout.LayoutString = resources.GetString("gxGiaDinhList1_DesignTimeLayout.LayoutString");
            this.gxGiaDinhList1.DesignTimeLayout = gxGiaDinhList1_DesignTimeLayout;
            this.gxGiaDinhList1.Operation = GxGlobal.GxOperation.VIEW;
            // 
            // gxAddEdit1
            // 
            this.gxAddEdit1.Size = new System.Drawing.Size(795, 29);
            // 
            // cbGiaoHo
            // 
            this.cbGiaoHo.AutoLoadGrid = true;
            this.cbGiaoHo.HasShowAll = true;
            this.cbGiaoHo.Size = new System.Drawing.Size(257, 25);
            // 
            // lblTotal
            // 
            this.lblTotal.Size = new System.Drawing.Size(64, 13);
            this.lblTotal.Text = "3 gia đình";
            // 
            // chkGiaDinhAo
            // 
            this.toolTip1.SetToolTip(this.chkGiaDinhAo, "Giáo dân ảo là giáo dân ngoài xứ, không được tính trong các mục thống kê");
            // 
            // btnChonGiaDinh
            // 
            this.btnChonGiaDinh.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChonGiaDinh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonGiaDinh.BackgroundImage")));
            this.btnChonGiaDinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChonGiaDinh.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnChonGiaDinh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnChonGiaDinh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnChonGiaDinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChonGiaDinh.Location = new System.Drawing.Point(274, 19);
            this.btnChonGiaDinh.Name = "btnChonGiaDinh";
            this.btnChonGiaDinh.Size = new System.Drawing.Size(128, 23);
            this.btnChonGiaDinh.TabIndex = 2;
            this.btnChonGiaDinh.Text = "Chọn / bỏ chọn tất cả";
            this.btnChonGiaDinh.UseVisualStyleBackColor = true;
            this.btnChonGiaDinh.Click += new System.EventHandler(this.btnChonGiaDinh_Click);
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
            this.cbGiaoHoDich.Location = new System.Drawing.Point(408, 15);
            this.cbGiaoHoDich.MaGiaoHo = -1;
            this.cbGiaoHoDich.Name = "cbGiaoHoDich";
            this.cbGiaoHoDich.SelectedValue = null;
            this.cbGiaoHoDich.ShowNgoaiXu = true;
            this.cbGiaoHoDich.Size = new System.Drawing.Size(281, 27);
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
            this.btnBatDauChuyen.Location = new System.Drawing.Point(704, 18);
            this.btnBatDauChuyen.Name = "btnBatDauChuyen";
            this.btnBatDauChuyen.Size = new System.Drawing.Size(99, 23);
            this.btnBatDauChuyen.TabIndex = 4;
            this.btnBatDauChuyen.Text = "Bắt đầu chuyển";
            this.btnBatDauChuyen.UseVisualStyleBackColor = true;
            this.btnBatDauChuyen.Click += new System.EventHandler(this.btnBatDauChuyen_Click);
            // 
            // frmChuyenHoGiaDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 598);
            this.Controls.Add(this.btnBatDauChuyen);
            this.Controls.Add(this.cbGiaoHoDich);
            this.Controls.Add(this.btnChonGiaDinh);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmChuyenHoGiaDinh";
            this.Text = "Chuyển họ cho danh sách gia đình";
            this.Controls.SetChildIndex(this.uiGroupBox2, 0);
            this.Controls.SetChildIndex(this.uiGroupBox1, 0);
            this.Controls.SetChildIndex(this.gxCommand1, 0);
            this.Controls.SetChildIndex(this.btnChonGiaDinh, 0);
            this.Controls.SetChildIndex(this.cbGiaoHoDich, 0);
            this.Controls.SetChildIndex(this.btnBatDauChuyen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxButton btnChonGiaDinh;
        private GxControl.GxGiaoHo cbGiaoHoDich;
        private GxControl.GxButton btnBatDauChuyen;
    }
}