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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDotBiTichList));
            this.uiGroupBox1 = new GxControl.GxGroupBox();
            this.gxDotBiTichList1 = new GxControl.GxDotBiTichList();
            this.uiGroupBox3 = new GxControl.GxGroupBox();
            this.gxAddEdit1 = new GxControl.GxAddEdit();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLoaiBiTich = new GxControl.GxLoaiBiTich();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxDotBiTichList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.gxDotBiTichList1);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 52);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(890, 546);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "Danh sách các đợt bí tích";
            // 
            // gxDotBiTichList1
            // 
            this.gxDotBiTichList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxDotBiTichList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxDotBiTichList1.Arguments = null;
            this.gxDotBiTichList1.AutoLoadGridFormat = true;
            this.gxDotBiTichList1.ColumnAutoResize = true;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gxDotBiTichList1.DesignTimeLayout = gridEXLayout1;
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
            this.gxDotBiTichList1.SaveSettings = false;
            this.gxDotBiTichList1.Size = new System.Drawing.Size(884, 494);
            this.gxDotBiTichList1.TabIndex = 3;
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
            this.gxAddEdit1.ToolTipSelect = "Chọn gia đình";
            this.gxAddEdit1.DeleteClick += new System.EventHandler(this.gxAddEdit1_DeleteClick);
            this.gxAddEdit1.EditClick += new System.EventHandler(this.gxAddEdit1_EditClick);
            this.gxAddEdit1.AddClick += new System.EventHandler(this.gxAddEdit1_AddClick);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.label1);
            this.uiGroupBox2.Controls.Add(this.cbLoaiBiTich);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(890, 52);
            this.uiGroupBox2.TabIndex = 0;
            this.uiGroupBox2.Text = "Giáo họ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "(Hãy chọn 1 loại bí tích trước khi làm việc tiếp)";
            // 
            // cbLoaiBiTich
            // 
            this.cbLoaiBiTich.AutoUpperFirstChar = false;
            this.cbLoaiBiTich.BoxLeft = 0;
            this.cbLoaiBiTich.EditEnabled = true;
            this.cbLoaiBiTich.GridBiTichList = this.gxDotBiTichList1;
            this.cbLoaiBiTich.Label = "Loại bí tích";
            this.cbLoaiBiTich.Location = new System.Drawing.Point(12, 19);
            this.cbLoaiBiTich.Name = "cbLoaiBiTich";
            this.cbLoaiBiTich.SelectedValue = null;
            this.cbLoaiBiTich.Size = new System.Drawing.Size(260, 27);
            this.cbLoaiBiTich.TabIndex = 0;
            this.cbLoaiBiTich.Value = -1;
            // 
            // frmDotBiTichList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(890, 598);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Name = "frmDotBiTichList";
            this.Text = "Sổ bí tích";
            this.Load += new System.EventHandler(this.frmDotBiTichList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
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
    }
}