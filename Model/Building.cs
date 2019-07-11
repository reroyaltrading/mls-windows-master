using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Building", Namespace = "urn:CREA.Search.Property")]
    public class Building
    {
        [XmlElement(ElementName = "BathroomTotal", Namespace = "urn:CREA.Search.Property")]
        public string BathroomTotal { get; set; }
        [XmlElement(ElementName = "BedroomsTotal", Namespace = "urn:CREA.Search.Property")]
        public string BedroomsTotal { get; set; }
        [XmlElement(ElementName = "BedroomsAboveGround", Namespace = "urn:CREA.Search.Property")]
        public string BedroomsAboveGround { get; set; }
        [XmlElement(ElementName = "BedroomsBelowGround", Namespace = "urn:CREA.Search.Property")]
        public string BedroomsBelowGround { get; set; }
        [XmlElement(ElementName = "Appliances", Namespace = "urn:CREA.Search.Property")]
        public string Appliances { get; set; }
        [XmlElement(ElementName = "BasementDevelopment", Namespace = "urn:CREA.Search.Property")]
        public string BasementDevelopment { get; set; }
        [XmlElement(ElementName = "BasementType", Namespace = "urn:CREA.Search.Property")]
        public string BasementType { get; set; }
        [XmlElement(ElementName = "ConstructedDate", Namespace = "urn:CREA.Search.Property")]
        public string ConstructedDate { get; set; }
        [XmlElement(ElementName = "ConstructionStyleAttachment", Namespace = "urn:CREA.Search.Property")]
        public string ConstructionStyleAttachment { get; set; }
        [XmlElement(ElementName = "CoolingType", Namespace = "urn:CREA.Search.Property")]
        public string CoolingType { get; set; }
        [XmlElement(ElementName = "ExteriorFinish", Namespace = "urn:CREA.Search.Property")]
        public string ExteriorFinish { get; set; }
        [XmlElement(ElementName = "FireplacePresent", Namespace = "urn:CREA.Search.Property")]
        public string FireplacePresent { get; set; }
        [XmlElement(ElementName = "FlooringType", Namespace = "urn:CREA.Search.Property")]
        public string FlooringType { get; set; }
        [XmlElement(ElementName = "FoundationType", Namespace = "urn:CREA.Search.Property")]
        public string FoundationType { get; set; }
        [XmlElement(ElementName = "HalfBathTotal", Namespace = "urn:CREA.Search.Property")]
        public string HalfBathTotal { get; set; }
        [XmlElement(ElementName = "Rooms", Namespace = "urn:CREA.Search.Property")]
        public Rooms Rooms { get; set; }
        [XmlElement(ElementName = "StoriesTotal", Namespace = "urn:CREA.Search.Property")]
        public string StoriesTotal { get; set; }
        [XmlElement(ElementName = "TotalFinishedArea", Namespace = "urn:CREA.Search.Property")]
        public string TotalFinishedArea { get; set; }
        [XmlElement(ElementName = "Type", Namespace = "urn:CREA.Search.Property")]
        public string Type { get; set; }
        [XmlElement(ElementName = "UtilityWater", Namespace = "urn:CREA.Search.Property")]
        public string UtilityWater { get; set; }

        public Int32 PropertyId { get; set; }

        public void Persist(int propertyId)
        {
            this.PropertyId = propertyId;

            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(Building));
            DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
