using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.EditControls;
using GxGlobal;

namespace GxControl
{
    public partial class GxLoaiBiTich : GxBaseField
    {
        public GxLoaiBiTich()
        {
            InitializeComponent();
            label1.Text = "Loai bí tích";
            uiComboBox1.ComboStyle = ComboStyle.DropDownList;
            uiComboBox1.SelectedIndexChanged += new EventHandler(uiComboBox1_SelectedIndexChanged);
            InitControl();
            loadComboBox();
        }

        public UIComboBox Combo
        {
            get { return uiComboBox1; }
            set { uiComboBox1 = value; }
        }

        public int Value
        {
            get {
                try
                {
                    return (int)uiComboBox1.SelectedValue;
                }
                catch
                {
                    return -1;
                }
            }
            set { 
                SelectedValue = value;
                if (value == -1)
                {
                    uiComboBox1.Text = "";
                }
            }
        }

        public new bool Enabled
        {
            get { return uiComboBox1.Enabled; }
            set
            {
                uiComboBox1.Enabled = value;
                uiComboBox1.BackColor = Color.WhiteSmoke;
            }
        }

        public object SelectedValue
        {
            get { return uiComboBox1.SelectedValue; }
            set
            {
                try
                {
                    uiComboBox1.SelectedValue = value;
                }
                catch { }
            }
        }

        private GxDotBiTichList gridBiTichList = null;

        public GxDotBiTichList GridBiTichList
        {
            get { return gridBiTichList; }
            set { gridBiTichList = value; }
        }

        protected override void InitControl()
        {
            editBase = uiComboBox1;
            base.InitControl();
        }

        private void loadComboBox()
        {
            try
            {
                if (Memory.IsDesignMode) return;
                #region Load Item for combox Chuyen xu
                DataTable tblLoaiBiTich = new DataTable();
                tblLoaiBiTich.Columns.Add("Value", typeof(int));
                tblLoaiBiTich.Columns.Add("Text", typeof(string));

                DataRow row1 = tblLoaiBiTich.NewRow();
                row1["Value"] = 0; row1["Text"] = GxConstants.LOAIBT_RUATOI;
                tblLoaiBiTich.Rows.Add(row1);

                DataRow row2 = tblLoaiBiTich.NewRow();
                row2["Value"] = 1; row2["Text"] = GxConstants.LOAIBT_RUOCLE;
                tblLoaiBiTich.Rows.Add(row2);

                DataRow row3 = tblLoaiBiTich.NewRow();
                row3["Value"] = 2; row3["Text"] = GxConstants.LOAIBT_THEMSUC;
                tblLoaiBiTich.Rows.Add(row3);

                this.Combo.DataSource = tblLoaiBiTich;
                this.Combo.ValueMember = "Value";
                this.Combo.DisplayMember = "Text";
                #endregion
            }
            catch { }
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridBiTichList != null)
            {
                if (uiComboBox1.SelectedValue == null) return;
                LoadData();
                gridBiTichList.RootTable.Columns[DotBiTichConst.LinhMuc].Caption = int.Parse(uiComboBox1.SelectedValue.ToString()) == 2 ? "Đức Giám Mục" : "Linh Mục";
            }
        }

        public void LoadData()
        {
            if (!Memory.IsDesignMode && gridBiTichList != null)
            {
                gridBiTichList.LoaiBiTich = Value;
            }
        }
    }
}
