﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//here's a thought. Compare the PID's. Clever. Maybe later

namespace WindowsService1
{
    
    class HistoryDataTable
        /* This class is keeping a datatable of the history of all major app usage
         * I need to work on this. There's much to be decided on how to do this... */
    {

        private static DataTable _ProgramHistory;

        private static String _lastRecordTime;

        static HistoryDataTable()
            /* I'm initializing the datatable and setting the rows.*/
        {
            _ProgramHistory = new DataTable("current_Filings");
            _ProgramHistory.Columns.Add("pName", typeof(String));       //row 0
            _ProgramHistory.Columns.Add("Start Time", typeof(String));  //row 1
            _ProgramHistory.Columns.Add("End Time", typeof(String));    //row 2

            _lastRecordTime = "";
        }


        public void record(String processName, String time)
            /* I'll take a process, date (as a formatted int, I hate that idea)
             * and I'll selectively add it into the data table, this should
             * hopfully allow for total analysis of program usage */
        {
            List<DataRow> matchingRows = rowsWithName(processName);
                
            if (matchingRows.Count == 0)
                //if there are no entries with the corresponding process name...
            {
                _ProgramHistory.Rows.Add(processName, time, time);
            }
            else 
            {
                int rowNumber = recordingInProgress(matchingRows);
                
                if (rowNumber == -1)
                    //In this case I must simply add a new row...
                {
                    _ProgramHistory.Rows.Add(processName, time, time);
                }
                else
                    // This is the case where we've got a program currently running
                {
                    _ProgramHistory.Rows[rowNumber]["End Time"] = time;
                }
            }

        }


        private static int recordingInProgress(List<DataRow> matchingRows)
        {
            int rowCount = 0;
            try
            {
                foreach (DataRow row in matchingRows)
                {
                    String lastTimeStamp = row.ItemArray[2].ToString();
                    //I don't like hard-coding the column number...

                    if (_lastRecordTime == lastTimeStamp) return rowCount;
                    rowCount++;
                }
                return -1;
            }
            catch 
            {
                return -1;
            }
        }


        public void updateLastRecordTime(String time)
        {
            _lastRecordTime = time;
        }


        private static List<DataRow> rowsWithName(String processName)
            //Now here's where I'm going to get all of my datarows 
            //with a matching process name
        {
            List<DataRow> foundRows = new List<DataRow>();
            try 
            {
                foreach (DataRow row in _ProgramHistory.Rows)
                {
                    String pName = row.ItemArray[0].ToString();
                    if (pName == processName)
                    {
                        foundRows.Add(row);
                    }
                }
                return foundRows;
            }
            catch
            {
                return foundRows;
            }
        }


    }
}
