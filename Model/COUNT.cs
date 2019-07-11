using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "COUNT")]
    public class COUNT
    {
        [XmlAttribute(AttributeName = "Records")]
        public string Records { get; set; }
    }
}
