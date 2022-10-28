using Ladeskab;
using Ladeskab.Interfaces;
class Program
{
    static void Main(string[] args)
    {

        // Assemble your system here from all the classes
        RfidReader rfidReader = new RfidReader();
        Door door = new Door();
        DisplaySimulator display = new DisplaySimulator();
        UsbChargerSimulator charger = new UsbChargerSimulator();
        ChargeControl chargeControl = new ChargeControl(charger, display);
        StationControl stationControl = new StationControl(door,  rfidReader, display, chargeControl, "LogFile.txt");

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

