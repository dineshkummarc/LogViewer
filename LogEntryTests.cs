using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LogViewer
{
    [TestFixture]
    class LogEntryTests
    {
        [Test]
        public void ConstructorTest()
        {
            var number = "55";
            var entryText = "Error is database!";
            var entry = new LogEntry(number, entryText);
            Assert.AreEqual(number, entry.LineNumber);
            Assert.AreEqual(entryText, entry.EntryText);
        }

        [Test, Combinatorial]
        public void ConstructorTest
            (
            [Values("34534", "11222", "234534667", null, "")]
            string number,
            [Values("hi", "whats up", "errors559", null, "")]
            string entryText
            )
        {
            var entry = new LogEntry(number, entryText);
            Assert.AreEqual(number, entry.LineNumber);
            Assert.AreEqual(entryText, entry.EntryText);
        }

        [Test]
        public void ToArrayTest()
        {
            string number = "734";
            string entryText = "restarting NSD, please wait...";
            string[] logEntryArray = new string[] { "734", "restarting NSD, please wait..." };
            var entry = new LogEntry(number, entryText);
            Assert.AreEqual(logEntryArray, entry.ToArray());
            Assert.AreEqual(2, entry.ToArray().Length);
        }
    }
}
