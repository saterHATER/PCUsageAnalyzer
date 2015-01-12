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
            foreach (String User in UserChooser.CheckedItems)
            {
                try
                {
                    DataTable dt = _history.Tables["Penalties_" + User];
                    DataSetHelper inputter = new DataSetHelper();
                    String program = ProgramChooser.SelectedItem.ToString();
                    int sTime = FormatIntInput(StartTimeInput.Text);
                    int eTime = FormatIntInput(EndTimeInput.Text);
                    double val = Double.Parse(PenaltyValueInput.Text);
                    for (int i = 0; i < DayChooser.Items.Count; i++)
                    {
                        if (DayChooser.GetItemChecked(i))
                        {
                            inputter.UpdateProgram(dt, program, i, sTime, eTime, val);
                        }
                    }
                
                }
                catch (Exception elf)
                {
                    Console.WriteLine("I'm Expecting this: {0}", elf.Message);
                }
            }
            Console.WriteLine("Uhh, I got done with this stanza!");
        }

        private static int FormatIntInput(String input)
        {
            int totalMinutes = 0;
            try
            {
                String[] hrsNmns = input.Split(':');
                totalMinutes += 60 * int.Parse(hrsNmns[0]);
                totalMinutes += int.Parse(hrsNmns[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting data: {0}", e.Message);
            }
            return totalMinutes;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void PCMonitorWindow_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Minimize to Tray App";
            notifyIcon1.BalloonTipText = "You have successfully minimized your form.";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void PCMonitorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            notifyIcon1.BalloonTipTitle = "Minimize to Tray App";
            notifyIcon1.BalloonTipText = "You have successfully minimized your form.";
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500);
            this.Hide();
        }
        

    }
}