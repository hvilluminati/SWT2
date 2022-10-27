using System;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class rfidReader : IRfidReader
    {
        public event EventHandler<rfidEventArgs>? rfidEvent;

        public void scanId(int newId)
        {
            onRfid(new rfidEventArgs {id = newId});
        }

        public void onRfid(rfidEventArgs e)
        {
            rfidEvent?.Invoke(this, e);
        }
    }
}