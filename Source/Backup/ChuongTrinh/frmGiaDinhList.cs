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
    public partial class frmGiaDinhList : frmBase
    {
        private string SELECT_GIADINH = SqlConstants.SELECT_GIADINH_LIST;

        private object[] arguments = null;

        public object[] Arguments
        {
            get { return arguments; }
            set
            {
                arguments = value;
                gxGiaDinhList1.Arguments = value;
            }
        }

        private string queryString = "";

        public string QueryString
        {
            get { return queryString; }
            set 
            {
                queryString = value;
                gxGiaDinhList1.QueryString = value;
            }
        }

        public int MaGiaoHo
        {
            get { return cbGiaoHo.MaGiaoHo; }
            set {
                cbGiaoHo.AutoLoadGrid = false;
                cbGiaoHo.MaGiaoHo = value;
                cbGiaoHo.AutoLoadGrid = true;
            }
        }

        public GxGiaDinhList GiaDinhList
        {
            get { return gxGiaDinhList1; }
            set { gxGiaDinhList1 = value; }
        }

        public frmGiaDinhList()
        {
            InitializeComponent();
            this.HelpKey = "gia_dinh";
            //gxAddEdit1.PrintButton.Text = "&In danh sách gia đình";
            gxAddEdit1.PrintButton.Visible = true;

            //gxAddEdit1.ReloadButton.Text = "&Tải lại dữ liệu";
            gxAddEdit1.ReloadButton.Visible = true;
            gxAddEdit1.GridData = gxGiaDinhList1;

            gxAddEdit1.Button1.Text = "In &chứng nhận hôn phối";
            gxAddEdit1.Button1.Visible = true;
            gxAddEdit1.Button1Click += new EventHandler(gxAddEdit1_Button1Click);

            gxAddEdit1.Button2.Text = "In &sổ gia đình";
            gxAddEdit1.Button2.Visible = true;
            gxAddEdit1.Button2Click += new EventHandler(gxAddEdit1_Button2Click);

            //gxAddEdit1.FindButton.Text = "Tìm &kiếm trên lưới";
            gxAddEdit1.FindButton.Visible = true;
            //gxAddEdit1.FindButton.Click += new EventHandler(FindButton_Click);

            cbGiaoHo.GridGiaDinh = gxGiaDinhList1;

            gxGiaDinhList1.LoadDataFinished += new EventHandler(gxGiaDinhList1_LoadDataFinished);
            gxGiaDinhList1.FilterApplied += new EventHandler(gxGiaDinhList1_FilterApplied);
            gxGiaDinhList1.RowCountChanged += new EventHandler(gxGiaDinhList1_RowCountChanged);

            lblTotal.Text = "";
            cbGiaoHo.AutoLoadGrid = false;
            cbGiaoHo.IsAo = Janus.Windows.GridEX.TriState.False;
            cbGiaoHo.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);
            gxAddEdit1.ReloadButton.Enabled = false;
            //gxAddEdit1.EnableButtons(false);
        }

        private void gxGiaDinhList1_RowCountChanged(object sender, EventArgs e)
        {
            lblTotal.Text = gxGiaDinhList1.RowCount.ToString() + " gia đình";
        }

        private void gxAddEdit1_Button1Click(object sender, EventArgs e)
        {
            gxGiaDinhList1.XuatChungNhanHonPhoi();
        }

        private void gxAddEdit1_Button2Click(object sender, EventArgs e)
        {
            gxGiaDinhList1.XuatSoGiaDinh();
        }

        private void gxGiaDinhList1_FilterApplied(object sender, EventArgs e)
        {
            
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gxAddEdit1.ReloadButton.Enabled = true;
        }

        protected virtual void gxGiaDinhList1_LoadDataFinished(object sender, EventArgs e)
        {
            lblTotal.Text = gxGiaDinhList1.RowCount.ToString() + " gia đình";
        }

        //void FindButton_Click(object sender, EventArgs e)
        //{
        //    frmFilter frm = new frmFilter();
        //    Dictionary<object, object> dic = new Dictionary<object, object>();
        //    dic.Add(GiaDinhConst.TenGiaDinh, "");
        //    frm.GrdData = this.gxGiaDinhList1;
        //    frm.FilterParameter = dic;
        //    frm.ShowDialog();
        //}

        private void frmGiaDinhList_Load(object sender, EventArgs e)
        {
            //Show "Tất cả" item and Load default data
            cbGiaoHo.HasShowAll = true;
            gxGiaDinhList1.FormatGrid();
            cbGiaoHo.AutoLoadGrid = true;
            if (this.operation == GxOperation.EDIT && id > -1)
            {
                cbGiaoHo.Enabled = false;
                cbGiaoHo.MaGiaoHo = id;
            }
            else
            {
                if (Memory.Instance.GetMemory(GxConstants.DangTimKiemGiaDinhGiaoDan) == null)
                {
                    if (Memory.CurrentGiaoHo > 0)
                    {
                        cbGiaoHo.MaGiaoHo = Memory.CurrentGiaoHo;
                    }
                }
                else
                {
                    gxGiaDinhList1.LoadData();
                }
            }
            if (operation != GxOperation.EDIT) gxCommand1.Visible = false;
            Memory.Instance.SetMemory(GxConstants.DangTimKiemGiaDinhGiaoDan, null);
        }

        private void LoadGiaDinhList()
        {
            string where = "";
            if (cbGiaoHo.MaGiaoHo > -1)
            {
                where = string.Format(" AND ({0}={1}) ", GiaoHoConst.MaGiaoHo, cbGiaoHo.MaGiaoHo);
            }
            gxGiaDinhList1.LoadData(string.Concat(SELECT_GIADINH, where), null);
        }

        public void LoadGiaDinhList(string sql)
        {
            gxGiaDinhList1.LoadData(sql, null);
        }

        public void LoadGiaDinhList(string sql, object[] arguments)
        {
            gxGiaDinhList1.LoadData(sql, arguments);
        }

        private void gxAddEdit1_AddClick(object sender, EventArgs e)
        {
            frmGiaDinh frm = new frmGiaDinh();
            frm.MaGiaoHo = cbGiaoHo.MaGiaoHo;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    DataTable tbl = Memory.GetData(string.Concat(SELECT_GIADINH, " AND MaGiaDinh=" + frm.DataReturn[GiaDinhConst.MaGiaDinh].ToString()));
                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        DataTable sourceTbl = (DataTable)gxGiaDinhList1.DataSource;
                        if (sourceTbl != null)
                        {
                            sourceTbl.ImportRow(tbl.Rows[0]);
                            gxGiaDinhList1.FindAll(gxGiaDinhList1.RootTable.Columns[0], Janus.Windows.GridEX.ConditionOperator.Equal, tbl.Rows[0][GiaDinhConst.MaGiaDinh]);
                        }
                        else
                        {
                            gxGiaDinhList1.DataSource = tbl;
                        }
                    }
                }
            }
        }

        private void gxAddEdit1_EditClick(object sender, EventArgs e)
        {
            gxGiaDinhList1.EditRow();
        }

        /// <summary>
        /// Truong hop xoa 1 gia dinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (gxGiaDinhList1.CurrentRow != null && (gxGiaDinhList1.CurrentRow.DataRow as DataRowView)!=null)
            {
                DialogResult rs = MessageBox.Show("Bạn muốn xóa vĩnh viễn gia đình được chọn không?\r\nChọn [Yes] để xóa vĩnh viễn.\r\nChọn [No] để đưa vào hồ sơ lưu trữ.\r\nChọn [Cancel] hủy bỏ việc xóa.", "Xác nhận xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.Cancel) return;

                //if (MessageBox.Show("Bạn có chắc muốn xóa (các) gia đình này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int count = gxGiaDinhList1.SelectedItems.Count;
                List<int> lstDelete = new List<int>();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem item in gxGiaDinhList1.SelectedItems)
                {
                    lstDelete.Add(item.Position);
                }
                for (int i = 0; i < count;i++ )
                {
                    Janus.Windows.GridEX.GridEXRow item = gxGiaDinhList1.GetRow(lstDelete[i] - i);
                    if (rs == DialogResult.Yes)
                    {
                        Memory.ExecuteSqlCommand("DELETE FROM GiaDinh WHERE MaGiaDinh=?",
                                                            new object[] { (item.DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh] });
                        if (Memory.ShowError())
                        {
                            return;
                        }
                        Memory.ExecuteSqlCommand("DELETE FROM ThanhVienGiaDinh WHERE MaGiaDinh=?",
                                                            new object[] { (item.DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh] });
                        if (Memory.ShowError())
                        {
                            return;
                        }
                    }
                    else
                    {
                        
                        Memory.ExecuteSqlCommand(SqlConstants.DELETE_GIADINH_THEO_ID,
                                                            new object[] { (item.DataRow as DataRowView).Row[GiaDinhConst.MaGiaDinh] });
                        if (Memory.ShowError())
                        {
                            return;
                        }
                    }
                    //gxGiaDinhList1.CurrentRow.Delete();
                    item.Delete();
                    //gxGiaDinhList1.SelectedItems.Remove(item);
                }
            }
        }

        private void gxGiaDinhList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //EditRow();
        }

        //protected virtual void EditRow()
        //{
        //    if (gxGiaDinhList1.CurrentRow == null || (gxGiaDinhList1.CurrentRow.DataRow as DataRowView) == null)
        //    {
        //        return;
        //    }
        //    frmGiaDinh frm = new frmGiaDinh();
        //    frm.Operation = GxOperation.EDIT;
        //    DataRow row = (gxGiaDinhList1.CurrentRow.DataRow as DataRowView).Row;
        //    frm.Id = (int)row[GiaDinhConst.MaGiaDinh];
        //    frm.MaGiaoHo = id;
        //    frm.AssignControlData();
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        if (frm.DataReturn != null)
        //        {
        //            DataTable tbl = Memory.GetData(string.Concat(SELECT_GIADINH, " AND MaGiaDinh=" + frm.DataReturn[GiaDinhConst.MaGiaDinh].ToString()));
        //            if (Memory.ShowError()) return;
        //            if (tbl != null && tbl.Rows.Count > 0)
        //            {
        //                foreach (DataColumn col in tbl.Columns)
        //                {
        //                    if (row.Table.Columns.Contains(col.ColumnName))
        //                    {
        //                        row[col.ColumnName] = tbl.Rows[0][col.ColumnName];
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gxCommand1_OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.Export.GridEXExporter ex = new Janus.Windows.GridEX.Export.GridEXExporter();
            ex.GridEX = gxGiaDinhList1;

            string filePath = System.IO.Path.GetRandomFileName() + ".xls";
            filePath = Memory.GetTempPath(filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            System.IO.FileStream stream = file.OpenWrite();
            ex.Export((System.IO.Stream)stream);
            stream.Close();
            System.Diagnostics.Process.Start(filePath);
        }

        private void chkGiaoDanAo_CheckedChanged(object sender, EventArgs e)
        {
            cbGiaoHo.IsAo = chkGiaDinhAo.Checked ? Janus.Windows.GridEX.TriState.True : Janus.Windows.GridEX.TriState.False;
        }
    }
}