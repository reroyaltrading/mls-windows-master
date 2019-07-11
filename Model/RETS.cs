using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "RETS")]
    public class RETS
    {
        [XmlElement(ElementName = "COUNT")]
        public COUNT COUNT { get; set; }
        [XmlElement(ElementName = "RETS_RESPONSE", Namespace = "urn:CREA.Search.Property")]
        public RETS_RESPONSE RETS_RESPONSE { get; set; }
        [XmlAttribute(AttributeName = "ReplyCode")]
        public string ReplyCode { get; set; }
        [XmlAttribute(AttributeName = "ReplyText")]
        public string ReplyText { get; set; }
    }
}
