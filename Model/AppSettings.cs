using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Model
{
    public class AppSettings
    {
        public static String CurrentFolder
        {
            get
            {
                return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
        }

        public static String AppData
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
        }

        public static String FILE_NAME
        {
            get
            {
                return "app.conf";
            }
        }

        public String load_folder { get; set; }
        public String db_name { get; set; }
        public String db_server { get; set; }
        public String db_user { get; set; }
        public String db_password { get; set; }
        public bool enable_hot_loading { get; set; }
        public bool enable_loging { get; set; }
        public String idx_server { get; set; }

        public static AppSettings GetAppSettingsFromJson(String Json)
        {
            return JsonConvert.DeserializeObject<AppSettings>(Json);
        }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Boolean Save()
        {
            String place = String.Format(@"{0}\{1}", CurrentFolder, FILE_NAME);
            return Archive.CreateCommonFile(this.ToJson(), place);
        }

        public static AppSettings GetAppSettings()
        {
            String folder = CreateAppDataFolders();
            //String place = String.Format(@"{0}\{1}\idx\{2}", AppData, folder,FILE_NAME);
            String place = String.Format(@"{0}\{1}", CurrentFolder, FILE_NAME);

            if (File.Exists(place))
            {
                return GetAppSettingsFromJson(Archive.ReadFile(place));
            }
            else
            {
                AppSettings settings = new AppSettings()
                {
                    load_folder = String.Concat(folder, @"\idx\data"),
                    db_name = "idx",
                    db_server = "localhost",
                    db_user = "root",
                    db_password = "",
                    enable_hot_loading = false,
                    enable_loging = true,
                    idx_server = ""
                };

                Archive.CreateCommonFile(settings.ToJson(), place);
                return settings;
            }
        }

        private static String CreateAppDataFolders()
        {
            String folder = String.Concat(AppData, @"\royaltrading");
            if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }

            String idx_folder = String.Concat(AppData, @"\royaltrading\idx");
            if (!Directory.Exists(idx_folder)) { Directory.CreateDirectory(idx_folder); }

            String idx_data_folder = String.Concat(AppData, @"\royaltrading\idx\data");
            if (!Directory.Exists(idx_data_folder)) { Directory.CreateDirectory(idx_data_folder); }

            String idx_log_folder = String.Concat(AppData, @"\royaltrading\idx\log");
            if (!Directory.Exists(idx_log_folder)) { Directory.CreateDirectory(idx_log_folder); }

            return folder;
        }
    }
}
