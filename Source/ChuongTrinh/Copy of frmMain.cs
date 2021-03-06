using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.UI.Dock;
using Janus.Windows.ExplorerBar;
using GxControl;
using GxGlobal;
using FarsiLibrary.Win;
using System.Reflection;
using System.Threading;

namespace GiaoXu
{
    public partial class frmMain : Form
    {
        Dictionary<string, FATabStripItem> dicShows = new Dictionary<string, FATabStripItem>();
        FATabStripItem defaulItem = null;
        frmReplace frmReplace = new frmReplace();
        frmTimGiaoDan frmTimGiaoDan = new frmTimGiaoDan();
        frmTimGiaDinh frmTimGiaDinh = new frmTimGiaDinh();

        public frmMain()
        {
            InitializeComponent();
            frmReplace.OnOK += new EventHandler(frmReplace_OnOK);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAOXU);
            try
            {
                if (Memory.ShowError() || tbl == null || tbl.Rows.Count == 0)
                {
                    defaulItem = new FATabStripItem("Quản lý giáo xứ", null);
                    this.pictureBox1.BackgroundImage = Image.FromFile(Memory.AppPath + GxConstants.CHURCH_IMG_NAME);
                    MessageBox.Show("Xin vui lòng nhập thông tin giáo xứ trước khi làm việc với chương trình");
                    ShowForm(new frmGiaoXu());                    
                }
                else if (tbl.Rows.Count > 0)
                {
                    Memory.GiaoXuInfo = tbl.Rows[0];
                    string gxName = string.Format("Giáo xứ {0}", tbl.Rows[0][GiaoXuConst.TenGiaoXu]);
                    this.Text = string.Format("Chương trình quản lý giáo xứ - {0}", gxName);
                    defaulItem = new FATabStripItem(gxName, null);
                    string imgPath = Memory.AppPath + tbl.Rows[0][GiaoXuConst.Hinh].ToString();
                    if (System.IO.File.Exists(imgPath))
                    {
                        this.pictureBox1.BackgroundImage = Image.FromFile(Memory.AppPath + tbl.Rows[0][GiaoXuConst.Hinh].ToString());
                    }
                    else
                    {
                        this.pictureBox1.BackgroundImage = Image.FromFile(Memory.AppPath + GxConstants.CHURCH_IMG_NAME);
                    }
                }
            }
            catch { }
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            defaulItem.Controls.Add(pictureBox1);
            pictureBox1.Dock = DockStyle.Fill;
            FATabStrip.Items.Add(defaulItem);
            
            ThreadStart threadStart = new ThreadStart(ProcessVersion);
            Thread thread = new Thread(threadStart);
            thread.Start();
            //ProcessVersion();
        }

        private void ProcessVersion()
        {
            if (Memory.GetVersionInfo())
            {
                if (Memory.GetConfig(GxConstants.CF_AUTO_UPDATE).ToString() == "1")
                {
                    CheckNewVersion(false);
                }
            }

            if (Memory.CurrentVersion != "" && string.Compare(Memory.DbVersion = getDbVersion(), Memory.CurrentVersion) < 0)
            {
                frmProcess frmUpdate = new frmProcess();
                frmUpdate.LabelStart = "Đang cập nhật chương trình lên phiên bản mới...";
                frmUpdate.LableFinished = "Đã cập nhật xong!";
                frmUpdate.Text = "Đang cập nhật chương trình lên phiên bản mới. Có thể mất vài phút. Xin vui lòng đợi...";
                frmUpdate.ProcessClass = new UpdateProcess();
                frmUpdate.FinishedFunction = new EventHandler(MarkUpdated);
                frmUpdate.ShowDialog();
            }
        }

        private string getDbVersion()
        {
            if (Memory.GetConfig(GxConstants.CF_CURRENT_DB_VERSION).ToString() != "")
            {
                if (Memory.GetConfig(GxConstants.CF_CURRENT_DB_VERSION).ToString() == "2.0.0.0")
                {
                    if (!isDbVersion2())
                    {
                        return "1.0.0.3";
                    }
                }
                return Memory.GetConfig(GxConstants.CF_CURRENT_DB_VERSION).ToString();
            }
            if (System.IO.File.Exists(Memory.AppPath + GxConstants.VERSION_UPDATE_MARK_FILE))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Memory.AppPath + GxConstants.VERSION_UPDATE_MARK_FILE);
                string version = sr.ReadToEnd();
                if (version.Trim() == "1.0.0.3")
                {
                    return "1.0.0.3";
                }
            }
            return "1.0.0.1";
        }

        public void MarkUpdated(object sender, EventArgs e)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Memory.AppPath + GxConstants.VERSION_UPDATE_MARK_FILE, false);
                sw.Write(Memory.CurrentVersion);
                sw.Close();
            }
            catch
            {

            }
        }

        private bool isDbVersion2()
        {
            DataTable tblGiaoDan = Memory.GetTableStruct(GiaoDanConst.TableName);
            string[] columnCheck = new string[] { GiaoDanConst.SoRuocLe, GiaoDanConst.DaCoGiaDinh };
            foreach (string s in columnCheck)
            {
                if (!tblGiaoDan.Columns.Contains(s))
                {
                    return false;
                }
            }
            return true;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            //Delete all temp file
            try
            {
                Memory.SaveConfig();
                string temp = System.IO.Path.GetTempPath() + GxConstants.TempFolder;
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(temp);
                //frmReplace.Dispose();
                foreach(Form frm in Application.OpenForms)
                {
                    frm.Dispose();
                }
                foreach (System.IO.FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
            }
            catch { }
            base.OnClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGiaDinhList frm = new frmGiaDinhList();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGiaoDanList frm = new frmGiaoDanList();
            frm.Show();
        }

        private void buttonBar1_ItemClick(object sender, Janus.Windows.ButtonBar.ItemEventArgs e)
        {
            if (e.Item.Key == "itNhapGiaoHo")
            {
                frmGiaoHo frm = new frmGiaoHo();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itNhapGiaoDan")
            {
                frmGiaoDanList frm = new frmGiaoDanList();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itNhapGiaDinh")
            {
                frmGiaDinhList frm = new frmGiaDinhList();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itNhapGiaoXu")
            {
                frmGiaoXu frm = new frmGiaoXu();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itSoBiTich")
            {
                frmDotBiTichList frm = new frmDotBiTichList();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itThongKeChung")
            {
                frmThongKeChung frm = new frmThongKeChung();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itLuuTruGiaoDan")
            {
                frmGiaoDanLuuTruList frm = new frmGiaoDanLuuTruList();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itLuuTruGiaDinh")
            {
                frmGiaDinhLuuTruList frm = new frmGiaDinhLuuTruList();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itTimGiaoDan")
            {
                frmTimGiaoDan.ShowDialog();
            }
            else if (e.Item.Key == "itTimGiaDinhCuaGiaoDan")
            {                
                frmTimGiaDinh.ShowDialog();
            }
            else if (e.Item.Key == "itTimThayThe")
            {
                frmReplace.ShowDialog();
            }
            else if (e.Item.Key == "itKiemTraGiaoDan")
            {
                frmKiemTraGiaoDanList frm = new frmKiemTraGiaoDanList();
                ShowForm(frm);
            }
            else if (e.Item.Key == "itKiemTraGiaDinh")
            {
                frmKiemTraGiaDinhList frm = new frmKiemTraGiaDinhList();
                ShowForm(frm);
            }
        }

        private void frmReplace_OnOK(object sender, EventArgs e)
        {
            if ((int)sender <= 0) return;
            if (frmReplace.TableName == GiaoDanConst.TableName)
            {
                frmGiaoDanList frm = new frmGiaoDanList();
                frm.GiaoDanList.WhereSQL = frmReplace.WhereSQL;
                frm.GiaoDanList.LoadData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO, null);
                ShowForm(frm);
            }
            else if (frmReplace.TableName == GiaDinhConst.TableName)
            {
                frmGiaDinhList frm = new frmGiaDinhList();

                frm.GiaDinhList.WhereSQL = frmReplace.WhereSQL;
                frm.GiaDinhList.LoadData(SqlConstants.SELECT_GIADINH_LIST, null);
                ShowForm(frm);
            }
        }

        public void ShowForm(frmBase frm)
        {
            FATabStripItem item = null;
            if (dicShows.ContainsKey(frm.Name))
            {
                FATabStrip.SelectedItem = dicShows[frm.Name];
                item = FATabStrip.SelectedItem;
                item.Controls.RemoveAt(0);
                frmBase opennedForm = (frmBase)Application.OpenForms[frm.Name];
                opennedForm.Close();
                //return;
            }
            else
            {
                item = new FATabStripItem(frm.Text, null);
                FATabStrip.AddTab(item);
                dicShows.Add(frm.Name, item);
            }
            FATabStrip.Dock = DockStyle.Fill;
            item.Dock = DockStyle.Fill;
            frm.Dock = DockStyle.Fill;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            
            item.Controls.Add(frm);
            

            frm.Dock = DockStyle.Fill;
            
            FATabStrip.SelectedItem = item;
            item.Selected = true;
            frm.Show();
            
            defaulItem.Visible = false;
            GC.Collect();
        }

        private void FATabStrip_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if (e.Item.Equals(defaulItem))
            {
                e.Cancel = true;
                return;
            }
            if (e.Item.Controls.Count == 0) return;

            frmBase frm = (frmBase)e.Item.Controls[0];
            if (frm != null && dicShows.ContainsKey(frm.Name))
            {
                dicShows.Remove(frm.Name);
            }
            if (dicShows.Count == 0)
                defaulItem.Visible = true;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            frmTimGiaDinh.ShowDialog();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            frm.ShowDialog();
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            frmMergeData frm = new frmMergeData();
            frm.ShowDialog();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            CheckNewVersion(true);
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Memory.AppPath + "HuongDan.Doc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmMain, menuItem10_Click)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            frmOption frm = new frmOption();
            frm.ShowDialog();
        }

        private void tìmVàThaythếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplace.ShowDialog();
        }

        private void tìmGiáoDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimGiaoDan.ShowDialog();
        }

        private static Assembly loadUpdateModule()
        {
            try
            {
                return Assembly.LoadFile(Memory.AppPath + "AutoUpdate.exe");
            }
            catch
            {
                return null;
            }
        }

        private static void CheckNewVersion(bool alert)
        {
            try
            {
                if (!Memory.IsConnectionAvailable()) return;
                System.Net.WebClient web = new System.Net.WebClient();
                //check new version
                if (!Memory.ServerUrl.EndsWith("/")) Memory.ServerUrl += "/";
                string serverVersion = web.DownloadString(Memory.ServerUrl + "version.txt").Replace("ï»¿", "");
                string t = serverVersion.Replace(".", "");
                if (!Validator.IsNumber(t)) return;

                int check = string.Compare(serverVersion, Memory.CurrentVersion);
                //if no new version
                if (check <= 0)
                {
                    return;
                }
                //if has new version, get new version info
                Assembly updateAsm = loadUpdateModule();
                if (updateAsm == null)
                {
                    MessageBox.Show("Không tìm thấy thư viện cập nhật chương trình (Tập tin [AutoUpdate.exe] đã bị xóa hoặc bị hư).\r\nXin vui lòng cài đặt lại chương trình hoặc liên hệ tác giả");
                    return;
                }

                Type objectType = updateAsm.GetType("AutoUpdate.frmProcess");
                object update = Activator.CreateInstance(objectType);

                check = (int)update.GetType().InvokeMember("CheckVersion", BindingFlags.InvokeMethod, null, update, null);
                object info = update.GetType().InvokeMember("Information", BindingFlags.GetProperty, null, update, null);
                Memory.ServerUrl = (string)info.GetType().InvokeMember("ServerUrl", BindingFlags.GetProperty, null, info, null);
                //Memory.CurrentVersion = (string)info.GetType().InvokeMember("CurrentVersion", BindingFlags.GetProperty, null, info, null);

                if (check == -1)
                {
                    if (alert) MessageBox.Show(info.GetType().InvokeMember("ErrorInfo", BindingFlags.GetProperty, null, info, null).ToString(),
                         "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (check == 0)
                {
                    if (alert) MessageBox.Show("Không tìm thấy bản mới hơn. Phiên bản bạn đang dùng là phiên bản mới nhất",
                                             "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string updateInfo = (string)info.GetType().InvokeMember("UpdateInfo", BindingFlags.GetProperty, null, info, null);
                if (MessageBox.Show("Đã có phiên bản mới hơn của chương trình. Bạn có muốn tải bản mới nhất không?" + Environment.NewLine +
                                     "Thông tin cập nhật trong bản mới:" + Environment.NewLine + updateInfo +
                                     "Nếu cập nhật thất bại, bạn vui lòng vào website " + Memory.ServerUrl + " để tại bản cập nhật mới nhất về hoặc liên hệ tác giả",
                                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                try
                {
                    System.Diagnostics.Process.Start("AutoUpdate.exe");
                    Application.Exit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không tìm thấy file cập nhật chương trình. Xin vui lòng cài lại chương trình hoặc liên hệ tác giả", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (alert) MessageBox.Show(ex.Message, "Lỗi Exception (frmMain, CheckNewVersion)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}