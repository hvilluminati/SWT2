using System;
using System.IO;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door: IDoor
    {
        public event EventHandler<DoorEventArgs>? DoorEvent;

        public bool Locked { get; private set; }
        public bool Open { get; private set; }

        public void UnlockDoor()
        {
            Locked = false;
        }

        public void LockDoor()
        {
            Locked = true;
        }

        public void DoorOpened()
        {
            Open = true;
            DoorEvent?.Invoke(this, new DoorEventArgs { DoorOpen = Open });
        }
        public void DoorClosed()
        {
            Open = false;
            DoorEvent?.Invoke(this, new DoorEventArgs { DoorOpen = Open });
        }
    }
}