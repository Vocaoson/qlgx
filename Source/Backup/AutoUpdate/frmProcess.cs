using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AutoUpdate
{
    public partial class frmProcess : Form
    {
        AutoUpdate update = null;
        private UpdateProcessInformation information = null;
        private Thread thread = null;
        private ThreadStart threadStart = null;

        public UpdateProcessInformation Information
        {
            get { return update != null ? update.Information : null; }
        }

        public int CheckVersion()
        {
            if (update == null) update = new AutoUpdate();
            return update.CheckVersionInfo();
        }

        public frmProcess()
        {
            InitializeComponent();
        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("GiaoXu");
                    if (processes.Length > 0)
                    {
                        MessageBox.Show("Xin vui lòng đóng tất cả các chương trình QLGX đang chạy. Sau khi đóng xong tất cả, bấm nút OK để tiếp tục.");
                    }

                    foreach (System.Diagnostics.Process p in processes)
                    {
                        p.Kill();                        
                    }
                }
                catch
                { }
  
                //
                if (update == null)
                {
                    update = new AutoUpdate();
                    update.OnDownloading += new EventHandler(update_OnDownloading);
                    update.OnError += new EventHandler(update_OnError);
                    update.OnFinished += new EventHandler(update_OnFinished);
                    update.OnStart += new EventHandler(update_OnStart);
                }
                threadStart = new ThreadStart(update.Execute);
                thread = new Thread(threadStart);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Exception (frmProcess, frmProcess_Load)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void update_OnStart(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnStart);
                this.Invoke(d, new object[] { sender, e });
            }
            lblUpdating.Text = "Starting update...";
        }

        void update_OnFinished(object sender, EventArgs e)
        {
            if (this.lblUpdating.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnFinished);
                this.Invoke(d, new object[] { sender, e });
            }
            lblUpdating.Text = sender.ToString();
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.Close();
        }

        void update_OnError(object sender, EventArgs e)
        {
            try
            {
                if (this.lblUpdating.InvokeRequired)
                {
                    EventHandler d = new EventHandler(update_OnError);
                    this.Invoke(d, new object[] { sender, e });
                }
                lblUpdating.Text = sender.ToString();
                lblUpdating.Text = "Finished";
                this.progressBar1.Style = ProgressBarStyle.Blocks;
                this.progressBar1.Value = this.progressBar1.Minimum;
                MessageBox.Show(sender.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch { }
        }

        void update_OnDownloading(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnDownloading);
                this.Invoke(d, new object[] { sender, e });
            }
            lblUpdating.Text = "Downloading fle " + sender.ToString() + "...";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.ThreadState != ThreadState.Stopped)
            {
                try
                {
                    thread.Abort();
                }
                catch { }
            }
            this.Close();
        }
    }
}