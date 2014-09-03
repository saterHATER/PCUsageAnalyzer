using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    
    class HistoryDataTable
        /* This class is keeping a datatable of the history of all major app usage
         * I need to work on this. There's much to be decided on how to do this... */

    {

        private static DataTable _ProgramHistory;
        // TODO add a time interval variable.


        static HistoryDataTable()
            /* I'm initializing the datatable and setting the rows.*/
        {
            _ProgramHistory = new DataTable("current_Filings");
            _ProgramHistory.Columns.Add("pName", typeof(String));
            _ProgramHistory.Columns.Add("Start Time", typeof(String));
            _ProgramHistory.Columns.Add("End Time", typeof(String));

            //TODO: add a time interval thing here
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
                // now we're assuming there's a match, we need to check if the
                // row is on currently on a streak and how to best                 
            {
                //todo: stuff here
            }

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
