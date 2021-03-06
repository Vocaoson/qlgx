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
    public partial class GxLinhMucList : GxGrid
    {
        public GxLinhMucList()
        {
            InitializeComponent();
            QueryString = SqlConstants.SELECT_LINHMUC_LIST;
        }

        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();
            GridEXColumn col1 = this.RootTable.Columns.Add(LinhMucConst.MaLinhMuc, ColumnType.Text);
            col1.Width = 80;
            col1.BoundMode = ColumnBoundMode.Bound;
            col1.DataMember = LinhMucConst.MaLinhMuc;
            col1.Caption = "Mã Linh mục";

            GridEXColumn col2 = this.RootTable.Columns.Add(LinhMucConst.TenThanh, ColumnType.Text);
            col2.Width = 100;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = LinhMucConst.TenThanh;
            col2.Caption = "Tên thánh"; 
            col2.FilterEditType = FilterEditType.Combo;

            GridEXColumn col3 = this.RootTable.Columns.Add(LinhMucConst.HoTen, ColumnType.Text);
            col3.Width = 200;
            col3.BoundMode = ColumnBoundMode.Bound;
            col3.DataMember = LinhMucConst.HoTen;
            col3.Caption = "Họ tên";
            col3.FilterEditType = FilterEditType.Combo;

            GridEXColumn col4 = this.RootTable.Columns.Add(LinhMucConst.NgaySinh, ColumnType.Text);
            col4.Width = 100;
            col4.EditButtonDisplayMode = CellButtonDisplayMode.EditingCell;
            col4.ButtonDisplayMode = CellButtonDisplayMode.CurrentCell;
            col4.EditType = EditType.NoEdit;
            col4.BoundMode = ColumnBoundMode.Bound;
            col4.DataMember = LinhMucConst.NgaySinh;
            col4.Caption = "Ngày sinh";
            col4.FormatMode = FormatMode.UseIFormattable;
            col4.DefaultGroupFormatMode = FormatMode.UseIFormattable;
            col4.TextAlignment = TextAlignment.Far;
            col4.DefaultGroupFormatString = "dd/MM/yyyy";
            col4.FormatString = "dd/MM/yyyy";

            GridEXColumn col5 = this.RootTable.Columns.Add(LinhMucConst.TuNgay, ColumnType.Text);
            col5.Width = 100;
            col5.EditButtonDisplayMode = CellButtonDisplayMode.EditingCell;
            col5.ButtonDisplayMode = CellButtonDisplayMode.CurrentCell;
            col5.EditType = EditType.NoEdit;
            col5.BoundMode = ColumnBoundMode.Bound;
            col5.DataMember = LinhMucConst.TuNgay;
            col5.Caption = "Từ ngày";
            col5.FormatMode = FormatMode.UseIFormattable;
            col5.DefaultGroupFormatMode = FormatMode.UseIFormattable;
            col5.TextAlignment = TextAlignment.Far;
            col5.DefaultGroupFormatString = "dd/MM/yyyy";
            col5.FormatString = "dd/MM/yyyy";

            GridEXColumn col6 = this.RootTable.Columns.Add(LinhMucConst.DenNgay, ColumnType.Text);
            col6.Width = 100;
            col6.EditButtonDisplayMode = CellButtonDisplayMode.EditingCell;
            col6.ButtonDisplayMode = CellButtonDisplayMode.CurrentCell;
            col6.EditType = EditType.NoEdit;
            col6.BoundMode = ColumnBoundMode.Bound;
            col6.DataMember = LinhMucConst.DenNgay;
            col6.Caption = "Đến ngày";
            col6.FormatMode = FormatMode.UseIFormattable;
            col6.DefaultGroupFormatMode = FormatMode.UseIFormattable;
            col6.TextAlignment = TextAlignment.Far;
            col6.DefaultGroupFormatString = "dd/MM/yyyy";
            col6.FormatString = "dd/MM/yyyy";

            GridEXColumn col7 = this.RootTable.Columns.Add(LinhMucConst.ChucVu, ColumnType.Text);
            col7.Width = 100;
            col7.BoundMode = ColumnBoundMode.Bound;
            col7.DataMember = LinhMucConst.ChucVu;
            col7.Caption = "Chức vụ";
            col7.FilterEditType = FilterEditType.Combo;
        }

        public override void LoadData()
        {
            if (Memory.IsDesignMode) return;
            LoadData(QueryString, Arguments);
        }

    }
}
