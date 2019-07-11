using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Rooms", Namespace = "urn:CREA.Search.Property")]
    public class Rooms
    {
        [XmlElement(ElementName = "Room", Namespace = "urn:CREA.Search.Property")]
        public List<Room> Room { get; set; }
    }
}
