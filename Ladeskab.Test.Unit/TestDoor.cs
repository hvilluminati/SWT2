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
        }

        [Test]
        public void ctor_DoorLock()
        {
            _uut.DoorEvent += (sender, args) => _DoorEventArgs = args;
            _uut.LockDoor(0);
            Assert.That(_DoorEventArgs, Is.EqualTo(1));
        }
        
        public void ctor_DoorUnlocked()
        {
            _uut.DoorEvent += (sender, args) => _DoorEventArgs = args;
            _uut.UnlockDoor(1);
            Assert.That(_DoorEventArgs, Is.EqualTo(1));
        }
    }
}