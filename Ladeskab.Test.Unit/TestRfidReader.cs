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
        private rfidEventargs _rfidEventargs;

        [SetUp]
        public void Setup()
        {
            _rfidEventargs = null;
            _uut = new RfidReader();
        }

        [Test]
        public void ctor_IsRfidRead()
        {
            _uut.OnRfidRead(1);
            Assert.That(_rfidEventargs, Is.Not.Null);
        }

        [Test]
        public void ctor_IsIdCorrect()
        {
            _uut.OnRfidRead(1);
            Assert.That(_rfidEventargs.id, Is.Not.Null);
        }

    }
}