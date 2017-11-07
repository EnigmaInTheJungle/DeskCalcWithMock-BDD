using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using TestStack.White.Factory;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutoTest
{
    [TestClass]

    public class WFWithB
    {
        Window window = null;
        ObjectModel obj;

        //static string GetApplicationPath(string applicationName)
        //{
        //    var tmpDirName = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
        //    var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(tmpDirName))) + @"\WFCalcWithButton\";
        //    string result = Path.Combine(solutionFolder, applicationName);
        //    return result;
        //}

        [TestInitialize]
        public void StartApp()
        {
            Application application = Application.Launch(new ProcessStartInfo(@"WFCalcWithButton.exe")
            {
                WorkingDirectory = @"..\..\..\WFCalcWithButton\bin\Debug\",
            });
            //Application application = Application.Launch(GetApplicationPath("WFCalcWithButton.exe"));
            //window = application.GetWindow("Form1", InitializeOption.NoCache);
            window = application.GetWindows()[0];
            obj = new ObjectModel(window);
        }

        [TestCleanup]
        public void QuitF()
        {
            window.Close();
        }

        [DataTestMethod]
        [DataRow("but1")]
        [DataRow("but2")]
        [DataRow("but3")]
        [DataRow("but4")]
        [DataRow("but5")]
        [DataRow("but6")]
        [DataRow("but6")]
        [DataRow("but8")]
        [DataRow("but9")]
        [DataRow("but0")]
        [DataRow("butMinus")]
        [DataRow("butPlus")]
        [DataRow("butMult")]
        [DataRow("butDiv")]
        [DataRow("butEqual")]
        public void TestWPFExistingElement(string elId)
        {
            Assert.AreEqual(true, obj.GetButton(elId).Visible);
        }

        [DataTestMethod]
        [DataRow("but1", "1")]
        [DataRow("but2", "2")]
        [DataRow("but3", "3")]
        [DataRow("but4", "4")]
        [DataRow("but5", "5")]
        [DataRow("but6", "6")]
        [DataRow("but7", "7")]
        [DataRow("but8", "8")]
        [DataRow("but9", "9")]
        [DataRow("but0", "0")]
        public void TestWPFSimpleCheck(string elId, string res)
        {
            obj.GetButton(elId).Click();
            string calc = obj.GetTextBox("txtResult").BulkText;
            Assert.AreEqual(res, calc);
        }

        [DataTestMethod]
        [DataRow(new string[] { "but1", "but2", "but3" }, "123")]
        [DataRow(new string[] { "but4", "but5", "but6" }, "456")]
        [DataRow(new string[] { "but7", "but8", "but9" }, "789")]
        [DataRow(new string[] { "but3", "but0", "but6" }, "306")]
        public void TestWPFComplexCheck(string[] arr, string res)
        {
            foreach (string str in arr)
            {
                obj.GetButton(str).Click();
            }
            string calc = obj.GetTextBox("txtResult").BulkText;
            Assert.AreEqual(res, calc);
        }

        [DataTestMethod]
        [DataRow("but1", "but2", "butPlus", "3")]
        [DataRow("but3", "but4", "butMinus", "-1")]
        [DataRow("but5", "but6", "butMult", "30")]
        [DataRow("but9", "but3", "butDiv", "3")]
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
