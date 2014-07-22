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
        /* This app will keep a list of app IDs,
         *  names, and run times. It may also
         *  need to read a time limit int in 
         *  the future once the config file is 
         *  made.
         */
        private int[] pids;         //ID numbers
        private int apps;           //My counter
        private int[] runTimes;     //Run times

        public void newApp(Process process)
        {
            runTimes[apps] = 0;
            pids[apps] = process.Id;
            apps++;
        }

        public void sample()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }
            }
            Console.WriteLine("\n");
        }

    }
}
