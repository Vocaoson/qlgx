using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;

namespace GxControl
{
    public partial class frmChonDuLieu : frmBase
    {
        private string whereSQL = "";

        public string WhereSQL
        {
            get { return whereSQL; }
            set { whereSQL = value; }
        }

        public frmChonDuLieu()
        {
            InitializeComponent();
            this.HelpKey = "thao_tac_chung";
            //uiGroupBox1.Height = 0;
            cbGiaoHo.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);
            cbGiaoHo.HasShowAll = true;
            gxCommand1.OKIsAccept = true;
            if (this.loaiTimKiem == LoaiTimKiem.GiaoDan)
            {
                this.Text = "Chọn giáo dân";
            }
            else if (this.loaiTimKiem == LoaiTimKiem.GiaoDan)
            {
                this.Text = "Chọn gia đình";
            }
            this.gxGiaoDanList1.AllowShowForm = false;
            this.gxGiaoDanList1.AllowContextMenu = false;
            this.gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);
            this.gxGiaDinhList1.LoadDataFinished += new EventHandler(gxGiaDinhList1_LoadDataFinished);
        }

        private void gxGiaDinhList1_LoadDataFinished(object sender, EventArgs e)
        {
            gxFilter1.GrdData = gxGiaDinhList1;
        }

        private void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            gxFilter1.GrdData = gxGiaoDanList1;
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGiaoHo.Combo.SelectedIndex >= 0)
            {
                uiGroupBox1.Visible = true;
                //uiGroupBox1.Height = 92;
            }
            else
            {
                uiGroupBox1.Visible = false;
                //uiGroupBox1.Height = 0;
            }

            Dictionary<object, object> dicDefault = new Dictionary<object, object>();

            if (loaiTimKiem == LoaiTimKiem.GiaoDan)
            {
                if (gxGiaoDanList1 != null && gxGiaoDanList1.DataSource != null)
                {
                    gxGiaoDanList1.FormatGrid();
                    gxFilter1.GrdData = gxGiaoDanList1;
                    dicDefault.Add(GiaoDanConst.HoTen, "");
                    gxFilter1.FilterParameter = dicDefault;
                }
            }
            else if (loaiTimKiem == LoaiTimKiem.GiaDinh)
            {
                if (gxGiaDinhList1 != null && gxGiaDinhList1.DataSource != null)
                {
                    gxGiaDinhList1.FormatGrid();
                    gxFilter1.GrdData = gxGiaDinhList1;
                    dicDefault.Add(GiaDinhConst.TenGiaDinh, "");
                    gxFilter1.FilterParameter = dicDefault;
                }
            }
        }

        private LoaiTimKiem loaiTimKiem = LoaiTimKiem.GiaoDan;

        public LoaiTimKiem LoaiTimKiem
        {
            get { return loaiTimKiem; }
            set
            {
                loaiTimKiem = value;
                if (value == LoaiTimKiem.GiaoDan)
                {
                    this.gxGiaoDanList1.AllowContextMenu = false;
                    gxGiaoDanList1.AllowShowForm = false;
                    
                    cbGiaoHo.GridGiaDinh = null;
                    cbGiaoHo.GridGiaoDan = gxGiaoDanList1;
                    gxGiaoDanList1.Dock = DockStyle.Fill;
                    gxGiaoDanList1.Visible = true;
                    gxGiaDinhList1.Visible = false;
                    this.Text = "Chọn giáo dân";
                }
                else if (value == LoaiTimKiem.GiaDinh)
                {
                    cbGiaoHo.GridGiaDinh= gxGiaDinhList1;
                    gxGiaDinhList1.Dock = DockStyle.Fill;
                    gxGiaDinhList1.Visible = true;
                    gxGiaoDanList1.Visible = false;
                    this.Text = "Chọn gia đình";
                }
            }
        }        

        private void gridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            gxCommand1_OnOK(sender, e);
        }

        private void gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            if (loaiTimKiem == LoaiTimKiem.GiaoDan)
            {
                if (gxGiaoDanList1.CurrentRow == null || (gxGiaoDanList1.CurrentRow.DataRow as DataRowView) == null)
                {
                    if (gxGiaoDanList1.RowCount > 0)
                    {
                        gxGiaoDanList1.Row = 0;
                    }
                    else
                    {
                        return;
                    }
                }
                dataReturn = (gxGiaoDanList1.CurrentRow.DataRow as DataRowView).Row;
            }
            else if (loaiTimKiem == LoaiTimKiem.GiaDinh)
            {
                if (gxGiaDinhList1.CurrentRow == null || (gxGiaDinhList1.CurrentRow.DataRow as DataRowView) == null)
                {
                    if (gxGiaDinhList1.RowCount > 0)
                    {
                        gxGiaDinhList1.Row = 0;
                    }
                    else
                    {
                        return;
                    }
                }
                dataReturn = (gxGiaDinhList1.CurrentRow.DataRow as DataRowView).Row;
            }
        }

        //private void LoadData()
        //{
        //    try
        //    {
        //        DataTable tbl = Memory.GetData("SELECT MaGiaoDan, HoTen, TenThanh, NgaySinh, GiaoHo.TenGiaoHo FROM GiaoDan LEFT JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo");
        //        if (tbl != null)
        //        {
        //            gridEX1.DataSource = tbl;
        //        }
        //    }
        //    catch { }
        //}

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmChonGiaoDan_Load(object sender, EventArgs e)
        {
            Dictionary<object, object> dicDefault = new Dictionary<object, object>();

            if (loaiTimKiem == LoaiTimKiem.GiaoDan)
            {
                gxGiaoDanList1.FormatGrid();
                gxFilter1.GrdData = gxGiaoDanList1;
                cbGiaoHo.GridGiaoDan = gxGiaoDanList1;
                dicDefault.Add(GiaoDanConst.HoTen, "");
                gxFilter1.FilterParameter = dicDefault;
            }
            else if (loaiTimKiem == LoaiTimKiem.GiaDinh)
            {
                gxGiaDinhList1.FormatGrid();
                gxFilter1.GrdData = gxGiaDinhList1;
                cbGiaoHo.GridGiaDinh = gxGiaDinhList1;
                dicDefault.Add(GiaDinhConst.TenGiaDinh, "");
                gxFilter1.FilterParameter = dicDefault;
            }
            cbGiaoHo.WhereSQL = whereSQL;
            if (Memory.CurrentGiaoHo > -1) cbGiaoHo.MaGiaoHo = Memory.CurrentGiaoHo;
        }
    }
}