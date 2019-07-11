using CanadaHousing.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanadaHousing
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*String AppSettingsFile = String.Concat(AppSettings.CurrentFolder, @"\", AppSettings.FILE_NAME);
            if (!File.Exists(AppSettingsFile))
            {
                Archive.CreateFile(AppSettings.GetAppSettings().ToJson(), AppSettingsFile);
            }*/
            Application.Run(new Form1(AppSettings.GetAppSettings()));
        }
    }
}
