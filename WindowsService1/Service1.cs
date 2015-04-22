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
        private ComputerManager _PolicyPusher;

        public void Start(HistoryStorage hs)
        {
            _PolicyPusher = new ComputerManager();
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
            processPenalties(progList);
        }

        public void processPenalties(List<String> Programs)
        {
            double diminish = _PolicyPusher.getDimishVal();         //this is a --> x*a^(n)
            int loopback = _PolicyPusher.getLoopbacks();            //this is n --> x*a^(n)
            double totalPenalty = 0.0;
            foreach (String prog in Programs)
            {
                double initVal = _appCollector.getPenalty(prog, 0, DateTime.Now);
                double tot4prog = 0.0;
                for (int j = 0; j < loopback; j++)
                {
                    double vall = Math.Pow(diminish, j);
                    tot4prog += (vall * initVal);
                }
                Console.WriteLine(prog + " " + tot4prog);
                totalPenalty += tot4prog;
            }
            totalPenalty = 1.0 - totalPenalty;
            Console.WriteLine("\nTotal Penalties for this moment: {0}", totalPenalty);
            _PolicyPusher.RecievePoints(totalPenalty);
            Console.WriteLine("New point value: {0}\n", _PolicyPusher.GetPoints());            
        }

        public void closeUp()
        {
            
        }

    }

    class ComputerManager
    {
        private double _POINTS;
        private double _TRAILOFF = .4;
        private int _LOOKBACKS = 5;

        public ComputerManager()
        {
            _POINTS = 1.00;
        }

        public double GetPoints()
        {
            return _POINTS;
        }

        public void RecievePoints(double points)
        {
            _POINTS *= points;
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

        public double getDimishVal()
        {
            return _TRAILOFF;
        }

    }
}