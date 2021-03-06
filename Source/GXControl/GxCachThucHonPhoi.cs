using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GxControl
{
    public partial class GxCachThucHonPhoi : GxComboField
    {
        public GxCachThucHonPhoi()
        {
            InitializeComponent();
            this.Combo.Items.Add("");
            this.Combo.Items.Add("Hợp pháp");
            this.Combo.Items.Add("Hợp thức hóa");
            this.Combo.Items.Add("Chuẩn");
            this.Combo.Items.Add("Không theo phép đạo");
            this.Combo.Items.Add("Ly thân");
            this.Combo.Items.Add("Ly dị");
            this.Combo.Items.Add("Đã được tháo gỡ");
            this.Combo.Items.Add("Không xác định");
            this.Combo.SelectedIndex = 0;
        }
    }
}
