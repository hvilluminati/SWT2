using System;

namespace RFIDReader
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