using CanadaHousing.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanadaHousing.Views
{
    public partial class formLoadData : Form
    {
        public StringBuilder builder { get; set; }
        public Thread thread { get; set; }

        public delegate void UpdateProgressBarDelegate(int total, int count);   
        public UpdateProgressBarDelegate UpdateProgressBar;

        public delegate void UpdateTextLogDelegate(string id);
        public UpdateTextLogDelegate UpdateTextLog;

        public delegate void UpdateTextLabelDelegate(int count, int total);
        public UpdateTextLabelDelegate UpdateTextLabel;

        public void UpdateProgressBarMethod(int total, int count)
        {
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Value = (int) count / total;
        }

        public void UpdateTextLabelMethod(int count, int total)
        {
            this.lblCurrent.Text = String.Format("Current: {0} - {1}% from {2}", count, ((double)(count / total)).ToString("0.####"), total);
        }

        public void UpdateTextLogMethod(string id)
        {
            this.builder.AppendLine(String.Format("Grabing data from #{0}", id));
            this.txtLog.Text = this.builder.ToString();
        }

        public formLoadData()
        {
            InitializeComponent();
            this.builder = new StringBuilder();

            this.txtLog.Text = this.builder.ToString();

            UpdateProgressBar = new UpdateProgressBarDelegate(this.UpdateProgressBarMethod);
            UpdateTextLabel = new UpdateTextLabelDelegate(this.UpdateTextLabelMethod);
            UpdateTextLog = new UpdateTextLogDelegate(this.UpdateTextLogMethod);
        }

        private void btnGrabData_Click(object sender, EventArgs e)
        {
            this.thread = new Thread(() =>
            {
                Crawler.GrabAllData(chkUpdateDatabase.Checked, !chkAvoidSaveDataOnDisc.Checked, this);
            });

            if (thread.ThreadState != ThreadState.Running)
            {
               thread.Start();
                this.btnStopProcess.Visible = true;
                this.btnGrabData.Enabled = false;
            }
            else
            {
              thread.Abort();
            }
        }

        public void UpdateLabelWithInvoke(int total, int count)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateTextLabelDelegate(UpdateTextLabelMethod), total, count);
            }
            else
            {
                this.lblCurrent.Text = String.Format("Current: {0} - {1}% from {2}", count, ((double)(count / total)).ToString("0.####"), total);
            }
        }

        public void RunWithInvoke(int total, int count)
        {
            progressBar1.Maximum = 100;

            int value = (int)(count / total);

            if ( value < progressBar1.Maximum)
            {
                if (InvokeRequired)
                {
                    Invoke(new UpdateProgressBarDelegate(UpdateProgressBar), count, total);
                }
                else
                {
                    progressBar1.Value = value;
                }
            }
        }

        private void SetProgressValue(int value)
        {
            progressBar1.Value = value;
        }

        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            if(thread != null)
            {
                if(thread.ThreadState == ThreadState.Running)
                {
                    thread.Abort();
                }
            }

            this.btnStopProcess.Visible = false;
            this.btnGrabData.Enabled = true;
        }

     
        private void formLoadData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                if (thread.ThreadState == ThreadState.Running)
                {
                    thread.Abort();
                }
            }
        }
    }
}
