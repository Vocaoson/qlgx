namespace GiaoXu
{
    partial class frmKiemTraGiaDinhList
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
            Janus.Windows.GridEX.GridEXLayout GxGiaDinhLoiList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemTraGiaDinhList));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.gxGiaDinhList1 = new GxControl.GxGiaDinhLoiList();
            this.uiGroupBox3 = new GxControl.GxGroupBox();
            this.gxAddEdit1 = new GxControl.GxAddEdit();
            this.gxCommand1 = new GxControl.GxCommand();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbGiaoHo = new GxControl.GxGiaoHo();
            this.gxGroupBox1 = new GxControl.GxGroupBox();
            this.btnKiemTra = new GxControl.GxButton();
            this.chkSaiTuoiConCaiChaMe = new GxControl.GxCheckBox();
            this.chkCacVanDeKhac = new GxControl.GxCheckBox();
            this.chkNgayHPKoHopLe = new GxControl.GxCheckBox();
            this.chkKhongCoNgayHP = new GxControl.GxCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).BeginInit();
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
            this.uiGroupBox1.Controls.Add(this.gxGiaDinhList1);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 152);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(890, 446);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "Danh sách các gia đình";
            // 
            // gxGiaDinhList1
            // 
            this.gxGiaDinhList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxGiaDinhList1.AllowEditGiaDinh = true;
            this.gxGiaDinhList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaDinhList1.Arguments = null;
            this.gxGiaDinhList1.AutoLoadGridFormat = true;
            this.gxGiaDinhList1.ColumnAutoResize = true;
            GxGiaDinhLoiList_DesignTimeLayout.LayoutString = resources.GetString("GxGiaDinhLoiList_DesignTimeLayout.LayoutString");
            this.gxGiaDinhList1.DesignTimeLayout = GxGiaDinhLoiList_DesignTimeLayout;
            this.gxGiaDinhList1.DisableParentOnLoadData = true;
            this.gxGiaDinhList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxGiaDinhList1.DynamicFiltering = true;
            this.gxGiaDinhList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaDinhList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaDinhList1.GroupByBoxVisible = false;
            this.gxGiaDinhList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaDinhList1.Location = new System.Drawing.Point(3, 49);
            this.gxGiaDinhList1.Name = "gxGiaDinhList1";
            this.gxGiaDinhList1.Operation = GxGlobal.GxOperation.EDIT;
            this.gxGiaDinhList1.QueryString = "SELECT * FROM SELECT_GIADINH_LIST WHERE 1 ";
            this.gxGiaDinhList1.RecordNavigator = true;
            this.gxGiaDinhList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaDinhList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaDinhList1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.gxGiaDinhList1.Size = new System.Drawing.Size(884, 394);
            this.gxGiaDinhList1.TabIndex = 0;
            this.gxGiaDinhList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaDinhList1.WhereSQL = "";
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
            this.gxAddEdit1.GridData = this.gxGiaDinhList1;
            this.gxAddEdit1.Location = new System.Drawing.Point(5, 3);
            this.gxAddEdit1.Name = "gxAddEdit1";
            this.gxAddEdit1.Size = new System.Drawing.Size(63, 29);
            this.gxAddEdit1.TabIndex = 0;
            this.gxAddEdit1.ToolTipAdd = "Thêm gia đình";
            this.gxAddEdit1.ToolTipButton1 = "";
            this.gxAddEdit1.ToolTipButton2 = "";
            this.gxAddEdit1.ToolTipDelete = "Xóa gia đình được chọn";
            this.gxAddEdit1.ToolTipEdit = "Sửa gia đình được chọn";
            this.gxAddEdit1.ToolTipFind = "";
            this.gxAddEdit1.ToolTipPrint = "";
            this.gxAddEdit1.ToolTipReload = "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
                "ếm";
            this.gxAddEdit1.ToolTipSelect = "In danh sách gia đình trong lưới hiện tại";
            this.gxAddEdit1.DeleteClick += new System.EventHandler(this.gxAddEdit1_DeleteClick);
            this.gxAddEdit1.EditClick += new System.EventHandler(this.gxAddEdit1_EditClick);
            this.gxAddEdit1.PrintClick += new System.EventHandler(this.btnInDanhSach_Click);
            this.gxAddEdit1.AddClick += new System.EventHandler(this.gxAddEdit1_AddClick);
            // 
            // gxCommand1
            // 
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Mode2;
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 553);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(890, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "";
            this.gxCommand1.ToolTipOK = "";
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
            this.uiGroupBox2.Text = "Giáo họ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotal.Location = new System.Drawing.Point(318, 24);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Tổng cộng:";
            // 
            // cbGiaoHo
            // 
            this.cbGiaoHo.AutoLoadGrid = true;
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
            // gxGroupBox1
            // 
            this.gxGroupBox1.Controls.Add(this.btnKiemTra);
            this.gxGroupBox1.Controls.Add(this.chkSaiTuoiConCaiChaMe);
            this.gxGroupBox1.Controls.Add(this.chkCacVanDeKhac);
            this.gxGroupBox1.Controls.Add(this.chkNgayHPKoHopLe);
            this.gxGroupBox1.Controls.Add(this.chkKhongCoNgayHP);
            this.gxGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gxGroupBox1.Location = new System.Drawing.Point(0, 50);
            this.gxGroupBox1.Name = "gxGroupBox1";
            this.gxGroupBox1.Size = new System.Drawing.Size(890, 102);
            this.gxGroupBox1.TabIndex = 2;
            this.gxGroupBox1.Text = "Loại kiểm tra";
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKiemTra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKiemTra.BackgroundImage")));
            this.btnKiemTra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKiemTra.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnKiemTra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnKiemTra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKiemTra.Location = new System.Drawing.Point(44, 65);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(101, 23);
            this.btnKiemTra.TabIndex = 3;
            this.btnKiemTra.Text = "Bắt đầu kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // chkSaiTuoiConCaiChaMe
            // 
            this.chkSaiTuoiConCaiChaMe.AutoSize = true;
            this.chkSaiTuoiConCaiChaMe.Checked = true;
            this.chkSaiTuoiConCaiChaMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaiTuoiConCaiChaMe.Location = new System.Drawing.Point(44, 42);
            this.chkSaiTuoiConCaiChaMe.Name = "chkSaiTuoiConCaiChaMe";
            this.chkSaiTuoiConCaiChaMe.Size = new System.Drawing.Size(288, 17);
            this.chkSaiTuoiConCaiChaMe.TabIndex = 2;
            this.chkSaiTuoiConCaiChaMe.Text = "Khoảng cách tuổi giữa con cái và cha mẹ không hợp lý";
            this.chkSaiTuoiConCaiChaMe.UseVisualStyleBackColor = true;
            // 
            // chkCacVanDeKhac
            // 
            this.chkCacVanDeKhac.AutoSize = true;
            this.chkCacVanDeKhac.Checked = true;
            this.chkCacVanDeKhac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCacVanDeKhac.Location = new System.Drawing.Point(443, 19);
            this.chkCacVanDeKhac.Name = "chkCacVanDeKhac";
            this.chkCacVanDeKhac.Size = new System.Drawing.Size(109, 17);
            this.chkCacVanDeKhac.TabIndex = 1;
            this.chkCacVanDeKhac.Text = "Các vấn đề khác";
            this.chkCacVanDeKhac.UseVisualStyleBackColor = true;
            // 
            // chkNgayHPKoHopLe
            // 
            this.chkNgayHPKoHopLe.AutoSize = true;
            this.chkNgayHPKoHopLe.Checked = true;
            this.chkNgayHPKoHopLe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNgayHPKoHopLe.Location = new System.Drawing.Point(192, 19);
            this.chkNgayHPKoHopLe.Name = "chkNgayHPKoHopLe";
            this.chkNgayHPKoHopLe.Size = new System.Drawing.Size(233, 17);
            this.chkNgayHPKoHopLe.TabIndex = 1;
            this.chkNgayHPKoHopLe.Text = "Hôn phối trước tuổi (nam 20 tuổi, nữ 18 tuổi)";
            this.chkNgayHPKoHopLe.UseVisualStyleBackColor = true;
            // 
            // chkKhongCoNgayHP
            // 
            this.chkKhongCoNgayHP.AutoSize = true;
            this.chkKhongCoNgayHP.Checked = true;
            this.chkKhongCoNgayHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKhongCoNgayHP.Location = new System.Drawing.Point(44, 19);
            this.chkKhongCoNgayHP.Name = "chkKhongCoNgayHP";
            this.chkKhongCoNgayHP.Size = new System.Drawing.Size(142, 17);
            this.chkKhongCoNgayHP.TabIndex = 0;
            this.chkKhongCoNgayHP.Text = "Không có ngày hôn phối";
            this.chkKhongCoNgayHP.UseVisualStyleBackColor = true;
            // 
            // frmKiemTraGiaDinhList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(890, 598);
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.gxGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Name = "frmKiemTraGiaDinhList";
            this.Text = "Kiểm tra dữ liệu gia đình";
            this.Load += new System.EventHandler(this.frmGiaDinhList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaDinhList1)).EndInit();
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
        private GxControl.GxGiaDinhLoiList gxGiaDinhList1;
        private GxControl.GxCommand gxCommand1;
        private GxControl.GxGroupBox uiGroupBox3;
        private GxControl.GxAddEdit gxAddEdit1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxGiaoHo cbGiaoHo;
        private System.Windows.Forms.Label lblTotal;
        private GxControl.GxGroupBox gxGroupBox1;
        private GxControl.GxButton btnKiemTra;
        private GxControl.GxCheckBox chkSaiTuoiConCaiChaMe;
        private GxControl.GxCheckBox chkNgayHPKoHopLe;
        private GxControl.GxCheckBox chkKhongCoNgayHP;
        private GxControl.GxCheckBox chkCacVanDeKhac;
    }
}