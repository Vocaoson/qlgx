using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using GxControl;

namespace GiaoXu
{
    public partial class frmDotBiTichList : frmBase
    {
        public frmDotBiTichList()
        {
            InitializeComponent();
            this.HelpKey = "dot_bi_tich";
            //cbLoaiBiTich.Combo.SelectedIndex = 0;
            gxAddEdit1.Enabled = false;
            cbLoaiBiTich.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);
            gxAddEdit1.FindButton.Visible = true;
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gxAddEdit1.Enabled = true;
        }

        private void frmDotBiTichList_Load(object sender, EventArgs e)
        {
            gxDotBiTichList1.FormatGrid();
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            frmBiTichChiTiet frm = new frmBiTichChiTiet();
            frm.Operation = GxOperation.ADD;
            frm.LoaiBiTich = (LoaiBiTich)cbLoaiBiTich.SelectedValue;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable tbl = (DataTable)gxDotBiTichList1.DataSource;
                if (tbl != null)
                {
                    if (frm.DataReturn != null)
                    {
                        tbl.ImportRow(frm.DataReturn);
                    }
                }
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            EditRow();
        }

        /// <summary>
        /// Truong hop xoa 1 gia dinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (gxDotBiTichList1.CurrentRow != null && (gxDotBiTichList1.CurrentRow.DataRow as DataRowView) != null)
            {
                DataRow currRow = (gxDotBiTichList1.CurrentRow.DataRow as DataRowView).Row;
                if (MessageBox.Show("Bạn có chắc muốn loại bỏ đợt bí tích này ra khỏi danh sách?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Memory.DeleteRows(BiTichChiTietConst.TableName, BiTichChiTietConst.MaDotBiTich, currRow[DotBiTichConst.MaDotBiTich]);
                Memory.DeleteRows(DotBiTichConst.TableName, DotBiTichConst.MaDotBiTich, currRow[DotBiTichConst.MaDotBiTich]);
                gxDotBiTichList1.CurrentRow.Delete();
            }
        }

        private void gxDotBiTichList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            EditRow();
        }

        private void EditRow()
        {
            if (gxDotBiTichList1.CurrentRow == null || (gxDotBiTichList1.CurrentRow.DataRow as DataRowView) == null)
            {
                return;
            }
            frmBiTichChiTiet frm = new frmBiTichChiTiet();
            frm.Operation = GxOperation.EDIT;
            frm.LoaiBiTich = (LoaiBiTich)cbLoaiBiTich.SelectedValue;
            DataRow row = (gxDotBiTichList1.CurrentRow.DataRow as DataRowView).Row;
            frm.MaDotBiTich = (int)row[DotBiTichConst.MaDotBiTich];
            frm.AssignControlData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                row[DotBiTichConst.LinhMuc] = frm.DataReturn[DotBiTichConst.LinhMuc];
                row[DotBiTichConst.NgayBiTich] = frm.DataReturn[DotBiTichConst.NgayBiTich];
                row[DotBiTichConst.MoTa] = frm.DataReturn[DotBiTichConst.MoTa];
            }
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}