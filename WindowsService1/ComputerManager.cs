using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Management;
using System.Windows.Forms;


namespace WindowsService1
{
    class ComputerManager
    {
        private static HistoryStorage _DataSetManager; 

        static ComputerManager()
        {
            _DataSetManager = new HistoryStorage();
            Application.Run(new PenaltyCreator());
        }

        public void sample()
        {
            _DataSetManager.sample();
        } 

        private static void CutOffUser()
        {
            System.Diagnostics.Process.Start("shutdown", "/l /f");
        }

    }
}