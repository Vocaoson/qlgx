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
    public partial class frmChuyenHoGiaoDan : frmGiaoDanList
    {
        public const string SELECT_COL = "Chon";
        private bool selectAll = false;

        public frmChuyenHoGiaoDan()
        {
            InitializeComponent();
            this.HelpKey = "chuyen_ho";
            //Show "Tất cả" item and Load default data
            cbGiaoHo.Label = "Giáo họ nguồn";
            cbGiaoHo.BoxLeft = 80;

            cbGiaoHoDich.HasShowAll = false;
            cbGiaoHoDich.AutoLoadGrid = false;
            cbGiaoHoDich.Label = "Giáo họ đích";
            gxGiaoDanList1.Click += new EventHandler(gxGiaoDanList1_Click);
            gxGiaoDanList1.AllowEditGiaoDan = false;
        }

        private void gxGiaoDanList1_Click(object sender, EventArgs e)
        {
            if (gxGiaoDanList1.Row > -1 && gxGiaoDanList1.Col > -1)
            {
                if (gxGiaoDanList1.CurrentColumn.Key == SELECT_COL)
                {
                    DataRow currentRow = (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row;
                    bool selected = false;
                    if (!Memory.IsNullOrEmpty(currentRow[SELECT_COL])) selected = (bool)currentRow[SELECT_COL];
                    currentRow[SELECT_COL] = !selected;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            gxGiaoDanList1.FormatGrid();
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

            gxGiaoDanList1.RootTable.Columns.Insert(0, newCol);
        }

        protected override void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)gxGiaoDanList1.DataSource;
            if (tbl != null)
            {
                tbl.TableName = GiaoDanConst.TableName;
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
            //base.gxGiaoDanList1_LoadDataFinished(sender, e);
        }

        private void btnChonGiaoDan_Click(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)gxGiaoDanList1.DataSource;
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

                if (gxGiaoDanList1.RowCount == 0)
                {
                    Memory.ShowError("Không có dữ liệu làm việc");
                    return;
                }

                //bat dau chuyen ho
                DataTable tblGiaoDan = (DataTable)gxGiaoDanList1.DataSource;

                if (tblGiaoDan != null)
                {
                    DataTable tbl = tblGiaoDan.Copy();
                    if (tbl.Select(string.Format("{0}={1}", SELECT_COL, true)).Length == 0)
                    {
                        MessageBox.Show("Xin vui lòng chọn ít nhất 1 giáo dân để chuyển họ");
                        return;
                    }
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow row = tbl.Rows[i];
                        if ((bool)row[frmChuyenHoGiaDinh.SELECT_COL] == true)
                        {
                            row[GiaoDanConst.MaGiaoHo] = cbGiaoHoDich.SelectedValue;
                        }
                        else
                        {
                            tbl.Rows.Remove(row);
                            i--;
                        }
                    }
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tbl);
                    Memory.UpdateDataSet(ds);
                    if (Memory.ShowError())
                    {
                        return;
                    }
                    MessageBox.Show("Chuyển họ thành công");
                    gxGiaoDanList1.LoadData();
                }
            }
            catch (Exception ex)
            {
                Memory.ShowError(ex.Message);
            }
        }
    }
}