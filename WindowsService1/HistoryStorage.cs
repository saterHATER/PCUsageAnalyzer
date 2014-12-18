﻿using System;
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
                int day = (int)DateTime.Now.DayOfWeek;
                //int start = (int) DateTime.Now.TimeOfDay.TotalMinutes;
                int end = start + 1;
                Double val = 0.03;
                Console.WriteLine("\n \n now: {2} \n start: {0} \n end: {1} \n", start, end, DateTime.Now.ToString());
                _CurrentUserPenalties.UpdateProgram("OUTLOOK", day, start, end, val);
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
                
                int isWindows = String.Compare(Environment.OSVersion.ToString(),"Microsoft Windows NT 6.1.7601 Service Pack 1");
                foreach (Process process in processlist)
                {
                    if (isWindows==0)
                    {
                        if (!String.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            string testies = process.ProcessName;
                            _CurrentUserHistory.record(process, now);
                            _CurrentUserPenalties.AddNewProgram(process.ProcessName);
                        } 
                    }
                    else
                    {
                        if (!(String.Compare(process.MainWindowTitle,"Null")==0))
                        {
                            string testies = process.ProcessName;
                            _CurrentUserHistory.record(process, now);
                            _CurrentUserPenalties.AddNewProgram(process.ProcessName);
                        }                         
                    }
                }
                Console.WriteLine("Looking for: {0}, it's currently {1}", start, now.TimeOfDay.TotalMinutes);
                Console.WriteLine(_CurrentUserPenalties.ReturnPenalty("OUTLOOK", DateTime.Now));
                //Console.WriteLine(_History.GetXml() + "\n \n");
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