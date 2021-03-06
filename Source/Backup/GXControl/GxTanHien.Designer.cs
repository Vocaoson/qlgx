namespace GxControl
{
    partial class GxTanHien
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GxTanHien));
            this.chkHoiTuc = new System.Windows.Forms.CheckBox();
            this.txtNoiTu = new GxControl.GxTextField();
            this.cbChucVu = new GxControl.GxComboField();
            this.dtNgayBonMang = new GxControl.GxDateField();
            this.dtNgayThuPhongLM = new GxControl.GxDateField();
            this.dtNgayPhoTe = new GxControl.GxDateField();
            this.dtNgayKhanVinhVien = new GxControl.GxDateField();
            this.dtNgayKhanLanDau = new GxControl.GxDateField();
            this.dtNgayVaoNhaTap = new GxControl.GxDateField();
            this.dtNgayVaoNhaThu = new GxControl.GxDateField();
            this.dtNgayVaoDaiChungVien = new GxControl.GxDateField();
            this.dtNgayBatDau = new GxControl.GxDateField();
            this.txtGhiChu = new GxControl.GxTextField();
            this.txtEmailPhucVu = new GxControl.GxTextField();
            this.txtDienThoaiPhucVu = new GxControl.GxTextField();
            this.txtDiaChiPhucVu = new GxControl.GxTextField();
            this.txtNoiPhucVu = new GxControl.GxTextField();
            this.txtDongTu = new GxControl.GxTextField();
            this.SuspendLayout();
            // 
            // chkHoiTuc
            // 
            this.chkHoiTuc.AutoSize = true;
            this.chkHoiTuc.Location = new System.Drawing.Point(124, 400);
            this.chkHoiTuc.Name = "chkHoiTuc";
            this.chkHoiTuc.Size = new System.Drawing.Size(75, 17);
            this.chkHoiTuc.TabIndex = 17;
            this.chkHoiTuc.Text = "Đã hồi tục";
            this.chkHoiTuc.UseVisualStyleBackColor = true;
            // 
            // txtNoiTu
            // 
            this.txtNoiTu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiTu.AutoCompleteEnabled = true;
            this.txtNoiTu.AutoUpperFirstChar = true;
            this.txtNoiTu.BoxLeft = 120;
            this.txtNoiTu.EditEnabled = true;
            this.txtNoiTu.Label = "Địa chỉ";
            this.txtNoiTu.Location = new System.Drawing.Point(3, 137);
            this.txtNoiTu.MaxLength = 255;
            this.txtNoiTu.MultiLine = false;
            this.txtNoiTu.Name = "txtNoiTu";
            this.txtNoiTu.NumberInputRequired = true;
            this.txtNoiTu.NumberMode = false;
            this.txtNoiTu.ReadOnly = false;
            this.txtNoiTu.Size = new System.Drawing.Size(725, 27);
            this.txtNoiTu.TabIndex = 10;
            // 
            // cbChucVu
            // 
            this.cbChucVu.AutoUpperFirstChar = true;
            this.cbChucVu.BoxLeft = 120;
            this.cbChucVu.EditEnabled = true;
            this.cbChucVu.Label = "Chức vụ";
            this.cbChucVu.Location = new System.Drawing.Point(3, 170);
            this.cbChucVu.MaxLength = 0;
            this.cbChucVu.Name = "cbChucVu";
            this.cbChucVu.SelectedIndex = -1;
            this.cbChucVu.SelectedText = "";
            this.cbChucVu.SelectedValue = null;
            this.cbChucVu.Size = new System.Drawing.Size(325, 26);
            this.cbChucVu.TabIndex = 11;
            // 
            // dtNgayBonMang
            // 
            this.dtNgayBonMang.AutoUpperFirstChar = false;
            this.dtNgayBonMang.BoxLeft = 120;
            this.dtNgayBonMang.EditEnabled = true;
            this.dtNgayBonMang.FullInputRequired = false;
            this.dtNgayBonMang.IsNullDate = true;
            this.dtNgayBonMang.Label = "Ngày mừng bổn mạng";
            this.dtNgayBonMang.Location = new System.Drawing.Point(487, 67);
            this.dtNgayBonMang.Name = "dtNgayBonMang";
            this.dtNgayBonMang.Size = new System.Drawing.Size(237, 26);
            this.dtNgayBonMang.TabIndex = 8;
            this.dtNgayBonMang.Value = ((object)(resources.GetObject("dtNgayBonMang.Value")));
            // 
            // dtNgayThuPhongLM
            // 
            this.dtNgayThuPhongLM.AutoUpperFirstChar = false;
            this.dtNgayThuPhongLM.BoxLeft = 120;
            this.dtNgayThuPhongLM.EditEnabled = true;
            this.dtNgayThuPhongLM.FullInputRequired = false;
            this.dtNgayThuPhongLM.IsNullDate = true;
            this.dtNgayThuPhongLM.Label = "Ngày thụ phong LM";
            this.dtNgayThuPhongLM.Location = new System.Drawing.Point(244, 67);
            this.dtNgayThuPhongLM.Name = "dtNgayThuPhongLM";
            this.dtNgayThuPhongLM.Size = new System.Drawing.Size(237, 26);
            this.dtNgayThuPhongLM.TabIndex = 7;
            this.dtNgayThuPhongLM.Value = ((object)(resources.GetObject("dtNgayThuPhongLM.Value")));
            // 
            // dtNgayPhoTe
            // 
            this.dtNgayPhoTe.AutoUpperFirstChar = false;
            this.dtNgayPhoTe.BoxLeft = 120;
            this.dtNgayPhoTe.EditEnabled = true;
            this.dtNgayPhoTe.FullInputRequired = false;
            this.dtNgayPhoTe.IsNullDate = true;
            this.dtNgayPhoTe.Label = "Ngày lãnh chức phó tế";
            this.dtNgayPhoTe.Location = new System.Drawing.Point(3, 67);
            this.dtNgayPhoTe.Name = "dtNgayPhoTe";
            this.dtNgayPhoTe.Size = new System.Drawing.Size(237, 26);
            this.dtNgayPhoTe.TabIndex = 6;
            this.dtNgayPhoTe.Value = ((object)(resources.GetObject("dtNgayPhoTe.Value")));
            // 
            // dtNgayKhanVinhVien
            // 
            this.dtNgayKhanVinhVien.AutoUpperFirstChar = false;
            this.dtNgayKhanVinhVien.BoxLeft = 120;
            this.dtNgayKhanVinhVien.EditEnabled = true;
            this.dtNgayKhanVinhVien.FullInputRequired = false;
            this.dtNgayKhanVinhVien.IsNullDate = true;
            this.dtNgayKhanVinhVien.Label = "Ngày khấn vĩnh viễn";
            this.dtNgayKhanVinhVien.Location = new System.Drawing.Point(488, 35);
            this.dtNgayKhanVinhVien.Name = "dtNgayKhanVinhVien";
            this.dtNgayKhanVinhVien.Size = new System.Drawing.Size(237, 26);
            this.dtNgayKhanVinhVien.TabIndex = 5;
            this.dtNgayKhanVinhVien.Value = ((object)(resources.GetObject("dtNgayKhanVinhVien.Value")));
            // 
            // dtNgayKhanLanDau
            // 
            this.dtNgayKhanLanDau.AutoUpperFirstChar = false;
            this.dtNgayKhanLanDau.BoxLeft = 120;
            this.dtNgayKhanLanDau.EditEnabled = true;
            this.dtNgayKhanLanDau.FullInputRequired = false;
            this.dtNgayKhanLanDau.IsNullDate = true;
            this.dtNgayKhanLanDau.Label = "Ngày khấn lần đầu";
            this.dtNgayKhanLanDau.Location = new System.Drawing.Point(244, 35);
            this.dtNgayKhanLanDau.Name = "dtNgayKhanLanDau";
            this.dtNgayKhanLanDau.Size = new System.Drawing.Size(237, 26);
            this.dtNgayKhanLanDau.TabIndex = 4;
            this.dtNgayKhanLanDau.Value = ((object)(resources.GetObject("dtNgayKhanLanDau.Value")));
            // 
            // dtNgayVaoNhaTap
            // 
            this.dtNgayVaoNhaTap.AutoUpperFirstChar = false;
            this.dtNgayVaoNhaTap.BoxLeft = 120;
            this.dtNgayVaoNhaTap.EditEnabled = true;
            this.dtNgayVaoNhaTap.FullInputRequired = false;
            this.dtNgayVaoNhaTap.IsNullDate = true;
            this.dtNgayVaoNhaTap.Label = "Ngày vào nhà tập";
            this.dtNgayVaoNhaTap.Location = new System.Drawing.Point(3, 35);
            this.dtNgayVaoNhaTap.Name = "dtNgayVaoNhaTap";
            this.dtNgayVaoNhaTap.Size = new System.Drawing.Size(237, 26);
            this.dtNgayVaoNhaTap.TabIndex = 3;
            this.dtNgayVaoNhaTap.Value = ((object)(resources.GetObject("dtNgayVaoNhaTap.Value")));
            // 
            // dtNgayVaoNhaThu
            // 
            this.dtNgayVaoNhaThu.AutoUpperFirstChar = false;
            this.dtNgayVaoNhaThu.BoxLeft = 120;
            this.dtNgayVaoNhaThu.EditEnabled = true;
            this.dtNgayVaoNhaThu.FullInputRequired = false;
            this.dtNgayVaoNhaThu.IsNullDate = true;
            this.dtNgayVaoNhaThu.Label = "Ngày vào nhà thử";
            this.dtNgayVaoNhaThu.Location = new System.Drawing.Point(488, 3);
            this.dtNgayVaoNhaThu.Name = "dtNgayVaoNhaThu";
            this.dtNgayVaoNhaThu.Size = new System.Drawing.Size(237, 26);
            this.dtNgayVaoNhaThu.TabIndex = 2;
            this.dtNgayVaoNhaThu.Value = ((object)(resources.GetObject("dtNgayVaoNhaThu.Value")));
            // 
            // dtNgayVaoDaiChungVien
            // 
            this.dtNgayVaoDaiChungVien.AutoUpperFirstChar = false;
            this.dtNgayVaoDaiChungVien.BoxLeft = 120;
            this.dtNgayVaoDaiChungVien.EditEnabled = true;
            this.dtNgayVaoDaiChungVien.FullInputRequired = false;
            this.dtNgayVaoDaiChungVien.IsNullDate = true;
            this.dtNgayVaoDaiChungVien.Label = "Ngày vào ĐCV";
            this.dtNgayVaoDaiChungVien.Location = new System.Drawing.Point(244, 3);
            this.dtNgayVaoDaiChungVien.Name = "dtNgayVaoDaiChungVien";
            this.dtNgayVaoDaiChungVien.Size = new System.Drawing.Size(237, 26);
            this.dtNgayVaoDaiChungVien.TabIndex = 1;
            this.dtNgayVaoDaiChungVien.Value = ((object)(resources.GetObject("dtNgayVaoDaiChungVien.Value")));
            // 
            // dtNgayBatDau
            // 
            this.dtNgayBatDau.AutoUpperFirstChar = false;
            this.dtNgayBatDau.BoxLeft = 120;
            this.dtNgayBatDau.EditEnabled = true;
            this.dtNgayBatDau.FullInputRequired = false;
            this.dtNgayBatDau.IsNullDate = true;
            this.dtNgayBatDau.Label = "Ngày nhập dòng";
            this.dtNgayBatDau.Location = new System.Drawing.Point(3, 3);
            this.dtNgayBatDau.Name = "dtNgayBatDau";
            this.dtNgayBatDau.Size = new System.Drawing.Size(237, 26);
            this.dtNgayBatDau.TabIndex = 0;
            this.dtNgayBatDau.Value = ((object)(resources.GetObject("dtNgayBatDau.Value")));
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.AutoCompleteEnabled = true;
            this.txtGhiChu.AutoUpperFirstChar = true;
            this.txtGhiChu.BoxLeft = 120;
            this.txtGhiChu.EditEnabled = true;
            this.txtGhiChu.Label = "Ghi chú";
            this.txtGhiChu.Location = new System.Drawing.Point(3, 328);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.MultiLine = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.NumberInputRequired = true;
            this.txtGhiChu.NumberMode = false;
            this.txtGhiChu.ReadOnly = false;
            this.txtGhiChu.Size = new System.Drawing.Size(725, 66);
            this.txtGhiChu.TabIndex = 16;
            // 
            // txtEmailPhucVu
            // 
            this.txtEmailPhucVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailPhucVu.AutoCompleteEnabled = true;
            this.txtEmailPhucVu.AutoUpperFirstChar = true;
            this.txtEmailPhucVu.BoxLeft = 120;
            this.txtEmailPhucVu.EditEnabled = true;
            this.txtEmailPhucVu.Label = "Email  nơi phục vụ";
            this.txtEmailPhucVu.Location = new System.Drawing.Point(3, 297);
            this.txtEmailPhucVu.MaxLength = 255;
            this.txtEmailPhucVu.MultiLine = false;
            this.txtEmailPhucVu.Name = "txtEmailPhucVu";
            this.txtEmailPhucVu.NumberInputRequired = true;
            this.txtEmailPhucVu.NumberMode = false;
            this.txtEmailPhucVu.ReadOnly = false;
            this.txtEmailPhucVu.Size = new System.Drawing.Size(725, 25);
            this.txtEmailPhucVu.TabIndex = 15;
            // 
            // txtDienThoaiPhucVu
            // 
            this.txtDienThoaiPhucVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDienThoaiPhucVu.AutoCompleteEnabled = true;
            this.txtDienThoaiPhucVu.AutoUpperFirstChar = true;
            this.txtDienThoaiPhucVu.BoxLeft = 120;
            this.txtDienThoaiPhucVu.EditEnabled = true;
            this.txtDienThoaiPhucVu.Label = "Điện thoại nơi phục vụ";
            this.txtDienThoaiPhucVu.Location = new System.Drawing.Point(3, 266);
            this.txtDienThoaiPhucVu.MaxLength = 255;
            this.txtDienThoaiPhucVu.MultiLine = false;
            this.txtDienThoaiPhucVu.Name = "txtDienThoaiPhucVu";
            this.txtDienThoaiPhucVu.NumberInputRequired = true;
            this.txtDienThoaiPhucVu.NumberMode = false;
            this.txtDienThoaiPhucVu.ReadOnly = false;
            this.txtDienThoaiPhucVu.Size = new System.Drawing.Size(725, 25);
            this.txtDienThoaiPhucVu.TabIndex = 14;
            // 
            // txtDiaChiPhucVu
            // 
            this.txtDiaChiPhucVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChiPhucVu.AutoCompleteEnabled = true;
            this.txtDiaChiPhucVu.AutoUpperFirstChar = true;
            this.txtDiaChiPhucVu.BoxLeft = 120;
            this.txtDiaChiPhucVu.EditEnabled = true;
            this.txtDiaChiPhucVu.Label = "Địa chỉ nơi phục vụ";
            this.txtDiaChiPhucVu.Location = new System.Drawing.Point(3, 235);
            this.txtDiaChiPhucVu.MaxLength = 255;
            this.txtDiaChiPhucVu.MultiLine = false;
            this.txtDiaChiPhucVu.Name = "txtDiaChiPhucVu";
            this.txtDiaChiPhucVu.NumberInputRequired = true;
            this.txtDiaChiPhucVu.NumberMode = false;
            this.txtDiaChiPhucVu.ReadOnly = false;
            this.txtDiaChiPhucVu.Size = new System.Drawing.Size(725, 25);
            this.txtDiaChiPhucVu.TabIndex = 13;
            // 
            // txtNoiPhucVu
            // 
            this.txtNoiPhucVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiPhucVu.AutoCompleteEnabled = true;
            this.txtNoiPhucVu.AutoUpperFirstChar = true;
            this.txtNoiPhucVu.BoxLeft = 120;
            this.txtNoiPhucVu.EditEnabled = true;
            this.txtNoiPhucVu.Label = "Nơi phục vụ";
            this.txtNoiPhucVu.Location = new System.Drawing.Point(3, 204);
            this.txtNoiPhucVu.MaxLength = 255;
            this.txtNoiPhucVu.MultiLine = false;
            this.txtNoiPhucVu.Name = "txtNoiPhucVu";
            this.txtNoiPhucVu.NumberInputRequired = true;
            this.txtNoiPhucVu.NumberMode = false;
            this.txtNoiPhucVu.ReadOnly = false;
            this.txtNoiPhucVu.Size = new System.Drawing.Size(725, 25);
            this.txtNoiPhucVu.TabIndex = 12;
            // 
            // txtDongTu
            // 
            this.txtDongTu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDongTu.AutoCompleteEnabled = true;
            this.txtDongTu.AutoUpperFirstChar = true;
            this.txtDongTu.BoxLeft = 120;
            this.txtDongTu.EditEnabled = true;
            this.txtDongTu.Label = "Dòng tu/chủng viện";
            this.txtDongTu.Location = new System.Drawing.Point(3, 106);
            this.txtDongTu.MaxLength = 255;
            this.txtDongTu.MultiLine = false;
            this.txtDongTu.Name = "txtDongTu";
            this.txtDongTu.NumberInputRequired = true;
            this.txtDongTu.NumberMode = false;
            this.txtDongTu.ReadOnly = false;
            this.txtDongTu.Size = new System.Drawing.Size(725, 25);
            this.txtDongTu.TabIndex = 9;
            // 
            // GxTanHien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkHoiTuc);
            this.Controls.Add(this.txtNoiTu);
            this.Controls.Add(this.cbChucVu);
            this.Controls.Add(this.dtNgayBonMang);
            this.Controls.Add(this.dtNgayThuPhongLM);
            this.Controls.Add(this.dtNgayPhoTe);
            this.Controls.Add(this.dtNgayKhanVinhVien);
            this.Controls.Add(this.dtNgayKhanLanDau);
            this.Controls.Add(this.dtNgayVaoNhaTap);
            this.Controls.Add(this.dtNgayVaoNhaThu);
            this.Controls.Add(this.dtNgayVaoDaiChungVien);
            this.Controls.Add(this.dtNgayBatDau);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtEmailPhucVu);
            this.Controls.Add(this.txtDienThoaiPhucVu);
            this.Controls.Add(this.txtDiaChiPhucVu);
            this.Controls.Add(this.txtNoiPhucVu);
            this.Controls.Add(this.txtDongTu);
            this.Name = "GxTanHien";
            this.Size = new System.Drawing.Size(728, 431);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GxTextField txtNoiTu;
        private GxComboField cbChucVu;
        private GxDateField dtNgayBatDau;
        private GxTextField txtNoiPhucVu;
        private GxTextField txtDongTu;
        private GxTextField txtGhiChu;
        private System.Windows.Forms.CheckBox chkHoiTuc;
        private GxTextField txtDiaChiPhucVu;
        private GxTextField txtDienThoaiPhucVu;
        private GxTextField txtEmailPhucVu;
        private GxDateField dtNgayVaoDaiChungVien;
        private GxDateField dtNgayVaoNhaThu;
        private GxDateField dtNgayVaoNhaTap;
        private GxDateField dtNgayKhanLanDau;
        private GxDateField dtNgayKhanVinhVien;
        private GxDateField dtNgayPhoTe;
        private GxDateField dtNgayThuPhongLM;
        private GxDateField dtNgayBonMang;
    }
}
