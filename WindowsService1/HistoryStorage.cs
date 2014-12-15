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
        private static HistoryDataTable _CurrentUserHistory;
        private static PenaltyValues _CurrentUserPenalties; //new edit
        private static String _FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\record.xml";

        static HistoryStorage()
        {
            try
            {
                _History = new DataSet();
                _CurrentUserHistory = new HistoryDataTable();
                _CurrentUserPenalties = new PenaltyValues();

                if (File.Exists(@_FilePath))
                {
                    _History.ReadXml(_FilePath);
                }
                AddHistory();
                AddPenalties();
                WriteDataSet();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        private static void AddHistory()
        {
            try
            {
                String CurrentName = _CurrentUserHistory.Title();
                if (_History.Tables.Contains(CurrentName))
                {
                    _CurrentUserHistory.InsertDataTable(_History.Tables[CurrentName]);
                    //give _CurrentUserHistory what _history had
                    _History.Tables.Remove(CurrentName);
                    //Purge _history, for some reason....
                }
                _History.Tables.Add(_CurrentUserHistory.GetDataTable());
                //insert newly created datatable into the dataset freshly devoid of a datatable
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in adding DT: " + e.Message.ToString() );
            }
        }

        private static void AddPenalties()
        {
            try
            {
                String CurrentName = _CurrentUserPenalties.Title();
                if (_History.Tables.Contains(CurrentName))
                {
                    _CurrentUserPenalties.InsertDataTable(_History.Tables[CurrentName]);
                    _History.Tables.Remove(CurrentName);
                }
                _History.Tables.Add(_CurrentUserPenalties.GetDataTable());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in adding DT(p): " + e.Message.ToString());
            }
        }

        public void sample()
        {
            try
            {
                DateTime now = DateTime.Now;
                Process[] processlist = Process.GetProcesses();

                foreach (Process process in processlist)
                {
                    if (!String.IsNullOrEmpty(process.MainWindowTitle))
                    {
                        string testies = process.ProcessName;
                        _CurrentUserHistory.record(process, now);
                    }
                }
                Console.WriteLine(_CurrentUserHistory.Title());
                _CurrentUserHistory.print();
                WriteDataSet();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN SAMPLE: \n" + e.Message.ToString());
            }
        }

        private static void WriteDataSet()
        {
            _History.WriteXml(_FilePath);
        }

    }
}