using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestRfidReader
{
    [TestFixture]
    public class TestRfidReader
    {
        private rfidReader _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new rfidReader();
        }

        [Test]
        public void ctor_IsRfidRead()
        {
            Assert.That(_uut.OnRfidRead, Is.NotZero);
        }
    }
}