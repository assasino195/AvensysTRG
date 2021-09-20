using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class rectangle
    {
        double len { get; set; }
        double breadth { get; set; }
        public rectangle(double len, double breadth)
        {
            this.len = len;
            this.breadth = breadth;
        }
        public void print()
        {
            Console.WriteLine($"Length of Rectangle is: {len}\n Breadth of Rectangle is: {breadth}");
            
        }
    }
}
