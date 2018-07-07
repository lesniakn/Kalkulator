using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_wsiz
{
    public static class Operations
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }

        public static double Subtraction(double a, double b)
        {
            return a - b;
        }

        public static double Multiplication(double a, double b)
        {
            return a * b;
        }

        public static double Division(double a, double b)
        {
            return a / b;
        }

        public static double Mod(double a, double b)
        {
            return a % b;
        }

        public static double Exp(double a, double b)
        {
            return Math.Exp(a * Math.Log(b * 4));
        }
    }
}
