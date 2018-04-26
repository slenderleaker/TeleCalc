using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.ConCalc
{
    class Calc
    {
        #region OldOperations
        public int Sum(int x, int y)
        {
            return x + y;
        }
        public double Sum(double x, double y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public int Mul(int x, int y)
        {
            return x * y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public int Div(int x, int y)
        {
            return x / y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
        
        public double Exp(double x, double y)
        {
            return Math.Pow(x, y);
        }
        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }
        #endregion
    }
}
