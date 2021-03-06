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
    public partial class GxHonPhoiList : GxGrid
    {
        public GxHonPhoiList()
        {
            InitializeComponent();
            this.AllowAddNew = InheritableBoolean.False;
            this.AllowDelete = InheritableBoolean.False;
            this.AllowEdit = InheritableBoolean.False;
        }

        private int maGiaoDan = -1;

        public int MaGiaoDan
        {
            get { return maGiaoDan; }
            set { maGiaoDan = value; }
        }

        private string phai = "";

        public string Phai
        {
            get { return phai; }
            set { phai = value; }
        }

        private int listMode = 1;
        /// <summary>
        /// 1: used for giao dan form (only vo or chong)
        /// 2: used for thong ke form (include vo and chong)
        /// </summary>
        public int ListMode
        {
            get { return listMode; }
            set { listMode = value; }
        }

        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();
            this.ColumnAutoResize = false;
            if (listMode == 1)
            {
                AddColumn(GiaoDanHonPhoiConst.SoThuTu, ColumnType.Text, 60, ColumnBoundMode.Bound, "STT", FilterEditType.Combo, TextAlignment.Far);
            }
            else if (listMode == 2)
            {
                AddColumn(HonPhoiConst.MaHonPhoi, ColumnType.Text, 60, ColumnBoundMode.Bound, "Mã HP", FilterEditType.Combo);
            }
            if (listMode == 1)
            {
                string vochong = "Chồng";
                if (phai.ToLower() == GxConstants.NAM.ToLower())
                {
                    vochong = "Vợ";
                }
                AddColumn(HonPhoiConst.VoChong, ColumnType.Text, 100, ColumnBoundMode.Bound, vochong, FilterEditType.Combo);
            }
            else if (listMode == 2)
            {
                AddColumn(GxConstants.NAM, ColumnType.Text, 100, ColumnBoundMode.Bound, "Chồng", FilterEditType.Combo);
                AddColumn(GxConstants.NU, ColumnType.Text, 100, ColumnBoundMode.Bound, "Vợ", FilterEditType.Combo);
            }
            AddColumn(HonPhoiConst.SoHonPhoi, ColumnType.Text, 80, ColumnBoundMode.Bound, "Số HP", FilterEditType.Combo);
            AddColumn(HonPhoiConst.NoiHonPhoi, ColumnType.Text, 100, ColumnBoundMode.Bound, "Nơi HP", FilterEditType.Combo);
            AddColumn(HonPhoiConst.NgayHonPhoi, ColumnType.Text, 80, ColumnBoundMode.Bound, "Ngày HP", FilterEditType.Combo, TextAlignment.Far);
            AddColumn(HonPhoiConst.CachThucHonPhoi, ColumnType.Text, 100, ColumnBoundMode.Bound, "Cách thức HP", FilterEditType.Combo);
            AddColumn(HonPhoiConst.LinhMucChung, ColumnType.Text, 100, ColumnBoundMode.Bound, "Linh mục chứng", FilterEditType.Combo);
            AddColumn(HonPhoiConst.NguoiChung1, ColumnType.Text, 100, ColumnBoundMode.Bound, "Người chứng 1", FilterEditType.Combo);
            AddColumn(HonPhoiConst.NguoiChung2, ColumnType.Text, 100, ColumnBoundMode.Bound, "Người chứng 2", FilterEditType.Combo);
            AddColumn(HonPhoiConst.GhiChu, ColumnType.Text, 200, ColumnBoundMode.Bound, "Ghi chú", FilterEditType.Combo);
        }

        public bool LoadData()
        {
            //select ma hon phoi
            LoadData(SqlConstants.SELECT_HONPHOI_THEO_MAGIAODAN + " AND GiaoDanHonPhoi_1.MaGiaoDan <> ?", new object[] { maGiaoDan, maGiaoDan });

            return true;
        }
    }
}
