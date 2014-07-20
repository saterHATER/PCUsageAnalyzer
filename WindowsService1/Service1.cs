using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace WindowsService1
{

    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
            InitializeScheduler();
        }

        private void InitializeScheduler()
        {
            Scheduler osheduler = new Scheduler();
            osheduler.Start();
        }

        public void OnDebug()           //Lets see if I can add a dubugger class, if not, delete this and form a new strategy.
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();  //This allows me to have regular routined function calls
            stopWatch.Start();                      //initialization 

            sampleFileCreation();                   //I'm following a tutorial, this may be of import later.
        }

        private void sampleFileCreation()
        {
            string filePath = @"C:\Users\Dev\Documents\visual studio 2013\Projects\WindowsService1\WindowsService1\sample.txt";
            string dateTime = DateTime.Now.ToString();

            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            fileWriter.WriteLine("\n" + dateTime);
            fileWriter.Close();

        }

        protected override void OnStop(){

        }
    }
}
