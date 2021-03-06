using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;

namespace GxControl
{
    public partial class frmHelp : frmBase
    {
        private Dictionary<string, string> dicHelp = new Dictionary<string, string>();

        private bool allowShowMessage = true;

        public bool AllowShowMessage
        {
            get { return allowShowMessage; }
            set { allowShowMessage = value; }
        }

        public frmHelp()
        {
            InitializeComponent();
            dicHelp.Add("index", "Hướng dẫn sử dụng chương trình");
            dicHelp.Add("giao_dan", "Hướng dẫn quản lý thông tin giáo dân");
            dicHelp.Add("gia_dinh", "Hướng dẫn quản lý thông tin gia đình");
            dicHelp.Add("cai_dat", "Hướng dẫn cách cài đặt chương trình");
            dicHelp.Add("cap_nhat", "Hướng dẫn cập nhật chương trình");
            dicHelp.Add("dot_bi_tich", "Hướng dẫn quản lý các đợt bí tích");
            dicHelp.Add("gia_dinh_luu_tru", "Hướng dẫn quản lý thông tin lưu trữ gia đình");
            dicHelp.Add("giao_dan_luu_tru", "Hướng dẫn quản lý thông tin lưu trữ giáo dân");
            dicHelp.Add("giao_ho", "Hướng dẫn quản lý thông tin giáo họ");
            dicHelp.Add("giao_xu", "Hướng dẫn quản lý thông tin giáo xứ");
            dicHelp.Add("ket_noi_du_lieu", "Hướng dẫn cách kết nối dữ liệu từ nhiều máy");
            dicHelp.Add("kiem_tra_du_lieu", "Hướng dẫn kiểm tra dữ liệu");
            dicHelp.Add("lien_he", "Hướng dẫn liên hệ");
            dicHelp.Add("nhap_giao_dan", "Hướng dẫn nhập thông tin giáo dân");
            dicHelp.Add("thao_tac_chung", "Hướng dẫn các thao tác chung");
            dicHelp.Add("thong_ke", "Hướng dẫn thống kê");
            dicHelp.Add("tim_kiem", "Hướng dẫn tìm kiếm");
            dicHelp.Add("tuy_chon", "Hướng dẫn các tùy chọn cho chương trình");
            dicHelp.Add("sao_luu_khoi_phuc", "Sao lưu và khôi phục dữ liệu");
            dicHelp.Add("rao_hon_phoi", "Rao hôn phối");
            dicHelp.Add("thong_tin_cap_nhat", "Thông tin cập nhật");
            dicHelp.Add("chuyen_ho", "Chuyển giáo họ hàng loạt");
        }

        public bool SetHelp(string key)
        {
            string path = "";
            bool isConnected = Memory.IsConnectionAvailable();
            if (key == "index")
            {
                if (isConnected && Memory.ServerUrl != "")
                {
                    path = Memory.ServerUrl + "help/" + key + ".htm";
                }
                else
                {
                    path = string.Format("{0}help\\{1}.htm", Memory.AppPath, key);
                }
            }
            else
            {
                if (dicHelp.ContainsKey(key))
                {
                    path = string.Format("{0}help\\{1}.htm", Memory.AppPath, key);
                    if (!System.IO.File.Exists(path) && isConnected && Memory.ServerUrl != "")
                    {
                        path = Memory.ServerUrl + "help/" + key + ".htm";
                    }
                }
                else
                {
                    path = key;
                }
            }
            if (!isConnected && !System.IO.File.Exists(path))
            {
                if (allowShowMessage)
                {
                    MessageBox.Show("Không tìm thấy tập tin hướng dẫn cho mục này.\r\nCó thể tập tin chưa được tải hoặc đã bị xóa\r\nXin vui lòng tải lại tập tin hướng dẫn đầy đủ cho chương trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            Uri uri = new Uri(path);
            webBrowser1.Url = uri;
            if (dicHelp.ContainsKey(key))
            {
                this.Text = dicHelp[key];
            }
            else
            {
                this.Text = "Thông tin online";
            }
            return true;
        }

        private void frmHelp_Resize(object sender, EventArgs e)
        {
            //webBrowser1.Height = this.Height - 20;
            //webBrowser1.Width = this.Width - 30;
        }
    }
}