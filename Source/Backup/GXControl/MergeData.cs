using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using GxControl;
using GxGlobal;
using System.IO;
using System.ComponentModel;

namespace GxControl
{
    public class MergeData : IGxProcess
    {
        #region DECLARE
        private DataProvider provider = null;
        private DataTable tblGiaoHo = null;
        private DataTable tblGiaDinh = null;
        public DataTable tblGiaDinhCu = null;
        private DataTable tblHonPhoi = null;
        private DataTable tblGiaoDanHonPhoi = null;
        private DataTable tblGiaoDanHonPhoiCu = null;
        private DataTable tblGiaoDan = null;
        public DataTable tblGiaoDanMayCon = null;
        private DataTable tblThanhVienGiaDinh = null;
        private DataTable tblThanhVienGiaDinhCu = null;
        private DataTable tblDotBiTich = null;
        private DataTable tblBiTichChiTiet = null;
        private DataTable tblBiTichChiTietCu = null;
        //private DataTable tblChuyenXu = null;
        private int currentProgress = 0;

        private StreamWriter sw = null;
        public event EventHandler OnStart = null;
        public event CancelEventHandler OnError = null;
        public event EventHandler OnFinished = null;
        public event EventHandler OnExecuting = null;
        private ProcessOptions processOptions = ProcessOptions.MergeData;
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

        private bool overrideGiaoDan = true;

        public bool OverrideGiaoDan
        {
            get { return overrideGiaoDan; }
            set { overrideGiaoDan = value; }
        }

        private bool overrideGiaDinh = true;

        public bool OverrideGiaDinh
        {
            get { return overrideGiaDinh; }
            set { overrideGiaDinh = value; }
        }

        private bool forceOverrideGiaoDan = false;

        public bool ForceOverrideGiaoDan
        {
            get { return forceOverrideGiaoDan; }
            set { forceOverrideGiaoDan = value; }
        }

        private bool forceOverrideGiaDinh = false;

        public bool ForceOverrideGiaDinh
        {
            get { return forceOverrideGiaDinh; }
            set { forceOverrideGiaDinh = value; }
        }

        private bool overrideHonPhoi = false;

        public bool OverrideHonPhoi
        {
            get { return overrideHonPhoi; }
            set { overrideHonPhoi = value; }
        }

        private bool overrideBiTich = false;

        public bool OverrideBiTich
        {
            get { return overrideBiTich; }
            set { overrideBiTich = value; }
        }

        private bool forceOverrideHonPhoi = false;

        public bool ForceOverrideHonPhoi
        {
            get { return forceOverrideHonPhoi; }
            set { forceOverrideHonPhoi = value; }
        }

        private bool forceOverrideBiTich = false;

        public bool ForceOverrideBiTich
        {
            get { return forceOverrideBiTich; }
            set { forceOverrideBiTich = value; }
        }

        private bool overrideGiaoHo = false;

        public bool OverrideGiaoHo
        {
            get { return overrideGiaoHo; }
            set { overrideGiaoHo = value; }
        }

        #endregion

        #region Constants
        public const string KetQua = "KetQua";
        public const string MaGiaoDanMoi = "MaGiaoDanMoi";
        public const string MaGiaoDanCu = "MaGiaoDanCu";
        public const string MaGiaDinhMoi = "MaGiaDinhMoi";
        public const string DUPLICATED_NOT_UPDATE = "Trùng thông tin (không thêm vào)";
        public const string DUPLICATED_HAS_UPDATED = "Trùng thông tin (nhưng thêm vào vì có dữ liệu mới hơn)";
        public const string DUPLICATED_HAS_UPDATED_FORCE = "Trùng thông tin (nhưng thêm vào vì có chọn ép buộc)";
        public const string ADD_NEW = "Thêm mới";
        public const string NOT_FOUND = "Không tìm thấy";
        public const string TRUNG_TEN_KHAC_TVGD = "Thêm mới (Trùng tên gia đình nhưng khác thành viên)";
        #endregion

        #region Constructor
        public MergeData(string dbName, string user, string pass)
        {
            provider = new DataProvider(dbName, user, pass);
        }
        #endregion

        #region Begin import
        public void Execute()
        {
            string backupPath = "";
            try
            {
                //backup database                 
                Memory.BackupDatabase(out backupPath);

                Memory.ClearError();
                currentProgress = 0;
                sw = new StreamWriter(Memory.AppPath + "ImportLog.txt", true, Encoding.UTF8);
                //check valid db
                if (!IsValidDb())
                {
                    sw.WriteLine();
                    sw.WriteLine("START IMPORT FROM OWNER - " + DateTime.Now.ToString() + " -----------------------");
                    sw.WriteLine(GxConstants.MSG_INVALID_FILE_IMPORT);
                    sw.Write("END IMPORT FROM OWNER  - " + DateTime.Now.ToString() + " -----------------------");
                    sw.Close();
                    if (OnError != null) OnError(GxConstants.MSG_INVALID_FILE_IMPORT, new CancelEventArgs());
                    if (OnFinished != null) OnFinished("finished", EventArgs.Empty);
                    return;
                }
                int tong = 0;
                string sql = "SELECT COUNT(MaGiaDinh) FROM GiaDinh";
                DataTable tblTmp = provider.GetData(sql);
                if (tblTmp != null && tblTmp.Rows.Count > 0)
                {
                    tong = (int)tblTmp.Rows[0][0];
                }

                sql = "SELECT COUNT(MaGiaoDan) FROM GiaoDan";
                tblTmp = provider.GetData(sql);
                if (tblTmp != null && tblTmp.Rows.Count > 0)
                {
                    tong += (int)tblTmp.Rows[0][0];
                }

                sql = "SELECT COUNT(MaDotBiTich) FROM DotBiTich";
                tblTmp = provider.GetData(sql);
                if (tblTmp != null && tblTmp.Rows.Count > 0)
                {
                    tong += (int)tblTmp.Rows[0][0];
                }

                sql = "SELECT COUNT(MaChuyenXu) FROM ChuyenXu";
                tblTmp = provider.GetData(sql);
                if (tblTmp != null && tblTmp.Rows.Count > 0)
                {
                    tong += (int)tblTmp.Rows[0][0];
                }

                sql = "SELECT COUNT(MaHonPhoi) FROM HonPhoi";
                tblTmp = provider.GetData(sql);
                if (tblTmp != null && tblTmp.Rows.Count > 0)
                {
                    tong += (int)tblTmp.Rows[0][0];
                }

                Memory.Instance.SetMemory("TongDuLieu", tong);

                if (OnStart != null) OnStart("started", EventArgs.Empty);
                sw.WriteLine();
                sw.Write("START IMPORT FROM OWNER - " + DateTime.Now.ToString() + " -----------------------");
                try
                {
                    if (ImportGiaoHo())
                    {
                        if (ImportTatCaGiaoDan())
                        {
                            bool sc = false;
                            sc = ImportCacGiaDinh();
                            if (!sc) goto errorHandler;

                            sc = ImportCacHonPhoi();
                            if (!sc) goto errorHandler;

                            sc = ImportCacDotBitich();
                            if (!sc) goto errorHandler;

                            sc = ImportChuyenXu();
                            if (!sc) goto errorHandler;
                        }
                        else
                        {
                            goto errorHandler;
                        }
                    }
                    else
                    {
                        goto errorHandler;
                    }
                }
                catch (Exception ex)
                {
                    Memory.Instance.Error = ex;
                    sw.WriteLine("Import: " + ex.Message);
                    if (OnError != null) OnError("Import: " + ex.Message, new CancelEventArgs());
                    goto errorHandler;
                }
                finally
                {
                    sw.WriteLine();
                    sw.Write("END IMPORT FROM OWNER - " + DateTime.Now.ToString() + " -----------------------");
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Memory.ShowError(ex.Message);
                if (OnError != null) OnError("Import: " + ex.Message, new CancelEventArgs());
                goto errorHandler;
            }
            finally
            {
                if (OnFinished != null) OnFinished("finished", EventArgs.Empty);
            }

            return;

            errorHandler:
            Memory.RestoreDatabase(backupPath);
        }
        /// <summary>
        /// Return 
        /// 1: date1 greater then date2
        /// 0: date1 = date2
        /// -1: date1 less than date2
        /// </summary>
        private int compareUpdateDate(object date1, object date2)
        {
            return ((DateTime)date1).CompareTo((DateTime)date2);
        }
        #endregion

        #region For Giao ho
        private bool ImportGiaoHo()
        {
            try
            {
                if (OnExecuting != null) OnExecuting("Bắt đầu nhập các giáo họ", EventArgs.Empty);
                DataTable tblGiaoHoCu = provider.GetData("SELECT * FROM GiaoHo");
                int currentMaGiaoHo = Memory.Instance.GetNextId("GiaoHo", "MaGiaoHo", true);
                tblGiaoHo = Memory.GetData("SELECT * FROM GiaoHo");
                tblGiaoHo.TableName = "GiaoHo";
                tblGiaoHo.Columns.Add("MaGiaoHoCu", typeof(int));
                if (!Memory.HasError())
                {
                    foreach (DataRow row in tblGiaoHoCu.Rows)
                    {
                        //check user abort
                        bool userStop = (bool)Memory.Instance.GetMemory("UserAbort");
                        //if user abort progress, return
                        if (userStop) return false;

                        string tenGiaoHo = row["TenGiaoHo"].ToString();
                        //int maGiaoHo = -1;
                        if (OnExecuting != null) OnExecuting("Đang nhập giáo họ: " + tenGiaoHo, EventArgs.Empty);
                        DataRow[] rows = tblGiaoHo.Select("TenGiaoHo='" + tenGiaoHo.Replace("'", "''") + "'");
                        if (rows != null && rows.Length > 0)
                        {
                            rows[0]["MaGiaoHoCu"] = row[GiaoHoConst.MaGiaoHo];
                            //Neu muon chep de
                            if (overrideGiaoHo)
                            {
                                foreach (DataColumn col in row.Table.Columns)
                                {
                                    if (col.ColumnName == GiaoHoConst.MaGiaoHo) continue;
                                    //Chi override trong truong hop update date cua data may con lon hon update date cua data may chinh
                                    rows[0][col.ColumnName] = row[col];
                                }
                            }
                            if (tblGiaoHo.Columns.Contains(GiaoHoConst.MaNhanDang) && Memory.IsNullOrEmpty(rows[0][GiaoHoConst.MaNhanDang]))
                            {
                                rows[0][GiaoHoConst.MaNhanDang] = Memory.GetGiaoHoKey(row[GiaoHoConst.MaGiaoHo]);
                            }
                            continue;
                        }
                        else if (tblGiaoHo.Columns.Contains(GiaoHoConst.MaNhanDang))
                        {
                            rows = tblGiaoHo.Select(string.Format("MaNhanDang='{0}'", row[GiaoHoConst.MaNhanDang]));
                            if (rows != null && rows.Length > 0)
                            {
                                rows[0]["MaGiaoHoCu"] = row[GiaoHoConst.MaGiaoHo];
                                if (overrideGiaoHo)
                                {
                                    foreach (DataColumn col in row.Table.Columns)
                                    {
                                        if (col.ColumnName == GiaoHoConst.MaGiaoHo) continue;
                                        rows[0][col.ColumnName] = row[col];
                                    }
                                }
                                if (tblGiaoHo.Columns.Contains(GiaoHoConst.MaNhanDang) && Memory.IsNullOrEmpty(rows[0][GiaoHoConst.MaNhanDang]))
                                {
                                    rows[0][GiaoHoConst.MaNhanDang] = Memory.GetGiaoHoKey(row[GiaoHoConst.MaGiaoHo]);
                                }
                                continue;
                            }
                        }

                        DataRow newRow = tblGiaoHo.NewRow();
                        newRow["MaGiaoHo"] = currentMaGiaoHo++;
                        newRow["TenGiaoHo"] = tenGiaoHo;
                        newRow["MaGiaoHoCu"] = row["MaGiaoHo"];
                        newRow["UpdateDate"] = Memory.Instance.GetServerDateTime();
                        newRow[GiaoHoConst.MaNhanDang] = Memory.GetGiaoHoKey(newRow[GiaoHoConst.MaGiaoHo]);
                        tblGiaoHo.Rows.Add(newRow);
                    }
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblGiaoHo);
                    Memory.UpdateDataSet(ds);
                    if (OnExecuting != null) OnExecuting("Kết thúc nhập các giáo họ", EventArgs.Empty);
                    if (Memory.HasError())
                    {
                        if (OnError != null) OnError("Lỗi khi cập nhật các giáo họ", new CancelEventArgs());
                        return false;
                    }
                    ds.Tables.Remove(tblGiaoHo);
                }
                else
                {
                    if (OnError != null) OnError("Lỗi khi lấy dữ liệu giáo họ", new CancelEventArgs());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportGiaoHo: " + ex.Message);
                if (OnError != null) OnError("Có lỗi khi nhập dữ liệu giáo họ\r\n\t" + ex.Message, new CancelEventArgs());
                return false;
            }
            return true;
        }

        private int getMaGiaoHo(object maGiaoHoCu)
        {
            if (!Memory.IsNullOrEmpty(maGiaoHoCu) && int.Parse(maGiaoHoCu.ToString()) > 0)
            {
                DataRow[] ho = tblGiaoHo.Select(string.Format("MaGiaoHoCu = {0} ", maGiaoHoCu));
                if (ho != null && ho.Length > 0)
                {
                    return (int)ho[0][GiaoHoConst.MaGiaoHo];
                }
            }
            return 0; //Ngoai xu
        }
        #endregion

        #region For Giao dan
        private bool ImportTatCaGiaoDan()
        {
            try
            {
                if (OnExecuting != null) OnExecuting("Đang lấy dữ liệu giáo dân...", EventArgs.Empty);
                tblGiaoDan = Memory.GetData("SELECT * FROM GiaoDan");
                tblGiaoDan.Columns.Add(MaGiaoDanCu, typeof(int));

                tblGiaoDanMayCon = provider.GetData("SELECT * FROM GiaoDan");

                if (tblGiaoDanMayCon == null)
                {
                    Memory.Instance.Error = new Exception("Không tìm thấy dữ liệu gia đình và giáo dân");
                    sw.WriteLine(Memory.Instance.Error.Message);
                    if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }
                //Add result columns
                tblGiaoDanMayCon.Columns.Add(KetQua, typeof(string));
                tblGiaoDanMayCon.Columns.Add(MaGiaoDanMoi, typeof(int));

                for (int i = 0; i < tblGiaoDanMayCon.Rows.Count; i++)
                {
                    //check user abort
                    bool userStop = (bool)Memory.Instance.GetMemory("UserAbort");
                    //if user abort progress, return
                    if (userStop) return false;

                    currentProgress++;
                    Memory.Instance.SetMemory("DuLieuHienTai", currentProgress);

                    DataRow rowCon = tblGiaoDanMayCon.Rows[i];
                    string tenGiaoDan = rowCon["HoTen"].ToString();

                    if (OnExecuting != null) OnExecuting(string.Format("Đang xem xét giáo dân: {0}", tenGiaoDan), EventArgs.Empty);
                    //check giao dan ton tai hay chua?
                    DataRow[] rows = GetExistedGiaoDan(rowCon);
                    /************************************************************************************************/
                    //Neu giao dan do da ton tai
                        //Neu chon chep de thi chi
                            //voi nhung thong tin rong thi de vao ma khong can so sanh ngay gio
                            //voi nhung thong tin khac rong thi co so sanh ngay gio, cai nao moi hon thi lay cai do
                        //Neu khong chon chep de thi khong lam gi het
                    //Neu giao dan chua ton tai thi import vao
                    /************************************************************************************************/
                    if (rows != null && rows.Length > 0)
                    {
                        string baocao = DUPLICATED_NOT_UPDATE;
                        rows[0][MaGiaoDanCu] = rowCon[GiaoDanConst.MaGiaoDan];
                        
                        //if (overrideExisted
                        //    && (compareUpdateDate(rowCon[GiaoHoConst.UpdateDate], rows[0][GiaoHoConst.UpdateDate]) == 1))
                        if (overrideGiaoDan || forceOverrideGiaoDan)
                        {
                            bool isNewer = compareUpdateDate(rowCon[GiaoHoConst.UpdateDate], rows[0][GiaoHoConst.UpdateDate]) == 1;
                            foreach (DataColumn col in tblGiaoDanMayCon.Columns)
                            {
                                if (!tblGiaoDan.Columns.Contains(col.ColumnName)) continue;
                                if (col.ColumnName == GiaoDanConst.MaGiaoDan) continue;
                                object value = rowCon[col];
                                if (col.ColumnName == GiaoDanConst.MaGiaoHo)
                                {
                                    value = getMaGiaoHo(rowCon[GiaoDanConst.MaGiaoHo]);
                                }
                                if (col.ColumnName != GiaoDanConst.UpdateDate && value is DateTime) value = Memory.GetDateString(value);
                                if (col.ColumnName.StartsWith("Ngay"))
                                {
                                    value = Memory.GetStandardDateString(value);
                                }
                                if (forceOverrideGiaoDan)
                                {
                                    rows[0][col.ColumnName] = value;
                                    baocao = DUPLICATED_HAS_UPDATED_FORCE;
                                }
                                else
                                {
                                    if (Memory.IsNullOrEmpty(rows[0][col.ColumnName]) && !Memory.IsNullOrEmpty(value)
                                        || !Memory.IsNullOrEmpty(value) && isNewer)
                                    {
                                        rows[0][col.ColumnName] = value;
                                        baocao = DUPLICATED_HAS_UPDATED;
                                    }
                                }
                            }
                            if (tblGiaoDan.Columns.Contains(GiaoDanConst.MaNhanDang) && Memory.IsNullOrEmpty(rows[0][GiaoDanConst.MaNhanDang]))
                            {
                                rows[0][GiaoDanConst.MaNhanDang] = Memory.GetGiaoDanKey(rowCon[GiaoDanConst.MaGiaoDan]);
                            }
                        }
                        BaoCaoGiaoDan(rowCon, baocao, rows[0][GiaoDanConst.MaGiaoDan]);
                        continue;
                    }

                    //Neu giao dan chua ton tai thi import vao
                    DataRow newRow = tblGiaoDan.NewRow();
                    foreach (DataColumn col in tblGiaoDanMayCon.Columns)
                    {
                        if (tblGiaoDan.Columns.Contains(col.ColumnName))
                        {
                            object value = rowCon[col];
                            if (col.ColumnName != GiaoDanConst.UpdateDate && value is DateTime) value = Memory.GetDateString(value);
                            if (col.ColumnName.StartsWith("Ngay"))
                            {
                                value = Memory.GetStandardDateString(value);
                            }
                            newRow[col.ColumnName] = value;
                        }
                    }
                    newRow[GiaoDanConst.MaGiaoDan] = Memory.Instance.GetNextId(GiaoDanConst.TableName, GiaoDanConst.MaGiaoDan, false);
                    if (tblGiaoDan.Columns.Contains(GiaoDanConst.MaNhanDang) && Memory.IsNullOrEmpty(newRow[GiaoDanConst.MaNhanDang]))
                    {
                        newRow[GiaoDanConst.MaNhanDang] = Memory.GetGiaoDanKey(rowCon[GiaoDanConst.MaGiaoDan]);
                    }
                    newRow[MaGiaoDanCu] = rowCon[GiaoDanConst.MaGiaoDan];
                    newRow[GiaoDanConst.MaGiaoHo] = getMaGiaoHo(rowCon[GiaoDanConst.MaGiaoHo]);
                    tblGiaoDan.Rows.Add(newRow);
                    BaoCaoGiaoDan(rowCon, ADD_NEW, newRow[GiaoDanConst.MaGiaoDan]);
                }
                if (OnExecuting != null) OnExecuting("Đang cập nhật dữ liệu giáo dân vào chương trình...", EventArgs.Empty);
                DataSet ds = new DataSet();
                tblGiaoDan.TableName = GiaoDanConst.TableName;
                ds.Tables.Add(tblGiaoDan);

                Memory.UpdateDataSet(ds);
                if (!Memory.HasError())
                {
                    return true;
                }
                else
                {
                    sw.WriteLine("ImportTatCaGiaoDan: " + Memory.Instance.Error.Message);
                    if (OnError != null) OnError("Cập nhật dữ liệu giáo dân xuống database của chương trình bị thất bại. \r\n\t" + Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }

            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportTatCaGiaoDan: " + ex.Message);
                if (OnError != null) OnError("Có lỗi chung xảy ra khi nhập dữ liệu giáo dân. Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t" + ex.Message, new CancelEventArgs());
                return false;
            }
        }

        private void BaoCaoGiaoDan(DataRow oldRow, string ketQua, object maGiaoDanMoi)
        {
            oldRow[KetQua] = ketQua;
            oldRow[MaGiaoDanMoi] = maGiaoDanMoi;
        }

        private DataRow[] GetExistedGiaoDan(DataRow row)
        {
            string strCheck = "";
            DataRow[] rows = null;
            //Tim theo ma nhan dang truoc, neu ma nhan dang ma trung thi chac chan roi
            if (row.Table.Columns.Contains("MaNhanDang"))
            {
                strCheck = string.Format(" MaNhanDang='{0}'", row[GiaoDanConst.MaNhanDang]);
                rows = tblGiaoDan.Select(strCheck);
                if (rows != null && rows.Length > 0)
                {
                    return rows;
                }
            }
            //Neu tim theo ma nhan dang ma khong thay thi vui long tim theo thong tin chi tiet
            //Neu co nhap ngay sinh thi chi can so sanh TenThanh, HoTen, NgaySinh
            if (row[GiaoDanConst.NgaySinh].ToString() != "" && row[GiaoDanConst.TenThanh].ToString() != "")
            {
                strCheck = string.Format("TenThanh='{0}' AND HoTen='{1}' ",
                                         row[GiaoDanConst.TenThanh].ToString().Replace("'", "''"),
                                         row[GiaoDanConst.HoTen].ToString().Replace("'", "''"), row[GiaoDanConst.Phai]);
            }
            else //Nguoc lai thi so sanh 5 yeu to
            {
                strCheck = string.Format("TenThanh='{0}' AND HoTen='{1}' AND Phai='{2}' AND HoTenCha='{3}' AND HoTenMe='{4}'",
                                             row[GiaoDanConst.TenThanh].ToString().Replace("'", "''"),
                                             row[GiaoDanConst.HoTen].ToString().Replace("'", "''"), row[GiaoDanConst.Phai],
                                             row[GiaoDanConst.HoTenCha].ToString().Replace("'", "''"),
                                             row[GiaoDanConst.HoTenMe].ToString().Replace("'", "''"));
            }
            if (row[GiaoDanConst.NgaySinh] == DBNull.Value) strCheck += " AND NgaySinh IS NULL";
            else strCheck += string.Format(" AND NgaySinh='{0}'", Memory.GetDateString(row[GiaoDanConst.NgaySinh]));
            rows = tblGiaoDan.Select(strCheck);
            if (rows != null && rows.Length > 1)
            {//Neu tim thay nhieu nguoi thi hay chon dai nguoi nao chua qua doi ma cung chua bi xoa
                foreach (DataRow rowExisted in rows)
                {
                    if ((bool)rowExisted[GiaoDanConst.DaXoa] == false
                        && (bool)rowExisted[GiaoDanConst.QuaDoi] == false)
                    {
                        return new DataRow[] { rowExisted };
                    }
                }
                //Neu cung khong co nguoi nao thoa dieu kien tren thi return het ve di
            }
            
            return rows;
        }

        private int FindMaGiaoDan(int maThanhVien)
        {
            string s = string.Format("MaGiaoDanCu = '{0}'", maThanhVien);
            DataRow[] rows = tblGiaoDan.Select(s);
            if (rows != null && rows.Length > 0)
            {
                return (int)rows[0][GiaoDanConst.MaGiaoDan];
            }
            return -1;
        }
        #endregion

        #region For Gia dinh
        private bool ImportCacGiaDinh()
        {
            try
            {
                if (OnExecuting != null) OnExecuting("Đang lấy dữ liệu gia đình...", EventArgs.Empty);

                tblGiaDinh = Memory.GetData("SELECT * FROM GiaDinh");
                tblGiaDinhCu = provider.GetData("SELECT * FROM GiaDinh");
                tblThanhVienGiaDinh = Memory.GetData("SELECT * FROM ThanhVienGiaDinh");
                tblThanhVienGiaDinhCu = provider.GetData("SELECT * FROM ThanhVienGiaDinh");

                if (tblThanhVienGiaDinh == null || tblThanhVienGiaDinhCu == null || tblGiaDinhCu == null)
                {
                    Memory.Instance.Error = new Exception("Có lỗi khi lấy dữ liệu gia đình");
                    sw.WriteLine(Memory.Instance.Error.Message);
                    if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }
                //Thêm các cột báo cáo kết quả
                tblGiaDinhCu.Columns.Add(KetQua, typeof(string));
                tblGiaDinhCu.Columns.Add(MaGiaDinhMoi, typeof(int));

                string tenGiaDinh = "";
                int maGiaDinh = -1;

                for (int i = 0; i < tblGiaDinhCu.Rows.Count; i++)
                {
                    //check user abort
                    bool userStop = (bool)Memory.Instance.GetMemory("UserAbort");
                    //if user abort progress, return
                    if (userStop) return false;
                    DataRow row = tblGiaDinhCu.Rows[i];
                    tenGiaDinh = row["TenGiaDinh"].ToString();
                    bool isExisted = false;
                    bool allowOverride = true;
                    maGiaDinh = ImportGiaDinh(row, out isExisted, out allowOverride);

                    currentProgress++;
                    Memory.Instance.SetMemory("DuLieuHienTai", currentProgress);

                    if (OnExecuting != null) OnExecuting(string.Format("Đang nhập gia đình: {0}", tenGiaDinh), EventArgs.Empty);

                    bool importTVGDThanhCong = true;
                    if (isExisted)
                    {
                        if (overrideGiaDinh && allowOverride || forceOverrideGiaDinh)
                        {
                            //delete old
                            DataRow[] tvgdExisted = tblThanhVienGiaDinh.Select(string.Format("MaGiaDinh={0}", maGiaDinh));
                            if (tvgdExisted != null && tvgdExisted.Length > 0)
                            {
                                for (int j = 0; j < tvgdExisted.Length; j++)
                                {
                                    tvgdExisted[j].Delete();
                                }
                            }
                            //add new
                            importTVGDThanhCong = ImportThanhVienGiaDinh((int)row[ThanhVienGiaDinhConst.MaGiaDinh], maGiaDinh);
                        }
                        //else, don't do anything
                    }
                    else //if not existed
                    {
                        importTVGDThanhCong = ImportThanhVienGiaDinh((int)row[ThanhVienGiaDinhConst.MaGiaDinh], maGiaDinh);
                    }
                    if (!importTVGDThanhCong)
                    {
                        Memory.Instance.Error = new Exception("Có lỗi khi nhập các thành viên gia đình " + tenGiaDinh);
                        sw.WriteLine(Memory.Instance.Error.Message);
                        if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    }
                }
                if (OnExecuting != null) OnExecuting("Đang hoàn tất việc cập nhật dữ liệu vào chương trình...", EventArgs.Empty);

                DataSet ds = new DataSet();

                tblGiaDinh.TableName = GiaDinhConst.TableName;
                ds.Tables.Add(tblGiaDinh);

                tblThanhVienGiaDinh.TableName = ThanhVienGiaDinhConst.TableName;
                ds.Tables.Add(tblThanhVienGiaDinh);

                Memory.UpdateDataSet(ds);

                if (!Memory.HasError())
                {
                    return true;
                }
                else
                {
                    sw.WriteLine("ImportCacGiaDinh: " + Memory.Instance.Error.Message);
                    if (OnError != null) OnError("Cập nhật dữ liệu gia đình xuống database của chương trình bị thất bại. Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t" + Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }

            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportCacGiaDinh: " + ex.Message);
                if (OnError != null) OnError("Có lỗi chung xảy ra khi nhập dữ liệu các gia đình. " + ex.Message, new CancelEventArgs());
                return false;
            }
        }

        private bool ImportThanhVienGiaDinh(int maGiaDinhCu, int maGiaDinhMoi)
        {
            try
            {
                DataRow[] rows = tblThanhVienGiaDinhCu.Select("MaGiaDinh=" + maGiaDinhCu.ToString(), "MaGiaoDan DESC");
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        //check existance
                        int maGiaoDan = FindMaGiaoDan((int)row[GiaoDanConst.MaGiaoDan]);
                        int vaiTro = (int)row[ThanhVienGiaDinhConst.VaiTro];
                        if (maGiaoDan == -1)
                        {
                            //Neu khong tim thay giao dan nay trong du lieu moi thi thoi
                            continue;
                        }

                        //Kiem tra giao dan nay da ton tai trong gia dinh chua
                        DataRow[] thanhviens = tblThanhVienGiaDinh.Select(string.Format("MaGiaDinh={0} AND MaGiaoDan={1}", maGiaDinhMoi, maGiaoDan));
                        if (thanhviens != null && thanhviens.Length > 0) continue;//Neu co roi thi thoi

                        //Kiem tra gia dinh nay da co thanh vien nao cung vai tro la vo hoac chong chua
                        if (vaiTro == 0 || vaiTro == 1)
                        {
                            thanhviens = tblThanhVienGiaDinh.Select(string.Format("MaGiaDinh={0} AND VaiTro={1}", maGiaDinhMoi, vaiTro));
                            if (thanhviens != null && thanhviens.Length > 0) continue;//Neu co roi thi thoi
                        }

                        //Neu chua co thi them moi
                        DataRow newRow = tblThanhVienGiaDinh.NewRow();
                        newRow[ThanhVienGiaDinhConst.MaGiaDinh] = maGiaDinhMoi;
                        newRow[ThanhVienGiaDinhConst.MaGiaoDan] = maGiaoDan;
                        newRow[ThanhVienGiaDinhConst.VaiTro] = vaiTro;

                        tblThanhVienGiaDinh.Rows.Add(newRow);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportThanhVienGiaDinh: " + ex.Message);
                return false;
            }
        }

        private DataRow FindGiaDinh(DataRow oldRow)
        {
            string s = "";
            DataRow[] rows = null;
            //Neu ma nhan dang ma giong nhau thi chac chan la gia dinh do roi
            if (oldRow.Table.Columns.Contains(GiaDinhConst.MaNhanDang) && !Memory.IsNullOrEmpty(oldRow[GiaDinhConst.MaNhanDang]))
            {
                s = string.Format("MaNhanDang='{0}'", oldRow[GiaDinhConst.MaNhanDang]);
                rows = tblGiaDinh.Select(s);
                if (rows != null && rows.Length > 0)
                {
                    return rows[0];
                }
            }
            //Neu ma nhan dang ma khac nhau thi xet them cac thong tin khac, 
            //vi co the co truong hop 2 may cung nhap 1 gia dinh nen ma nhan dang khac nhau nhung lai cung gia dinh
            s = string.Format("TenGiaDinh = '{0}' AND DiaChi = '{1}' AND DienThoai = '{2}' AND GhiChu = '{3}' ",
                                            oldRow["TenGiaDinh"].ToString().Replace("'", "''"),
                                            oldRow["DiaChi"].ToString().Replace("'", "''"),
                                            oldRow["DienThoai"].ToString().Replace("'", "''"),
                                            oldRow["GhiChu"].ToString().Replace("'", "''"));
            rows = tblGiaDinh.Select(s);
            if (rows != null && rows.Length > 0)
            {
                //kiem tra su giong nhau giua gia dinh cu va gia dinh moi dua tren cac thanh vien gia dinh
                //vi co truong hop cac thong tin cua gia dinh thi giong nhau, nhung lai la 2 gia dinh khac nhau
                //va co cac thanh vien trong gia dinh khac nhau
                //neu co 1 thanh vien trong gia dinh nay co luon trong gia dinh kia va cung vai tro thi coi nhu 2 gia dinh do la 1
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow[] rowTVGDCu = tblThanhVienGiaDinhCu.Select(string.Format("MaGiaDinh={0}", oldRow[GiaDinhConst.MaGiaDinh]));
                    DataRow[] rowTVGDMoi = tblThanhVienGiaDinh.Select(string.Format("MaGiaDinh={0}", rows[i][GiaDinhConst.MaGiaDinh]));
                    bool giongNhau = false;
                    List<int> lstTVGiaDinhCu = new List<int>();
                    Dictionary<int, int> dicVaiTro = new Dictionary<int, int>();
                    foreach (DataRow row1 in rowTVGDCu)
                    {
                        int maGiaoDanMoi = FindMaGiaoDan((int)row1[ThanhVienGiaDinhConst.MaGiaoDan]);
                        if (maGiaoDanMoi > -1)
                        {
                            lstTVGiaDinhCu.Add(maGiaoDanMoi);
                            if (!dicVaiTro.ContainsKey(maGiaoDanMoi))
                            {
                                dicVaiTro.Add(maGiaoDanMoi, (int)row1[ThanhVienGiaDinhConst.VaiTro]);
                            }
                        }
                    }
                    foreach (DataRow row2 in rowTVGDMoi)
                    {
                        //Neu gia dinh moi ma co 1 thanh vien nao do giong trong gia dinh cu (giong ma va vai tro) thi coi nhu la giong nhau
                        if (lstTVGiaDinhCu.Contains((int)row2[ThanhVienGiaDinhConst.MaGiaoDan]) &&
                            dicVaiTro.ContainsKey((int)row2[ThanhVienGiaDinhConst.MaGiaoDan]) &&
                            dicVaiTro[(int)row2[ThanhVienGiaDinhConst.MaGiaoDan]] == (int)row2[ThanhVienGiaDinhConst.VaiTro])
                        {
                            giongNhau = true;
                            break;
                        }
                    }
                    //Neu tim duoc thi return
                    if (giongNhau)
                    {
                        //if (!Memory.IsNullOrEmpty(oldRow[KetQua]))
                        //{
                        //    BaoCaoGiaDinh(oldRow, "", rows[i][GiaDinhConst.MaGiaDinh]);
                        //}
                        return rows[i];
                    }
                    //else
                    //{
                    //    BaoCaoGiaDinh(oldRow, TRUNG_TEN_KHAC_TVGD, rows[i][GiaDinhConst.MaGiaDinh]);
                    //}
                }

                ////if khong khac nhau
                //return rows[0];
            }

            //if (rows != null && rows.Length > 0)
            //{
            //    return rows[0];
            //}
            return null;
        }

        private int ImportGiaDinh(DataRow rowCon, out bool isExisted, out bool allowOverride)
        {
            isExisted = false;
            allowOverride = true;
            try
            {
                DataRow rowChu = FindGiaDinh(rowCon);
                /************************************************************************************************/
                //Neu gia dinh do da ton tai
                    //Neu chon chep de thi chi
                        //voi nhung thong tin rong thi de vao ma khong can so sanh ngay gio
                        //voi nhung thong tin khac rong thi co so sanh ngay gio, cai nao moi hon thi lay cai do
                    //Neu khong chon chep de thi khong lam gi het
                //Neu gia dinh chua ton tai thi import vao
                /************************************************************************************************/
                if (rowChu != null)
                {
                    string baocao = DUPLICATED_NOT_UPDATE;
                    //if (overrideExistedGiaoDan
                    //    && (compareUpdateDate(row[GiaoHoConst.UpdateDate], rowTmp[GiaoHoConst.UpdateDate]) == 1))
                    if (overrideGiaDinh || forceOverrideGiaDinh)
                    {
                        bool isNewer = (compareUpdateDate(rowCon[GiaoHoConst.UpdateDate], rowChu[GiaoHoConst.UpdateDate]) == 1);
                        foreach (DataColumn col in rowCon.Table.Columns)
                        {
                            if (col.ColumnName == GiaDinhConst.MaGiaDinh) continue;
                            object value = rowCon[col];
                            if (col.ColumnName == GiaDinhConst.MaGiaoHo)
                            {
                                value = getMaGiaoHo(rowCon[col]);
                            }
                            if (rowChu.Table.Columns.Contains(col.ColumnName))
                            {
                                if (forceOverrideGiaDinh)
                                {
                                    rowChu[col.ColumnName] = value;
                                    baocao = DUPLICATED_HAS_UPDATED_FORCE;
                                }
                                else
                                {
                                    //Chi de nhung thong tin may chinh la rong hay may con moi hon
                                    if (Memory.IsNullOrEmpty(rowChu[col.ColumnName]) && !Memory.IsNullOrEmpty(rowCon[col.ColumnName]) 
                                        || !Memory.IsNullOrEmpty(rowCon[col.ColumnName]) && isNewer)
                                    {
                                        rowChu[col.ColumnName] = value;
                                        baocao = DUPLICATED_HAS_UPDATED;
                                    }
                                }
                            }
                        }

                        if (!isNewer) allowOverride = false;
                        if (forceOverrideGiaDinh) allowOverride = true;
                    }
                    else
                    {
                        allowOverride = false;
                    }
                    if (tblGiaDinh.Columns.Contains(GiaDinhConst.MaNhanDang) && Memory.IsNullOrEmpty(rowChu[GiaDinhConst.MaNhanDang]))
                    {
                        rowChu[GiaDinhConst.MaNhanDang] = Memory.GetGiaDinhKey(rowChu[GiaDinhConst.MaGiaDinh]);
                    }
                    isExisted = true;

                    BaoCaoGiaDinh(rowCon, baocao, rowChu[GiaDinhConst.MaGiaDinh]);

                    return (int)rowChu[GiaDinhConst.MaGiaDinh];
                }
                int maGiaDinh = Memory.Instance.GetNextId(GiaDinhConst.TableName, GiaDinhConst.MaGiaDinh, false);
                DataRow row1 = tblGiaDinh.NewRow();
                assignGiaDinh(maGiaDinh, row1, rowCon);
                tblGiaDinh.Rows.Add(row1);
                if (Memory.IsNullOrEmpty(rowCon[KetQua]))
                {
                    BaoCaoGiaDinh(rowCon, ADD_NEW, maGiaDinh);
                }

                return maGiaDinh;
            }
            catch (Exception ex)
            {
                sw.WriteLine("ImportGiaDinh: " + rowCon["TenGiaDinh"].ToString() + " - " + ex.Message);
                Memory.Instance.Error = ex;
                if (OnError != null) OnError("Có lỗi khi nhập dữ liệu gia đình" + rowCon["TenGiaDinh"].ToString(), new CancelEventArgs());
            }
            return -1;
        }

        private void BaoCaoGiaDinh(DataRow oldRow, string ketQua, object maGiaDinhMoi)
        {
            oldRow[KetQua] = ketQua;
            oldRow[MaGiaDinhMoi] = maGiaDinhMoi;
        }

        private void assignGiaDinh(int maGiaDinh, DataRow newRow, DataRow oldRow)
        {
            foreach (DataColumn col in tblGiaDinh.Columns)
            {
                if (oldRow.Table.Columns.Contains(col.ColumnName))
                {
                    object value = oldRow[col.ColumnName];
                    if (col.ColumnName != GiaDinhConst.UpdateDate && value is DateTime) value = Memory.GetDateString(value);
                    if (col.ColumnName.StartsWith("Ngay"))
                    {
                        value = Memory.GetStandardDateString(value);
                    }
                    newRow[col.ColumnName] = value;
                }
            }

            newRow[GiaDinhConst.MaGiaDinh] = maGiaDinh;
            newRow[GiaDinhConst.MaGiaoHo] = getMaGiaoHo(oldRow[GiaDinhConst.MaGiaoHo]);
            if (tblGiaDinh.Columns.Contains(GiaDinhConst.MaNhanDang) && Memory.IsNullOrEmpty(newRow[GiaDinhConst.MaNhanDang]))
            {
                newRow[GiaDinhConst.MaNhanDang] = Memory.GetGiaDinhKey(newRow[GiaDinhConst.MaGiaDinh]);
            }
        }
        #endregion

        #region For Hon Phoi
        private bool ImportCacHonPhoi()
        {
            try
            {
                if (OnExecuting != null) OnExecuting("Đang lấy dữ liệu hôn phối...", EventArgs.Empty);

                tblHonPhoi = Memory.GetData("SELECT * FROM HonPhoi");
                DataTable tblHonPhoiCu = provider.GetData("SELECT * FROM HonPhoi");
                tblGiaoDanHonPhoi = Memory.GetData("SELECT * FROM GiaoDanHonPhoi");
                tblGiaoDanHonPhoiCu = provider.GetData("SELECT * FROM GiaoDanHonPhoi");

                if (tblGiaoDanHonPhoi == null || tblGiaoDanHonPhoiCu == null || tblHonPhoiCu == null)
                {
                    Memory.Instance.Error = new Exception("Có lỗi khi lấy dữ liệu hôn phối");
                    sw.WriteLine(Memory.Instance.Error.Message);
                    if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }
                string tenHonPhoi = "";
                int maHonPhoi = -1;

                for (int i = 0; i < tblHonPhoiCu.Rows.Count; i++)
                {
                    //check user abort
                    bool userStop = (bool)Memory.Instance.GetMemory("UserAbort");
                    //if user abort progress, return
                    if (userStop) return false;
                    DataRow row = tblHonPhoiCu.Rows[i];
                    tenHonPhoi = row["TenHonPhoi"].ToString();
                    bool isExisted = false;
                    bool allowOverride = true;
                    maHonPhoi = ImportHonPhoi(row, out isExisted, out allowOverride);

                    currentProgress++;
                    Memory.Instance.SetMemory("DuLieuHienTai", currentProgress);

                    if (OnExecuting != null) OnExecuting(string.Format("Đang nhập đôi hôn phối: {0}", tenHonPhoi), EventArgs.Empty);

                    bool importGDHPThanhCong = true;
                    if (isExisted)
                    {
                        if (overrideHonPhoi && allowOverride || forceOverrideHonPhoi)
                        {
                            //delete old
                            DataRow[] tvgdExisted = tblGiaoDanHonPhoi.Select(string.Format("MaHonPhoi={0}", maHonPhoi));
                            if (tvgdExisted != null && tvgdExisted.Length > 0)
                            {
                                for (int j = 0; j < tvgdExisted.Length; j++)
                                {
                                    tvgdExisted[j].Delete();
                                }
                            }
                            //add new
                            importGDHPThanhCong = ImportGiaoDanHonPhoi((int)row[GiaoDanHonPhoiConst.MaHonPhoi], maHonPhoi);
                        }
                        //else, don't do anything
                    }
                    else //if not existed
                    {
                        importGDHPThanhCong = ImportGiaoDanHonPhoi((int)row[GiaoDanHonPhoiConst.MaHonPhoi], maHonPhoi);
                    }
                    if (!importGDHPThanhCong)
                    {
                        Memory.Instance.Error = new Exception("Có lỗi khi nhập các thành viên hôn phối " + tenHonPhoi);
                        sw.WriteLine(Memory.Instance.Error.Message);
                        if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    }
                }
                if (OnExecuting != null) OnExecuting("Đang hoàn tất việc cập nhật dữ liệu vào chương trình...", EventArgs.Empty);

                DataSet ds = new DataSet();

                tblHonPhoi.TableName = HonPhoiConst.TableName;
                ds.Tables.Add(tblHonPhoi);

                tblGiaoDanHonPhoi.TableName = GiaoDanHonPhoiConst.TableName;
                ds.Tables.Add(tblGiaoDanHonPhoi);

                Memory.UpdateDataSet(ds);

                if (!Memory.HasError())
                {
                    return true;
                }
                else
                {
                    sw.WriteLine("ImportCacHonPhoi: " + Memory.Instance.Error.Message);
                    if (OnError != null) OnError("Cập nhật dữ liệu hôn phối xuống database của chương trình bị thất bại. Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t" + Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }

            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportCacHonPhoi: " + ex.Message);
                if (OnError != null) OnError("Có lỗi chung xảy ra khi nhập dữ liệu các hôn phối. " + ex.Message, new CancelEventArgs());
                return false;
            }
        }

        private bool ImportGiaoDanHonPhoi(int maHonPhoiCu, int maHonPhoiMoi)
        {
            try
            {
                DataRow[] rows = tblGiaoDanHonPhoiCu.Select("MaHonPhoi=" + maHonPhoiCu.ToString());
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        //check existance
                        int maGiaoDan = FindMaGiaoDan((int)row[GiaoDanConst.MaGiaoDan]);
                        if (maGiaoDan == -1)
                        {
                            //maGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
                            continue;//fix bug from version 2.0.0.4
                        }
                        DataRow[] vochong = tblGiaoDanHonPhoi.Select(string.Format("MaHonPhoi={0} AND MaGiaoDan={1}", maHonPhoiMoi, maGiaoDan));
                        if (vochong != null && vochong.Length > 0) continue;

                        //Add to new
                        DataRow newRow = tblGiaoDanHonPhoi.NewRow();
                        newRow[GiaoDanHonPhoiConst.MaHonPhoi] = maHonPhoiMoi;
                        newRow[GiaoDanHonPhoiConst.MaGiaoDan] = maGiaoDan;
                        newRow[GiaoDanHonPhoiConst.SoThuTu] = row[GiaoDanHonPhoiConst.SoThuTu];

                        tblGiaoDanHonPhoi.Rows.Add(newRow);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImporttblGiaoDanHonPhoi: " + ex.Message);
                return false;
            }
        }

        private DataRow FindHonPhoi(DataRow oldRow)
        {
            string s = "";
            DataRow[] rows = null;
            //Tim theo ma nhan dang truoc, neu ma nhan dang ma trung thi chac chan la no roi
            if (oldRow.Table.Columns.Contains(HonPhoiConst.MaNhanDang) && !Memory.IsNullOrEmpty(oldRow[HonPhoiConst.MaNhanDang]))
            {
                s = string.Format("MaNhanDang='{0}'", oldRow[HonPhoiConst.MaNhanDang]);
                rows = tblHonPhoi.Select(s);
                if (rows != null && rows.Length > 0)
                {
                    return rows[0];
                }
            }
            //Neu tim theo ma nhan dang ma khong thay thi tim them theo thong tin chi tiet
            string ngayHPQuery = oldRow["NgayHonPhoi"] == DBNull.Value ? " NgayHonPhoi IS NULL " : string.Format(" NgayHonPhoi = '{0}'", Memory.GetDateString(oldRow["NgayHonPhoi"]));
            string soHPQuery = oldRow["SoHonPhoi"] == DBNull.Value ? " SoHonPhoi IS NULL " : string.Format(" SoHonPhoi = '{0}'", oldRow["SohonPhoi"]);
            s = string.Format("TenHonPhoi = '{0}' AND {1} AND {2}",
                                            oldRow["TenHonPhoi"].ToString().Replace("'", "''"),
                                            ngayHPQuery,
                                            soHPQuery);
            rows = tblHonPhoi.Select(s);
            
            if (rows != null && rows.Length > 0)
            {
                return rows[0];
            }
            return null;
        }

        private int ImportHonPhoi(DataRow row, out bool isExisted, out bool allowOverride)
        {
            isExisted = false;
            allowOverride = true;
            try
            {
                DataRow rowTmp = FindHonPhoi(row);
                if (rowTmp != null)
                {
                    if (overrideHonPhoi || forceOverrideHonPhoi)
                    {
                        bool isNewer = (compareUpdateDate(row[GiaoHoConst.UpdateDate], rowTmp[GiaoHoConst.UpdateDate]) == 1);
                        foreach (DataColumn col in row.Table.Columns)
                        {
                            if (col.ColumnName == HonPhoiConst.MaHonPhoi) continue;
                            if (forceOverrideHonPhoi
                                || Memory.IsNullOrEmpty(rowTmp[col.ColumnName]) && !Memory.IsNullOrEmpty(row[col.ColumnName])
                                || !Memory.IsNullOrEmpty(row[col.ColumnName]) && isNewer)
                            {
                                rowTmp[col.ColumnName] = row[col];
                            }
                        }
                        if (!isNewer) allowOverride = false;
                        if (forceOverrideHonPhoi) allowOverride = true;
                    }
                    else
                    {
                        allowOverride = false;
                    }
                    if (tblHonPhoi.Columns.Contains(HonPhoiConst.MaNhanDang) && Memory.IsNullOrEmpty(rowTmp[HonPhoiConst.MaNhanDang]))
                    {
                        rowTmp[HonPhoiConst.MaNhanDang] = Memory.GetGiaDinhKey(rowTmp[HonPhoiConst.MaHonPhoi]);
                    }
                    isExisted = true;
                    return (int)rowTmp[HonPhoiConst.MaHonPhoi];
                }
                int maHonPhoi = Memory.Instance.GetNextId(HonPhoiConst.TableName, HonPhoiConst.MaHonPhoi, false);
                DataRow row1 = tblHonPhoi.NewRow();
                assignHonPhoi(maHonPhoi, row1, row);
                tblHonPhoi.Rows.Add(row1);
                return maHonPhoi;

            }
            catch (Exception ex)
            {
                sw.WriteLine("ImportHonPhoi: " + row["TenHonPhoi"].ToString() + " - " + ex.Message);
                Memory.Instance.Error = ex;
                if (OnError != null) OnError("Có lỗi khi nhập dữ liệu hôn phối" + row["TenHonPhoi"].ToString(), new CancelEventArgs());
            }
            return -1;
        }

        private void assignHonPhoi(int maGiaDinh, DataRow newRow, DataRow oldRow)
        {
            foreach (DataColumn col in tblHonPhoi.Columns)
            {
                if (oldRow.Table.Columns.Contains(col.ColumnName))
                {
                    object value = oldRow[col.ColumnName];
                    if (col.ColumnName != HonPhoiConst.UpdateDate && value is DateTime) value = Memory.GetDateString(value);
                    if (col.ColumnName.StartsWith("Ngay"))
                    {
                        value = Memory.GetStandardDateString(value);
                    }
                    newRow[col.ColumnName] = value;
                }
            }

            newRow[HonPhoiConst.MaHonPhoi] = maGiaDinh;
            if (tblHonPhoi.Columns.Contains(HonPhoiConst.MaNhanDang) && Memory.IsNullOrEmpty(newRow[HonPhoiConst.MaNhanDang]))
            {
                newRow[HonPhoiConst.MaNhanDang] = Memory.GetHonPhoiKey(newRow[HonPhoiConst.MaHonPhoi]);
            }
        }
        #endregion

        #region For Bi tich
        private bool ImportCacDotBitich()
        {
            try
            {
                if (OnExecuting != null) OnExecuting("Đang lấy dữ liệu bí tích...", EventArgs.Empty);

                tblDotBiTich = Memory.GetData("SELECT * FROM DotBiTich");
                DataTable tblDotBiTichCu = provider.GetData("SELECT * FROM DotBiTich");
                tblBiTichChiTiet = Memory.GetData("SELECT * FROM BiTichChiTiet");
                tblBiTichChiTietCu = provider.GetData("SELECT * FROM BiTichChiTiet");

                if (tblBiTichChiTiet == null || tblBiTichChiTietCu == null || tblDotBiTichCu == null)
                {
                    Memory.Instance.Error = new Exception("Có lỗi khi lấy dữ liệu bí tích");
                    sw.WriteLine(Memory.Instance.Error.Message);
                    if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }
                string tenDotBiTich = "";
                int maDotBiTich = -1;

                for (int i = 0; i < tblDotBiTichCu.Rows.Count; i++)
                {
                    //check user abort
                    bool userStop = (bool)Memory.Instance.GetMemory("UserAbort");
                    //if user abort progress, return
                    if (userStop) return false;
                    DataRow row = tblDotBiTichCu.Rows[i];
                    tenDotBiTich = row[DotBiTichConst.MoTa].ToString();
                    maDotBiTich = ImportDotBiTich(row);

                    currentProgress++;
                    Memory.Instance.SetMemory("DuLieuHienTai", currentProgress);

                    if (OnExecuting != null) OnExecuting(string.Format("Đang nhập đợt bí tích: {0}", tenDotBiTich), EventArgs.Empty);

                    if (!ImportBiTichChiTiet((int)row[BiTichChiTietConst.MaDotBiTich], maDotBiTich))
                    {
                        Memory.Instance.Error = new Exception("Có lỗi khi nhập các thành viên bí tích " + tenDotBiTich);
                        sw.WriteLine(Memory.Instance.Error.Message);
                        if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    }
                }
                if (OnExecuting != null) OnExecuting("Đang hoàn tất việc cập nhật dữ liệu vào chương trình...", EventArgs.Empty);

                DataSet ds = new DataSet();

                tblDotBiTich.TableName = DotBiTichConst.TableName;
                ds.Tables.Add(tblDotBiTich);

                tblBiTichChiTiet.TableName = BiTichChiTietConst.TableName;
                ds.Tables.Add(tblBiTichChiTiet);

                Memory.UpdateDataSet(ds);

                if (!Memory.HasError())
                {
                    return true;
                }
                else
                {
                    sw.WriteLine("ImportCacDotBitich: " + Memory.Instance.Error.Message);
                    if (OnError != null) OnError("Cập nhật dữ liệu bí tích xuống database của chương trình bị thất bại. Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t" + Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }

            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportCacDotBitich: " + ex.Message);
                if (OnError != null) OnError("Có lỗi chung xảy ra khi nhập dữ liệu  bí tích. Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t", new CancelEventArgs());
                return false;
            }
        }

        private void assignDotBiTich(int maDotBiTich, DataRow newRow, DataRow oldRow)
        {
            foreach (DataColumn col in tblDotBiTich.Columns)
            {
                if (oldRow.Table.Columns.Contains(col.ColumnName))
                {
                    object value = oldRow[col.ColumnName];
                    if (col.ColumnName != DotBiTichConst.UpdateDate && value is DateTime) value = Memory.GetDateString(value);
                    newRow[col.ColumnName] = value;
                }
            }

            newRow[DotBiTichConst.MaDotBiTich] = maDotBiTich;
        }

        private int ImportDotBiTich(DataRow row)
        {
            try
            {
                DataRow rowTmp = FindDotBiTich(row);
                if (rowTmp != null)
                {
                    return (int)rowTmp[DotBiTichConst.MaDotBiTich];
                }
                int maDotBiTich = Memory.Instance.GetNextId(DotBiTichConst.TableName, DotBiTichConst.MaDotBiTich, false);
                DataRow row1 = tblDotBiTich.NewRow();
                assignDotBiTich(maDotBiTich, row1, row);
                tblDotBiTich.Rows.Add(row1);
                return maDotBiTich;

            }
            catch (Exception ex)
            {
                sw.WriteLine("ImportDotBiTich: " + row["MoTa"].ToString() + " - " + ex.Message);
                Memory.Instance.Error = ex;
                if (OnError != null) OnError("Có lỗi khi nhập dữ liệu đợt bí tích" + row["MoTa"].ToString(), new CancelEventArgs());
            }
            return -1;
        }

        private DataRow FindDotBiTich(DataRow row)
        {
            string s = "";
            string ngayBTQuery = row[DotBiTichConst.NgayBiTich] == DBNull.Value ? " NgayBiTich IS NULL " : string.Format(" NgayBiTich = '{0}'", Memory.GetDateString(row["NgayBiTich"]));
            s = string.Format("MoTa = '{0}' AND {1} AND LoaiBiTich={2} AND LinhMuc='{3}'",
                                            row[DotBiTichConst.MoTa].ToString().Replace("'", "''"),
                                            ngayBTQuery,
                                            row[DotBiTichConst.LoaiBiTich],
                                            row[DotBiTichConst.LinhMuc].ToString().Replace("'", "''"));
            DataRow[] rows = tblDotBiTich.Select(s);
            if (rows != null && rows.Length > 0)
            {
                return rows[0];
            }
            return null;
        }

        private bool ImportBiTichChiTiet(int maDotBiTichCu, int maDotBiTichMoi)
        {
            try
            {
                DataRow[] rows = tblBiTichChiTietCu.Select("MaDotBiTich=" + maDotBiTichCu.ToString());
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        //check existance

                        DataRow newRow = tblBiTichChiTiet.NewRow();

                        int maGiaoDan = FindMaGiaoDan((int)row[GiaoDanConst.MaGiaoDan]);
                        if (maGiaoDan == -1)
                        {
                            //maGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
                            continue;//fix error from version 2.0.0.4
                        }
                        DataRow[] thanhviens = tblBiTichChiTiet.Select(string.Format("MaDotBiTich={0} AND MaGiaoDan={1}", maDotBiTichMoi, maGiaoDan));
                        if (thanhviens != null && thanhviens.Length > 0) continue;
                        foreach (DataColumn col in tblBiTichChiTietCu.Columns)
                        {
                            newRow[col.ColumnName] = row[col.ColumnName];
                        }
                        newRow[BiTichChiTietConst.MaDotBiTich] = maDotBiTichMoi;
                        newRow[BiTichChiTietConst.MaGiaoDan] = maGiaoDan;

                        tblBiTichChiTiet.Rows.Add(newRow);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportThanhVienGiaDinh: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region For Chuyển xứ
        private bool ImportChuyenXu()
        {
            try
            {
                if (OnExecuting != null) OnExecuting("Đang lấy dữ liệu chuyển xứ...", EventArgs.Empty);
                DataTable tbChuyenXu = Memory.GetData("SELECT * FROM ChuyenXu");
                tbChuyenXu.Columns.Add(MaGiaoDanCu, typeof(int));

                DataTable tblChuyenXuCu = provider.GetData("SELECT * FROM ChuyenXu");

                if (tblChuyenXuCu == null)
                {
                    Memory.Instance.Error = new Exception("Lỗi khi lấy dữ liệu chuyển xứ");
                    sw.WriteLine(Memory.Instance.Error.Message);
                    if (OnError != null) OnError(Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }
                for (int i = 0; i < tblChuyenXuCu.Rows.Count; i++)
                {
                    //check user abort
                    bool userStop = (bool)Memory.Instance.GetMemory("UserAbort");
                    //if user abort progress, return
                    if (userStop) return false;

                    currentProgress++;
                    Memory.Instance.SetMemory("DuLieuHienTai", currentProgress);

                    DataRow row = tblChuyenXuCu.Rows[i];
                    int maGiaodanMoi = FindMaGiaoDan((int)row[ChuyenXuConst.MaGiaoDan]);
                    if (maGiaodanMoi > -1)
                    {
                        if (OnExecuting != null) OnExecuting("Đang nhập chuyển xứ cho giáo dân", EventArgs.Empty);
                        //check giao dan ton tai hay chua?
                        string strCheck = string.Format("MaGiaoDan='{0}' AND LoaiChuyen='{1}' ",
                                                    maGiaodanMoi, row[ChuyenXuConst.LoaiChuyen]);
                        if (row[ChuyenXuConst.NgayChuyen] == DBNull.Value) strCheck += " AND NgayChuyen IS NULL";
                        else strCheck += string.Format(" AND NgayChuyen='{0}'", Memory.GetDateString(row[ChuyenXuConst.NgayChuyen]));

                        DataRow[] rows = tbChuyenXu.Select(strCheck);
                        if (rows != null && rows.Length > 0)
                        {
                            //rows[0][MaGiaoDanCu] = row[ChuyenXuConst.MaGiaoDan];
                            //rows[0][ChuyenXuConst.MaGiaoHo] = getMaGiaoHo(row[ChuyenXuConst.MaGiaoHo]);
                            continue;
                        }

                        DataRow newRow = tbChuyenXu.NewRow();

                        foreach (DataColumn col in tblChuyenXuCu.Columns)
                        {
                            object value = row[col];
                            //if (col.ColumnName != ChuyenXuConst.UpdateDate && value is DateTime) value = Memory.GetDateString(value);
                            newRow[col.ColumnName] = value;
                        }
                        newRow["MaChuyenXu"] = Memory.Instance.GetNextId(ChuyenXuConst.TableName, ChuyenXuConst.MaChuyenXu, false);

                        if (maGiaodanMoi > 0)
                        {
                            newRow["MaGiaoDan"] = maGiaodanMoi;
                            tbChuyenXu.Rows.Add(newRow);
                        }
                    }
                }
                if (OnExecuting != null) OnExecuting("Đang cập nhật dữ liệu chuyển xứ vào chương trình...", EventArgs.Empty);
                DataSet ds = new DataSet();
                tbChuyenXu.TableName = ChuyenXuConst.TableName;
                ds.Tables.Add(tbChuyenXu);

                Memory.UpdateDataSet(ds);
                if (!Memory.HasError())
                {
                    return true;
                }
                else
                {
                    sw.WriteLine("ImportChuyenXu: " + Memory.Instance.Error.Message);
                    if (OnError != null) OnError("Cập nhật dữ liệu chuyển xứ xuống database của chương trình bị thất bại. Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t" + Memory.Instance.Error.Message, new CancelEventArgs());
                    return false;
                }

            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                sw.WriteLine("ImportChuyenXu: " + ex.Message);
                if (OnError != null) OnError("Có lỗi chung xảy ra khi nhập dữ liệu chuyển xứ.Xin vui lòng liên hệ tác giả để được hỗ trợ\r\n\t" + ex.Message, new CancelEventArgs());
                return false;
            }
        }
        #endregion

        #region For Check valid
        private bool IsValidDb()
        {
            //check table giaoxu
            DataTable tbl = provider.GetData("SELECT * FROM GiaoDan");
            string[] strChecks = new string[] { GiaoDanConst.MaGiaoDan, GiaoDanConst.HoTen, GiaoDanConst.TenThanh, GiaoDanConst.NgaySinh,
                                                GiaoDanConst.NgayRuaToi, GiaoDanConst.NgayRuocLe, GiaoDanConst.NgayThemSuc, GiaoDanConst.NgheNghiep, GiaoDanConst.NguoiDoDauRuaToi,
                                                GiaoDanConst.NguoiDoDauThemSuc, GiaoDanConst.NoiRuaToi, GiaoDanConst.NoiRuocLe,
                                                GiaoDanConst.NoiSinh, GiaoDanConst.NoiThemSuc, GiaoDanConst.Phai,GiaoDanConst.QuaDoi,
                                                GiaoDanConst.SoRuaToi, GiaoDanConst.SoThemSuc, GiaoDanConst.TrinhDoVanHoa, GiaoDanConst.SoRuocLe};
            if (tbl != null)
            {
                for (int i = 0; i < strChecks.Length; i++)
                {
                    if (!tbl.Columns.Contains(strChecks[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            tbl = provider.GetData("SELECT * FROM GiaDinh");
            strChecks = new string[] { GiaDinhConst.MaGiaDinh, GiaDinhConst.MaGiaoHo, GiaDinhConst.TenGiaDinh, GiaDinhConst.DaChuyenXu };
            if (tbl != null)
            {
                for (int i = 0; i < strChecks.Length; i++)
                {
                    if (!tbl.Columns.Contains(strChecks[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            tbl = provider.GetData("SELECT * FROM HonPhoi");
            strChecks = new string[] { HonPhoiConst.MaHonPhoi, HonPhoiConst.NgayHonPhoi, HonPhoiConst.TenHonPhoi, HonPhoiConst.SoHonPhoi, 
                                        HonPhoiConst.NoiHonPhoi, HonPhoiConst.NguoiChung1, HonPhoiConst.NguoiChung2,
                                        HonPhoiConst.LinhMucChung};
            if (tbl != null)
            {
                for (int i = 0; i < strChecks.Length; i++)
                {
                    if (!tbl.Columns.Contains(strChecks[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            //check table tenho
            return true;
        }
        #endregion
    }
}
