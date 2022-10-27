using System;

namespace Ladeskab.Interfaces
{
    public class DoorEventArgs : EventArgs
    {
        public bool DoorOpen { get; set; }
    }

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorEvent;

        public void OnStateChange(int LockState);
    }
}