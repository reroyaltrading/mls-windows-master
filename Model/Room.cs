using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Room", Namespace = "urn:CREA.Search.Property")]
    public class Room
    {
        [XmlElement(ElementName = "Type", Namespace = "urn:CREA.Search.Property")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Width", Namespace = "urn:CREA.Search.Property")]
        public string Width { get; set; }
        [XmlElement(ElementName = "Length", Namespace = "urn:CREA.Search.Property")]
        public string Length { get; set; }
        [XmlElement(ElementName = "Level", Namespace = "urn:CREA.Search.Property")]
        public string Level { get; set; }
        [XmlElement(ElementName = "Dimension", Namespace = "urn:CREA.Search.Property")]
        public string Dimension { get; set; }

        public int PropertyId { get; set; }

        public Boolean Persist(int PropertyId)
        {
            this.PropertyId = PropertyId;
            this.Dimension = this.Dimension.Replace("'", String.Empty);
            this.Level = this.Level.Replace("'", String.Empty);

            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(Room));
            return DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
