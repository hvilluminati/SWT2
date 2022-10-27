using System;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class rfidReader : IRfidReader
    {
        public event EventHandler<rfidEventArgs>? rfidEvent;

        public void OnRfidRead(int newId)
        {
            rfidEvent?.Invoke(this, new rfidEventArgs { id = newId });
        }
    }
}