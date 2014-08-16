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

        runningApps appCollector;
        System.Timers.Timer oTimer = null;
        double interval = 10000;

        public void Start()
        {
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Start();

            appCollector = new runningApps();

            oTimer.Elapsed += new System.Timers.ElapsedEventHandler(oTimerElapsed);
        }

        public void oTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            appCollector.sample();
        }

    }
}