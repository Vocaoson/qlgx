using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using GxGlobal;
using ExcelReport;

namespace GxControl
{
    public partial class GxRaoHonPhoiList : GxGrid
    {
        private ContextMenu contextMenu = new ContextMenu();
        
        private int maRaoHonPhoi = -1;

        private bool showAll = false;

        public bool ShowAll
        {
            get { return showAll; }
            set { showAll = value; }
        }

        private bool allowShowForm = true;

        public bool AllowShowForm
        {
            get { return allowShowForm; }
            set { allowShowForm = value; }
        }

        private bool allowContextMenu = true;

        public bool AllowContextMenu
        {
            get { return allowContextMenu; }
            set { allowContextMenu = value; }
        }


        public GxRaoHonPhoiList()
        {
            InitializeComponent();
            if (allowContextMenu)
            {
                MenuItem item1 = new MenuItem("Xem - &sửa");
                item1.Click += new EventHandler(item1_Click);

                MenuItem item2 = new MenuItem("&Xóa");
                item2.Click += new EventHandler(item2_Click);

                MenuItem item3 = new MenuItem("&In điều tra hôn phối");
                item3.Click += new EventHandler(item3_Click);

                contextMenu.MenuItems.Add(item1);
                contextMenu.MenuItems.Add(item2);
                contextMenu.MenuItems.Add(item3);
                this.ContextMenu = contextMenu;
            }
            this.RowDoubleClick += new RowActionEventHandler(GxRaoHonPhoiList_RowDoubleClick);
        }

        private void GxRaoHonPhoiList_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            EditRow(false);
        }

        private void item1_Click(object sender, EventArgs e)
        {
            EditRow(false);
        }

        private void item2_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        public void item3_Click(object sender, EventArgs e)
        {
            EditRow(true);
        }

        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            this.ColumnAutoResize = false;
            base.FormatGrid();

            this.RootTable.Columns.Clear();

            GridEXColumn col = this.RootTable.Columns.Add(RaoHonPhoiConst.MaRaoHonPhoi, ColumnType.Text);
            col.Width = 50;
            col.TextAlignment = TextAlignment.Far;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.MaRaoHonPhoi;
            col.Caption = "Mã rao";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.TenRaoHonPhoi, ColumnType.Text);
            col.Width = 100;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.TenRaoHonPhoi;
            col.Caption = "Đôi rao";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.Nguoi1, ColumnType.Text);
            col.Width = 150;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.Nguoi1;
            col.Caption = "Người thứ nhất";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.Nguoi2, ColumnType.Text);
            col.Width = 150;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.Nguoi2;
            col.Caption = "Người thứ hai";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.NgayRaoLan1, ColumnType.Text);
            col.Width = 80;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.NgayRaoLan1;
            col.Caption = "Rao lần 1";
            col.TextAlignment = TextAlignment.Far;
            col.DefaultGroupFormatString = "dd/MM/yyyy";
            col.FormatString = "dd/MM/yyyy";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.NgayRaoLan2, ColumnType.Text);
            col.Width = 80;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.NgayRaoLan2;
            col.Caption = "Rao lần 2";
            col.TextAlignment = TextAlignment.Far;
            col.DefaultGroupFormatString = "dd/MM/yyyy";
            col.FormatString = "dd/MM/yyyy";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.NgayRaoLan3, ColumnType.Text);
            col.Width = 80;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.NgayRaoLan3;
            col.Caption = "Rao lần 3";
            col.TextAlignment = TextAlignment.Far;
            col.DefaultGroupFormatString = "dd/MM/yyyy";
            col.FormatString = "dd/MM/yyyy";

            col = this.RootTable.Columns.Add(RaoHonPhoiConst.GhiChu, ColumnType.Text);
            col.Width = 150;
            col.BoundMode = ColumnBoundMode.Bound;
            col.DataMember = RaoHonPhoiConst.GhiChu;
            col.Caption = "Ghi chú";
        }

        public override void LoadData()
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (!showAll)
            {
                LoadData(SqlConstants.SELECT_RAOHONPHOI_LIST + string.Format(@" AND Int(Right({0},4) & Mid({0},4,2) & Left({0},2)) >= {4}
                                ORDER BY Int(Right({0},4)) ASC, Int(Mid({0},4,2)) ASC, Int(LEFT({0},2)) ASC", 
                                RaoHonPhoiConst.NgayRaoLan3, year, month, day, DateTime.Now.ToString("yyyyMMdd")), null);
            }
            else
            {
                LoadData(SqlConstants.SELECT_RAOHONPHOI_LIST + string.Format(" ORDER BY Int(Right({0},4)) ASC, Int(Mid({0},4,2)) ASC, Int(LEFT({0},2)) ASC", RaoHonPhoiConst.NgayRaoLan1), null);
            }
        }

        public void EditRow(bool usePrint)
        {
            if (this.CurrentRow == null || ((this.CurrentRow.DataRow as DataRowView) != null))
            {
                DataRow row = (this.CurrentRow.DataRow as DataRowView).Row;
                frmRaoHonPhoi frm = new frmRaoHonPhoi();
                frm.Operation = GxOperation.EDIT;
                frm.UsePrint = usePrint;
                frm.MaRaoHonPhoi = (int)row[RaoHonPhoiConst.MaRaoHonPhoi];
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.DataReturn != null)
                    {
                        DataTable tbl = Memory.GetData(string.Concat(SqlConstants.SELECT_RAOHONPHOI_LIST, " AND MaRaoHonPhoi=" + frm.DataReturn[RaoHonPhoiConst.MaRaoHonPhoi].ToString()));
                        if (Memory.ShowError()) return;
                        if (tbl != null && tbl.Rows.Count > 0)
                        {
                            foreach (DataColumn col in tbl.Columns)
                            {
                                if (row.Table.Columns.Contains(col.ColumnName))
                                {
                                    row[col.ColumnName] = tbl.Rows[0][col.ColumnName];
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AddRow()
        {
            frmRaoHonPhoi frm = new frmRaoHonPhoi();
            frm.Operation = GxOperation.ADD;
            frm.UsePrint = false;
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = Memory.GetData(string.Concat(SqlConstants.SELECT_RAOHONPHOI_LIST, " AND MaRaoHonPhoi=" + frm.DataReturn[RaoHonPhoiConst.MaRaoHonPhoi].ToString()));
                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        DataTable sourceTbl = (DataTable)this.DataSource;
                        if (sourceTbl != null)
                        {
                            sourceTbl.ImportRow(tbl.Rows[0]);
                            this.FindAll(this.RootTable.Columns[0], Janus.Windows.GridEX.ConditionOperator.Equal, tbl.Rows[0][RaoHonPhoiConst.MaRaoHonPhoi]);
                        }
                        else
                        {
                            this.DataSource = tbl;
                        }
                    }
                }
            }
        }

        public void DeleteRow()
        {
            if (this.CurrentRow != null && (this.CurrentRow.DataRow as DataRowView) != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa (các) đôi rao được chọn trong danh sách?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int count = this.SelectedItems.Count;
                List<int> lstDelete = new List<int>();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in this.SelectedItems)
                {
                    lstDelete.Add(item.Position);
                }
                for (int i = 0; i < count; i++)
                {
                    Janus.Windows.GridEX.GridEXRow item = this.GetRow(lstDelete[i] - i);
                    Memory.ExecuteSqlCommand(SqlConstants.DELETE_RAOHONPHOI,
                                                        new object[] { (item.DataRow as DataRowView).Row[RaoHonPhoiConst.MaRaoHonPhoi] });
                    if (Memory.ShowError())
                    {
                        return;
                    }
                    item.Delete();
                }
            }
        }

        public override void Print()
        {
            try
            {
                frmDateInput frmDate = new frmDateInput();
                frmDate.Label = "Hãy chọn ngày rao";
                if (frmDate.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                DateTime date = frmDate.Value;
                Memory.Instance.SetMemory(ReportRaoHonPhoiConst.ThoiGianRao, date);
                if (this.RowCount == 0) return;
                bool error = false;
                //drop table temporary
                string sql = @"DROP TABLE RaoHonPhoiTMP";
                Memory.ExecuteSqlCommand(sql);
                Memory.ClearError();
                //create table temporary
                sql = @"CREATE TABLE RaoHonPhoiTMP (
                                        STT INTEGER NOT NULL,
                                        MaRaoHonPhoi INTEGER NOT NULL,
                                        MaGiaoDan INTEGER NOT NULL,
                                        NamSinh TEXT(4),
                                        TenRaoHonPhoi TEXT(255),
                                        ThuocXu TEXT(255),
                                        TruocOXu TEXT(255),
                                        LanRao TEXT(20),
                                        CONSTRAINT RaoHonPhoiTMP_PK PRIMARY KEY(MaRaoHonPhoi, MaGiaoDan)
                                        )";
                Memory.ExecuteSqlCommand(sql);
                if (!Memory.HasError())
                {
                    DataTable tblGiaoDanRaoHP = Memory.GetTableStruct(RaoHonPhoiTMPConst.TableName);
                    //tblGiaoDanRaoHP.Columns.Add(RaoHonPhoiConst.MaRaoHonPhoi);
                    int stt = 1;
                    foreach (GridEXRow grow in this.GetRows())
                    {
                        DataRow row = (grow.DataRow as DataRowView).Row;
                        //if ((bool)row[GiaoDanConst.TanTong] == false)
                        //{
                        //    row[GiaoDanConst.TanTong] = "";
                        //}
                        //else
                        //{
                        //    row[GiaoDanConst.TanTong] = "X";
                        //}
                        int lanrao = getLanRao(row, date);
                        if (lanrao == 0) continue;

                        DataRow row1 = tblGiaoDanRaoHP.NewRow();
                        row1["STT"] = stt;
                        row1[RaoHonPhoiConst.MaRaoHonPhoi] = row[RaoHonPhoiConst.MaRaoHonPhoi];
                        row1[RaoHonPhoiConst.TenRaoHonPhoi] = row[RaoHonPhoiConst.TenRaoHonPhoi];
                        row1[GiaoDanConst.MaGiaoDan] = row[RaoHonPhoiConst.MaGiaoDan1];
                        row1[RaoHonPhoiTMPConst.ThuocXu] = row[RaoHonPhoiConst.GiaoXu1];
                        if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.GiaoPhan1]))
                        {
                            row1[RaoHonPhoiTMPConst.ThuocXu] = row1[RaoHonPhoiTMPConst.ThuocXu] + " - " + row[RaoHonPhoiConst.GiaoPhan1].ToString();
                        }
                        row1[RaoHonPhoiTMPConst.TruocOXu] = row[RaoHonPhoiConst.GiaoXuTruoc1];
                        if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.GiaoPhanTruoc1]))
                        {
                            row1[RaoHonPhoiTMPConst.TruocOXu] = row1[RaoHonPhoiTMPConst.TruocOXu] + " - " + row[RaoHonPhoiConst.GiaoPhanTruoc1].ToString();
                        }
                        row1[RaoHonPhoiTMPConst.LanRao] = lanrao.ToString();
                        tblGiaoDanRaoHP.Rows.Add(row1);

                        row1 = tblGiaoDanRaoHP.NewRow();
                        row1["STT"] = stt;
                        row1[RaoHonPhoiTMPConst.MaRaoHonPhoi] = row[RaoHonPhoiConst.MaRaoHonPhoi];
                        row1[RaoHonPhoiConst.TenRaoHonPhoi] = row[RaoHonPhoiConst.TenRaoHonPhoi];
                        row1[RaoHonPhoiTMPConst.MaGiaoDan] = row[RaoHonPhoiConst.MaGiaoDan2];
                        //row1[RaoHonPhoiTMPConst.NamSinh] = GetYear(row[RaoHonPhoiConst.Na].ToString());
                        row1[RaoHonPhoiTMPConst.ThuocXu] = row[RaoHonPhoiConst.GiaoXu2];
                        if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.GiaoPhan2]))
                        {
                            row1[RaoHonPhoiTMPConst.ThuocXu] = row1[RaoHonPhoiTMPConst.ThuocXu] + " - " + row[RaoHonPhoiConst.GiaoPhan2].ToString();
                        }
                        row1[RaoHonPhoiTMPConst.TruocOXu] = row[RaoHonPhoiConst.GiaoXuTruoc2];
                        if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.GiaoPhanTruoc2]))
                        {
                            row1[RaoHonPhoiTMPConst.TruocOXu] = row1[RaoHonPhoiTMPConst.TruocOXu] + " - " + row[RaoHonPhoiConst.GiaoPhanTruoc2].ToString();
                        }
                        row1[RaoHonPhoiTMPConst.LanRao] = lanrao.ToString();
                        tblGiaoDanRaoHP.Rows.Add(row1);
                        stt++;
                    }
                    DataSet ds = new DataSet();
                    tblGiaoDanRaoHP.TableName = RaoHonPhoiTMPConst.TableName;
                    ds.Tables.Add(tblGiaoDanRaoHP);
                    Memory.UpdateDataSet(ds);
                    if (!Memory.ShowError())
                    {
                        //export to excel start
                        //get data join between RaoHonPhoiTMP AND GiaoDan
                        tblGiaoDanRaoHP = Memory.GetData(SqlConstants.SELECT_REPORT_RAOHONPHOI_LIST);
                        if (!Memory.ShowError() && tblGiaoDanRaoHP != null)
                        {
                            tblGiaoDanRaoHP.TableName = RaoHonPhoiTMPConst.TableName;
                            foreach (DataRow row in tblGiaoDanRaoHP.Rows)
                            {
                                row[GiaoDanConst.NgaySinh] = GetYear(row[GiaoDanConst.NgaySinh].ToString());
                            }
                            ds = new DataSet();
                            ds.Tables.Add(tblGiaoDanRaoHP);
                            ReportRaoHP.ExportList(ds);
                            if (Memory.ShowError())
                            {
                                error = true;
                            }
                        }
                        else
                        {
                            error = true;
                        }
                        //export to excel end
                    }
                    else
                    {
                        error = true;
                    }
                    if (error)
                    {
                        MessageBox.Show("Xuất báo cáo bị thất bại.\r\nXin quý vị vui lòng liên hệ tác giả để được giải quyết!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                //drop table temporary
                string sql = @"DROP TABLE RaoHonPhoiTMP";
                Memory.ExecuteSqlCommand(sql);
                Memory.ClearError();
            }
        }

        public static string GetYear(string ngay)
        {
            if (ngay.ToString() == "") return "";
            GxDateInput date = new GxDateInput();
            date.Value = ngay;
            return date.Year;
        }

        private int getLanRao(DataRow row, DateTime ngayRao)
        {
            if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.NgayRaoLan1]))
            {
                DateTime d = Memory.GetDateFromString(row[RaoHonPhoiConst.NgayRaoLan1].ToString());
                if (isPrinted(d, ngayRao))
                {
                    return 1;
                }
            }
            if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.NgayRaoLan2]))
            {
                DateTime d = Memory.GetDateFromString(row[RaoHonPhoiConst.NgayRaoLan2].ToString());
                if (isPrinted(d, ngayRao))
                {
                    return 2;
                }
            }
            if (!Memory.IsNullOrEmpty(row[RaoHonPhoiConst.NgayRaoLan3]))
            {
                DateTime d = Memory.GetDateFromString(row[RaoHonPhoiConst.NgayRaoLan3].ToString());
                if (isPrinted(d, ngayRao))
                {
                    return 3;
                }
            }
            return 0;
        }

        /// <summary>
        /// Compare between two date object.
        /// Return:
        /// 0 if equal .
        /// -1 if ver1 greater than ver2. 
        /// 1 if ver2 less than ver1
        /// </summary>
        private bool isPrinted(DateTime date1, DateTime date2)
        {
            TimeSpan ts = date2.Subtract(date1);
            int cach = (int)ts.TotalDays;
            if (cach >= 0 && cach < 7)
                return true;
            return false;
        }
    }
}
