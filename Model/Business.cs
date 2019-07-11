using CanadaHousing.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "Business", Namespace = "urn:CREA.Search.Property")]
    public class Business
    {
        [XmlElement(ElementName = "Franchise", Namespace = "urn:CREA.Search.Property")]
        public string Franchise { get; set; }

        public Int32 PropertyId { get; set; }

        public void Persist(int propertyId)
        {
            this.PropertyId = propertyId;

            String SqlInsert = ClassControl.SqlInsertFromObject(this, typeof(Building));
            DatabaseControl.SendInsert(SqlInsert);
        }
    }
}
