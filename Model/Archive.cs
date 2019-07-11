using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Model
{
    public class Archive
    {
        public static String ReadFile(String FileName)
        {
            String Content = String.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    Content = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {

            }

            return Content;
        }

        public static Boolean CreateCommonFile(String Content, String Path)
        {
            // string path = String.Format(@"{0}\log_{1}{2}{3}{4}{5}{6}.log", Folder,
            //     DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(),
            //     DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString());

            try
            {

                // Delete the file if it exists.
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }

                // Create the file.
                using (FileStream fs = File.Create(Path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Content);
                    fs.Write(info, 0, info.Length);
                }

                return true;
            }

            catch (Exception ex)
            {

            }

            return false;
        }

        public static Boolean CreateFile(String Content, String Folder)
        {
            string path = String.Format(@"{0}\log_{1}{2}{3}{4}{5}{6}.log", Folder,
                DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(),
                DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString());

            try
            {

                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Content);
                    fs.Write(info, 0, info.Length);
                }

                return true;
            }

            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
