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
        
        static HistoryDataTable()   
            /* I'm initializing the datatable and setting the rows.*/
        {
            _ProgramHistory = new DataTable("current_Filings");
            _ProgramHistory.Columns.Add("pName", typeof(String));
            _ProgramHistory.Columns.Add("Start Time", typeof(int));
            _ProgramHistory.Columns.Add("Last Tab", typeof(int));
            _ProgramHistory.Columns.Add("End Time", typeof(int));
        }

        public void record(String processName, int time)
            /* I'll take a process, date (as a formatted int, I hate that idea)
             * and I'll selectively add it into the data table, this should
             * hopfully allow for total analysis of program usage */
        {
            if (_ProgramHistory.Rows.Count == 0)
                // if were off to a blank slate, here's what we add.
            {
                _ProgramHistory.Rows.Add(processName,time,time);
            }
        }

        private DataRow[] rowsWithNames(String processName)
            //Now here's where I'm going to get all of my datarows 
            //with a matching process name
        {
            foreach (DataRow row in _ProgramHistory.Rows)
            {
                //TODO: figure out how to check the first column
            }
        }

    }
}
