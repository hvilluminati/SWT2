using System;
using System.IO;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door: IDoor
    {
        public event EventHandler<DoorEventArgs>? DoorEvent;

        public bool _LockState = false;

        public void UnlockDoor(bool _LockState)
        {
            if (_LockState == true)
            {
                _LockState = false;
            }
        }

        public void LockDoor(bool _LockState)
        {
            if (_LockState == false)
            {
                _LockState = true;
            }
        }

        public void OnStateChange(bool _LockState)
        {
            DoorEvent?.Invoke(this, new DoorEventArgs { DoorState = this._LockState});
        }
    }
}