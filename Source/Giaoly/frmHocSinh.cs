using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxControl;
using GxGlobal;
using Janus.Windows.GridEX;

namespace GiaoLy
{
    public partial class frmHocSinh : frmBase
    {


        public frmHocSinh()
        {
            InitializeComponent();
            this.HelpKey = "hoc_sinh";

            gxCommand1.OKButton.Text = "&Chấp nhận";
            this.AcceptButton = gxCommand1.OKButton;
            
        }

        private int idGiaoDan = 0;

        public int MaGiaoDan
        {
            get { return idGiaoDan; }
            set
            {
                idGiaoDan = value;
            }
        }

        private int idLop = 0;

        public int MaLop
        {
            get { return idLop; }
            set
            {
                idLop = value;
            }
        }

        private string tenThanh = "";

        public string TenThanh
        {
            get { return tenThanh; }
            set
            {
                tenThanh = value;
            }
        }
        private string hoTen = "";

        public string HoTen
        {
            get { return hoTen; }
            set
            {
                hoTen = value;
            }
        }
        private string phai = "";

        public string Phai
        {
            get { return phai; }
            set
            {
                phai = value;
            }
        }

        private string ngaysinh = "";

        public string NgaySinh
        {
            get { return ngaysinh; }
            set
            {
                ngaysinh = value;
            }
        }

        private bool hoanThanh = false;

        public bool HoanThanh
        {
            get { return hoanThanh; }
            set
            {
                hoanThanh = value;
            }
        }

        private string ghiChu = "";

        public string GhiChu
        {
            get { return ghiChu; }
            set
            {
                ghiChu = value;
            }
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            txtTenThanh.Enabled = false;
            txtHoTen.Enabled = false;
            txtPhai.Enabled = false;
            txtNgaySinh.Enabled = false;

        }

        private void AssignDataSource(DataRow row)
        {
            row["magiaodan"] = MaGiaoDan;
            row["malop"] = MaLop;
            row["hoanthanh"] = rabDa.Checked;            
            row["ghichugly"] = txtGhiChu.Text;
        }

        public void AssignControlData()
        {
            txtTenThanh.Text = TenThanh;
            txtHoTen.Text = HoTen;
            if (Phai.Equals("Nam"))
            {
                txtPhai.Text = "Nam";
            }
            else
            {
                txtPhai.Text = "Nữ";
            }
            txtNgaySinh.Text = NgaySinh;
            if (HoanThanh)
            {
                rabDa.Checked = true;
            }
            else
            {
                rabChua.Checked = true;
            }
            txtGhiChu.Text = GhiChu;
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            DataTable tblChiTietLopGiaoLy = Memory.GetData("SELECT * FROM ChiTietLopGiaoLy WHERE MaLop = ? and MaGiaoDan= ?", new object[] { MaLop,MaGiaoDan });
            if (Memory.ShowError())
            {
                return;
            }
            tblChiTietLopGiaoLy.TableName = "ChiTietLopGiaoLy";
            dataReturn = tblChiTietLopGiaoLy.NewRow();
            AssignDataSource(dataReturn);
            this.DialogResult = DialogResult.OK;
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {

        }
    }
}