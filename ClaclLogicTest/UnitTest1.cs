using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFCalcWithButton;

namespace ClaclLogicTest
{
    [TestFixture]
    public class UnitTest1
    {
        Form1 form;
        [SetUp]
        public void Es()
        {
            form = new Form1();
        }

        [Test]
        [TestCase(1, 2, '+', "0")]
        [TestCase(12, 2, '-', "10")]
        [TestCase(7, 2, '*', "14")]
        [TestCase(6, 2, '/', "3")]
        public void TestCalcWF(double x, double y, char op, string res)
        {
            NUnit.Framework.Assert.AreEqual(res, Task.Run(() => form.Calculate( x, y, op)).Result);
        }
    }
}
