using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Photo", Namespace = "urn:CREA.Search.Property")]
    public class Photo
    {
        [XmlElement(ElementName = "PropertyPhoto", Namespace = "urn:CREA.Search.Property")]
        public List<PropertyPhoto> PropertyPhoto { get; set; }
    }
}
