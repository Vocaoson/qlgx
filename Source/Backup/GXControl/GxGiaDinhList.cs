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
    public partial class GxGiaDinhList : GxGrid
    {
        private ContextMenu contextMenu = new ContextMenu();
        protected bool choNhapMaRieng = false;

        private bool allowEditGiaDinh = true;

        public bool AllowEditGiaDinh
        {
            get { return allowEditGiaDinh; }
            set { allowEditGiaDinh = value; }
        }

        private GxOperation operation = GxOperation.EDIT;

        public GxOperation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public GxGiaDinhList()
        {
            InitializeComponent();
            QueryString = SqlConstants.SELECT_GIADINH_LIST;

            MenuItem item1 = new MenuItem("Chứng nhận hôn phối");
            item1.Click += new EventHandler(item1_Click);

            MenuItem item2 = new MenuItem("Xem chi tiết");
            item2.Click += new EventHandler(item2_Click);

            MenuItem item3 = new MenuItem("In sổ gia đình");
            item3.Click += new EventHandler(item3_Click);

            contextMenu.MenuItems.Add(item1);
            //contextMenu.MenuItems.Add(item2);
            contextMenu.MenuItems.Add(item3);
            this.ContextMenu = contextMenu;
            choNhapMaRieng = (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIADINH) == GxConstants.CF_TRUE);
        }

        private void item1_Click(object sender, EventArgs e)
        {
            XuatChungNhanHonPhoi();
        }

        public void XuatChungNhanHonPhoi()
        {
            if (this.SelectedItems.Count > 1)
            {
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in this.SelectedItems)
                {
                    ChungNhanHonPhoi((int)(item.GetRow().DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh]);
                    if (Memory.ShowError())
                    {
                        return;
                    }
                }
            }
            else if (this.CurrentRow != null && (this.CurrentRow.DataRow is DataRowView))
            {
                ChungNhanHonPhoi((int)(this.CurrentRow.DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh]);
            }
        }

        private void item2_Click(object sender, EventArgs e)
        {

        }

        private void item3_Click(object sender, EventArgs e)
        {
            XuatSoGiaDinh();
        }

        public void XuatSoGiaDinh()
        {
            foreach (Janus.Windows.GridEX.GridEXSelectedItem item in this.SelectedItems)
            {
                InSoGiaDinh((int)(item.GetRow().DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh]);
                if (Memory.ShowError())
                {
                    return;
                }
            }

            //if (this.CurrentRow != null && (this.CurrentRow.DataRow is DataRowView))
            //{
            //    InSoGiaDinh((int)(this.CurrentRow.DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh]);
            //}
        }

        public override void FormatGrid()
        {
            if (Memory.IsDesignMode) return;

            if (this.RootTable == null) this.RootTable = new GridEXTable();
            base.FormatGrid();

            this.RootTable.Columns.Clear();
            this.ColumnAutoResize = false;
            //this.AllowEdit = InheritableBoolean.True;
            if (!choNhapMaRieng)
            {
                GridEXColumn col1 = this.RootTable.Columns.Add(GiaDinhConst.MaGiaDinh, ColumnType.Text);
                col1.Width = 70;
                col1.BoundMode = ColumnBoundMode.Bound;
                col1.DataMember = GiaDinhConst.MaGiaDinh;
                col1.Caption = "Mã gia đình";
                col1.FilterEditType = FilterEditType.Combo;
            }
            else
            {
                GridEXColumn col1 = this.RootTable.Columns.Add(GiaDinhConst.MaGiaDinhRieng, ColumnType.Text);
                col1.Width = 70;
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
            col3.Caption = "Người nam";
            col3.FilterEditType = FilterEditType.Combo;

            GridEXColumn col4 = this.RootTable.Columns.Add(GiaDinhConst.TenVo, ColumnType.Text);
            col4.Width = 200;
            col4.BoundMode = ColumnBoundMode.Bound;
            col4.DataMember = GiaDinhConst.TenVo;
            col4.Caption = "Người nữ";
            col4.FilterEditType = FilterEditType.Combo;

            GridEXColumn colSoLuong = this.RootTable.Columns.Add(GiaDinhConst.SoLuong, ColumnType.Text);
            colSoLuong.Width = 80;
            colSoLuong.BoundMode = ColumnBoundMode.Bound;
            colSoLuong.DataMember = GiaDinhConst.SoLuong;
            colSoLuong.Caption = "Số người";
            colSoLuong.FilterEditType = FilterEditType.Combo;

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

            //GridEXColumn col11 = this.RootTable.Columns.Add(GiaDinhConst.GiaDinhAo, ColumnType.CheckBox);
            //col11.Width = 50;
            //col11.BoundMode = ColumnBoundMode.Bound;
            //col11.DataMember = GiaDinhConst.GiaDinhAo;
            //col11.Caption = "GĐ ảo";
            //col11.FilterEditType = FilterEditType.CheckBox;

        }

        public override void LoadData()
        {
            if (Memory.IsDesignMode) return;
            try
            {
                LoadData(QueryString, Arguments);

                //if (!Memory.ShowError() && tbl != null)
                //{
                //    tbl.TableName = GiaDinhConst.TableName;
                //    this.DataSource = tbl;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxGiaDinhList, LoadData)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int ChungNhanHonPhoi(int maGiaDinh)
        {
            DataSet DataObj = new DataSet();
            //Get GiaoXu info
            DataTable tblGiaoXu = Memory.GetData(SqlConstants.SELECT_GIAOXU);
            if (Memory.ShowError())
            {
                return -1;
            }
            if (tblGiaoXu == null || tblGiaoXu.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin giáo xứ. Vui lòng nhập thông tin giáo xứ trước khi sử dụng chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            tblGiaoXu.TableName = GiaoXuConst.TableName;
            DataObj.Tables.Add(tblGiaoXu);

            //Get GiaDinh info
            DataTable tblGiaDinh = Memory.GetData(string.Format(SqlConstants.SELECT_GIADINH_GIAODAN, " WHERE GiaDinh.MaGiaDinh=? AND (VaiTro=0 OR VaiTro=1)"), new object[] { maGiaDinh });
            //DataTable tblGiaDinh = Memory.GetTable(GiaDinhConst.TableName, string.Format(" AND MaGiaDinh={0}", maGiaDinh));
            if (Memory.ShowError())
            {
                return -1;
            }

            if (tblGiaDinh == null || tblGiaDinh.Rows.Count == 0)
            {
                MessageBox.Show("Không lấy được thông tin gia đình.\r\nXuất chứng nhận thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (Memory.IsNullOrEmpty(tblGiaDinh.Rows[0][GiaDinhConst.TenChong]) || Memory.IsNullOrEmpty(tblGiaDinh.Rows[0][GiaDinhConst.TenVo]))
            {
                MessageBox.Show("Gia đình được chọn không có đầy đủ thông tin vợ chồng nên không thể xuất chứng nhận hôn phối.\r\nXin vui lòng xem lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            tblGiaDinh.TableName = GiaDinhConst.TableName;
            DataObj.Tables.Add(tblGiaDinh);

            //Get Chong + Vo Info
            DataTable tblVoChong = Memory.GetData(SqlConstants.SELECT_VOCHONG_THEO_MAGIADINH, new object[] { maGiaDinh });
            if (Memory.ShowError() || tblVoChong == null || tblVoChong.Rows.Count <= 1)
            {
                MessageBox.Show("Không lấy được thông tin vợ chồng.\r\nXuất chứng nhận thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //Make main report data
            DataTable tblThongtinVoChong = new DataTable();
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.HoTenNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.HoTenNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NgaySinhNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NgaySinhNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NgayThangNamHP);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NhanChung);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NoiSinhNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NoiSinhNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.TenChaNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.TenChaNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.TenLinhMucGui);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.TenMeNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.TenMeNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.GiaoXuNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.GiaoXuNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NgayRuaToiNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.SoRuaToiNam);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.NgayRuaToiNu);
            tblThongtinVoChong.Columns.Add(ReportChungNhanHPConst.SoRuaToiNu);
            //honp hoi
            tblThongtinVoChong.Columns.Add(HonPhoiConst.SoHonPhoi);
            tblThongtinVoChong.Columns.Add(HonPhoiConst.LinhMucChung);
            tblThongtinVoChong.Columns.Add(HonPhoiConst.NoiHonPhoi);
            tblThongtinVoChong.Columns.Add(HonPhoiConst.NguoiChung1);
            tblThongtinVoChong.Columns.Add(HonPhoiConst.NguoiChung2);
            DataRow row = tblThongtinVoChong.NewRow();
            //Get thong tin chong
            DataRow[] rowCheck = tblVoChong.Select("VaiTro=" + GxConstants.VAITRO_CHONG);
            int maChong = 0;
            if (rowCheck != null && rowCheck.Length > 0)
            {
                maChong = (int)rowCheck[0][GiaoDanConst.MaGiaoDan];
                row[ReportChungNhanHPConst.HoTenNam] = rowCheck[0][GiaoDanConst.TenThanh].ToString() + " " + rowCheck[0][GiaoDanConst.HoTen].ToString();
                row[ReportChungNhanHPConst.NgaySinhNam] = rowCheck[0][GiaoDanConst.NgaySinh];
                row[ReportChungNhanHPConst.NoiSinhNam] = rowCheck[0][GiaoDanConst.NoiSinh];
                row[ReportChungNhanHPConst.NgayRuaToiNam] = rowCheck[0][GiaoDanConst.NgayRuaToi];
                row[ReportChungNhanHPConst.SoRuaToiNam] = rowCheck[0][GiaoDanConst.SoRuaToi];
                //Get Cha Me Info
                Dictionary<object, object> dicChaMe = GetTenChaMe((int)rowCheck[0][GiaoDanConst.MaGiaoDan],
                            rowCheck[0][GiaoDanConst.HoTenCha],
                            rowCheck[0][GiaoDanConst.HoTenMe]);
                row[ReportChungNhanHPConst.TenChaNam] = dicChaMe[GxConstants.VAITRO_CHONG];
                row[ReportChungNhanHPConst.TenMeNam] = dicChaMe[GxConstants.VAITRO_VO];
                row[ReportChungNhanHPConst.GiaoXuNam] = Memory.GetThuocXu(rowCheck[0]);
            }
            //Get thong tin vo
            int maVo = 0;
            rowCheck = tblVoChong.Select("VaiTro=" + GxConstants.VAITRO_VO);
            if (rowCheck != null && rowCheck.Length > 0)
            {
                maVo = (int)rowCheck[0][GiaoDanConst.MaGiaoDan];
                row[ReportChungNhanHPConst.HoTenNu] = rowCheck[0][GiaoDanConst.TenThanh].ToString() + " " + rowCheck[0][GiaoDanConst.HoTen];
                row[ReportChungNhanHPConst.NgaySinhNu] = rowCheck[0][GiaoDanConst.NgaySinh];
                row[ReportChungNhanHPConst.NoiSinhNu] = rowCheck[0][GiaoDanConst.NoiSinh];
                row[ReportChungNhanHPConst.NgayRuaToiNu] = rowCheck[0][GiaoDanConst.NgayRuaToi];
                row[ReportChungNhanHPConst.SoRuaToiNu] = rowCheck[0][GiaoDanConst.SoRuaToi];
                //Get Cha Me Info
                Dictionary<object, object> dicChaMe = GetTenChaMe((int)rowCheck[0][GiaoDanConst.MaGiaoDan], 
                            rowCheck[0][GiaoDanConst.HoTenCha],
                            rowCheck[0][GiaoDanConst.HoTenMe]);
                row[ReportChungNhanHPConst.TenChaNu] = dicChaMe[GxConstants.VAITRO_CHONG];
                row[ReportChungNhanHPConst.TenMeNu] = dicChaMe[GxConstants.VAITRO_VO];
                row[ReportChungNhanHPConst.GiaoXuNu] = Memory.GetThuocXu(rowCheck[0]);
            }

            bool coHP = false;
            if (maChong > 0 && maVo > 0)
            {
                DataTable tblHonPhoi = GxHonPhoiGiaDinh.GetHonPhoiTheoVoChong(maVo, maChong);
                if (!Memory.ShowError() && tblHonPhoi != null && tblHonPhoi.Rows.Count > 0)
                {
                    coHP = true;
                    row[ReportChungNhanHPConst.NgayThangNamHP] = tblHonPhoi.Rows[0][HonPhoiConst.NgayHonPhoi];

                    row[HonPhoiConst.SoHonPhoi] = tblHonPhoi.Rows[0][HonPhoiConst.SoHonPhoi];
                    row[HonPhoiConst.LinhMucChung] = tblHonPhoi.Rows[0][HonPhoiConst.LinhMucChung];
                    row[HonPhoiConst.NoiHonPhoi] = tblHonPhoi.Rows[0][HonPhoiConst.NoiHonPhoi];
                    row[HonPhoiConst.NguoiChung1] = tblHonPhoi.Rows[0][HonPhoiConst.NguoiChung1];
                    row[HonPhoiConst.NguoiChung2] = tblHonPhoi.Rows[0][HonPhoiConst.NguoiChung2];
                }
            }
            if (!coHP)
            {
                Memory.ShowError("Không tìm thấy thông tin hôn phối!");
                return -1;
            }

            //Get thong tin linh muc
            DataTable tblLinhMuc = Memory.GetData(SqlConstants.SELECT_LINHMUC_LIST + " AND DenNgay IS NULL ");
            if (!Memory.ShowError() && tblLinhMuc != null && tblLinhMuc.Rows.Count > 0)
            {
                row[ReportChungNhanHPConst.TenLinhMucGui] = tblLinhMuc.Rows[0][LinhMucConst.TenThanh].ToString() + " " + tblLinhMuc.Rows[0][LinhMucConst.HoTen].ToString();
            }
            tblThongtinVoChong.Rows.Add(row);
            tblThongtinVoChong.TableName = ReportChungNhanHPConst.TableName;
            DataObj.Tables.Add(tblThongtinVoChong);

            int rs = ExcelReport.ReportChungNhanHP.Export(DataObj);
            Memory.ShowError();
            return 0;
        }

        private static void setThongTinHonPhoi(DataRow rowGiaoDan)
        {
            int maGiaoDan = (int)rowGiaoDan[GiaoDanConst.MaGiaoDan];
            DataRow row = GetHonPhoi(maGiaoDan);
            if (row != null)
            {
                rowGiaoDan[HonPhoiConst.NgayHonPhoi] = row[HonPhoiConst.NgayHonPhoi];
                rowGiaoDan[HonPhoiConst.NoiHonPhoi] = row[HonPhoiConst.NoiHonPhoi];
            }
        }

        public static DataRow GetRowGiaDinhVoChong(int maGiaoDan)
        {
            DataRow rowReturn = null;
            string where = " WHERE GiaoDan.MaGiaoDan=" + maGiaoDan.ToString() + " AND (VaiTro=0 OR VaiTro=1)";
            string sql = string.Format(SqlConstants.SELECT_GIADINH_GIAODAN, where);
            DataTable tbl = Memory.GetData(sql);
            if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0)
            {
                rowReturn = tbl.Rows[0];
            }
            return rowReturn;
        }

        public static DataRow GetHonPhoi(int maGiaoDan)
        {
            //select ma hon phoi
            DataTable tblCheck = Memory.GetData(@"SELECT NgayHonPhoi,NoiHonPhoi FROM HonPhoi INNER JOIN GiaoDanHonPhoi 
                                                    ON HonPhoi.MaHonPhoi = GiaoDanHonPhoi.MaHonPhoi WHERE MaGiaoDan=?", new object[] { maGiaoDan });
            if (!Memory.ShowError() && tblCheck != null && tblCheck.Rows.Count > 0)
            {
                return tblCheck.Rows[0];
            }
            //this.operation = GxOperation.ADD;
            return null;
        }

        public static DataRow GetRowGiaDinh(int maGiaoDan, int vaiTro)
        {
            DataRow rowReturn = null;
            DataTable tblThanhVienGiaDinh = Memory.GetData("SELECT * FROM ThanhVienGiaDinh WHERE MaGiaoDan=? AND VaiTro=?", new object[] { maGiaoDan, vaiTro });
            //if exist in one GiaDinh
            if (!Memory.ShowError() && tblThanhVienGiaDinh != null && tblThanhVienGiaDinh.Rows.Count > 0)
            {
                int maGiaDinh = (int)tblThanhVienGiaDinh.Rows[0][ThanhVienGiaDinhConst.MaGiaDinh];
                //Get parent info
                //string sql = string.Format(SqlConstants.SELECT_CHA_ME_THEO_GIADINH, SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO);
                string sql = SqlConstants.SELECT_GIADINH_LIST + "AND MaGiaDinh=?";
                DataTable tblGiaDinh = Memory.GetData(sql, new object[] { maGiaDinh });
                if (!Memory.ShowError() && tblGiaDinh != null && tblGiaDinh.Rows.Count > 0)
                {
                    rowReturn = tblGiaDinh.Rows[0];
                }
            }
            return rowReturn;
        }

        /// <summary>
        /// Trả về 1 dictionary chứa thông tin cha mẹ và gia đình, các item trong dictionary luôn khác null
        /// </summary>
        /// <param name="maGiaoDan"></param>
        /// <param name="tenCha"></param>
        /// <param name="tenMe"></param>
        /// <returns></returns>
        public static Dictionary<object, object> GetTenChaMe(int maGiaoDan, object tenCha, object tenMe)
        {
            int maGiaDinh = -1;
            DataRow rowGiaDinh = GetRowGiaDinh(maGiaoDan, 2);
            if (rowGiaDinh != null)
            {
                if (rowGiaDinh[GiaDinhConst.TenChong].ToString() != "") tenCha = rowGiaDinh[GiaDinhConst.TenChong];
                if (rowGiaDinh[GiaDinhConst.TenVo].ToString() != "") tenMe = rowGiaDinh[GiaDinhConst.TenVo];
                maGiaDinh = (int)rowGiaDinh[GiaDinhConst.MaGiaDinh];
            }

            Dictionary<object, object> dic = new Dictionary<object, object>();
            dic.Add(GxConstants.VAITRO_CHONG, tenCha);
            dic.Add(GxConstants.VAITRO_VO, tenMe);
            dic.Add(GiaDinhConst.MaGiaDinh, maGiaDinh);
            return dic;
        }

        /// <summary>
        /// Trả về 1 dictionary chứa thông tin chồng vợ và gia đình, các item trong dictionary luôn khác null
        /// </summary>
        /// <param name="maGiaoDan"></param>
        /// <param name="vaiTro"></param>
        /// <returns></returns>
        public static Dictionary<object, object> GetTenVoChong(int maGiaoDan, int vaiTro)
        {
            string tenChong = "", tenVo = "";
            int maGiaDinh = -1;
            DataRow rowGiaDinh = GetRowGiaDinh(maGiaoDan, vaiTro);
            if (rowGiaDinh != null)
            {
                tenChong = rowGiaDinh[GiaDinhConst.TenChong].ToString();
                tenVo = rowGiaDinh[GiaDinhConst.TenVo].ToString();
                maGiaDinh = (int)rowGiaDinh[GiaDinhConst.MaGiaDinh];
            }

            Dictionary<object, object> dic = new Dictionary<object, object>();
            dic.Add(GxConstants.VAITRO_CHONG, tenChong);
            dic.Add(GxConstants.VAITRO_VO, tenVo);
            dic.Add(GiaDinhConst.MaGiaDinh, maGiaDinh);
            return dic;
        }

        public static int InSoGiaDinh(int maGiaDinh)
        {
            #region For GiaoXu
            DataTable tblGiaoXu = Memory.GetData(SqlConstants.SELECT_GIAOXU);
            if (Memory.ShowError())
            {
                return -1;
            }
            if (tblGiaoXu.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin giáo xứ. Vui lòng nhập thông tin giáo xứ trước khi sử dụng chức năng này.");
                return -1;
            }
            tblGiaoXu.TableName = GiaoXuConst.TableName;
            #endregion

            #region For GiaDinh
            DataTable tblGiaDinh = Memory.GetData(SqlConstants.SELECT_GIADINH_THEO_ID, new object[] { maGiaDinh });
            if (Memory.ShowError() || tblGiaDinh == null || tblGiaDinh.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin gia đình.\r\nXuất sổ gia đình thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            if ((bool)tblGiaDinh.Rows[0][GiaDinhConst.DaChuyenXu] == true)
            {
                MessageBox.Show("Gia đình này đã chuyển xứ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            tblGiaDinh.TableName = GiaDinhConst.TableName;
            #endregion

            #region For ThanhVienGiaDinh
            string sql = string.Format(SqlConstants.SELECT_THANHVIEN_GIADINH, SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO);
            DataTable tblThanhVienGiaDinh = Memory.GetData(sql + " AND ThanhVienGiaDinh.MaGiaDinh = ? ORDER BY ThanhVienGiaDinh.VaiTro, GiaoDan.NamSinh", new object[] { maGiaDinh });

            if (Memory.ShowError() || tblThanhVienGiaDinh == null)
            {
                MessageBox.Show("Không lấy được thông tin các thành viên trong gia đình.\r\nXuất sổ gia đình thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (tblThanhVienGiaDinh.Rows.Count == 0)
            {
                MessageBox.Show("Gia đình này không có thành viên nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;
            }

            //tblThanhVienGiaDinh.Columns.Add(ReportSoGiaDinhConst.DaQuaDoiR, typeof(string));
            tblThanhVienGiaDinh.Columns.Add(ReportSoGiaDinhConst.QuanHeR, typeof(string));
            tblThanhVienGiaDinh.Columns.Add(HonPhoiConst.NgayHonPhoi, typeof(string));
            tblThanhVienGiaDinh.Columns.Add(HonPhoiConst.NoiHonPhoi, typeof(string));

            tblThanhVienGiaDinh.TableName = GiaoDanConst.TableName;

            GridEXValueListItemCollection dicQuanHe = new GridEXValueListItemCollection();
            LoadQuanHeGDText(dicQuanHe, true);

            foreach (DataRow row in tblThanhVienGiaDinh.Rows)
            {
                //row[ReportSoGiaDinhConst.DaQuaDoiR] = ((bool)row[GiaoDanConst.QuaDoi] == false) ? "" : "X";
                if (((int)row[ThanhVienGiaDinhConst.VaiTro] == 0 || (int)row[ThanhVienGiaDinhConst.VaiTro] == 1)
                    && (bool)row[ThanhVienGiaDinhConst.ChuHo] == true)
                {
                    row[ReportSoGiaDinhConst.QuanHeR] = "Chủ hộ";
                }
                else
                {
                    row[ReportSoGiaDinhConst.QuanHeR] = findQuanHeText(dicQuanHe, (int)row[ThanhVienGiaDinhConst.VaiTro]);
                }
                if ((bool)row[GiaoDanConst.DaCoGiaDinh])
                {
                    setThongTinHonPhoi(row);
                }
            }
            #endregion

            DataSet DataObj = new DataSet();
            DataObj.Tables.Add(tblGiaoXu);
            DataObj.Tables.Add(tblThanhVienGiaDinh);
            DataObj.Tables.Add(tblGiaDinh);
            ExcelReport.ReportSoGiaDinh.Export(DataObj);
            Memory.ShowError();
            return 0;
        }

        public static string findQuanHeText(GridEXValueListItemCollection dicQuanHe, int vaiTro)
        {
            for (int i = 0; i < dicQuanHe.Count; i++)
            {
                if ((int)dicQuanHe[i].Value == vaiTro) return dicQuanHe[i].Text;
            }
            return "";
        }

        public static void LoadQuanHeGDText(GridEXValueListItemCollection vl)
        {
            LoadQuanHeGDText(vl, false);
        }

        public static void LoadQuanHeGDText(GridEXValueListItemCollection vl, bool isLoadChaMe)
        {
            if (isLoadChaMe)
            {
                vl.Add(0, "Chồng");
                vl.Add(1, "Vợ");
            }
            vl.Add(2, "Con");
            vl.Add(3, "Cháu");
            vl.Add(4, "Cha");
            vl.Add(5, "Mẹ");
            vl.Add(6, "Ông");
            vl.Add(7, "Bà");
            vl.Add(8, "Anh");
            vl.Add(17, "Chị");
            vl.Add(18, "Em");
            vl.Add(19, "Dâu");
            vl.Add(20, "Rể");
            vl.Add(9, "Cô");
            vl.Add(10, "Chú");
            vl.Add(11, "Bác");
            vl.Add(12, "Cậu");
            vl.Add(13, "Dì");
            vl.Add(14, "Mợ");
            vl.Add(15, "Thím");
            vl.Add(16, "Dượng");
            vl.Add(100, "Chưa rõ");
        }

        private void GxGiaDinhList_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            EditRow();
        }

        public virtual void EditRow()
        {
            if (this.CurrentRow == null || (this.CurrentRow.DataRow as DataRowView) == null
                || (this.CurrentRow.DataRow as DataRowView).Row.RowState == DataRowState.Deleted)
            {
                return;
            }
            frmGiaDinh frm = new frmGiaDinh();
            frm.Operation = Operation;
            DataRow row = (this.CurrentRow.DataRow as DataRowView).Row;
            SetFormData(frm);
            frm.MaGiaoHo = (int)row[GiaDinhConst.MaGiaoHo];
            frm.AssignControlData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = Memory.GetData(string.Concat(SqlConstants.SELECT_GIADINH_LIST, " AND MaGiaDinh=" + frm.DataReturn[GiaDinhConst.MaGiaDinh].ToString()));
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

        protected virtual void SetFormData(frmGiaDinh frm)
        {
            DataRow row = (this.CurrentRow.DataRow as DataRowView).Row;
            frm.Id = (int)row[GiaDinhConst.MaGiaDinh];
        }
    }
}
