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

        public LogViewer()
        {
            InitializeComponent();
            MyLogEntryList = new LogEntryList();
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
            ReadLogDataFromFile(openFile.FileName);
            DisplayLogEntries();
        }

        private void ReadLogDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                MyLogEntryList.Clear();
                StreamReader file = null;
                string line;
                int lineNumber = 1;
                try
                {
                    file = new StreamReader(filePath);
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
            lvMain.Items.Clear();
            foreach (LogEntry entry in MyLogEntryList)
            {
                lvMain.Items.Add(new ListViewItem(entry.EntryPair()));
            }
        }
    }
}
