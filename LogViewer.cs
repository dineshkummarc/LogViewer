using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LogViewer
{
    public partial class LogViewer : Form
    {
        public List<LogEntry> MyLogEntryList { get; private set; }
        public string FilePath { get; private set; }
        public bool Include { get; private set; }

        public LogViewer()
        {
            InitializeComponent();
            MyLogEntryList = new List<LogEntry>();
            cboFilterSetting.Items.Add("Include:");
            cboFilterSetting.Items.Add("Exclude:");
            cboFilterSetting.SelectedIndex = 0;
            Include = true;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            if (openFile.FileName == null)
            {
                return;
            }
            this.FilePath = openFile.FileName;

            ReadLogDataFromFile();
            AddEntries();
        }

        private void ReadLogDataFromFile()
        {
            if (File.Exists(FilePath))
            {
                MyLogEntryList.Clear();
                StreamReader file = null;
                string line;
                int lineNumber = 1;
                try
                {
                    file = new StreamReader(FilePath);
                    while ((line = file.ReadLine()) != null)
                    {
                        MyLogEntryList.Add(new LogEntry(lineNumber.ToString(), line));
                        lineNumber++;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
            }
        }

        private void AddEntries()
        {
            int count = 0;
            lvMain.BeginUpdate();
            lvMain.Items.Clear();
            foreach (var entry in MyLogEntryList)
            {
                string searchString = "";
                string entryTestString = "";

                if ((cbxHideBlankLines.Checked == true) && (entry.EntryText == ""))
                {
                    continue;
                }

                if (cbxIgnoreCase.Checked == true)
                {
                    searchString = txtFilterText.Text.ToUpper();
                    entryTestString = entry.EntryText.ToUpper();
                }
                else
                {
                    searchString = txtFilterText.Text;
                    entryTestString = entry.EntryText;
                }

                if (Include)
                {
                    if (entryTestString.Contains(searchString))
                    {
                        lvMain.Items.Add(new ListViewItem(entry.ToArray()));
                        count++;
                    }
                }
                else
                {
                    if (!entryTestString.Contains(searchString))
                    {
                        lvMain.Items.Add(new ListViewItem(entry.ToArray()));
                        count++;
                    }
                }
            }
            lvMain.EndUpdate();
            UpdateEntryCounts(count);
            return;
        }       

        private void cboFilterSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFilterSetting.SelectedIndex)
            {
                case 0:
                    Include = true;
                    break;
                case 1:
                    Include = false;
                    break;
                default:
                    break;
            }
            AddEntries();
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            AddEntries();
        }

        private void UpdateEntryCounts(int count)
        {
            lblResults.Text = "Showing: " + count.ToString() +
                " of " + MyLogEntryList.Count.ToString();
        }

        private void cbxHideBlankLines_CheckedChanged(object sender, EventArgs e)
        {
            AddEntries();
        }

        private void cbxIgnoreCase_CheckedChanged(object sender, EventArgs e)
        {
            AddEntries();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            MyLogEntryList.Clear();
            AddEntries();
        }
    }
}
