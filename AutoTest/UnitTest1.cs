using System;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using TestStack.White.Factory;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;

namespace AutoTest
{
    public class WFWithB
    {
        Application application;
        Window window;
        ObjectModel obj;

        static string GetApplicationPath(string applicationName)
        {
            var tmpDirName = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(tmpDirName))) + @"\WFCalcWithButton\";
            string result = Path.Combine(solutionFolder, applicationName);
            return result;
        }

        [SetUp]
        public void StartApp()
        {

            //application = Application.Launch(new ProcessStartInfo(@"WFCalcWithButton.exe")
            //{
            //    WorkingDirectory = @"..\..\..\WFCalcWithButton\bin\Debug\",
            //});

            application = Application.Launch(GetApplicationPath("WFCalcWithButton.exe"));
            window = application.GetWindows()[0];

            obj = new ObjectModel(window);

        }

        [TearDown]
        public void QuitF()
        {
            application.Kill();
        }

        [Test]
        [TestCase("but1")]
        [TestCase("but2")]
        [TestCase("but3")]
        [TestCase("but4")]
        [TestCase("but5")]
        [TestCase("but6")]
        [TestCase("but6")]
        [TestCase("but8")]
        [TestCase("but9")]
        [TestCase("but0")]
        [TestCase("butMinus")]
        [TestCase("butPlus")]
        [TestCase("butMult")]
        [TestCase("butDiv")]
        [TestCase("butEqual")]
        public void TestWPFExistingElement(string elId)
        {
            obj = new ObjectModel(window);
            Assert.AreEqual(true, obj.GetButton(elId).Visible);
        }

        [Test]
        [TestCase("but1", "1")]
        [TestCase("but2", "2")]
        [TestCase("but3", "3")]
        [TestCase("but4", "4")]
        [TestCase("but5", "5")]
        [TestCase("but6", "6")]
        [TestCase("but7", "7")]
        [TestCase("but8", "8")]
        [TestCase("but9", "9")]
        [TestCase("but0", "0")]
        public void TestWPFSimpleCheck(string elId, string res)
        {
            obj.GetButton(elId).Click();
            string calc = obj.GetTextBox("txtResult").BulkText;
            Assert.AreEqual(res, calc);
        }

        [Test]
        [TestCase(new string[] { "but1", "but2", "but3" }, "123")]
        [TestCase(new string[] { "but4", "but5", "but6" }, "456")]
        [TestCase(new string[] { "but7", "but8", "but9" }, "789")]
        [TestCase(new string[] { "but3", "but0", "but6" }, "306")]
        public void TestWPFComplexCheck(string[] arr, string res)
        {
            foreach (string str in arr)
            {
                obj.GetButton(str).Click();
            }
            string calc = obj.GetTextBox("txtResult").BulkText;
            Assert.AreEqual(res, calc);
        }

        [Test]
        [TestCase("but1", "but2", "butPlus", "3")]
        [TestCase("but3", "but4", "butMinus", "-1")]
        [TestCase("but5", "but6", "butMult", "30")]
        [TestCase("but9", "but3", "butDiv", "3")]
        public void TestWPFRealJob(string x, string y, string op, string res)
        {
            Task.Run(() =>
            {
                obj.GetButton(x).Click();
                obj.GetButton(op).Click();
                obj.GetButton(y).Click();
                obj.GetButton("butEqual").Click();
                string calc = obj.GetTextBox("txtResult").BulkText;
                return calc;
            }).ContinueWith((e) => { Assert.AreEqual(res, e); });
        }
    }
}
