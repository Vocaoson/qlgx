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
    public partial class GxLopGiaoLyList : GxGrid
    {
        //private ContextMenu contextMenu = new ContextMenu();
        protected bool choNhapMaRieng = false;

        private bool allowEditGiaDinh = true;

        public bool AllowEditGiaDinh
        {
            get { return allowEditGiaDinh; }
            set { allowEditGiaDinh = value; }
        }

        public GxLopGiaoLyList()
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

        private void item1_Click(object sender, EventArgs e)
        {

        }


        private void item2_Click(object sender, EventArgs e)
        {

        }

        private void item3_Click(object sender, EventArgs e)
        {
           
        }

      
        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();
            this.ColumnAutoResize = false;
            //this.AllowEdit = InheritableBoolean.True;

            GridEXColumn col1 = this.RootTable.Columns.Add("MaLop", ColumnType.Text);
            col1.Width = 50;
            col1.BoundMode = ColumnBoundMode.Bound;
            col1.DataMember = "MaLop";
            col1.Caption = "Mã Lớp";
            col1.FilterEditType = FilterEditType.Combo;



            GridEXColumn col2 = this.RootTable.Columns.Add("TenLop", ColumnType.Text);
            col2.Width = 200;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = "TenLop";
            col2.Caption = "Tên lớp";
            col2.FilterEditType = FilterEditType.Combo;

            //Khoan add start
            col2 = this.RootTable.Columns.Add("PhongHoc", ColumnType.Text);
            col2.Width = 80;
            col2.BoundMode = ColumnBoundMode.Bound;
            col2.DataMember = "PhongHoc";
            col2.Caption = "Phòng học";
            col2.FilterEditType = FilterEditType.Combo;
            //Khoan add end

            GridEXColumn col3 = this.RootTable.Columns.Add("GiaoLyVien", ColumnType.Text);
            col3.Width = 250;
            col3.BoundMode = ColumnBoundMode.Bound;
            col3.DataMember = "GiaoLyVien";
            col3.Caption = "Giáo lý viên";
            col3.FilterEditType = FilterEditType.Combo;

            GridEXColumn col4 = this.RootTable.Columns.Add("GhiChu", ColumnType.Text);
            col4.Width = 200;
            col4.BoundMode = ColumnBoundMode.Bound;
            col4.DataMember = "GhiChu";
            col4.Caption = "Ghi chú";
            col4.FilterEditType = FilterEditType.Combo;

        }

        public override void LoadData()
        {
            if (Memory.IsDesignMode) return;
            try
            {
                //LoadData(QueryString, Arguments);
                DataTable tbl = Memory.GetData(QueryString);
                tbl.Columns.Add("GiaoLyVien", System.Type.GetType("System.String"));
                foreach (DataRow dr in tbl.Rows)
                {
                    string sqlGiaoLyVien ="select giaolyvien.magiaodan,giaodan.tenthanh,giaodan.hoten from giaolyvien inner join giaodan on giaolyvien.magiaodan=giaodan.magiaodan where giaolyvien.malop =" + dr["malop"].ToString() + " order by malop";
                    DataTable tblglv = Memory.GetData(sqlGiaoLyVien);
                    if (tblglv.Rows.Count>0)
                    {
                        sqlGiaoLyVien = "";
                        foreach (DataRow drglv in tblglv.Rows)
                        {
                            //Khoan modify start
                            //sqlGiaoLyVien += Memory.GetName(drglv["HoTen"].ToString()) + " - ";
                            sqlGiaoLyVien += drglv["HoTen"].ToString() + ", ";
                            //Khoan modify end
                        }

                        sqlGiaoLyVien = sqlGiaoLyVien.Substring(0, sqlGiaoLyVien.Length - 2);
                        dr["GiaoLyVien"] = sqlGiaoLyVien;
                    }

                }
                if (!Memory.ShowError() && tbl != null)
                {
                    //tbl.TableName = "LopGiaoLy";
                    this.DataSource = tbl;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxLopGiaoLyList, LoadData)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        
    }
}
