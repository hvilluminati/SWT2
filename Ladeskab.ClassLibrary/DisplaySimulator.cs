using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class DisplaySimulator : IDisplay
    {
        public void Print(string print)
        {
            Console.WriteLine(print);
        }

    }
}
