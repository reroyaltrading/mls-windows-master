using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Controller
{
    public class FolderControl
    {
        public static void OpenFolder(String folder)
        {
            try
            {
                // opens the folder in explorer
                Process.Start(folder);
                // opens the folder in explorer
                Process.Start("explorer.exe", folder);
            }catch(Exception ex)
            {

            }
        }
    }
}
