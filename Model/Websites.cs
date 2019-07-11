using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Websites", Namespace = "urn:CREA.Search.Property")]
    public class Websites
    {
        [XmlElement(ElementName = "Website", Namespace = "urn:CREA.Search.Property")]
        public List<Website> Website { get; set; }
    }
}
