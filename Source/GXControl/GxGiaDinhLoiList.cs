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
    public partial class GxGiaDinhLoiList : GxGiaDinhList
    {
        private ContextMenu contextMenu = new ContextMenu();
        public GxGiaDinhLoiList()
        {
            InitializeComponent();
        }

        public override void FormatGrid()
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

            if (!choNhapMaRieng)
            {
                GridEXColumn col1 = this.RootTable.Columns.Add(GiaDinhConst.MaGiaDinh, ColumnType.Text);
                col1.Width = 50;
                col1.BoundMode = ColumnBoundMode.Bound;
                col1.DataMember = GiaDinhConst.MaGiaDinh;
                col1.Caption = "Mã gia đình";
                col1.FilterEditType = FilterEditType.Combo;
            }
            else
            {
                GridEXColumn col1 = this.RootTable.Columns.Add(GiaDinhConst.MaGiaDinhRieng, ColumnType.Text);
                col1.Width = 50;
                col1.BoundMode = ColumnBoundMode.Bound;
                col1.DataMember = GiaDinhConst.MaGiaDinhRieng;
                col1.Caption = "Mã gia đình";
                col1.FilterEditType = FilterEditType.Combo;
            }

            GridEXColumn col2 = this.RootTable.Columns.Add(GiaDinhConst.TenGiaDinh, ColumnType.Text);
            col2.Width = 100;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = GiaDinhConst.TenGiaDinh;
            col2.Caption = "Tên gia đình";
            col2.FilterEditType = FilterEditType.Combo;

            GridEXColumn col3 = this.RootTable.Columns.Add(GiaDinhConst.TenChong, ColumnType.Text);
            col3.Width = 200;
            col3.BoundMode = ColumnBoundMode.Bound;
            col3.DataMember = GiaDinhConst.TenChong;
            col3.Caption = "Bên nam";
            col3.FilterEditType = FilterEditType.Combo;

            GridEXColumn col4 = this.RootTable.Columns.Add(GiaDinhConst.TenVo, ColumnType.Text);
            col4.Width = 200;
            col4.BoundMode = ColumnBoundMode.Bound;
            col4.DataMember = GiaDinhConst.TenVo;
            col4.Caption = "Bên nữ";
            col4.FilterEditType = FilterEditType.Combo;

            //GridEXColumn col7 = this.RootTable.Columns.Add(GiaDinhConst.NgayHonPhoi, ColumnType.Text);
            //col7.Width = 80;
            //col7.BoundMode = ColumnBoundMode.Bound;
            //col7.DataMember = GiaDinhConst.NgayHonPhoi;
            //col7.TextAlignment = TextAlignment.Far;
            //col7.Caption = "Ngày HP";
            //col7.FilterEditType = FilterEditType.Combo;

            //GridEXColumn col6 = this.RootTable.Columns.Add(GiaDinhConst.CachThucHonPhoi, ColumnType.Text);
            //col6.Width = 100;
            //col6.BoundMode = ColumnBoundMode.Bound;
            //col6.DataMember = GiaDinhConst.CachThucHonPhoi;
            //col6.Caption = "Tình trạng HP";
            //col6.FilterEditType = FilterEditType.Combo;

            //col6.ValueList.Add("Hợp pháp", "Hợp pháp");
            //col6.ValueList.Add("Hợp thức hóa", "Hợp thức hóa");
            //col6.ValueList.Add("Chuẩn", "Chuẩn");
            //col6.ValueList.Add("Không theo phép đạo", "Không theo phép đạo");
            //col6.ValueList.Add("Không xác định", "Không xác định");

            GridEXColumn col8 = this.RootTable.Columns.Add(GiaDinhConst.DienThoai, ColumnType.Text);
            col8.Width = 80;
            col8.BoundMode = ColumnBoundMode.Bound;
            col8.DataMember = GiaDinhConst.DienThoai;
            col8.Caption = "Điện thoại";
            col8.FilterEditType = FilterEditType.Combo;

            GridEXColumn col9 = this.RootTable.Columns.Add(GiaDinhConst.DiaChi, ColumnType.Text);
            col9.Width = 100;
            col9.BoundMode = ColumnBoundMode.Bound;
            col9.DataMember = GiaDinhConst.DiaChi;
            col9.Caption = "Địa chỉ";
            col9.FilterEditType = FilterEditType.Combo;

            GridEXColumn col10 = this.RootTable.Columns.Add(GiaDinhConst.GhiChu, ColumnType.Text);
            col10.Width = 200;
            col10.BoundMode = ColumnBoundMode.Bound;
            col10.DataMember = GiaDinhConst.GhiChu;
            col10.Caption = "Ghi chú";
            col10.FilterEditType = FilterEditType.Combo;

            GridEXColumn col5 = this.RootTable.Columns.Add(GiaDinhConst.TenGiaoHo, ColumnType.Text);
            col5.Width = 80;
            col5.BoundMode = ColumnBoundMode.Bound;
            col5.DataMember = GiaDinhConst.TenGiaoHo;
            col5.Caption = "Giáo họ";
            col5.FilterEditType = FilterEditType.Combo;

            GridEXColumn col16 = this.RootTable.Columns.Add(GxConstants.KETQUA_KIEMRA, ColumnType.Text);
            col16.Visible = false;

            GridEXColumn col17 = this.RootTable.Columns.Add(GiaDinhConst.GiaDinhAo, ColumnType.CheckBox);
            col17.Width = 50;
            col17.BoundMode = ColumnBoundMode.Bound;
            col17.DataMember = GiaDinhConst.GiaDinhAo;
            col17.Caption = "GĐ không thống kê";
            col17.FilterEditType = FilterEditType.CheckBox;

            GridEXFormatCondition con1 = new GridEXFormatCondition(col16, ConditionOperator.Equal, (int)ReviewGiaDinhType.HonPhoiTruocTuoi);
            con1.FormatStyle = new GridEXFormatStyle();
            con1.FormatStyle.BackColor = Color.Cyan;

            GridEXFormatCondition con2 = new GridEXFormatCondition(col16, ConditionOperator.Equal, (int)ReviewGiaDinhType.KhoangCachTuoiKhongHopLe);
            con2.FormatStyle = new GridEXFormatStyle();
            con2.FormatStyle.BackColor = Color.Yellow;

            GridEXFormatCondition con3 = new GridEXFormatCondition(col16, ConditionOperator.Equal, (int)ReviewGiaDinhType.KhongCoNgayHonPhoi);
            con3.FormatStyle = new GridEXFormatStyle();
            con3.FormatStyle.BackColor = Color.LightGray;

            GridEXFormatCondition con4 = new GridEXFormatCondition(col16, ConditionOperator.Equal, (int)ReviewGiaDinhType.NhieuVoChong);
            con4.FormatStyle = new GridEXFormatStyle();
            con4.FormatStyle.BackColor = Color.LightCoral;

            this.RootTable.FormatConditions.Add(con1);
            this.RootTable.FormatConditions.Add(con2);
            this.RootTable.FormatConditions.Add(con3);
            this.RootTable.FormatConditions.Add(con4);
            this.RowHeaders = InheritableBoolean.True;

            col0.MaxLines = 100;
            col0.WordWrap = true;

            SetGridColumnWidth();
        }
    }
}
