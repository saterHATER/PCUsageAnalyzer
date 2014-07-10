using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1{

    public partial class Service1 : ServiceBase{

        public Service1(){
            InitializeComponent();
        }

        protected override void OnStart(string[] args){
            Stopwatch stopWatch = new Stopwatch();  //we'll start by starting a new stopwatch
            stopWatch.Start();                      //tracking the user's time logged in shall commence     

            sampleFileCreation();                   //I'm following a tutorial
        }

        private void sampleFileCreation(){
            string filePath = @"C:\Users\Dev\Documents\visual studio 2013\Projects\WindowsService1\WindowsService1\sample.txt";
            string dateTime = DateTime.Now.ToString();

            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(filePath, true);
            fileWriter.WriteLine("\n" + dateTime);
            fileWriter.Close();

        }

        protected override void OnStop(){

        }
    }
}
