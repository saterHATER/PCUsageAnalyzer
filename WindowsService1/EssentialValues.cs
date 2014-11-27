using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class EssentialValues
    {
        private static Dictionary<string, DateTime> AllottedTimes;

        private static Dictionary<string, DateTime> ObservedPrograms;

        private static DateTime startTime;

        static EssentialValues()
        {
            AllottedTimes = new Dictionary<string, DateTime>();
            ObservedPrograms = new Dictionary<string, DateTime>();
            startTime = DateTime.Now;
        }

        public void getAllotedTimes(Dictionary<String, int> allotments)
            /*  I'll expodite all of my variable grabbing to the 
             *  computer Manager. It should have a better grasp of
             *  who the user is and where to get the values.*/
        {

        }

    }
}
