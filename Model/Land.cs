using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Land", Namespace = "urn:CREA.Search.Property")]
    public class Land
    {
        [XmlElement(ElementName = "SizeTotal", Namespace = "urn:CREA.Search.Property")]
        public string SizeTotal { get; set; }
        [XmlElement(ElementName = "SizeTotalText", Namespace = "urn:CREA.Search.Property")]
        public string SizeTotalText { get; set; }
        [XmlElement(ElementName = "Acreage", Namespace = "urn:CREA.Search.Property")]
        public string Acreage { get; set; }
        [XmlElement(ElementName = "FenceType", Namespace = "urn:CREA.Search.Property")]
        public string FenceType { get; set; }
        [XmlElement(ElementName = "LandDisposition", Namespace = "urn:CREA.Search.Property")]
        public string LandDisposition { get; set; }
        [XmlElement(ElementName = "SizeIrregular", Namespace = "urn:CREA.Search.Property")]
        public string SizeIrregular { get; set; }

        public Int32 PropertyId { get; set; }
        public void Persist(int propertyId)
        {
            this.PropertyId = propertyId;

            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(Land));
            DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
