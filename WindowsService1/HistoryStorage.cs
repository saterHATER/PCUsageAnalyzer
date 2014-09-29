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
            //this case only assumes that there has been no previous logins todate.
            dt.ExtendedProperties.Add("Start Date", DateTime.Now);  //I'll need the end date
            dt.ExtendedProperties.Add("User Name", Environment.UserName);
            int zero = 0;
            dt.ExtendedProperties.Add("Login Periods", zero);
            _History.Tables.Add(dt);
            /*I need to check if the datatable allready exists, and here's what else:
             ****1. The day (date) this is covering-------->DONE
             ****2. The amount of logins this user has
             ****3. Username, of course-------------------->                        */
        }


    }
}
