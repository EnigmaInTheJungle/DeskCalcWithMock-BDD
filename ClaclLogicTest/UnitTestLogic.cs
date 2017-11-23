using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;
using WFCalcWithButton;

namespace ClaclLogicTest
{
    [TestFixture]
    public class UnitTestLogic
    {
        MockCalcClient mock;
        [SetUp]
        public void Es()
        {
            mock = new MockCalcClient();
        }

        [Test]
        [TestCase(1, 2, '+', "3")]
        [TestCase(12, 2, '-', "10")]
        [TestCase(7, 2, '*', "14")]
        [TestCase(6, 2, '/', "3")]
        public void TestCalcWF(double x, double y, char op, string res)
        {
            Assert.AreEqual(res, Task.Run(() => mock.Calculate( x, y, op)).Result);
        }
    }
}
