using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LogViewer
{
    public class LogEntry
    {
        public string LineNumber { get; private set; }
        public string EntryText { get; private set; }

        public LogEntry(string number, string entry)
        {
            this.LineNumber = number;
            this.EntryText = entry;
        }

        public string[] ToArray()
        {
            return new string[] { LineNumber, EntryText };
        }
    }
}
