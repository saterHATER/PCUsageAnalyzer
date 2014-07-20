using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;   //new class?

namespace WindowsService1
{

    class Scheduler
    {

        System.Timers.Timer oTimer = null;
        double interval = 10000;

        public void Start()
        {
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Start();

            oTimer.Elapsed += new System.Timers.ElapsedEventHandler(oTimerElapsed);
        }

        public void oTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FileCreation();
            cacheProcesses();
        }

        void FileCreation()
        {
            string filePath = @"C:\Users\Dev\Documents\visual studio 2013\Projects\WindowsService1\WindowsService1\sample.txt";
            string dateTime = DateTime.Now.ToString();

            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            fileWriter.WriteLine("\n" + dateTime);
            fileWriter.Close();
        }

        private void cacheProcesses() //THIS IS THE TEST OF
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