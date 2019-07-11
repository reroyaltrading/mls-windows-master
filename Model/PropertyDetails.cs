using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "PropertyDetails", Namespace = "urn:CREA.Search.Property")]
    public class PropertyDetails
    {
        [XmlElement(ElementName = "ListingID", Namespace = "urn:CREA.Search.Property")]
        public string ListingID { get; set; }
        [XmlElement(ElementName = "AgentDetails", Namespace = "urn:CREA.Search.Property")]
        public AgentDetails AgentDetails { get; set; }
        [XmlElement(ElementName = "Board", Namespace = "urn:CREA.Search.Property")]
        public string Board { get; set; }
        [XmlElement(ElementName = "Business", Namespace = "urn:CREA.Search.Property")]
        public Business Business { get; set; }
        [XmlElement(ElementName = "Building", Namespace = "urn:CREA.Search.Property")]
        public Building Building { get; set; }
        [XmlElement(ElementName = "Land", Namespace = "urn:CREA.Search.Property")]
        public Land Land { get; set; }
        [XmlElement(ElementName = "Address", Namespace = "urn:CREA.Search.Property")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "AmmenitiesNearBy", Namespace = "urn:CREA.Search.Property")]
        public string AmmenitiesNearBy { get; set; }
        [XmlElement(ElementName = "ListingContractDate", Namespace = "urn:CREA.Search.Property")]
        public string ListingContractDate { get; set; }
        [XmlElement(ElementName = "Photo", Namespace = "urn:CREA.Search.Property")]
        public Photo Photo { get; set; }
        [XmlElement(ElementName = "Price", Namespace = "urn:CREA.Search.Property")]
        public string Price { get; set; }
        [XmlElement(ElementName = "PropertyType", Namespace = "urn:CREA.Search.Property")]
        public string PropertyType { get; set; }
        [XmlElement(ElementName = "PublicRemarks", Namespace = "urn:CREA.Search.Property")]
        public string PublicRemarks { get; set; }
        [XmlElement(ElementName = "TransactionType", Namespace = "urn:CREA.Search.Property")]
        public string TransactionType { get; set; }
        [XmlElement(ElementName = "UtilitiesAvailable", Namespace = "urn:CREA.Search.Property")]
        public UtilitiesAvailable UtilitiesAvailable { get; set; }
        [XmlElement(ElementName = "AnalyticsClick", Namespace = "urn:CREA.Search.Property")]
        public string AnalyticsClick { get; set; }
        [XmlElement(ElementName = "AnalyticsView", Namespace = "urn:CREA.Search.Property")]
        public string AnalyticsView { get; set; }
        [XmlElement(ElementName = "MoreInformationLink", Namespace = "urn:CREA.Search.Property")]
        public string MoreInformationLink { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "LastUpdated")]
        public string LastUpdated { get; set; }

        public Int32 Persist()
        {
            this.AnalyticsClick = String.Empty;
            this.AnalyticsView = String.Empty;
            this.PublicRemarks = this.PublicRemarks.Replace("'", String.Empty);

            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(PropertyDetails));

            //Console.WriteLine(String.Empty);
            //Console.WriteLine(SqlInsert);
            //Console.WriteLine(String.Empty);

            DatabaseControl.SendInsert(SqlInsert);

            return Int32.Parse(this.ID.ToString());
        }
    }
}
