using CanadaHousing.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CanadaHousing.Model
{
    [XmlRoot(ElementName = "xml")]
    public class Idx
    {
        [XmlElement(ElementName = "RETS")]
        public RETS RETS { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "encoding")]
        public string Encoding { get; set; }

        #region Database Operation
        public static Boolean DeleteFromDatabase(Int32 Id)
        {
            String connectionString = DatabaseControl.GetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString); ;

            try
            {
                
                var command = conn.CreateCommand();

                MySqlDataReader rdr = null;
                conn.Open();

                string stm = String.Format("DELETE FROM md_propertydetails WHERE ID={0}", Id);
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                Int32 count = 0;

                while (rdr.Read())
                {
                    count++;
                    break;
                }

                return count > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Clone();
            }

            return false;
        }
        public static Boolean HasOnDatabase(Int32 Id)
        {
            String connectionString = DatabaseControl.GetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {              
                var command = conn.CreateCommand();

                MySqlDataReader rdr = null;
                conn.Open();

                string stm = String.Format("SELECT * FROM md_propertydetails WHERE ID={0}", Id);
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                Int32 count = 0;

                while (rdr.Read())
                {
                    count++;
                    break;
                }

                return count > 0;
            }catch(Exception ex)
            {

            }
            finally
            {
                conn.Clone();
            }

            return false;
         }
        public static Boolean UpdateAllPropertyesNotAvaliable()
        {
            return DatabaseControl.SendUpdate("UPDATE md_propertydetails SET Avaliable=0");
        }
        #endregion

        public void Persist(DumpJson Dump)
        {
            PropertyDetails property = this.RETS.RETS_RESPONSE.PropertyDetails;

            //if (HasOnDatabase(Int32.Parse(property.ID)))
            //{
                DeleteFromDatabase(Int32.Parse(property.ID));
            //}

            UpdateAllPropertyesNotAvaliable();

            Item current = new Item() { PropertyId = property.ID };
            current.Fail = property == null;

            //if (Dump.NotIn(property.ID))
            //{
            Dump.Items.Add(current);
            Dump.Save();
            //}

            if (property != null)
            {
                //if (Dump.NotIn(property.ID))
                //{
                    Int32 propertyId = property.Persist();

                    property.Address.Persist(propertyId);

                    foreach (PropertyPhoto item in property.Photo.PropertyPhoto)
                    {
                        item.Persist(propertyId);
                    }

                    property.Land.Persist(propertyId);
                    property.Building.Persist(propertyId);
                    property.Business.Persist(propertyId);
                    property.AgentDetails.Persist(propertyId);

                    foreach (Room room in property.Building.Rooms.Room)
                    {
                        room.Persist(propertyId);
                    }
                //}
            }
        }
    }
}