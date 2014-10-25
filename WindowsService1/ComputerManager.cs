using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

using System.IO;
using System.Runtime.InteropServices;


namespace WindowsService1
{
    class ComputerManager
    /* This will be what physically gather's up all programs, logs out the user, keeps
     * track of the bad stuff being consumed...etc.
     */
    {
        private static HistoryDataTable _History;      //This keeps track of the program usage.

        private static HistoryStorage _testDS;          //This is my dataset manager.

        private static List<String> _AppsInQuestion;    //This will be the list of all programs 
                                                        //I want to scrutinize

        static ComputerManager()
            //this is where I need to add settings 'n sh**. I need to establish the user and the
            //apps that are in question. Let's angle for a more analysis role for now. It's baby
            //stuff to go down the PC route.
        {
            _testDS = new HistoryStorage();
            _History = new HistoryDataTable();
            _testDS.AddDataTable(_History.PukeUpDataTable());
            _AppsInQuestion = new List<string>();
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
                    _History.record(process.ProcessName, now);
                }
            }
            Console.WriteLine(_History.GetTableTitle());
            _History.print();
            _testDS.AddDataTable(_History.PukeUpDataTable());//currently debuging this shit
            Dictionary<String, int> dummy = Report();
        }


        private static void CutOffUser()
        {
            System.Diagnostics.Process.Start("shutdown", "/l /f");
        }


        public Dictionary<String, int> Report()
        {
            Dictionary<String, int> output = new Dictionary<string, int>();

            foreach (string app in _AppsInQuestion.ToArray())
            {
                output.Add(app, _History.UsageTotals(app));
            }

            return output;
        }





    }
}