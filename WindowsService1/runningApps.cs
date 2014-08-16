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
        private int sampleCount;    //# of times sampled
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);



        public void newApp(Process process)
        {
            runTimes[apps] = 0;
            pids[apps] = process.Id;
            apps++;
        }//intigration to the sample part would be nice, but something needs to check and see if the app's been run.

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

        public void log(Process[] processList)
        {
            
            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            string dateTime = DateTime.Now.ToString();

            foreach (Process process in processList)
            {
                fileWriter.WriteLine("Sample from {0}: \n", dateTime);
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    fileWriter.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }
            }
            Console.WriteLine("\n");
        }

    }
}
