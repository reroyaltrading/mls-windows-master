using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Phone", Namespace = "urn:CREA.Search.Property")]
    public class Phone
    {
        [XmlAttribute(AttributeName = "ContactType")]
        public string ContactType { get; set; }
        [XmlAttribute(AttributeName = "PhoneType")]
        public string PhoneType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
