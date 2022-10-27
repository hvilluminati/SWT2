using System;

namespace Ladeskab.Interfaces
{
    public class rfidEventArgs : EventArgs
    {
        public int id {get; set; }
    }

    
    public interface IRfidReader
    {
        event EventHandler<rfidEventArgs>rfidEvent;
        public void OnRfidRead(int newId);
    }
};