using CanadaHousing.Core;
using CanadaHousing.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanadaHousing.Views
{
    public partial class formIndexUpdate : Form
    {
        AppSettings appSettings
        {
            get
            {
                return AppSettings.GetAppSettings();
            }
        }

        StringBuilder builder;

        public formIndexUpdate()
        {
            builder = new StringBuilder();
            InitializeComponent();
            builder.AppendLine(String.Format("Index file will be created at '{0}'", String.Concat(appSettings.load_folder, @"\index.xml")));
            textBox1.Text = builder.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            builder.AppendLine("Process is starting, please wait");
            textBox1.Text = builder.ToString();

            if (Crawler.GetIndex())
            {
                MessageBox.Show("App index saved", "IDX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("App index could not be saved", "IDX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            builder = new StringBuilder();
        }
    }
}
