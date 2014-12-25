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
            ProgramChooser.Items.Add("New Program");
            _history = history;
            DataSetHelper something = new DataSetHelper();
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

        private class DataSetHelper : PenaltyValues{}

        private void button1_Click(object sender, EventArgs e)
        {
            DataSetHelper inputter = new DataSetHelper();
            inputter.UpdateProgram("ONENOTE", 1, 2, 3, 4.0);
            Console.WriteLine("LOLZ");
        }

        private static int FormatIntInput(String input)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting data: {0}", e.Message);
            }
            return 1;
        }
        
    }
}
