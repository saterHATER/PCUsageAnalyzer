using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace ComputerUsageAnalyzer
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
        }

        protected override void OnStop()
        {

        }
    }
}
