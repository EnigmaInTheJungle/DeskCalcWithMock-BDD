using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace AutoTest
{
    public class ObjectModel
    {
        string but1 = "button1";
        string but2 = "button2";
        string but3 = "button3";
        string but4 = "button4";
        string but5 = "button5";
        string but6 = "button6";
        string but7 = "button7";
        string but8 = "button8";
        string but9 = "button9";
        string but0 = "button0";
        string butPlus = "buttonPlus";
        string butMinus = "buttonMinus";
        string butMult = "buttonMultiply";
        string butDiv = "buttonDivide";
        string butEqual = "buttonEqual";
        string txtResult = "textResult";

        Window window;

        public ObjectModel()
        {

        }

        public ObjectModel(Window window)
        {
            this.window = window;
        }

        public Button GetButton(string s)
        {
            Button flag = null;
            if (s == nameof(but1))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but1));
            else if (s == nameof(but2))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but2));
            else if (s == nameof(but3))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but3));
            else if (s == nameof(but4))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but4));
            else if (s == nameof(but5))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but5));
            else if (s == nameof(but6))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but6));
            else if (s == nameof(but7))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but7));
            else if (s == nameof(but8))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but8));
            else if (s == nameof(but9))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but9));
            else if (s == nameof(but0))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(but0));
            else if (s == nameof(butMinus))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(butMinus));
            else if (s == nameof(butPlus))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(butPlus));
            else if (s == nameof(butDiv))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(butDiv));
            else if (s == nameof(butEqual))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(butEqual));
            else if (s == nameof(butMult))
                flag = window.Get<Button>(SearchCriteria.ByAutomationId(butMult));
            return flag;
        }

        public TextBox GetTextBox(string s)
        {
            TextBox flag = null;
            if (s == nameof(txtResult))
                flag = window.Get<TextBox>(SearchCriteria.ByAutomationId(txtResult));
            return flag;
        }
    }
}
