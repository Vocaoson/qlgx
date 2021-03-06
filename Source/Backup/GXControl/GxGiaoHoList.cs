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
    public partial class GxGiaoHoList : GxGrid
    {
        public GxGiaoHoList()
        {
            InitializeComponent();
            QueryString = SqlConstants.SELECT_GIAOHO;
        }

        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();
            //GridEXColumn col1 = this.RootTable.Columns.Add(GiaoHoConst.MaGiaoHo, ColumnType.Text);
            //col1.Width = 80;
            //col1.BoundMode = ColumnBoundMode.Bound;
            //col1.DataMember = GiaoHoConst.MaGiaoHo;
            //col1.Caption = "Mã giáo họ";

            GridEXColumn col2 = this.RootTable.Columns.Add(GiaoHoConst.TenGiaoHo, ColumnType.Text);
            col2.Width = 200;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = GiaoHoConst.TenGiaoHo;
            col2.FilterEditType = FilterEditType.Combo;
            col2.Caption = "Tên giáo họ";

            RootTable.RowHeight = 20;
            this.ColumnHeaders = InheritableBoolean.True;
            this.RowHeaderContent = RowHeaderContent.RowHeaderText;
            this.RowHeaders = InheritableBoolean.True;
            this.FilterMode = FilterMode.None;
        }

        public override void LoadData()
        {
            if (Memory.IsDesignMode) return;
            LoadData(QueryString, Arguments);
        }

    }
}
