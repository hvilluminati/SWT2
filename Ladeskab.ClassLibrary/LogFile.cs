using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class LogFile : ILogFile
    {
        public string FileName { get; set; }
        public LogFile(string fileName)
        {
            FileName = fileName;
        }
        public void LogDoorLocked(int id)
        {
            using var writer = File.AppendText(FileName);
            writer.WriteLine(DateTime.Now + " - Door locked with ID: " + id);
        }
        public void LogDoorUnlocked(int id)
        {
            using var writer = File.AppendText(FileName);
            writer.WriteLine(DateTime.Now + " - Door unlocked with ID: " + id);
        }
    }
}
