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
    public partial class GxDotBiTichList : GxGrid
    {
        private int loaiBiTich = -1;

        /// <summary>
        /// Gets or sets Loai bi tich, if set valid loai bi tich (0, 1, 2), data is loaded automatically
        /// </summary>
        public int LoaiBiTich
        {
            get { return loaiBiTich; }
            set
            {
                loaiBiTich = value;

                if (!Memory.IsDesignMode)
                {
                    LoadData();
                }
            }
        }
        private int tuNam = 0;
        public int TuNam
        {
            get { return tuNam; }
            set { tuNam = value; }
        }

        private int denNam = 0;
        public int DenNam
        {
            get { return denNam; }
            set { denNam = value; }
        }

        public GxDotBiTichList()
        {
            InitializeComponent();
            //FormatGrid();
        }

        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();

            GridEXColumn col1 = this.RootTable.Columns.Add(DotBiTichConst.NgayBiTich, ColumnType.Text);
            col1.Width = 100;
            col1.EditButtonDisplayMode = CellButtonDisplayMode.EditingCell;
            col1.ButtonDisplayMode = CellButtonDisplayMode.CurrentCell;
            col1.EditType = EditType.NoEdit;
            col1.BoundMode = ColumnBoundMode.Bound;
            col1.DataMember = DotBiTichConst.NgayBiTich;
            col1.Caption = "Ngày";
            col1.FormatMode = FormatMode.UseIFormattable;
            col1.DefaultGroupFormatMode = FormatMode.UseIFormattable;
            col1.TextAlignment = TextAlignment.Far;
            col1.DefaultGroupFormatString = "dd/MM/yyyy";
            col1.FormatString = "dd/MM/yyyy";

            GridEXColumn col2 = this.RootTable.Columns.Add(DotBiTichConst.MoTa, ColumnType.Text);
            col2.Width = 200;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = DotBiTichConst.MoTa;
            col2.Caption = "Mô tả";

            GridEXColumn col3 = this.RootTable.Columns.Add(DotBiTichConst.LinhMuc, ColumnType.Text);
            col3.Width = 200;
            col3.BoundMode = ColumnBoundMode.Bound;
            col3.DataMember = DotBiTichConst.LinhMuc;
            col3.Caption = "Người ban bí tích";

            AddColumn(DotBiTichConst.NoiBiTich, ColumnType.Text, 200, ColumnBoundMode.Bound, "Nơi nhận bí tích", FilterEditType.NoEdit);
            AddColumn(DotBiTichConst.SoLuong, ColumnType.Text, 200, ColumnBoundMode.Bound, "Số lượng GD", FilterEditType.NoEdit);

            SetGridColumnWidth();
        }

        public override void LoadData()
        {
            string sql = SqlConstants.SELECT_DOTBITICH_LIST + " AND LoaiBiTich = ? ";
            List<object> args = new List<object>();
            args.Add(loaiBiTich);
            if (tuNam != 0)
            {
                sql += " AND INT(IIF(LEN([NgayBiTich])>=1,RIGHT([NgayBiTich], 4),\"0000\")) >= ? ";
                args.Add(tuNam);
            }
            if (denNam != 0)
            {
                sql += " AND INT(IIF(LEN([NgayBiTich])>=1,RIGHT([NgayBiTich], 4),\"0000\")) <= ? ";
                args.Add(denNam);
            }
            sql += " ORDER BY " + Memory.ConvertDateToInt("NgayBiTich") + " ASC ";
            LoadData(sql, args.ToArray());
        }
    }
}
