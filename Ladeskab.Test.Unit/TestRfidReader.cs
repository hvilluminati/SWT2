using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ladeskab;

namespace TestRfidReader
{
    [TestFixture]
    public class TestRfidReader
    {
        private RfidReader _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new RfidReader();
        }

        [Test]
        public void ctor_IsRfidRead()
        {
            Assert.That(_uut.OnRfidRead, Is.Not.Null);
        }
    }
}