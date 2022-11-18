using Ladeskab;
using Ladeskab.Interfaces;
class Program
{
    static void Main(string[] args)
    {

        // Assemble your system here from all the classes
        IRfidReader rfidReader = new RfidReader();
        IDoor door = new Door();
        IDisplay display = new DisplaySimulator();
        IUsbCharger charger = new UsbChargerSimulator();
        IChargeControl chargeControl = new ChargeControl(charger, display);
        IStationControl stationControl = new StationControl(door,  rfidReader, display, chargeControl, "LogFile.txt");

        bool finish = false;
        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, R: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.DoorOpened();
                    break;

                case 'C':
                    door.DoorClosed();
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.OnRfidRead(id);
                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}

