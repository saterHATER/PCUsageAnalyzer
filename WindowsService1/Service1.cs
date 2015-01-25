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
        private PCMonitorWindow _form;

        public Service1()
        {
            InitializeComponent();
            InitializeStuff(); 
        }

        private void InitializeStuff()//I want all of this gone.
        {
            _form = new PCMonitorWindow();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Application.Run(_form);
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

        public void Start(HistoryStorage hs)
        {
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Start();
            _appCollector = hs;
            oTimer.Elapsed += new System.Timers.ElapsedEventHandler(oTimerElapsed);
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
