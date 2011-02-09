using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LogViewer
{
    public class LogEntry
    {
        private string[] _numberEntryPair;

        public LogEntry(string number, string entry)
        {
            _numberEntryPair = new string[] { number, entry };
        }

        public string[] EntryPair()
        {
            return _numberEntryPair;
        }
    }
}
