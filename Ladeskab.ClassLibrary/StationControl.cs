using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;
using Ladeskab.Interfaces;
using System.Xml.Linq;
using System.ComponentModel;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IUsbCharger _charger;
        private int _oldId;
        private IDisplay _display;
        private IRfidReader _RfidReader;
        //private IDoor _door;
        private ILogFile _logFile;


        public StationControl(IDisplay display, IUsbCharger charger, IRfidReader rfidReader, string logFile)
        {
            //door.DoorEvent += DoorHandler;
            //rfidReader.rfidEvent += RfidDetected;
            //_door = door;
            _display = display; 
            _charger = charger;
            _RfidReader = rfidReader;
            _logFile = new LogFile(logFile);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        //_door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        _logFile.LogDoorLocked(id);

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        //_door.UnlockDoor();
                        _logFile.LogDoorUnlocked(id);

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }
        //private void DoorHandler(DoorEventArgs e)
        //{
        //    switch (_state)
        //    {
        //        case LadeskabState.Available :
        //            switch (e.DoorState)
        //            {
        //                case 0:

        //            }
        //    }
        //}
        // Her mangler de andre trigger handlere
    }
}
