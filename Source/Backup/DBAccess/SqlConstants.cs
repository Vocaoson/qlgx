using System;
using System.Collections.Generic;
using System.Text;

namespace GxGlobal
{
    public class SqlConstants
    {
//        public const string SELECT_GIAODAN_LIST_CO_GIAOHO = @"SELECT GiaoDan.*,  IIF(ThanhVienGiaDinh.MaGiaoDan1 IS NOT NULL,-1,0) AS DaCoGiaDinh
//                                            FROM (SELECT GiaoDan.*, GiaoHo.TenGiaoHo, IIF(ChuyenXu.MaGiaoDan IS NOT NULL,-1,0) AS DaChuyenXu,
//                                                                                     IIF(GiaoDan.NgaySinh IS NOT NULL,RIGHT(GiaoDan.NgaySinh,4),"""") AS NamSinh
//                                                    FROM (
//                                                            (SELECT DISTINCT ChuyenXu.MaGiaoDan
//                                                            FROM ChuyenXu WHERE LoaiChuyen=2
//                                                            GROUP BY ChuyenXu.MaGiaoDan) AS ChuyenXu 
//                                                        RIGHT JOIN GiaoDan ON ChuyenXu.MaGiaoDan = GiaoDan.MaGiaoDan
//                                                        ) LEFT JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo
//                                            )  AS GiaoDan 
//                                            LEFT JOIN (SELECT DISTINCT MaGiaoDan AS MaGiaoDan1 FROM ThanhVienGiaDinh
//                                                    WHERE VaiTro=0 OR VaiTro=1
//                                                    GROUP BY MaGiaoDan, VaiTro) AS ThanhVienGiaDinh 
//                                            ON GiaoDan.MaGiaoDan = ThanhVienGiaDinh.MaGiaoDan1
//                                            WHERE 1 ";
        public const string SELECT_GIAODAN_LIST_CO_GIAOHO = @"SELECT GiaoDan.*
                                                    FROM (SELECT GiaoDan.*, IIF(GiaoDan.MaGiaoHo = 0, ""Ngoài xứ"", GiaoHo.TenGiaoHo) AS TenGiaoHo, IIF(ChuyenXu.MaGiaoDan IS NOT NULL,-1,0) AS DaChuyenXu,
                                                                                             IIF(GiaoDan.NgaySinh IS NOT NULL,RIGHT(GiaoDan.NgaySinh,4),"""") AS NamSinh
                                                            FROM (
                                                                    (SELECT DISTINCT ChuyenXu.MaGiaoDan
                                                                    FROM ChuyenXu WHERE LoaiChuyen=2
                                                                    GROUP BY ChuyenXu.MaGiaoDan) AS ChuyenXu 
                                                                RIGHT JOIN GiaoDan ON ChuyenXu.MaGiaoDan = GiaoDan.MaGiaoDan
                                                                ) LEFT JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo ORDER BY GiaoDan.MaGiaoDan ASC
                                                    )  AS GiaoDan 
                                                    WHERE 1 ";

        /// <summary>
        /// Luu y phai su dung bang string.Format va dua vao tham so la thong tin table GiaoDan
        /// </summary>
        public const string SELECT_THANHVIEN_GIADINH = @"SELECT ThanhVienGiaDinh.MaGiaDinh, ThanhVienGiaDinh.VaiTro, ThanhVienGiaDinh.ChuHo, GiaoDan.*
                                            FROM ((ThanhVienGiaDinh INNER JOIN GiaDinh ON ThanhVienGiaDinh.MaGiaDinh = GiaDinh.MaGiaDinh) 
                                            INNER JOIN ({0}) AS GiaoDan ON ThanhVienGiaDinh.MaGiaoDan = GiaoDan.MaGiaoDan) LEFT JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo
                                            WHERE GiaoDan.DaXoa=0 ";
        public const string SELECT_GIAODAN_THEO_ID = @"SELECT GiaoDan.*, ChuyenXu.MaChuyenXu, ChuyenXu.NgayChuyen, ChuyenXu.NoiChuyen, ChuyenXu.LoaiChuyen, ChuyenXu.GhiChuChuyen
                                                        FROM GiaoDan LEFT JOIN ChuyenXu ON GiaoDan.MaGiaoDan = ChuyenXu.MaGiaoDan
                                                        WHERE GiaoDan.MaGiaoDan = ? ";
        public const string SELECT_CHECK_GIAODAN_TONTAI = "SELECT GiaoDan.* FROM GiaoDan WHERE HoTen = ? AND TenThanh = ? AND NgaySinh = ? AND GiaoDan.DaXoa = 0 AND GiaoDan.MaGiaoDan <> ?";
        /// <summary>
        /// Yeu cau 2 tham so la MaGiaoHo va MaGiaDinh
        /// </summary>
        //public const string SELECT_GIADINH_THEO_ID = @"SELECT * FROM SELECT_GIADINH_LIST WHERE MaGiaDinh = ?";
        public const string SELECT_GIADINH_THEO_ID = @"SELECT TOP 1 GiaDinh.*, HonPhoi.SoHonPhoi, HonPhoi.NgayHonPhoi, HonPhoi.NoiHonPhoi, HonPhoi.LinhMucChung, HonPhoi.NguoiChung1, HonPhoi.NguoiChung2, HonPhoi.CachThucHonPhoi
                                            FROM (((SELECT_GIADINH_LIST GiaDinh INNER JOIN ThanhVienGiaDinh TVGD ON GiaDinh.MaGiaDinh=TVGD.MaGiaDinh)
                                            LEFT JOIN GiaoDanHonPhoi GDHP ON GDHP.MaGiaoDan=TVGD.MaGiaoDan)
                                            LEFT JOIN HonPhoi ON HonPhoi.MaHonPhoi=GDHP.MaHonPhoi)
                                             WHERE (TVGD.VaiTro=0 OR TVGD.VaiTro=1) AND GiaDinh.MaGiaDinh = ?";

        /// <summary>
        /// Yeu cau tham so MaGiaDinh. Luu y phai su dung bang string.Format va dua vao tham so la thong tin table GiaoDan
        /// </summary>
        public const string SELECT_CHA_ME_THEO_GIADINH = @"SELECT ThanhVienGiaDinh.MaGiaDinh, GiaoDan.*, ThanhVienGiaDinh.VaiTro, ThanhVienGiaDinh.ChuHo
                                                        FROM ThanhVienGiaDinh INNER JOIN ({0}) AS GiaoDan ON ThanhVienGiaDinh.MaGiaoDan = GiaoDan.MaGiaoDan
                                                        WHERE (ThanhVienGiaDinh.VaiTro=0 Or ThanhVienGiaDinh.VaiTro=1) AND MaGiaDinh = ?
                                                         ";
        /// <summary>
        /// Select danh sach gia dinh
        /// </summary>
        public const string SELECT_GIADINH_LIST = @"SELECT * FROM SELECT_GIADINH_LIST WHERE MaGiaDinh<>NULL ";

        public const string SELECT_GIADINH_LIST_CO_HONPHOI = @"SELECT DISTINCT * FROM (SELECT DISTINCT GiaDinh.*, HonPhoi.SoHonPhoi, HonPhoi.NgayHonPhoi, HonPhoi.NoiHonPhoi, HonPhoi.LinhMucChung, HonPhoi.NguoiChung1, HonPhoi.NguoiChung2, HonPhoi.CachThucHonPhoi
                                            FROM (((SELECT_GIADINH_LIST GiaDinh INNER JOIN ThanhVienGiaDinh TVGD ON GiaDinh.MaGiaDinh=TVGD.MaGiaDinh)
                                            LEFT JOIN GiaoDanHonPhoi GDHP ON GDHP.MaGiaoDan=TVGD.MaGiaoDan)
                                            LEFT JOIN HonPhoi ON HonPhoi.MaHonPhoi=GDHP.MaHonPhoi)
                                             WHERE (TVGD.VaiTro=0 OR TVGD.VaiTro=1)) WHERE 1 ";

        /*
        public const string SELECT_GIADINH_LIST = @"TRANSFORM First([TenThanh]+" "+[HoTen]) AS TenDayDu
                                                SELECT GD.MaGiaDinh, GD.TenGiaDinh, GD.MaGiaoHo, GD.SoHonPhoi, GD.NgayHonPhoi, GD.LinhMucChung, GD.NguoiChung1, GD.NguoiChung2, GD.CachThucHonPhoi, GD.GhiChu, GD.DienThoai, GD.DiaChi, GD.DaXoa, GD.UpdateDate, GD.TenGiaoHo
                                                FROM ((SELECT * FROM ThanhVienGiaDinh INNER JOIN VaiTro ON(ThanhVienGiaDinh.VaiTRo = VaiTro.ID))  AS TVGD INNER JOIN (SELECT * FROM GiaoDan)  AS A ON TVGD.MaGiaoDan = A.MaGiaoDan) INNER JOIN (SELECT GiaDinh.*, GiaoHo.TenGiaoHo FROM GiaDinh INNER JOIN GiaoHo ON (GiaDinh.MaGiaoHo = GiaoHo.MaGiaoHo))  AS GD ON TVGD.MaGiaDinh = GD.MaGiaDinh
                                                WHERE TVGD.VaiTro=0 OR TVGD.ThanhVienGiaDinh.VaiTro=1 AND GD.DaXoa=0
                                                GROUP BY GD.MaGiaDinh, GD.TenGiaDinh, GD.MaGiaoHo, GD.SoHonPhoi, GD.NgayHonPhoi, GD.LinhMucChung, GD.NguoiChung1, GD.NguoiChung2, GD.CachThucHonPhoi, GD.GhiChu, GD.DienThoai, GD.DiaChi, GD.DaXoa, GD.UpdateDate, GD.TenGiaoHo
                                                PIVOT TVGD.Value ";
        */
        public const string DELETE_GIADINH_THEO_ID = "UPDATE GiaDinh SET DaXoa=-1, UpdateDate = Now() WHERE MaGiaDinh = ? ";//"DELETE FROM GiaDinh WHERE MaGiaDinh = ? ";

        public const string DELETE_CONCAI_THEO_GIADINH = "DELETE FROM ThanhVienGiaDinh WHERE MaGiaDinh = ? ";
        public const string SELECT_GIAOHO = "SELECT * FROM GiaoHo WHERE DaXoa = 0 ";
        public const string SELECT_COUNT_GIADINH_THUOC_GIAOHO = "SELECT COUNT(MaGiaDinh) AS SoLuong FROM GiaDinh WHERE MaGiaoHo = ? ";
        public const string SELECT_COUNT_GIAODAN_THUOC_GIAOHO = "SELECT COUNT(MaGiaoDan) AS SoLuong FROM GiaoDan WHERE MaGiaoHo = ? ";
        public const string DELETE_GIAOHO_KHONG_CO_GIADINH = "DELETE FROM GiaoHo WHERE MaGiaoHo = ? ";
        public const string DELETE_GIAOHO_CO_GIADINH = "UPDATE GiaoHo SET DaXoa=-1, UpdateDate = Now() WHERE MaGiaoHo = ? ";
        public const string DELETE_GIAODAN = "UPDATE GiaoDan SET DaXoa=-1, UpdateDate = Now() WHERE MaGiaoDan = ? ";

        public const string SELECT_LINHMUC_LIST = "SELECT * FROM LinhMuc WHERE DaXoa = 0 ";
        public const string SELECT_GIAOXU = @"SELECT GiaoPhan.TenGiaoPhan, GiaoHat.TenGiaoHat, GiaoXu.* 
                                                FROM GiaoPhan RIGHT JOIN (GiaoHat RIGHT JOIN GiaoXu ON GiaoHat.MaGiaoHat = GiaoXu.MaGiaoHat) ON GiaoPhan.MaGiaoPhan = GiaoHat.MaGiaoPhan ";
        public const string SELECT_CHECK_LINHMUC = "SELECT MaLinhMuc FROM LinhMuc WHERE DaXoa = 0 AND TenThanh = ? AND HoTen = ? AND NgaySinh = ? AND MaLinhMuc <> ? ";
        public const string DELETE_LINHMUC_THEO_ID = "UPDATE LinhMuc SET DaXoa=-1, UpdateDate = Now() WHERE MaLinhMuc = ? ";//"DELETE FROM GiaDinh WHERE MaGiaDinh = ? ";
//        public const string SELECT_GIAODAN_THEO_HONPHOI = @"SELECT A.*, B.TenGiaoHo
//                                                        FROM (SELECT     GiaDinh.MaGiaDinh, GiaDinh.NguoiChong, GiaDinh.NguoiVo, GiaDinh.NgayHonPhoi, GiaoDan.*
//                                                            FROM         (GiaoDan RIGHT OUTER JOIN
//                                                                              GiaDinh ON GiaoDan.MaGiaoDan = GiaDinh.NguoiChong OR GiaoDan.MaGiaoDan = GiaDinh.NguoiVo)
//                                                                          ) A
//                                                        LEFT JOIN GiaoHo B ON A.MaGiaoHo = B.MaGiaoHo WHERE A.DaXoa = 0 ";

        public const string UPDATE_GIAOHO = "UPDATE GiaoHo SET TenGiaoHo = ?, UpdateDate = Now() WHERE MaGiaoHo = ?";
        public const string SELECT_TENTHANH = "SELECT DISTINCT TenThanh FROM GiaoDan ";

        public const string SELECT_CHA_ME = @"SELECT S_GiaDinh.TenVo AS TenMe, S_GiaDinh.TenChong AS TenCha FROM (SELECT * FROM SELECT_GIADINH_LIST) 
                                    AS S_GiaDinh INNER JOIN ThanhVienGiaDinh ON ThanhVienGiaDinh.MaGiaDinh = S_GiaDinh.MaGiaDinh 
                                    WHERE ThanhVienGiaDinh.MaGiaoDan = ?";
//        /// <summary>
//        /// Phải dùng string.Format nếu có điều kiện WHERE
//        /// </summary>
//        public const string SELECT_GIADINH_GIAODAN = @"SELECT GiaDinh.MaGiaDinh, GiaDinh.TenGiaDinh, GiaDinh.MaGiaoHo, HonPhoi.SoHonPhoi, 
//                                    HonPhoi.NgayHonPhoi, HonPhoi.NoiHonPhoi, HonPhoi.LinhMucChung, HonPhoi.NguoiChung1, HonPhoi.NguoiChung2, HonPhoi.CachThucHonPhoi, 
//                                    GiaDinh.GhiChu, GiaDinh.DienThoai, GiaDinh.DiaChi, GiaDinh.DaXoa, GiaDinh.UpdateDate, GiaDinh.TenGiaoHo, GiaDinh.TenChong, GiaDinh.TenVo, 
//                                    GiaDinh.GiaDinhAo, GiaDinh.MaNhanDang, GiaDinh.MaGiaDinhRieng
//                                    FROM (((SELECT_GIADINH_LIST AS GiaDinh INNER JOIN ThanhVienGiaDinh ON GiaDinh.MaGiaDinh = ThanhVienGiaDinh.MaGiaDinh) 
//                                    INNER JOIN GiaoDan ON ThanhVienGiaDinh.MaGiaoDan = GiaoDan.MaGiaoDan) LEFT JOIN GiaoDanHonPhoi ON GiaoDan.MaGiaoDan = GiaoDanHonPhoi.MaGiaoDan) 
//                                    LEFT JOIN HonPhoi ON GiaoDanHonPhoi.MaHonPhoi = HonPhoi.MaHonPhoi
//                                    {0}
//                                    GROUP BY GiaDinh.MaGiaDinh, GiaDinh.TenGiaDinh, GiaDinh.MaGiaoHo, HonPhoi.SoHonPhoi, HonPhoi.NgayHonPhoi, HonPhoi.NoiHonPhoi, HonPhoi.LinhMucChung, HonPhoi.NguoiChung1, HonPhoi.NguoiChung2, HonPhoi.CachThucHonPhoi, GiaDinh.GhiChu, GiaDinh.DienThoai, GiaDinh.DiaChi, GiaDinh.DaXoa, GiaDinh.UpdateDate, GiaDinh.TenGiaoHo, GiaDinh.TenChong, GiaDinh.TenVo, GiaDinh.GiaDinhAo, GiaDinh.MaNhanDang, GiaDinh.MaGiaDinhRieng";

        /// <summary>
        /// Phải dùng string.Format nếu có điều kiện WHERE
        /// </summary>
        public const string SELECT_GIADINH_GIAODAN = @"SELECT * FROM SELECT_GIADINH_LIST WHERE MaGiaDinh IN 
                                                     (SELECT    DISTINCT    GiaDinh.MaGiaDinh
                                                      FROM      ((SELECT_GIADINH_LIST GiaDinh INNER JOIN
                                                                    ThanhVienGiaDinh ON GiaDinh.MaGiaDinh = ThanhVienGiaDinh.MaGiaDinh) INNER JOIN
                                                                    GiaoDan ON ThanhVienGiaDinh.MaGiaoDan = GiaoDan.MaGiaoDan)
                                                        {0}
                                                        )";

        public const string SELECT_GIAOPHAN = "SELECT * FROM GiaoPhan ";
        public const string SELECT_GIAOHAT = "SELECT * FROM GiaoHat ";

        public const string SELECT_CHUYENXU_THEOID = "SELECT * FROM ChuyenXu WHERE MaGiaoDan = ? ";
        public const string SELECT_CHUYENXU_LIST = "SELECT * FROM ChuyenXu WHERE 1 ";

        public const string SELECT_DOTBITICH_LIST = @"SELECT DotBiTich.*, SL.SoLuong
                                                    FROM DotBiTich
                                                    LEFT JOIN (
                                                            SELECT BiTichChiTiet.MaDotBiTich As MaDot, Count(BiTichChiTiet.MaGiaoDan) AS SoLuong
                                                            FROM BiTichChiTiet
                                                            GROUP BY BiTichChiTiet.MaDotBiTich) AS SL
                                                            ON DotBiTich.MaDotBiTich = SL.MaDot
                                                    WHERE 1 
                                                     ";
        public const string SELECT_BITICH_CHITIET_THEODOT = @"SELECT 1 as Existed, GiaoDan.MaGiaoDan, GiaoDan.HoTen, GiaoDan.MaGiaoHo, GiaoDan.Phai, 
                                                    GiaoDan.TenThanh, GiaoDan.NgaySinh, GiaoDan.NoiSinh, GiaoDan.SoRuaToi, GiaoDan.NgayRuaToi, 
                                                    GiaoDan.NoiRuaToi, GiaoDan.ChaRuaToi, GiaoDan.NguoiDoDauRuaToi, GiaoDan.SoRuocLe, GiaoDan.NgayRuocLe, 
                                                    GiaoDan.NoiRuocLe, GiaoDan.ChaRuocLe, GiaoDan.SoThemSuc, GiaoDan.NgayThemSuc, GiaoDan.NoiThemSuc, 
                                                    GiaoDan.ChaThemSuc, GiaoDan.NguoiDoDauThemSuc, GiaoDan.TrinhDoVanHoa, GiaoDan.NgheNghiep, 
                                                    GiaoDan.ConHoc, GiaoDan.QuaDoi, GiaoDan.NgayQuaDoi, GiaoDan.DienThoai, GiaoDan.Email,  GiaoDan.GhiChu,
                                                    GiaoDan.DaXoa, GiaoDan.UpdateDate, GiaoDan.HoTenCha, GiaoDan.HoTenMe, GiaoDan.DaCoGiaDinh, GiaoDan.GiaoDanAo, GiaoDan.TanTong, GiaoDan.MaNhanDang, GiaoDan.ThuocGiaoXu, GiaoDan.DiaChi,
                                                    BiTichChiTiet.MaDotBiTich, BiTichChiTiet.GhiChu AS GhiChu1, BiTichChiTiet.VaiTro, BiTichChiTiet.TenGiaDinh,
                                                    MaGiaDinh AS MaGiaDinh, MaGiaDinh AS MaGiaDinhCo 
                                                    FROM GiaoDan INNER JOIN
                                                    (SELECT BiTichChiTiet.*,  ThanhVienGiaDinh.MaGiaDinh, ThanhVienGiaDinh.TenGiaDinh, ThanhVienGiaDinh.VaiTro 
                                                    FROM BiTichChiTiet LEFT JOIN 
                                                        (SELECT ThanhVienGiaDinh.*, GiaDinh.TenGiaDinh
                                                        FROM ThanhVienGiaDinh INNER JOIN GiaDinh ON ThanhVienGiaDinh.MaGiaDinh = GiaDinh.MaGiaDinh
                                                        WHERE VaiTro = 2) AS ThanhVienGiaDinh ON (BiTichChiTiet.MaGiaoDan = ThanhVienGiaDinh.MaGiaoDan)
                                                    ) AS BiTichChiTiet 
                                                    ON GiaoDan.MaGiaoDan = BiTichChiTiet.MaGiaoDan
                                                    WHERE GiaoDan.DaXoa=0 AND BiTichChiTiet.MaDotBiTich = ?  ";

        public const string SELECT_THANHVIEN_GIADINH_LIST = "SELECT ThanhVienGiaDinh.*, GiaDinh.TenGiaDinh FROM ThanhVienGiaDinh INNER JOIN GiaDinh ON ThanhVienGiaDinh.MaGiaDinh = GiaDinh.MaGiaDinh WHERE 1 ";
        public const string SELECT_BITICH_CHITIET_THEOLOAI = "SELECT BiTichChiTiet.*, DotBiTich.LoaiBiTich FROM DotBiTich INNER JOIN BiTichChiTiet ON DotBiTich.MaDotBiTich = BiTichChiTiet.MaDotBiTich WHERE 1 ";
        public const string SELECT_CHECK_VOCHONG = @"SELECT HP1.MaHonPhoi, HonPhoi.TenHonPhoi, GiaoDan.*
                                                    FROM ((GiaoDanHonPhoi HP1 
                                                    INNER JOIN GiaoDanHonPhoi HP2 ON (HP1.MaHonPhoi=HP2.MaHonPhoi AND HP1.MaGiaoDan <> HP2.MaGiaoDan))
                                                    INNER JOIN HonPhoi ON HP1.MaHonPhoi = HonPhoi.MaHonPhoi)
                                                    INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = HP2.MaGiaoDan
                                                    WHERE HP1.MaGiaoDan=? ";
        /// <summary>
        /// Select thong tin giao dan cua nguoi vo, nguoi chong dua vao ma gia dinh, vi vay phai input MaGiaDinh
        /// </summary>
        public const string SELECT_VOCHONG_THEO_MAGIADINH = "SELECT GiaoDan.*, ThanhVienGiaDinh.MaGiaDinh, ThanhVienGiaDinh.VaiTro FROM ThanhVienGiaDinh INNER JOIN GiaoDan ON ThanhVienGiaDinh.MaGiaoDan = GiaoDan.MaGiaoDan WHERE ThanhVienGiaDinh.MaGiaDinh=? ";

        public const string SELECT_THANHVIENGIADINH_GIAODAN = "SELECT GiaoDan.*, ThanhVienGiaDinh.MaGiaDinh, ThanhVienGiaDinh.VaiTro FROM ThanhVienGiaDinh INNER JOIN GiaoDan ON ThanhVienGiaDinh.MaGiaoDan = GiaoDan.MaGiaoDan WHERE 1 ";

        public const string SELECT_RAOHONPHOI_LIST = @"SELECT RaoHonPhoi.*, GiaoDan.TenTHanh & ' ' & GiaoDan.HoTen AS Nguoi1, GiaoDan_1.TenThanh & ' ' & GiaoDan_1.HoTen As Nguoi2
                                                            FROM (RaoHonPhoi INNER JOIN GiaoDan ON RaoHonPhoi.MaGiaoDan1 = GiaoDan.MaGiaoDan) 
                                                            INNER JOIN GiaoDan AS GiaoDan_1 ON RaoHonPhoi.MaGiaoDan2 = GiaoDan_1.MaGiaoDan 
                                                            WHERE 1 ";
        public const string DELETE_RAOHONPHOI = "DELETE FROM RaoHonPhoi WHERE MaRaoHonPhoi=? ";
        /// <summary>
        /// Can thong tin nguoi check trong cau WHERE MaGiaoDan1=? OR MaGiaoDan2=?
        /// </summary>
        public const string CHECK_DA_RAOHONPHOI = @"SELECT MaRaoHonPhoi FROM RaoHonPhoi WHERE MaGiaoDan1=? OR MaGiaoDan2=?";
        public const string SELECT_REPORT_RAOHONPHOI_LIST = @"SELECT RaoHonPhoiTMP.STT, RaoHonPhoiTMP.MaRaoHonPhoi, RaoHonPhoiTMP.TenRaoHonPhoi, 
                                                        RaoHonPhoiTMP.LanRao, RaoHonPhoiTMP.ThuocXu, RaoHonPhoiTMP.TruocOXu, GiaoDan.* 
                                                   FROM RaoHonPhoiTMP INNER JOIN GiaoDan ON RaoHonPhoiTMP.MaGiaoDan = GiaoDan.MaGiaoDan";
        public const string SELECT_VOCHONG_THEO_HONPHOI = @"SELECT GiaoDan.* 
                                                FROM GiaoDanHonPhoi 
                                                    INNER JOIN GiaoDan ON GiaoDanHonPhoi.MaGiaoDan=GiaoDan.MaGiaoDan 
                                                WHERE MaHonPhoi=?
                                                ORDER BY GiaoDan.Phai ";

        public const string SELECT_HONPHOI_THEO_ID = @"SELECT * FROM HonPhoi WHERE MaHonPhoi=? ";
        /// <summary>
        /// Select ra danh sach cac hon phoi cua nguoi nao do, nhung thong tin hon phoi se lap lai 2 lan, nen phai dung them dieu kien de loc ra trong tung truong hop cu the
        /// Vi du:
        /// - De loc ra danh sach hon phoi cua cung 1 nguoi ma khong bi trung nhau thi them: AND GiaoDanHonPhoi_1.MaGiaoDan != ? (cung ma giao dan cua 1 nguoi)
        /// - De loc ra thong tin hon phoi cua 2 nguoi thi them: AND GiaoDanHonPhoi_1.MaGiaoDan = ? (ma giao dan cua nguoi con lai)
        /// </summary>
        public const string SELECT_HONPHOI_THEO_MAGIAODAN = @"SELECT HP.*, GiaoDanHonPhoi.SoThuTu, GiaoDanHonPhoi_1.MaGiaoDan, GiaoDan.TenThanh + ' ' + GiaoDan.HoTen AS VoChong
                                                FROM ((HonPhoi AS HP INNER JOIN GiaoDanHonPhoi ON HP.MaHonPhoi = GiaoDanHonPhoi.MaHonPhoi) 
                                                    INNER JOIN GiaoDanHonPhoi AS GiaoDanHonPhoi_1 ON HP.MaHonPhoi = GiaoDanHonPhoi_1.MaHonPhoi) 
                                                    INNER JOIN GiaoDan ON GiaoDanHonPhoi_1.MaGiaoDan = GiaoDan.MaGiaoDan
                                                WHERE GiaoDanHonPhoi.[MaGiaoDan]=? ";
        public const string SELECT_HONPHOI_CHECK_LIST = @"SELECT HP.*, GiaoDanHonPhoi.MaGiaoDan AS MaGiaoDan, GiaoDanHonPhoi_1.MaGiaoDan AS MaGiaoDan1
                                                FROM ((HonPhoi AS HP INNER JOIN GiaoDanHonPhoi ON HP.MaHonPhoi = GiaoDanHonPhoi.MaHonPhoi) 
                                                    INNER JOIN GiaoDanHonPhoi AS GiaoDanHonPhoi_1 ON HP.MaHonPhoi = GiaoDanHonPhoi_1.MaHonPhoi) 
                                                 WHERE GiaoDanHonPhoi.MaGiaoDan<>GiaoDanHonPhoi_1.MaGiaoDan ";

        public const string SELECT_HONPHOI_LIST = "SELECT * FROM SELECT_HONPHOI_LIST WHERE 1 ";

        public const string SELECT_CHECK_GIADINH_THEO_VOCHONG = @"SELECT A.MaGiaDinh, A.MaGiaoDan AS NguoiThu1,B.MaGiaoDan AS NguoiThu2 FROM
                                                ((SELECT * FROM ThanhVienGiaDinh WHERE  (VaiTro=0 OR VaiTro=1)) AS A
                                                INNER JOIN 
                                                (SELECT * FROM ThanhVienGiaDinh WHERE  (VaiTro=0 OR VaiTro=1)) AS B ON A.MaGiaDinh=B.MaGiaDinh
                                                )
                                                WHERE A.MaGiaoDan=? AND B.MaGiaoDan=?";
        public const string SELECT_TANHIEN_HIENTAI = @"SELECT * FROM TanHien WHERE DaHoiTuc=0 AND MaGiaoDan=?";
    }
}
