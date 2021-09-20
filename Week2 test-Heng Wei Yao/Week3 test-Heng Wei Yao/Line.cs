using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class Line
    {
        public double x { get; set; }
        public double y { get; set; }
        public double x1 { get; set; }
        public double y1 { get; set; }
        public Line(double x,double y,double x1,double y1)
        {
            this.x = x;
            this.y = y;
            this.x1 = x1;
            this.y1 = y1;
        }
        public void display()
        {
            Console.WriteLine($"starting point is: {x} {y}\n Ending point is: {x1} {y1}");
            
        }
        public void slope()
        {
            Console.WriteLine("Slope is: " + ((y1 - y) / (x1 - x)));
        }
    }
}
