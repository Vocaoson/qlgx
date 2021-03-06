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
    public partial class GxGiaoHo : GxBaseField
    {
        protected bool choNhapMaRieng = false;

        public GxGiaoHo()
        {
            InitializeComponent();
            label1.Text = "Giáo họ";
            uiComboBox1.ComboStyle = ComboStyle.DropDownList;
            InitControl();
            LoadData();
            this.uiComboBox1.SelectedIndexChanged += new EventHandler(uiComboBox1_SelectedIndexChanged);
            choNhapMaRieng = (Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIADINH) == GxConstants.CF_TRUE);
        }

        private bool isLuuTru = false;

        public bool IsLuuTru
        {
            get { return isLuuTru; }
            set { isLuuTru = value; }
        }

        private Janus.Windows.GridEX.TriState isAo = Janus.Windows.GridEX.TriState.Empty;

        public Janus.Windows.GridEX.TriState IsAo
        {
            get { return isAo; }
            set { 
                isAo = value;
                if (autoLoadGrid)
                {
                    if (isAo == Janus.Windows.GridEX.TriState.True)
                    {
                        bool auto = this.autoLoadGrid;
                        this.autoLoadGrid = false;
                        this.SelectedValue = -1;//chọn "tất cả"
                        this.autoLoadGrid = auto;
                    }
                    LoadGridData();
                }
            }
        }

        public UIComboBox Combo
        {
            get { return uiComboBox1; }
        }

        private GxGiaoDanList gridGiaoDan = null;

        public GxGiaoDanList GridGiaoDan
        {
            get { return gridGiaoDan; }
            set { gridGiaoDan = value; gridGiaDinh = null; }
        }

        private GxGiaDinhList gridGiaDinh = null;

        public GxGiaDinhList GridGiaDinh
        {
            get { return gridGiaDinh; }
            set { gridGiaDinh = value; gridGiaoDan = null; }
        }

        private string whereSQL = "";

        public string WhereSQL
        {
            get { return whereSQL; }
            set { whereSQL = value; }
        }

        private bool autoLoadGrid = true;

        public bool AutoLoadGrid
        {
            get { return autoLoadGrid; }
            set { autoLoadGrid = value; }
        }

        public int MaGiaoHo
        {
            get
            {
                try
                {
                    return (int)uiComboBox1.SelectedValue;
                }
                catch
                {
                    return -1;
                }
            }
            set
            {
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

        private bool hasShowAll = false;

        public bool HasShowAll
        {
            get { return hasShowAll; }
            set
            {
                if (value)
                {
                    UIComboBoxItem item1 = new UIComboBoxItem("Tất cả");
                    item1.Value = -1;
                    this.uiComboBox1.Items.Insert(0, item1);
                    //SelectedValue = -1;
                }
                hasShowAll = value;
            }
        }

        private bool showNgoaiXu = true;

        public bool ShowNgoaiXu
        {
            get { return showNgoaiXu; }
            set 
            { 
                showNgoaiXu = value;
                if (value == true)
                {
                    UIComboBoxItem item1 = new UIComboBoxItem("Ngoài xứ", (object)0);
                    if (hasShowAll)
                    {
                        this.uiComboBox1.Items.Insert(1, item1);
                    }
                    else
                    {
                        this.uiComboBox1.Items.Insert(0, item1);
                    }
                }
            }
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoLoadGrid)
            {
                LoadGridData();
            }
            
            if (this.MaGiaoHo > 0) 
                Memory.CurrentGiaoHo = this.MaGiaoHo;
        }

        private void LoadGridData()
        {
            if (gridGiaoDan != null)
            {
                gridGiaoDan.Focus();
                string where = isLuuTru ? " AND (DaXoa=-1 OR DaChuyenXu=-1 OR QuaDoi=-1) " : " AND DaXoa=0 AND DaChuyenXu=0 AND QuaDoi=0 ";
                if (this.MaGiaoHo > -1)
                {
                    where += string.Format(" AND (MaGiaoHo={0}) ", this.MaGiaoHo);
                }
                if (this.MaGiaoHo != 0)
                {
                    if (isAo == Janus.Windows.GridEX.TriState.True)
                    {
                        where += " AND GiaoDanAo=-1 ";
                    }
                    else if (isAo == Janus.Windows.GridEX.TriState.False)
                    {
                        where += " AND GiaoDanAo=0 ";
                    }
                }
                gridGiaoDan.WhereSQL = where + whereSQL;
                gridGiaoDan.LoadData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO, null);
            }

            if (gridGiaDinh != null)
            {
                gridGiaDinh.Focus();
                string where = isLuuTru ? " AND (DaXoa=-1 OR DaChuyenXu=-1) " : " AND DaXoa=0 AND DaChuyenXu=0 ";
                if (this.MaGiaoHo > -1)
                {
                    where += string.Format(" AND ({0}={1}) ", GiaoHoConst.MaGiaoHo, this.MaGiaoHo);
                }
                if (isAo == Janus.Windows.GridEX.TriState.True)
                {
                    where += " AND GiaDinhAo=-1 ";
                }
                else if (isAo == Janus.Windows.GridEX.TriState.False)
                {
                    where += " AND GiaDinhAo=0 ";
                }
                string orderBy = " ORDER BY MaGiaDinh ASC ";
                if (choNhapMaRieng)
                {
                    orderBy = " ORDER BY MaGiaDinhRieng ASC ";
                }
                gridGiaDinh.WhereSQL = where + whereSQL + orderBy;
                gridGiaDinh.LoadData(SqlConstants.SELECT_GIADINH_LIST, null);
            }
        }

        protected override void InitControl()
        {
            editBase = uiComboBox1;
            base.InitControl();
        }

        private void LoadData()
        {
            try
            {
                if (Memory.IsDesignMode) return;

                DataTable tbl = Memory.GetData("SELECT * FROM GiaoHo ORDER BY TenGiaoHo ASC");
                
                if (tbl != null)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        UIComboBoxItem item = new UIComboBoxItem(row["TenGiaoHo"].ToString(), row["MaGiaoHo"]);
                        this.uiComboBox1.Items.Add(item);
                    }
                }
            }
            catch { }
        }

        private void GxGiaoHo_Load(object sender, EventArgs e)
        {
            //LoadData();
        }
    }
}
