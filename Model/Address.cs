using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Address", Namespace = "urn:CREA.Search.Property")]
    public class Address
    {

        public Int32 PropertyId { get; set; }
        [XmlElement(ElementName = "StreetAddress", Namespace = "urn:CREA.Search.Property")]
        public string StreetAddress { get; set; }
        [XmlElement(ElementName = "AddressLine1", Namespace = "urn:CREA.Search.Property")]
        public string AddressLine1 { get; set; }
        [XmlElement(ElementName = "City", Namespace = "urn:CREA.Search.Property")]
        public string City { get; set; }
        [XmlElement(ElementName = "Province", Namespace = "urn:CREA.Search.Property")]
        public string Province { get; set; }
        [XmlElement(ElementName = "PostalCode", Namespace = "urn:CREA.Search.Property")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "Country", Namespace = "urn:CREA.Search.Property")]
        public string Country { get; set; }

        [XmlElement(ElementName = "StreetNumber", Namespace = "urn:CREA.Search.Property")]
        public string StreetNumber { get; set; }
        [XmlElement(ElementName = "StreetName", Namespace = "urn:CREA.Search.Property")]
        public string StreetName { get; set; }
        [XmlElement(ElementName = "StreetSuffix", Namespace = "urn:CREA.Search.Property")]
        public string StreetSuffix { get; set; }
        [XmlElement(ElementName = "CommunityName", Namespace = "urn:CREA.Search.Property")]
        public string CommunityName { get; set; }

        public void Persist(int propertyId)
        {
            this.PropertyId = propertyId;
            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(Address));
            DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
