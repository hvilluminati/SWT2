using System;

namespace RFIDReader
{
    public class rfidReader : IRfidReader
    {
        
        private int _oldId;

        public event EventHandler<rfidEventArgs>? rfidEvent;

        public void scanId(int newId)
        {
            onRfid(new rfidEventArgs {id = newId});
            _oldId = newId;
        }

        public void onRfid(rfidEventArgs e)
        {
            rfidEvent?.Invoke(this, e);
        }
    }
}