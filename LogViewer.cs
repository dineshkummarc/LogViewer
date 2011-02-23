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
        public LogEntryList MyLogEntryList { get; private set; }
        public string FilePath { get; private set; }
        public bool ApplyingFilter { get; private set; }
        public bool ShowContaining { get; private set; }

        public LogViewer()
        {
            InitializeComponent();
            MyLogEntryList = new LogEntryList();
            cboFilterSetting.Items.Add("No Filter Applied!");
            cboFilterSetting.Items.Add("Show Only Containing:");
            cboFilterSetting.Items.Add("Show Not Containing:");
            cboFilterSetting.SelectedIndex = 0;
            ApplyingFilter = false;
            ShowContaining = true;
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
            DisplayLogEntries();
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

        private void DisplayLogEntries()
        {
            if (!ApplyingFilter)
            {
                lvMain.BeginUpdate();
                lvMain.Items.Clear();
                foreach (var entry in MyLogEntryList)
                {
                    lvMain.Items.Add(new ListViewItem(entry.ToArray()));
                }
                lvMain.EndUpdate();
                UpdateEntryCounts(MyLogEntryList.Count);
                return;
            }
            else
            {
                if (ShowContaining)
                {
                    int count = 0;
                    lvMain.BeginUpdate();
                    lvMain.Items.Clear();
                    foreach (var entry in MyLogEntryList)
                    {
                        if (entry.EntryText.Contains(txtFilterText.Text))
                        {
                            lvMain.Items.Add(new ListViewItem(entry.ToArray()));
                            count++;
                        }
                    }
                    lvMain.EndUpdate();
                    UpdateEntryCounts(count);
                    return;
                }
                else
                {
                    int count = 0;
                    lvMain.BeginUpdate();
                    lvMain.Items.Clear();
                    foreach (var entry in MyLogEntryList)
                    {
                        if (!entry.EntryText.Contains(txtFilterText.Text))
                        {
                            lvMain.Items.Add(new ListViewItem(entry.ToArray()));
                            count++;
                        }
                    }
                    lvMain.EndUpdate();
                    UpdateEntryCounts(count);
                    return;
                }
            }
        }

        private void cboFilterSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFilterSetting.SelectedIndex)
            {
                case 0:
                    ApplyingFilter = false;
                    txtFilterText.ReadOnly = true;
                    break;
                case 1:
                    ApplyingFilter = true;
                    txtFilterText.ReadOnly = false;
                    ShowContaining = true;
                    break;
                case 2:
                    ApplyingFilter = true;
                    txtFilterText.ReadOnly = false;
                    ShowContaining = false;
                    break;
                default:
                    break;
            }
            DisplayLogEntries();
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            DisplayLogEntries();
        }

        private void UpdateEntryCounts(int filterCount)
        {
            txtFilterCount.Text = filterCount.ToString();
            txtFileCount.Text = MyLogEntryList.Count.ToString();
        }
    }
}
