using System;

namespace Ladeskab.Interfaces
{
    public class DoorEventArgs : EventArgs
    {
        public int DoorState { get; set; }
    }

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorEvent;

        public void OnStateChange(int LockState);
    }
}