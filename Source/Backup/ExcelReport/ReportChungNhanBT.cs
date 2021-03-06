using System;
using System.Collections.Generic;
using System.Text;
using GxGlobal;
using System.Data;

namespace ExcelReport
{
    public class ReportChungNhanBT
    {
        public static int Export(DataSet ds)
        {
            ExcelEngine excel = null;
            WordEngine word = null;
            try
            {
                if (!ds.Tables.Contains(GiaoDanConst.TableName) || !ds.Tables.Contains(GiaoXuConst.TableName))
                {
                    Memory.Instance.Error = new Exception("Không có dữ liệu làm việc!");
                    return -1;
                }

                DataTable tblGiaoDan = ds.Tables[GiaoDanConst.TableName];
                DataTable tblGiaoXu = ds.Tables[GiaoXuConst.TableName];
                //DataTable tblGiaDinh = ds.Tables[GiaDinhConst.TableName];
                //DataTable tblGiaoXuNhan = null;
                //if (ds.Tables.Contains(ReportGiaoDanConst.TableName))
                //{
                //    tblGiaoXuNhan = ds.Tables[ReportGiaoDanConst.TableName];
                //}
                if (tblGiaoDan.Rows.Count == 0 || tblGiaoXu.Rows.Count == 0) return -1;
                LoaiBiTich loaiBiTich = Memory.Instance.GetMemory(GxConstants.CURRENT_REPORT) == null ? LoaiBiTich.TatCa : (LoaiBiTich)Memory.Instance.GetMemory(GxConstants.CURRENT_REPORT);
                string fileName = "";
                switch (loaiBiTich)
                {
                    case LoaiBiTich.RuaToi:
                        fileName = GxConstants.REPORT_RUATOI_FILENAME;
                        break;
                    case LoaiBiTich.RuocLe:
                        fileName = GxConstants.REPORT_XTRL_FILENAME;
                        break;
                    case LoaiBiTich.ThemSuc:
                        fileName = GxConstants.REPORT_THEMSUC_FILENAME;
                        break;
                    default:
                        fileName = GxConstants.REPORT_BITICH_FILENAME;
                        break;
                }

                string templatePath = Memory.GetReportTemplatePath(fileName);
                string outputPath = Memory.GetTempPath(fileName);
                
                DataRow rowGiaoXu = tblGiaoXu.Rows[0];
                DataRow rowGiaoDan = tblGiaoDan.Rows[0];
                //DataRow rowGiaoXuNhan = null;
                //if (tblGiaoXuNhan != null && tblGiaoXuNhan.Rows.Count > 0)
                //{
                //    rowGiaoXuNhan = tblGiaoXuNhan.Rows[0];
                //}

                string reportFormat = Memory.GetReportFormat();
                templatePath = string.Concat(templatePath, reportFormat);
                outputPath = string.Concat(outputPath, reportFormat);

                if (reportFormat == GxConstants.DOC_FORMAT)
                {
                    word = new WordEngine();
                    if (word.CreateObject(outputPath, templatePath))
                    {
                        try
                        {
                            word.Replace(GiaoPhanConst.TenGiaoPhan, rowGiaoXu[GiaoPhanConst.TenGiaoPhan]);
                            word.Replace(GiaoHatConst.TenGiaoHat, rowGiaoXu[GiaoHatConst.TenGiaoHat]);
                            word.Replace(GiaoXuConst.TenGiaoXu, rowGiaoXu[GiaoXuConst.TenGiaoXu]);
                            word.Replace(ReportGiaoDanConst.TenLinhMucGui, rowGiaoXu[ReportGiaoDanConst.TenLinhMucGui]);
                            word.Replace(GiaoDanConst.HoTen, rowGiaoDan[GiaoDanConst.TenThanh].ToString() + " " + rowGiaoDan[GiaoDanConst.HoTen].ToString());
                            word.Replace(GiaoDanConst.NgaySinh, rowGiaoDan[GiaoDanConst.NgaySinh]);
                            word.Replace(GiaoDanConst.NoiSinh, rowGiaoDan[GiaoDanConst.NoiSinh]);

                            word.Replace(ReportGiaoDanConst.TenCha, rowGiaoDan[GiaoDanConst.HoTenCha]);
                            word.Replace(ReportGiaoDanConst.TenMe, rowGiaoDan[GiaoDanConst.HoTenMe]);

                            word.Replace(GiaoDanConst.NgayRuaToi, rowGiaoDan[GiaoDanConst.NgayRuaToi]);
                            word.Replace(GiaoDanConst.NoiRuaToi, rowGiaoDan[GiaoDanConst.NoiRuaToi]);
                            word.Replace(GiaoDanConst.ChaRuaToi, rowGiaoDan[GiaoDanConst.ChaRuaToi]);
                            word.Replace(GiaoDanConst.NguoiDoDauRuaToi, rowGiaoDan[GiaoDanConst.NguoiDoDauRuaToi]);
                            word.Replace(GiaoDanConst.SoRuaToi, rowGiaoDan[GiaoDanConst.SoRuaToi]);
                            word.Replace(GiaoDanConst.NgayThemSuc, rowGiaoDan[GiaoDanConst.NgayThemSuc]);
                            word.Replace(GiaoDanConst.NoiThemSuc, rowGiaoDan[GiaoDanConst.NoiThemSuc]);
                            word.Replace(GiaoDanConst.ChaThemSuc, rowGiaoDan[GiaoDanConst.ChaThemSuc]);
                            word.Replace(GiaoDanConst.NguoiDoDauThemSuc, rowGiaoDan[GiaoDanConst.NguoiDoDauThemSuc]);
                            word.Replace(GiaoDanConst.SoThemSuc, rowGiaoDan[GiaoDanConst.SoThemSuc]);
                            word.Replace(GiaoDanConst.SoRuocLe, rowGiaoDan[GiaoDanConst.SoRuocLe]);
                            word.Replace(GiaoDanConst.NgayRuocLe, rowGiaoDan[GiaoDanConst.NgayRuocLe]);
                            word.Replace(GiaoDanConst.NoiRuocLe, rowGiaoDan[GiaoDanConst.NoiRuocLe]);
                            word.Replace(GiaoDanConst.ChaRuocLe, rowGiaoDan[GiaoDanConst.ChaRuocLe]);

                            //if (rowGiaoXuNhan != null)
                            //{
                            //    word.Replace(ReportGiaoDanConst.LyDo, rowGiaoXuNhan[ReportGiaoDanConst.LyDo]);
                            //    word.Replace(ReportGiaoDanConst.TenLinhMucNhan, rowGiaoXuNhan[ReportGiaoDanConst.TenLinhMucNhan]);
                            //    word.Replace(ReportGiaoDanConst.GiaoXuNhan, rowGiaoXuNhan[ReportGiaoDanConst.GiaoXuNhan]);
                            //}

                            if (Memory.GetConfig(GxConstants.CF_LANGUAGE).ToString() == GxConstants.LANG_VN)
                            {
                                word.Replace(ReportGiaoDanConst.NgayThangNam, Memory.GetReportNgayThangNamVn());
                            }
                            else
                            {
                                word.Replace(ReportGiaoDanConst.NgayThangNam, Memory.GetReportNgayThangNamEn());
                            }
                            word.End_Write();

                            System.Diagnostics.Process.Start(outputPath);
                        }
                        catch (Exception ex)
                        {
                            Memory.Instance.Error = ex;
                        }
                    }
                    else
                    {
                        Memory.Instance.Error = new Exception("Xuất giới thiệu thất bại." + Environment.NewLine +
                                                                "Có thể bạn chưa cài MS Office 2003 trở lên" + Environment.NewLine +
                                                                "Có thể do tập tin \"BiTich.doc\" trong thư mục Template của chương trình đang được mở" + Environment.NewLine +
                                                                "Xin vui lòng đóng tập tin này và thử lại lần nữa");
                        return -1;
                    }
                }
                else
                {
                    excel = new ExcelEngine();
                    if (excel.CreateObject(outputPath, templatePath))
                    {
                        try
                        {
                            excel.Write_to_excel(GiaoPhanConst.TenGiaoPhan, rowGiaoXu[GiaoPhanConst.TenGiaoPhan]);
                            excel.Write_to_excel(GiaoHatConst.TenGiaoHat, rowGiaoXu[GiaoHatConst.TenGiaoHat]);
                            excel.Write_to_excel(GiaoXuConst.TenGiaoXu, rowGiaoXu[GiaoXuConst.TenGiaoXu]);
                            excel.Write_to_excel(ReportGiaoDanConst.TenLinhMucGui, rowGiaoXu[ReportGiaoDanConst.TenLinhMucGui]);
                            excel.Write_to_excel(GiaoDanConst.HoTen, rowGiaoDan[GiaoDanConst.TenThanh].ToString() + " " + rowGiaoDan[GiaoDanConst.HoTen].ToString());
                            excel.Write_to_excel(GiaoDanConst.NgaySinh, rowGiaoDan[GiaoDanConst.NgaySinh]);
                            excel.Write_to_excel(GiaoDanConst.NoiSinh, rowGiaoDan[GiaoDanConst.NoiSinh]);

                            excel.Write_to_excel(ReportGiaoDanConst.TenCha, rowGiaoDan[GiaoDanConst.HoTenCha]);
                            excel.Write_to_excel(ReportGiaoDanConst.TenMe, rowGiaoDan[GiaoDanConst.HoTenMe]);

                            excel.Write_to_excel(GiaoDanConst.NgayRuaToi, rowGiaoDan[GiaoDanConst.NgayRuaToi]);
                            excel.Write_to_excel(GiaoDanConst.NoiRuaToi, rowGiaoDan[GiaoDanConst.NoiRuaToi]);
                            excel.Write_to_excel(GiaoDanConst.ChaRuaToi, rowGiaoDan[GiaoDanConst.ChaRuaToi]);
                            excel.Write_to_excel(GiaoDanConst.NguoiDoDauRuaToi, rowGiaoDan[GiaoDanConst.NguoiDoDauRuaToi]);
                            excel.Write_to_excel(GiaoDanConst.SoRuaToi, rowGiaoDan[GiaoDanConst.SoRuaToi]);
                            excel.Write_to_excel(GiaoDanConst.NgayThemSuc, rowGiaoDan[GiaoDanConst.NgayThemSuc]);
                            excel.Write_to_excel(GiaoDanConst.NoiThemSuc, rowGiaoDan[GiaoDanConst.NoiThemSuc]);
                            excel.Write_to_excel(GiaoDanConst.ChaThemSuc, rowGiaoDan[GiaoDanConst.ChaThemSuc]);
                            excel.Write_to_excel(GiaoDanConst.NguoiDoDauThemSuc, rowGiaoDan[GiaoDanConst.NguoiDoDauThemSuc]);
                            excel.Write_to_excel(GiaoDanConst.SoThemSuc, rowGiaoDan[GiaoDanConst.SoThemSuc]);
                            excel.Write_to_excel(GiaoDanConst.SoRuocLe, rowGiaoDan[GiaoDanConst.SoRuocLe]);
                            excel.Write_to_excel(GiaoDanConst.NgayRuocLe, rowGiaoDan[GiaoDanConst.NgayRuocLe]);
                            excel.Write_to_excel(GiaoDanConst.NoiRuocLe, rowGiaoDan[GiaoDanConst.NoiRuocLe]);
                            excel.Write_to_excel(GiaoDanConst.ChaRuocLe, rowGiaoDan[GiaoDanConst.ChaRuocLe]);

                            //if (rowGiaoXuNhan != null)
                            //{
                            //    excel.Write_to_excel(ReportGiaoDanConst.LyDo, rowGiaoXuNhan[ReportGiaoDanConst.LyDo]);
                            //    excel.Write_to_excel(ReportGiaoDanConst.TenLinhMucNhan, rowGiaoXuNhan[ReportGiaoDanConst.TenLinhMucNhan]);
                            //    excel.Write_to_excel(ReportGiaoDanConst.GiaoXuNhan, rowGiaoXuNhan[ReportGiaoDanConst.GiaoXuNhan]);
                            //}

                            if (Memory.GetConfig(GxConstants.CF_LANGUAGE).ToString() == GxConstants.LANG_VN)
                            {
                                excel.Write_to_excel(ReportGiaoDanConst.NgayThangNam, Memory.GetReportNgayThangNamVn());
                            }
                            else
                            {
                                excel.Write_to_excel(ReportGiaoDanConst.NgayThangNam, Memory.GetReportNgayThangNamEn());
                            }
                            excel.End_Write();

                            System.Diagnostics.Process.Start(outputPath);
                        }
                        catch (Exception ex)
                        {
                            Memory.Instance.Error = ex;
                        }
                    }
                    else
                    {
                        Memory.Instance.Error = new Exception("Xuất giới thiệu thất bại." + Environment.NewLine +
                                                                "Có thể bạn chưa cài MS Office 2003 trở lên" + Environment.NewLine +
                                                                "Có thể do tập tin \"BiTich.xls\" trong thư mục Template của chương trình đang được mở" + Environment.NewLine +
                                                                "Xin vui lòng đóng tập tin này và thử lại lần nữa");
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                return -1;
            }
            finally
            {
                if (excel != null) excel.End_Write();
                if (word != null) word.End_Write();
            }
            return 0;
        }
    }
}
