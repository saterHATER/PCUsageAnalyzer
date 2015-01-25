using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerUsageAnalyzer
{
    class HistoryStorage
    {
        private static DataSet _History;
        private static HistoryDataTable _CurrentUserHistory;
        private static PenaltyValues _CurrentUserPenalties; //new edit
        private static String _FilePath = AppDomain.CurrentDomain.BaseDirectory 
            + "\\record.xml";
        private static int start = (int)DateTime.Now.TimeOfDay.TotalMinutes;

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
                //Application.Run(new PCMonitorWindow(_History));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in instantiation: {0}", e.Message);
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
                    _History.Tables.Remove(CurrentName);
                }
                _History.Tables.Add(_CurrentUserHistory.GetDataTable());
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
                        _CurrentUserPenalties.AddNewProgram(process.ProcessName);
                    }
                }
                Console.WriteLine("Bleep");
                WriteDataSet();
                Console.Write("Bloop");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN SAMPLE: \n" + e.Message.ToString());
            }
        }

        private static void  WriteDataSet()
        {
            _History.WriteXml(_FilePath);
        }

        public DataSet GetDataSet()
        {
            return _History;
        }

        public void UpdateProgram(String tableName, String program, int day, int start, int end, double value)
        {
            if (_CurrentUserPenalties.Title() != tableName) SwitchPenalties(tableName);
            _CurrentUserPenalties.UpdateProgram(program, day, start, end, value);
            WriteDataSet();
            SwitchPenalties("Penalties_" + Environment.UserName.ToString());
        }

        public void SwitchPenalties(String tableName)
        {
            if (_History.Tables.Contains(tableName) && _CurrentUserPenalties.Title() != tableName)
            {
                _CurrentUserPenalties.InsertDataTable(_History.Tables[tableName]);
            }
            else Console.WriteLine("Couldn't match The Tablename, yo");
        }


    }
}