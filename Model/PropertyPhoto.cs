using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "PropertyPhoto", Namespace = "urn:CREA.Search.Property")]
    public class PropertyPhoto
    {
        [XmlElement(ElementName = "SequenceId", Namespace = "urn:CREA.Search.Property")]
        public string SequenceId { get; set; }
        [XmlElement(ElementName = "LastUpdated", Namespace = "urn:CREA.Search.Property")]
        public string LastUpdated { get; set; }
        [XmlElement(ElementName = "PhotoLastUpdated", Namespace = "urn:CREA.Search.Property")]
        public string PhotoLastUpdated { get; set; }

        public string PhotoLocation { get; set; }

        public String PropertyId { get; set; }

        public void Persist(int propertyId)
        {
            this.PhotoLocation = String.Concat(propertyId, "_", (Int32.Parse(SequenceId) - 1), ".png");
            this.PropertyId = propertyId.ToString();

            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(PropertyPhoto));
            DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
