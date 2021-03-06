namespace GxControl
{
    partial class GxThongKeOnGoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GxThongKeOnGoi));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.txtNoiTu = new GxControl.GxTextField();
            this.txtNoiPhucVu = new GxControl.GxTextField();
            this.txtDongTu = new GxControl.GxTextField();
            this.cbChucVu = new GxControl.GxComboField();
            this.cbGiaoHo = new GxControl.GxGiaoHo();
            this.chkLuuTru = new GxControl.GxCheckBox();
            this.chkNullAccept = new GxControl.GxCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFilter = new GxControl.GxButton();
            this.btnPrint = new GxControl.GxButton();
            this.btnSearch = new GxControl.GxButton();
            this.dtDateTo = new GxControl.GxDateField();
            this.dtDateFrom = new GxControl.GxDateField();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.gxGiaoDanList1 = new GxControl.GxGiaoDanList();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtNoiTu);
            this.uiGroupBox1.Controls.Add(this.txtNoiPhucVu);
            this.uiGroupBox1.Controls.Add(this.txtDongTu);
            this.uiGroupBox1.Controls.Add(this.cbChucVu);
            this.uiGroupBox1.Controls.Add(this.cbGiaoHo);
            this.uiGroupBox1.Controls.Add(this.chkLuuTru);
            this.uiGroupBox1.Controls.Add(this.chkNullAccept);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.lblTotal);
            this.uiGroupBox1.Controls.Add(this.btnFilter);
            this.uiGroupBox1.Controls.Add(this.btnPrint);
            this.uiGroupBox1.Controls.Add(this.btnSearch);
            this.uiGroupBox1.Controls.Add(this.dtDateTo);
            this.uiGroupBox1.Controls.Add(this.dtDateFrom);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(770, 291);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Điều kiện thống kê";
            // 
            // txtNoiTu
            // 
            this.txtNoiTu.AutoCompleteEnabled = true;
            this.txtNoiTu.AutoUpperFirstChar = true;
            this.txtNoiTu.BoxLeft = 120;
            this.txtNoiTu.EditEnabled = true;
            this.txtNoiTu.Label = "Địa chỉ";
            this.txtNoiTu.Location = new System.Drawing.Point(6, 164);
            this.txtNoiTu.MaxLength = 255;
            this.txtNoiTu.MultiLine = false;
            this.txtNoiTu.Name = "txtNoiTu";
            this.txtNoiTu.NumberInputRequired = true;
            this.txtNoiTu.NumberMode = false;
            this.txtNoiTu.ReadOnly = false;
            this.txtNoiTu.Size = new System.Drawing.Size(554, 27);
            this.txtNoiTu.TabIndex = 5;
            // 
            // txtNoiPhucVu
            // 
            this.txtNoiPhucVu.AutoCompleteEnabled = true;
            this.txtNoiPhucVu.AutoUpperFirstChar = true;
            this.txtNoiPhucVu.BoxLeft = 120;
            this.txtNoiPhucVu.EditEnabled = true;
            this.txtNoiPhucVu.Label = "Nơi phục vụ";
            this.txtNoiPhucVu.Location = new System.Drawing.Point(6, 195);
            this.txtNoiPhucVu.MaxLength = 255;
            this.txtNoiPhucVu.MultiLine = false;
            this.txtNoiPhucVu.Name = "txtNoiPhucVu";
            this.txtNoiPhucVu.NumberInputRequired = true;
            this.txtNoiPhucVu.NumberMode = false;
            this.txtNoiPhucVu.ReadOnly = false;
            this.txtNoiPhucVu.Size = new System.Drawing.Size(554, 25);
            this.txtNoiPhucVu.TabIndex = 6;
            // 
            // txtDongTu
            // 
            this.txtDongTu.AutoCompleteEnabled = true;
            this.txtDongTu.AutoUpperFirstChar = true;
            this.txtDongTu.BoxLeft = 120;
            this.txtDongTu.EditEnabled = true;
            this.txtDongTu.Label = "Dòng tu/chủng viện";
            this.txtDongTu.Location = new System.Drawing.Point(6, 133);
            this.txtDongTu.MaxLength = 255;
            this.txtDongTu.MultiLine = false;
            this.txtDongTu.Name = "txtDongTu";
            this.txtDongTu.NumberInputRequired = true;
            this.txtDongTu.NumberMode = false;
            this.txtDongTu.ReadOnly = false;
            this.txtDongTu.Size = new System.Drawing.Size(554, 25);
            this.txtDongTu.TabIndex = 4;
            // 
            // cbChucVu
            // 
            this.cbChucVu.AutoUpperFirstChar = true;
            this.cbChucVu.BoxLeft = 120;
            this.cbChucVu.EditEnabled = true;
            this.cbChucVu.Label = "Chức vụ";
            this.cbChucVu.Location = new System.Drawing.Point(6, 101);
            this.cbChucVu.MaxLength = 0;
            this.cbChucVu.Name = "cbChucVu";
            this.cbChucVu.SelectedIndex = -1;
            this.cbChucVu.SelectedText = "";
            this.cbChucVu.SelectedValue = null;
            this.cbChucVu.Size = new System.Drawing.Size(355, 26);
            this.cbChucVu.TabIndex = 3;
            // 
            // cbGiaoHo
            // 
            this.cbGiaoHo.AutoLoadGrid = false;
            this.cbGiaoHo.AutoUpperFirstChar = false;
            this.cbGiaoHo.BoxLeft = 120;
            this.cbGiaoHo.EditEnabled = true;
            this.cbGiaoHo.GridGiaDinh = null;
            this.cbGiaoHo.GridGiaoDan = null;
            this.cbGiaoHo.HasShowAll = true;
            this.cbGiaoHo.IsAo = Janus.Windows.GridEX.TriState.Empty;
            this.cbGiaoHo.IsLuuTru = false;
            this.cbGiaoHo.Label = "Giáo họ";
            this.cbGiaoHo.Location = new System.Drawing.Point(6, 70);
            this.cbGiaoHo.MaGiaoHo = -1;
            this.cbGiaoHo.Name = "cbGiaoHo";
            this.cbGiaoHo.SelectedValue = null;
            this.cbGiaoHo.ShowNgoaiXu = false;
            this.cbGiaoHo.Size = new System.Drawing.Size(355, 25);
            this.cbGiaoHo.TabIndex = 2;
            this.cbGiaoHo.WhereSQL = "";
            // 
            // chkLuuTru
            // 
            this.chkLuuTru.AutoSize = true;
            this.chkLuuTru.Location = new System.Drawing.Point(129, 229);
            this.chkLuuTru.Name = "chkLuuTru";
            this.chkLuuTru.Size = new System.Drawing.Size(152, 17);
            this.chkLuuTru.TabIndex = 7;
            this.chkLuuTru.Text = "Tính cả trong hồ sơ lưu trữ";
            this.chkLuuTru.UseVisualStyleBackColor = true;
            // 
            // chkNullAccept
            // 
            this.chkNullAccept.AutoSize = true;
            this.chkNullAccept.Location = new System.Drawing.Point(325, 229);
            this.chkNullAccept.Name = "chkNullAccept";
            this.chkNullAccept.Size = new System.Drawing.Size(235, 17);
            this.chkNullAccept.TabIndex = 8;
            this.chkNullAccept.Text = "Tính cả những dữ liệu không có ngày tháng";
            this.chkNullAccept.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nếu nhập [Từ năm] = [Đến năm] thì xem như chỉ thống kê trong 1 năm";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotal.Location = new System.Drawing.Point(469, 258);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 13);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Tổng cộng:";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter.BackgroundImage")));
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilter.Enabled = false;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(297, 253);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(101, 23);
            this.btnFilter.TabIndex = 11;
            this.btnFilter.Text = "&Lọc lại trên lưới";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Location = new System.Drawing.Point(210, 253);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 23);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "&In danh sách";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(129, 253);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Thống kê";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtDateTo
            // 
            this.dtDateTo.AutoUpperFirstChar = false;
            this.dtDateTo.BoxLeft = 60;
            this.dtDateTo.EditEnabled = true;
            this.dtDateTo.FullInputRequired = false;
            this.dtDateTo.IsNullDate = true;
            this.dtDateTo.Label = "đến ngày";
            this.dtDateTo.Location = new System.Drawing.Point(248, 20);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(182, 26);
            this.dtDateTo.TabIndex = 1;
            this.dtDateTo.Value = ((object)(resources.GetObject("dtDateTo.Value")));
            this.dtDateTo.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.AutoUpperFirstChar = false;
            this.dtDateFrom.BoxLeft = 120;
            this.dtDateFrom.EditEnabled = true;
            this.dtDateFrom.FullInputRequired = false;
            this.dtDateFrom.IsNullDate = true;
            this.dtDateFrom.Label = "Nhập dòng từ ngày";
            this.dtDateFrom.Location = new System.Drawing.Point(6, 19);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(240, 26);
            this.dtDateFrom.TabIndex = 0;
            this.dtDateFrom.Value = ((object)(resources.GetObject("dtDateFrom.Value")));
            this.dtDateFrom.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.gxGiaoDanList1);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 291);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(770, 232);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "Kết quả thống kê";
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
            this.gxGiaoDanList1.DynamicFiltering = true;
            this.gxGiaoDanList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaoDanList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaoDanList1.GroupByBoxVisible = false;
            this.gxGiaoDanList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaoDanList1.Location = new System.Drawing.Point(3, 16);
            this.gxGiaoDanList1.Name = "gxGiaoDanList1";
            this.gxGiaoDanList1.QueryString = "";
            this.gxGiaoDanList1.RecordNavigator = true;
            this.gxGiaoDanList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaoDanList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaoDanList1.Size = new System.Drawing.Size(705, 121);
            this.gxGiaoDanList1.TabIndex = 0;
            this.gxGiaoDanList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaoDanList1.WhereSQL = "";
            // 
            // GxThongKeOnGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "GxThongKeOnGoi";
            this.Size = new System.Drawing.Size(770, 523);
            this.Load += new System.EventHandler(this.frmThongKeOnGoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoDanList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxDateField dtDateFrom;
        private GxControl.GxButton btnSearch;
        private GxControl.GxGiaoDanList gxGiaoDanList1;
        private System.Windows.Forms.Label lblTotal;
        private GxControl.GxDateField dtDateTo;
        private System.Windows.Forms.Label label1;
        private GxControl.GxButton btnPrint;
        private GxControl.GxCheckBox chkNullAccept;
        private GxControl.GxCheckBox chkLuuTru;
        protected GxControl.GxGiaoHo cbGiaoHo;
        private GxControl.GxButton btnFilter;
        private GxComboField cbChucVu;
        private GxTextField txtNoiTu;
        private GxTextField txtNoiPhucVu;
        private GxTextField txtDongTu;
    }
}