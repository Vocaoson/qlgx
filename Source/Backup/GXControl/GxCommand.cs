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
    public partial class GxCommand : UserControl
    {
        public event EventHandler OnOK;
        public event EventHandler OnCancel;
        public event EventHandler Button1Click;

        private List<GxButton> lstButton = new List<GxButton>();

        public GxButton Button1
        {
            get { return btn1; }
            set { btn1 = value; }
        }

        public GxButton OKButton
        {
            get { return btnOK; }
            set { btnOK = value; }
        }

        public GxButton CancelButton
        {
            get { return btnCancel; }
            set { btnOK = btnCancel; }
        }

        private bool allowHotkey = false;

        public bool AllowHotkey
        {
            get { return allowHotkey; }
            set { allowHotkey = value; }
        }

        public GxCommand()
        {
            InitializeComponent();
            btn1.Visible = false;
            lstButton.Add(btnCancel);
            lstButton.Add(btnOK);
            lstButton.Add(btn1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OnOKClick(sender, e);
        }

        public void OnOKClick(object sender, EventArgs e)
        {
            if (OnOK != null) OnOK(sender, e);
        }

        private bool oKIsAccept = false;

        public bool OKIsAccept
        {
            get { return oKIsAccept; }
            set 
            { 
                oKIsAccept = value;
                if (value == true)
                {
                    OKButton.ImageKey = "Accept";
                }
                else
                {
                    OKButton.ImageKey = "Save";
                }
            }
        }
        
        public string ToolTipOK
        {
            get { return toolTip1.GetToolTip(btnOK); }
            set { toolTip1.SetToolTip(btnOK, value); }
        }

        public string ToolTipCancel
        {
            get { return toolTip1.GetToolTip(btnCancel); }
            set { toolTip1.SetToolTip(btnCancel, value); }
        }

        public string ToolTipButton1
        {
            get { return toolTip1.GetToolTip(btn1); }
            set { toolTip1.SetToolTip(btn1, value); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        public void OnCancelClick(object sender, EventArgs e)
        {
            if (OnCancel != null) OnCancel(sender, e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            btnCancel.Left = this.Width - btnCancel.Width - GxGlobal.GxConstants.CONTROL_DIS;
            btnOK.Left = btnCancel.Left - btnOK.Width - GxGlobal.GxConstants.CONTROL_DIS;
            btn1.Left = btnOK.Left - btn1.Width - GxGlobal.GxConstants.CONTROL_DIS;
            //base.OnVisibleChanged(e);
            //if (OKIsAccept == true)
            //{
            //    OKButton.ImageList = ImageList;
            //    OKButton.ImageKey = "Accept";
            //}
            //else
            //{
            //    OKButton.ImageList = ImageList;
            //    OKButton.ImageKey = "Save";
            //}
        }

        private DisplayMode displayMode = DisplayMode.Full;

        public DisplayMode DisplayMode
        {
            get { return displayMode; }
            set
            {
                displayMode = value;
                switch (value)
                {
                    case DisplayMode.Full:
                        CancelButton.Visible = true;
                        OKButton.Visible = true;
                        break;
                    case DisplayMode.Mode1:
                        OKButton.Visible = true;
                        CancelButton.Visible = false;
                        break;
                    case DisplayMode.Mode2:
                        OKButton.Visible = false;
                        CancelButton.Visible = true;
                        CancelButton.Text = "Đón&g";
                        break;
                    default:
                        break;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Button1Click != null) Button1Click(sender, e);
        }

        private void button_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                GxButton btn = (GxButton)sender;
                reOrderButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (GXAddEdit, button_VisibleChanged)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //base.OnVisibleChanged(e);
        }

        private void reOrderButtons()
        {
            bool begin = false;
            int j = 0;
            for (int i = 0; i < lstButton.Count; i++)
            {
                if (lstButton[i].Visible)
                {
                    if (!begin)
                    {
                        lstButton[i].Left = this.Width - lstButton[i].Width - GxConstants.CONTROL_DIS;
                        begin = true;
                        j = i;
                    }
                    else
                    {
                        lstButton[i].Left = lstButton[j].Left - lstButton[i].Width - GxConstants.CONTROL_DIS;
                        j = i;
                    }
                }
            }
        }

        private void GxCommand_Resize(object sender, EventArgs e)
        {
            reOrderButtons();
        }
    }
}
