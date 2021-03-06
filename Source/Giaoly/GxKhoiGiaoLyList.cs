using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using GxGlobal;

namespace GxControl
{
    public partial class GxKhoiGiaoLyList : GxGrid
    {
        //private ContextMenu contextMenu = new ContextMenu();
        //protected bool choNhapMaRieng = false;

        //private bool allowEditGiaDinh = true;

        //public bool AllowEditGiaDinh
        //{
        //    get { return allowEditGiaDinh; }
        //    set { allowEditGiaDinh = value; }
        //}

        public GxKhoiGiaoLyList()
        {
            InitializeComponent();
            //QueryString = SqlConstants.SELECT_GIADINH_LIST;

            //MenuItem item1 = new MenuItem("Chứng nhận hôn phối");
            //item1.Click += new EventHandler(item1_Click);

            //MenuItem item2 = new MenuItem("Xem chi tiết");
            //item2.Click += new EventHandler(item2_Click);

            //MenuItem item3 = new MenuItem("In sổ gia đình");
            //item3.Click += new EventHandler(item3_Click);

            //contextMenu.MenuItems.Add(item1);
            ////contextMenu.MenuItems.Add(item2);
            //contextMenu.MenuItems.Add(item3);
            //this.ContextMenu = contextMenu;
            //choNhapMaRieng = (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIADINH) == GxConstants.CF_TRUE);
        }

     
        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();
            this.ColumnAutoResize = false;
            //this.AllowEdit = InheritableBoolean.True;

            GridEXColumn col1 = this.RootTable.Columns.Add("MaKhoi", ColumnType.Text);
            col1.Width = 50;
            col1.BoundMode = ColumnBoundMode.Bound;
            col1.DataMember = "MaKhoi";
            col1.Caption = "Mã khối";
            col1.FilterEditType = FilterEditType.Combo;

            GridEXColumn col2 = this.RootTable.Columns.Add("TenKhoi", ColumnType.Text);
            col2.Width = 250;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = "TenKhoi";
            col2.Caption = "Tên khối";
            col2.FilterEditType = FilterEditType.Combo;

            GridEXColumn col3 = this.RootTable.Columns.Add("NguoiQuanLy", ColumnType.Text);
            col3.Width = 250;
            col3.BoundMode = ColumnBoundMode.Bound;
            col3.DataMember = "NguoiQuanLy";
            col3.Caption = "Người quản lý";
            col3.FilterEditType = FilterEditType.Combo;

            GridEXColumn col4 = this.RootTable.Columns.Add("GhiChu", ColumnType.Text);
            col4.Width = 200;
            col4.BoundMode = ColumnBoundMode.Bound;
            col4.DataMember = "GhiChu";
            col4.Caption = "Ghi chú";
            col4.FilterEditType = FilterEditType.Combo;

            SetGridColumnWidth();
        }

        public override void LoadData()
        {
            if (Memory.IsDesignMode) return;
            try
            {
                LoadData(QueryString, Arguments);

                //if (!Memory.ShowError() && tbl != null)
                //{
                //    tbl.TableName = GiaDinhConst.TableName;
                //    this.DataSource = tbl;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxKhoiGiaoLyList, LoadData)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        
    }
}
