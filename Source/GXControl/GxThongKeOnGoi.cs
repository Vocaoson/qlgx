using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using Femiani.Forms.UI.Input;

namespace GxControl
{
    public partial class GxThongKeOnGoi : UserControl
    {
        string totalText = "";
        public GxThongKeOnGoi()
        {
            InitializeComponent();
            gxGiaoDanList1.Visible = true;
            gxGiaoDanList1.Dock = DockStyle.Fill;
            lblTotal.Text = "";
            dtDateFrom.Text = DateTime.Now.Year.ToString();
            gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);

            cbChucVu.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChucVu.Combo.Items.Add("");
            cbChucVu.Combo.Items.Add("Tu sĩ");
            cbChucVu.Combo.Items.Add("Chủng sinh");
            cbChucVu.Combo.Items.Add("Phó tế");
            cbChucVu.Combo.Items.Add("Linh mục");
            cbChucVu.Combo.Items.Add("Giám mục");
            cbChucVu.Combo.Items.Add("Khấn trọn");
            cbChucVu.Combo.Items.Add("Khác");
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtDateFrom.Text.Length >= 4 && ((e.KeyValue >= 96 && e.KeyValue <= 105) || (e.KeyValue >= 48 && e.KeyValue <= 57)))
            {
                dtDateTo.Focus();
            }
        }

        private void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            lblTotal.Text = "Tổng cộng: " + gxGiaoDanList1.RowCount.ToString() + totalText;
        }

        private bool checkYear()
        {
            if (dtDateFrom.IsNullDate)
            {
                Memory.ShowError("Hãy nhập từ ngày");
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtDateTo.IsNullDate)
            {
                dtDateTo.Value = dtDateFrom.Value;
            }

            int iDateFrom = int.Parse(Memory.GetIntOfDateFrom(dtDateFrom.DateInput.Day.Trim(), dtDateFrom.DateInput.Month.Trim(), dtDateFrom.DateInput.Year.Trim()));
            int iDateTo = int.Parse(Memory.GetIntOfDateTo(dtDateTo.DateInput.Day.Trim(), dtDateTo.DateInput.Month.Trim(), dtDateTo.DateInput.Year.Trim()));
            if (iDateFrom > iDateTo)
            {
                Memory.ShowError("Từ ngày không thể lớn hơn đến ngày");
                return;
            }

            if (!checkYear())
                return;
            string noDateSql = "";
            if (chkNullAccept.Checked)
            {
                noDateSql = " OR {0} IS NULL OR {0} = \"\"";
            }
            string convertDateToInt = " INT(IIF(LEN([{0}])>=1,RIGHT([{0}], 4),\"0000\") " //year
                    + "& IIF(LEN([{0}])>=7,MID([{0}],4,2),IIF(LEN([{0}])=7,MID([{0}],1,2),\"00\")) "  //month
                    + "& IIF(LEN([{0}])=10,MID([{0}],1,2),\"00\")) ";//day
            string dateSql = string.Concat(" AND (", convertDateToInt, " BETWEEN ? AND ?) ");

            string sql = @"SELECT * " +
                @"FROM (SELECT GiaoDan.*, GiaoHo.TenGiaoHo, IIF(ChuyenXu.MaGiaoDan IS NOT NULL,-1,0) AS DaChuyenXu,
                                                            IIF(GiaoDan.NgaySinh IS NOT NULL,RIGHT(GiaoDan.NgaySinh,4),"""") AS NamSinh,
                                                            TanHien.NgayBatDau,TanHien.MaTanHien,TanHien.ChucVu,TanHien.NoiTu,TanHien.DongTu,TanHien.NoiPhucVu
                                                            FROM (
                                                                    ((SELECT DISTINCT ChuyenXu.MaGiaoDan
                                                                    FROM ChuyenXu WHERE LoaiChuyen=2
                                                                    GROUP BY ChuyenXu.MaGiaoDan) AS ChuyenXu 
                                                                RIGHT JOIN GiaoDan ON ChuyenXu.MaGiaoDan = GiaoDan.MaGiaoDan
                                                                ) LEFT JOIN GiaoHo ON GiaoDan.MaGiaoHo = GiaoHo.MaGiaoHo)
                                                                INNER JOIN TanHien ON GiaoDan.MaGiaoDan=TanHien.MaGiaoDan) WHERE 1 ";
            
            //tao cau dieu kien
            string where = " AND DaXoa=0 AND GiaoDanAo=0 ";
            where += chkLuuTru.Checked ? "" : " AND DaChuyenXu=0 AND QuaDoi=0 ";
            where += string.Format(dateSql + noDateSql, TanHienConst.NgayBatDau);
            string chucvu = "%";
            string noitu = "%";
            string dongtu = "%";
            string noiphucvu = "%";
            if (cbChucVu.Text != "")
            {
                chucvu += cbChucVu.Text + "%";
            }

            if (txtNoiTu.Text != "")
            {
                noitu += txtNoiTu.Text + "%";
            }

            if (txtDongTu.Text != "")
            {
                dongtu += txtDongTu.Text + "%";
            }

            if (txtNoiPhucVu.Text != "")
            {
                noiphucvu += txtNoiPhucVu.Text + "%";
            }

            where += " AND ChucVu LIKE ? AND NoiTu LIKE ? AND DongTu LIKE ? AND NoiPhucVu LIKE ? ";

            totalText = " người theo ơn gọi";
            gxGiaoDanList1.LoadData(sql + where, new object[] { iDateFrom, iDateTo, chucvu, noitu, dongtu, noiphucvu });

            btnPrint.Enabled = true;
            btnFilter.Enabled = true;
        }

        private void txtYear_Leave(object sender, System.EventArgs e)
        {
            //txtDateFrom.Text = Memory.GetYear(txtDateFrom.Text).ToString();
        }

        private void frmThongKeOnGoi_Load(object sender, EventArgs e)
        {
            if (Memory.IsDesignMode) return;
            cbGiaoHo.SelectedValue = -1;
            gxGiaoDanList1.FormatGrid();
            DataTable tblNoiTu = Memory.GetData("SELECT DISTINCT NoiTu FROM TanHien");
            DataTable tblDongTu = Memory.GetData("SELECT DISTINCT DongTu FROM TanHien");
            DataTable tblNoiPhucVu = Memory.GetData("SELECT DISTINCT NoiPhucVu FROM TanHien");

            //Load auto complete for Noi Tu
            AutoCompleteEntryCollection Items = new AutoCompleteEntryCollection();
            foreach (DataRow row in tblNoiTu.Rows)
            {
                Items.Add(new AutoCompleteEntry(row[TanHienConst.NoiTu].ToString(), row[TanHienConst.NoiTu].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
            }
            txtNoiTu.TextBox.Items = Items;

            //Load auto complete for Dong Tu
            Items = new AutoCompleteEntryCollection();
            foreach (DataRow row in tblDongTu.Rows)
            {
                Items.Add(new AutoCompleteEntry(row[TanHienConst.DongTu].ToString(), row[TanHienConst.DongTu].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
            }
            txtDongTu.TextBox.Items = Items;

            //Load auto complete for Noi Phuc Vu
            Items = new AutoCompleteEntryCollection();
            foreach (DataRow row in tblNoiPhucVu.Rows)
            {
                Items.Add(new AutoCompleteEntry(row[TanHienConst.NoiPhucVu].ToString(), row[TanHienConst.NoiPhucVu].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
            }
            txtNoiPhucVu.TextBox.Items = Items;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gxGiaoDanList1.Print();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmFilter frm = new frmFilter();
            Dictionary<object, object> dic = new Dictionary<object, object>();
            if (gxGiaoDanList1.Visible)
            {
                dic.Add(GiaoDanConst.HoTen, "");
            }
            else
            {
                dic.Add(GiaDinhConst.TenGiaDinh, "");
            }
            frm.GrdData = gxGiaoDanList1;
            frm.FilterParameter = dic;
            frm.ShowDialog();
        }
    }
}