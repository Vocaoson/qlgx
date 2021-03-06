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
    public partial class frmLoadDataProcess : frmBase
    {
        public event EventHandler OnError = null;
        public event EventHandler OnFinished = null;

        private string query = "";

        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        private object[] parameters = null;

        public object[] Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public frmLoadDataProcess()
        {
            InitializeComponent();
        }

        public void Execute()
        {
            try
            {
                //DataTable tbl = Memory.GetData(query, parameters);
                DataProvider provider = new DataProvider(Memory.AppPath + GxConstants.DB_FILENAME, GxConstants.DB_USER, GxConstants.DB_PASSWORD);
                DataTable tbl = provider.GetData(query, parameters);
                if (!Memory.ShowError() && tbl != null)
                {
                    if (OnFinished != null) OnFinished(tbl, EventArgs.Empty);
                }
                else
                {
                    if (OnError != null) OnError("", EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmLoadDataProcess, Execute)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (OnError != null) OnError("Exception", EventArgs.Empty);
            }
            finally 
            {
                this.Dispose();
            }
        }
    }
}