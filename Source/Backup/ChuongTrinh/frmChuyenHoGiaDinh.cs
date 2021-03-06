using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using GxControl;
using Janus.Windows.GridEX;

namespace GiaoXu
{
    public partial class frmChuyenHoGiaDinh : frmGiaDinhList
    {
        public const string SELECT_COL = "Chon";
        private bool selectAll = false;
        private bool processError = false;

        public frmChuyenHoGiaDinh()
        {
            InitializeComponent();
            this.HelpKey = "chuyen_ho";
            //Show "Tất cả" item and Load default data
            cbGiaoHo.Label = "Giáo họ nguồn";
            cbGiaoHo.BoxLeft = 80;

            cbGiaoHoDich.HasShowAll = false;
            cbGiaoHoDich.AutoLoadGrid = false;
            cbGiaoHoDich.Label = "Giáo họ đích";
            gxGiaDinhList1.Click += new EventHandler(gxGiaDinhList1_Click);
            gxGiaDinhList1.AllowEditGiaDinh = false;
            this.gxCommand1.Visible = false;
        }

        private void gxGiaDinhList1_Click(object sender, EventArgs e)
        {
            if (gxGiaDinhList1.Row > -1 && gxGiaDinhList1.Col > -1)
            {
                if (gxGiaDinhList1.CurrentColumn.Key == SELECT_COL)
                {
                    DataRow currentRow = (gxGiaDinhList1.CurrentRow.DataRow as DataRowView).Row;
                    bool selected = false;
                    if (!Memory.IsNullOrEmpty(currentRow[SELECT_COL])) selected = (bool)currentRow[SELECT_COL];
                    currentRow[SELECT_COL] = !selected;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            gxGiaDinhList1.FormatGrid();
            cbGiaoHo.Combo.Left = cbGiaoHo.BoxLeft + GxConstants.CONTROL_DIS;
            cbGiaoHo.Combo.Width = cbGiaoHo.Width - cbGiaoHo.BoxLeft - 2 * GxConstants.CONTROL_DIS;
            gxAddEdit1.Visible = false;
            FormatGrid();
        }

        private void FormatGrid()
        {
            //add new grid column
            GridEXColumn newCol = new GridEXColumn();
            newCol.Key = SELECT_COL;
            newCol.ColumnType = ColumnType.CheckBox;
            newCol.CheckBoxFalseValue = false;
            newCol.CheckBoxTrueValue = true;

            newCol.Width = 50;
            newCol.BoundMode = ColumnBoundMode.Bound;
            newCol.DataMember = SELECT_COL;
            newCol.Caption = "Chọn";
            newCol.EditType = EditType.CheckBox;
            newCol.DefaultValue = false;
            newCol.FilterEditType = FilterEditType.CheckBox;

            gxGiaDinhList1.RootTable.Columns.Insert(0, newCol);
        }

        protected override void gxGiaDinhList1_LoadDataFinished(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)gxGiaDinhList1.DataSource;
            if (tbl != null)
            {
                tbl.TableName = GiaDinhConst.TableName;
                //add new column
                if (!tbl.Columns.Contains(SELECT_COL))
                {
                    tbl.Columns.Add(SELECT_COL, typeof(bool));
                    foreach (DataRow row in tbl.Rows)
                    {
                        row[SELECT_COL] = false;
                    }
                }
            }
            //base.gxGiaDinhList1_LoadDataFinished(sender, e);
        }

        private void btnChonGiaDinh_Click(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)gxGiaDinhList1.DataSource;
            if (tbl == null) return;

            foreach (DataRow row in tbl.Rows)
            {
                row[SELECT_COL] = !selectAll;
            }
            selectAll = !selectAll;
        }

        private void btnBatDauChuyen_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbGiaoHo.Text.Trim() == "" || cbGiaoHoDich.Text.Trim() == "")
                {
                    Memory.ShowError("Xin vui lòng chọn đầy đủ giáo họ nguồn vào giáo họ đích");
                    return;
                }

                if ((int)cbGiaoHo.SelectedValue == (int)cbGiaoHoDich.SelectedValue)
                {
                    Memory.ShowError("Xin vui lòng chọn giáo họ đích khác giáo họ nguồn");
                    return;
                }

                if (gxGiaDinhList1.RowCount == 0)
                {
                    Memory.ShowError("Không có dữ liệu làm việc");
                    return;
                }

                //bat dau chuyen ho
                DataTable tbl = (DataTable)gxGiaDinhList1.DataSource;
                if (tbl != null)
                {
                    if (tbl.Select(string.Format("{0}={1}", SELECT_COL, true)).Length == 0)
                    {
                        MessageBox.Show("Xin vui lòng chọn ít nhất 1 gia đình để chuyển họ");
                        return;
                    }
                    frmProcess frmUpdate = new frmProcess();

                    if (MessageBox.Show("Nếu chuyển họ cho các gia đình được chọn, các thành viên trong các gia đình này cũng sẽ bị chuyển theo.\r\nBạn có chắc muốn thực hiện việc chuyển họ không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    processError = false;

                    frmUpdate.LabelStart = "Chuẩn bị thực hiện việc chuyển họ...";
                    frmUpdate.LableFinished = "Đã thực hiện xong!";
                    frmUpdate.Text = "Đang chuyển họ cho gia đình. Có thể mất vài phút. Xin vui lòng đợi...";
                    frmUpdate.ProcessClass = new UpdateProcess();
                    frmUpdate.ProcessClass.ProcessOptions = ProcessOptions.ChuyenHoGiaDinh;

                    //assign process data 
                    Dictionary<string, object> dicData = new Dictionary<string, object>();
                    dicData.Add(GiaoHoConst.MaGiaoHo, cbGiaoHoDich.SelectedValue);
                    dicData.Add(GiaDinhConst.TableName, tbl);
                    frmUpdate.ProcessClass.ProcessData = dicData;

                    frmUpdate.StartFunction = new EventHandler(frmUpdate_OnUpdating);
                    frmUpdate.ErrorFunction = new CancelEventHandler(frmUpdate_OnError);
                    frmUpdate.FinishedFunction = new EventHandler(frmUpdate_OnFinished);
                    frmUpdate.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Memory.ShowError(ex.Message);
            }
        }

        public void frmUpdate_OnUpdating(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler d = new EventHandler(frmUpdate_OnUpdating);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.Enabled = false;
            }
        }

        public void frmUpdate_OnError(object sender, CancelEventArgs e)
        {
            if (this.InvokeRequired)
            {
                CancelEventHandler d = new CancelEventHandler(frmUpdate_OnError);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                Memory.ShowError(sender.ToString());
                processError = true;
                this.Enabled = true;
            }
        }

        public void frmUpdate_OnFinished(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    EventHandler d = new EventHandler(frmUpdate_OnFinished);
                    this.Invoke(d, new object[] { sender, e });
                }
                else
                {
                    if (!processError)
                    {
                        MessageBox.Show("Chuyển họ thành công!");
                        gxGiaDinhList1.LoadData();
                    }
                    processError = false;
                    this.Enabled = true;
                }
            }
            catch
            {

            }
        }

        //protected override void EditRow()
        //{
        //    if (gxGiaDinhList1.CurrentRow == null || (gxGiaDinhList1.CurrentRow.DataRow as DataRowView) == null)
        //    {
        //        return;
        //    }
        //    frmGiaDinh frm = new frmGiaDinh();
        //    frm.Operation = GxOperation.VIEW;
        //    DataRow row = (gxGiaDinhList1.CurrentRow.DataRow as DataRowView).Row;
        //    frm.Id = (int)row[GiaDinhConst.MaGiaDinh];
        //    frm.MaGiaoHo = id;
        //    frm.AssignControlData();
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {

        //    }
        //}
    }
}