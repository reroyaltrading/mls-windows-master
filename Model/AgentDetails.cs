using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "AgentDetails", Namespace = "urn:CREA.Search.Property")]
    public class AgentDetails
    {
        [XmlElement(ElementName = "Name", Namespace = "urn:CREA.Search.Property")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Phones", Namespace = "urn:CREA.Search.Property")]
        public Phones Phones { get; set; }
        [XmlElement(ElementName = "Websites", Namespace = "urn:CREA.Search.Property")]
        public Websites Websites { get; set; }
        [XmlElement(ElementName = "Office", Namespace = "urn:CREA.Search.Property")]
        public Office Office { get; set; }
        [XmlElement(ElementName = "Position", Namespace = "urn:CREA.Search.Property")]
        public string Position { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }

        public Int32 PropertyId { get; set; }

        public void Persist(int propertyId)
        {
            this.PropertyId = propertyId;
            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(AgentDetails));
            DatabaseControl.SendInsert(SqlInsert);

            this.Office.Persist(Int32.Parse(this.ID));
        }
    }
}
