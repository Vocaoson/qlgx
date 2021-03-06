using System;
using System.Collections.Generic;
using System.Text;
using GxGlobal;
using System.Data;

namespace ExcelReport
{
    public class ReportSoGiaDinh
    {
        private static int beginDetailRow = -1;
        
        public static int Export(DataSet ds)
        {
            try
            {
                if (!ds.Tables.Contains(GiaoDanConst.TableName) || !ds.Tables.Contains(GiaoXuConst.TableName) || !ds.Tables.Contains(GiaDinhConst.TableName))
                {
                    Memory.Instance.Error = new Exception("Không có dữ liệu làm việc!");
                    return -1;
                }

                DataTable tblGiaoDan = ds.Tables[GiaoDanConst.TableName];
                DataTable tblGiaoXu = ds.Tables[GiaoXuConst.TableName];
                DataTable tblGiaDinh = ds.Tables[GiaDinhConst.TableName];
                if (tblGiaoDan.Rows.Count == 0 || tblGiaoXu.Rows.Count == 0) return -1;
                string templatePath = Memory.GetReportTemplatePath(GxConstants.REPORT_SOGIADINH_FILENAME);
                string outputPath = Memory.GetTempPath(GxConstants.REPORT_SOGIADINH_FILENAME);

                ExcelEngine excel = new ExcelEngine();
                DataRow rowGiaoXu = tblGiaoXu.Rows[0];
                DataRow rowGiaDinh = tblGiaDinh.Rows[0];

                if (excel.CreateObject(outputPath, templatePath))
                {
                    try
                    {
                        bool isMaGDRieng = (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIADINH) == "1");
                        excel.LoaiBaoCao = ReportType.SoGiaDinh;
                        excel.Write_to_excel(GiaoXuConst.TenGiaoXu, rowGiaoXu[GiaoXuConst.TenGiaoXu].ToString().ToUpper());
                        excel.Write_to_excel(GiaDinhConst.MaGiaDinh, isMaGDRieng ? rowGiaDinh[GiaDinhConst.MaGiaDinhRieng] : rowGiaDinh[GiaDinhConst.MaGiaDinh]);
                        excel.Write_to_excel(GiaDinhConst.TenGiaDinh, rowGiaDinh[GiaDinhConst.TenGiaDinh]);
                        excel.Write_to_excel(GiaoHoConst.TenGiaoHo, rowGiaDinh[GiaoHoConst.TenGiaoHo]);
                        Dictionary<string, int> dicPos = getPositionsDic(excel, tblGiaoDan);
                        int maxColIndex = 0;
                        foreach (KeyValuePair<string, int> item in dicPos)
                        {
                            if (item.Value > maxColIndex) maxColIndex = item.Value;
                        }
                        string lasDetailColName = excel.MapColIndexToColName(maxColIndex);

                        int minColIndex = 20;
                        foreach (KeyValuePair<string, int> item in dicPos)
                        {
                            if (item.Value < minColIndex) minColIndex = item.Value;
                        }
                        string beginDetailColName = excel.MapColIndexToColName(minColIndex);

                        int i = beginDetailRow;
                        bool inNoiSinh = Memory.GetConfig(GxConstants.CF_SOGIADINH_INNOISINH) == GxConstants.CF_TRUE;
                        string lang = Memory.GetConfig(GxConstants.CF_LANGUAGE);
                        bool isUSFormatName = Memory.GetConfig(GxConstants.CF_US_FORMAT_NAME) == GxConstants.CF_TRUE;
                        foreach (DataRow row in tblGiaoDan.Rows)
                        {
                            //xem xet giao dan hien tai co cho phep in khong?
                            if ((bool)row[GiaoDanConst.QuaDoi] || row[GiaoDanConst.DaChuyenXu].ToString() != GxConstants.CF_FALSE)
                            {
                                if (Memory.GetConfig(GxConstants.CF_SOGIADINH_IN_LUUTRU) == GxConstants.CF_TRUE)
                                {
                                    if (Memory.GetConfig(GxConstants.CF_SOGIADINH_IN_GACHNGANG) == GxConstants.CF_TRUE)
                                    {
                                        System.Drawing.FontStyle fontStyle = System.Drawing.FontStyle.Italic;
                                        System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 9, fontStyle);
                                        if ((bool)row[GiaoDanConst.QuaDoi])
                                        {
                                            fontStyle = System.Drawing.FontStyle.Strikeout;
                                            font = new System.Drawing.Font("Times New Roman", 10, fontStyle);
                                        }
                                        excel.SetFont("A" + i.ToString(), "Z" + i.ToString(), font);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if ((int)row[ThanhVienGiaDinhConst.VaiTro] > 1 && (bool)row[GiaoDanConst.DaCoGiaDinh])
                            {
                                if (Memory.GetConfig(GxConstants.CF_SOGIADINH_IN_LAPGD) == GxConstants.CF_TRUE)
                                {
                                    System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 9, System.Drawing.FontStyle.Italic);

                                    excel.SetFont("A" + i.ToString(), "Z" + i.ToString(), font);
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            #region For nhung thuoc tinh dac biet, co nhieu truong hop
                            if (dicPos.ContainsKey(GiaoDanConst.MaGiaoDan))
                            {
                                if (Memory.GetConfig(GxConstants.CF_SOGIADINH_THAYSTT_MAGIAODAN) == GxConstants.CF_TRUE)
                                {
                                    row[GiaoDanConst.MaGiaoDan] = row[GiaoDanConst.MaGiaoDan];
                                }
                                else
                                {
                                    row[GiaoDanConst.MaGiaoDan] = (i - beginDetailRow + 1);
                                }
                            }

                            if (dicPos.ContainsKey(HonPhoiConst.NgayHonPhoi))
                            {
                                //for hon phoi
                                if (!Memory.IsNullOrEmpty(row[HonPhoiConst.NgayHonPhoi]))
                                {
                                }
                                else
                                {
                                    if ((bool)row[GiaoDanConst.DaCoGiaDinh])
                                    {
                                        //honPhoi = "X";
                                        row[HonPhoiConst.NgayHonPhoi] = "X";
                                    }
                                }
                            }

                            if (dicPos.ContainsKey(GiaoDanConst.NgayQuaDoi))
                            {
                                //for qua doi
                                if (!Memory.IsNullOrEmpty(row[GiaoDanConst.NgayQuaDoi]))
                                {
                                }
                                else
                                {
                                    if ((bool)row[GiaoDanConst.QuaDoi])
                                    {
                                        row[GiaoDanConst.NgayQuaDoi] = "X";
                                    }
                                }
                            }
                            if (dicPos.ContainsKey(GiaoDanConst.HoTen))
                            {
                                if (lang == GxConstants.LANG_EN && isUSFormatName)
                                {
                                    row[GiaoDanConst.HoTen] = Memory.GetHoTenByLangKhongTenThanh(row[GiaoDanConst.HoTen].ToString(), lang);
                                }
                            }

                            if (inNoiSinh)
                            {
                                row[GiaoDanConst.NgaySinh] = getNgayVaNoi(row[GiaoDanConst.NgaySinh], row[GiaoDanConst.NoiSinh]);
                                row[GiaoDanConst.NgayRuaToi] = getNgayVaNoi(row[GiaoDanConst.NgayRuaToi], row[GiaoDanConst.NoiRuaToi]);
                                row[GiaoDanConst.NgayRuocLe] = getNgayVaNoi(row[GiaoDanConst.NgayRuocLe], row[GiaoDanConst.NoiRuocLe]);
                                row[GiaoDanConst.NgayThemSuc] = getNgayVaNoi(row[GiaoDanConst.NgayThemSuc], row[GiaoDanConst.NoiThemSuc]);
                                row[HonPhoiConst.NgayHonPhoi] = getNgayVaNoi(row[HonPhoiConst.NgayHonPhoi], row[HonPhoiConst.NoiHonPhoi]);
                            }
                            #endregion
                            foreach (KeyValuePair<string, int> item in dicPos)
                            {
                                string key = item.Key.ToLower();
                                if (key.StartsWith("ngay"))
                                {
                                    if (inNoiSinh &&
                                            (key == GiaoDanConst.NgaySinh.ToLower() || key == GiaoDanConst.NgayRuaToi.ToLower() || key == GiaoDanConst.NgayRuocLe.ToLower()
                                            || key == GiaoDanConst.NgayThemSuc.ToLower() || key == HonPhoiConst.NgayHonPhoi.ToLower()))
                                    {
                                        excel.Write_to_excel(i, item.Value, row[item.Key]);
                                    }
                                    else
                                    {
                                        row[item.Key] = Memory.GetDateStringByLang(row[item.Key]);
                                        excel.Write_to_excel(i, item.Value, "'" + row[item.Key].ToString());
                                    }
                                    
                                }
                                else
                                {
                                    if (Validator.IsNumber(row[item.Key].ToString()))
                                    {
                                        excel.Write_to_excel(i, item.Value, "'" + row[item.Key].ToString());
                                    }
                                    else
                                    {
                                        excel.Write_to_excel(i, item.Value, row[item.Key]);
                                    }
                                }
                            }
                            if (inNoiSinh && (!Memory.IsNullOrEmpty(row[GiaoDanConst.NoiSinh]) 
                                                || !Memory.IsNullOrEmpty(row[GiaoDanConst.NoiRuaToi]) || !Memory.IsNullOrEmpty(row[GiaoDanConst.NoiRuocLe])
                                                || !Memory.IsNullOrEmpty(row[GiaoDanConst.NoiThemSuc]) || !Memory.IsNullOrEmpty(row[HonPhoiConst.NoiHonPhoi])))
                            {
                                excel.AutoFitRow(i, i);
                            }
                            i++;
                        }
                        
                        //luon dong khung 10 thanh vien
                        //neu chua du thi them cho du dong
                        //bat dau tinh toan
                        int dis = i - beginDetailRow;
                        dis = 10 - dis;
                        i = i + dis;
                        //ket thuc tinh toan
                        excel.Border_Range(beginDetailColName + beginDetailRow.ToString(), lasDetailColName + (i - 1).ToString());

                        excel.Write_to_excel(GiaDinhConst.DienThoai, "'" + rowGiaDinh[GiaDinhConst.DienThoai].ToString());

                        excel.Write_to_excel(GiaDinhConst.DiaChi, rowGiaDinh[GiaDinhConst.DiaChi]);

                        //i++;
                        if (rowGiaDinh[GiaDinhConst.GhiChu].ToString().Trim() != "")
                        {
                            if (Memory.GetConfig(GxConstants.CF_LANGUAGE) == GxConstants.LANG_EN)
                            {
                                excel.Write_to_excel(i, minColIndex, "Note: " + rowGiaDinh[GiaDinhConst.GhiChu].ToString());
                            }
                            else
                            {
                                excel.Write_to_excel(i, minColIndex, "Ghi chú: " + rowGiaDinh[GiaDinhConst.GhiChu].ToString());
                            }
                        }
                        else
                        {
                            if (Memory.GetConfig(GxConstants.CF_LANGUAGE) == GxConstants.LANG_EN)
                            {
                                excel.Write_to_excel(i, minColIndex, "Note: ");
                            }
                            else
                            {
                                excel.Write_to_excel(i, minColIndex, "Ghi chú: ");
                            }
                        }
                        excel.SetWrapText(beginDetailColName + i.ToString(), lasDetailColName + i.ToString(), false);
                        excel.SetAlignment(beginDetailColName + i.ToString(), lasDetailColName + i.ToString(), XlHAlign.xlHAlignLeft);

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
                                                            "Có thể do tập tin \"SoGiaDinh.xls\" trong thư mục Template của chương trình đang được mở" + Environment.NewLine +
                                                            "Xin vui lòng đóng tập tin này và thử lại lần nữa");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Memory.Instance.Error = ex;
                return -1;
            }
            beginDetailRow = -1;
            return 0;
        }

        private static Dictionary<string, int> getPositionsDic(ExcelEngine excel, DataTable tbl)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            if (excel != null && tbl != null)
            {
                foreach (DataColumn col in tbl.Columns)
                {
                    if (col.ColumnName == GiaoDanConst.DienThoai || col.ColumnName == GiaDinhConst.MaGiaDinh || col.ColumnName == GiaoDanConst.DiaChi) continue;
                    int idx = excel.FindColIndex(string.Format("[{0}]", col.ColumnName));
                    if (idx > -1)
                    {
                        if (beginDetailRow == -1)
                        {
                            beginDetailRow = excel.FindRowIndex(string.Format("[{0}]", col.ColumnName));
                        }
                        dic.Add(col.ColumnName, idx);
                    }
                }
            }
            return dic;
        }

        private static string getNgayVaNoi(object ngay, object noi)
        {
            if (Memory.IsNullOrEmpty(ngay))
            {
                return noi.ToString();
            }

            ngay = Memory.GetDateStringByLang(ngay);
            if (Memory.IsNullOrEmpty(noi))
            {
                return ngay.ToString();
            }
            return string.Format("{0}\n{1}", ngay, noi);
        }
    }
}
