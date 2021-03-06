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

namespace GxControl
{
    public partial class frmHonPhoi : frmBase
    {
        bool isLoaded = false;

        #region PROPERTY
        public int MaHonPhoi
        {
            get { return id; }
            set
            {
                id = value;
                txtMaHonPhoi.Text = value.ToString();
            }
        }

        private int maNguoiNam = -1;

        public int MaNguoiNam
        {
            get { return txtNguoiChong.MaGiaoDan; }
            set { txtNguoiChong.MaGiaoDan = value; }
        }

        public int MaNguoiNu
        {
            get { return txtNguoiVo.MaGiaoDan; }
            set { txtNguoiVo.MaGiaoDan = value; }
        }
        #endregion

        public frmHonPhoi()
        {
            InitializeComponent();
            this.HelpKey = "gia_dinh";
            //gxAddEdit1.AddButton.Text = "&Thêm";
            //gxAddEdit1.DeleteButton.Text = "&Xóa";
            //gxAddEdit1.EditButton.Text = "&Xem-Sửa";
            //gxAddEdit1.SelectButton.Text = "&Chọn";
            gxCommand1.OKButton.Text = "&Cập nhật";
            gxCommand1.Button1.Text = "&In sổ đôi hôn phối";
            gxCommand1.Button1.Visible = true;
            cbCachThuc.Combo.Items.Add("");
            cbCachThuc.Combo.Items.Add("Hợp pháp");
            cbCachThuc.Combo.Items.Add("Hợp thức hóa");
            cbCachThuc.Combo.Items.Add("Chuẩn");
            cbCachThuc.Combo.Items.Add("Không theo phép đạo");
            cbCachThuc.Combo.Items.Add("Không xác định");
            cbCachThuc.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AcceptButton = gxCommand1.OKButton;
            (dtNgayHonPhoi.editBase as GxDateInput).IsNullDate = true;
            txtNguoiChong.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            txtNguoiVo.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NU.ToLower());

            txtNguoiChong.EditControl.ReloadButton.Visible = false;
            txtNguoiVo.EditControl.ReloadButton.Visible = false;
            //For linh muc control 
            Memory.Instance.SetMemory(GxConstants.LOAD_LINHMUC, null);
            
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmHonPhoi_Load(object sender, EventArgs e)
        {
            //handle events
            this.txtNguoiChong.OnSelected += new System.EventHandler(this.txtNguoiChong_OnSelected);
            this.txtNguoiVo.OnSelected += new System.EventHandler(this.txtNguoiVo_OnSelected);

            if (this.operation == GxOperation.ADD)
            {
                id = Memory.Instance.GetNextId(HonPhoiConst.TableName, HonPhoiConst.MaHonPhoi, true);
                cbCachThuc.Combo.SelectedIndex = 0;
                gxCommand1.Button1.Visible = false;
            }
            else
            {
                gxCommand1.Button1.Visible = true;
                if (this.Operation == GxOperation.VIEW)
                {
                    gxCommand1.OKButton.Visible = false;
                    gxCommand1.Button1.Visible = false;
                }
            }

            txtMaHonPhoi.Text = id.ToString();

            isLoaded = true;
        }

        private void txtNguoiChong_OnSelected(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            string tenChong = Memory.GetName(txtNguoiChong.Text).Trim();
            string tenVo = Memory.GetName(txtNguoiVo.Text).Trim();
            txtTenHonPhoi.Text = tenChong + (tenChong == "" || tenVo == "" ? "" : " - ") + tenVo;
        }

        private void txtNguoiVo_OnSelected(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            string tenChong = Memory.GetName(txtNguoiChong.Text).Trim();
            string tenVo = Memory.GetName(txtNguoiVo.Text).Trim();
            txtTenHonPhoi.Text = tenChong + (tenChong == "" || tenVo == "" ? "" : " - ") + tenVo;
        }

        private void txtNguoiVo_OnSelecting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoaded) return;
            DataRow row = (DataRow)sender;
            if (row[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NAM.ToLower())
            {
                MessageBox.Show("Người vợ không thể là nam!");
                e.Cancel = true;
                return;
            }
            //kiem tra tuoi hop le
            int tuoi = GxConstants.TUOI_HON_PHOI_NAM;
            if ((sender as DataRow)[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NAM.ToLower())
            {
                tuoi = GxConstants.TUOI_HON_PHOI_NU;
            }
            if (Memory.KiemTraTuoiKhongHopLe((sender as DataRow)[GiaoDanConst.NgaySinh], DateTime.Now.ToString("dd/MM/yyyy"), tuoi))
            {
                if (MessageBox.Show(string.Format("Giáo dân được chọn chưa đến tuổi được phép kết hôn (vì nhỏ hơn {0} tuồi.\r\nB ạn có chắc chọn giáo dân này không?", tuoi),
                                     "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            //kiem tra vo chong
            if (((int)row[GiaoDanConst.MaGiaoDan] != txtNguoiVo.MaGiaoDan) && Memory.KiemTraVoChong((int)row[GiaoDanConst.MaGiaoDan]) == 0)
            {
                e.Cancel = true;
                return;
            }
            //if ((bool)row[GiaoDanConst.QuaDoi] || (Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) &&
            //                           int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
            //{
            //    txtNguoiVo.TextBox.ForeColor = Color.Red;
            //    txtNguoiVo.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Strikeout);
            //}
            //else
            //{
            //    txtNguoiVo.TextBox.ForeColor = Color.Black;
            //    txtNguoiVo.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Regular);
            //}
        }

        private void txtNguoiChong_OnSelecting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoaded) return;
            DataRow row = (DataRow)sender;
            if (row[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NU.ToLower())
            {
                MessageBox.Show("Người chồng không thể là nữ!");
                e.Cancel = true;
                return;
            }
            //kiem tra tuoi hop le
            int tuoi = GxConstants.TUOI_HON_PHOI_NAM;
            if ((sender as DataRow)[GiaoDanConst.Phai].ToString().ToLower() == GxConstants.NU.ToLower())
            {
                tuoi = GxConstants.TUOI_HON_PHOI_NU;
            }
            if (Memory.KiemTraTuoiKhongHopLe((sender as DataRow)[GiaoDanConst.NgaySinh], DateTime.Now.ToString("dd/MM/yyyy"), tuoi))
            {
                if (MessageBox.Show(string.Format("Giáo dân được chọn chưa đến tuổi được phép kết hôn (vì nhỏ hơn {0} tuồi.\r\nB ạn có chắc chọn giáo dân này không?", tuoi),
                                     "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (((int)row[GiaoDanConst.MaGiaoDan] != txtNguoiChong.MaGiaoDan) && Memory.KiemTraVoChong((int)row[GiaoDanConst.MaGiaoDan]) == 0)
            {
                e.Cancel = true;
                return;
            }
            //if ((bool)row[GiaoDanConst.QuaDoi] || (Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) &&
            //                            int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
            //{
            //    txtNguoiChong.TextBox.ForeColor = Color.Red;
            //    txtNguoiChong.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Strikeout);
            //}
            //else
            //{
            //    txtNguoiChong.TextBox.ForeColor = Color.Black;
            //    txtNguoiChong.TextBox.Font = new Font(txtNguoiChong.Font, FontStyle.Regular);
            //}
        }

        private bool checkInput()
        {
            if (!Validator.IsNumber(txtMaHonPhoi.Text))
            {
                MessageBox.Show("Mã hôn phối phải được nhập số");
                txtMaHonPhoi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNguoiChong.Text.Trim()) || string.IsNullOrEmpty(txtNguoiVo.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập đầy đủ người nam và người nữ!");
                txtNguoiChong.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtTenHonPhoi.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập tên đôi hôn phối!");
                txtTenHonPhoi.Focus();
                return false;
            }

            return true;
        }

        private void AssignDataSource(DataRow row)
        {
            row[HonPhoiConst.MaHonPhoi] = int.Parse(txtMaHonPhoi.Text);
            row[HonPhoiConst.TenHonPhoi] = txtTenHonPhoi.Text.Trim(new char[] { '-' });
            if (txtSoHonPhoi.Text == "")
            {
                row[HonPhoiConst.SoHonPhoi] = DBNull.Value;
            }
            else
            {
                row[HonPhoiConst.SoHonPhoi] = txtSoHonPhoi.Text;
            }
            //row[HonPhoiConst.TenChong] = txtNguoiChong.Text;
            //row[HonPhoiConst.TenVo] = txtNguoiVo.Text;
            row[HonPhoiConst.NoiHonPhoi] = txtNoiHonPhoi.Text;
            row[HonPhoiConst.NgayHonPhoi] = dtNgayHonPhoi.Value;
            row[HonPhoiConst.LinhMucChung] = txtLinhMuc.Text;
            row[HonPhoiConst.NguoiChung1] = txtNguoiChung1.Text;
            row[HonPhoiConst.NguoiChung2] = txtNguoiChung2.Text;
            row[HonPhoiConst.CachThucHonPhoi] = cbCachThuc.Text;
            row[HonPhoiConst.GhiChu] = txtGhiChu.Text;
            if (Memory.IsNullOrEmpty(row[HonPhoiConst.MaNhanDang]))
            {
                row[HonPhoiConst.MaNhanDang] = Memory.GetGiaDinhKey(row[HonPhoiConst.MaHonPhoi]);
            }
            row[HonPhoiConst.UpdateDate] = Memory.Instance.GetServerDateTime();
        }

        public void AssignControlData()
        {
            GetData(MaHonPhoi);
        }

        public void AssignControlData(DataRow row)
        {
            id = (int)row[HonPhoiConst.MaHonPhoi];
            txtMaHonPhoi.Text = id.ToString();
            txtTenHonPhoi.Text = row[HonPhoiConst.TenHonPhoi].ToString();
            txtSoHonPhoi.Text = row[HonPhoiConst.SoHonPhoi].ToString();
            txtNoiHonPhoi.Text = row[HonPhoiConst.NoiHonPhoi].ToString();            
            dtNgayHonPhoi.Value = row[HonPhoiConst.NgayHonPhoi];
            txtLinhMuc.Text = row[HonPhoiConst.LinhMucChung].ToString();
            txtNguoiChung1.Text = row[HonPhoiConst.NguoiChung1].ToString();
            txtNguoiChung2.Text = row[HonPhoiConst.NguoiChung2].ToString();
            cbCachThuc.SelectedText = row[HonPhoiConst.CachThucHonPhoi].ToString();
            txtGhiChu.Text = row[HonPhoiConst.GhiChu].ToString();
            currentRow = row;
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            if (!updateHonPhoi())
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private bool updateHonPhoi()
        {
            try
            {
                if (!checkInput()) return false;
                DataTable tblHonPhoi = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_ID, new object[] { Id });
                if (Memory.ShowError())
                {
                    return false;
                }
                tblHonPhoi.TableName = HonPhoiConst.TableName;
                if (operation == GxOperation.ADD)
                {
                    dataReturn = tblHonPhoi.NewRow();
                    AssignDataSource(dataReturn);
                    tblHonPhoi.Rows.Add(dataReturn);
                }
                else
                {
                    if (tblHonPhoi.Rows.Count > 0)
                    {
                        dataReturn = tblHonPhoi.Rows[0];
                        AssignDataSource(dataReturn);
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(tblHonPhoi);
                //Update UpdateDate field
                foreach (DataRow rowTmp in tblHonPhoi.Rows)
                {
                    rowTmp[GiaoDanConst.UpdateDate] = Memory.Instance.GetServerDateTime();
                }
                //delete GiaoDanHonPhoi
                string deleteSql = "DELETE FROM GiaoDanHonPhoi WHERE MaHonPhoi=?";
                Memory.ExecuteSqlCommand(deleteSql, new object[] { id });
                if (Memory.ShowError())
                {
                    return false;
                }
                DataTable tblGiaoDanHonPhoi = Memory.GetTableStruct(GiaoDanHonPhoiConst.TableName);
                //them nguoi nam
                DataRow newRow = tblGiaoDanHonPhoi.NewRow();
                newRow[GiaoDanHonPhoiConst.MaHonPhoi] = id;
                newRow[GiaoDanHonPhoiConst.MaGiaoDan] = txtNguoiChong.MaGiaoDan;
                tblGiaoDanHonPhoi.Rows.Add(newRow);

                //them nguoi nu
                newRow = tblGiaoDanHonPhoi.NewRow();
                newRow[GiaoDanHonPhoiConst.MaHonPhoi] = id;
                newRow[GiaoDanHonPhoiConst.MaGiaoDan] = txtNguoiVo.MaGiaoDan;
                tblGiaoDanHonPhoi.Rows.Add(newRow);

                //add to data set
                ds.Tables.Add(tblGiaoDanHonPhoi);

                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblHonPhoi);
                if (Memory.ShowError())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmHonPhoi, gxCommand1_OnOK)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            if (this.Operation == GxOperation.ADD && (txtNguoiChong.MaGiaoDan > 0 || txtNguoiVo.MaGiaoDan > 0))
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn lưu đôi hôn phối này không?\r\nChọn [Yes] để lưu và đóng màn hình.\r\nChọn [No] để đóng màn hình và không lưu.\r\nChọn [Cancel] để quay trở lại màn hình này và xem lại.",
                    "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    gxCommand1_OnOK(sender, e);
                    return;
                }
                else if(rs == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                this.DialogResult = DialogResult.None;
            }
        }

        public DataTable GetHonPhoi(int maGiaoDan)
        {
            //select ma hon phoi
            DataTable tblCheck = Memory.GetData("SELECT MaHonPhoi FROM GiaoDanHonPhoi WHERE MaGiaoDan=?", new object[] { maGiaoDan });
            if (!Memory.ShowError() && tblCheck != null && tblCheck.Rows.Count > 0)
            {
                MaHonPhoi = (int)tblCheck.Rows[0][HonPhoiConst.MaHonPhoi];
                return GetData(MaHonPhoi);
            }
            this.operation = GxOperation.ADD;
            return null;
        }

        public DataTable GetData(int maHonPhoi)
        {
            //select vo chong
            DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_VOCHONG_THEO_HONPHOI, new object[] { maHonPhoi });
            if (!Memory.ShowError() && tblCheck != null && tblCheck.Rows.Count > 1)
            {
                txtNguoiChong.MaGiaoDan = (int)tblCheck.Rows[0][GiaoDanConst.MaGiaoDan];
                txtNguoiVo.MaGiaoDan = (int)tblCheck.Rows[1][GiaoDanConst.MaGiaoDan];
                //select thong tin hon phoi
                tblCheck = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_ID, new object[] { maHonPhoi });
                if (!Memory.ShowError() && tblCheck != null && tblCheck.Rows.Count > 0)
                {
                    AssignControlData(tblCheck.Rows[0]);
                    this.operation = GxOperation.EDIT;
                    return tblCheck;
                }
            }
            this.operation = GxOperation.ADD;
            return null;
        }
    }
}