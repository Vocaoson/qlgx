using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GxControl;
using GxGlobal;
using Janus.Windows.GridEX;

namespace GxControl
{
    public partial class GxHonPhoiGiaDinh : UserControl
    {
        public GxHonPhoiGiaDinh()
        {
            InitializeComponent();

            cbCachThuc.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            (dtNgayHonPhoi.editBase as GxDateInput).IsNullDate = true;            

            //cbCachThuc.Combo.Items.Add("");
            //cbCachThuc.Combo.Items.Add("Hợp pháp");
            //cbCachThuc.Combo.Items.Add("Hợp thức hóa");
            //cbCachThuc.Combo.Items.Add("Chuẩn");
            //cbCachThuc.Combo.Items.Add("Không theo phép đạo");
            //cbCachThuc.Combo.Items.Add("Không xác định");
            //cbCachThuc.Combo.SelectedIndex = 0;
        }

        private DataRow currentRow = null;

        public DataRow CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }

        private int maHonPhoi = -1;

        public int MaHonPhoi
        {
            get { return maHonPhoi; }
            set { maHonPhoi = value; }
        }

        private int nguoiVo = -1;

        public int NguoiVo
        {
            get { return nguoiVo; }
            set { nguoiVo = value; }
        }

        private int nguoiChong = -1;

        public int NguoiChong
        {
            get { return nguoiChong; }
            set { nguoiChong = value; }
        }

        private string tenHonPhoi = "";

        public string TenHonPhoi
        {
            get { return tenHonPhoi; }
            set { tenHonPhoi = value; }
        }

        private int soThuTu = 1;

        public int SoThuTu
        {
            get { return soThuTu; }
            set { soThuTu = value; }
        }

        private GxOperation operation = GxOperation.NONE;

        public GxOperation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public DataTable GetHonPhoi(int maNguoiVo, int maNguoiChong)
        {
            if (maNguoiChong < 1 || maNguoiVo < 1) return null;
            nguoiVo = maNguoiVo;
            nguoiChong = maNguoiChong;
            //DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_MAGIAODAN + " AND GiaoDanHonPhoi_1.MaGiaoDan = ?", new object[] { maNguoiVo, nguoiChong });
            DataTable tblCheck = GetHonPhoiTheoVoChong(maNguoiVo, maNguoiChong);
            if (!Memory.ShowError() && tblCheck != null && tblCheck.Rows.Count > 0)
            {
                int maHP = (int)tblCheck.Rows[0][HonPhoiConst.MaHonPhoi];
                AssignControlData(tblCheck.Rows[0]);
                operation = GxOperation.EDIT;
                return tblCheck;
            }
            ClearControlData();
            operation = GxOperation.ADD;
            return null;
        }

        public static DataTable GetHonPhoiTheoVoChong(int maNguoiVo, int maNguoiChong)
        {
            DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_MAGIAODAN + " AND GiaoDanHonPhoi_1.MaGiaoDan = ?", new object[] { maNguoiVo, maNguoiChong });
            return tblCheck;
        }

        public void AssignControlData(DataRow row)
        {
            txtSoHonPhoi.Text = row[HonPhoiConst.SoHonPhoi].ToString();
            txtNoiHonPhoi.Text = row[HonPhoiConst.NoiHonPhoi].ToString();
            dtNgayHonPhoi.Value = row[HonPhoiConst.NgayHonPhoi];
            txtLinhMuc.Text = row[HonPhoiConst.LinhMucChung].ToString();
            txtNguoiChung1.Text = row[HonPhoiConst.NguoiChung1].ToString();
            txtNguoiChung2.Text = row[HonPhoiConst.NguoiChung2].ToString();
            cbCachThuc.SelectedText = row[HonPhoiConst.CachThucHonPhoi].ToString();
            txtGhiChu.Text = row[HonPhoiConst.GhiChu].ToString();
            maHonPhoi = (int)row[HonPhoiConst.MaHonPhoi];
            //soThuTu = (int)row[HonPhoiConst.SoThuTu];
            tenHonPhoi = row[HonPhoiConst.TenHonPhoi].ToString();
            currentRow = row;
        }

        public void ClearControlData()
        {
            txtSoHonPhoi.Text = "";
            txtNoiHonPhoi.Text = "";
            dtNgayHonPhoi.Value = DBNull.Value;
            txtLinhMuc.Text = "";
            txtNguoiChung1.Text = "";
            txtNguoiChung2.Text = "";
            cbCachThuc.SelectedIndex = 0;
            soThuTu = 1;
            currentRow = null;
        }

        private void AssignDataSource(DataRow row)
        {
            row[HonPhoiConst.MaHonPhoi] = maHonPhoi;
            row[HonPhoiConst.TenHonPhoi] = tenHonPhoi.Trim(new char[] { '-' });
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
            //row[HonPhoiConst.SoThuTu] = SoThuTu;
            if (Memory.IsNullOrEmpty(row[HonPhoiConst.MaNhanDang]))
            {
                row[HonPhoiConst.MaNhanDang] = Memory.GetGiaDinhKey(row[HonPhoiConst.MaHonPhoi]);
            }
            row[HonPhoiConst.UpdateDate] = Memory.Instance.GetServerDateTime();
        }

        public bool UpdateHonPhoi()
        {
            try
            {
                if (checkInput())
                {
                    //check ton tai roi
                    DataTable tblHonPhoi = GxHonPhoi.HonPhoiExists(NguoiChong, NguoiVo);
                    if (tblHonPhoi != null && tblHonPhoi.Rows.Count > 0)
                    {
                        operation = GxOperation.EDIT;
                        maHonPhoi = (int)tblHonPhoi.Rows[0][HonPhoiConst.MaHonPhoi];
                    }
                    else
                    {
                        tblHonPhoi = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_ID, new object[] { maHonPhoi });
                        if (Memory.ShowError() || tblHonPhoi == null)
                        {
                            return false;
                        }
                        if (tblHonPhoi.Rows.Count == 0)
                        {
                            maHonPhoi = Memory.Instance.GetNextId(HonPhoiConst.TableName, HonPhoiConst.MaHonPhoi, false);
                            operation = GxOperation.ADD;
                        }
                    }
                    tblHonPhoi.TableName = HonPhoiConst.TableName;
                    DataRow dataReturn = null;
                    if (operation == GxOperation.ADD)
                    {
                        dataReturn = tblHonPhoi.NewRow();
                        AssignDataSource(dataReturn);
                        tblHonPhoi.Rows.Add(dataReturn);
                    }
                    else if (operation == GxOperation.EDIT)
                    {
                        if (tblHonPhoi.Rows.Count > 0)
                        {
                            dataReturn = tblHonPhoi.Rows[0];
                            AssignDataSource(dataReturn);
                        }
                    }
                    else
                    {
                        return false;
                    }
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblHonPhoi);
                    //Update UpdateDate field
                    foreach (DataRow rowTmp in tblHonPhoi.Rows)
                    {
                        rowTmp[GiaoDanConst.UpdateDate] = Memory.Instance.GetServerDateTime();
                    }
                    //delete GiaoDanHonPhoi
                    if (operation == GxOperation.EDIT)
                    {
                        string deleteSql = "DELETE FROM GiaoDanHonPhoi WHERE MaHonPhoi=?";
                        Memory.ExecuteSqlCommand(deleteSql, new object[] { maHonPhoi });
                        if (Memory.ShowError())
                        {
                            return false;
                        }
                    }
                    DataTable tblGiaoDanHonPhoi = Memory.GetTableStruct(GiaoDanHonPhoiConst.TableName);
                    //them nguoi nam
                    DataRow newRow = tblGiaoDanHonPhoi.NewRow();
                    newRow[GiaoDanHonPhoiConst.MaHonPhoi] = maHonPhoi;
                    newRow[GiaoDanHonPhoiConst.MaGiaoDan] = NguoiVo;
                    newRow[GiaoDanHonPhoiConst.SoThuTu] = GxHonPhoi.GetNextSoThuTu(NguoiVo);
                    tblGiaoDanHonPhoi.Rows.Add(newRow);

                    //them nguoi nu
                    newRow = tblGiaoDanHonPhoi.NewRow();
                    newRow[GiaoDanHonPhoiConst.MaHonPhoi] = maHonPhoi;
                    newRow[GiaoDanHonPhoiConst.MaGiaoDan] = NguoiChong;
                    newRow[GiaoDanHonPhoiConst.SoThuTu] = GxHonPhoi.GetNextSoThuTu(NguoiChong);
                    tblGiaoDanHonPhoi.Rows.Add(newRow);

                    //add to data set
                    ds.Tables.Add(tblGiaoDanHonPhoi);

                    Memory.UpdateDataSet(ds);
                    ds.Tables.Remove(tblHonPhoi);
                    if (Memory.ShowError())
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxHonPhoiGiaDinh, UpdateHonPhoi)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool checkInput()
        {
            bool result = true;
            if (Memory.IsNullOrEmpty(txtSoHonPhoi.Text.Trim()) &&
                Memory.IsNullOrEmpty(dtNgayHonPhoi.Value) &&
                Memory.IsNullOrEmpty(txtNoiHonPhoi.Text.Trim()) &&
                Memory.IsNullOrEmpty(txtLinhMuc.Text.Trim()) &&
                Memory.IsNullOrEmpty(txtNguoiChung1.Text.Trim()) &&
                Memory.IsNullOrEmpty(txtNguoiChung2.Text.Trim()) &&
                Memory.IsNullOrEmpty(cbCachThuc.Text) &&
                Memory.IsNullOrEmpty(txtGhiChu.Text))
            {
                if (operation == GxOperation.EDIT)
                {
                    MessageBox.Show("Hãy nhập ít nhất một thông tin hôn phối");
                }
                result = false;
            }
            else if (NguoiChong < 1 || NguoiVo < 1)
            {
                MessageBox.Show("Không thể lưu thông tin hôn phối vì không đủ thông tin người nam và người nữ!");
                result = false;
            }

            return result;
        }
    }
}
