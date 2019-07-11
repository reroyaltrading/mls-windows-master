using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Model
{
    public class DumpJson
    {
        public List<Item> Items { get; set; }

        public static DumpJson Get()
        {
            String filename = String.Format(@"{0}\dump.json", AppSettings.GetAppSettings().load_folder);

            if (!File.Exists(filename))
            {
                return new DumpJson() { Items = new List<Item>() };
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<DumpJson>(Archive.ReadFile(filename));
            }
        }

        public void Save()
        {
            String Content = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            String filename = String.Format(@"{0}\dump.json", AppSettings.GetAppSettings().load_folder);
            if (File.Exists(filename)) { File.Delete(filename); }

            Archive.CreateFile(Content, filename);

        }


        public bool NotIn(String propertyId)
        {
            return NotIn(Int32.Parse(propertyId));
        }

        public bool NotIn(Int32 propertyId)
        {
            Int32[] Ids = this.Items.Select(x => Int32.Parse(x.PropertyId)).ToArray();
            return !Ids.Contains(propertyId);
        }
    }
}
