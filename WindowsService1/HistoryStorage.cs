using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class HistoryStorage
    {
        private static DataSet _History;

        private static String _FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\sample.xml";


        static HistoryStorage()
        {
            _History = new DataSet();
            
            if (File.Exists(@_FilePath))
            {
                _History.ReadXml(_FilePath);   //this needs testing
            }

        }


        public void WriteDataSet()
        {
            _History.WriteXml(_FilePath);
        }


        public void AddDataTable(DataTable dt)
        {
            foreach(DataTable czek in _History.Tables)
            {
                if (czek.TableName.Equals(dt.TableName))
                {
                    Console.WriteLine(dt.TableName + " is a match!");
                }
                else
                {
                    Console.WriteLine("gotta write a new table for " + dt.TableName);
                    _History.Tables.Add(dt);
                }                
            }
        }





    }
}
