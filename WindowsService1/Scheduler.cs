using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{

    class Scheduler
    {

        System.Timers.Timer oTimer = null;
        double interval = 20000;

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
        }

        void FileCreation()
        {
            string filePath = @"C:\Users\Dev\Documents\visual studio 2013\Projects\WindowsService1\WindowsService1\sample.txt";
            string dateTime = DateTime.Now.ToString();

            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            fileWriter.WriteLine("\n" + dateTime);
            fileWriter.Close();
        }

    }
}