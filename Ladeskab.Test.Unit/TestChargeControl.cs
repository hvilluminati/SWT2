using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interfaces;
using NUnit.Framework;
using NSubstitute;
using UsbSimulator;

namespace Ladeskab.Test.Unit
{
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IUsbCharger _usbCharger;
        private IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_usbCharger, _display);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsConnected_ControllerToSimulator(bool connection)
        {
            _usbCharger.Connected.Returns(connection);
            bool x = _uut.IsConnected();

            Assert.That(x, Is.EqualTo(connection));
        }

        [Test]
        public void StartCharge_ControllerToSimulator()
        {
            _uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
        }
        [Test]
        public void StopCharge_ControllerToSimulator()
        {
            _uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(100)]
        [TestCase(600)]
        public void CurrentChanged_IsCurrentUpdated(double newCurrent)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = newCurrent });
            Assert.That(_uut.CurrentValue, Is.EqualTo(newCurrent));
        }

        [TestCase(100, "Charging", 1)]
        [TestCase(600, "Error, charging will stop immediately", 1)]
        [TestCase(2, "Fully charged", 1)]
        [TestCase(0, null, 0)]
        public void HandleCurrentValueEvent_DisplayMessages(double newCurrent, string msg, int received)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = newCurrent });
            _display.Received(received).Print(msg);
        }

    }
}