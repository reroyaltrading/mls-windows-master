using CanadaHousing.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Utils
{
    public class Treatment
    {
        public static string Replaces(string v)
        {
            String temp = v.Replace("\"window.location", "window.location");
            //temp = temp.Replace("\", 500", ",500");
            temp = temp.Replace("\",500", " ");
            temp = temp.Replace("#", "");
            temp = temp.Replace("@", "");
            temp = temp.Replace("?", "");
            temp = temp.Replace("RETS-RESPONSE", "RETS_RESPONSE");
            temp = temp.Replace("?xml", "xml");
            temp = temp.Replace("\\r\\n", "");
            temp = temp.Replace(@"\", "");
            temp = temp.Replace("\"", @"\""");
            temp = temp.Replace("\\", "");
            temp = String.Concat(temp, "</xml>");
            return temp;
        }

        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static Stream StringToStream(string src)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(src);
            return new MemoryStream(byteArray);
        }

        public static int GetPhotosQuantity(Idx result)
        {
            if (result != null)
            {
                if (result.RETS != null)
                {
                    if (result.RETS.RETS_RESPONSE != null)
                    {
                        if (result.RETS.RETS_RESPONSE.PropertyDetails != null)
                        {
                            return result.RETS.RETS_RESPONSE.PropertyDetails.Photo.PropertyPhoto.Count;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
