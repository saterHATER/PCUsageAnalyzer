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
            _form.killIcon();
        }
    }

    class Scheduler
    {
        System.Timers.Timer _oTimer = null;
        private static int _interval = 10000;
        private HistoryStorage _appCollector;
        public ComputerManager _PolicyPusher;

        public void Start(HistoryStorage hs)
        {
            ComputerManager _PolicyPusher = new ComputerManager();
            _oTimer = new System.Timers.Timer(_interval);
            _oTimer.AutoReset = true;
            _oTimer.Enabled = true;
            _oTimer.Start();
            _appCollector = hs;
            _oTimer.Elapsed += new System.Timers.ElapsedEventHandler(oTimerElapsed);
        }

        public void oTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<String> progList = new List<String>();
            progList = _appCollector.sample();
            foreach (String prog in progList)
            {
                Console.Write(prog + " ");
                Console.WriteLine(_appCollector.getPenalty(prog, 0, DateTime.Now));
            }
        }

        public void processPenalties(List<String> Programs)
        {
            
        }

        public void closeUp()
        {
            
        }

    }

    class ComputerManager
    {
        protected double _POINTS;
        protected double _TRAILOFF = 0.25;
        protected int _LOOKBACKS = 2;

        public ComputerManager()
        {
            double _POINTS = new double();
            _POINTS = 0.00;
        }

        public double GetPoints()
        {
            return _POINTS;
        }

        public void UpdatePoints(List<float> progvals)
        {
            foreach(Double pts in progvals)
            {
                _POINTS -= pts;
                if (_POINTS <= 0.00) CutOffUser();
            }

        }

        private static void CutOffUser()
        {
            System.Diagnostics.Process.Start("shutdown", "/l /f");
        }

        private static void KillProcess(Process process)
        {
            process.Kill();
        }

        public int getLoopbacks()
        {
            return _LOOKBACKS;
        }

    }
}