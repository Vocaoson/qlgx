using System;
using System.Collections.Generic;
using System.Text;
using GxControl;
using GxGlobal;
using System.Data;
using System.Xml;
using System.ComponentModel;

namespace GiaoXu
{
    public class ReviewGiaoDanProcess: IGxProcess
    {
        public event EventHandler OnStart = null;
        public event CancelEventHandler OnError = null;
        public event EventHandler OnFinished = null;
        public event EventHandler OnExecuting = null;
        private ProcessOptions processOptions = ProcessOptions.ReviewGiaoDanProcess;
        public ProcessOptions ProcessOptions
        {
            get { return processOptions; }
            set { processOptions = value; }
        }

        private object processData = null;
        public object ProcessData
        {
            get { return processData; }
            set { processData = value; }
        }

        private DataTable tblGiaoDanReviewed = null;
        private DataTable tblThanhVienGiaDinh = null;
        private DataTable tblGiaoDan = null;
        private static DataTable tblGiaoDanHonPhoi = null;
        private int maGiaoHo = -1;

        public int MaGiaoHo
        {
            get { return maGiaoHo; }
            set { maGiaoHo = value; }
        }

        private bool kiemTraThuocNhieuGiaDinh = true;

        public bool KiemTraNhieuGiaDinh
        {
            get { return kiemTraThuocNhieuGiaDinh; }
            set { kiemTraThuocNhieuGiaDinh = value; }
        }

        private bool kiemTraKhongThuocGiaDinh = true;

        public bool KiemTraKhongThuocGiaDinh
        {
            get { return kiemTraKhongThuocGiaDinh; }
            set { kiemTraKhongThuocGiaDinh = value; }
        }

        private bool kiemTraKhongNgayThang = true;

        public bool KiemTraKhongNgayThang
        {
            get { return kiemTraKhongNgayThang; }
            set { kiemTraKhongNgayThang = value; }
        }

        private bool kiemTraSaiQuanHeNgayThang = true;

        public bool KiemTraSaiQuanHeNgayThang
        {
            get { return kiemTraSaiQuanHeNgayThang; }
            set { kiemTraSaiQuanHeNgayThang = value; }
        }

        private bool kiemTraRuocLeTruocTuoi = true;

        public bool KiemTraRuaToiTruocTuoi
        {
            get { return kiemTraRuocLeTruocTuoi; }
            set { kiemTraRuocLeTruocTuoi = value; }
        }

        private bool kiemTraNhieuHonPhoi = true;

        public bool KiemTraNhieuHonPhoi
        {
            get { return kiemTraNhieuHonPhoi; }
            set { kiemTraNhieuHonPhoi = value; }
        }

        public void Execute()
        {
            if (OnStart != null) OnStart("started", EventArgs.Empty);            
            try
            {
                reViewData();
            }
            catch (Exception ex)
            {
                if (OnError != null) OnError("Update: " + ex.Message, new CancelEventArgs());
            }
            if (OnFinished != null) OnFinished(tblGiaoDanReviewed, EventArgs.Empty);
        }

        private void reViewData()
        {
            if (OnExecuting != null) OnExecuting("Đang lấy dữ liệu giáo dân để kiểm tra...", EventArgs.Empty);
            string where = " AND DaXoa=0 ";
            if (MaGiaoHo > -1)
            {
                where += string.Format(" AND (MaGiaoHo={0}) ", MaGiaoHo);
            }
            tblGiaoDan = Memory.GetData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO + where);
            tblGiaoDan.Columns.Add(GxConstants.NGUYEN_NHAN, typeof(string));
            tblGiaoDan.Columns.Add(GxConstants.KETQUA_KIEMRA, typeof(int));

            tblThanhVienGiaDinh = Memory.GetTable(ThanhVienGiaDinhConst.TableName, "");
            if (Memory.ShowError()) return;

            tblGiaoDanHonPhoi = Memory.GetData(SqlConstants.SELECT_HONPHOI_CHECK_LIST, null);
            if (Memory.ShowError()) return;

            if (!Memory.ShowError() && tblGiaoDan != null)
            {
                if (OnExecuting != null) OnExecuting("Đang kiểm tra dữ liệu giáo dân...", EventArgs.Empty);
                tblGiaoDanReviewed = tblGiaoDan.Clone();
                foreach (DataRow row in tblGiaoDan.Rows)
                {
                    if (coNgayThangLoi(row) > 0 || kiemTraThanhVienGiaDinh(row) > 0 || kiemTraHonPhoi(row) > 0)
                    {
                        tblGiaoDanReviewed.ImportRow(row);
                    }
                }
                tblGiaoDan.Dispose();
                tblGiaoDan = null;
            }

            if (tblThanhVienGiaDinh != null)
            {
                tblThanhVienGiaDinh.Dispose();
                tblThanhVienGiaDinh = null;
            }

            if (tblGiaoDanHonPhoi != null)
            {
                tblGiaoDanHonPhoi.Dispose();
                tblGiaoDanHonPhoi = null;
            }
        }

        private int coNgayThangLoi(DataRow row)
        {
            int ketQua = 0;
            StringBuilder str = new StringBuilder();
            if (kiemTraKhongNgayThang)
            {
                if (Memory.IsNullOrEmpty(row[GiaoDanConst.NgaySinh]) && Memory.IsNullOrEmpty(row[GiaoDanConst.NgayRuaToi]) && Memory.IsNullOrEmpty(row[GiaoDanConst.NgayRuocLe]) &&
                                                        Memory.IsNullOrEmpty(row[GiaoDanConst.NgayThemSuc]) && Memory.IsNullOrEmpty(row[GiaoDanConst.NgayQuaDoi]))
                {
                    str.Append("- Không có dữ liệu ngày tháng\n");
                    ketQua += (int)ReviewGiaoDanType.KhongCoDuLieuNgayThang;
                }
            }
            if (KiemTraSaiQuanHeNgayThang)
            {
                if (!frmGiaoDan.isValidDateInputRelations(row[GiaoDanConst.NgaySinh], row[GiaoDanConst.NgayRuaToi], row[GiaoDanConst.NgayRuocLe],
                                                        row[GiaoDanConst.NgayThemSuc], DBNull.Value, row[GiaoDanConst.NgayQuaDoi]))
                {
                    str.Append("- Sai quan hệ ngày tháng\n");
                    ketQua += (int)ReviewGiaoDanType.SaiQuanHeNgayThang;
                }
            }
            if (kiemTraRuocLeTruocTuoi)
            {
                if (Memory.KiemTraTuoiKhongHopLe(row[GiaoDanConst.NgaySinh], row[GiaoDanConst.NgayRuocLe], GxConstants.TUOI_RUOCLE))
                {
                    str.Append(string.Format("- Rước lễ trước {0} tuổi\n", GxConstants.TUOI_RUOCLE));
                    ketQua += (int)ReviewGiaoDanType.RuocLeTruocTuoi;
                }
            }

            row[GxConstants.NGUYEN_NHAN] = str.ToString().Trim('\n');
            row[GxConstants.KETQUA_KIEMRA] = row[GxConstants.KETQUA_KIEMRA] != DBNull.Value ? (int)row[GxConstants.KETQUA_KIEMRA] + ketQua : ketQua;
            return ketQua;
        }

        private int kiemTraThanhVienGiaDinh(DataRow row)
        {
            int ketQua = 0;
            StringBuilder str = new StringBuilder();
            
            DataRow[] rows = null;
            if (kiemTraKhongThuocGiaDinh)
            {
                //kiem tra ko thuoc gia dinh nao
                rows = tblThanhVienGiaDinh.Select(string.Format("{0}={1}", GiaoDanConst.MaGiaoDan, row[GiaoDanConst.MaGiaoDan]));
                if (rows == null || rows.Length == 0)
                {
                    str.Append("- Không thuộc gia đình nào\n");
                    ketQua += (int)ReviewGiaoDanType.KhongThuocGiaDinhNao;
                }
            }
            if (kiemTraThuocNhieuGiaDinh)
            {
                //kiem tra ko thuoc nhieu gia dinh
                rows = tblThanhVienGiaDinh.Select(string.Format("{0}={1} AND MaGiaDinh>-1", GiaoDanConst.MaGiaoDan, row[GiaoDanConst.MaGiaoDan]));
                if (rows != null && rows.Length > 1)
                {
                    int maGiaDinh = -1;
                    int solan = 0;
                    string giaDinh = " (Mã GĐ: ";
                    foreach (DataRow row1 in rows)
                    {
                        if ((int)row1[ThanhVienGiaDinhConst.MaGiaDinh] != maGiaDinh)
                        {
                            solan++;
                            maGiaDinh = (int)row1[ThanhVienGiaDinhConst.MaGiaDinh];
                            giaDinh += maGiaDinh.ToString() + "; ";
                        }
                    }
                    if (solan > 1)
                    {
                        str.Append(string.Concat("- Thuộc nhiều gia đình\n", giaDinh.Remove(giaDinh.Length - 2), ")"));
                        ketQua += (int)ReviewGiaoDanType.ThuocNhieuGiaDinh;
                    }
                }
            }
            row[GxConstants.NGUYEN_NHAN] = string.Concat(row[GxConstants.NGUYEN_NHAN], str.ToString().Trim('\n'));
            row[GxConstants.KETQUA_KIEMRA] = row[GxConstants.KETQUA_KIEMRA] != DBNull.Value ? (int)row[GxConstants.KETQUA_KIEMRA] + ketQua : ketQua;
            return ketQua;
        }

        private int kiemTraHonPhoi(DataRow row)
        {
            int ketQua = 0;
            if (KiemTraNhieuHonPhoi)
            {
                int maGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
                StringBuilder str = new StringBuilder();
                if(tblGiaoDanHonPhoi != null)
                {
                    DataRow[] rowChecks = tblGiaoDanHonPhoi.Select(string.Concat("MaGiaoDan1=", maGiaoDan));
                    if (rowChecks != null && rowChecks.Length > 1)
                    {
                        str.Append("- Có nhiều thông tin hôn phối\n");
                        ketQua += (int)ReviewGiaoDanType.CoNhieuHonPhoi;
                    }
                    row[GxConstants.NGUYEN_NHAN] = string.Concat(row[GxConstants.NGUYEN_NHAN], str.ToString().Trim('\n'));
                    row[GxConstants.KETQUA_KIEMRA] = row[GxConstants.KETQUA_KIEMRA] != DBNull.Value ? (int)row[GxConstants.KETQUA_KIEMRA] + ketQua : ketQua;
                }
            }

            return ketQua;
        }
    }
}
