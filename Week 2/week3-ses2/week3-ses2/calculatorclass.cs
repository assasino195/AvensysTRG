using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_pretest_practice
{
    class calculatorclass : calculater
    {
        public int add(int a, int b)
        {
            return a + b;
        }

        public int divide(int a, int b)
        {
            return a / b;
        }

        public int modulus(int a, int b)
        {
            return a % b;
        }

        public int multiply(int a, int b)
        {
            return a * b;
        }

        public int subtract(int a, int b)
        {
            return a - b;
        }
    }
}
