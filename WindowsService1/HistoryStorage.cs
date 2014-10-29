using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        private static HistoryDataTable _currentUser;

        private static String DTName = "History_" + Environment.UserName.ToString();

        static HistoryStorage()
        {
            try
            {
                _History = new DataSet();
                _currentUser = new HistoryDataTable();

                if (File.Exists(@_FilePath))
                {
                    Console.WriteLine("It exists!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!#############");
                    try
                    {
                        _History.ReadXml(_FilePath);
                        Console.WriteLine("~~~~~Loading...~~~~~");
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("~~~~~~~~~");
                        Console.WriteLine("~~~~~~~~~");
                        Console.WriteLine(e.Message.ToString());
                        Console.WriteLine("~~~~~~~~~");
                        Console.WriteLine("~~~~~~~~~");
                    }
                }
                AddDataTable(_currentUser.ReturnDT());
                WriteDataSet();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }


        private static void WriteDataSet()
        {
            _History.WriteXml(_FilePath);
        }


        private static void AddDataTable(DataTable dt)
        //no. Fuck that. Do better than that fuckery.
        {
            try
            {
                String targetDT = dt.TableName.ToString();
                if (_History.Tables.Contains(targetDT))
                {
                    
                    Console.WriteLine("Merging logic needed...");
                }
                else
                {
                    Console.WriteLine("DT added...");
                    _History.Tables.Add(dt);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in adding DT: " + e.Message.ToString() );
            }
        }


        public void sample()
        {
            try
            {
                String now = DateTime.Now.TimeOfDay.ToString();     //I'm gonna need to change the 
                now = now.Substring(0, 8);                          //datatable if the day changes

                Process[] processlist = Process.GetProcesses();

                foreach (Process process in processlist)
                {
                    if (!String.IsNullOrEmpty(process.MainWindowTitle))
                    {
                        _currentUser.record(process.ProcessName, now);
                    }
                }
                Console.WriteLine(_currentUser.GetTableTitle());
                _currentUser.print();
                _currentUser.updateLastRecordTime(now);
                AddDataTable(_currentUser.ReturnDT());//currently debuging this shit
                WriteDataSet();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN SAMPLE: \n" + e.Message.ToString());
            }
        }


        public Dictionary<String, int> Report(List<string> AppsInQuestion)
            //put a stanza in for if AppsInQuestion is null
        {
            Dictionary<String, int> output = new Dictionary<string, int>();

            foreach (string app in AppsInQuestion.ToArray())
            {
                output.Add(app, _currentUser.UsageTotals(app));
            }

            return output;
        }


    }
}
