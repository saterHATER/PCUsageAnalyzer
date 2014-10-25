using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        private static Dictionary<String, int> _index; //this keeps track of rows by title;

        static HistoryDataTable()
            /* I'm initializing the datatable and setting the rows.*/
        {
            _ProgramHistory = new DataTable("current_Filings");
            _index = new Dictionary<string,int>();
 
            _index.Add("Row Number", 0);
            _ProgramHistory.Columns.Add("Row Number", typeof(int));     //row 0
            
            _index.Add("Program Name", 1);
            _ProgramHistory.Columns.Add("Program Name", typeof(String));//row 1

            _index.Add("Start Time", 2);
            _ProgramHistory.Columns.Add("Start Time", typeof(String));  //row 2

            _index.Add("End Time", 3);
            _ProgramHistory.Columns.Add("End Time", typeof(String));    //row 3

            _ProgramHistory.TableName = "History_" + Environment.UserName.ToString();
            _ProgramHistory.ExtendedProperties.Add("End Date", DateTime.Now);
            _ProgramHistory.ExtendedProperties.Add("User Name", Environment.UserName);
            _ProgramHistory.ExtendedProperties.Add("Login Periods", 0);

            _lastRecordTime = "";
        }


        public String GetTableTitle()
        {
            return _ProgramHistory.TableName.ToString();
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
                _ProgramHistory.Rows.Add(_ProgramHistory.Rows.Count, processName, time, time);
            }
            else 
            {
                int rowNumber = recordingInProgress(matchingRows);//it's partially this.
                //the rowNumber 'nabbed from this is farsicle. I need that fixed.
                
                if (rowNumber == -1)
                    //In this case I must simply add a new row...
                {
                    _ProgramHistory.Rows.Add(_ProgramHistory.Rows.Count, processName, time, time);//NEEDS A FIXIN'
                }
                else
                    // This is the case where we've got a program currently running
                {
                    _ProgramHistory.Rows[rowNumber]["End Time"] = time;
                }
            }

        }


        private static int recordingInProgress(List<DataRow> matchingRows)
            //I thought this row was clearly self explanitory.
            //It's supposed to return the row # where the matching row sits.
            // It doesn't...yet.-->this should be a string
        {
            int rowCount = 0;
            try
            {
                foreach (DataRow row in matchingRows)
                {
                    String lastTimeStamp = row.ItemArray[_index["End Time"]].ToString();

                    if (_lastRecordTime == lastTimeStamp) return Convert.ToInt32(
                        row.ItemArray[_index["Row Number"]].ToString());
                    //^that line is essentially getting the row# that it's looking for...
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
                    String pName = row.ItemArray[_index["Program Name"]].ToString();
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


        public int UsageTotals(String DisiredApp)
            /* This method outputs the total seconds a program has run
             * Because I'm stupid, I need to deliniate each hour, minute and second*/
        {
            List<DataRow> MatchingRows = rowsWithName(DisiredApp);
            int UsageTime = 0;

            foreach (DataRow row in MatchingRows)
            {
                String StartTime = row.ItemArray[_index["Start Time"]].ToString();
                String EndTime = row.ItemArray[_index["End Time"]].ToString();
                UsageTime += timeDifference(StartTime, EndTime);
            }   
            return UsageTime;
        }


        private static int timeDifference(string BeginTime, string EndTime)
        {
            int hour = (Convert.ToInt32(EndTime.Substring(0, 2))) 
                - (Convert.ToInt32(BeginTime.Substring(0, 2)));
            hour = hour * 3600;
            int min = (Convert.ToInt32(EndTime.Substring(3, 2))) 
                - (Convert.ToInt32(BeginTime.Substring(3, 2)));
            min = min * 60;
            int sec = (Convert.ToInt32(EndTime.Substring(6, 2))) 
                - (Convert.ToInt32(BeginTime.Substring(6, 2)));
            return hour+sec+min;
        }


        public DataTable PukeUpDataTable()
        {
            return _ProgramHistory;
        }


    }
}