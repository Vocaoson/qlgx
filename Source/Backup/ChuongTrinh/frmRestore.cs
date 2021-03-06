using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxControl;
using GxGlobal;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace GiaoXu
{
    public partial class frmRestore : frmBase
    {
        public frmRestore()
        {
            InitializeComponent();
            gxCommand1.OKButton.Visible = false;
            listView1.MultiSelect = false;
            string path = Memory.AppPath + "backup\\";
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                int i = 1;
                foreach (FileInfo file in dir.GetFiles("*.zip"))
                {
                    ListViewItem item = listView1.Items.Add(i.ToString());
                    item.SubItems.Add(file.Name);
                    item.SubItems.Add( file.CreationTime.ToString("dd/MM/yyyy h:mm:ss tt"));
                    i++;
                }
            }
            
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string path = "";
            if (Memory.BackupDatabase(out path))
            {
                ListViewItem item = listView1.Items.Add((listView1.Items.Count + 1).ToString());
                item.SubItems.Add(Path.GetFileName(path));
                item.SubItems.Add(System.DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt"));
                MessageBox.Show("Tạo sao lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnBackup.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu sao lưu tại thời điểm được chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string path = Memory.AppPath + "backup\\" + listView1.SelectedItems[0].SubItems[1].Text;
            try
            {
                File.Delete(path);
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa\r\n" +
                    "Error message:\r\n" +
                    ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn mục cần khôi phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn khôi phục dữ liệu từ mục được chọn không?\r\n" +
                "Nếu chọn [Yes] thì tất cả dữ liệu chương trình sẽ được phục hồi như tại thời điểm [" + listView1.SelectedItems[0].SubItems[2].Text + "] ", 
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string path = Memory.AppPath + "backup\\" + listView1.SelectedItems[0].SubItems[1].Text;
            path = Memory.RestoreDatabase(path);
            if (path == "")
            {
                MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi khi thực hiện việc phục hồi dữ liệu từ mục được chọn\r\n" +
                "Xin vui lòng đóng tất cả các màn hình đang được mở trong chương trình và thử lại lần nữa\r\n" +
                "Nếu có khó khăn nào, xin vui lòng liên hệ tác giả để được hướng dẫn thêm\r\n" +
                "Error message:\r\n" +
                path, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnRestoreFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Bạn có chắc muốn khôi phục dữ liệu từ mục được chọn không?\r\nHãy chắc chắn rằng tập tin bạn chọn là tập tin được sao lưu từ chương trình!", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    string path = openFileDialog1.FileName;
                    if (path.EndsWith(".mdb"))
                    {
                        File.Copy(path, Memory.AppPath + GxConstants.DB_FILENAME, true);
                        MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FastZip zip = new FastZip();
                    string exPath = Memory.GetTempPath("");
                    zip.ExtractZip(path, exPath, "mdb");
                    foreach (FileInfo file in new DirectoryInfo(exPath).GetFiles())
                    {
                        if (file.Extension == ".mdb")
                        {
                            path = file.FullName;
                            File.Copy(path, Memory.AppPath + GxConstants.DB_FILENAME, true);
                            MessageBox.Show("Khôi phục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    MessageBox.Show("Không tìm thấy dữ liệu chương trình từ tập tin bạn chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi thực hiện việc phục hồi dữ liệu từ mục được chọn\r\n" +
                        "Xin vui lòng đóng tất cả các màn hình đang được mở trong chương trình và thử lại lần nữa\r\n" +
                        "Nếu có khó khăn nào, xin vui lòng liên hệ tác giả để được hướng dẫn thêm\r\n" +
                        "Error message:\r\n" +
                        ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}