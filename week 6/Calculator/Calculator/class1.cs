using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class class1
    {
       Complex c1 { get; set; }
        Complex c2 { get; set; }
        //public class1(Complex a,Complex b)
        //{
        //    c1 = a;
        //    c2 = b;
        //}
        public Complex add(Complex a,Complex b)
        {
            return a + b;
        }
        public Complex sub(Complex a, Complex b)
        {
            return a - b;
        }
        public Complex divi(Complex a, Complex b)
        {
            return a / b;
        }

    }
}
