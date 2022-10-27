using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public interface ILogFile
    {
        string FileName { get; set; }
        public void LogDoorLocked(int id);
        public void LogDoorUnlocked(int id);
    }
}
