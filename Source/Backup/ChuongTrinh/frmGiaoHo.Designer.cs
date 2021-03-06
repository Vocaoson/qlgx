namespace GiaoXu
{
    partial class frmGiaoHo
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
            this.txtTenGiaoHo = new GxControl.GxTextField();
            this.gxAddEdit1 = new GxControl.GxAddEdit();
            this.gxGiaoHoList1 = new GxControl.GxGiaoHoList();
            this.txtMaGiaoHo = new GxControl.GxTextField();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.uiGroupBox3 = new GxControl.GxGroupBox();
            this.gxAddEdit2 = new GxControl.GxAddEdit();
            this.gxCommand1 = new GxControl.GxCommand();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoHoList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtTenGiaoHo);
            this.uiGroupBox1.Controls.Add(this.gxAddEdit1);
            this.uiGroupBox1.Controls.Add(this.txtMaGiaoHo);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(854, 89);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Nhập giáo họ";
            // 
            // txtTenGiaoHo
            // 
            this.txtTenGiaoHo.AutoCompleteEnabled = true;
            this.txtTenGiaoHo.AutoUpperFirstChar = true;
            this.txtTenGiaoHo.BoxLeft = 80;
            this.txtTenGiaoHo.EditEnabled = true;
            this.txtTenGiaoHo.Label = "Tên giáo họ";
            this.txtTenGiaoHo.Location = new System.Drawing.Point(7, 19);
            this.txtTenGiaoHo.MaxLength = 255;
            this.txtTenGiaoHo.MultiLine = false;
            this.txtTenGiaoHo.Name = "txtTenGiaoHo";
            this.txtTenGiaoHo.NumberInputRequired = true;
            this.txtTenGiaoHo.NumberMode = false;
            this.txtTenGiaoHo.ReadOnly = false;
            this.txtTenGiaoHo.Size = new System.Drawing.Size(457, 25);
            this.txtTenGiaoHo.TabIndex = 1;
            // 
            // gxAddEdit1
            // 
            this.gxAddEdit1.BackColor = System.Drawing.Color.Transparent;
            this.gxAddEdit1.CaptionDisplayMode = GxGlobal.CaptionDisplayMode.Full;
            this.gxAddEdit1.DisplayMode = GxGlobal.DisplayMode.Mode2;
            this.gxAddEdit1.GridData = this.gxGiaoHoList1;
            this.gxAddEdit1.Location = new System.Drawing.Point(22, 50);
            this.gxAddEdit1.Name = "gxAddEdit1";
            this.gxAddEdit1.Size = new System.Drawing.Size(366, 25);
            this.gxAddEdit1.TabIndex = 2;
            this.gxAddEdit1.ToolTipAdd = "Thêm mới một giáo họ";
            this.gxAddEdit1.ToolTipButton1 = "";
            this.gxAddEdit1.ToolTipButton2 = "";
            this.gxAddEdit1.ToolTipDelete = "Xóa giáo họ được chọn";
            this.gxAddEdit1.ToolTipEdit = "Sửa giáo họ được chọn";
            this.gxAddEdit1.ToolTipFind = "";
            this.gxAddEdit1.ToolTipPrint = "";
            this.gxAddEdit1.ToolTipReload = "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
                "ếm";
            this.gxAddEdit1.ToolTipSelect = "Cập nhật những thay đổi";
            this.gxAddEdit1.DeleteClick += new System.EventHandler(this.gxAddEdit1_DeleteClick);
            this.gxAddEdit1.EditClick += new System.EventHandler(this.gxAddEdit1_EditClick);
            this.gxAddEdit1.AddClick += new System.EventHandler(this.gxAddEdit1_AddClick);
            this.gxAddEdit1.SelectClick += new System.EventHandler(this.gxAddEdit1_UpdateClick);
            // 
            // gxGiaoHoList1
            // 
            this.gxGiaoHoList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxGiaoHoList1.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxGiaoHoList1.Arguments = null;
            this.gxGiaoHoList1.AutoLoadGridFormat = true;
            this.gxGiaoHoList1.ColumnAutoResize = true;
            this.gxGiaoHoList1.DisableParentOnLoadData = true;
            this.gxGiaoHoList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxGiaoHoList1.DynamicFiltering = true;
            this.gxGiaoHoList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxGiaoHoList1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxGiaoHoList1.GroupByBoxVisible = false;
            this.gxGiaoHoList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxGiaoHoList1.Location = new System.Drawing.Point(3, 49);
            this.gxGiaoHoList1.Name = "gxGiaoHoList1";
            this.gxGiaoHoList1.QueryString = "SELECT * FROM GiaoHo WHERE DaXoa = 0 ";
            this.gxGiaoHoList1.RecordNavigator = true;
            this.gxGiaoHoList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxGiaoHoList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gxGiaoHoList1.Size = new System.Drawing.Size(848, 440);
            this.gxGiaoHoList1.TabIndex = 0;
            this.gxGiaoHoList1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gxGiaoHoList1.WhereSQL = "";
            this.gxGiaoHoList1.Click += new System.EventHandler(this.gxGiaoHoList1_Click);
            this.gxGiaoHoList1.RowCountChanged += new System.EventHandler(this.gxGiaoHoList1_RowCountChanged);
            this.gxGiaoHoList1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gxGiaoHoList1_RowDoubleClick);
            this.gxGiaoHoList1.CurrentCellChanged += new System.EventHandler(this.gxGiaoHoList1_CurrentCellChanged);
            this.gxGiaoHoList1.SelectionChanged += new System.EventHandler(this.gxGiaoHoList1_SelectionChanged);
            // 
            // txtMaGiaoHo
            // 
            this.txtMaGiaoHo.AutoCompleteEnabled = true;
            this.txtMaGiaoHo.AutoUpperFirstChar = false;
            this.txtMaGiaoHo.BoxLeft = 80;
            this.txtMaGiaoHo.EditEnabled = false;
            this.txtMaGiaoHo.Label = "Mã giáo họ";
            this.txtMaGiaoHo.Location = new System.Drawing.Point(7, 17);
            this.txtMaGiaoHo.MaxLength = 32767;
            this.txtMaGiaoHo.MultiLine = false;
            this.txtMaGiaoHo.Name = "txtMaGiaoHo";
            this.txtMaGiaoHo.NumberInputRequired = true;
            this.txtMaGiaoHo.NumberMode = false;
            this.txtMaGiaoHo.ReadOnly = false;
            this.txtMaGiaoHo.Size = new System.Drawing.Size(203, 25);
            this.txtMaGiaoHo.TabIndex = 0;
            this.txtMaGiaoHo.Visible = false;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.gxGiaoHoList1);
            this.uiGroupBox2.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 89);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(854, 492);
            this.uiGroupBox2.TabIndex = 0;
            this.uiGroupBox2.Text = "Danh sách các giáo họ";
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground;
            this.uiGroupBox3.Controls.Add(this.gxAddEdit2);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox3.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox3.Location = new System.Drawing.Point(3, 16);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(848, 33);
            this.uiGroupBox3.TabIndex = 3;
            // 
            // gxAddEdit2
            // 
            this.gxAddEdit2.BackColor = System.Drawing.Color.Transparent;
            this.gxAddEdit2.CaptionDisplayMode = GxGlobal.CaptionDisplayMode.Full;
            this.gxAddEdit2.DisplayMode = GxGlobal.DisplayMode.Mode3;
            this.gxAddEdit2.GridData = null;
            this.gxAddEdit2.Location = new System.Drawing.Point(12, 5);
            this.gxAddEdit2.Name = "gxAddEdit2";
            this.gxAddEdit2.Size = new System.Drawing.Size(202, 29);
            this.gxAddEdit2.TabIndex = 1;
            this.gxAddEdit2.ToolTipAdd = "Quản lý danh sách các gia đình của giáo họ được chọn";
            this.gxAddEdit2.ToolTipButton1 = "";
            this.gxAddEdit2.ToolTipButton2 = "";
            this.gxAddEdit2.ToolTipDelete = "Xóa";
            this.gxAddEdit2.ToolTipEdit = "";
            this.gxAddEdit2.ToolTipFind = "";
            this.gxAddEdit2.ToolTipPrint = "";
            this.gxAddEdit2.ToolTipReload = "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
                "ếm";
            this.gxAddEdit2.ToolTipSelect = "Chọn";
            // 
            // gxCommand1
            // 
            this.gxCommand1.AllowHotkey = false;
            this.gxCommand1.DisplayMode = GxGlobal.DisplayMode.Full;
            this.gxCommand1.Location = new System.Drawing.Point(0, 536);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.OKIsAccept = false;
            this.gxCommand1.Size = new System.Drawing.Size(854, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipButton1 = "";
            this.gxCommand1.ToolTipCancel = "";
            this.gxCommand1.ToolTipOK = "";
            this.gxCommand1.Visible = false;
            this.gxCommand1.OnCancel += new System.EventHandler(this.gxCommand1_OnCancel);
            this.gxCommand1.OnOK += new System.EventHandler(this.gxCommand1_OnOK);
            // 
            // frmGiaoHo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 581);
            this.ControlBox = false;
            this.Controls.Add(this.gxCommand1);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "frmGiaoHo";
            this.Text = "Nhập giáo họ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGiaoHo_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmGiaoHo_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxGiaoHoList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxGroupBox uiGroupBox1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxCommand gxCommand1;
        private GxControl.GxAddEdit gxAddEdit1;
        private GxControl.GxTextField txtMaGiaoHo;
        private GxControl.GxGiaoHoList gxGiaoHoList1;
        private GxControl.GxTextField txtTenGiaoHo;
        private GxControl.GxAddEdit gxAddEdit2;
        private GxControl.GxGroupBox uiGroupBox3;
    }
}