using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using GxControl;
using GxGlobal;
using System.Threading;
using System.IO;

namespace GiaoXu
{
    public partial class frmProcess : frmBase
    {
        private IGxProcess processClass = null;

        public IGxProcess ProcessClass
        {
            get { return processClass; }
            set { processClass = value; }
        }

        private string labelStart = "";

        public string LabelStart
        {
            get { return labelStart; }
            set { labelStart = value; }
        }

        private string lableFinished = "";

        public string LableFinished
        {
            get { return lableFinished; }
            set { lableFinished = value; }
        }

        public EventHandler FinishedFunction;
        public EventHandler StartFunction;
        public CancelEventHandler ErrorFunction;

        public frmProcess()
        {
            InitializeComponent();
        }

        private void frmUpdateProcess_Load(object sender, System.EventArgs e)
        {
            //UpdateProcess update = new UpdateProcess();
            if (processClass != null)
            {
                processClass.OnStart += new EventHandler(update_OnStart);
                processClass.OnError += new CancelEventHandler(update_OnError);
                processClass.OnExecuting += new EventHandler(update_OnExecuting);
                processClass.OnFinished += new EventHandler(update_OnFinished);
                ThreadStart threadStart = new ThreadStart(processClass.Execute);
                Thread thread = new Thread(threadStart);
                thread.Start();
            }
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
                label1.Text = lableFinished;
                this.progressBar1.Style = ProgressBarStyle.Blocks;
                if (FinishedFunction != null)
                {
                    FinishedFunction(sender, e);
                }
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

        void update_OnError(object sender, CancelEventArgs e)
        {
            if (this.progressBar1.InvokeRequired)
            {
                CancelEventHandler d = new CancelEventHandler(update_OnError);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                label1.Text = sender.ToString();
                if (ErrorFunction != null) ErrorFunction(sender, e);
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
                label1.Text = labelStart;
                if (StartFunction != null) StartFunction(sender, e);
            }
        }
    }
}