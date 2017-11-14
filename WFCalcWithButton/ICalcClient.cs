using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCalcWithButton
{
    public interface ICalcClient
    {
        Task<double> Calculate(double x, double y, char op);
    }
}
