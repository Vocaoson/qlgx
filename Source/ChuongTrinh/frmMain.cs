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
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.IO;

namespace GiaoXu
{
    public partial class frmMain : Form
    {
        private Dictionary<string, FATabStripItem> dicShows = new Dictionary<string, FATabStripItem>();
        private FATabStripItem defaulItem = null;
        private frmReplace frmReplace = new frmReplace();
        private frmTimGiaoDan frmTimGiaoDan = new frmTimGiaoDan();
        private frmTimGiaDinh frmTimGiaDinh = new frmTimGiaDinh();
        private bool processError = false;
        DataTable tblGiaoXu = null;

        public frmMain()
        {
            InitializeComponent();
            frmReplace.OnOK += new EventHandler(frmReplace_OnOK);
            tblGiaoXu = Memory.GetData(SqlConstants.SELECT_GIAOXU);

            //update new version start
            GxCheckVersion checkVersion = new GxCheckVersion();
            checkVersion.Alert = false;
            checkVersion.OnFinished += new EventHandler(checkVersion_OnFinished);
            ThreadStart threadStart = new ThreadStart(checkVersion.Execute);
            Thread thread = new Thread(threadStart);
            thread.Start();
            //update new version end
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (Memory.ShowError() || tblGiaoXu == null || tblGiaoXu.Rows.Count == 0)
                {
                    defaulItem = new FATabStripItem("QLGX - Quản lý giáo xứ", null);
                    this.pictureBox1.BackgroundImage = Image.FromFile(Memory.AppPath + GxConstants.CHURCH_IMG_NAME);
                    MessageBox.Show("Xin vui lòng nhập thông tin giáo xứ trước khi làm việc với chương trình");
                    ShowForm(new frmGiaoXu());                    
                }
                else if (tblGiaoXu.Rows.Count > 0)
                {
                    Memory.GiaoXuInfo = tblGiaoXu.Rows[0];
                    string gxName = string.Format("Giáo xứ {0}", tblGiaoXu.Rows[0][GiaoXuConst.TenGiaoXu]);
                    string version = Memory.CurrentVersionDisplay != "" ? " phiên bản " + Memory.CurrentVersionDisplay : "";
                    this.Text = string.Format("QLGX - Chương trình quản lý giáo xứ{0} - {1}", version, gxName);
                    defaulItem = new FATabStripItem(gxName, null);
                    string imgPath = Memory.AppPath + tblGiaoXu.Rows[0][GiaoXuConst.Hinh].ToString();
                    if (System.IO.File.Exists(imgPath))
                    {
                        this.pictureBox1.BackgroundImage = Image.FromFile(Memory.AppPath + tblGiaoXu.Rows[0][GiaoXuConst.Hinh].ToString());
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

            //Check message from website start
            
            GxKiemTraThongBao kiemTraThongBao = new GxKiemTraThongBao();
            kiemTraThongBao.OnFinished += new EventHandler(kiemTraThongBao_OnFinished);
            ThreadStart threadStart = new ThreadStart(kiemTraThongBao.Execute);
            Thread thread = new Thread(threadStart);
            thread.Start();

            //Check message from website end
        }

        private void checkVersion_OnFinished(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    EventHandler d = new EventHandler(checkVersion_OnFinished);
                    this.Invoke(d, new object[] { sender, e });
                }
                else
                {
                    GxCheckVersion checkVersion = (GxCheckVersion)sender;
                    if (checkVersion.HasNewVersion)
                    {
                        frmShowUpdateInfo updateDialog = new frmShowUpdateInfo();
                        string updateInfo = checkVersion.UpdateInfo;
                        updateInfo = updateInfo.Trim().Replace(Environment.NewLine, "<br />");
                        updateInfo = string.Concat("<thml><body style='font-family:Microsoft Sans Serif;font-size:12px;margin:0 10 0 10'>", updateInfo, "</body></html>");
                        updateDialog.Info = updateInfo;
                        DialogResult rs = updateDialog.ShowDialog(this);
                        if (rs != DialogResult.OK)
                        {
                            return;
                        }

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
                }
            }
            catch
            {
                //Do nothing if error
            }            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //Delete all temp file
            try
            {
                Memory.SaveConfig();
                string temp = System.IO.Path.GetTempPath() + GxConstants.TempFolder;
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(temp);
                foreach (System.IO.FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
                /*
                //Save Grid config
                DataTable tbl = (DataTable)Memory.Instance.GetMemory("GridColumns");
                DataSet ds = new DataSet();
                ds.Tables.Add(tbl);
                ds.WriteXml(GxGrid.XmlPath);
                tbl.AcceptChanges();
                tbl.DataSet.Tables.Remove(tbl);
                 * */
            }
            catch { }
            try
            {
                foreach (var frm in dicShows)
                {
                    if (frm.Value.Controls.Count > 0 && frm.Value.Controls[0] is frmBase)
                    {
                        (frm.Value.Controls[0] as frmBase).Close();
                    }
                }
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Form frm = Application.OpenForms[i];
                    if (!frm.Equals(this))
                    {
                        frm.Dispose();
                    }
                }
                
            }
            catch { }
            //Memory.SaveConfig();
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
            LoadFunction(e.Item.Key);
        }

        private void explorerBar1_ItemClick(object sender, ItemEventArgs e)
        {
            LoadFunction(e.Item.Key);
        }

        private void LoadFunction(string key)
        {
            if (key == "itNhapGiaoHo")
            {
                frmGiaoHo frm = new frmGiaoHo();
                ShowForm(frm);
            }
            else if (key == "itNhapGiaoDan")
            {
                frmGiaoDanList frm = new frmGiaoDanList();
                ShowForm(frm);
            }
            else if (key == "itNhapGiaDinh")
            {
                frmGiaDinhList frm = new frmGiaDinhList();
                ShowForm(frm);
            }
            else if (key == "itNhapGiaoXu")
            {
                frmGiaoXu frm = new frmGiaoXu();
                ShowForm(frm);
            }
            else if (key == "itSoBiTich")
            {
                frmDotBiTichList frm = new frmDotBiTichList();
                ShowForm(frm);
            }
            else if (key == "itThongKeChung")
            {
                frmThongKeChung frm = new frmThongKeChung();
                ShowForm(frm);
            }
            else if (key == "itLuuTruGiaoDan")
            {
                frmGiaoDanLuuTruList frm = new frmGiaoDanLuuTruList();
                ShowForm(frm);
            }
            else if (key == "itLuuTruGiaDinh")
            {
                frmGiaDinhLuuTruList frm = new frmGiaDinhLuuTruList();
                ShowForm(frm);
            }
            else if (key == "itTimGiaoDan")
            {
                frmTimGiaoDan.ShowDialog();
            }
            else if (key == "itTimGiaDinhCuaGiaoDan")
            {
                frmTimGiaDinh.ShowDialog();
            }
            else if (key == "itTimThayThe")
            {
                frmReplace.ShowDialog();
            }
            else if (key == "itKiemTraGiaoDan")
            {
                frmKiemTraGiaoDanList frm = new frmKiemTraGiaoDanList();
                ShowForm(frm);
            }
            else if (key == "itKiemTraGiaDinh")
            {
                frmKiemTraGiaDinhList frm = new frmKiemTraGiaDinhList();
                ShowForm(frm);
            }
            else if (key == "itKiemTraPhienBan")
            {
                GxCheckVersion checkVersion = new GxCheckVersion();
                checkVersion.Alert = true;
                checkVersion.OnFinished += new EventHandler(checkVersion_OnFinished);
                checkVersion.Execute();
            }
            else if (key == "itAboutUs")
            {
                frmAbout frm = new frmAbout();
                frm.ShowDialog();
            }
            else if (key == "itGopY")
            {
                //frmGopY frm = new frmGopY();
                //frm.ShowDialog();
                try
                {
                    //System.Diagnostics.Process.Start(Memory.AppPath + "HuongDan.Doc");
                    if (Memory.IsConnectionAvailable())
                    {
                        frmHelp frmHelp = new frmHelp();
                        string helpKey = "http://forum.qlgx.net/gopy";
                        ShowThongTinOnline(helpKey, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có kết nối internet, vì thế không sử dụng được chức năng này. Bạn có thể liên hệ với tác giả qua email " + GxConstants.EMAIL + "\n Xin chân thành cảm ơn!");
                    }
                }
                catch (Exception)
                {
                }
            }
            else if (key == "itHuongDan")
            {
                menuItem10_Click(this, EventArgs.Empty);
            }
            else if (key == "itRaoHonPhoi")
            {
                frmRaoHonPhoiList frm = new frmRaoHonPhoiList();
                ShowForm(frm);
            }
            else if (key == "itChuanHoaDuLieuGiaoDan")
            {
                chuanHoaDuLieu(ProcessOptions.AutoUpperFirstCharGiaoDan);
            }
            else if (key == "itChuanHoaDuLieuGiaDinh")
            {
                chuanHoaDuLieu(ProcessOptions.AutoUpperFirstCharGiaDinh);
            }
            else if (key == "itChuyenHoGiaoDan")
            {
                frmChuyenHoGiaoDan frm = new frmChuyenHoGiaoDan();
                ShowForm(frm);
            }
            else if (key == "itChuyenHoGiaDinh")
            {
                frmChuyenHoGiaDinh frm = new frmChuyenHoGiaDinh();
                ShowForm(frm);
            }
            else if (key == "itGiaoLy")
            {
                GiaoLy.frmKhoiGiaoLyList frm = new GiaoLy.frmKhoiGiaoLyList();
                ShowForm(frm);
            }
            else if (key == "itThongTinOnline")
            {
                //Check message from website start
                if (Memory.IsConnectionAvailable())
                {
                    GxKiemTraThongBao kiemTraThongBao = new GxKiemTraThongBao();
                    kiemTraThongBao.OnFinished += new EventHandler(kiemTraThongBao_OnFinished1);
                    ThreadStart threadStart = new ThreadStart(kiemTraThongBao.Execute);
                    Thread thread = new Thread(threadStart);
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("Bạn không có kết nối internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Check message from website end
            }
            else if (key == "itLapBiTichTuDong")
            {
                frmTaoDotBiTich frm = new frmTaoDotBiTich();
                frm.ShowDialog();
            }
            else if (key == "itBieuDo")
            {
                frmBieuDo frm = new frmBieuDo();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void chuanHoaDuLieu(ProcessOptions options)
        {
            if (options == ProcessOptions.AutoUpperFirstCharGiaDinh || options == ProcessOptions.AutoUpperFirstCharGiaoDan)
            {
                frmProcess frmUpdate = new frmProcess();
                
                if (options == ProcessOptions.AutoUpperFirstCharGiaoDan)
                {
                    if (MessageBox.Show("Bạn có chắc muốn thực hiện việc chuẩn hóa dữ liệu (tất cả các dữ liệu được nhập cho giáo dân sẽ được chuyển hóa theo quy tắc viết hoa chữ cái đầu tiên mỗi từ, các ký tự khác trong từ chuyển thành chữ thường, trừ các ghi chú)?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    frmUpdate.LabelStart = "Đang chuẩn hóa dữ liệu giáo dân...";
                    frmUpdate.LableFinished = "Đã thực hiện xong!";
                    frmUpdate.Text = "Đang chuẩn hóa dữ liệu giáo dân. Có thể mất vài phút. Xin vui lòng đợi...";
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc muốn thực hiện việc chuẩn hóa dữ liệu (tất cả các dữ liệu được nhập cho gia đình sẽ được chuyển hóa theo quy tắc viết hoa chữ cái đầu tiên mỗi từ, các ký tự khác trong từ viết thường, trừ các ghi chú)?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    frmUpdate.LabelStart = "Đang chuẩn hóa dữ liệu gia đình...";
                    frmUpdate.LableFinished = "Đã thực hiện xong!";
                    frmUpdate.Text = "Đang chuẩn hóa dữ liệu gia đình. Có thể mất vài phút. Xin vui lòng đợi...";
                    
                }

                frmUpdate.ProcessClass = new UpdateProcess();
                frmUpdate.ProcessClass.ProcessOptions = options;
                frmUpdate.StartFunction = new EventHandler(frmUpdate_OnUpdating);
                frmUpdate.ErrorFunction = new CancelEventHandler(frmUpdate_OnError);
                frmUpdate.FinishedFunction = new EventHandler(frmUpdate_OnFinished);
                frmUpdate.ShowDialog();
            }
            
        }

        public void frmUpdate_OnUpdating(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler d = new EventHandler(frmUpdate_OnUpdating);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.Enabled = false;
            }
        }

        public void frmUpdate_OnError(object sender, CancelEventArgs e)
        {
            if (this.InvokeRequired)
            {
                CancelEventHandler d = new CancelEventHandler(frmUpdate_OnError);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                Memory.ShowError(sender.ToString());
                processError = true;
                this.Enabled = true;
            }
        }

        public void frmUpdate_OnFinished(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    EventHandler d = new EventHandler(frmUpdate_OnFinished);
                    this.Invoke(d, new object[] { sender, e });
                }
                else
                {
                    if(!processError) MessageBox.Show("Thực hiện xong");
                    processError = false;
                    this.Enabled = true;
                }
            }
            catch
            {

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

        public void ShowHelp(string helpKey)
        {
            frmHelp frm = new frmHelp();
            frm.SetHelp(helpKey);
            ShowForm(frm);
        }

        public void ShowForm(Form frm)
        {
            ShowForm(frm, true);
        }

        public void ShowForm(Form frm, bool autoSelect)
        {
            FATabStripItem item = null;
            if (dicShows.ContainsKey(frm.Name))
            {
                try
                {
                    FATabStrip.SelectedItem = dicShows[frm.Name];
                    item = FATabStrip.SelectedItem;
                    item.Controls.RemoveAt(0);
                    frmBase opennedForm = (frmBase)Application.OpenForms[frm.Name];
                    opennedForm.Close();
                }
                catch { }
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
            frm.AutoScroll = true;
            frm.WindowState = FormWindowState.Maximized;
            
            item.Controls.Add(frm);

            //frm.Dock = DockStyle.Fill;
            if (autoSelect || FATabStrip.Items.DrawnCount == 1)
            {
                FATabStrip.SelectedItem = item;
                item.Selected = true;
            }
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
                frm.Close();
                GC.Collect();
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
            GxCheckVersion checkVersion = new GxCheckVersion();
            checkVersion.Alert = true;
            checkVersion.OnFinished += new EventHandler(checkVersion_OnFinished);
            checkVersion.Execute();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start(Memory.AppPath + "HuongDan.Doc");
                frmHelp frmHelp = new frmHelp();
                string helpKey = "index";
                foreach (Control frm in FATabStrip.SelectedItem.Controls)
                {
                    if (frm is frmBase && !(frm is frmHelp))
                    {
                        helpKey = (frm as frmBase).HelpKey;
                        break;
                    }
                }
                frmHelp.SetHelp(helpKey);
                frmHelp.Show();
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

        /// <summary>
        /// Backup data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string path = compressDatabase();
            if (path != "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "ZIP (*.zip)|*.zip";
                save.FileName = "data" + DateTime.Now.ToString("yyyyMMddhhmm") + ".zip";
                save.InitialDirectory = Memory.AppPath + "backup\\";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(path, save.FileName);
                        MessageBox.Show("Sao lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                try
                {
                    File.Delete(path);
                }
                catch 
                {
                    
                }
            }
        }

        private string compressDatabase()
        {
            try
            {
                FastZip fzip = new FastZip();
                string path = Memory.GetTempPath("dulieugiaoxu.zip");
                fzip.CreateZip(path, Memory.AppPath, false, "giaoxu.mdb");
                return path;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception compressDatabase()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void khôiPhụcDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestore frm = new frmRestore();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void kiemTraThongBao_OnFinished(object sender, EventArgs e)
        {
            if (this.FATabStrip.InvokeRequired)
            {
                EventHandler d = new EventHandler(kiemTraThongBao_OnFinished);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                string message = (sender as IGxProcess).ProcessData.ToString();
                ShowThongTinOnline(message, false);
            }
        }

        private void kiemTraThongBao_OnFinished1(object sender, EventArgs e)
        {
            if (this.FATabStrip.InvokeRequired)
            {
                EventHandler d = new EventHandler(kiemTraThongBao_OnFinished1);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                string message = (sender as IGxProcess).ProcessData.ToString();
                ShowThongTinOnline(message, true);
            }
        }

        private void ShowThongTinOnline(string message, bool showMessage)
        {
            try
            {
                if (message.Trim() != "")
                {
                    frmHelp frm = new frmHelp();
                    frm.AllowShowMessage = false;
                    if (frm.SetHelp(message))
                    {
                        ShowForm(frm, false);
                    }
                }
                else
                {
                    if (showMessage)
                    {
                        MessageBox.Show("Không có thông tin nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception) { }
        }

        private void xuấtDữLiệuRaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcess frmUpdate = new frmProcess();

            processError = false;

            frmUpdate.LabelStart = "Chuẩn bị thực hiện việc xuất dữ liệu...";
            frmUpdate.LableFinished = "Đã thực hiện xong!";
            frmUpdate.Text = "Đang xuất dữ liệu ra Excel. Xin vui lòng đợi...";
            frmUpdate.ProcessClass = new ExportDataToExcel();

            //assign process data 
            frmUpdate.StartFunction = new EventHandler(frmUpdate_OnUpdating);
            frmUpdate.ErrorFunction = new CancelEventHandler(frmUpdate_OnError);
            frmUpdate.FinishedFunction = new EventHandler(frmUpdate_OnFinished);
            frmUpdate.ShowDialog();
        }

        private void nhậpDữLiệuTừMSExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            frm.ImportDataType = frmImport.ImportType.Excel;
            frm.ShowDialog();
        }        
    }
}