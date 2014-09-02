using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace WindowsService1
{
    class runningApps
        /* this will get a list of all programs running at a certain interval of time.
         * It's calling HistoryDataTable to tabulate all program consumption. But for now
         * I'm also keeping a _progs dictionary for some reason :/ */
    {

        private static Dictionary<String, int> _progs;//this contains <the process name, the intervals it's been collected
        private static int logEvents;
        private static string filename = "log.txt";
        private static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + filename ;

        static runningApps()
        {
            _progs = new Dictionary<String, int>();
            _progs.Add("don't Freak", 0);
        }

        public void tabApp(Process process)
        {
            string pName = process.ProcessName;
            int runCount = 0;
            
            if (_progs.Count == 1)
            {
                Console.WriteLine("poop!");
                _progs.Add(pName, runCount);
            }
            else
            {
                if (_progs.ContainsKey(pName))
                {
                    _progs.TryGetValue(pName, out runCount);
                    _progs[pName] = ++runCount;
                }
                else
                {
                    _progs.Add(pName, 0);
                }
            }
        }


        public void sample()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process: {0} ID: {1}", process.ProcessName, process.Id);
                    tabApp(process);
                }
            }
            log();
        }


        public void log()
        {
            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            fileWriter.WriteLine("Written on: ");
            foreach (var entry in _progs)
            {
                fileWriter.WriteLine("{0}::{1},", entry.Key, entry.Value);
            }
            fileWriter.Close();
        }
    }
}