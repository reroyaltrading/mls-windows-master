using CanadaHousing.Controller;
using CanadaHousing.Model;
using CanadaHousing.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanadaHousing
{
    public partial class Form1 : Form
    {
        public AppSettings appSettings { get; set; }

        public Form1(AppSettings appSettings)
        {
            InitializeComponent();
            this.appSettings = appSettings;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            formSettings settings = new formSettings(AppSettings.GetAppSettings());
            settings.ShowDialog();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderControl.OpenFolder(AppSettings.GetAppSettings().load_folder);
        }

        private void btnUpdateIndex_Click(object sender, EventArgs e)
        {
            formIndexUpdate formIndex = new formIndexUpdate();
            formIndex.ShowDialog();
        }

        private void btnStartCrawling_Click(object sender, EventArgs e)
        {
            formLoadData loadData = new formLoadData();
            loadData.ShowDialog();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            formSyncDatabase formSync = new formSyncDatabase();
            formSync.ShowDialog();
        }
    }
}
