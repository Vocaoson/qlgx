using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Diagnostics;
using ConvertDB.vnConvert;
using System.Xml;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace GxGlobal
{
    public class Memory
    {
        private static Memory instance = null;

        private Dictionary<object, object> memory = null;
        private Dictionary<string, int> maxIDs = new Dictionary<string, int>();
        private static DataTable tblCauHinh = null;

        private const string SPLASH = "\\";

        private static ConvertFont convertFont = new ConvertDB.vnConvert.ConvertFont();

        private static string computerID = "";

        public static string ComputerID
        {
            get { return Memory.computerID; }
            set { Memory.computerID = value; }
        }

        private static int currentGiaoHo = -1;

        public static int CurrentGiaoHo
        {
            get { return Memory.currentGiaoHo; }
            set 
            { 
                Memory.currentGiaoHo = value;
                SetConfig(GxConstants.CF_CURRENT_GIAOHO, value);
            }
        }

        private Exception err = null;

        public Exception Error
        {
            get { return err; }
            set { err = value; }
        }

        private DataProvider provider = null;

        public DataProvider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        private static string serverUrl = "http://qlgx.net/";

        public static string ServerUrl
        {
            get { return Memory.serverUrl; }
            set { Memory.serverUrl = value; }
        }

        private static string currentVersion = "";

        public static string CurrentVersion
        {
            get { return Memory.currentVersion; }
            set { Memory.currentVersion = value; }
        }

        public bool GetVersionInfo()
        {
            try
            {
                ClearError();
                XmlDocument docVersion = new XmlDocument();
                docVersion.Load(AppPath + GxConstants.VERSION_CONFIG_FILE);

                // Create an XmlNamespaceManager to resolve the default namespace.
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(docVersion.NameTable);
                nsmgr.AddNamespace("vs", "urn:newversion-schema");

                XmlElement root = docVersion.DocumentElement;
                XmlNodeList nodeList = root.SelectNodes("/vs:application/vs:version-info", nsmgr);
                if (nodeList != null && nodeList.Count > 0)
                {
                    CurrentVersion = nodeList[0].Attributes["value"].Value;
                }

                nodeList = docVersion.DocumentElement.SelectNodes("/vs:application/vs:version-info/vs:downloadpath", nsmgr);
                if (nodeList != null && nodeList.Count > 0)
                {
                    ServerUrl = nodeList[0].InnerText;
                }
                return true;
            }
            catch (Exception ex)
            {
                Instance.Error = ex;
                return false;
            }
        }

        public static DataTable GetData(string commandText, params object[] parameters)
        {
            return Instance.provider.GetData(commandText, parameters);
        }

        public static DataTable GetData(string commandText)
        {
            return Instance.provider.GetData(commandText);
        }

        public static object ExecuteSqlCommand(string commandText)
        {
            return Instance.provider.Execute(commandText);
        }

        public static object ExecuteSqlCommand(string commandText, params object[] parameters)
        {
            return Instance.provider.Execute(commandText, parameters);
        }

        public static object UpdateDataSet(DataSet ds)
        {
            return Instance.provider.Execute(ds);
        }

        private static DataRow giaoXuInfo = null;

        public static DataRow GiaoXuInfo
        {
            get { return giaoXuInfo; }
            set { giaoXuInfo = value; }
        }

        /// <summary>
        /// Gets Executable files path include splash '\' char in end of path string
        /// </summary>
        public static string AppPath
        {
            get
            {
                string p = System.Windows.Forms.Application.ExecutablePath;
                return System.IO.Path.GetDirectoryName(p) + SPLASH;
            }
        }

        private static string dbVersion = "";

        public static string DbVersion
        {
            get { return dbVersion; }
            set { dbVersion = value; }
        }

        private static string dbName = GxConstants.DB_FILENAME;

        public static string DbName
        {
            get { return Memory.dbName; }
            set { Memory.dbName = value; }
        }

        private static string dbUser = GxConstants.DB_USER;

        public static string DbUser
        {
            get { return Memory.dbUser; }
            set { Memory.dbUser = value; }
        }

        private static string dbPassword = GxConstants.DB_PASSWORD;

        public static string DbPassword
        {
            get { return Memory.dbPassword; }
            set { Memory.dbPassword = value; }
        }

        /// <summary>
        /// Gets instance of FMSMemory
        /// </summary>
        public static Memory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Memory();
                    instance.Provider = new DataProvider(AppPath + dbName, dbUser, dbPassword);
                    if (tblCauHinh == null)
                    {
                        LoadConfig();
                    }
                    computerID = ComputerInfo.GetUniqueID();
                }
                return instance;
            }
        }

        public bool ChangeDatabase(string dbPath, string user, string password)
        {
            try
            {
                Provider = new DataProvider(dbPath, user, password);
                return true;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return false;
            }
        }

        public static void LoadConfig()
        {
            try
            {
                tblCauHinh = GetTable(CauHinhConst.TableName, "");
                string i = GetConfig(GxConstants.CF_CURRENT_GIAOHO);
                if (i != "")
                {
                    currentGiaoHo = int.Parse(i);
                }
            }
            catch { }
            ClearError();
        }

        public static string GetConfig(string key)
        {
            try
            {
                if (tblCauHinh != null && tblCauHinh.Rows.Count > 0)
                {
                    DataRow[] rows = tblCauHinh.Select("MaCauHinh='" + key + "'");
                    if (rows.Length > 0)
                    {
                        return rows[0][CauHinhConst.GiaTri].ToString();
                    }
                }
            }
            catch
            {
            }
            return "";
        }

        public static void SetConfig(string key, object value, string description)
        {
            try
            {
                if (tblCauHinh != null)
                {
                    DataRow[] rows = tblCauHinh.Select("MaCauHinh='" + key + "'");
                    if (rows.Length > 0)
                    {
                        rows[0][CauHinhConst.GiaTri] = value;
                        return;
                    }
                    DataRow newRow = tblCauHinh.NewRow();
                    newRow[CauHinhConst.MaCauHinh] = key;
                    newRow[CauHinhConst.GiaTri] = value;
                    newRow[CauHinhConst.MoTa] = description;
                    tblCauHinh.Rows.Add(newRow);
                }
            }
            catch
            {
            }
        }

        public static void SetConfig(string key, object value)
        {
            try
            {
                if (tblCauHinh != null)
                {
                    DataRow[] rows = tblCauHinh.Select("MaCauHinh='" + key + "'");
                    if (rows.Length > 0)
                    {
                        rows[0][CauHinhConst.GiaTri] = value;
                        return;
                    }
                    DataRow newRow = tblCauHinh.NewRow();
                    newRow[CauHinhConst.MaCauHinh] = key;
                    newRow[CauHinhConst.GiaTri] = value;
                    tblCauHinh.Rows.Add(newRow);
                }
            }
            catch
            {
            }
        }

        public static bool SaveConfig()
        {
            try
            {
                if (tblCauHinh != null)
                {
                    DataSet ds = new DataSet();
                    tblCauHinh.TableName = CauHinhConst.TableName;
                    ds.Tables.Add(tblCauHinh);
                    UpdateDataSet(ds);
                    ds.Tables.Remove(tblCauHinh);
                    if (!Memory.ShowError())
                    {
                        return true;
                    }
                }

            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// Gets environment variable
        /// </summary>
        /// <param name="key">Key of variable which need gotten</param>
        /// <returns></returns>
        public object GetMemory(object key)
        {
            try
            {
                key = key.ToString().ToLower();
                return memory[key];
            }
            catch
            {
                return null;
            }            
        }

        /// <summary>
        /// Clear all error
        /// </summary>
        public static void ClearError()
        {
            Instance.Error = null;
        }

        /// <summary>
        /// Indicating whether system has errors
        /// </summary>
        /// <returns></returns>
        public static bool HasError()
        {
            return Instance.Error != null;
        }

        /// <summary>
        /// Sets environment variable
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void SetMemory(object key, object value)
        {
            if (memory == null)
            {
                memory = new Dictionary<object, object>();
            }
            if (key == null) return;
            key = key.ToString().ToLower();
            if (memory.ContainsKey(key))
            {
                memory[key] = value;
                return;
            }
            memory.Add(key, value);
        }

        public void ClearMemory()
        {
            memory.Clear();
            maxIDs.Clear();
        }

        public void Dispose()
        {
            provider = null;
        }

        /// <summary>
        /// Show error infor
        /// </summary>
        /// <returns>true if has error, false for else</returns>
        public static bool ShowError()
        {
            if (HasError())
            {
                if (!IsDesignMode) System.Windows.Forms.MessageBox.Show(Instance.Error.Message, "Thông báo lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                ClearError();
                return true;
            }
            return false;
        }

        public int GetNextId(string tableName, string colName, bool fromDBOnly)
        {
            try
            {
                if (!fromDBOnly && maxIDs.ContainsKey(tableName))
                {
                    maxIDs[tableName]++;
                    return maxIDs[tableName];
                }

                DataTable tbl = GetData(string.Format("SELECT Max({0}) As MaxId FROM {1}", colName, tableName));
                if (tbl != null)
                {
                    int max = 0;
                    if (tbl.Rows.Count > 0 && tbl.Rows[0][0] != DBNull.Value)
                    {
                        max = (int)tbl.Rows[0][0];                        
                    }
                    max++;
                    if (!maxIDs.ContainsKey(tableName))
                    {
                        maxIDs.Add(tableName, max);
                    }
                    else
                    {
                        maxIDs[tableName] = max;
                    }
                    return max;
                }
            }
            catch
            {
                return 1;
            }
            return 1;
        }

        public DateTime GetServerDateTime()
        {
            try
            {
                DataTable tbl = GetData("SELECT Now() As n");
                if (tbl != null)
                {
                    if (tbl.Rows.Count > 0 && tbl.Rows[0][0] != DBNull.Value)
                    {
                        return (DateTime)tbl.Rows[0][0];
                    }
                }
            }
            catch { }
            return DateTime.Now;
        }

        public static bool IsDesignMode
        {
            get
            {
                if (System.Windows.Forms.Application.ExecutablePath.Contains(@"Common7\IDE\devenv.exe"))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool IsExistedData(string commandText, object[] args)
        {
            DataTable tbl = Memory.GetData(commandText, args);
            if (Memory.ShowError())
            {
                return false;
            }
            if (tbl == null || tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static string GetReportTemplatePath(string excelTemplateFileName)
        {
            return AppPath + GxConstants.TemplateFolder + "\\" + GetConfig(GxConstants.CF_LANGUAGE) + "\\" + excelTemplateFileName;
        }

        public static string GetTempPath(string fileName)
        {
            string temp = Path.GetTempPath();
            temp += GxConstants.TempFolder;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            temp += "\\" + DateTime.Now.Ticks.ToString() + fileName;
            try
            {
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }
            }
            catch { }
            return temp;
        }

        public static string ConvertVNI2UNI(string s)
        {
            convertFont.Convert(ref s, FontIndex.iVNI, FontIndex.iUNI);
            convertFont.CharCase = FontCase.Normal;
            return s.Replace("Aù", "Á").Replace("ø", "").Replace("Uù", "Ú").Replace("©", "");
        }

        public static string ConvertVNI2UNIUpperFirstChar(string s)
        {
            convertFont.CharCase = FontCase.UpperCaseFirstChar;
            return ConvertVNI2UNI(s);
        }

        public static Dictionary<string, string> GetAssemblyInfo()
        {
            Dictionary<string, string> dicInfo = new Dictionary<string, string>();
            DirectoryInfo root = new DirectoryInfo(Memory.AppPath);
            foreach (FileInfo file in root.GetFiles())
            {
                if (file.Extension.ToLower().EndsWith("dll") || file.Extension.ToLower().EndsWith("exe"))
                {
                    if (!dicInfo.ContainsKey(file.Name + file.Extension))
                    {
                        dicInfo.Add(file.Name.ToLower(), System.Diagnostics.FileVersionInfo.GetVersionInfo(file.FullName).FileVersion);
                    }
                }
            }
            return dicInfo;
        }

        public static string GetExeFileVersion()
        {
            Dictionary<string, string> dicInfo = Memory.GetAssemblyInfo();
            if (dicInfo.ContainsKey("giaoxu.exe"))
            {
                return dicInfo["giaoxu.exe"];
            }
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string[] keys = asm.FullName.Split(',');
            if (keys.Length > 1 && keys[1].Contains("="))
            {
                return keys[1].Split('=')[1];
            }
            return "1.0.0.0";
        }

        private static System.Globalization.CultureInfo enCultureInfo = new System.Globalization.CultureInfo("en-US");

        public static System.Globalization.CultureInfo EnCultureInfo
        {
            get { return Memory.enCultureInfo; }
            set { Memory.enCultureInfo = value; }
        }

        public static int GetYear(string year)
        {
            try
            {
                DateTime d = DateTime.Parse("01/01/" + year);
                return d.Year;
            }
            catch
            {
                return DateTime.Now.Year;
            }
        }

        private static string[] dateSeperators = new string[] { "/", "-", "." };
        public static DateTime GetDateFromString(string sDate)
        {
            return GetDateFromString(sDate, true);
        }
        /// <summary>
        /// Get DateTime object from string.
        /// </summary>
        /// <param name="sDate">
        /// The date string has "dd/MM/yyyy" || "MM/yyyy" || "yyyy" formats
        /// If string is not contain month, month equal 1, if string is not contain day, day is equal 1
        /// </param>
        /// <param name="maxMonthIfNull">
        /// if true, month is 12 if month is empty
        /// if false, month is 1 if month is empty
        /// </param>
        /// <returns>Return DateTime object based on input string. If the input string is null or empty, return Now</returns>
        public static DateTime GetDateFromString(string sDate, bool maxMonthIfNull)
        {
            if (string.IsNullOrEmpty(sDate)) return DateTime.Now;
            string year = "1", month = "12", day = "-1";
            if (!maxMonthIfNull)
            {
                month = "1";
                day = "0";
            }
            bool hasSeperator = false;
            foreach (string seperator in dateSeperators)
            {
                if (sDate.Contains(seperator))
                {
                    string[] arr = sDate.Split(new string[] { seperator }, StringSplitOptions.None);
                    year = arr[arr.Length - 1];
                    if (arr.Length > 1) month = arr[arr.Length - 2];
                    if (arr.Length > 2) day = arr[arr.Length - 3];
                    hasSeperator = true;
                    break;
                }
            }

            if (!hasSeperator && sDate.Length <= 4) year = sDate;
            if (day == "0" || day == "-1")
            {
                day = DaysInMonth(int.Parse(year), int.Parse(month)).ToString();
            }
            
            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }

        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static string GetDateString(object date)
        {
            if (date == null || date == DBNull.Value) return "";
            if (date is string) return date.ToString();

            if (date is DateTime)
            {
                return ((DateTime)date).ToString("dd/MM/yyyy");
            }
            
            return "";
        }

        public static string GetDateString(string day, string month, string year)
        {
            string date = "";
            if (day.Trim() != "") date += int.Parse(day).ToString("00") + "/";

            if (month.Trim() != "") date += int.Parse(month).ToString("00") + "/";

            return date + Memory.GetYear(year).ToString("0000");
        }

        public static DateDTO GetDatePart(string sDate)
        {
            string[] ss = sDate.Split('/');
            string day = "";
            string month = "";
            string year = "";
            if (ss.Length == 3)
            {
                year = ss[2];
                month = ss[1];
                day = ss[0];
            }
            else if (ss.Length == 2)
            {
                year = ss[1];
                month = ss[0];                
            }
            else if (ss.Length == 1)
            {
                year = ss[0];
            }
            DateDTO dateDTO = new DateDTO();
            dateDTO.Day = day;
            dateDTO.Month = month;
            dateDTO.Year = year;
            return dateDTO;
        }

        public static string GetIntOfDateFrom(string sDate)
        {
            DateDTO date = GetDatePart(sDate);
            return GetIntOfDateFrom(date.Day, date.Month, date.Year);
        }

        public static string GetIntOfDateFrom(string day, string month, string year)
        {
            //get day
            if (day != "")
            {
                day = int.Parse(day).ToString("00");
            }
            else
            {
                day = "00";
            }

            //get month
            if (month != "")
            {
                month = int.Parse(month).ToString("00");
            }
            else
            {
                month = "00";
            }

            //get year
            if (year != "")
            {
                year = int.Parse(year).ToString("0000");
            }
            else
            {
                year = "0000";
            }

            return string.Concat(year, month, day);
        }

        public static string GetIntOfDateTo(string sDate)
        {
            DateDTO date = GetDatePart(sDate);
            return GetIntOfDateTo(date.Day, date.Month, date.Year);
        }

        public static string GetIntOfDateTo(string day, string month, string year)
        {
            //get day
            if (day != "")
            {
                day = int.Parse(day).ToString("00");
            }
            else
            {
                day = "31";
            }

            //get month
            if (month != "")
            {
                month = int.Parse(month).ToString("00");
            }
            else
            {
                month = "12";
            }

            //get year
            if (year != "")
            {
                year = int.Parse(year).ToString("0000");
            }
            else
            {
                year = "9999";
            }

            return string.Concat(year, month, day);
        }

        public static string AutoUpperFirstChar(string word)
        {
            string chuanHoa = Memory.GetConfig(GxConstants.CF_CHUANHOA_TRONGNGOAC);
            if (chuanHoa == "") chuanHoa = "3";
            FontCase fontCase = (FontCase)int.Parse(chuanHoa);

            bool autoConvertSignPos = !(Memory.GetConfig(GxConstants.CF_CHUANHOA_TUDOIDAU) == GxConstants.CF_FALSE);
            bool autoConvertCharCode = !(Memory.GetConfig(GxConstants.CF_CHUANHOA_TUCHUYENMA) == GxConstants.CF_FALSE);

            return AutoUpperFirstChar(word, fontCase, autoConvertSignPos, autoConvertCharCode);
        }

        public static string AutoUpperFirstChar(string word, FontCase fontCaseInQuote, bool autoConvertSignPosition, bool autoConvertCharCode)
        {
            //string[] splits = word.Split("~`!@#$%^&*()-+=|\\{[]}:;'\"<,>.?/\t\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] splits = word.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string specialChars = "(){[]}<>";
            if (splits != null && splits.Length > 0)
            {
                for (int i = 0; i < splits.Length; i++)
                {
                    if (splits[i].Length > 1)
                    {
                        string firsChar = splits[i].Substring(0, 1);
                        if (specialChars.Contains(firsChar))
                        {
                            if (fontCaseInQuote == FontCase.Normal) //Neu gap ky tu dac biet thi bo qua khong lam gi het
                            {
                                continue;
                            }
                            else if (fontCaseInQuote == FontCase.UpperCaseFirstChar)
                            {
                                //chuan hoa nhung tru cac ky tu dac biet. Vi du: nguyen van an (mr)=> Nguyen Van An (Mr) chu khong phai Nguyen Van An (mr)
                                for (int k = 0; k < splits[i].Length; k++)
                                {
                                    //tim ky tu dau tien khong phai la ky tu dac biet
                                    if (specialChars.Contains(splits[i].Substring(k, 1)))
                                    {
                                        continue;
                                    }
                                    //neu tim thay
                                    if (k == 0) //chuoi khong bat dau bang ky tu dac biet
                                    {
                                        splits[i] = string.Concat(splits[i].Substring(0, 1).ToUpper(),
                                                                splits[i].Substring(1).ToLower());
                                    }
                                    else if (k == splits[i].Length - 1) //chuoi ky tu cuoi cung moi la ky tu binh thuong
                                    {
                                        splits[i] = string.Concat(splits[i].Substring(0, splits[i].Length - 1), splits[i][k].ToString().ToUpper());
                                    }
                                    else //ngoai cac truong hop tren
                                    {
                                        splits[i] = string.Concat(splits[i].Substring(0, k), splits[i][k].ToString().ToUpper(), splits[i].Substring(k + 1).ToLower());
                                    }
                                    break;
                                }
                            }
                            else if (fontCaseInQuote == FontCase.UpperCase)
                            {
                                splits[i] = splits[i].ToUpper();
                            }
                            else if (fontCaseInQuote == FontCase.LowerCase)
                            {
                                splits[i] = splits[i].ToLower();
                            }
                        }
                        else
                        {
                            splits[i] = string.Concat(splits[i].Substring(0, 1).ToUpper(), splits[i].Substring(1).ToLower());
                        }
                    }
                    else if (splits[i].Length == 1)
                    {
                        splits[i] = splits[i].ToUpper();
                    }
                }
            }
            word = string.Join(" ", splits);
            if (autoConvertCharCode)
            {
                convertFont.Convert(ref word, FontIndex.iUTH, FontIndex.iUNI);
            }
            if (autoConvertSignPosition)
            {
                word = Memory.ChuanHoaDau(word);
            }
            
            return word;
        }

        public static string ChuanHoaDau(string s)
        {
            return convertFont.ConvertVietnameseSign(s);
        }

        public static DataTable GetTable(string tableName, string condition)
        {
            if (condition == null) condition = "";
            DataTable tbl = Memory.GetData(string.Format("SELECT * FROM {0} WHERE 1 {1}", tableName, condition));
            if (tbl != null)
            {
                tbl.TableName = tableName;
            }
            return tbl;
        }

        public static DataTable GetTableStruct(string tableName)
        {
            return GetTable(tableName, " AND 1=2");
        }

        public static bool IsNullOrEmpty(object o)
        {
            try
            {
                if (o == null) return true;
                if (o is string && o.ToString() == "") return true;
                if (o is DBNull) return true;
                return false;
            }
            catch
            {
                return true;
            }

        }

        public static object DeleteRows(string tableName, string columnName, object valueKey)
        {
            return ExecuteSqlCommand(string.Format("DELETE FROM {0} WHERE {1}=?", tableName, columnName), new object[] { valueKey });
        }

        public static object DeleteRows(string tableName, string where, object[] values)
        {
            return ExecuteSqlCommand(string.Format("DELETE FROM {0} WHERE {1} ", tableName, where), values);
        }

        public static string GetNumberIntFormat(string num, string format)
        {
            try
            {
                return int.Parse(num).ToString(format);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Check Giao dan da Qua doi, Chuyen Xu hoac Da co gia dinh hay chua
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool IsRedGiaoDan(DataRow row)
        {
            if (row != null && ((bool)row[GiaoDanConst.QuaDoi] ||
                            row[GiaoDanConst.DaChuyenXu].ToString() == "-1" ||
                            (bool)row[GiaoDanConst.DaCoGiaDinh]))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Input a date string format and return day, month, year
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public static void SplitDatePart(string value, out string day, out string month, out string year)
        {
            day = ""; month = ""; year = "";
            string spllitChar = "/";
            foreach (string seperator in dateSeperators)
            {
                if (value.Contains(seperator))
                {
                    spllitChar = seperator;
                    break;
                }
            }

            string[] items = value.ToString().Split(new string[] { spllitChar }, StringSplitOptions.None);

            if (items.Length > 0)
            {
                year = Memory.GetNumberIntFormat(items[items.Length - 1], "0000");
            }
            else year = DateTime.Now.Year.ToString();

            if (items.Length > 1)
            {
                month = Memory.GetNumberIntFormat(items[items.Length - 2], "00");
            }

            if (items.Length > 2)
            {
                day = Memory.GetNumberIntFormat(items[items.Length - 3], "00");
            }
        }

        public static object GetStandardDateString(object s)
        {
            try
            {
                if (Memory.IsNullOrEmpty(s)) return DBNull.Value;

                string day = "", month = "", year = "";
                Memory.SplitDatePart(s.ToString(), out day, out month, out year);
                return Memory.GetDateString(day, month, year);

            }
            catch
            {
                return s;
            }
        }

        public static string GetDateLongString(string sDate)
        {
            string day = "", month = "", year = "";
            SplitDatePart(sDate, out day, out month, out year);
            if (day != "" || month != "" || year != "")
            {
                return string.Format("{0}{1}{2}",
                                                day != "" ? "ngày " + day : "",
                                                month != "" ? " tháng " + month : "",
                                                year != "" ? " năm " + year : "");
            }
            return "";
        }

        /// <summary>
        /// Method used to check for internet connectivity by piging
        /// varoaus websites and looking for the response.
        /// </summary>
        /// <returns>True if a ping succeeded, False if otherwise.</returns>
        /// <remarks></remarks>
        public static bool IsConnectionAvailable()
        {
            //build a list of sites to ping, you can use your own
            string[] sitesList = { "www.google.com", "www.luudiachiweb.com", "www.yahoo.com", "www.vnexpress.net" };
            //create an instance of the System.Net.NetworkInformation Namespace
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            //Create an instance of the PingReply object from the same Namespace
            System.Net.NetworkInformation.PingReply reply;
            //int variable to hold # of pings not successful
            int notReturned = 0;
            try
            {
                //start a loop that is the lentgh of th string array we
                //created above
                for (int i = 0; i <= sitesList.Length; i++)
                {
                    //use the Send Method of the Ping object to send the
                    //Ping request
                    reply = ping.Send(sitesList[i], 5);
                    //now we check the status, looking for,
                    //of course a Success status
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        return true;
                    }
                }
            }
            //comment this back in if you have your own excerption
            //library you use for you applications (use you own
            //exception names)
            //catch (ConnectivityNotFoundException ex)
            //use this line if you don't have your own custom exception 
            //library
            catch
            {
            }
            return false;
        }

        public static string GetDateStringByLang(object value)
        {
            return GetDateStringByLang(value, GetConfig(GxConstants.CF_LANGUAGE));
        }

        public static string GetDateStringByLang(object value, string lang)
        {
            if (value == null) return "";
            if (value.ToString().Split('/').Length > 1)
            {
                System.Globalization.DateTimeFormatInfo df = new System.Globalization.DateTimeFormatInfo();
                df.ShortDatePattern = "dd/MM/yyyy";
                DateTime d = DateTime.Parse(value.ToString(), df);
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(lang);
                value = d.ToString(ci.DateTimeFormat.ShortDatePattern);
            }
            return value.ToString();
        }

        /// <summary>
        /// Ngay sau chi duoc chua ngay/thang/nam chu khong chua gio
        /// </summary>
        /// <param name="ngayTruoc"></param>
        /// <param name="ngaySau"></param>
        /// <param name="khoangCach"></param>
        /// <returns></returns>
        public static bool KiemTraTuoiKhongHopLe(object ngayTruoc, object ngaySau, int khoangCach)
        {
            DateTime d1;
            DateTime d2;
            if (!Memory.IsNullOrEmpty(ngayTruoc) && !Memory.IsNullOrEmpty(ngaySau))
            {
                d1 = Memory.GetDateFromString(ngayTruoc.ToString(), false);
                d2 = Memory.GetDateFromString(ngaySau.ToString(), true);
                TimeSpan ts = d2.Subtract(d1);
                if (d2.Year - d1.Year < khoangCach)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsHoTenKey(string key)
        {
            key = key.ToLower();
            if ((key.Contains("ten") || key.Contains("linhmuc") || key.StartsWith("cha") || key.StartsWith("nguoi"))
                && !key.Contains("tengiaophan") && !key.Contains("tengiaohat") && !key.Contains("tengiaoxu") && !key.Contains("tengiadinh"))
            {
                return true;
            }
            return false;
        }

        public static string GetHoTenByLang(string s, string lang)
        {
            if (lang == GxConstants.LANG_EN)
            {
                string[] arr = s.Split(' ');
                string t = "";
                if (arr.Length > 2)
                {
                    for (int i = 2; i < arr.Length - 1; i++)
                    {
                        t += arr[i] + " ";
                    }
                    return string.Format("{0} {1} {2}{3}", arr[0], arr[arr.Length - 1], t, arr[1]);
                }
            }
            return s;
        }

        public static string GetHoTenByLangKhongTenThanh(string s, string lang)
        {
            if (lang == GxConstants.LANG_EN)
            {
                string[] arr = s.Split(' ');
                string t = "";
                if (arr.Length > 1)
                {
                    string temp = arr[0];
                    arr[0] = arr[arr.Length - 1];
                    arr[arr.Length - 1] = temp;
                    s = string.Join(" ", arr);
                }
            }
            return s;
        }

        public static string GetStringKhongDau(string s)
        {
            convertFont.Convert(ref s, FontIndex.iUNI, FontIndex.iNOSIGN);
            return s;
        }

        public static bool IsEmail(string s)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
            if (re.IsMatch(s))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        //From version 2.0.0.3 start
        public static string GetGiaoDanKey(object maGiaoDan)
        {
            return string.Format("{0}{1}{2}{3}", computerID, GxConstants.GIAODAN_KEY, maGiaoDan, DateTime.Now.Ticks);
        }

        public static string GetGiaoHoKey(object maGiaoHo)
        {
            return string.Format("{0}{1}{2}{3}", computerID, GxConstants.GIAOHO_KEY, maGiaoHo, DateTime.Now.Ticks);
        }

        public static string GetGiaDinhKey(object maGiaDinh)
        {
            return string.Format("{0}{1}{2}{3}", computerID, GxConstants.GIADINH_KEY, maGiaDinh, DateTime.Now.Ticks);
        }

        public static string GetHonPhoiKey(object maHonPhoi)
        {
            return string.Format("{0}{1}{2}{3}", computerID, GxConstants.HONPHOI_KEY, maHonPhoi, DateTime.Now.Ticks);
        }

        /// <summary>
        /// Compare between two version.
        /// Return:
        /// 0 if equal .
        /// -1 if ver1 greater than ver2. 
        /// 1 if ver2 greater than ver1
        /// </summary>
        public static int CompareVersion(string ver1, string ver2)
        {
            return string.Compare(ver1, ver2);
        }

        //From version 2.0.0.3 end
        public static string GetThuocXu(DataRow row)
        {
            if (row == null) return "";
            if ((int)row[GiaoDanConst.MaGiaoHo] == 0)
            {
                return row[GiaoDanConst.ThuocGiaoXu].ToString();
            }
            if (Memory.GiaoXuInfo != null) return Memory.GiaoXuInfo[GiaoXuConst.TenGiaoXu].ToString();
            return "";
        }

        public static string GetReportNgayThangNamVn()
        {
            return string.Format("ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }

        public static string GetReportNgayThangNamEn()
        {
            return DateTime.Now.ToLongDateString();
        }

        public static string GetName(string s)
        {
            s = s.Trim();
            if (s == "" || !s.Contains(" "))
            {
                return s;
            }
            return s.Substring(s.LastIndexOf(' ') + 1);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AutoUpperCaseFirstCharGiaDinh(DataTable tblGiaDinh)
        {
            foreach (DataRow row in tblGiaDinh.Rows)
            {
                foreach (DataColumn col in tblGiaDinh.Columns)
                {
                    if (col.DataType == typeof(string) && col.ColumnName != GiaDinhConst.GhiChu &&
                        col.ColumnName != GiaDinhConst.MaNhanDang && !col.ColumnName.StartsWith("Ngay")
                        && !col.ColumnName.StartsWith("So"))
                    {
                        row[col] = Memory.AutoUpperFirstChar(row[col].ToString());
                    }
                }
            }
        }

        public static void AutoUpperCaseFirstCharGiaoDan(DataTable tblGiaoDan)
        {
            foreach (DataRow row in tblGiaoDan.Rows)
            {
                foreach (DataColumn col in tblGiaoDan.Columns)
                {
                    if (col.DataType == typeof(string) && col.ColumnName != GiaoDanConst.GhiChu && 
                        col.ColumnName != GiaoDanConst.MaNhanDang && !col.ColumnName.StartsWith("Ngay")
                        && !col.ColumnName.StartsWith("So"))
                    {
                        row[col] = Memory.AutoUpperFirstChar(row[col].ToString());
                    }
                }
            }
        }


        /// <summary>
        /// Kiểm tra 1 người nào đó đã từng lập đôi hôn phối chưa
        /// </summary>
        /// <param name="maGiaoDan">Mã giáo dân cần kiểm tra</param>
        /// <returns>
        /// 1: hợp lệ
        /// 0: không hợp lệ
        /// </returns>
        public static int KiemTraVoChong(int maGiaoDan, bool showMessage)
        {
            return KiemTraVoChong(maGiaoDan, showMessage);
        }

        /// <summary>
        /// Kiểm tra 1 người nào đó đã từng lập đôi hôn phối chưa
        /// </summary>
        /// <param name="maGiaoDan">Mã giáo dân cần kiểm tra</param>
        /// <returns>
        /// 1: hợp lệ
        /// 0: không hợp lệ
        /// </returns>
        public static int KiemTraVoChong(int maGiaoDan)
        {
            DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_CHECK_VOCHONG + " AND QuaDoi=0 ORDER BY HP1.SoThuTu DESC ", new object[] { maGiaoDan });
            if (Memory.ShowError() || tblCheck == null)
            {
                return 0;
            }
            if (tblCheck.Rows.Count > 0)
            {
                DataRow row = tblCheck.Rows[0];
                if (!Memory.IsNullOrEmpty(row[GiaoDanConst.HoTen]))
                {
                    string msg = string.Format("Giáo dân này đã từng kết hôn với [{0} {1}], thuộc đôi hôn phối [{2}].\r\n Bạn có chắc tiếp tục chọn giáo dân này không?", row[GiaoDanConst.TenThanh], row[GiaoDanConst.HoTen], row[HonPhoiConst.TenHonPhoi]);
                    if (MessageBox.Show(msg, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        public static bool BackupDatabase(out string path)
        {
            try
            {
                FastZip fzip = new FastZip();
                string fileName = "data" + System.DateTime.Now.ToString("yyyyMMddhhmm") + ".zip";
                path = Memory.AppPath + "backup\\" + fileName;
                fzip.CreateZip(path, Memory.AppPath, false, "giaoxu.mdb");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo sao lưu mới\r\n" +
                   "Error message:\r\n" +
                   ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                path = "";
                return false;
            }
        }

        public static string RestoreDatabase(string path)
        {
            try
            {
                FastZip zip = new FastZip();
                string exPath = Memory.GetTempPath("");
                zip.ExtractZip(path, exPath, "mdb");
                path = exPath + "\\" + GxConstants.DB_FILENAME;
                File.Copy(path, Memory.AppPath + GxConstants.DB_FILENAME, true);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        public static string GetFontName()
        {
            string fontName = GetConfig(GxConstants.CF_FONT_NAME);
            if (string.IsNullOrEmpty(fontName))
            {
                return GxConstants.DEFAULT_FONT_NAME;
            }
            return fontName;
        }

        public static float GetFontSize()
        {
            string fontSize = GetConfig(GxConstants.CF_FONT_SIZE);
            if (!string.IsNullOrEmpty(fontSize) && Validator.IsNumber(fontSize))
            {
                return float.Parse(fontSize);
            }
            return GxConstants.DEFAULT_FONT_SIZE;
        }

        public static string GetReportFormat()
        {
            return ".doc";
        }
    }
}