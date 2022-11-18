using System.CodeDom.Compiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using System.Xml.Linq;
using System.ComponentModel;

namespace Ladeskab.Interfaces
{
    public interface IStationControl
    {
        void RfidDetected(object sender, rfidEventArgs e);

        void DoorHandler(object sender, DoorEventArgs e);
    }
}