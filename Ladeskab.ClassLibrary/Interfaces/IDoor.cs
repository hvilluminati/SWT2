using System;

namespace Ladeskab.Interfaces
{
    public class DoorEventArgs : EventArgs
    {
        public bool DoorState { get; set; }
    }

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorEvent;

        bool _Lockstate{ get;}

        public void OnStateChange();
    }
}