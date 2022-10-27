using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interfaces;


namespace TestRfidReader
{
    [TestFixture]
    public class TestRfidReader
    {
        private RfidReader _uut;
        private rfidEventArgs _rfidEventArgs;

        [SetUp]
        public void Setup()
        {
            _rfidEventArgs = null;
            _uut = new RfidReader();
        }

        [Test]
        public void ctor_IsRfidRead()
        {
            _uut.OnRfidRead(1);
            Assert.That(_rfidEventArgs, Is.Not.Null);
        }

        [Test]
        public void ctor_IsIdCorrect()
        {
            _uut.OnRfidRead(1);
            Assert.That(_rfidEventArgs.id, Is.Not.Null);
        }

    }
}