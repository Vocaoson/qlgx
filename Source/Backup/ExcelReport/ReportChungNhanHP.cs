using System;
using System.Collections.Generic;
using System.Text;
using GxGlobal;
using System.Data;

namespace ExcelReport
{
    public class ReportChungNhanHP
    {
        public static int Export(DataSet ds)
        {
            ExcelEngine excel = null;
            WordEngine word = null;
            try
            {
                if (!ds.Tables.Contains(GiaoXuConst.TableName) || !ds.Tables.Contains(GiaDinhConst.TableName) || !ds.Tables.Contains(ReportChungNhanHPConst.TableName))
                {
                    Memory.Instance.Error = new Exception("Không có dữ liệu làm việc!");
                    return -1;
                }

                DataTable tblGiaDinh = ds.Tables[GiaDinhConst.TableName];
                DataTable tblGiaoXu = ds.Tables[GiaoXuConst.TableName];
                DataTable tblReport = ds.Tables[ReportChungNhanHPConst.TableName];

                if (tblGiaDinh.Rows.Count == 0 || tblGiaoXu.Rows.Count == 0 || tblReport.Rows.Count == 0) return -1;

                DataRow rowGiaoXu = tblGiaoXu.Rows[0];
                DataRow rowGiaDinh = tblGiaDinh.Rows[0];
                DataRow rowReport = tblReport.Rows[0];

                

                string templatePath = Memory.GetReportTemplatePath(GxConstants.REPORT_CHUNGNHAN_HONPHOI_FILENAME);
                string outputPath = Memory.GetTempPath(GxConstants.REPORT_CHUNGNHAN_HONPHOI_FILENAME);
                
                string reportFormat = Memory.GetReportFormat();
                templatePath = string.Concat(templatePath, reportFormat);
                outputPath = string.Concat(outputPath, reportFormat);

                if (reportFormat == GxConstants.DOC_FORMAT)
                {
                    word = new WordEngine();
                    if (word.CreateObject(outputPath, templatePath))
                    {

                        word.Replace(GiaoPhanConst.TenGiaoPhan, rowGiaoXu[GiaoPhanConst.TenGiaoPhan]);
                        word.Replace(GiaoHatConst.TenGiaoHat, rowGiaoXu[GiaoHatConst.TenGiaoHat]);
                        word.Replace(GiaoXuConst.TenGiaoXu, rowGiaoXu[GiaoXuConst.TenGiaoXu]);

                        word.Replace(ReportChungNhanHPConst.HoTenNam, rowReport[ReportChungNhanHPConst.HoTenNam]);
                        word.Replace(ReportChungNhanHPConst.HoTenNu, rowReport[ReportChungNhanHPConst.HoTenNu]);
                        word.Replace(ReportChungNhanHPConst.NgaySinhNam, rowReport[ReportChungNhanHPConst.NgaySinhNam]);
                        word.Replace(ReportChungNhanHPConst.NgaySinhNu, rowReport[ReportChungNhanHPConst.NgaySinhNu]);
                        word.Replace(ReportChungNhanHPConst.NgayThangNamHP, rowReport[ReportChungNhanHPConst.NgayThangNamHP]);
                        word.Replace(ReportChungNhanHPConst.NoiSinhNam, rowReport[ReportChungNhanHPConst.NoiSinhNam]);
                        word.Replace(ReportChungNhanHPConst.NoiSinhNu, rowReport[ReportChungNhanHPConst.NoiSinhNu]);
                        word.Replace(ReportChungNhanHPConst.TenChaNam, rowReport[ReportChungNhanHPConst.TenChaNam]);
                        word.Replace(ReportChungNhanHPConst.TenChaNu, rowReport[ReportChungNhanHPConst.TenChaNu]);
                        word.Replace(ReportChungNhanHPConst.TenLinhMucGui, rowReport[ReportChungNhanHPConst.TenLinhMucGui]);
                        word.Replace(ReportChungNhanHPConst.TenMeNam, rowReport[ReportChungNhanHPConst.TenMeNam]);
                        word.Replace(ReportChungNhanHPConst.TenMeNu, rowReport[ReportChungNhanHPConst.TenMeNu]);
                        word.Replace(ReportChungNhanHPConst.GiaoXuNam, rowReport[ReportChungNhanHPConst.GiaoXuNam]);
                        word.Replace(ReportChungNhanHPConst.GiaoXuNu, rowReport[ReportChungNhanHPConst.GiaoXuNu]);
                        word.Replace(ReportChungNhanHPConst.NgayRuaToiNam, rowReport[ReportChungNhanHPConst.NgayRuaToiNam]);
                        word.Replace(ReportChungNhanHPConst.SoRuaToiNam, rowReport[ReportChungNhanHPConst.SoRuaToiNam]);
                        word.Replace(ReportChungNhanHPConst.NgayRuaToiNu, rowReport[ReportChungNhanHPConst.NgayRuaToiNu]);
                        word.Replace(ReportChungNhanHPConst.SoRuaToiNu, rowReport[ReportChungNhanHPConst.SoRuaToiNu]);

                        word.Replace(HonPhoiConst.SoHonPhoi, rowReport[HonPhoiConst.SoHonPhoi]);
                        word.Replace(HonPhoiConst.LinhMucChung, rowReport[HonPhoiConst.LinhMucChung]);
                        word.Replace(HonPhoiConst.NoiHonPhoi, rowReport[HonPhoiConst.NoiHonPhoi]);
                        word.Replace(HonPhoiConst.NguoiChung1, rowReport[HonPhoiConst.NguoiChung1]);
                        word.Replace(HonPhoiConst.NguoiChung2, rowReport[HonPhoiConst.NguoiChung2]);
                        if (Memory.GetConfig(GxConstants.CF_LANGUAGE) == GxConstants.LANG_VN)
                        {
                            word.Replace(ReportChungNhanHPConst.NgayThangNam, Memory.GetReportNgayThangNamVn());
                        }
                        else
                        {
                            word.Replace(ReportChungNhanHPConst.NgayThangNam, Memory.GetReportNgayThangNamEn());
                        }

                        word.End_Write();
                        System.Diagnostics.Process.Start(outputPath);
                    }
                    else
                    {
                        Memory.Instance.Error = new Exception("Xuất giới thiệu thất bại." + Environment.NewLine +
                                                                "Có thể bạn chưa cài MS Office 2003 trở lên" + Environment.NewLine +
                                                                "Có thể do tập tin \"HonPhoi.doc\" trong thư mục Template của chương trình đang được mở" + Environment.NewLine +
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

                            excel.Write_to_excel(ReportChungNhanHPConst.HoTenNam, rowReport[ReportChungNhanHPConst.HoTenNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.HoTenNu, rowReport[ReportChungNhanHPConst.HoTenNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NgaySinhNam, rowReport[ReportChungNhanHPConst.NgaySinhNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NgaySinhNu, rowReport[ReportChungNhanHPConst.NgaySinhNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NgayThangNamHP, rowReport[ReportChungNhanHPConst.NgayThangNamHP]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NoiSinhNam, rowReport[ReportChungNhanHPConst.NoiSinhNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NoiSinhNu, rowReport[ReportChungNhanHPConst.NoiSinhNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.TenChaNam, rowReport[ReportChungNhanHPConst.TenChaNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.TenChaNu, rowReport[ReportChungNhanHPConst.TenChaNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.TenLinhMucGui, rowReport[ReportChungNhanHPConst.TenLinhMucGui]);
                            excel.Write_to_excel(ReportChungNhanHPConst.TenMeNam, rowReport[ReportChungNhanHPConst.TenMeNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.TenMeNu, rowReport[ReportChungNhanHPConst.TenMeNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.GiaoXuNam, rowReport[ReportChungNhanHPConst.GiaoXuNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.GiaoXuNu, rowReport[ReportChungNhanHPConst.GiaoXuNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NgayRuaToiNam, rowReport[ReportChungNhanHPConst.NgayRuaToiNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.SoRuaToiNam, rowReport[ReportChungNhanHPConst.SoRuaToiNam]);
                            excel.Write_to_excel(ReportChungNhanHPConst.NgayRuaToiNu, rowReport[ReportChungNhanHPConst.NgayRuaToiNu]);
                            excel.Write_to_excel(ReportChungNhanHPConst.SoRuaToiNu, rowReport[ReportChungNhanHPConst.SoRuaToiNu]);

                            excel.Write_to_excel(HonPhoiConst.SoHonPhoi, rowReport[HonPhoiConst.SoHonPhoi]);
                            excel.Write_to_excel(HonPhoiConst.LinhMucChung, rowReport[HonPhoiConst.LinhMucChung]);
                            excel.Write_to_excel(HonPhoiConst.NoiHonPhoi, rowReport[HonPhoiConst.NoiHonPhoi]);
                            excel.Write_to_excel(HonPhoiConst.NguoiChung1, rowReport[HonPhoiConst.NguoiChung1]);
                            excel.Write_to_excel(HonPhoiConst.NguoiChung2, rowReport[HonPhoiConst.NguoiChung2]);
                            if (Memory.GetConfig(GxConstants.CF_LANGUAGE) == GxConstants.LANG_VN)
                            {
                                excel.Write_to_excel(ReportChungNhanHPConst.NgayThangNam, Memory.GetReportNgayThangNamVn());
                            }
                            else
                            {
                                excel.Write_to_excel(ReportChungNhanHPConst.NgayThangNam, Memory.GetReportNgayThangNamEn());
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
                        Memory.Instance.Error = new Exception("Xuất chứng nhận thất bại." + Environment.NewLine +
                                                                "Có thể bạn chưa cài MS Office 2003 trở lên" + Environment.NewLine +
                                                                "Có thể do tập tin \"ChungNhanHonPhoi.xls\" trong thư mục Template của chương trình đang được mở" + Environment.NewLine +
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
