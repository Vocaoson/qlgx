namespace GiaoXu
{
    partial class frmDotBiTichList
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
            Janus.Windows.GridEX.GridEXLayout gxDotBiTichList1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDotBiTichList));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.gxHonPhoiList1 = new GxControl.GxHonPhoiList();
            this.gxDotBiTichList1 = new GxControl.GxDotBiTichList();
            this.uiGroupBox3 = new GxControl.GxGroupBox();
            this.gxAddEdit1 = new GxControl.GxAddEdit();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.btnSearch = new GxControl.GxButton();
            this.cbDenNam = new GxControl.GxComboField();
            this.cbTuNam = new GxControl.GxComboField();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLoaiBiTich = new GxControl.GxLoaiBiTich();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxHonPhoiList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gxDotBiTichList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.gxHonPhoiList1);
            this.uiGroupBox1.Controls.Add(this.gxDotBiTichList1);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 95);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(890, 503);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "Danh sách các đợt bí tích";
            this.uiGroupBox1.Visible = false;
            // 
            // gxHonPhoiList1
            // 
            this.gxHonPhoiList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxHonPhoiList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxHonPhoiList1.Arguments = null;
            this.gxHonPhoiList1.AutoLoadGridFormat = true;
            this.gxHonPhoiList1.ColumnAutoResize = true;
            this.gxHonPhoiList1.DisableParentOnLoadData = true;
            this.gxHonPhoiList1.DynamicFiltering = true;
            this.gxHonPhoiList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxHonPhoiList1.GroupByBoxVisible = false;
            this.gxHonPhoiList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxHonPhoiList1.ListMode = 2;
            this.gxHonPhoiList1.Location = new System.Drawing.Point(467, 118);
            this.gxHonPhoiList1.MaGiaoDan = -1;
            this.gxHonPhoiList1.Name = "gxHonPhoiList1";
            this.gxHonPhoiList1.Phai = "";
            this.gxHonPhoiList1.QueryString = "";
            this.gxHonPhoiList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxHonPhoiList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gxHonPhoiList1.Size = new System.Drawing.Size(354, 197);
            this.gxHonPhoiList1.TabIndex = 4;
            this.gxHonPhoiList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxHonPhoiList1.WhereSQL = "";
            // 
            // gxDotBiTichList1
            // 
            this.gxDotBiTichList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxDotBiTichList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxDotBiTichList1.Arguments = null;
            this.gxDotBiTichList1.AutoLoadGridFormat = true;
            this.gxDotBiTichList1.ColumnAutoResize = true;
            this.gxDotBiTichList1.DenNam = 0;
            gxDotBiTichList1_DesignTimeLayout.LayoutString = resources.GetString("gxDotBiTichList1_DesignTimeLayout.LayoutString");
            this.gxDotBiTichList1.DesignTimeLayout = gxDotBiTichList1_DesignTimeLayout;
            this.gxDotBiTichList1.DisableParentOnLoadData = true;
            this.gxDotBiTichList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxDotBiTichList1.DynamicFiltering = true;
            this.gxDotBiTichList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxDotBiTichList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxDotBiTichList1.GroupByBoxVisible = false;
            this.gxDotBiTichList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxDotBiTichList1.LoaiBiTich = -1;
            this.gxDotBiTichList1.Location = new System.Drawing.Point(3, 49);
            this.gxDotBiTichList1.Name = "gxDotBiTichList1";
            this.gxDotBiTichList1.QueryString = "";
            this.gxDotBiTichList1.RecordNavigator = true;
            this.gxDotBiTichList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxDotBiTichList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxDotBiTichList1.Size = new System.Drawing.Size(884, 451);
            this.gxDotBiTichList1.TabIndex = 3;
            this.gxDotBiTichList1.TuNam = 0;
            this.gxDotBiTichList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxDotBiTichList1.WhereSQL = "";
            this.gxDotBiTichList1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gxDotBiTichList1_RowDoubleClick);
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
            this.gxAddEdit1.DisplayMode = GxGlobal.DisplayMode.Mode3;
            this.gxAddEdit1.GridData = this.gxDotBiTichList1;
            this.gxAddEdit1.Location = new System.Drawing.Point(5, 3);
            this.gxAddEdit1.Name = "gxAddEdit1";
            this.gxAddEdit1.Size = new System.Drawing.Size(213, 29);
            this.gxAddEdit1.TabIndex = 4;
            this.gxAddEdit1.ToolTipAdd = "Thêm gia đình";
            this.gxAddEdit1.ToolTipButton1 = "";
            this.gxAddEdit1.ToolTipButton2 = "";
            this.gxAddEdit1.ToolTipDelete = "Xóa gia đình được chọn";
            this.gxAddEdit1.ToolTipEdit = "Sửa gia đình được chọn";
            this.gxAddEdit1.ToolTipFind = "";
            this.gxAddEdit1.ToolTipPrint = "";
            this.gxAddEdit1.ToolTipReload = "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
    "ếm";
            this.gxAddEdit1.ToolTipSelect = "Chọn gia đình";
            this.gxAddEdit1.AddClick += new System.EventHandler(this.gxAddEdit1_AddClick);
            this.gxAddEdit1.EditClick += new System.EventHandler(this.gxAddEdit1_EditClick);
            this.gxAddEdit1.DeleteClick += new System.EventHandler(this.gxAddEdit1_DeleteClick);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.btnSearch);
            this.uiGroupBox2.Controls.Add(this.cbDenNam);
            this.uiGroupBox2.Controls.Add(this.cbTuNam);
            this.uiGroupBox2.Controls.Add(this.label1);
            this.uiGroupBox2.Controls.Add(this.cbLoaiBiTich);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(890, 95);
            this.uiGroupBox2.TabIndex = 0;
            this.uiGroupBox2.Text = "Giáo họ";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(305, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Xem dữ liệu";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbDenNam
            // 
            this.cbDenNam.AutoUpperFirstChar = false;
            this.cbDenNam.BoxLeft = 50;
            this.cbDenNam.EditEnabled = true;
            this.cbDenNam.Label = "đến năm";
            this.cbDenNam.Location = new System.Drawing.Point(174, 54);
            this.cbDenNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDenNam.MaxLength = 0;
            this.cbDenNam.Name = "cbDenNam";
            this.cbDenNam.SelectedIndex = -1;
            this.cbDenNam.SelectedText = "";
            this.cbDenNam.SelectedValue = null;
            this.cbDenNam.Size = new System.Drawing.Size(122, 26);
            this.cbDenNam.TabIndex = 2;
            // 
            // cbTuNam
            // 
            this.cbTuNam.AutoUpperFirstChar = false;
            this.cbTuNam.BoxLeft = 80;
            this.cbTuNam.EditEnabled = true;
            this.cbTuNam.Label = "Từ năm";
            this.cbTuNam.Location = new System.Drawing.Point(12, 54);
            this.cbTuNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTuNam.MaxLength = 0;
            this.cbTuNam.Name = "cbTuNam";
            this.cbTuNam.SelectedIndex = -1;
            this.cbTuNam.SelectedText = "";
            this.cbTuNam.SelectedValue = null;
            this.cbTuNam.Size = new System.Drawing.Size(154, 26);
            this.cbTuNam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "(Hãy chọn 1 loại bí tích trước khi làm việc tiếp)";
            // 
            // cbLoaiBiTich
            // 
            this.cbLoaiBiTich.AutoUpperFirstChar = false;
            this.cbLoaiBiTich.BoxLeft = 80;
            this.cbLoaiBiTich.EditEnabled = true;
            this.cbLoaiBiTich.GridBiTichList = null;
            this.cbLoaiBiTich.Label = "Loại bí tích";
            this.cbLoaiBiTich.Location = new System.Drawing.Point(12, 19);
            this.cbLoaiBiTich.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLoaiBiTich.Name = "cbLoaiBiTich";
            this.cbLoaiBiTich.SelectedValue = null;
            this.cbLoaiBiTich.Size = new System.Drawing.Size(284, 27);
            this.cbLoaiBiTich.TabIndex = 0;
            this.cbLoaiBiTich.Value = -1;
            // 
            // frmDotBiTichList
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(890, 598);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Name = "frmDotBiTichList";
            this.Text = "Sổ bí tích";
            this.Load += new System.EventHandler(this.frmDotBiTichList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxHonPhoiList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gxDotBiTichList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxGroupBox uiGroupBox3;
        private GxControl.GxAddEdit gxAddEdit1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxDotBiTichList gxDotBiTichList1;
        private GxControl.GxLoaiBiTich cbLoaiBiTich;
        private System.Windows.Forms.Label label1;
        private GxControl.GxHonPhoiList gxHonPhoiList1;
        private GxControl.GxComboField cbDenNam;
        private GxControl.GxComboField cbTuNam;
        private GxControl.GxButton btnSearch;
    }
}