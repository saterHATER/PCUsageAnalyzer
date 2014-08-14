using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsService1
{
    /*
     * This is 'generic' code for writing data to a settings file
     * To be honest, I don't really know how to use this just yet.
     */

    public class MySettings
    {

        public string DatabaseConnection { get; set; }
        public string LastAction { get; set; }
        private static XmlSerializer xs;
        
        static MySettings()
        {
            xs = new XmlSerializer(typeof(MySettings));
        }
        
        public void SaveToFile(string NameFile)
        {
            using (StreamWriter sr = new StreamWriter(NameFile))
            {
                xs.Serialize(sr, this);
            }
        }

        public static MySettings ReadFromFile(string NameFile)
        {
            using(StreamReader sr = new StreamReader(NameFile))
            {
                return xs.Deserialize(sr) as MySettings;
            }
        }

    }
}
