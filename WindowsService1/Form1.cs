using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerUsageAnalyzer
{
    public partial class PCMonitorWindow : Form
    {
        private string[] _week = {"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
        private DataSet _history;

        public PCMonitorWindow()
        {
            InitializeComponent();
            Console.WriteLine("Error");
        }

        public PCMonitorWindow(DataSet history)
        {
            InitializeComponent();
            String[] users = Directory.GetDirectories("C://Users");
            for (int i = 0; i < users.Length; i++)
                UserChooser.Items.Add(users[i].Substring(10));
            foreach (string day in _week)
                DayChooser.Items.Add(day);
            ProgramChooser.Items.Add("New Program");
            _history = history;
        }

        private void ProgramChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProgramChooser.SelectedItem == "New Program")
            {
                NewProgramLabel.Visible = true;
                ProcessNameInput.Visible = true;
            }
            else
            {
                NewProgramLabel.Visible = false;
                ProcessNameInput.Visible = false;
            }
        }

        private void UserChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            HashSet<string> listy = new HashSet<string>();
            foreach (String user in UserChooser.CheckedItems)
            {
                try
                {
                    if (_history.Tables.Contains(("Penalties_" + user)))
                    {
                        foreach (DataRow row in _history.Tables["Penalties_" + user].Rows)
                        {
                            listy.Add(row["Program Name"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in loading programs in Form1: {0}", ex.Message.ToString());
                }
            }
            ProgramChooser.Items.Clear();
            ProgramChooser.Items.Add("New Program");
            foreach (String entry in listy) ProgramChooser.Items.Add(entry);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ProcName = ProcessNameInput.Text;
            foreach (String user in UserChooser.CheckedItems)
            {
                string PTName = "Penalties_" + user;
                if (_history.Tables.Contains(PTName))
                {
                    
                }
            }
            this.Close();
        }
        
    }
}
