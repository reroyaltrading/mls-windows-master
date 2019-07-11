using CanadaHousing.Controller;
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
    public partial class formSettings : Form
    {
        private AppSettings appSettings { get; set; }

        public formSettings(AppSettings appSettings)
        {
            InitializeComponent();

            this.appSettings = appSettings;

            txtDbName.Text = appSettings.db_name;
            txtDbPassword.Text = appSettings.db_password;
            txtDbServer.Text = appSettings.db_server;
            txtDbUser.Text = appSettings.db_user;
            txtIdxServer.Text = appSettings.idx_server;
            txtWorkingFolder.Text = appSettings.load_folder;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            appSettings.db_name = txtDbName.Text;
            appSettings.db_password = txtDbPassword.Text;
            appSettings.db_server = txtDbServer.Text;
            appSettings.db_user = txtDbUser.Text;
            appSettings.idx_server = txtIdxServer.Text;
            appSettings.load_folder = txtWorkingFolder.Text;

            if(appSettings.Save())
            {
                MessageBox.Show("App settings saved", "IDX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("App settings could not saved", "IDX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtWorkingFolder.Text = folderDlg.SelectedPath;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            appSettings.db_name = txtDbName.Text;
            appSettings.db_password = txtDbPassword.Text;
            appSettings.db_server = txtDbServer.Text;
            appSettings.db_user = txtDbUser.Text;

            if (DatabaseControl.TestConnection())
            {
                MessageBox.Show("Conection stabilished sucessfully", "IDX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Conection could not be stabilished sucessfully", "IDX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
