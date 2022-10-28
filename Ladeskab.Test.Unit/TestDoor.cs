using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interfaces;

namespace TestDoor
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;

        private DoorEventArgs _DoorEventArgs;

        [SetUp]
        public void Setup()
        {
            _DoorEventArgs = null;
            _uut = new Door();
            _uut.DoorEvent += (sender, args) => _DoorEventArgs = args;
        }

        [Test]
        public void ctor_DoorLock()
        {
            _uut.LockDoor();
            Assert.That(_uut.Locked, Is.True);
        }

        [Test]
        public void ctor_DoorUnlocked()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.Locked, Is.False);
        }

        [Test]
        public void DoorOpened()
        {
            _uut.DoorOpened();
            Assert.That(_uut.Open, Is.True);
        }

        [Test]
        public void DoorOpenedEventHappened()
        {
            _uut.DoorOpened();
            Assert.That(_DoorEventArgs, Is.Not.Null);
        }

        [Test]
        public void DoorOpenedEvent()
        {
            _uut.DoorOpened();
            Assert.That(_DoorEventArgs.DoorOpen, Is.True);
        }

        [Test]
        public void DoorClosed()
        {
            _uut.DoorClosed();
            Assert.That(_uut.Open, Is.False);
        }

        [Test]
        public void DoorClosedEventHappened()
        {
            _uut.DoorClosed();
            Assert.That(_DoorEventArgs, Is.Not.Null);
        }

        [Test]
        public void DoorClosedEvent()
        {
            _uut.DoorClosed();
            Assert.That(_DoorEventArgs.DoorOpen, Is.False);
        }

    }
}