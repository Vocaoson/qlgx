using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GxGlobal;

namespace GxControl
{
    public partial class GxGiaoDan : GxTextField
    {
        public event EventHandler OnSelected;
        public event EventHandler OnAdded;
        public event EventHandler OnEdited;

        public event SelectingHandler OnSelecting;
        public event SelectingHandler OnAdding;
        public event SelectingHandler OnEditing;

        public delegate void SelectingHandler(object sender, CancelEventArgs e);

        private string whereSQL = "";

        public string WhereSQL
        {
            get { return whereSQL; }
            set { whereSQL = value; }
        }

        private int maGiaoDan = -1;

        public int MaGiaoDan
        {
            get { return maGiaoDan; }
            set
            {
                maGiaoDan = value;
                if (value > -1)
                {
                    gxAddEdit1.EditButton.Enabled = true;
                    gxAddEdit1.DeleteButton.Enabled = true;
                    DataTable tbl = Memory.GetData(SqlConstants.SELECT_GIAODAN_THEO_ID, new object[] { value });
                    if (!Memory.ShowError() && tbl != null && tbl.Rows.Count > 0)
                    {
                        this.CurrentRow = tbl.Rows[0];
                    }
                }
                else
                {
                    TextBox.Text = "";
                    gxAddEdit1.EditButton.Enabled = false;
                    gxAddEdit1.DeleteButton.Enabled = false;
                }
            }
        }

        private int maGiaoHo = -1;

        public int MaGiaoHo
        {
            get { return maGiaoHo; }
            set { maGiaoHo = value; }
        }

        private DisplayMode displayMode = DisplayMode.Full;

        public DisplayMode DisplayMode
        {
            get { return displayMode; }
            set 
            {
                displayMode = value;
                if (displayMode == DisplayMode.Mode1)
                {
                    TextBox.Visible = true;
                    gxAddEdit1.Visible = true;
                }
                else if (displayMode == DisplayMode.Mode2)
                {
                    gxAddEdit1.Visible = false;
                    TextBox.Visible = true;
                }
                else
                {
                    TextBox.Visible = true;
                    gxAddEdit1.Visible = true;
                }
                ChangeSize();
            }
        }


        public GxAddEdit EditControl
        {
            get { return gxAddEdit1; }
        }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                gxAddEdit1.Enabled = value;
            }
        }
        private DataRow currentRow = null;

        public DataRow CurrentRow
        {
            get { return currentRow; }
            set 
            {
                currentRow = value;
                if (value != null)
                {
                    assignValue(value);
                    if (OnSelected != null) OnSelected(value, EventArgs.Empty);
                }
                else
                {
                    this.editBase.Text = "";
                    this.MaGiaoDan = -1;
                }
            }
        }

        private List<Control> lstButton = new List<Control>();

        public GxGiaoDan()
        {
            InitializeComponent();
            gxAddEdit1.ToolTipDelete = "Loại bỏ";
            lstButton.Add(label1);
            lstButton.Add(TextBox);
            lstButton.Add(gxAddEdit1);
        }


        protected override void ChangeSize()
        {
            try
            {
                int spaceEditCtlLeft = 0;
                if (boxLeft == 0)
                {
                    spaceEditCtlLeft = label1.Left + label1.Width;
                }
                else
                {
                    label1.AutoSize = false;
                    label1.Left = 0;
                    label1.Width = boxLeft;
                    spaceEditCtlLeft = boxLeft;
                }
                editBase.Left = spaceEditCtlLeft + GxConstants.CONTROL_DIS;
                if (gxAddEdit1.Visible)
                {
                    editBase.Width = this.Width - label1.Width - gxAddEdit1.Width - GxConstants.CONTROL_DIS;
                    gxAddEdit1.Left = editBase.Left + editBase.Width + GxConstants.CONTROL_DIS;
                    editBase.Top = 4;
                }
                else
                {
                    editBase.Width = this.Width - label1.Width - GxConstants.CONTROL_DIS;
                }
                //this.Height = 33;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GxGiaoDan, resizeControls)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableEditButton(bool enabled)
        {
            gxAddEdit1.EditButton.Enabled = enabled;
            gxAddEdit1.DeleteButton.Enabled = enabled;
        }
        
        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmChonGiaoDan frm;
            frm = new frmChonGiaoDan();
            frm.WhereSQL = whereSQL;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    CancelEventArgs ce = new CancelEventArgs();
                    if (OnSelecting != null) OnSelecting(frm.DataReturn, ce);
                    if (!ce.Cancel)
                    {
                        //assignValue(frm.DataReturn);
                        CurrentRow = frm.DataReturn;
                        EnableEditButton(true);
                        changFont(CurrentRow);
                        //if (OnSelected != null) OnSelected(frm.DataReturn, e);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGiaoDan frm;
            frm = new frmGiaoDan();
            frm.MaGiaoHo = maGiaoHo;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    CancelEventArgs ce = new CancelEventArgs();
                    if (OnAdding != null) OnAdding(frm.DataReturn, ce);
                    if (!ce.Cancel)
                    {
                        //assignValue(frm.DataReturn);
                        CurrentRow = frm.DataReturn;
                        EnableEditButton(true);
                        changFont(CurrentRow);
                        if (OnAdded != null) OnAdded(frm.DataReturn, e);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmGiaoDan frm;
            frm = new frmGiaoDan();
            frm.Operation = GxOperation.EDIT;
            frm.Id = MaGiaoDan;
            frm.MaGiaoHo = maGiaoHo;
            frm.AssignControlData();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.DataReturn != null)
                {
                    CancelEventArgs ce = new CancelEventArgs();
                    if (OnEditing != null) OnEditing(frm.DataReturn, ce);
                    if (!ce.Cancel)
                    {
                        //assignValue(frm.DataReturn);
                        CurrentRow = frm.DataReturn;
                        changFont(CurrentRow);
                        if (OnEdited != null) OnEdited(frm.DataReturn, e);  
                    }
                }
            }
        }

        private void changFont(DataRow row)
        {
            if ((bool)row[GiaoDanConst.QuaDoi] || (Validator.IsNumber(row[GiaoDanConst.DaChuyenXu].ToString()) &&
                    int.Parse(row[GiaoDanConst.DaChuyenXu].ToString()) == -1))
            {
                TextBox.ForeColor = Color.Red;
                TextBox.Font = new Font(TextBox.Font, FontStyle.Strikeout);
            }
            else
            {
                TextBox.ForeColor = Color.Black;
                TextBox.Font = new Font(TextBox.Font, FontStyle.Regular);
            }
        }

        private void assignValue(DataRow row)
        {
            this.editBase.Text = row[GiaoDanConst.TenThanh].ToString() + " " + row[GiaoDanConst.HoTen].ToString();
            this.maGiaoDan = (int)row[GiaoDanConst.MaGiaoDan];
        }

        private void gxAddEdit1_DeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn loại bỏ người này ra?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentRow = null;
                EnableEditButton(false);
            }
        }

        private void GxGiaoDan_Load(object sender, EventArgs e)
        {
            ChangeSize();
            TextBox.ReadOnly = true;
        }
        /// <summary>
        /// Set ma giao dan without raising OnSelected event
        /// </summary>
        /// <param name="ma"></param>
        public void SetMaGiaoDan(int ma)
        {
            maGiaoDan = ma;
        }
    }
}
