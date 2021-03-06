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
    public partial class GxGiaoDanLoiList : GxGiaoDanList
    {
        public GxGiaoDanLoiList()
        {
            InitializeComponent();
        }

        public override void FormatGrid()
        {
            try
            {
                if (Memory.IsDesignMode) return;

                if (this.RootTable == null) this.RootTable = new GridEXTable();

                this.RootTable.RowHeight = -1;
                this.VisualStyle = VisualStyle.Office2003;
                this.ColumnAutoResize = false;
                this.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
                this.RootTable.Columns.Clear();

                GridEXColumn col0 = this.RootTable.Columns.Add(GxConstants.NGUYEN_NHAN, ColumnType.Text);
                col0.Width = 220;
                col0.Caption = "Nguyên nhân";
                col0.FilterEditType = FilterEditType.Combo;

                GridEXColumn col1 = this.RootTable.Columns.Add(GiaoDanConst.MaGiaoDan, ColumnType.Text);
                col1.Width = 50;
                col1.BoundMode = ColumnBoundMode.Bound;
                col1.DataMember = GiaoDanConst.MaGiaoDan;
                col1.Caption = "Mã GD";
                col1.FilterEditType = FilterEditType.Combo;

                GridEXColumn col2 = this.RootTable.Columns.Add(GiaoDanConst.TenThanh, ColumnType.Text);
                col2.Width = 80;
                col2.BoundMode = ColumnBoundMode.Bound;
                col2.DataMember = GiaoDanConst.TenThanh;
                col2.Caption = "Tên thánh";
                col2.FilterEditType = FilterEditType.Combo;

                GridEXColumn col3 = this.RootTable.Columns.Add(GiaoDanConst.HoTen, ColumnType.Text);
                col3.Width = 150;
                col3.BoundMode = ColumnBoundMode.Bound;
                col3.DataMember = GiaoDanConst.HoTen;
                col3.Caption = "Họ tên";
                col3.FilterEditType = FilterEditType.Combo;

                GridEXColumn col4 = this.RootTable.Columns.Add(GiaoDanConst.Phai, ColumnType.Text);
                col4.Width = 50;
                col4.BoundMode = ColumnBoundMode.Bound;
                col4.DataMember = GiaoDanConst.Phai;
                col4.Caption = "Phái";
                col4.FilterEditType = FilterEditType.DropDownList;

                GridEXColumn col5 = this.RootTable.Columns.Add(GiaoDanConst.NgaySinh, ColumnType.Text);
                col5.Width = 80;
                col5.BoundMode = ColumnBoundMode.Bound;
                col5.DataMember = GiaoDanConst.NgaySinh;
                col5.TextAlignment = TextAlignment.Far;
                col5.Caption = "Ngày sinh";
                col5.FilterEditType = FilterEditType.Combo;

                GridEXColumn col6 = this.RootTable.Columns.Add(GiaoDanConst.NgayRuaToi, ColumnType.Text);
                col6.Width = 80;
                col6.BoundMode = ColumnBoundMode.Bound;
                col6.DataMember = GiaoDanConst.NgayRuaToi;
                col6.TextAlignment = TextAlignment.Far;
                col6.Caption = "Ngày rửa tội";
                col6.FilterEditType = FilterEditType.Combo;

                GridEXColumn col7 = this.RootTable.Columns.Add(GiaoDanConst.NgayRuocLe, ColumnType.Text);
                col7.Width = 80;
                col7.BoundMode = ColumnBoundMode.Bound;
                col7.DataMember = GiaoDanConst.NgayRuocLe;
                col7.TextAlignment = TextAlignment.Far;
                col7.Caption = "Ngày XTRL";
                col7.FilterEditType = FilterEditType.Combo;

                GridEXColumn col8 = this.RootTable.Columns.Add(GiaoDanConst.NgayThemSuc, ColumnType.Text);
                col8.Width = 80;
                col8.BoundMode = ColumnBoundMode.Bound;
                col8.DataMember = GiaoDanConst.NgayThemSuc;
                col8.TextAlignment = TextAlignment.Far;
                col8.Caption = "Ngày Th.Sức";
                col8.FilterEditType = FilterEditType.Combo;

                GridEXColumn col9 = this.RootTable.Columns.Add(GiaoDanConst.DaCoGiaDinh, ColumnType.CheckBox);
                col9.Width = 50;
                col9.BoundMode = ColumnBoundMode.Bound;
                col9.DataMember = GiaoDanConst.DaCoGiaDinh;
                col9.Caption = "Lập GĐ";
                col9.FilterEditType = FilterEditType.CheckBox;

                GridEXColumn col12 = this.RootTable.Columns.Add(GiaoDanConst.GhiChu, ColumnType.Text);
                col12.Width = 200;
                col12.BoundMode = ColumnBoundMode.Bound;
                col12.DataMember = GiaoDanConst.GhiChu;
                col12.Caption = "Ghi chú";
                col12.FilterEditType = FilterEditType.Combo;

                GridEXColumn col10 = this.RootTable.Columns.Add(GiaDinhConst.TenGiaoHo, ColumnType.Text);
                col10.Width = 80;
                col10.BoundMode = ColumnBoundMode.Bound;
                col10.DataMember = GiaDinhConst.TenGiaoHo;
                col10.Caption = "Giáo họ";
                col10.FilterEditType = FilterEditType.Combo;

                GridEXColumn col13 = this.RootTable.Columns.Add(GiaoDanConst.GiaoDanAo, ColumnType.CheckBox);
                col13.Width = 50;
                col13.BoundMode = ColumnBoundMode.Bound;
                col13.DataMember = GiaoDanConst.GiaoDanAo;
                col13.Caption = "GD không thống kê";
                col13.FilterEditType = FilterEditType.CheckBox;

                GridEXColumn col11 = this.RootTable.Columns.Add(GxConstants.KETQUA_KIEMRA, ColumnType.Text);
                col11.Visible = false;

                GridEXFormatCondition con1 = new GridEXFormatCondition(col11, ConditionOperator.Equal, (int)ReviewGiaoDanType.SaiQuanHeNgayThang);
                con1.FormatStyle = new GridEXFormatStyle();
                con1.FormatStyle.BackColor = Color.Cyan;

                GridEXFormatCondition con2 = new GridEXFormatCondition(col11, ConditionOperator.Equal, (int)ReviewGiaoDanType.KhongCoDuLieuNgayThang);
                con2.FormatStyle = new GridEXFormatStyle();
                con2.FormatStyle.BackColor = Color.Yellow;

                GridEXFormatCondition con3 = new GridEXFormatCondition(col11, ConditionOperator.Equal, (int)ReviewGiaoDanType.RuocLeTruocTuoi);
                con3.FormatStyle = new GridEXFormatStyle();
                con3.FormatStyle.BackColor = Color.LightGray;

                GridEXFormatCondition con4 = new GridEXFormatCondition(col11, ConditionOperator.Equal, (int)ReviewGiaoDanType.ThuocNhieuGiaDinh);
                con4.FormatStyle = new GridEXFormatStyle();
                con4.FormatStyle.BackColor = Color.AntiqueWhite;

                GridEXFormatCondition con5 = new GridEXFormatCondition(col11, ConditionOperator.Equal, (int)ReviewGiaoDanType.KhongThuocGiaDinhNao);
                con5.FormatStyle = new GridEXFormatStyle();
                con5.FormatStyle.BackColor = Color.WhiteSmoke;

                GridEXFormatCondition con6 = new GridEXFormatCondition(col11, ConditionOperator.Equal, (int)ReviewGiaoDanType.CoNhieuHonPhoi);
                con6.FormatStyle = new GridEXFormatStyle();
                con6.FormatStyle.BackColor = Color.AliceBlue;

                this.RootTable.FormatConditions.Add(con1);
                this.RootTable.FormatConditions.Add(con2);
                this.RootTable.FormatConditions.Add(con3);
                this.RootTable.FormatConditions.Add(con4);
                this.RootTable.FormatConditions.Add(con5);
                this.RootTable.FormatConditions.Add(con6);
                this.RowHeaders = InheritableBoolean.True;

                col0.MaxLines = 100;
                col0.WordWrap = true;
                //foreach (GridEXColumn col in this.RootTable.Columns)
                //{
                //    col.MaxLines = 100;
                //    col.WordWrap = true;
                //}

                SetGridColumnWidth();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxGiaoDanList, FormatGrid)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
