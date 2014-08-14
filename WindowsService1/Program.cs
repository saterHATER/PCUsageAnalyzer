using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            MySettings ms = new MySettings();                                                               //this is code for my xml settings thingy
            ms.DatabaseConnection = "my database";                                                          //
            ms.LastAction = "print";                                                                        //
            string PathToSave = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);  //
            string FileName = Path.Combine(PathToSave,"mysettings.txt");
            ms.SaveToFile(FileName);
            
            /* Retrieve Settings */
            
            MySettings ms1 = MySettings.ReadFromFile(FileName);
            Console.WriteLine(ms1.LastAction);

#if DEBUG
            Service1 myService = new Service1();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
