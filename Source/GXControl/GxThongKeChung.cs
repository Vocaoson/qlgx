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
    public partial class GxThongKeChung : UserControl
    {
        string totalText = "";
        public GxThongKeChung()
        {
            InitializeComponent();
            gxGiaoDanList1.Visible = true;
            gxGiaoDanList1.Dock = DockStyle.Fill;
            gxGiaDinhList1.Visible = false;
            lblTotal.Text = "";
            dtDateFrom.Text = DateTime.Now.Year.ToString();
            gxGiaoDanList1.LoadDataFinished += new EventHandler(gxGiaoDanList1_LoadDataFinished);
            gxGiaDinhList1.LoadDataFinished += new EventHandler(gxGiaDinhList1_LoadDataFinished);
            //txtDateFrom.TextBox.KeyUp += new KeyEventHandler(TextBox_KeyUp);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtDateFrom.Text.Length >= 4 && ((e.KeyValue >= 96 && e.KeyValue <= 105) || (e.KeyValue >= 48 && e.KeyValue <= 57)))
            {
                dtDateTo.Focus();
            }
        }

        private void gxGiaDinhList1_LoadDataFinished(object sender, EventArgs e)
        {
            lblTotal.Text = "Tổng cộng: " + gxGiaDinhList1.RowCount.ToString() + totalText;
        }

        private void gxGiaoDanList1_LoadDataFinished(object sender, EventArgs e)
        {
            lblTotal.Text = "Tổng cộng: " + gxGiaoDanList1.RowCount.ToString() + totalText;
        }

        private void gxHonPhoiList1_LoadDataFinished(object sender, EventArgs e)
        {
            lblTotal.Text = "Tổng cộng: " + gxHonPhoiList1.RowCount.ToString() + totalText;
        }

        private bool checkYear()
        {
            if (dtDateFrom.IsNullDate && !rdGiaDinh.Checked)
            {
                Memory.ShowError("Hãy nhập từ ngày");
                return false;
            }
            return true;
        }

        private bool checkRadio()
        {
            foreach (Control ctl in uiGroupBox1.Controls)
            {
                if (ctl is GxRadioBox && (ctl as GxRadioBox).Checked)
                {
                    return true;
                }
            }
            MessageBox.Show("Hãy chọn một điều kiện thống kê");
            return false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtDateTo.IsNullDate)
            {
                dtDateTo.Value = dtDateFrom.Value;
            }

            if (!checkYear() || !checkRadio())
                return;

            int iDateFrom = int.Parse(Memory.GetIntOfDateFrom(dtDateFrom.DateInput.Day.Trim(), dtDateFrom.DateInput.Month.Trim(), dtDateFrom.DateInput.Year.Trim()));
            int iDateTo = int.Parse(Memory.GetIntOfDateTo(dtDateTo.DateInput.Day.Trim(), dtDateTo.DateInput.Month.Trim(), dtDateTo.DateInput.Year.Trim()));
            if (iDateFrom > iDateTo)
            {
                Memory.ShowError("Từ ngày không thể lớn hơn đến ngày");
                return;
            }

            string noDateSql = "";
            if (chkNullAccept.Checked)
            {
                noDateSql = " OR {0} IS NULL OR {0} = \"\"";
            }
            //TODO: review again GET MONTH
            string convertDateToInt = " INT(IIF(LEN([{0}])>=1,RIGHT([{0}], 4),\"0000\") " //year
                                + "& IIF(LEN([{0}])>=7,MID([{0}],4,2),IIF(LEN([{0}])=7,MID([{0}],1,2),\"00\")) "  //month
                                + "& IIF(LEN([{0}])=10,MID([{0}],1,2),\"00\")) ";//day
            string dateSql = string.Concat(" AND (", convertDateToInt, " BETWEEN ? AND ?) ");

            //nếu không phải search theo hôn phối
            if (!rdHonPhoi.Checked && !rdGiaDinh.Checked)
            {
                string where = " AND DaXoa=0 ";
                where += chkLuuTru.Checked ? "" : " AND DaChuyenXu=0 AND QuaDoi=0 ";
                if (rdSinhRa.Checked)
                {
                    where += string.Format(dateSql + noDateSql, GiaoDanConst.NgaySinh);
                    totalText = " người được sinh ra";
                }
                else if (rdRuaToi.Checked)
                {
                    where += string.Format(dateSql + noDateSql, GiaoDanConst.NgayRuaToi);
                    totalText = " người được rửa tội";
                }
                else if (rdRuocLe.Checked)
                {
                    where += string.Format(dateSql + noDateSql, GiaoDanConst.NgayRuocLe);
                    totalText = " người được xưng tội rước lễ lần đầu";
                }
                else if (rdThemSuc.Checked)
                {
                    where += string.Format(dateSql + noDateSql, GiaoDanConst.NgayThemSuc);
                    totalText = " người được thêm sức";
                }
                else if (rdQuaDoi.Checked)
                {
                    where = " AND QuaDoi<>0 ";
                    if (!chkLuuTru.Checked)
                    {
                        where += " AND DaXoa=0 AND DaChuyenXu=0 ";
                    }
                    if (chkNullAccept.Checked)
                    {
                        where += string.Format(dateSql + " OR ({0} IS NULL OR {0} = \"\")) ", GiaoDanConst.NgayQuaDoi);
                    }
                    else
                    {
                        where += string.Format(dateSql, GiaoDanConst.NgayQuaDoi);
                    }
                    totalText = " người qua đời";
                }
                else if (rdConSong.Checked)
                {
                    dtDateTo.Text = dtDateFrom.Text;
                    //where = " AND DaXoa=0 ";
                    //where += chkLuuTru.Checked ? "" : " AND DaChuyenXu=0 AND QuaDoi=0 ";
                    where += string.Format(" AND (" + convertDateToInt + " <= ? " + noDateSql + ")", GiaoDanConst.NgaySinh);
                    iDateFrom = iDateTo;
                    totalText = " giáo dân đến thời điểm được nhập";
                }
                else if (rdTanTong.Checked)
                {
                    where = " AND TanTong<>0 ";
                    if (!chkLuuTru.Checked)
                    {
                        where += " AND DaXoa=0 AND DaChuyenXu=0 ";
                    }
                    if (chkNullAccept.Checked)
                    {
                        where += string.Format(dateSql + " OR ({0} IS NULL OR {0} = \"\")) ", GiaoDanConst.NgayRuaToi);
                    }
                    else
                    {
                        where += string.Format(dateSql, GiaoDanConst.NgayRuaToi);
                    }
                    totalText = " tân tòng được rửa tội";
                }
                if (cbGiaoHo.MaGiaoHo > -1)
                {
                    where += string.Format(" AND (MaGiaoHo={0} OR MaGiaoHoCha={0}) ", cbGiaoHo.MaGiaoHo);
                }
                if (cbGiaoHo.MaGiaoHo > 0 || rdConSong.Checked) //neu thong ke 1 giao ho cu the hoac thong ke tong giao dan
                {
                    where += " AND GiaoDanAo=0 ";
                }

                gxGiaoDanList1.LoadData(SqlConstants.SELECT_GIAODAN_LIST_CO_GIAOHO + where, new object[] { iDateFrom, iDateTo });
                gxGiaoDanList1.Dock = DockStyle.Fill;
                gxGiaoDanList1.Visible = true;
                gxGiaDinhList1.Visible = false;
                gxHonPhoiList1.Visible = false;
            }
            else // Hon phoi
            {
                string where = "";
                if (rdHonPhoi.Checked)
                {
                    if (!Memory.CreateSELECT_HONPHOI_VIEW())
                    {
                        MessageBox.Show("Không thể lấy thông tin hôn phối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    totalText = " đôi chịu phép hôn phối";
                    where += string.Format(dateSql + noDateSql, HonPhoiConst.NgayHonPhoi);
                    //if (cbGiaoHo.MaGiaoHo > -1)
                    //{
                    //    where += string.Format(" AND (MaGiaoHo={0} OR MaGiaoHoCha={0}) ", cbGiaoHo.MaGiaoHo);
                    //}
                    gxHonPhoiList1.LoadData(string.Concat(SqlConstants.SELECT_HONPHOI_LIST, where), new object[] { iDateFrom, iDateTo });
                    gxHonPhoiList1.Dock = DockStyle.Fill;
                    gxGiaDinhList1.Visible = false;
                    gxGiaoDanList1.Visible = false;
                    gxHonPhoiList1.Visible = true;
                }
                else if (rdGiaDinh.Checked)
                {
                    where = " AND DaXoa=0 ";
                    if (cbGiaoHo.MaGiaoHo > 0) //neu thong ke 1 giao ho cu the
                    {
                        where += " AND GiaDinhAo=0 ";
                    }
                    where += chkLuuTru.Checked ? "" : " AND DaChuyenXu=0 ";
                    totalText = " gia đình";

                    if (cbGiaoHo.MaGiaoHo > -1)
                    {
                        where += string.Format(" AND (MaGiaoHo={0} OR MaGiaoHoCha={0}) ", cbGiaoHo.MaGiaoHo);
                    }
                    gxGiaDinhList1.LoadData(string.Concat(SqlConstants.SELECT_GIADINH_LIST, where), null);
                    gxGiaDinhList1.Dock = DockStyle.Fill;
                    gxGiaDinhList1.Visible = true;
                    gxGiaoDanList1.Visible = false;
                    gxHonPhoiList1.Visible = false;
                }
            }
            btnPrint.Enabled = true;
            btnFilter.Enabled = true;
        }

        private void txtYear_Leave(object sender, System.EventArgs e)
        {
            //txtDateFrom.Text = Memory.GetYear(txtDateFrom.Text).ToString();
        }

        private void gxGiaDinhList1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //EditRow();
        }

        private void frmThongKeChung_Load(object sender, EventArgs e)
        {
            cbGiaoHo.SelectedValue = -1;
            gxGiaoDanList1.FormatGrid();
            gxGiaDinhList1.FormatGrid();
            gxHonPhoiList1.ListMode = 2;
            gxHonPhoiList1.FormatGrid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gxGiaDinhList1.Visible && gxGiaDinhList1.RowCount > 0) gxGiaDinhList1.Print();
            else if (gxGiaoDanList1.Visible && gxGiaoDanList1.RowCount > 0) gxGiaoDanList1.Print();
            else if (gxHonPhoiList1.Visible && gxHonPhoiList1.RowCount > 0) gxHonPhoiList1.Print();
        }

        private void rd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdQuaDoi.Checked || rdSinhRa.Checked || rdHonPhoi.Checked || rdConSong.Checked || rdTanTong.Checked)
            {
                chkNullAccept.Enabled = true;
            }
            else
            {
                chkNullAccept.Checked = false;
                chkNullAccept.Enabled = false;
            }
            if(rdHonPhoi.Checked)
            {
                cbGiaoHo.SelectedValue = -1;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmFilter frm = new frmFilter();
            Dictionary<object, object> dic = new Dictionary<object, object>();
            if (gxGiaoDanList1.Visible)
            {
                dic.Add(GiaoDanConst.HoTen, "");
                frm.GrdData = gxGiaoDanList1;
            }
            else if(gxGiaDinhList1.Visible)
            {
                dic.Add(GiaDinhConst.TenGiaDinh, "");
                frm.GrdData = gxGiaDinhList1;
            }
            else if (gxHonPhoiList1.Visible)
            {
                dic.Add(GxConstants.NAM, "");
                frm.GrdData = gxHonPhoiList1;
            }
            frm.FilterParameter = dic;
            frm.ShowDialog();
        }
    }
}