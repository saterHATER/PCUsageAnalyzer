using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ComputerUsageAnalyzer
{

    public partial class Service1 : ServiceBase
    {
        
        //<new shit>
        private HistoryStorage _DataSetManager;   
        //</new shit>

        public Service1()
        {
            InitializeComponent();
            InitializeScheduler(); 
        }

        private void InitializeScheduler()//I want all of this gone.
        {
            _DataSetManager = new HistoryStorage();
            Scheduler osheduler = new Scheduler();
            osheduler.Start(_DataSetManager);
            osheduler.LaunchForm();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();//I want this gone  
            stopWatch.Start();                    //this too.  
        }

        protected override void OnStop()
        {

        }
    }

    class Scheduler
    {
        System.Timers.Timer oTimer = null;
        private static int interval = 10000;
        private HistoryStorage _appCollector;

        public void Start(HistoryStorage ac)
        {
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Start();
            _appCollector = ac;
            oTimer.Elapsed += new System.Timers.ElapsedEventHandler(oTimerElapsed);
        }

        public void LaunchForm()
        {
            //PCMonitorWindow dumbdumb = new PCMonitorWindow(_appCollector.GetDataSet());
            Application.Run(new PCMonitorWindow(_appCollector.GetDataSet()));
        }

        public void oTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _appCollector.sample();
        }

        public void closeUp()
        {
            
        }

    }
}
