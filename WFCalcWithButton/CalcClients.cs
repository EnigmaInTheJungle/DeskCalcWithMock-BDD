using CaclClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCalcWithButton
{
    class MockCalcClient : ICalcClient
    {
        public async Task<double> Calculate(double a, double b, char op)
        {
            double res = 0;
            switch (op)
            {
                case '-': res = a - b; break;
                case '+': res = a + b; break;
                case '*': res = a * b; break;
                case '/': res = a / b; break;
            }
            return res;
        }
    }

    class RealCalcClient : ICalcClient
    {
        CalcClient client = null;
        public RealCalcClient(string uri)
        {
            client = new CalcClient(uri);
        }

        public async Task<double> Calculate(double a, double b, char op)
        {
            return await client.Calculate(a, b, op);
        }
    }
}
