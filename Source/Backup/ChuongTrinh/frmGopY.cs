using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxControl;
using GxGlobal;

namespace GiaoXu
{
    public partial class frmGopY : frmBase
    {
        public frmGopY()
        {
            InitializeComponent();
            this.HelpKey = "lien_he";
            gxCommand1.OKButton.Text = "&Gởi ý kiến";
            this.AcceptButton = gxCommand1.OKButton;
            gxCommand1.OKIsAccept = true;
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "" || txtHoTen.Text.Trim() == "" || txtYKien.Text.Trim() == "")
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!Memory.IsEmail(txtEmail.Text))
            {
                MessageBox.Show("Xin vui lòng nhập email hợp lệ");
                return;
            }
            try
            {
                if (Memory.ServerUrl != "")
                {
                    string giaoXu = "";
                    DataTable tblGiaoXuInfo = Memory.GetData(SqlConstants.SELECT_GIAOXU);
                    if (tblGiaoXuInfo != null && tblGiaoXuInfo.Rows.Count > 0)
                    {
                        giaoXu = System.Web.HttpUtility.UrlEncode(tblGiaoXuInfo.Rows[0][GiaoXuConst.TenGiaoXu].ToString()) + ": ";
                        giaoXu += System.Web.HttpUtility.UrlEncode(tblGiaoXuInfo.Rows[0][GiaoXuConst.DiaChi].ToString());
                    }
                    string email = System.Web.HttpUtility.UrlEncode(txtEmail.Text);
                    string hoten = System.Web.HttpUtility.UrlEncode(txtHoTen.Text);
                    string ykien = System.Web.HttpUtility.UrlEncode(txtYKien.Text);
                    string queryString = string.Format("?txtEmail={0}&txtHoTen={1}&txtGiaoXu={2}&txtYKien={3}&fromform={4}",
                                            email, hoten, giaoXu, ykien, true);

                    System.Net.WebClient web = new System.Net.WebClient();
                    web.OpenRead(Memory.ServerUrl + "gopy.aspx" + queryString);
                    MessageBox.Show("Ý kiến của bạn đã được gởi!");
                    this.Close();
                }
            }
            catch
            { }
        }

        private void frmGopY_Load(object sender, EventArgs e)
        {
            if (!Memory.IsConnectionAvailable())
            {
                MessageBox.Show("Bạn hiện không kết nối internet. Không thể đưa ý kiến đóng góp được");
                this.Close();
            }
        }
    }
}