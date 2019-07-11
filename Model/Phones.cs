using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Phones", Namespace = "urn:CREA.Search.Property")]
    public class Phones
    {
        [XmlElement(ElementName = "Phone", Namespace = "urn:CREA.Search.Property")]
        public List<Phone> Phone { get; set; }
    }
}
