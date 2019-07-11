using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Pagination", Namespace = "urn:CREA.Search.Property")]
    public class Pagination
    {
        [XmlElement(ElementName = "TotalRecords", Namespace = "urn:CREA.Search.Property")]
        public string TotalRecords { get; set; }
        [XmlElement(ElementName = "Limit", Namespace = "urn:CREA.Search.Property")]
        public string Limit { get; set; }
        [XmlElement(ElementName = "Offset", Namespace = "urn:CREA.Search.Property")]
        public string Offset { get; set; }
        [XmlElement(ElementName = "TotalPages", Namespace = "urn:CREA.Search.Property")]
        public string TotalPages { get; set; }
        [XmlElement(ElementName = "RecordsReturned", Namespace = "urn:CREA.Search.Property")]
        public string RecordsReturned { get; set; }
    }
}
