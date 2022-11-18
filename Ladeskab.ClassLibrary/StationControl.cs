using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using System.Xml.Linq;
using System.ComponentModel;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        public LadeskabState _state;
        private ChargeControl _chargeControl;
        public int _oldId;
        private IDisplay _display;
        private IRfidReader _RfidReader;
        private IDoor _door;
        private ILogFile _logFile;


        public StationControl(IDoor door, IRfidReader rfidReader, IDisplay display, ChargeControl chargeControl, string logFile)
        {
            door.DoorEvent += DoorHandler;
            rfidReader.rfidEvent += RfidDetected;
            _door = door;
            _display = display; 
            _chargeControl = chargeControl;
            _RfidReader = rfidReader;
            _logFile = new LogFile(logFile);
        }

        public DisplaySimulator DisplaySimulator
        {
            get => default;
            set
            {
            }
        }

        public RfidReader RfidReader
        {
            get => default;
            set
            {
            }
        }

        public ChargeControl ChargeControl
        {
            get => default;
            set
            {
            }
        }

        public Door Door
        {
            get => default;
            set
            {
            }
        }

        public LogFile LogFile
        {
            get => default;
            set
            {
            }
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(object sender, rfidEventArgs e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_chargeControl.IsConnected())
                    {
                        _door.LockDoor();
                        _chargeControl.StartCharge();
                        _oldId = e.id;
                        _logFile.LogDoorLocked(e.id);

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
                    if (e.id == _oldId)
                    {
                        _chargeControl.StopCharge();
                        _door.UnlockDoor();
                        _logFile.LogDoorUnlocked(e.id);

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
        public void DoorHandler(object sender, DoorEventArgs e)
        {
            if(e.DoorOpen)
            {
                _state = LadeskabState.DoorOpen;
                _display.Print("Tilslut telefon");
            }
            else
            {
                _state=LadeskabState.Available;
                _display.Print("Indlæs RFID");
            }
        }
        //Her mangler de andre trigger handlere
    }
}
