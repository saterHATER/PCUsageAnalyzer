using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

using System.IO;
using System.Runtime.InteropServices;


namespace WindowsService1
{
    class ComputerManager
    /* This will be what physically gather's up all programs, logs out the user, keeps
     * track of the bad stuff being consumed...etc. */
    {
        private static HistoryDataTable _History;      //This keeps track of the program usage.

        private static HistoryStorage _testDS;          //This is my dataset manager.

        static ComputerManager()
            //this is where I need to add settings 'n sh**. I need to establish the user and the
            //apps that are in question. Let's angle for a more analysis role for now. It's baby
            //stuff to go down the PC route.
        {
            _testDS = new HistoryStorage();
            //_History = new HistoryDataTable();
            //_testDS.AddHistory(_History.GetDataTable());
        }


        public void sample()
        {
            _testDS.sample();
        }


        private static void CutOffUser()
        {
            System.Diagnostics.Process.Start("shutdown", "/l /f");
        }


    }
}