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
        public bool FilterUsingTextString { get; private set; }
        public bool RemoveEntriesContainingText { get; private set; }

        public LogViewer()
        {
            InitializeComponent();
            MyLogEntryList = new LogEntryList();
            cboFilterSetting.Items.Add("No Filter Applied");
            cboFilterSetting.Items.Add("Filter - Remove Entries Containing This Text");
            cboFilterSetting.Items.Add("Filter - Show Only Entries Containing This Text");
            cboFilterSetting.SelectedIndex = 0;
            FilterUsingTextString = false;
            RemoveEntriesContainingText = true;
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
            lvMain.BeginUpdate();
            lvMain.Items.Clear();
            foreach (var entry in MyLogEntryList)
            {
                if (FilterUsingTextString && RemoveEntriesContainingText &&
                    txtFilterText.Text != "" &&
                    entry.EntryText.Contains(txtFilterText.Text))
                {
                    continue;
                }

                if (FilterUsingTextString && !RemoveEntriesContainingText &&
                    txtFilterText.Text != "" &&
                    !entry.EntryText.Contains(txtFilterText.Text))
                {
                    continue;
                }
                lvMain.Items.Add(new ListViewItem(entry.ToArray()));
            }
            lvMain.EndUpdate();
        }

        private void cboFilterSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilterSetting.SelectedIndex == 0)
            {
                FilterUsingTextString = false;
                txtFilterText.ReadOnly = true;
            }

            if (cboFilterSetting.SelectedIndex == 1)
            {
                FilterUsingTextString = true;
                txtFilterText.ReadOnly = false;
                RemoveEntriesContainingText = true;
            }

            if (cboFilterSetting.SelectedIndex == 2)
            {
                FilterUsingTextString = true;
                txtFilterText.ReadOnly = false;
                RemoveEntriesContainingText = false;
            }
            DisplayLogEntries();
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            DisplayLogEntries();
        }
    }
}
