using CanadaHousing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Controller
{
    public class LogControl
    {
        private StringBuilder Content { get; set; }

        public LogControl()
        {
            this.Content = new StringBuilder();
        }

        public void Write(String v)
        {
            Console.Write(v);
            Content.Append(v);
            //MakeLog(v);
        }

        public void WriteLine(String v)
        {
            Console.WriteLine(v);
            Content.AppendLine(v);
            //MakeLog(v);
        }

        public Boolean MakeLog(String WorkingFolder)
        {
            return Archive.CreateFile(this.Content.ToString(), WorkingFolder);
        }
    }
}
