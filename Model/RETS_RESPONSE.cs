using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "RETS_RESPONSE", Namespace = "urn:CREA.Search.Property")]
    public class RETS_RESPONSE
    {
        [XmlElement(ElementName = "Pagination", Namespace = "urn:CREA.Search.Property")]
        public Pagination Pagination { get; set; }
        [XmlElement(ElementName = "PropertyDetails", Namespace = "urn:CREA.Search.Property")]
        public PropertyDetails PropertyDetails { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
