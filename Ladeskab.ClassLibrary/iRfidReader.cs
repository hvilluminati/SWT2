using System;

namespace RFIDReader
{
    public class rfidEventArgs : EventArgs
    {
        public int id {get; set; }
    }

    
    public interface IRfidReader
    {
         event EventHandler<rfidEventArgs>RfidDetected;

    }
};