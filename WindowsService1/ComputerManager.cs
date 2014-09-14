using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

namespace WindowsService1
{
    class ComputerManager
        /*This will be what physically gather's up all programs, logs out the user, keeps track
         * of the bad stuff being consumed...etc.
         */
    {
        private static HistoryDataTable _History;      //This keeps track of the program usage.

        private static List<String> _AppsInQuestion;    //This will be the list of all programs 
                                                        //I want to scrutinize
        static ComputerManager()
        {
            _History = new HistoryDataTable();
            _AppsInQuestion = new List<string>();
            _AppsInQuestion.Add("Chrome");          //this is in lieu of my ability to call out
        }


        public void sample()
        {
            String now = DateTime.Now.TimeOfDay.ToString();     //I'm gonna need to change the 
            now = now.Substring(0, 8);                          //datatable if the day changes

            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    _History.record(process.ProcessName,now);
                }
            }
            _History.updateLastRecordTime(now);
            _History.print();  //purely a debugging measure

            Console.WriteLine(_History.UsageTotals("WDExpress"));
        }


    }
}