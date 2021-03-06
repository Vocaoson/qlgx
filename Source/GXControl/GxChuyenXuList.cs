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
    public partial class GxChuyenXuList : GxGrid
    {
        private int maGiaoDan = -1;
        public const string LoaiChuyenText = "LoaiChuyenText";

        public int MaGiaoDan
        {
            get { return maGiaoDan; }
            set
            {
                maGiaoDan = value;

                if (!Memory.IsDesignMode && maGiaoDan > -1)
                {
                    LoadData();
                }
            }
        }

        public GxChuyenXuList()
        {
            InitializeComponent();
            QueryString = SqlConstants.SELECT_CHUYENXU_LIST;
        }

        public override void FormatGrid()
        {
            if (this.RootTable == null)
            {
                this.RootTable = new GridEXTable();
            }
            base.FormatGrid();
            this.RootTable.Columns.Clear();
            GridEXColumn col1 = this.RootTable.Columns.Add(LoaiChuyenText, ColumnType.Text);
            col1.Width = 200;
            col1.BoundMode = ColumnBoundMode.Bound;
            col1.DataMember = LoaiChuyenText;
            col1.Caption = "Loại chuyển";

            GridEXColumn col2 = this.RootTable.Columns.Add(ChuyenXuConst.NgayChuyen, ColumnType.Text);
            col2.Width = 100;
            col2.EditButtonDisplayMode = CellButtonDisplayMode.EditingCell;
            col2.ButtonDisplayMode = CellButtonDisplayMode.CurrentCell;
            col2.EditType = EditType.NoEdit;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = ChuyenXuConst.NgayChuyen;
            col2.Caption = "Ngày chuyển";
            col2.FormatMode = FormatMode.UseIFormattable;
            col2.DefaultGroupFormatMode = FormatMode.UseIFormattable;
            col2.TextAlignment = TextAlignment.Far;
            col2.DefaultGroupFormatString = "dd/MM/yyyy";
            col2.FormatString = "dd/MM/yyyy";

            GridEXColumn col3 = this.RootTable.Columns.Add(ChuyenXuConst.NoiChuyen, ColumnType.Text);
            col3.Width = 200;
            col3.BoundMode = ColumnBoundMode.Bound;
            col3.DataMember = ChuyenXuConst.NoiChuyen;
            col3.Caption = "Nơi chuyển";

            GridEXColumn col4 = this.RootTable.Columns.Add(ChuyenXuConst.GhiChuChuyen, ColumnType.Text);
            col4.Width = 200;
            col4.BoundMode = ColumnBoundMode.Bound;
            col4.DataMember = ChuyenXuConst.GhiChuChuyen;
            col4.Caption = "Ghi chú";
        }

        public override void LoadData()
        {
            try
            {
                LoadData(SqlConstants.SELECT_CHUYENXU_LIST + " AND MaGiaoDan = ? ", new object[] { maGiaoDan });
                DataTable tbl = (DataTable)this.DataSource;
                if (tbl != null)
                {
                    tbl.TableName = ChuyenXuConst.TableName;
                    tbl.Columns.Add(LoaiChuyenText);
                    foreach (DataRow row in tbl.Rows)
                    {
                        row[LoaiChuyenText] = getLoaiChuyenText(int.Parse(row[ChuyenXuConst.LoaiChuyen].ToString()));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxChuyenXuLists, LoadData)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getLoaiChuyenText(int loaiChuyen)
        {
            switch (loaiChuyen)
            { 
                case 1:
                    return GxConstants.CHUYENXU_DEN;
                case 2:
                    return GxConstants.CHUYENXU_DI;
                default:
                    return GxConstants.CHUYENXU_TAIXU;
            }
        }

    }
}
