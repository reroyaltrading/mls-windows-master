using CanadaHousing.Model;
using CanadaHousing.Utils;
using CanadaHousing.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CanadaHousing.Core
{
    public class Crawler
    {
        private static HttpWebRequest httpWebRequest;
        private static CredentialCache requestCredentialCache = new CredentialCache();
        private static string RetsUrl = ConfigurationManager.AppSettings["url"];

        private static ICredentials requestCredentials = new NetworkCredential(
            Credentials.USERNAME,
            Credentials.PASSWORD);

        private static CookieContainer cookieJar = new CookieContainer();

        public static String[] SearchTransactionGetIds(string SearchType, string Class, string QueryType, string Query, int Count = 1, string Limit = "None", int Offset = 1, string Culture = "en-CA", string Format = "STANDARD-XML")
        {
            string filename = String.Concat(AppSettings.GetAppSettings().load_folder, @"\index.xml");
            string requestArguments = "?Format=" + Format + "&SearchType=" + SearchType + "&Class=" + Class + "&QueryType=" + QueryType + "&Query=" + Query + "&Count=" + Count + "&Limit=" + Limit + "&Offset=" + Offset + "&Culture=" + Culture;
            string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

            httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
            httpWebRequest.CookieContainer = cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = requestCredentials; //PASS CREDENTIALS

            List<String> Ids = new List<String>();

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    Stream stream = httpResponse.GetResponseStream();

                    using (Stream file = File.Create(filename))
                    {
                        CopyStream(stream, file);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

            return Ids.ToArray();
        }

        public static Boolean GrabAllData(Boolean UpdateExisting, Boolean SaveFile, formLoadData parent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            //if(stringBuilder == null) { stringBuilder = new StringBuilder(); }
            Int32 current = 0;

            try
            {
                LoginTransaction();
                List<String> Ids = GetIndexFromFile();
                
                foreach (String Id in Ids.ToArray())
                {
                    stringBuilder.AppendLine(String.Format("Property: {0}", Id));

                    if (UpdateExisting)
                    {
                        SearchTransactionOneByOne("Property", "Property", "DMQL2", Id, SaveFile, UpdateExisting);
                    }
                    else
                    {
                        if (!File.Exists(String.Format(@"{0}\{1}.xml", AppSettings.GetAppSettings().load_folder, Id)))
                        {
                            SearchTransactionOneByOne("Property", "Property", "DMQL2", Id, SaveFile, UpdateExisting);
                        }
                        else
                        {
                            stringBuilder.AppendLine(String.Format("File '{0}.xml' exists, avoiding it", Id));
                        }
                    }

                    current++;
                    parent.RunWithInvoke(current, Ids.Count);
                    parent.UpdateLabelWithInvoke(current, Ids.Count);
                    //parent.UpdateProgressBarMethod( Ids.Count, current);
                }

                return true;
            }catch(Exception ex)
            {
                
            }
            finally
            {
                LogoutTransaction();
            }

            return false;
        }

        public static void SearchTransactionOneByOne(string SearchType, string Class, string QueryType, string Query, Boolean saveFile, Boolean PersistOnDatabase, int Count = 1, string Limit = "None", int Offset = 1, string Culture = "en-CA", string Format = "STANDARD-XML")
        {
            string requestArguments = "?Format=" + Format + "&SearchType=" + SearchType + "&Class=" + Class + "&QueryType=" + QueryType + "&Query=" + String.Format("(ID={0})", Query) + "&Count=" + Count + "&Limit=" + Limit + "&Offset=" + Offset + "&Culture=" + Culture;
            string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

            httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
            httpWebRequest.CookieContainer = cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = requestCredentials; //PASS CREDENTIALS

            DumpJson dump = DumpJson.Get();

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    Stream stream = httpResponse.GetResponseStream();
                    // READ THE RESPONSE STREAM USING XMLTEXTREADER                    

                    String Content = String.Empty;
                    if (saveFile)
                    {
                        String filecomplete = String.Format(@"{0}\{1}.xml", AppSettings.GetAppSettings().load_folder, Query);
                        using (Stream file = File.Create(filecomplete))
                        {
                            CopyStream(stream, file);
                        }

                        Content = Archive.ReadFile(filecomplete);
                    }
                    else
                    {
                        Content = Treatment.StreamToString(stream);
                    }

                    //GetImages Quantity
                    
                    Content = Treatment.Replaces(Content);


                    XmlSerializer serializer = new XmlSerializer(typeof(Idx));
                    using (TextReader reader = new StringReader(Content))
                    {
                        Idx result = (Idx)serializer.Deserialize(reader);

                        if (PersistOnDatabase)
                        {
                            result.Persist(dump);
                        }

                        Int32 TotalPhotos = Treatment.GetPhotosQuantity(result);

                        for (int i = 0; i < TotalPhotos; i++)
                        {
                            GetImagesFromId(Query, Model.Type.TYPE_LARGET_PHOTO, String.Format("{0}", i));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void SynDatabase(formSyncDatabase parent)
        {

            String folder = AppSettings.GetAppSettings().load_folder;
            Int32 total = Directory.GetFiles(folder).Count();
            Int32 count = 0;

            foreach (String filecomplete in Directory.GetFiles(folder))
            {
                if (filecomplete.EndsWith(".xml") && !filecomplete.EndsWith("index.xml"))
                {
                    String Content = Archive.ReadFile(filecomplete);
                    XmlSerializer serializer = new XmlSerializer(typeof(Idx));
                    using (TextReader reader = new StringReader(Content))
                    {
                        DumpJson dump = DumpJson.Get();

                        try
                        {
                            Idx result = (Idx)serializer.Deserialize(reader);
                            result.Persist(dump);

                            count++;

                            parent.RunWithInvoke(count, total);
                            parent.UpdateLabelWithInvoke(count, total);
                        }catch(Exception ex)
                        {

                        }
                    }
                }
            }            
        }

        public static void GetImagesFromId(String PropertyId, Model.Type type = Model.Type.TYPE_LARGET_PHOTO, String ImageId = "*")
        {
            string requestArguments = String.Format("?Resource={0}&Type={1}&ID={2}:{3}", "Property", TypeHandler.Convert(type), PropertyId, ImageId);
            string searchService = RetsUrl + "/GetObject.svc/GetObject" + requestArguments;


            httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
            httpWebRequest.CookieContainer = cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = requestCredentials; //PASS CREDENTIALS


            using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                Stream stream = httpResponse.GetResponseStream();
                string filename = String.Concat(CreateDirIfNotExists(PropertyId), @"\", PropertyId, "_", ImageId.Equals("*") ? "0" : ImageId, ".png");

                using (Stream file = File.Create(filename))
                {
                    CopyStream(stream, file);
                }
            }

        }

        private static String CreateDirIfNotExists(string propertyId)
        {
            String path = String.Concat(AppSettings.GetAppSettings().load_folder, @"\", propertyId);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }


        public static List<String> GetIndexFromFile()
        {
            Stream stream = File.OpenRead(String.Format(@"{0}\index.xml", AppSettings.GetAppSettings().load_folder));
            XmlTextReader reader = new XmlTextReader(stream);
            List<String> Ids = new List<String>();

            try
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "Property":
                                String Id = reader["ID"].ToString();
                                //Console.WriteLine("ID Found: {0}", Id);
                                Ids.Add(reader["ID"].ToString());
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return Ids;
        }

        public static bool GetIndex()
        {
            try
            {
                LoginTransaction();
                SearchTransactionGetIds("Property", "Property", "DMQL2", "(ID=*)");
                LogoutTransaction();

                return true;
            }catch(Exception ex)
            {

            }

            return false;
        }

        public static void LoginTransaction()
        {
            string service = RetsUrl + "/Login.svc/Login";

            CookieContainer loginCookie = new CookieContainer();

            httpWebRequest = (HttpWebRequest)WebRequest.Create(service);
            httpWebRequest.CookieContainer = loginCookie; //STORE THE REQUEST COOKIE
            httpWebRequest.Credentials = requestCredentials;

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    Stream stream = httpResponse.GetResponseStream();
                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    XmlTextReader reader = new XmlTextReader(stream);

                    while (reader.Read())
                    {
                        if (reader.Name == "RETS")
                        {
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "ReplyCode" & reader.Value == "0")
                                    {
                                        //Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                                        loginCookie.Add(httpResponse.Cookies);
                                        cookieJar = loginCookie;
                                        //STORE THE COOKIES RECEIVED FOR FUTURE RETRIEVAL
                                        //FOR STATELESS APPLICATION PROCESSING, STORE THE COOKIES RECEIVED IN THE SESSION STATE FOR FUTURE RETRIEVAL BY THIS SESSION.
                                    }
                                    //else
                                    //{
                                    //    /Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                                    //}
                                }
                            }
                        }
                        //else if (reader.NodeType != XmlNodeType.XmlDeclaration & reader.HasValue)
                        //{
                        //    Console.WriteLine("RETS-RESPONSE:");
                        //    Console.WriteLine("{0}", reader.Value);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void LogoutTransaction()
        {
            string service = RetsUrl + "/Logout.svc/Logout";

            httpWebRequest = (HttpWebRequest)WebRequest.Create(service);
            httpWebRequest.CookieContainer = cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = requestCredentials; //PASS CREDENTIALS

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    Stream stream = httpResponse.GetResponseStream();
                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    XmlTextReader reader = new XmlTextReader(stream);

                    while (reader.Read())
                    {
                        if (reader.Name == "RETS")
                        {
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    //if (reader.Name == "ReplyCode" & reader.Value == "0")
                                    //{
                                    //    Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                                    //}
                                    //else
                                    //{
                                    //    Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                                    //}
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public static void ReadXMLElement(XmlTextReader reader)
        {
            if (reader.NodeType != XmlNodeType.EndElement)
            {
                string name = reader.Name;

                //RETRIEVE THE NEXT NESTED ELEMENT TEXT
                while (reader.Read())
                {
                    if (reader.HasValue)
                    {
                        Console.WriteLine("{0}: {1}", name, reader.Value);
                        break;
                    }
                }
            }
        }
        public static void GetObject(string strResource, string strID, string strType)
        {

            string requestArguments = "?Resource=" + strResource + "&ID=" + strID + "&Type=" + strType;
            string searchService = RetsUrl + "/Object.svc/GetObject" + requestArguments;

            httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
            httpWebRequest.CookieContainer = cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = requestCredentials; //PASS CREDENTIALS

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        Stream stream = httpResponse.GetResponseStream(); // READ THE RESPONSE STREAM USING STREAMREADER
                        StreamReader reader = new StreamReader(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
