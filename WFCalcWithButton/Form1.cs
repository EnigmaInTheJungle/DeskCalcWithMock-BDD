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
        HttpClient client;
        int x = 0;
        int y = 0;
        char op = ' ';

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            textResult.Text += but.Text;
        }

        private void buttonOperation_Click(object sender, EventArgs e)
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
                textResult.Text = Task.Run(() => Calculate(x, y, op)).Result;
            }
        }

        public async Task<string> Calculate(double a, double b, char op)
        {
            var param = "a=" + a + "&b=" + b + "&op=" + op;
            string response = await client.GetStringAsync("http://localhost:8888?" + param);
            return response;
        }
    }
}
