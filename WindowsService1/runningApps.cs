using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsService1
{
    class runningApps
    {

        private static Dictionary<String, int> _progs;//this contains <the process name, the intervals it's been collected>
        private static Dictionary<String, int> _prevProgs;
        private static int logEvents;
        private static string filename = "log.txt";
        private static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + filename ;

        static runningApps()
        {
            _progs = new Dictionary<String, int>();//FINALLY! I'm an idiot.
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

        public void startWatch()
        {

        }

    }
}