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
    public partial class frmGiaoHo : frmBase
    {
        private int maGiaoHoCha = -1;

        public int MaGiaoHoCha
        {
            get { return maGiaoHoCha; }
            set { maGiaoHoCha = value; }
        }
        public frmGiaoHo()
        {
            InitializeComponent();

            this.HelpKey = "giao_ho";
            //gxAddEdit1.AddButton.Text = "&Thêm";
            gxAddEdit1.EditButton.Text = "&Sửa";
            gxAddEdit1.DeleteButton.Text = "&Xóa";
            gxAddEdit1.SelectButton.Text = "&Lưu";
            //gxAddEdit1.FindButton.Text = "Tìm &kiếm";
            gxAddEdit1.SelectButton.Enabled = false;

            gxAddEdit2.EditButton.Visible = true;
            gxAddEdit2.EditButton.Text = "Danh sách giáo khu";
            gxAddEdit2.AddButton.Visible = false;
            gxAddEdit2.DeleteButton.Visible = false;
            gxAddEdit2.SelectButton.Visible = false;

            gxAddEdit2.EditButton.Click += new EventHandler(EditButton_Click);

            gxGiaoHoList1.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.EntireRow;
            gxGiaoHoList1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            gxGiaoHoList1.KeyDown += new KeyEventHandler(gxGiaoHoList1_KeyDown);
            this.AcceptButton = gxAddEdit1.AddButton;
        }

        void FindButton_Click(object sender, EventArgs e)
        {
            frmFilter frm = new frmFilter();
            Dictionary<object, object> dic = new Dictionary<object, object>();
            dic.Add(GiaoHoConst.TenGiaoHo, "");
            frm.GrdData = this.gxGiaoHoList1;
            frm.FilterParameter = dic;
            frm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //EditGiaDinhRow();
            EditGiaoHoRow();
        }

        private void gxGiaoHoList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gxAddEdit1_DeleteClick(sender, e);
            }
        }

        private void frmGiaoHo_Load(object sender, EventArgs e)
        {
            if (this.operation == GxOperation.ADD)
                id = Memory.Instance.GetNextId(GiaoHoConst.TableName, GiaoHoConst.MaGiaoHo, true);
            this.operation = GxOperation.NONE;
            txtMaGiaoHo.Text = id.ToString();
            if (maGiaoHoCha != -1)
            {
                this.Text = "Giáo khu";
                uiGroupBox1.Text = "Tên giáo khu";
                uiGroupBox2.Text = "Danh sách giáo khu";
                txtTenGiaoHo.Label = "Tên giáo khu";
                gxAddEdit2.Visible = false;
                gxGiaoHoList1.QueryString += " AND MaGiaoHoCha=" + maGiaoHoCha.ToString();
            }
            else
            {
                gxGiaoHoList1.QueryString += " AND (MaGiaoHoCha IS NULL OR MaGiaoHoCha <= 0)";
            }
            gxGiaoHoList1.MaGiaoHoCha = maGiaoHoCha;
            gxGiaoHoList1.LoadData();
            gxGiaoHoList1.FormatGrid();
            gxCommand1.OKButton.Visible = false;

            gxAddEdit1.AddButton.Focus();

            txtTenGiaoHo.ReadOnly = true;
            txtMaGiaoHo.ReadOnly = true;
        }

        private bool checkInput()
        {
            if (!Validator.IsNumber(txtMaGiaoHo.Text))
            {
                MessageBox.Show("Mã gia đình phải được nhập số");
                txtMaGiaoHo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenGiaoHo.Text.Trim()))
            {
                MessageBox.Show("Hãy nhập tên giáo họ!");
                txtTenGiaoHo.Focus();
                return false;
            }

            //check ma giao ho
            if (operation == GxOperation.ADD && Memory.IsExistedData(SqlConstants.SELECT_GIAOHO + " AND MaGiaoHo =" + txtMaGiaoHo.Text, null))
            {
                MessageBox.Show("Mã giáo họ này đã có. Hãy nhập mã khác");
                txtMaGiaoHo.Focus();
                return false;
            }

            if (Operation == GxOperation.ADD && 
                (MaGiaoHoCha == -1 && Memory.IsExistedData(SqlConstants.SELECT_GIAOHO + " AND TenGiaoHo = ? AND (MaGiaoHoCha=-1 OR MaGiaoHoCha IS NULL)", new object[] { txtTenGiaoHo.Text }))
                || MaGiaoHoCha != -1 && MaGiaoHoCha == -1 && Memory.IsExistedData(SqlConstants.SELECT_GIAOHO + " AND TenGiaoHo = ? AND MaGiaoHoCha= ?", new object[] { txtTenGiaoHo.Text, MaGiaoHoCha }))
            {
                MessageBox.Show("Tên giáo họ này đã có. Hãy nhập tên khác");
                txtTenGiaoHo.Focus();
                return false;
            }

            return true; ;
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            if (operation == GxOperation.ADD)
            {
                cancelEdit();
                return;
            }

            this.Operation = GxOperation.ADD;
            EnableEditControls(true);
            txtMaGiaoHo.Text = Memory.Instance.GetNextId(GiaoHoConst.TableName, GiaoHoConst.MaGiaoHo, true).ToString();
            txtTenGiaoHo.Text = "";
            txtTenGiaoHo.Focus();
        }


        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            if (operation == GxOperation.EDIT)
            {
                cancelEdit();
                return;
            }

            this.Operation = GxOperation.EDIT;
            EnableEditControls(true);
            txtTenGiaoHo.Focus();
        }

        private void gxAddEdit1_UpdateClick(object sender, EventArgs e)
        {
            if (!UpdateData()) return;
            EnableEditControls(false);
            gxAddEdit1.AddButton.Focus();
        }

        private void EnableEditControls(bool enabled)
        {
            if (!enabled)
            {
                txtMaGiaoHo.ReadOnly = true;
                txtTenGiaoHo.ReadOnly = true;
                gxAddEdit1.SelectButton.Enabled = false;
                gxAddEdit1.AddButton.Enabled = true;
                DataTable tb = gxGiaoHoList1.DataSource as DataTable;
                if (tb != null && tb.Rows.Count > 0)
                {
                    gxAddEdit1.EditButton.Enabled = true;
                    gxAddEdit1.DeleteButton.Enabled = true;
                }
                operation = GxOperation.NONE;
                gxAddEdit1.AddButton.Text = "&Thêm";
                gxAddEdit1.EditButton.Text = "&Sửa";
                this.AcceptButton = gxAddEdit1.AddButton;
                return;
            }
            if(operation == GxOperation.ADD) txtMaGiaoHo.ReadOnly = false;
            txtTenGiaoHo.ReadOnly = false;
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
            this.AcceptButton = gxAddEdit1.SelectButton;
        }

        private bool UpdateData()
        {
            if (!checkInput()) return false;
            if (this.Operation == GxOperation.ADD)
            {
                DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAOHO + " AND MaGiaoHo =" + txtMaGiaoHo.Text);
                if (tbl != null)
                {
                    tbl.TableName = GiaoHoConst.TableName;
                    DataRow row = tbl.NewRow();
                    row[GiaoHoConst.MaGiaoHo] = txtMaGiaoHo.Text;
                    row[GiaoHoConst.TenGiaoHo] = txtTenGiaoHo.Text;
                    if (maGiaoHoCha != -1)
                    {
                        row[GiaoHoConst.MaGiaoHoCha] = maGiaoHoCha;
                    }
                    if (Memory.IsNullOrEmpty(row[GiaoHoConst.MaNhanDang]))
                    {
                        row[GiaoHoConst.MaNhanDang] = Memory.GetGiaoHoKey(row[GiaoHoConst.MaGiaoHo]);
                    }
                    row[GiaoHoConst.UpdateDate] = Memory.Instance.GetServerDateTime();
                    tbl.Rows.Add(row);
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tbl);
                    Memory.UpdateDataSet(ds);
                    if (!Memory.ShowError())
                    {
                        row.AcceptChanges();
                        DataTable tbl1 = (DataTable)gxGiaoHoList1.DataSource;
                        if (tbl1 != null)
                        {
                            tbl1.ImportRow(row);
                        }
                        else
                        {
                            gxGiaoHoList1.DataSource = tbl;
                        }
                        gxGiaoHoList1.Row = gxGiaoHoList1.RowCount - 1;
                        return true;
                    }
                }
            }
            else
            {
                if (gxGiaoHoList1.CurrentRow != null && (gxGiaoHoList1.CurrentRow.DataRow as DataRowView) != null)
                {
                    string ma = txtMaGiaoHo.Text;
                    string ten = txtTenGiaoHo.Text;
                    //DataTable tbl = gxGiaoHoList1.DataSource as DataTable;
                    DataRow row = (gxGiaoHoList1.CurrentRow.DataRow as DataRowView).Row;
                    row[GiaoHoConst.TenGiaoHo] = ten;
                    //row[GiaoHoConst.MaGiaoHo] = ma;
                    //row[GiaoHoConst.UpdateDate] = Memory.Instance.GetNow();

                    Memory.ExecuteSqlCommand(SqlConstants.UPDATE_GIAOHO, new object[] { txtTenGiaoHo.Text, txtMaGiaoHo.Text });

                    if (!Memory.ShowError())
                    {
                        row.AcceptChanges();
                        MessageBox.Show("Giáo họ đã được cập nhật!");
                        return true;
                    }
                    row.RejectChanges();
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra giáo họ có ít nhất 1 gia đình hoặc 1 giáo dân
        /// </summary>
        /// <param name="maGiaHo">Mã giáo họ cần kiểm tra</param>
        /// <returns>True nếu giáo họ có ít nhất 1 gia đình hoặc 1 giáo dân, False cho ngược lại</returns>
        private bool hasGiaDinh(int maGiaHo)
        {
            #region Check Gia dinh
            DataTable tbl = Memory.GetData(SqlConstants.SELECT_COUNT_GIADINH_THUOC_GIAOHO, new object[] { maGiaHo, maGiaHo });
            if (tbl != null && tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0][0] != null && Validator.IsNumber(tbl.Rows[0][0].ToString())
                    && int.Parse(tbl.Rows[0][0].ToString()) > 0)
                {
                    return true;
                }
            }
            #endregion

            #region Check giao dan
            tbl = Memory.GetData(SqlConstants.SELECT_COUNT_GIAODAN_THUOC_GIAOHO, new object[] { maGiaHo, maGiaHo });
            if (tbl != null && tbl.Rows.Count > 0)
            {
                if (tbl.Rows[0][0] != null && Validator.IsNumber(tbl.Rows[0][0].ToString())
                    && int.Parse(tbl.Rows[0][0].ToString()) > 0)
                {
                    return true;
                }
            }
            #endregion
            return false;
        }

        /// <summary>
        /// Dùng cho trường hợp delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (gxGiaoHoList1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Khi 1 giáo họ bị xóa, tất cả các thông tin gia đình, giáo dân liên quan đến giáo  họ đó đều sẽ bị xóa khỏi hệ thống.\r\n" + 
                                    "Bạn có chắc muốn xóa các giáo họ được chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                DataTable tblSource = gxGiaoHoList1.DataSource as DataTable;
                DataTable tbl = (gxGiaoHoList1.DataSource as DataTable).Clone();
                tbl.TableName = GiaoHoConst.TableName;
                List<int> lstSelectionPositions = new List<int>();
  
                #region Xoa cac giao ho duoc chon - start
                for (int i = 0; i < gxGiaoHoList1.SelectedItems.Count; i++)
                {
                    DataRow row = (gxGiaoHoList1.SelectedItems[i].GetRow().DataRow as DataRowView).Row;
                    lstSelectionPositions.Add(gxGiaoHoList1.SelectedItems[i].Position);
                    tbl.ImportRow(row);                    
                }
                
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string sql = "";
                    //if (!hasGiaDinh((int)tbl.Rows[i][GiaoHoConst.MaGiaoHo]))
                    //{
                    //    if (MessageBox.Show(string.Format("Bạn chắc chắn muốn xóa giáo họ [{0}]?", tbl.Rows[i][GiaoHoConst.TenGiaoHo]), "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No)
                    //    {
                    //        continue;
                    //    }

                    //    sql = SqlConstants.DELETE_GIAOHO_KHONG_CO_GIADINH;
                    //}
                    //else
                    //{
                    //    MessageBox.Show(string.Format("Giáo họ [{0}] đã được nhập thông tin gia đình nên không thể xóa",
                    //                        tbl.Rows[i][GiaoHoConst.TenGiaoHo]), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //    //sql = SqlConstants.DELETE_GIAOHO_CO_GIADINH;
                    //}

                    //Delete ThanhVienGiaDinh
                    //Delete giao dan
                    sql = @"DELETE FROM ThanhVienGiaDinh
                                     WHERE MaGiaoDan IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((ThanhVienGiaDinh INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = ThanhVienGiaDinh.MaGiaoDan)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?) ";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });
                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //delete gia dinh
                    sql = @"DELETE FROM ThanhVienGiaDinh
                                     WHERE MaGiaDinh IN (SELECT DISTINCT GiaDinh.MaGiaDinh FROM ((ThanhVienGiaDinh INNER JOIN GiaDinh ON GiaDinh.MaGiaDinh = ThanhVienGiaDinh.MaGiaDinh)
                                                                INNER JOIN GiaoHo ON GiaDinh.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?) ";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });
                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //Delete GiaoDanHonPhoi
                    sql = @"DELETE FROM GiaoDanHonPhoi
                                     WHERE MaGiaoDan IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((GiaoDanHonPhoi INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = GiaoDanHonPhoi.MaGiaoDan)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?) ";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });

                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //Delete BiTichChiTiet
                    sql = @"DELETE FROM BiTichChiTiet
                                     WHERE MaGiaoDan IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((BiTichChiTiet INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = BiTichChiTiet.MaGiaoDan)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?) ";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });

                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //Delete TanHien
                    sql = @"DELETE FROM TanHien
                                     WHERE MaGiaoDan IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((TanHien INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = TanHien.MaGiaoDan)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?) ";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });

                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //Delete ChuyenXu
                    sql = @"DELETE FROM ChuyenXu
                                     WHERE MaGiaoDan IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((ChuyenXu INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = ChuyenXu.MaGiaoDan)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?) ";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });

                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //Delete RaoHonPhoi
                    sql = @"DELETE FROM RaoHonPhoi
                                     WHERE MaGiaoDan1 IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((RaoHonPhoi INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = RaoHonPhoi.MaGiaoDan1)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?)
                                        OR MaGiaoDan2 IN (SELECT DISTINCT GiaoDan.MaGiaoDan FROM ((RaoHonPhoi INNER JOIN GiaoDan ON GiaoDan.MaGiaoDan = RaoHonPhoi.MaGiaoDan2)
                                                                INNER JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo) WHERE GiaoHo.MaGiaoHo=?)";
                    Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo], tbl.Rows[i][GiaoHoConst.MaGiaoHo] });

                    if (Memory.ShowError())
                    {
                        return;
                    }

                    //DELETE master tables
                    string[] delTables = new string[] { GiaoDanConst.TableName, GiaDinhConst.TableName, GiaoHoConst.TableName };
                    foreach (string tableName in delTables)
                    {
                        sql = string.Format("DELETE FROM [{0}] WHERE MaGiaoHo=?", tableName);
                        Memory.ExecuteSqlCommand(sql, new object[] { tbl.Rows[i][GiaoHoConst.MaGiaoHo] });
                        if (Memory.ShowError())
                        {
                            return;
                        }
                        tblSource.Rows[lstSelectionPositions[i]].Delete();
                    }
                }
                gxGiaoHoList1.LoadData();
                #endregion Xoa cac giao ho duoc chon - end

                if (!Memory.ShowError())
                {
                    MessageBox.Show("Đã xóa thành công các giáo họ được chọn");
                }
                Memory.CurrentGiaoHo = -1;
            }
        }

        private void gxGiaoHoList1_SelectionChanged(object sender, EventArgs e)
        {
            changeSelection();
        }

        private void changeSelection()
        {
            if (gxGiaoHoList1.CurrentRow != null && (gxGiaoHoList1.CurrentRow.DataRow as DataRowView) != null)
            {
                DataRow row = (gxGiaoHoList1.CurrentRow.DataRow as DataRowView).Row;
                txtMaGiaoHo.Text = row[GiaoHoConst.MaGiaoHo].ToString();
                txtTenGiaoHo.Text = row[GiaoHoConst.TenGiaoHo].ToString();
            }
        }

        private void gxGiaoHoList1_RowCountChanged(object sender, EventArgs e)
        {
            if (gxGiaoHoList1.DataSource == null) return;
            if ((gxGiaoHoList1.DataSource as DataTable).Rows.Count == 0)
            {
                gxAddEdit1.DeleteButton.Enabled = false;
                gxAddEdit1.EditButton.Enabled = false;
                return;
            }
            gxAddEdit1.DeleteButton.Enabled = true;
            gxAddEdit1.EditButton.Enabled = true;
        }

        private void gxGiaoHoList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (maGiaoHoCha == -1) EditGiaoHoRow();
            //EditGiaDinhRow();
            
        }

        private void EditGiaoHoRow()
        {
            if (gxGiaoHoList1.CurrentRow == null)
            {
                return;
            }
            frmGiaoHo frm = new frmGiaoHo();
            frm.Operation = GxOperation.EDIT;
            DataRow row = (gxGiaoHoList1.CurrentRow.DataRow as DataRowView).Row;
            frm.MaGiaoHoCha = (int)row[GiaoHoConst.MaGiaoHo];
            frm.ControlBox = true;
            frm.WindowState = FormWindowState.Normal;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //If change grid value, write code here
            }
        }

        private void EditGiaDinhRow()
        {
            if (gxGiaoHoList1.CurrentRow == null)
            {
                return;
            }
            frmGiaDinhList frm = new frmGiaDinhList();
            frm.Operation = GxOperation.EDIT;
            DataRow row = (gxGiaoHoList1.CurrentRow.DataRow as DataRowView).Row;
            frm.Id = (int)row[GiaoHoConst.MaGiaoHo];
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //If change grid value, write code here
            }
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gxGiaoHoList1_Click(object sender, EventArgs e)
        {

        }

        private void gxGiaoHoList1_CurrentCellChanged(object sender, EventArgs e)
        {
            cancelEdit();
        }
        private void cancelEdit()
        {
            if (operation == GxOperation.ADD || operation == GxOperation.EDIT)
            {
                EnableEditControls(false);
                gxAddEdit1.AddButton.Focus();
                if (gxGiaoHoList1.RowCount > 0)
                {
                    changeSelection();
                }
                else
                {
                    txtMaGiaoHo.Text = "";
                    txtTenGiaoHo.Text = "";
                }
            }
        }

        private void frmGiaoHo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && (operation == GxOperation.EDIT || operation == GxOperation.VIEW))
            {
                cancelEdit();
            }
        }
    }
}