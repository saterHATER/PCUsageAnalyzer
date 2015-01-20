namespace ComputerUsageAnalyzer
{
    partial class PCMonitorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCMonitorWindow));
            this.StartTimeInput = new System.Windows.Forms.TextBox();
            this.EndTimeInput = new System.Windows.Forms.TextBox();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.EndTimeLable = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.PenaltyLabel = new System.Windows.Forms.Label();
            this.PenaltyValueInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ProgramChooser = new System.Windows.Forms.ComboBox();
            this.DayChooser = new System.Windows.Forms.CheckedListBox();
            this.UserChooser = new System.Windows.Forms.CheckedListBox();
            this.NewProgramLabel = new System.Windows.Forms.Label();
            this.ProcessNameInput = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.UsageViewerTab = new System.Windows.Forms.TabPage();
            this.TableChooser = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PenaltyCreatorTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.UsageViewerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PenaltyCreatorTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartTimeInput
            // 
            this.StartTimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimeInput.Location = new System.Drawing.Point(110, 132);
            this.StartTimeInput.Name = "StartTimeInput";
            this.StartTimeInput.Size = new System.Drawing.Size(237, 20);
            this.StartTimeInput.TabIndex = 0;
            this.StartTimeInput.Text = "HH:MM (24 hr mode)";
            // 
            // EndTimeInput
            // 
            this.EndTimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTimeInput.Location = new System.Drawing.Point(110, 171);
            this.EndTimeInput.Name = "EndTimeInput";
            this.EndTimeInput.Size = new System.Drawing.Size(240, 20);
            this.EndTimeInput.TabIndex = 9;
            this.EndTimeInput.Text = "HH:MM (24 hr mode)";
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(108, 116);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.StartTimeLabel.TabIndex = 10;
            this.StartTimeLabel.Text = "Start Time";
            // 
            // EndTimeLable
            // 
            this.EndTimeLable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTimeLable.AutoSize = true;
            this.EndTimeLable.Location = new System.Drawing.Point(108, 155);
            this.EndTimeLable.Name = "EndTimeLable";
            this.EndTimeLable.Size = new System.Drawing.Size(52, 13);
            this.EndTimeLable.TabIndex = 11;
            this.EndTimeLable.Text = "End Time";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "BLAH BLAH BLAH";
            this.notifyIcon1.BalloonTipTitle = "Card Games";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "PC Usage Analyzer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // PenaltyLabel
            // 
            this.PenaltyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PenaltyLabel.AutoSize = true;
            this.PenaltyLabel.Location = new System.Drawing.Point(107, 194);
            this.PenaltyLabel.Name = "PenaltyLabel";
            this.PenaltyLabel.Size = new System.Drawing.Size(72, 13);
            this.PenaltyLabel.TabIndex = 14;
            this.PenaltyLabel.Text = "Penalty Value";
            // 
            // PenaltyValueInput
            // 
            this.PenaltyValueInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PenaltyValueInput.Location = new System.Drawing.Point(111, 210);
            this.PenaltyValueInput.Name = "PenaltyValueInput";
            this.PenaltyValueInput.Size = new System.Drawing.Size(239, 20);
            this.PenaltyValueInput.TabIndex = 13;
            this.PenaltyValueInput.Text = "#.###";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(111, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 37);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save Penalty!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgramChooser
            // 
            this.ProgramChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgramChooser.FormattingEnabled = true;
            this.ProgramChooser.Location = new System.Drawing.Point(109, 0);
            this.ProgramChooser.Name = "ProgramChooser";
            this.ProgramChooser.Size = new System.Drawing.Size(241, 21);
            this.ProgramChooser.TabIndex = 17;
            this.ProgramChooser.Text = "Choose Program";
            this.ProgramChooser.SelectedIndexChanged += new System.EventHandler(this.ProgramChooser_SelectedIndexChanged);
            // 
            // DayChooser
            // 
            this.DayChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DayChooser.CheckOnClick = true;
            this.DayChooser.FormattingEnabled = true;
            this.DayChooser.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.DayChooser.Location = new System.Drawing.Point(2, 161);
            this.DayChooser.Name = "DayChooser";
            this.DayChooser.Size = new System.Drawing.Size(103, 109);
            this.DayChooser.TabIndex = 19;
            // 
            // UserChooser
            // 
            this.UserChooser.CheckOnClick = true;
            this.UserChooser.FormattingEnabled = true;
            this.UserChooser.Location = new System.Drawing.Point(0, 3);
            this.UserChooser.Name = "UserChooser";
            this.UserChooser.Size = new System.Drawing.Size(104, 154);
            this.UserChooser.TabIndex = 20;
            this.UserChooser.SelectedIndexChanged += new System.EventHandler(this.UserChooser_SelectedIndexChanged);
            // 
            // NewProgramLabel
            // 
            this.NewProgramLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewProgramLabel.AutoSize = true;
            this.NewProgramLabel.Location = new System.Drawing.Point(108, 77);
            this.NewProgramLabel.Name = "NewProgramLabel";
            this.NewProgramLabel.Size = new System.Drawing.Size(76, 13);
            this.NewProgramLabel.TabIndex = 22;
            this.NewProgramLabel.Text = "Process Name";
            this.NewProgramLabel.Visible = false;
            // 
            // ProcessNameInput
            // 
            this.ProcessNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessNameInput.Location = new System.Drawing.Point(110, 93);
            this.ProcessNameInput.Name = "ProcessNameInput";
            this.ProcessNameInput.Size = new System.Drawing.Size(237, 20);
            this.ProcessNameInput.TabIndex = 21;
            this.ProcessNameInput.Tag = "";
            this.ProcessNameInput.Text = "Process Name";
            this.ProcessNameInput.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.UsageViewerTab);
            this.tabControl1.Controls.Add(this.PenaltyCreatorTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(358, 303);
            this.tabControl1.TabIndex = 2;
            // 
            // UsageViewerTab
            // 
            this.UsageViewerTab.Controls.Add(this.TableChooser);
            this.UsageViewerTab.Controls.Add(this.dataGridView1);
            this.UsageViewerTab.Location = new System.Drawing.Point(4, 22);
            this.UsageViewerTab.Name = "UsageViewerTab";
            this.UsageViewerTab.Padding = new System.Windows.Forms.Padding(3);
            this.UsageViewerTab.Size = new System.Drawing.Size(350, 277);
            this.UsageViewerTab.TabIndex = 1;
            this.UsageViewerTab.Text = "View Usage";
            this.UsageViewerTab.UseVisualStyleBackColor = true;
            // 
            // TableChooser
            // 
            this.TableChooser.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableChooser.FormattingEnabled = true;
            this.TableChooser.Location = new System.Drawing.Point(3, 3);
            this.TableChooser.Name = "TableChooser";
            this.TableChooser.Size = new System.Drawing.Size(344, 21);
            this.TableChooser.TabIndex = 1;
            this.TableChooser.SelectedIndexChanged += new System.EventHandler(this.TableChooser_SelectedIndexChanged);
            this.TableChooser.SelectedValueChanged += new System.EventHandler(this.UserChooser_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(344, 271);
            this.dataGridView1.TabIndex = 0;
            // 
            // PenaltyCreatorTab
            // 
            this.PenaltyCreatorTab.Controls.Add(this.UserChooser);
            this.PenaltyCreatorTab.Controls.Add(this.NewProgramLabel);
            this.PenaltyCreatorTab.Controls.Add(this.DayChooser);
            this.PenaltyCreatorTab.Controls.Add(this.ProcessNameInput);
            this.PenaltyCreatorTab.Controls.Add(this.ProgramChooser);
            this.PenaltyCreatorTab.Controls.Add(this.button1);
            this.PenaltyCreatorTab.Controls.Add(this.PenaltyLabel);
            this.PenaltyCreatorTab.Controls.Add(this.StartTimeInput);
            this.PenaltyCreatorTab.Controls.Add(this.PenaltyValueInput);
            this.PenaltyCreatorTab.Controls.Add(this.EndTimeInput);
            this.PenaltyCreatorTab.Controls.Add(this.EndTimeLable);
            this.PenaltyCreatorTab.Controls.Add(this.StartTimeLabel);
            this.PenaltyCreatorTab.Location = new System.Drawing.Point(4, 22);
            this.PenaltyCreatorTab.Name = "PenaltyCreatorTab";
            this.PenaltyCreatorTab.Padding = new System.Windows.Forms.Padding(3);
            this.PenaltyCreatorTab.Size = new System.Drawing.Size(350, 277);
            this.PenaltyCreatorTab.TabIndex = 0;
            this.PenaltyCreatorTab.Text = "Add Penalty";
            this.PenaltyCreatorTab.UseVisualStyleBackColor = true;
            // 
            // PCMonitorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 303);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PCMonitorWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PC Monitor Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PCMonitorWindow_FormClosing);
            this.Resize += new System.EventHandler(this.PCMonitorWindow_Resize);
            this.tabControl1.ResumeLayout(false);
            this.UsageViewerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PenaltyCreatorTab.ResumeLayout(false);
            this.PenaltyCreatorTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox StartTimeInput;
        private System.Windows.Forms.TextBox EndTimeInput;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Label EndTimeLable;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label PenaltyLabel;
        private System.Windows.Forms.TextBox PenaltyValueInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ProgramChooser;
        private System.Windows.Forms.CheckedListBox DayChooser;
        private System.Windows.Forms.CheckedListBox UserChooser;
        private System.Windows.Forms.Label NewProgramLabel;
        private System.Windows.Forms.TextBox ProcessNameInput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PenaltyCreatorTab;
        private System.Windows.Forms.TabPage UsageViewerTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox TableChooser;
    }
}