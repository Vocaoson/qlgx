namespace GxControl
{
    partial class frmChuyenXu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenXu));
            this.gxCommand1 = new GxControl.GxCommand();
            this.uiGroupBox2 = new GxControl.GxGroupBox();
            this.gxChuyenXuList1 = new GxControl.GxChuyenXuList();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gxChuyenXuList1)).BeginInit();
            this.SuspendLayout();
            // 
            // gxCommand1
            // 
            this.gxCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gxCommand1.Location = new System.Drawing.Point(0, 366);
            this.gxCommand1.Name = "gxCommand1";
            this.gxCommand1.Size = new System.Drawing.Size(551, 45);
            this.gxCommand1.TabIndex = 1;
            this.gxCommand1.ToolTipCancel = "Đóng màn hình và bỏ qua những thay đổi";
            this.gxCommand1.ToolTipOK = "Đóng màn hình và cập nhật thông tin";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.gxChuyenXuList1);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(551, 366);
            this.uiGroupBox2.TabIndex = 0;
            this.uiGroupBox2.Text = "Lịch sử chuyển xứ";
            // 
            // gxChuyenXuList1
            // 
            this.gxChuyenXuList1.AllowColumnDrag = false;
            this.gxChuyenXuList1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gxChuyenXuList1.ColumnAutoResize = true;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gxChuyenXuList1.DesignTimeLayout = gridEXLayout1;
            this.gxChuyenXuList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gxChuyenXuList1.DynamicFiltering = true;
            this.gxChuyenXuList1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gxChuyenXuList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gxChuyenXuList1.GroupByBoxVisible = false;
            this.gxChuyenXuList1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gxChuyenXuList1.KeepRowSettings = true;
            this.gxChuyenXuList1.Location = new System.Drawing.Point(3, 16);
            this.gxChuyenXuList1.MaGiaoDan = -1;
            this.gxChuyenXuList1.Name = "gxChuyenXuList1";
            this.gxChuyenXuList1.RecordNavigator = true;
            this.gxChuyenXuList1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gxChuyenXuList1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gxChuyenXuList1.SaveSettings = false;
            this.gxChuyenXuList1.Size = new System.Drawing.Size(545, 347);
            this.gxChuyenXuList1.TabIndex = 0;
            // 
            // frmChuyenXu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 411);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.gxCommand1);
            this.Name = "frmChuyenXu";
            this.Text = "Lịch sử chuyển xứ";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gxChuyenXuList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GxControl.GxCommand gxCommand1;
        private GxControl.GxGroupBox uiGroupBox2;
        private GxControl.GxChuyenXuList gxChuyenXuList1;
    }
}