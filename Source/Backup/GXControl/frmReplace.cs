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
    public partial class frmReplace : frmBase
    {
        private DataTable tblGiaDinh = new DataTable();
        private DataTable tblGiaoDan = new DataTable();
        private DataTable tblTable = new DataTable();

        public event EventHandler OnOK;

        private string whereSQL = "";

        public string WhereSQL
        {
            get { return whereSQL; }
            set { whereSQL = value; }
        }

        private string tableName = "";

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public frmReplace()
        {
            InitializeComponent();
            this.HelpKey = "tim_kiem";

            tblTable.Columns.Add("Key");
            tblTable.Columns.Add("Value");
            tblTable.Rows.Add(GiaDinhConst.TableName, "Gia đình");
            tblTable.Rows.Add(GiaoDanConst.TableName, "Giáo dân");

            cbForm.Combo.DataSource = tblTable;
            cbForm.Combo.DisplayMember = "Value";
            cbForm.Combo.ValueMember = "Key";

            tblGiaoDan.Columns.Add("Key");
            tblGiaoDan.Columns.Add("Value");
            tblGiaoDan.Rows.Add(GiaoDanConst.TenThanh, "Tên thánh");
            tblGiaoDan.Rows.Add(GiaoDanConst.HoTen, "Họ tên");
            tblGiaoDan.Rows.Add(GiaoDanConst.HoTenCha, "Họ tên cha");
            tblGiaoDan.Rows.Add(GiaoDanConst.HoTenMe, "Họ tên mẹ");
            tblGiaoDan.Rows.Add(GiaoDanConst.ChaRuaToi, "Người ban bí tích rửa tội");
            tblGiaoDan.Rows.Add(GiaoDanConst.ChaRuocLe, "Người ban bí tích xưng tội - rước lễ lần đầu");
            tblGiaoDan.Rows.Add(GiaoDanConst.ChaThemSuc, "Người ban bí tích thêm sức");
            tblGiaoDan.Rows.Add(GiaoDanConst.NguoiDoDauRuaToi, "Người đỡ đầu rửa tội");
            tblGiaoDan.Rows.Add(GiaoDanConst.NguoiDoDauThemSuc, "Người ban đỡ đầu thêm sức");
            tblGiaoDan.Rows.Add(GiaoDanConst.NoiSinh, "Nơi sinh");
            tblGiaoDan.Rows.Add(GiaoDanConst.NoiRuaToi, "Nơi rửa tội");
            tblGiaoDan.Rows.Add(GiaoDanConst.NoiRuocLe, "Nơi xưng tội - rước lễ lần đầu");
            tblGiaoDan.Rows.Add(GiaoDanConst.NoiThemSuc, "Nơi thêm sức");
            tblGiaoDan.Rows.Add(GiaoDanConst.ThuocGiaoXu, "Thuộc giáo xứ");
            tblGiaoDan.Rows.Add(GiaoDanConst.DienThoai, "Điện thoại");
            tblGiaoDan.Rows.Add(GiaoDanConst.Email, "Email");
            tblGiaoDan.Rows.Add(GiaoDanConst.ThuocGiaoXu, "Thuộc giáo xứ");
            tblGiaoDan.Rows.Add(GiaoDanConst.TrinhDoVanHoa, "Trình độ văn hóa");
            tblGiaoDan.Rows.Add(GiaoDanConst.NgheNghiep, "Nghề nghiệp");
            tblGiaoDan.Rows.Add(GiaoDanConst.GhiChu, "Ghi chú");

            tblGiaDinh.Columns.Add("Key");
            tblGiaDinh.Columns.Add("Value");

            tblGiaDinh.Rows.Add(GiaDinhConst.TenGiaDinh, "Tên gia đình");
            //tblGiaDinh.Rows.Add(HonPhoiConst.LinhMucChung, "Người ban bí tích hôn phối");
            //tblGiaDinh.Rows.Add(HonPhoiConst.NguoiChung1, "Người chứng 1");
            //tblGiaDinh.Rows.Add(HonPhoiConst.NguoiChung2, "Người chứng 2");
            //tblGiaDinh.Rows.Add(HonPhoiConst.NoiHonPhoi, "Nơi nhận bí tích hôn phối");
            tblGiaDinh.Rows.Add(GiaDinhConst.DiaChi, "Địa chỉ");
            tblGiaDinh.Rows.Add(GiaDinhConst.DienThoai, "Điện thoại");
            tblGiaDinh.Rows.Add(GiaDinhConst.GhiChu, "Ghi chú");

            cbField.Combo.DisplayMember = "Value";
            cbField.Combo.ValueMember = "Key";
            cbField.Combo.DataSource = tblGiaDinh;

            gxCommand1.OKIsAccept = true;

            cbForm.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbField.Combo.DropDownStyle = ComboBoxStyle.DropDownList;            
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            //check
            if (txtFind.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập giá trị cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFind.Focus();
                return;
            }
            //confirm
            if (MessageBox.Show("Bạn có chắc muốn thay thế các giá trị đã nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //build sql
            tableName = cbForm.Combo.SelectedValue.ToString();
            string sql = string.Format("UPDATE {0} SET ", cbForm.Combo.SelectedValue);
            sql += string.Format(" {0}=? WHERE {0}=?", cbField.Combo.SelectedValue);
            whereSQL = string.Format(" AND {0}='{1}'", cbField.Combo.SelectedValue, txtReplace.Text.Replace("'", "''"));
            int rs = (int)Memory.ExecuteSqlCommand(sql, new object[] { txtReplace.Text, txtFind.Text });

            if (OnOK != null) OnOK(rs, e);

            if (Memory.ShowError())
            {
                this.Close();
                return;
            }
            if (rs >= 0)
            {
                MessageBox.Show(string.Format("Có {0} dữ liệu được thay thế", rs), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void cbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbForm.SelectedIndex == 0)//gia đình
            {
                cbField.Combo.DataSource = tblGiaDinh;
            }
            else if (cbForm.SelectedIndex == 1)//giao dân
            {
                cbField.Combo.DataSource = tblGiaoDan;
            }
            //cbField.Combo.DisplayMember = "Value";
        }
    }
}