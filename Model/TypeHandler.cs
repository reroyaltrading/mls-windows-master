using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Model
{
    public class TypeHandler
    {
        public static String Convert(Type type)
        {
            if (type == Type.TYPE_PHOTO)
            {
                return "Photo";
            }
            else if (type == Type.TYPE_LARGET_PHOTO)
            {
                return "LargePhoto";
            }
            else
            {
                return "Photo";
            }
        }
    }
}
