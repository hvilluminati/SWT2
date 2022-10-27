using System;
using System.IO;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door: IDoor
    {
        public event EventHandler<DoorEventArgs>? DoorEvent;

        public int LockState = 0;

        public void UnlockDoor(int LockState)
        {
            if (LockState == 1)
            {
                LockState = 0;
            }
        }

        public void LockDoor(int LockState)
        {
            if (LockState == 0)
            {
                LockState = 1;
            }
        }

        public void OnStateChange(int LockState)
        {
            DoorEvent?.Invoke(this, new DoorEventArgs { DoorState = this.LockState});
        }
    }
}