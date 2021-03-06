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
    public partial class GxAddEdit : UserControl
    {
        public event EventHandler SelectClick;
        public event EventHandler AddClick;
        public event EventHandler EditClick;
        public event EventHandler DeleteClick;
        public event EventHandler FindClick;
        public event EventHandler PrintClick;
        public event EventHandler Button1Click;
        public event EventHandler Button2Click;
        public event EventHandler ReloadClick;

        public Keys HK_ADD = Keys.F2;
        public Keys HK_DEL = Keys.F3;
        public Keys HK_EDIT = Keys.F4;

        private bool visible = false;

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                this.btn1.Enabled = value;
                this.btn2.Enabled = value;
                this.btnDelete.Enabled = value;
                this.btnEdit.Enabled = value;
                this.btnFind.Enabled = value;
                this.btnNew.Enabled = value;
                this.btnPrint.Enabled = value;
                this.btnReload.Enabled = value;
                this.btnSelect.Enabled = value;
            }
        }

        List<GxButton> lstButton = new List<GxButton>();
        public GxAddEdit()
        {
            InitializeComponent();
            lstButton.Add(btnNew);
            lstButton.Add(btnDelete);
            lstButton.Add(btnEdit);
            lstButton.Add(btnSelect);
            lstButton.Add(btnFind);
            lstButton.Add(btnPrint);
            lstButton.Add(btn1);
            lstButton.Add(btn2);
            lstButton.Add(btnReload);
            btnFind.Click += new EventHandler(btnFind_Click);
            this.VisibleChanged += new EventHandler(GxAddEdit_VisibleChanged);
        }

        private void GxAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            if (!visible)
            {
                visible = true;
                Form parent = this.FindForm();
                if (parent != null && parent is frmBase)
                {
                    if (((frmBase)parent).Operation == GxOperation.ADD)
                    {
                        btnReload.Enabled = false;
                        btnPrint.Enabled = false;
                    }
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            OnFind(sender, e);
        }

        protected virtual void OnFind(object sender, EventArgs e)
        {
            frmFilter frm = new frmFilter();
            Dictionary<object, object> dic = new Dictionary<object, object>();
            if (this.GridData is GxGiaoDanList)
            {
                dic.Add(GiaoDanConst.HoTen, "");
            }
            else if (this.GridData is GxGiaDinhList)
            {
                dic.Add(GiaDinhConst.TenGiaDinh, "");
            }
            frm.GrdData = this.GridData;
            frm.FilterParameter = dic;
            frm.ShowDialog();
        }

        public GxButton AddButton
        {
            get { return btnNew; }
            set { btnNew = value; }
        }

        public GxButton EditButton
        {
            get { return btnEdit; }
            set { btnEdit = value; }
        }

        public GxButton SelectButton
        {
            get { return btnSelect; }
            set { btnSelect = value; }
        }

        public GxButton DeleteButton
        {
            get { return btnDelete; }
            set { btnDelete = value; }
        }

        public GxButton FindButton
        {
            get { return btnFind; }
            set { btnFind = value; }
        }

        public GxButton PrintButton
        {
            get { return btnPrint; }
            set { btnPrint = value; }
        }

        public GxButton Button1
        {
            get { return btn1; }
            set { btn1 = value; }
        }

        public GxButton Button2
        {
            get { return btn2; }
            set { btn2 = value; }
        }

        public GxButton ReloadButton
        {
            get { return btnReload; }
            set { btnReload = value; }
        }

        public string ToolTipAdd
        {
            get { return toolTip1.GetToolTip(btnNew); }
            set { toolTip1.SetToolTip(btnNew, value); }
        }

        public string ToolTipEdit
        {
            get { return toolTip1.GetToolTip(btnEdit); }
            set { toolTip1.SetToolTip(btnEdit, value); }
        }

        public string ToolTipDelete
        {
            get { return toolTip1.GetToolTip(btnDelete); }
            set { toolTip1.SetToolTip(btnDelete, value); }
        }

        public string ToolTipSelect
        {
            get { return toolTip1.GetToolTip(btnSelect); }
            set { toolTip1.SetToolTip(btnSelect, value); }
        }

        public string ToolTipFind
        {
            get { return toolTip1.GetToolTip(btnFind); }
            set { toolTip1.SetToolTip(btnFind, value); }
        }

        public string ToolTipPrint
        {
            get { return toolTip1.GetToolTip(btnPrint); }
            set { toolTip1.SetToolTip(btnPrint, value); }
        }

        public string ToolTipButton1
        {
            get { return toolTip1.GetToolTip(btn1); }
            set { toolTip1.SetToolTip(btn1, value); }
        }

        public string ToolTipButton2
        {
            get { return toolTip1.GetToolTip(btn2); }
            set { toolTip1.SetToolTip(btn2, value); }
        }

        public string ToolTipReload
        {
            get { return toolTip1.GetToolTip(btnReload); }
            set { toolTip1.SetToolTip(btnReload, value); }
        }

        private GxGrid gridData = null;

        public GxGrid GridData
        {
            get { return gridData; }
            set { 
                gridData = value;
                if (value != null)
                {
                    if (gridData.RowCount == 0)
                    {
                        EnableButtons(false);
                    }
                    gridData.RowCountChanged += new EventHandler(gridData_RowCountChanged);
                }
            }
        }

        private void gridData_RowCountChanged(object sender, EventArgs e)
        {
            if (gridData == null) return;
            if (gridData.RowCount > 0)
            {
                EnableButtons(true);
            }
            else
            {
                EnableButtons(false);
            }
        }
        /// <summary>
        /// Enable/disable these buttons:
        /// Button1.Enabled
        /// Button2.Enabled
        /// DeleteButton.Enabled
        /// EditButton.Enabled
        /// PrintButton.Enabled
        /// FindButton.Enabled
        /// </summary>
        /// <param name="e"></param>
        public void EnableButtons(bool e)
        {
            this.Button1.Enabled = e;
            this.Button2.Enabled = e;
            this.DeleteButton.Enabled = e;
            this.EditButton.Enabled = e;
            this.PrintButton.Enabled = e;
            this.FindButton.Enabled = e;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string txt = (sender as Button).Name;
            if (txt == btnSelect.Name)
            {
                if (SelectClick != null) SelectClick(sender, e);
            }
            else if (txt == btnNew.Name)
            {
                if (AddClick != null) AddClick(sender, e);
            }
            else if (txt == btnEdit.Name)
            {
                if (EditClick != null) EditClick(sender, e);
            }
            else if (txt == btnDelete.Name)
            {
                if (DeleteClick != null) DeleteClick(sender, e);
            }
            else if (txt == btnFind.Name)
            {
                if (FindClick != null) FindClick(sender, e);
            }
            else if (txt == btnPrint.Name)
            {
                if (PrintClick != null) PrintClick(sender, e);
            }
            else if (txt == btn1.Name)
            {
                if (Button1Click != null) Button1Click(sender, e);
            }
            else if (txt == btn2.Name)
            {
                if (Button2Click != null) Button2Click(sender, e);
            }
            else if (txt == btnReload.Name)
            {
                if (gridData != null) gridData.LoadDataToGrid();
                if (ReloadClick != null) ReloadClick(sender, e);
            }
        }
        //private bool isResized = false;
        private void GXAddEdit_Resize(object sender, EventArgs e)
        {

        }

        private void GXAddEdit_Load(object sender, EventArgs e)
        {

        }

        private CaptionDisplayMode captionDisplayMode = CaptionDisplayMode.Full;

        public CaptionDisplayMode CaptionDisplayMode
        {
            get { return captionDisplayMode; }
            set { 
                captionDisplayMode = value;
                if (value == CaptionDisplayMode.Full)
                {
                    AddButton.Text = "&Thêm";
                    EditButton.Text = "&Xem-Sửa";
                    DeleteButton.Text = "&Loại bỏ";
                    FindButton.Text = "Tìm &kiếm trên lưới";
                    PrintButton.Text = "&In danh sách";
                    SelectButton.Text = "&Chọn";
                    ReloadButton.Text = "&Tải lại danh sách";
                }
                else if (value == CaptionDisplayMode.Short)
                {
                    AddButton.Text = "&T";
                    EditButton.Text = "&S";
                    DeleteButton.Text = "&X";
                    FindButton.Text = "&F";
                    PrintButton.Text = "&P";
                    SelectButton.Text = "&C";
                    ReloadButton.Text = "&R";
                }
                else if (value == CaptionDisplayMode.None)
                {
                    AddButton.Text = "";
                    EditButton.Text = "";
                    DeleteButton.Text = "";
                    FindButton.Text = "";
                    PrintButton.Text = "";
                    SelectButton.Text = "";
                    ReloadButton.Text = "";
                }
            
            }
        }

        private DisplayMode displayMode = DisplayMode.Mode2;

        public DisplayMode DisplayMode
        {
            get { return displayMode; }
            set { 
                displayMode = value;
                foreach(GxButton btn in lstButton)
                {
                    btn.Visible = false;
                }
                switch (value)
                { 
                    case DisplayMode.Mode1:
                        AddButton.Visible = true;
                        EditButton.Visible = true;
                        DeleteButton.Visible = true;
                        FindButton.Visible = true;
                        PrintButton.Visible = false;
                        SelectButton.Visible = true;
                        break;
                    case DisplayMode.Mode2:
                        AddButton.Visible = true;
                        EditButton.Visible = true;
                        DeleteButton.Visible = true;
                        FindButton.Visible = false;
                        PrintButton.Visible = false;
                        SelectButton.Visible = true;
                        ReloadButton.Visible = true;
                        break;
                    case DisplayMode.Mode3:
                        AddButton.Visible = true;
                        EditButton.Visible = true;
                        DeleteButton.Visible = true;
                        FindButton.Visible = false;
                        PrintButton.Visible = false;
                        SelectButton.Visible = false;
                        break;
                    case DisplayMode.Mode4:
                        AddButton.Visible = true;
                        EditButton.Visible = false;
                        DeleteButton.Visible = false;
                        FindButton.Visible = false;
                        PrintButton.Visible = false;
                        SelectButton.Visible = false;
                        break;
                    default:
                        AddButton.Visible = true;
                        EditButton.Visible = true;
                        DeleteButton.Visible = true;
                        FindButton.Visible = true;
                        PrintButton.Visible = true;
                        SelectButton.Visible = true;
                        Button1.Visible = true;
                        Button2.Visible = true;
                        ReloadButton.Visible = true;
                        break;
                }
            }
        }

        private void button_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                GxButton btn = (GxButton)sender;
                bool begin = false;
                int j = 0;
                int width = 0;
                for (int i = 0; i < lstButton.Count; i++)
                {
                    if (lstButton[i].Visible)
                    {
                        if (!begin)
                        {
                            lstButton[i].Left = 0;
                            width += lstButton[i].Width + GxConstants.CONTROL_DIS;
                            begin = true;
                            j = i;
                        }
                        else
                        {
                            lstButton[i].Left = lstButton[j].Right + GxConstants.CONTROL_DIS;
                            width += lstButton[i].Width + GxConstants.CONTROL_DIS;
                            j = i;
                        }
                    }
                }
                this.Width = width;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GXAddEdit, button_VisibleChanged)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //base.OnVisibleChanged(e);
        }

    }
}
