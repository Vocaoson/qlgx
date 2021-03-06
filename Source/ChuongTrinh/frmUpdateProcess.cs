using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using GXControl;
using GXGlobal;
using System.Threading;
using System.IO;

namespace GiaoXu
{
    public partial class frmUpdateProcess : frmBase
    {
        public frmUpdateProcess()
        {
            InitializeComponent();
        }

        private void frmUpdateProcess_Load(object sender, System.EventArgs e)
        {
            UpdateProcess update = new UpdateProcess();
            update.OnStart += new EventHandler(update_OnStart);
            update.OnError += new EventHandler(update_OnError);
            update.OnExecuting += new EventHandler(update_OnExecuting);
            update.OnFinished += new EventHandler(update_OnFinished);
            ThreadStart threadStart = new ThreadStart(update.Execute);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        void update_OnFinished(object sender, EventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnFinished);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                label1.Text = "Đã cập nhật xong!";
                MarkUpdated();
                this.Close();
            }  
        }

        void update_OnExecuting(object sender, EventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnExecuting);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                label1.Text = sender.ToString();
            }
        }

        void update_OnError(object sender, EventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnError);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                label1.Text = sender.ToString();
            }
        }

        void update_OnStart(object sender, EventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                EventHandler d = new EventHandler(update_OnStart);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                label1.Text = "Đang cập nhật chương trình lên phiên bản mới...";
            }
        }

        public void MarkUpdated()
        {
            try
            {
                StreamWriter sw = new StreamWriter(Memory.AppPath + GXConstants.VERSION_UPDATE_MARK_FILE, false);
                sw.Write(Memory.GetExeFileVersion());
                sw.Close();
            }
            catch
            {

            }
        }
    }
}