using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class ChargeControl
    {
        private IUsbCharger _usbCharger;
        private IDisplay _display;
        public double CurrentValue { get; set; }

        public DisplaySimulator DisplaySimulator
        {
            get => default;
            set
            {
            }
        }

        public UsbChargerSimulator UsbChargerSimulator
        {
            get => default;
            set
            {
            }
        }

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += HandleCurrentEvent;
            _display = display;
        }

        public bool IsConnected()
        {
            return _usbCharger.Connected;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }

        private void HandleCurrentEvent(object? sender, CurrentEventArgs e)
        {
            if (e.Current > 0 && e.Current <= 5)
            {
                _display.Print("Fully charged");
            }
            else if (e.Current > 5 && e.Current <= 500)
            {
                _display.Print("Charging");
            }
            else if (e.Current > 500)
            {
                _display.Print("Error, charging will stop immediately");
                _usbCharger.StopCharge();
            }
            CurrentValue = e.Current;
        }
    }
}
