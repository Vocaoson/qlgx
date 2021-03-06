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
    public partial class GxHonPhoi : UserControl
    {
        bool isLoaded = false;
        public event EventHandler HonPhoiChanged;
        public event EventHandler LoadDataFinished;

        #region PROPERTY
        private int maHonPhoi = -1;
        public int MaHonPhoi
        {
            get { return maHonPhoi; }
            set
            {
                maHonPhoi = value;
                txtMaHonPhoi.Text = value.ToString();
            }
        }

        private int maGiaoDan = -1;

        public int MaGiaoDan
        {
            get { return maGiaoDan; }
            set
            {
                maGiaoDan = value;
                gxHonPhoiList1.MaGiaoDan = value;
            }
        }

        private string phai = "";

        public string Phai
        {
            get { return phai; }
            set
            {
                phai = value;
                gxHonPhoiList1.Phai = value;
            }
        }

        public int TongSoHonPhoi
        {
            get
            {
                if (gxHonPhoiList1.DataSource != null)
                {
                    return ((DataTable)gxHonPhoiList1.DataSource).Rows.Count;
                }
                return 0;
            }
        }

        private GxOperation operation = GxOperation.NONE;

        public GxOperation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        private DataRow currentRow = null;

        public DataRow CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }

        private DataRow dataReturn = null;

        public DataRow DataReturn
        {
            get { return dataReturn; }
            set { dataReturn = value; }
        }

        private bool isChanging = false;

        public bool IsChanging
        {
            get { return isChanging; }
            set { isChanging = value; }
        }
        #endregion

        public GxHonPhoi()
        {
            InitializeComponent();
            //gxAddEdit1.AddButton.Text = "&Thêm";
            //gxAddEdit1.DeleteButton.Text = "&Xóa";
            //gxAddEdit1.EditButton.Text = "&Xem-Sửa";
            //gxAddEdit1.SelectButton.Text = "&Chọn";
            //cbCachThuc.Combo.Items.Add("");
            //cbCachThuc.Combo.Items.Add("Hợp pháp");
            //cbCachThuc.Combo.Items.Add("Hợp thức hóa");
            //cbCachThuc.Combo.Items.Add("Chuẩn");
            //cbCachThuc.Combo.Items.Add("Không theo phép đạo");
            //cbCachThuc.Combo.Items.Add("Không xác định");
            cbCachThuc.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            (dtNgayHonPhoi.editBase as GxDateInput).IsNullDate = true;
            txtNguoiChong.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NAM.ToLower());
            txtNguoiVo.WhereSQL = string.Format(" AND Phai=\"{0}\" ", GxConstants.NU.ToLower());

            txtNguoiChong.EditControl.ReloadButton.Visible = false;
            txtNguoiVo.EditControl.ReloadButton.Visible = false;
            gxAddEdit1.SelectButton.Text = "&Lưu";
            gxAddEdit1.SelectButton.Enabled = false;
            gxAddEdit1.EditButton.Text = "&Sửa";
            txtSoThuTu.Text = "0";
            gxHonPhoiList1.LoadDataFinished += new EventHandler(gxHonPhoiList1_LoadDataFinished);
            //For linh muc control 
            Memory.Instance.SetMemory(GxConstants.LOAD_LINHMUC, null);
            
        }

        private void gxHonPhoiList1_LoadDataFinished(object sender, EventArgs e)
        {
            DataTable tbl = ((DataTable)gxHonPhoiList1.DataSource);
            if (tbl != null && tbl.Rows.Count > 0)
            {
                DataRow row = tbl.Rows[tbl.Rows.Count - 1];
                AssignControlData(row);
                try
                {
                    gxHonPhoiList1.Row = tbl.Rows.Count - 1;
                }
                catch { }

            }
            if (LoadDataFinished != null)
            {
                LoadDataFinished(sender, e);
            }
        }

        private void cbGiaoHo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GxHonPhoi_Load(object sender, EventArgs e)
        {
            //handle events
            this.txtNguoiChong.OnSelected += new System.EventHandler(this.txtNguoiChong_OnSelected);
            this.txtNguoiVo.OnSelected += new System.EventHandler(this.txtNguoiVo_OnSelected);
            gxAddEdit1.SelectButton.Visible = true;
            //if (phai.ToLower() == GxConstants.NAM.ToLower())
            //{
            //    txtNguoiChong.EditControl.Enabled = false;
            //}
            //else if (phai.ToLower() == GxConstants.NU.ToLower())
            //{
            //    txtNguoiVo.EditControl.Enabled = false;
            //}

            txtNguoiChong.EditControl.Enabled = false;
            txtNguoiVo.EditControl.Enabled = false;

            setReadOnlyControls(true);

            if (gxHonPhoiList1.RowCount > 0)
            {
                gxHonPhoiList1.Row = gxHonPhoiList1.RowCount - 1;
            }

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
            if (string.IsNullOrEmpty(txtNguoiChong.Text.Trim()) && txtNguoiChong.MaGiaoDan == -1
                || string.IsNullOrEmpty(txtNguoiVo.Text.Trim()) && txtNguoiVo.MaGiaoDan == -1)
            {
                MessageBox.Show("Hãy nhập đầy đủ người nam và người nữ!");
                txtNguoiChong.Focus();
                return false;
            }

            DataTable tblTanHien = Memory.GetData(SqlConstants.SELECT_TANHIEN_HIENTAI, maGiaoDan);
            if (!Memory.ShowError() && tblTanHien != null && tblTanHien.Rows.Count > 0)
            {
                Memory.ShowError("Giáo dân này đã đi tu và chưa hồi tục nên không thể lập hôn phối");
                return false;
            }

            //check ton tai roi
            DataTable tblHonPhoi = GxHonPhoi.HonPhoiExists(txtNguoiChong.MaGiaoDan, txtNguoiVo.MaGiaoDan);
            if (operation == GxOperation.ADD && tblHonPhoi != null && tblHonPhoi.Rows.Count > 0)
            {
                MessageBox.Show("Đã tồn tại hôn phối cho đôi bạn nhập!");
                txtNguoiChong.Focus();
                return false;
            }

            if (!Validator.IsNumber(txtSoThuTu.Text))
            {
                MessageBox.Show("Số thứ tự phải được nhập số", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoThuTu.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenHonPhoi.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập tên đôi hôn phối!");
                txtTenHonPhoi.Focus();
                return false;
            }

            DataRow rowNguoiChong = txtNguoiChong.CurrentRow;
            DataRow rowNguoiVo = txtNguoiVo.CurrentRow;
            
            if (!Memory.IsNullOrEmpty(dtNgayHonPhoi.Value))
            {
                DateTime dNgayHonPhoi = Memory.GetDateFromString(dtNgayHonPhoi.Value.ToString());
                if (rowNguoiChong != null && !Memory.IsNullOrEmpty(rowNguoiChong[GiaoDanConst.NgaySinh]))
                {
                    DateTime d1 = Memory.GetDateFromString(rowNguoiChong[GiaoDanConst.NgaySinh].ToString());
                    if (d1.CompareTo(dNgayHonPhoi) >= 0)
                    {
                        Memory.ShowError("Ngày hôn phối phải sau ngày sinh của người chồng");
                        return false;
                    }
                    if (dNgayHonPhoi.Year - d1.Year < GxConstants.TUOI_HON_PHOI_NAM)
                    {
                        if (MessageBox.Show("Người chồng chưa đủ tuổi kết hôn với ngày hôn phối. Bạn có chắc muốn tiếp tục chọn người này không?", "Xác nhận", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }

                if (rowNguoiVo != null && !Memory.IsNullOrEmpty(rowNguoiVo[GiaoDanConst.NgaySinh]))
                {
                    DateTime d1 = Memory.GetDateFromString(rowNguoiVo[GiaoDanConst.NgaySinh].ToString());
                    if (d1.CompareTo(dNgayHonPhoi) >= 0)
                    {
                        Memory.ShowError("Ngày hôn phối phải sau ngày sinh của người vợ");
                        return false;
                    }
                    if (dNgayHonPhoi.Year - d1.Year < GxConstants.TUOI_HON_PHOI_NU)
                    {
                        if (MessageBox.Show("Người vợ chưa đủ tuổi kết hôn so với ngày hôn phối. Bạn có chắc muốn tiếp tục chọn người này không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
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
            //row[HonPhoiConst.SoThuTu] = int.Parse(txtSoThuTu.Text);
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
            if (phai == GxConstants.NAM)
            {
                txtNguoiVo.MaGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
                txtNguoiChong.MaGiaoDan = maGiaoDan;
            }
            else
            {
                txtNguoiChong.MaGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
                txtNguoiVo.MaGiaoDan = maGiaoDan;
            }

            MaHonPhoi = (int)row[HonPhoiConst.MaHonPhoi];
            MaHonPhoi = maHonPhoi;
            txtTenHonPhoi.Text = row[HonPhoiConst.TenHonPhoi].ToString();
            txtSoHonPhoi.Text = row[HonPhoiConst.SoHonPhoi].ToString();
            txtNoiHonPhoi.Text = row[HonPhoiConst.NoiHonPhoi].ToString();            
            dtNgayHonPhoi.Value = row[HonPhoiConst.NgayHonPhoi];
            txtLinhMuc.Text = row[HonPhoiConst.LinhMucChung].ToString();
            txtNguoiChung1.Text = row[HonPhoiConst.NguoiChung1].ToString();
            txtNguoiChung2.Text = row[HonPhoiConst.NguoiChung2].ToString();
            cbCachThuc.SelectedText = row[HonPhoiConst.CachThucHonPhoi].ToString();
            txtGhiChu.Text = row[HonPhoiConst.GhiChu].ToString();
            txtSoThuTu.Text = row[GiaoDanHonPhoiConst.SoThuTu].ToString();

            //operation = GxOperation.EDIT;
            currentRow = row;
        }

        public bool UpdateHonPhoi()
        {
            try
            {
                if (!checkInput()) return false;
                DataTable tblHonPhoi = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_ID, new object[] { maHonPhoi });
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
                //select lai so thu tu cu
                DataTable tbl = Memory.GetData("SELECT * FROM GiaoDanHonPhoi WHERE MaHonPhoi=" + maHonPhoi.ToString());
                int sttNam = 1;
                int sttNu = 1;
                if (operation == GxOperation.EDIT)
                {
                    if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0)
                    {
                        DataRow[] rowCheckStt = null;
                        if (phai.ToLower() == GxConstants.NAM.ToLower())
                        {
                            sttNam = int.Parse(txtSoThuTu.Text);
                            rowCheckStt = tbl.Select("MaGiaoDan=" + txtNguoiVo.MaGiaoDan.ToString());
                            if (rowCheckStt != null && rowCheckStt.Length > 0)
                            {
                                sttNu = (int)rowCheckStt[0][GiaoDanHonPhoiConst.SoThuTu];
                            }
                        }
                        else
                        {
                            sttNu = int.Parse(txtSoThuTu.Text);
                            rowCheckStt = tbl.Select("MaGiaoDan=" + txtNguoiChong.MaGiaoDan.ToString());
                            if (rowCheckStt != null && rowCheckStt.Length > 0)
                            {
                                sttNam = (int)rowCheckStt[0][GiaoDanHonPhoiConst.SoThuTu];
                            }
                        }
                    }
                }
                else if (operation == GxOperation.ADD)
                {
                    sttNam = GetNextSoThuTu(txtNguoiChong.MaGiaoDan);
                    sttNu = GetNextSoThuTu(txtNguoiVo.MaGiaoDan);
                }

                //delete GiaoDanHonPhoi
                string deleteSql = "DELETE FROM GiaoDanHonPhoi WHERE MaHonPhoi=?";
                Memory.ExecuteSqlCommand(deleteSql, new object[] { maHonPhoi });
                if (Memory.ShowError())
                {
                    return false;
                }
                DataTable tblGiaoDanHonPhoi = Memory.GetTableStruct(GiaoDanHonPhoiConst.TableName);
                //them nguoi nam
                DataRow newRow = tblGiaoDanHonPhoi.NewRow();
                newRow[GiaoDanHonPhoiConst.MaHonPhoi] = maHonPhoi;
                newRow[GiaoDanHonPhoiConst.MaGiaoDan] = txtNguoiChong.MaGiaoDan;
                newRow[GiaoDanHonPhoiConst.SoThuTu] = sttNam;
                tblGiaoDanHonPhoi.Rows.Add(newRow);

                //them nguoi nu
                newRow = tblGiaoDanHonPhoi.NewRow();
                newRow[GiaoDanHonPhoiConst.MaHonPhoi] = maHonPhoi;
                newRow[GiaoDanHonPhoiConst.MaGiaoDan] = txtNguoiVo.MaGiaoDan;
                newRow[GiaoDanHonPhoiConst.SoThuTu] = sttNu;
                tblGiaoDanHonPhoi.Rows.Add(newRow);

                //add to data set
                ds.Tables.Add(tblGiaoDanHonPhoi);

                Memory.UpdateDataSet(ds);
                ds.Tables.Remove(tblHonPhoi);
                if (Memory.ShowError())
                {
                    return false;
                }

                Memory.ExecuteSqlCommand("UPDATE GiaoDan SET DaCoGiaDinh=TRUE WHERE MaGiaoDan=? OR ?", new object[] { txtNguoiChong.MaGiaoDan, txtNguoiVo.MaGiaoDan });
                if (Memory.ShowError())
                {
                    return false;
                }
               
                isChanging = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxHonPhoi, updateHonPhoi)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool LoadData()
        {
            bool rs = gxHonPhoiList1.LoadData();
            return rs;
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
            //this.operation = GxOperation.ADD;
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
                    //this.operation = GxOperation.EDIT;
                    return tblCheck;
                }
            }
            //this.operation = GxOperation.ADD;
            return null;
        }

        private void EnableEditControls(bool enabled)
        {
            if (this.Phai.ToLower() == GxConstants.NU.ToLower())
            {
                txtNguoiChong.EditControl.Enabled = enabled;
            }
            else
            {
                txtNguoiVo.EditControl.Enabled = enabled;
            }
            txtNguoiVo.ReadOnly = true;
            txtNguoiChong.ReadOnly = true;

            if (!enabled)
            {
                setReadOnlyControls(true);
                gxAddEdit1.SelectButton.Enabled = false;
                gxAddEdit1.AddButton.Enabled = true;
                DataTable tb = gxHonPhoiList1.DataSource as DataTable;
                if (tb != null && tb.Rows.Count > 0)
                {
                    gxAddEdit1.EditButton.Enabled = true;
                    gxAddEdit1.DeleteButton.Enabled = true;
                }
                operation = GxOperation.NONE;
                gxAddEdit1.AddButton.Text = "&Thêm";
                gxAddEdit1.EditButton.Text = "&Sửa";
                return;
            }
            //if (operation == GxOperation.ADD) txtMaHonPhoi.ReadOnly = false;
            setReadOnlyControls(false);
            gxAddEdit1.SelectButton.Enabled = true;
            gxAddEdit1.AddButton.Enabled = false;
            gxAddEdit1.EditButton.Enabled = false;
            gxAddEdit1.DeleteButton.Enabled = false;
            if (operation == GxOperation.ADD)
            {
                gxAddEdit1.AddButton.Enabled = true;
                gxAddEdit1.AddButton.Text = "&Thôi";
            }
            else if (operation == GxOperation.EDIT)
            {
                gxAddEdit1.EditButton.Enabled = true;
                gxAddEdit1.EditButton.Text = "&Thôi";
            }
        }

        private void cancelEdit()
        {
            if (operation == GxOperation.ADD || operation == GxOperation.EDIT)
            {
                EnableEditControls(false);
                gxAddEdit1.AddButton.Focus();
                if (gxHonPhoiList1.RowCount > 0)
                {
                    changeSelection();
                }
                else
                {
                    clearTexts();
                }
            }
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            if (operation == GxOperation.ADD)
            {
                cancelEdit();
                isChanging = false;
                return;
            }

            this.Operation = GxOperation.ADD;
            EnableEditControls(true);
            clearTexts();

            MaHonPhoi = Memory.Instance.GetNextId(HonPhoiConst.TableName, HonPhoiConst.MaHonPhoi, false);
            cbCachThuc.Combo.SelectedIndex = 0;

            //txtMaHonPhoi.Text = maHonPhoi.ToString();

            if (phai == GxConstants.NAM)
            {
                txtNguoiChong.MaGiaoDan = maGiaoDan;
                txtNguoiVo.MaGiaoDan = -1;
            }
            else
            {
                txtNguoiVo.MaGiaoDan = maGiaoDan;
                txtNguoiChong.MaGiaoDan = -1;
            }

            txtNguoiVo.ReadOnly = true;
            txtNguoiChong.ReadOnly = true;

            txtSoThuTu.Text = GetNextSoThuTu(maGiaoDan).ToString();
            txtNguoiChong.Focus();
            isChanging = true;
        }

        public static int GetNextSoThuTu(int maGiaoDan)
        {
            string sql = "SELECT Max(SoThuTu) FROM GiaoDanHonPhoi WHERE MaGiaoDan=?";
            DataTable tbl = Memory.GetData(sql, new object[] { maGiaoDan });
            if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0 && !Memory.IsNullOrEmpty(tbl.Rows[0][0]))
            {
                return (int)tbl.Rows[0][0] + 1;
            }
            return 1;
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            if (operation == GxOperation.EDIT)
            {
                cancelEdit();
                isChanging = false;
                return;
            }

            this.Operation = GxOperation.EDIT;
            EnableEditControls(true);
            txtTenHonPhoi.Focus();
            txtNguoiVo.ReadOnly = true;
            txtNguoiChong.ReadOnly = true;
            isChanging = true;
        }

        private void gxAddEdit1_UpdateClick(object sender, EventArgs e)
        {
            if (!UpdateHonPhoi())
            {
                return;
            }
            isChanging = false;
            gxHonPhoiList1.LoadData();
            EnableEditControls(false);
            gxAddEdit1.AddButton.Focus();
            gxAddEdit1.DeleteButton.Enabled = true;
            gxAddEdit1.EditButton.Enabled = true;
            if (HonPhoiChanged != null)
            {
                HonPhoiChanged(this, e);
            }
            txtNguoiVo.ReadOnly = true;
            txtNguoiChong.ReadOnly = true;
        }

        private void changeSelection()
        {
            if (gxHonPhoiList1.CurrentRow != null && (gxHonPhoiList1.CurrentRow.DataRow as DataRowView) != null)
            {
                DataRow row = (gxHonPhoiList1.CurrentRow.DataRow as DataRowView).Row;
                AssignControlData(row);
                gxAddEdit1.EditButton.Enabled = true;
                gxAddEdit1.DeleteButton.Enabled = true;
            }
        }

        private void setReadOnlyControls(bool readOnly)
        {
            foreach(Control ctl in tableLayoutPanel1.Controls)
            {
                if (ctl is GxTextField)
                {
                    (ctl as GxTextField).ReadOnly = readOnly;
                }
                else if (ctl is GxComboField)
                {
                    (ctl as GxComboField).combo.Enabled = !readOnly;
                }
                else if (ctl is GxDateField)
                {
                    (ctl as GxDateField).Enabled = !readOnly;
                }
                else if (ctl is GxCachThucHonPhoi)
                {
                    (ctl as GxCachThucHonPhoi).combo.AllowDrop = !readOnly;
                }
            }
            txtGhiChu.ReadOnly = readOnly;
        }

        private void clearTexts()
        {
            foreach (Control ctl in tableLayoutPanel1.Controls)
            {
                if (ctl is GxBaseField)
                {
                    ctl.Text = "";
                }
            }
            dtNgayHonPhoi.Value = DBNull.Value;
            txtGhiChu.Text = "";
        }

        private void txtSoThuTu_Load(object sender, EventArgs e)
        {
            gxHonPhoiList1.FormatGrid();
        }

        private void gxHonPhoiList1_SelectionChanged(object sender, EventArgs e)
        {
            if (gxHonPhoiList1.Row > -1 && gxHonPhoiList1.Col > -1)
            {
                changeSelection();
            }
        }

        public static DataTable HonPhoiExists(int maNguoiNam, int maNguoiNu)
        {
            DataTable tblCheck = Memory.GetData(SqlConstants.SELECT_HONPHOI_THEO_MAGIAODAN + " AND GiaoDanHonPhoi_1.MaGiaoDan = ?", new object[] { maNguoiNam, maNguoiNu });
            if (!Memory.ShowError() && tblCheck != null && tblCheck.Rows.Count > 0)
            {
                return tblCheck;
            }
            return null;

        }

        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa hôn phối được chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Memory.ExecuteSqlCommand("DELETE FROM HonPhoi WHERE MaHonPhoi=?", maHonPhoi);
            if (Memory.ShowError())
            {
                return;
            }
            Memory.ExecuteSqlCommand("DELETE FROM GiaoDanHonPhoi WHERE MaHonPhoi=?", maHonPhoi);
            if (!Memory.ShowError())
            {
                if (gxHonPhoiList1.CurrentRow != null)
                {
                    DataRow currRow = (gxHonPhoiList1.CurrentRow.DataRow as DataRowView).Row;
                    //clear control
                    DataRow newRow = currRow.Table.NewRow();
                    newRow[GiaoDanConst.MaGiaoDan] = -1;
                    newRow[HonPhoiConst.MaHonPhoi] = -1;
                    AssignControlData(newRow);

                    txtNguoiChong.MaGiaoDan = -1;
                    txtNguoiVo.MaGiaoDan = -1;
                    txtNguoiChong.Text = "";
                    txtNguoiVo.Text = "";
                    
                    gxHonPhoiList1.CurrentRow.Delete();

                }
            }
        }

        private void gxHonPhoiList1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gxHonPhoiList1.CurrentRow != null && (gxHonPhoiList1.CurrentRow.DataRow as DataRowView) != null)
            {
                if (gxHonPhoiList1.Row > -1 && gxHonPhoiList1.Col > -1)
                {
                    changeSelection();
                }
            }
        }
    }
}