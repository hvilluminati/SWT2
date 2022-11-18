using System.CodeDom.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab.Interfaces
{
    public interface IChargeControl
    {
        double CurrentValue { get; set; }

        bool IsConnected();

        void StartCharge();

        void StopCharge();

    }
}
