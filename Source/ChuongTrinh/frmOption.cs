using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GxGlobal;
using GxControl;
using System.IO;

namespace GiaoXu
{
    public partial class frmOption : frmBase
    {
        public frmOption()
        {
            InitializeComponent();
            this.HelpKey = "tuy_chon";
            cbReportLang.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            string templatePath = Memory.AppPath + "Template";
            DirectoryInfo dir = new DirectoryInfo(templatePath);
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                cbTemplateFolder.Combo.Items.Add(subdir.Name);
            }
            cbReportLang.Combo.Items.Add("Tiếng Việt");
            cbReportLang.Combo.Items.Add("Tiếng Anh");
            gxCommand1.OKButton.Text = "&Cập nhật";
            txtMaxBackup.Text = "40";
            cbReportLang.Combo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);

            cmbFontList.Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            txtFontSize.Leave += new EventHandler(txtFontSize_Leave);
        }

        private void txtFontSize_Leave(object sender, EventArgs e)
        {
            if (!Validator.IsNumber(txtFontSize.Text.Trim()))
            {
                txtFontSize.Text = "8.25";
            }
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkUSName.Enabled = (cbReportLang.SelectedIndex == 1);
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            chkAutoUpdate.Checked = Memory.GetConfig(GxConstants.CF_AUTO_UPDATE) == GxConstants.CF_TRUE;
            string templateFolder = Memory.GetConfig(GxConstants.CF_TEMPLATE_FOLDER);
            if (templateFolder == "" || templateFolder == "vi-vn") templateFolder = "Chung";
            cbTemplateFolder.SelectedText = templateFolder;
            
            string language = Memory.GetConfig(GxConstants.CF_LANGUAGE);
            if (language == "") language = GxConstants.LANG_VN;
            if (language == GxConstants.LANG_EN)
            {
                cbReportLang.SelectedIndex = 1;
            }
            else
            {
                cbReportLang.SelectedIndex = 0;
            }

            string selectedFont = Memory.GetFontName();
            selectDefaultFont(selectedFont);
            txtFontSize.Text = Memory.GetFontSize().ToString();

            chkInHoSoLuuTru.Checked = Memory.GetConfig(GxConstants.CF_SOGIADINH_IN_LUUTRU) == GxConstants.CF_TRUE;
            chkInGachNgang.Checked = Memory.GetConfig(GxConstants.CF_SOGIADINH_IN_GACHNGANG) == GxConstants.CF_TRUE;
            chkInLapGiaDinh.Checked = Memory.GetConfig(GxConstants.CF_SOGIADINH_IN_LAPGD) == GxConstants.CF_TRUE;
            chkInMaGiaoDanThaySTT.Checked = Memory.GetConfig(GxConstants.CF_SOGIADINH_THAYSTT_MAGIAODAN) == GxConstants.CF_TRUE;
            chkUSName.Checked = Memory.GetConfig(GxConstants.CF_US_FORMAT_NAME) == GxConstants.CF_TRUE;
            chkSoGiaDinhInNoiSinh.Checked = Memory.GetConfig(GxConstants.CF_SOGIADINH_INNOISINH) == GxConstants.CF_TRUE;
            chkTuNhapMa.Checked = Memory.GetConfig(GxConstants.CF_TUNHAP_MAGIADINH) == GxConstants.CF_TRUE;
            chkTuChuanHoa.Checked = Memory.GetConfig(GxConstants.CF_CHUANHOA_TUCHUANHOA) == GxConstants.CF_TRUE;
            chkChuanHoaTuDoiDau.Checked = Memory.GetConfig(GxConstants.CF_CHUANHOA_TUDOIDAU) == GxConstants.CF_TRUE;
            chkHienGiaoDanDaChiuBiTich.Checked = Memory.GetConfig(GxConstants.CF_SOBITICH_HIENTATCAGIAODAN) == GxConstants.CF_TRUE;
            chkTuChuyenMa.Checked = Memory.GetConfig(GxConstants.CF_CHUANHOA_TUCHUYENMA) == GxConstants.CF_TRUE;
            txtMaxBackup.Text = Memory.GetConfig(GxConstants.CF_MAX_BACKUP) != "" ? Memory.GetConfig(GxConstants.CF_MAX_BACKUP) : "40";

            string chuanHoa = Memory.GetConfig(GxConstants.CF_CHUANHOA_TRONGNGOAC);
            if (chuanHoa == rdChuanHoaNormal.Tag.ToString() || chuanHoa == "") rdChuanHoaNormal.Checked = true;
            else if (chuanHoa == rdChuanHoaLowerCase.Tag.ToString()) rdChuanHoaLowerCase.Checked = true;
            else if (chuanHoa == rdChuanHoaUpperCase.Tag.ToString()) rdChuanHoaUpperCase.Checked = true;
            else if (chuanHoa == rdChuanHoaUpperCaseFirstChar.Tag.ToString()) rdChuanHoaUpperCaseFirstChar.Checked = true;
        }

        private void selectDefaultFont(string selectedFont)
        {
            List<string> lstFont = new List<string>();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                lstFont.Add(font.Name.ToLower());
                cmbFontList.Combo.Items.Add(font.Name);
            }
            if (lstFont.Contains(selectedFont.ToLower()))
            {
                cmbFontList.SelectedText = selectedFont;
            }
            else
            {
                cmbFontList.Combo.Items.Insert(0, selectedFont);
                cmbFontList.SelectedText = selectedFont;
            }
        }

        private void gxCommand1_OnOK(object sender, EventArgs e)
        {
            //for auto update
            Memory.SetConfig(GxConstants.CF_AUTO_UPDATE, chkAutoUpdate.Checked ? 1 : 0);
            //for template folder
            string templateFolder = cbTemplateFolder.Combo.Text;
            string language = "vi-vn";
            
            switch (cbReportLang.SelectedIndex)
            { 
                case 1:
                    language = GxConstants.LANG_EN;
                    break;
                default:
                    language = GxConstants.LANG_VN;
                    break;
            }
             
            Memory.SetConfig(GxConstants.CF_TEMPLATE_FOLDER, templateFolder);
            Memory.SetConfig(GxConstants.CF_LANGUAGE, language);
            //for so gia dinh
            Memory.SetConfig(GxConstants.CF_SOGIADINH_IN_LUUTRU, chkInHoSoLuuTru.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_SOGIADINH_IN_LAPGD, chkInLapGiaDinh.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_SOGIADINH_IN_GACHNGANG, chkInGachNgang.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_SOGIADINH_THAYSTT_MAGIAODAN, chkInMaGiaoDanThaySTT.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_US_FORMAT_NAME, chkUSName.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_SOGIADINH_INNOISINH, chkSoGiaDinhInNoiSinh.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_TUNHAP_MAGIADINH, chkTuNhapMa.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_CHUANHOA_TUDOIDAU, chkChuanHoaTuDoiDau.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_CHUANHOA_TUCHUANHOA, chkTuChuanHoa.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_SOBITICH_HIENTATCAGIAODAN, chkHienGiaoDanDaChiuBiTich.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_CHUANHOA_TUCHUYENMA, chkTuChuyenMa.Checked ? 1 : 0);
            Memory.SetConfig(GxConstants.CF_MAX_BACKUP, txtMaxBackup.Text);
            Memory.SetConfig(GxConstants.CF_FONT_NAME, cmbFontList.Text);
            Memory.SetConfig(GxConstants.CF_FONT_SIZE, txtFontSize.Text);

            //for chuan hoa
            string chuanHoa = "";
            if (rdChuanHoaLowerCase.Checked)
            {
                chuanHoa = rdChuanHoaLowerCase.Tag.ToString();
            }
            else if (rdChuanHoaNormal.Checked)
            {
                chuanHoa = rdChuanHoaNormal.Tag.ToString();
            }
            else if (rdChuanHoaUpperCase.Checked)
            {
                chuanHoa = rdChuanHoaUpperCase.Tag.ToString();
            }
            else if (rdChuanHoaUpperCaseFirstChar.Checked)
            {
                chuanHoa = rdChuanHoaUpperCaseFirstChar.Tag.ToString();
            }
            Memory.SetConfig(GxConstants.CF_CHUANHOA_TRONGNGOAC, chuanHoa);

            Memory.SaveConfig();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkInHoSoLuuTru_CheckedChanged(object sender, EventArgs e)
        {
            chkInGachNgang.Enabled = chkInHoSoLuuTru.Checked;
        }

        private void btnResetFont_Click(object sender, EventArgs e)
        {
            selectDefaultFont(GxConstants.DEFAULT_FONT_NAME);
            txtFontSize.Text = GxConstants.DEFAULT_FONT_SIZE.ToString();
        }

    }
}