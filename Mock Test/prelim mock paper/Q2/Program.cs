using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        class line
        {
            double point1X { get; set; }
            double point1Y { get; set; }
            double point2X { get; set; }
            double point2Y { get; set; }
            double point3X { get; set; }
            double point3Y { get; set; }
            double point4X { get; set; }
            double point4Y { get; set; }


            public line(string x1, string y1, string x2, string y2, string x3, string y3, string x4, string y4)
            {
                try
                {
                    point1X = double.Parse(x1);
                    point1Y = double.Parse(y1);
                    point2X = double.Parse(x2);
                    point2Y = double.Parse(y2);
                    point3X = double.Parse(x3);
                    point3Y = double.Parse(y3);
                    point4X = double.Parse(x4);
                    point4Y = double.Parse(y4);


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public void display()
            {
                Console.WriteLine("Line 1");
                Console.WriteLine($"Starting point of line {point1X},{point1Y} Ending point of line {point2X},{point2Y}");
                Console.WriteLine("Line 2");
                Console.WriteLine($"Starting point of line {point3X},{point3Y} Ending point of line {point4X},{point4Y}");
            }
            public void slope()
            {
                double A = ((point2Y - point1Y) / (point2X - point1X));
                double B = ((point4Y - point3Y) / (point4X - point3X));
                double dx1 = point2X - point1X;
                double dy1 = point2Y - point1Y;
                double dx2 = point4X - point3X;
                double dy2 = point4Y - point3Y;
                double cosAngle = Math.Abs((dx1 * dx2 + dy1 * dy2) / Math.Sqrt((dx1 * dx1 + dy1 * dy1) * (dx2 * dx2 + dy2 * dy2)));
                if(cosAngle>0.98)
                {
                    Console.WriteLine("this is a Parallel Line");
                }
                else
                {
                    Console.WriteLine("this is Not a parallel line");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line 1x cordinate");
            string x1 = Console.ReadLine();
            Console.WriteLine("enter line 1y cordinate");
            string y1 = Console.ReadLine();
            Console.WriteLine("enter line 2x cordinate");
            string x2 = Console.ReadLine();
            Console.WriteLine("enter line 2y cordinate");
            string y2 = Console.ReadLine();
            Console.WriteLine("enter line 3x cordinate");
            string x3 = Console.ReadLine();
            Console.WriteLine("enter line 3y cordinate");
            string y3 = Console.ReadLine();
            Console.WriteLine("enter line 4x cordinate");
            string x4 = Console.ReadLine();
            Console.WriteLine("enter line 4y cordinate");
            string y4 = Console.ReadLine();
            line lineclass = new line(x1,y1,x2,y2,x3,y3,x4,y4);
            bool stay = true;
            while(stay)
            {
                Console.WriteLine("1.view starting and end points\n2.Parallel or no\n3.Exit");
                string intp = Console.ReadLine();
                switch(intp)
                {
                    case "1":
                        {
                            lineclass.display();
                            break;
                        }
                    case "2":
                        {
                            lineclass.slope();
                            break;
                        }
                    case "3":
                        {
                            stay = false;
                            break;
                        }
                }
            }
            lineclass.display();
            lineclass.slope();

        }
    }
}
