namespace GxControl
{
    partial class GxAddEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GxAddEdit));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnEdit = new GxControl.GxButton();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnNew = new GxControl.GxButton();
            this.btnDelete = new GxControl.GxButton();
            this.btnReload = new GxControl.GxButton();
            this.btnPrint = new GxControl.GxButton();
            this.btnSelect = new GxControl.GxButton();
            this.btn2 = new GxControl.GxButton();
            this.btn1 = new GxControl.GxButton();
            this.btnFind = new GxControl.GxButton();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEdit.ImageKey = "Edit";
            this.btnEdit.ImageList = this.ImageList;
            this.btnEdit.Location = new System.Drawing.Point(92, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&S";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnEdit, "Sửa");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnEdit.Click += new System.EventHandler(this.btn_Click);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Add");
            this.ImageList.Images.SetKeyName(1, "Delete");
            this.ImageList.Images.SetKeyName(2, "Edit");
            this.ImageList.Images.SetKeyName(3, "Select");
            this.ImageList.Images.SetKeyName(4, "Search");
            this.ImageList.Images.SetKeyName(5, "Print");
            this.ImageList.Images.SetKeyName(6, "Refresh");
            this.ImageList.Images.SetKeyName(7, "ExportExcel");
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNew.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.ImageKey = "Add";
            this.btnNew.ImageList = this.ImageList;
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(40, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&T";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnNew, "Thêm");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnNew.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDelete.ImageKey = "Delete";
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Location = new System.Drawing.Point(46, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&X";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDelete, "Loại bỏ khỏi danh sách trên lưới");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnDelete.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnReload
            // 
            this.btnReload.AutoSize = true;
            this.btnReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReload.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReload.ImageKey = "Refresh";
            this.btnReload.ImageList = this.ImageList;
            this.btnReload.Location = new System.Drawing.Point(379, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(41, 23);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "&R";
            this.btnReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnReload, "Lấy lại dữ liệu trong chương trình và hiện lên lưới như khi chưa thực hiện tìm ki" +
        "ếm");
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Visible = false;
            this.btnReload.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnReload.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = true;
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPrint.ImageKey = "Print";
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Location = new System.Drawing.Point(229, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(40, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&P";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnPrint, "In danh sách trên lưới");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnPrint.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelect.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.BackgroundImage")));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSelect.ImageKey = "Select";
            this.btnSelect.ImageList = this.ImageList;
            this.btnSelect.Location = new System.Drawing.Point(138, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(40, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "&C";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnSelect, "Chọn");
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnSelect.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn2
            // 
            this.btn2.AutoSize = true;
            this.btn2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn2.BackgroundImage")));
            this.btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn2.ImageKey = "ExportExcel";
            this.btn2.ImageList = this.ImageList;
            this.btn2.Location = new System.Drawing.Point(327, 0);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(46, 23);
            this.btn2.TabIndex = 5;
            this.btn2.Text = "B&2";
            this.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Visible = false;
            this.btn2.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn1
            // 
            this.btn1.AutoSize = true;
            this.btn1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn1.BackgroundImage")));
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn1.ImageKey = "ExportExcel";
            this.btn1.ImageList = this.ImageList;
            this.btn1.Location = new System.Drawing.Point(275, 0);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(46, 23);
            this.btn1.TabIndex = 5;
            this.btn1.Text = "B&1";
            this.btn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            this.btn1.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = true;
            this.btnFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFind.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFind.BackgroundImage")));
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFind.ImageKey = "Search";
            this.btnFind.ImageList = this.ImageList;
            this.btnFind.Location = new System.Drawing.Point(184, 0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(39, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "&F";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.VisibleChanged += new System.EventHandler(this.button_VisibleChanged);
            this.btnFind.Click += new System.EventHandler(this.btn_Click);
            // 
            // GxAddEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnSelect);
            this.Name = "GxAddEdit";
            this.Size = new System.Drawing.Size(612, 28);
            this.Load += new System.EventHandler(this.GXAddEdit_Load);
            this.Resize += new System.EventHandler(this.GXAddEdit_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GxButton btnNew;
        public GxButton btnSelect;
        public GxButton btnEdit;
        public GxButton btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        public GxButton btnFind;
        public GxButton btnPrint;
        public GxButton btn1;
        public GxButton btn2;
        public GxButton btnReload;
        public System.Windows.Forms.ImageList ImageList;

    }
}
