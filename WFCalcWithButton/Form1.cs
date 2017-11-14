using CaclClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalcWithButton
{
    public partial class Form1 : Form
    {
        public enum ClientType{ REAL, MOCK };

        ICalcClient client;
        int x = 0;
        int y = 0;
        char op = ' ';

        public Form1(ClientType clientType)
        {
            InitializeComponent();
            if (clientType == ClientType.REAL)
                client = new RealCalcClient("http://localhost:8888");
            else
                client = new MockCalcClient();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            textResult.Text += but.Text;
        }

        private async void buttonOperation_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            char oper = Convert.ToChar(but.Text);
            if (oper != '=')
            {
                x = Int32.Parse(textResult.Text);
                textResult.Text = "";
                op = oper;
            }
            else
            {
                y = Int32.Parse(textResult.Text);
                textResult.Text = (await client.Calculate(x, y, op)).ToString();
            }
        }
    }
}
