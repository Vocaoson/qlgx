namespace GiaoXu
{
    partial class frmKiemTraGiaoDanList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemTraGiaoDanList));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.gxGiaoDanList1 = new GxControl.GxGiaoDanLoiList();
            this.uiGroupBox3 = new GxControl.GxGroupBox();
            this.gxAddEdit1 = new GxControl.GxAddEdit();
            this.gxCommand1 = new GxControl.GxCommand();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbGiaoHo = new GxControl.GxGiaoHo();
            this.gxButton1 = new GxControl.GxButton();
            this.chkKhongCoNgayThang = new GxControl.GxCheckBox();
            this.chkSaiQuanHeNgayThang = new GxControl.GxCheckBox();
            this.chkKhongThuocGiaDinh = new GxControl.GxCheckBox();
            this.chkThuocNhieuGiaDinh = new GxControl.GxCheckBox();
            this.chkRuocLeTruocTuoi = new GxControl.GxCheckBox();
            this.gxGroupBox1 = new GxControl.GxGroupBox();
            this.chkNhieuHonPhoi = new GxControl.GxCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox1)).BeginInit();
            this.gxGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.gxGiaoDanList1);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 154);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(890, 444);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "Danh sách giáo dân cần xem xét lại";
            // 
            // gxGiaoDanList1
            // 
            this.gxGiaoDanList1.AllowContextMenu = true;
            this.gxGiaoDanList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxGiaoDanList1.AllowEditGiaoDan = true;
            this.gxGiaoDanList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaoDanList1.AllowShowForm = true;
            this.gxGiaoDanList1.Arguments = null;
            this.gxGiaoDanList1.AutoLoadGridFormat = true;
            this.gxGiaoDanList1.ColumnAutoResize = true;
            this.gxGiaoDanList1.DisableParentOnLoadData = true;
            this.gxGiaoDanList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxGiaoDanList1.DynamicFiltering = true;
            this.gxGiaoDanList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaoDanList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaoDanList1.GroupByBoxVisible = false;
            this.gxGiaoDanList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaoDanList1.Location = new System.Drawing.Point(3, 49);
            this.gxGiaoDanList1.Name = "gxGiaoDanList1";
            this.gxGiaoDanList1.QueryString = "";
            this.gxGiaoDanList1.RecordNavigator = true;
            this.gxGiaoDanList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaoDanList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaoDanList1.Size = new System.Drawing.Size(884, 392);
            this.gxGiaoDanList1.TabIndex = 3;
            this.gxGiaoDanList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaoDanList1.WhereSQL = "";
            this.gxGiaoDanList1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gxGiaoDanList1_RowDoubleClick);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground;
            this.uiGroupBox3.Controls.Add(this.gxAddEdit1);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox3.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox3.Location = new System.Drawing.Point(3, 16);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(884, 33);
            this.uiGroupBox3.TabIndex = 2;
            // 
            // gxAddEdit1
            // 
            this.gxAddEdit1.BackColor = System.Drawing.Color.Transparent;
            this.gxAddEdit1.CaptionDisplayMode = GxGlobal.CaptionDisplayMode.Full;
            this.gxAddEdit1.DisplayMode = GxGlobal.DisplayMode.Mode4;
            this.gxAddEdit1.GridData = this.gxGiaoDanList1;
            this.gxAddEdit1.Location = new System.Drawing.Point(5, 3);
            this.gxAddEdit1.Name = "gxAddEdit1";
            this.gxAddEdit1.Size = new System.Drawing.Size(63, 29);
            this.gxAddEdit1.TabIndex = 0;
            this.gxAddEdit1.ToolTipAdd = "Thêm giáo dân";
            this.gxAddEdit1.ToolTipButton1 = "";
            this.gxAddEdit1.ToolTipButton2 = "";
            this.gxAddEdit1.ToolTipDelete = "Xóa giáo dân được chọn";
            this.gxAddEdit1.ToolTipEdit = "Sửa giáo dân được chọn";
            this.gxAddEdit1.ToolTipFind = "";
            this.gxAddEdit1.ToolTipPrint = "";
            this.gxAddEdit1.ToolTipReload = "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
                "ếm";
            this.gxAddEdit1.ToolTipSelect = "Chọn giáo dân";
            this.gxAddEdit1.DeleteClick += new System.EventHandler(this.gxAddEdit1_DeleteClick);
            this.gxAddEdit1.EditClick += new System.EventHandler(this.gxAddEdit1_EditClick);
            this.gxAddEdit1.AddClick += new System.EventHandler(this.gxAddEdit1_AddClick);
            // 
            // gxCommand1
            // 
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Mode1;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 553);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(890, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "";
            this.gxCommand1.ToolTipOK = "";
            this.gxCommand1.Visible = false;
            this.gxCommand1.OnCancel += new System.EventHandler(this.gxCommand1_OnCancel);
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.lblTotal);
            this.uiGroupBox2.Controls.Add(this.cbGiaoHo);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(890, 50);
            this.uiGroupBox2.TabIndex = 0;
            this.uiGroupBox2.Text = "Giáo họ kiểm tra";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotal.Location = new System.Drawing.Point(318, 29);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Tổng cộng:";
            // 
            // cbGiaoHo
            // 
            this.cbGiaoHo.AutoLoadGrid = false;
            this.cbGiaoHo.AutoUpperFirstChar = false;
            this.cbGiaoHo.BoxLeft = 0;
            this.cbGiaoHo.EditEnabled = true;
            this.cbGiaoHo.GridGiaDinh = null;
            this.cbGiaoHo.GridGiaoDan = null;
            this.cbGiaoHo.HasShowAll = false;
            this.cbGiaoHo.IsAo = Janus.Windows.GridEX.TriState.Empty;
            this.cbGiaoHo.IsLuuTru = false;
            this.cbGiaoHo.Label = "Giáo họ";
            this.cbGiaoHo.Location = new System.Drawing.Point(7, 17);
            this.cbGiaoHo.MaGiaoHo = -1;
            this.cbGiaoHo.Name = "cbGiaoHo";
            this.cbGiaoHo.SelectedValue = null;
            this.cbGiaoHo.ShowNgoaiXu = true;
            this.cbGiaoHo.Size = new System.Drawing.Size(305, 25);
            this.cbGiaoHo.TabIndex = 0;
            this.cbGiaoHo.WhereSQL = "";
            // 
            // gxButton1
            // 
            this.gxButton1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gxButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gxButton1.BackgroundImage")));
            this.gxButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gxButton1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.gxButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.gxButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.gxButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gxButton1.Location = new System.Drawing.Point(44, 65);
            this.gxButton1.Name = "gxButton1";
            this.gxButton1.Size = new System.Drawing.Size(99, 23);
            this.gxButton1.TabIndex = 10;
            this.gxButton1.Text = "Bắt đầu &kiểm tra";
            this.gxButton1.UseVisualStyleBackColor = true;
            this.gxButton1.Click += new System.EventHandler(this.gxButton1_Click);
            // 
            // chkKhongCoNgayThang
            // 
            this.chkKhongCoNgayThang.AutoSize = true;
            this.chkKhongCoNgayThang.Checked = true;
            this.chkKhongCoNgayThang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKhongCoNgayThang.Location = new System.Drawing.Point(44, 19);
            this.chkKhongCoNgayThang.Name = "chkKhongCoNgayThang";
            this.chkKhongCoNgayThang.Size = new System.Drawing.Size(162, 17);
            this.chkKhongCoNgayThang.TabIndex = 11;
            this.chkKhongCoNgayThang.Text = "Không có dữ liệu ngày tháng";
            this.chkKhongCoNgayThang.UseVisualStyleBackColor = true;
            // 
            // chkSaiQuanHeNgayThang
            // 
            this.chkSaiQuanHeNgayThang.AutoSize = true;
            this.chkSaiQuanHeNgayThang.Checked = true;
            this.chkSaiQuanHeNgayThang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaiQuanHeNgayThang.Location = new System.Drawing.Point(44, 42);
            this.chkSaiQuanHeNgayThang.Name = "chkSaiQuanHeNgayThang";
            this.chkSaiQuanHeNgayThang.Size = new System.Drawing.Size(139, 17);
            this.chkSaiQuanHeNgayThang.TabIndex = 11;
            this.chkSaiQuanHeNgayThang.Text = "Sai quan hệ ngày tháng";
            this.chkSaiQuanHeNgayThang.UseVisualStyleBackColor = true;
            // 
            // chkKhongThuocGiaDinh
            // 
            this.chkKhongThuocGiaDinh.AutoSize = true;
            this.chkKhongThuocGiaDinh.Checked = true;
            this.chkKhongThuocGiaDinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKhongThuocGiaDinh.Location = new System.Drawing.Point(294, 19);
            this.chkKhongThuocGiaDinh.Name = "chkKhongThuocGiaDinh";
            this.chkKhongThuocGiaDinh.Size = new System.Drawing.Size(149, 17);
            this.chkKhongThuocGiaDinh.TabIndex = 11;
            this.chkKhongThuocGiaDinh.Text = "Không thuộc gia đình nào";
            this.chkKhongThuocGiaDinh.UseVisualStyleBackColor = true;
            // 
            // chkThuocNhieuGiaDinh
            // 
            this.chkThuocNhieuGiaDinh.AutoSize = true;
            this.chkThuocNhieuGiaDinh.Checked = true;
            this.chkThuocNhieuGiaDinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThuocNhieuGiaDinh.Location = new System.Drawing.Point(294, 42);
            this.chkThuocNhieuGiaDinh.Name = "chkThuocNhieuGiaDinh";
            this.chkThuocNhieuGiaDinh.Size = new System.Drawing.Size(127, 17);
            this.chkThuocNhieuGiaDinh.TabIndex = 11;
            this.chkThuocNhieuGiaDinh.Text = "Thuộc nhiều gia đình";
            this.chkThuocNhieuGiaDinh.UseVisualStyleBackColor = true;
            // 
            // chkRuocLeTruocTuoi
            // 
            this.chkRuocLeTruocTuoi.AutoSize = true;
            this.chkRuocLeTruocTuoi.Checked = true;
            this.chkRuocLeTruocTuoi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRuocLeTruocTuoi.Location = new System.Drawing.Point(513, 19);
            this.chkRuocLeTruocTuoi.Name = "chkRuocLeTruocTuoi";
            this.chkRuocLeTruocTuoi.Size = new System.Drawing.Size(110, 17);
            this.chkRuocLeTruocTuoi.TabIndex = 11;
            this.chkRuocLeTruocTuoi.Text = "Rước lễ trước tuổi";
            this.chkRuocLeTruocTuoi.UseVisualStyleBackColor = true;
            // 
            // gxGroupBox1
            // 
            this.gxGroupBox1.Controls.Add(this.gxButton1);
            this.gxGroupBox1.Controls.Add(this.chkNhieuHonPhoi);
            this.gxGroupBox1.Controls.Add(this.chkRuocLeTruocTuoi);
            this.gxGroupBox1.Controls.Add(this.chkKhongCoNgayThang);
            this.gxGroupBox1.Controls.Add(this.chkThuocNhieuGiaDinh);
            this.gxGroupBox1.Controls.Add(this.chkSaiQuanHeNgayThang);
            this.gxGroupBox1.Controls.Add(this.chkKhongThuocGiaDinh);
            this.gxGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gxGroupBox1.Location = new System.Drawing.Point(0, 50);
            this.gxGroupBox1.Name = "gxGroupBox1";
            this.gxGroupBox1.Size = new System.Drawing.Size(890, 104);
            this.gxGroupBox1.TabIndex = 2;
            this.gxGroupBox1.Text = "Loại kiểm tra";
            // 
            // chkNhieuHonPhoi
            // 
            this.chkNhieuHonPhoi.AutoSize = true;
            this.chkNhieuHonPhoi.Checked = true;
            this.chkNhieuHonPhoi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNhieuHonPhoi.Location = new System.Drawing.Point(513, 42);
            this.chkNhieuHonPhoi.Name = "chkNhieuHonPhoi";
            this.chkNhieuHonPhoi.Size = new System.Drawing.Size(112, 17);
            this.chkNhieuHonPhoi.TabIndex = 11;
            this.chkNhieuHonPhoi.Text = "Có nhiều hôn phối";
            this.chkNhieuHonPhoi.UseVisualStyleBackColor = true;
            // 
            // frmKiemTraGiaoDanList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(890, 598);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.gxGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Name = "frmKiemTraGiaoDanList";
            this.Text = "Kiểm tra dữ liệu giáo dân";
            this.Load += new System.EventHandler(this.frmGiaoDanList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGroupBox1)).EndInit();
            this.gxGroupBox1.ResumeLayout(false);
            this.gxGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxCommand gxCommand1;
        private GxControl.GxGroupBox uiGroupBox3;
        private GxControl.GxAddEdit gxAddEdit1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxGiaoHo cbGiaoHo;
        private GxControl.GxGiaoDanLoiList gxGiaoDanList1;
        private System.Windows.Forms.Label lblTotal;
        private GxControl.GxButton gxButton1;
        private GxControl.GxCheckBox chkRuocLeTruocTuoi;
        private GxControl.GxCheckBox chkThuocNhieuGiaDinh;
        private GxControl.GxCheckBox chkKhongThuocGiaDinh;
        private GxControl.GxCheckBox chkSaiQuanHeNgayThang;
        private GxControl.GxCheckBox chkKhongCoNgayThang;
        private GxControl.GxGroupBox gxGroupBox1;
        private GxControl.GxCheckBox chkNhieuHonPhoi;
    }
}