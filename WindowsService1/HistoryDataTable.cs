using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerUsageAnalyzer
{
    
    class HistoryDataTable
    {

        private static DataTable _ProgramHistory;

        static HistoryDataTable()
        {
            _ProgramHistory = new DataTable("Current_Filings");
            
            //ROWS
            _ProgramHistory.Columns.Add("Row Number", typeof(int));         //row 0
            _ProgramHistory.Columns.Add("Program Name", typeof(String));    //row 1
            _ProgramHistory.Columns.Add("Process ID", typeof(int));         //row 2
            _ProgramHistory.Columns.Add("DateTime", typeof(DateTime));      //row 3
            _ProgramHistory.Columns.Add("Process Start", typeof(DateTime)); //row 4

            //PROPERTIES
            _ProgramHistory.TableName = "History_" + Environment.UserName.ToString();
            _ProgramHistory.ExtendedProperties.Add("Start Date", DateTime.Now.ToString());
            _ProgramHistory.ExtendedProperties.Add("End Date", DateTime.Now.ToString());
            _ProgramHistory.ExtendedProperties.Add("User Name", Environment.UserName.ToString());
            _ProgramHistory.ExtendedProperties.Add("Load Counts", (int) 0);//I STILL NEED TO ADD THIS
        }

        public String Title()
        {
            return _ProgramHistory.TableName.ToString();
        }

        public void record(Process process, DateTime now)
        {
            try
            {
                String processName = process.ProcessName;
                String time = now.ToString().Substring(9, 8);

                int rowMatch = GetIndex((int)process.Id);
                if (rowMatch == -1)
                {
                    _ProgramHistory.Rows.Add(_ProgramHistory.Rows.Count, processName, process.Id, now, process.StartTime);
                }
                else
                {
                    _ProgramHistory.Rows[rowMatch]["DateTime"] = now;
                }
                _ProgramHistory.ExtendedProperties["End Date"] = now.ToString();//update last touch time....
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN WRITING TO DT: " + e.Message);
            }
        }

        public void print()
        {
            try
            {
                foreach (DataRow row in _ProgramHistory.Rows)
                {
                    foreach (Object item in row.ItemArray)
                    {
                        Console.Write(item.ToString() + "\v\v");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch 
            {
                Console.WriteLine("there was a problem with reading the data");
            }
        }

        private int GetIndex(int pid)
        {
            foreach (DataRow row in _ProgramHistory.Rows)
            {
                int contender = int.Parse(row["Process ID"].ToString());
                if (pid == contender)
                {
                    int rowLocation = int.Parse(row["Row Number"].ToString());
                    return rowLocation;
                }
            }
            return (int)(-1);
        }

        public DataTable GetDataTable()
        {
            return _ProgramHistory;
        }

        public void InsertDataTable(DataTable newDT)
        {
            _ProgramHistory = newDT;
        }

    }
}