using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Threading;
using GxGlobal;

namespace GxControl
{
    public partial class GxGiaoDanImportList : GxGiaoDanList
    {
        public override void FormatGrid()
        {
            try
            {
                if (Memory.IsDesignMode) return;
               
                base.FormatGrid();

                GridEXColumn col = null;
                col = new GridEXColumn(MergeData.MaGiaoDanMoi, Janus.Windows.GridEX.ColumnType.Text);
                col.Width = 60;
                col.BoundMode = ColumnBoundMode.Bound;
                col.DataMember = MergeData.MaGiaoDanMoi;
                col.Caption = "Mã giáo dân mới";
                col.FilterEditType = FilterEditType.Combo;
                this.RootTable.Columns.Insert(0, col);

                col = new GridEXColumn(MergeData.KetQua, Janus.Windows.GridEX.ColumnType.Text);
                col.Width = 200;
                col.BoundMode = ColumnBoundMode.Bound;
                col.DataMember = MergeData.KetQua;
                col.Caption = "Kết quả";
                col.FilterEditType = FilterEditType.Combo;
                this.RootTable.Columns.Insert(0, col);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxGiaoDanList, FormatGrid)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void SetFormData(frmGiaoDan frm)
        {
            DataRow row = (this.CurrentRow.DataRow as DataRowView).Row;
            frm.Id = (int)row[MergeData.MaGiaoDanMoi];
        }
    }
}
