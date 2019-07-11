using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Office", Namespace = "urn:CREA.Search.Property")]
    public class Office
    {
        [XmlElement(ElementName = "Name", Namespace = "urn:CREA.Search.Property")]
        public string Name { get; set; }
        [XmlElement(ElementName = "LogoLastUpdated", Namespace = "urn:CREA.Search.Property")]
        public string LogoLastUpdated { get; set; }
        [XmlElement(ElementName = "Address", Namespace = "urn:CREA.Search.Property")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "Phones", Namespace = "urn:CREA.Search.Property")]
        public Phones Phones { get; set; }
        [XmlElement(ElementName = "Websites", Namespace = "urn:CREA.Search.Property")]
        public Websites Websites { get; set; }
        [XmlElement(ElementName = "OrganizationType", Namespace = "urn:CREA.Search.Property")]
        public string OrganizationType { get; set; }
        [XmlElement(ElementName = "Franchisor", Namespace = "urn:CREA.Search.Property")]
        public string Franchisor { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "LastUpdated")]
        public string LastUpdated { get; set; }

        public Int32 AgentId { get; set; }

        public void Persist(int agentId)
        {
            this.AgentId = agentId;
            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(Office));
            DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
