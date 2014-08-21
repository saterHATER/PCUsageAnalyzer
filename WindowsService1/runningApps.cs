using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsService1
{
    class runningApps
    {

        private static Dictionary<String, int> _procs;//this contains <the process name, the intervals it's been collected>
        private static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static runningApps()
        {
            _procs = new Dictionary<String, int>();//FINALLY! I'm an idiot.
            _procs.Add("don't Freak", 0);
        }

        public void tabApp(Process process)
        //intigration to the sample part would be nice, 
        //but something needs to check and see if the app's been run.
        {
            string pName = process.ProcessName;
            int runCount = 0;
            if (_procs.Count == 1)
            {
                Console.WriteLine("poop!");
                _procs.Add(pName, runCount);
            }
            else
            {
                if (_procs.ContainsKey(pName))
                {
                    _procs.TryGetValue(pName, out runCount);
                    _procs[pName] = ++runCount;
                    Console.WriteLine("{0} has been running for {1} cycles.", pName, runCount);
                }
            }
        }


        public void sample()
        /*
         * This is now called by the scheduler class. That's really all I needed from that class.
         * */
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
            Console.WriteLine("\n");
        }


        public void log(Process[] processList)
        {
            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            string dateTime = DateTime.Now.ToString();

            foreach (Process process in processList)
            {
                fileWriter.WriteLine("Sample from {0}: \n", dateTime);
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    fileWriter.WriteLine("Process: {0} ID: {1}", process.ProcessName, process.Id);
                }
            }
            Console.WriteLine("\n");
        }

    }
}