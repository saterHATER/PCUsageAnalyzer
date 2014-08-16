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

        Dictionary<String, int> allApps;//this contains <the process name, the intervals it's been collected>
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        
        public void tabApp(Process process)
        //intigration to the sample part would be nice, 
        //but something needs to check and see if the app's been run.
        {
            string pName = process.ProcessName;
            if (allApps.ContainsKey(pName))
            //if there's a process of the same name....
            {
                allApps[pName] = allApps[pName]++;
            }
            else
            {
                allApps[pName] = 0;
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
                    //this is where I need to work next.
                {
                    Console.WriteLine("Process: {0} ID: {1}", process.ProcessName, process.Id);
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