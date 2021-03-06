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
    public partial class frmLinhMuc : frmBase
    {
        public frmLinhMuc()
        {
            InitializeComponent();
            this.HelpKey = "giao_xu";
            (dtDenNgay.editBase as GxDateInput).IsNullDate = true;
            (dtTuNgay.editBase as GxDateInput).IsNullDate = true;
            cbChucVu.Combo.Items.Add("Chánh xứ");
            cbChucVu.Combo.Items.Add("Phó xứ");
            cbChucVu.Combo.Items.Add("Quản nhiệm");
            cbChucVu.Combo.Items.Add("Khác");
            cbChucVu.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            gxCommand1.OKButton.Text = "&Cập nhật";
            this.AcceptButton = gxCommand1.OKButton;
            (dtNgaySinh.editBase as GxDateInput).IsNullDate = true;
        }

        private void frmLinhMuc_Load(object sender, EventArgs e)
        {
            if (operation == GxOperation.ADD) id = Memory.Instance.GetNextId(LinhMucConst.TableName, LinhMucConst.MaLinhMuc, true);
            else txtMaLinhMuc.ReadOnly = true;
            txtMaLinhMuc.Text = id.ToString();
            
        }

        private bool checkInput()
        {
            if (!Validator.IsNumber(txtMaLinhMuc.Text))
            {
                MessageBox.Show("Mã linh mục phải được nhập số");
                txtMaLinhMuc.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenThanh.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập Tên Thánh!");
                txtTenThanh.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập Họ tên!");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbChucVu.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập chức vụ!");
                cbChucVu.Focus();
                return false;
            }

            //if (dtNgaySinh.Value == DBNull.Value)
            //{
            //    MessageBox.Show("Hãy nhập ngày sinh!");
            //    dtNgaySinh.Focus();
            //    return false;
            //}

            //if (dtTuNgay.Value == DBNull.Value)
            //{
            //    MessageBox.Show("Hãy nhập ngày bắt đầu quản xứ!");
            //    dtTuNgay.Focus();
            //    return false;
            //}

            return checkLinhMuc();
        }

        private bool checkLinhMuc()
        {
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_CHECK_LINHMUC, new object[] {txtTenThanh.Text, txtHoTen.Text, dtNgaySinh.Value, Id });
            if (Memory.HasError())
            {
                Memory.ShowError();
                return false;
            }
            if (tbl == null || tbl.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Đã có Linh mục cùng họ tên, tên thánh và ngày sinh trong hệ thống.\r\nBạn có muốn thêm một Linh mục mới trùng những thông tin trên?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.No)
                    return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!checkInput()) return;
            if (operation == GxOperation.ADD) id = Memory.Instance.GetNextId(LinhMucConst.TableName, LinhMucConst.MaLinhMuc, true);
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_LINHMUC_LIST + " AND MaLinhMuc = " + id.ToString());
            tbl.TableName = LinhMucConst.TableName;
            if (operation == GxOperation.ADD)
            {
                dataReturn = tbl.NewRow();
                AssignDataSource(dataReturn);
                tbl.Rows.Add(dataReturn);
            }
            else
            {
                dataReturn = tbl.Rows[0];
                AssignDataSource(dataReturn);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);
            Memory.UpdateDataSet(ds);
            if (!Memory.ShowError())
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void AssignDataSource(DataRow row)
        {
            row[LinhMucConst.MaLinhMuc] = int.Parse(txtMaLinhMuc.Text);
            row[LinhMucConst.TenThanh] = txtTenThanh.Text;
            row[LinhMucConst.HoTen] = txtHoTen.Text;
            row[LinhMucConst.ChucVu] = cbChucVu.Text;
            row[LinhMucConst.NgaySinh] = dtNgaySinh.Value;
            row[LinhMucConst.TuNgay] = dtTuNgay.Value;
            row[LinhMucConst.DenNgay] = dtDenNgay.Value;
            row[LinhMucConst.DienThoai] = txtDienThoai.Text;
            row[LinhMucConst.Email] = txtEmail.Text;
            row[LinhMucConst.GhiChu] = txtGhiChu.Text;
            row[LinhMucConst.UpdateDate] = Memory.Instance.GetServerDateTime();
        }

        public void AssignControlData()
        {
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_LINHMUC_LIST + " AND MaLinhMuc=" + id.ToString());
            if (tbl != null && tbl.Rows.Count > 0)
            {
                AssignControlData(tbl.Rows[0]);
            }
        }

        public void AssignControlData(DataRow row)
        {
            id = (int)row[LinhMucConst.MaLinhMuc];
            txtTenThanh.Text = row[LinhMucConst.TenThanh].ToString();
            txtHoTen.Text = row[LinhMucConst.HoTen].ToString();
            cbChucVu.Text = row[LinhMucConst.ChucVu].ToString();
            dtNgaySinh.Value = row[LinhMucConst.NgaySinh];
            dtTuNgay.Value = row[LinhMucConst.TuNgay];
            dtDenNgay.Value = row[LinhMucConst.DenNgay];
            txtGhiChu.Text = row[LinhMucConst.GhiChu].ToString();
            txtDienThoai.Text = row[LinhMucConst.DienThoai].ToString();
            txtEmail.Text = row[LinhMucConst.Email].ToString();
        }
        
    }
}