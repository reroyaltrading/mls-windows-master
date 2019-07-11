using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Utility", Namespace = "urn:CREA.Search.Property")]
    public class Utility
    {
        [XmlElement(ElementName = "Type", Namespace = "urn:CREA.Search.Property")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "urn:CREA.Search.Property")]
        public string Description { get; set; }
    }
}
