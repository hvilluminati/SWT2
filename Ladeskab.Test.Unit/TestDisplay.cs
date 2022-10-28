using Ladeskab.Interfaces;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Test.Unit
{
    [TestFixture]
    public class TestDisplay
    {
        private DisplaySimulator _uut;
        private StringWriter _output;

        [SetUp]
        public void Setup()
        {
            _output = new StringWriter();
            _uut = new DisplaySimulator();
            Console.SetOut(_output);
        }

        [TestCase("Test message")]
        public void DisplayCorrectMessage(string msg)
        {
            _uut.Print("Test message");
            Assert.That(_output.ToString(), Contains.Substring(msg));
        }
    }
}
