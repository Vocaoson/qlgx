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
    public partial class GxTanHien : UserControl
    {
        public GxTanHien()
        {
            InitializeComponent();

            cbChucVu.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChucVu.Combo.Items.Add("");
            
            cbChucVu.Combo.Items.Add("Tu sĩ");
            cbChucVu.Combo.Items.Add("Chủng sinh");
            cbChucVu.Combo.Items.Add("Phó tế");
            cbChucVu.Combo.Items.Add("Linh mục");
            cbChucVu.Combo.Items.Add("Giám mục");
            cbChucVu.Combo.Items.Add("Khấn trọn");
            cbChucVu.Combo.Items.Add("Khác");

            (dtNgayBatDau.editBase as GxDateInput).IsNullDate = true;            
        }

        private DataRow giaoDanRow = null;

        public DataRow GiaoDanRow
        {
            get { return giaoDanRow; }
            set { giaoDanRow = value; }
        }

        private DataRow currentRow = null;

        public DataRow CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }

        private int maTanHien = -1;

        public int MaTanHien
        {
            get { return maTanHien; }
            set { maTanHien = value; }
        }

        private int maGiaoDan = -1;

        public int MaGiaoDan
        {
            get { return maGiaoDan; }
            set { maGiaoDan = value; }
        }

        private GxOperation operation = GxOperation.NONE;

        public GxOperation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public DataTable GetData(int maGD)
        {
            maGiaoDan = maGD;
            DataTable tblTanHien = Memory.GetData("SELECT * FROM TanHien WHERE MaGiaoDan=" + maGiaoDan.ToString());
            if (!Memory.ShowError() && tblTanHien != null)
            {
                tblTanHien.TableName = TanHienConst.TableName;
                return tblTanHien;
            }
           return null;
        }

        public void AssignControlData()
        {
            DataTable tblTanHien = GetData(maGiaoDan);
            if (tblTanHien != null)
            {
                if (tblTanHien.Rows.Count > 0)
                {
                    AssignControlData(tblTanHien.Rows[0]);
                    operation = GxOperation.EDIT;
                }
                else
                {
                    operation = GxOperation.ADD;
                    maTanHien = Memory.Instance.GetNextId(TanHienConst.TableName, TanHienConst.MaTanHien, false);
                }
            }
        }

        public void AssignControlData(DataRow row)
        {
            maTanHien = (int)row[TanHienConst.MaTanHien];
            maGiaoDan = (int)row[TanHienConst.MaGiaoDan];
            txtDongTu.Text = row[TanHienConst.DongTu].ToString();
            txtGhiChu.Text = row[TanHienConst.GhiChu].ToString();
            txtNoiPhucVu.Text = row[TanHienConst.NoiPhucVu].ToString();
            txtNoiTu.Text = row[TanHienConst.NoiTu].ToString();
            cbChucVu.SelectedText = row[TanHienConst.ChucVu].ToString();
            dtNgayBatDau.Value = row[TanHienConst.NgayBatDau];
            txtDiaChiPhucVu.Text = row[TanHienConst.DiaChiPhucVu].ToString();
            txtDienThoaiPhucVu.Text = row[TanHienConst.DienThoaiPhucVu].ToString();
            txtEmailPhucVu.Text = row[TanHienConst.EmailPhucVu].ToString();
            chkHoiTuc.Checked = (bool)row[TanHienConst.DaHoiTuc];
            //Them sau
            dtNgayVaoNhaTap.Value = row[TanHienConst.NgayVaoNhaTap];
            dtNgayVaoNhaThu.Value = row[TanHienConst.NgayVaoNhaThu];
            dtNgayVaoDaiChungVien.Value = row[TanHienConst.NgayVaoDCV];
            dtNgayKhanLanDau.Value = row[TanHienConst.NgayVaoKhanLanDau];
            dtNgayKhanVinhVien.Value = row[TanHienConst.NgayVaoKhanTronDoi];
            dtNgayPhoTe.Value = row[TanHienConst.NgayPhoTe];
            dtNgayThuPhongLM.Value = row[TanHienConst.NgayThuPhongLM];
            dtNgayBonMang.Value = row[TanHienConst.NgayBonMang];

            currentRow = row;
        }

        private void AssignDataSource(DataRow row)
        {
            row[TanHienConst.MaTanHien] = maTanHien;
            row[TanHienConst.MaGiaoDan] = maGiaoDan;
            row[TanHienConst.DongTu] = txtDongTu.Text;
            row[TanHienConst.GhiChu] = txtGhiChu.Text;
            row[TanHienConst.NoiPhucVu] = txtNoiPhucVu.Text;
            row[TanHienConst.NoiTu] = txtNoiTu.Text;
            row[TanHienConst.ChucVu] = cbChucVu.Text;
            row[TanHienConst.NgayBatDau] = dtNgayBatDau.Value;
            row[TanHienConst.DiaChiPhucVu] = txtDiaChiPhucVu.Text;
            row[TanHienConst.DienThoaiPhucVu] = txtDienThoaiPhucVu.Text;
            row[TanHienConst.EmailPhucVu] = txtEmailPhucVu.Text;
            row[TanHienConst.DaHoiTuc] = chkHoiTuc.Checked;
            //Them sau
            row[TanHienConst.NgayVaoNhaTap] = dtNgayVaoNhaTap.Value;
            row[TanHienConst.NgayVaoNhaThu] = dtNgayVaoNhaThu.Value;
            row[TanHienConst.NgayVaoDCV] = dtNgayVaoDaiChungVien.Value;
            row[TanHienConst.NgayVaoKhanLanDau] = dtNgayKhanLanDau.Value;
            row[TanHienConst.NgayVaoKhanTronDoi] = dtNgayKhanVinhVien.Value;
            row[TanHienConst.NgayPhoTe] = dtNgayPhoTe.Value;
            row[TanHienConst.NgayThuPhongLM] = dtNgayThuPhongLM.Value;
            row[TanHienConst.NgayBonMang] = dtNgayBonMang.Value;
        }

        public void Clear()
        {
            maTanHien = 0;
            txtDongTu.Text = "";
            txtGhiChu.Text = "";
            txtNoiPhucVu.Text = "";
            txtNoiTu.Text = "";
            cbChucVu.SelectedText = "";
            dtNgayBatDau.IsNullDate = true;
            dtNgayVaoNhaTap.IsNullDate = true;
            dtNgayVaoNhaThu.IsNullDate = true;
            dtNgayVaoDaiChungVien.IsNullDate = true;
            dtNgayKhanLanDau.IsNullDate = true;
            dtNgayKhanVinhVien.IsNullDate = true;
            dtNgayPhoTe.IsNullDate = true;
            dtNgayThuPhongLM.IsNullDate = true;
            dtNgayBonMang.IsNullDate = true;
            txtDiaChiPhucVu.Text = "";
            txtDienThoaiPhucVu.Text = "";
            txtEmailPhucVu.Text = "";
            chkHoiTuc.Checked = false;
        }

        public bool UpdateData()
        {
            try
            {
                if (!checkInput()) return false;
                DataTable tblTanHien = GetData(maGiaoDan);
                if (tblTanHien != null)
                {
                    if (tblTanHien.Rows.Count > 0)
                    {
                        if (isNull())
                        {
                            tblTanHien.Rows[0].Delete();
                        }
                        else
                        {
                            AssignDataSource(tblTanHien.Rows[0]);
                        }
                    }
                    else
                    {
                        if (!isNull())
                        {
                            DataRow newRow = tblTanHien.NewRow();
                            maTanHien = Memory.Instance.GetNextId(TanHienConst.TableName, TanHienConst.MaTanHien, false);
                            AssignDataSource(newRow);
                            tblTanHien.Rows.Add(newRow);
                        }
                        else
                        {
                            return true;
                        }
                    }
                    if (tblTanHien.Rows.Count > 0)
                    {
                        DataSet ds = new DataSet();
                        ds.Tables.Add(tblTanHien);
                        Memory.UpdateDataSet(ds);
                        if (!Memory.ShowError())
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Memory.ShowError("Cập nhật dữ liệu ơn gọi tận hiến không thành công");
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxTanHien, UpdateData)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool checkInput()
        {
            DataTable tblGiaoDan = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID, maGiaoDan);
            if (!Memory.ShowError() && tblGiaoDan != null && tblGiaoDan.Rows.Count > 0)
            {
                GiaoDanRow = tblGiaoDan.Rows[0];
                if (!isNull() && GiaoDanRow != null)
                {
                    if ((bool)GiaoDanRow[GiaoDanConst.DaCoGiaDinh] == true)
                    {
                        DialogResult rs = MessageBox.Show("Giáo dân này đã có gia đình. Bạn có chắc muốn nhập thông tin tận hiến cho giáo dân này không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.No)
                        {
                            Clear();
                            return false;
                        }
                        else if(rs == DialogResult.Cancel)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        
        private bool isNull()
        {
            if (Memory.IsNullOrEmpty(dtNgayBatDau.Value) &&
                Memory.IsNullOrEmpty(dtNgayVaoNhaTap.Value) &&
                Memory.IsNullOrEmpty(dtNgayVaoNhaThu.Value) &&
                Memory.IsNullOrEmpty(dtNgayVaoDaiChungVien.Value) &&
                Memory.IsNullOrEmpty(dtNgayKhanLanDau.Value) &&
                Memory.IsNullOrEmpty(dtNgayKhanVinhVien.Value) &&
                Memory.IsNullOrEmpty(dtNgayPhoTe.Value) &&
                Memory.IsNullOrEmpty(dtNgayThuPhongLM.Value) &&
                Memory.IsNullOrEmpty(dtNgayBonMang.Value) &&
                Memory.IsNullOrEmpty(txtNoiTu.Text.Trim()) &&
                Memory.IsNullOrEmpty(txtDongTu.Text.Trim()) &&
                Memory.IsNullOrEmpty(txtNoiPhucVu.Text.Trim()) &&
                Memory.IsNullOrEmpty(cbChucVu.Text) &&
                Memory.IsNullOrEmpty(txtDiaChiPhucVu.Text) &&
                Memory.IsNullOrEmpty(txtDienThoaiPhucVu.Text) &&
                Memory.IsNullOrEmpty(txtEmailPhucVu.Text) &&
                Memory.IsNullOrEmpty(txtGhiChu.Text) 
                )
            {

                return true;
            }
            return false;
        }
    }
}
