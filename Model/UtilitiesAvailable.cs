using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "UtilitiesAvailable", Namespace = "urn:CREA.Search.Property")]
    public class UtilitiesAvailable
    {
        [XmlElement(ElementName = "Utility", Namespace = "urn:CREA.Search.Property")]
        public List<Utility> Utility { get; set; }
    }
}
