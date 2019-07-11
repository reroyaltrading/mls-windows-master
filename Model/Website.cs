using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Website", Namespace = "urn:CREA.Search.Property")]
    public class Website
    {
        [XmlAttribute(AttributeName = "ContactType")]
        public string ContactType { get; set; }
        [XmlAttribute(AttributeName = "WebsiteType")]
        public string WebsiteType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
