using System;

namespace Exam_Longtitude_Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("EAST OR WEST");
            //string direction = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter Degree");
            int degree = int.Parse(Console.ReadLine());
            //if (direction=="WEST")
            //{
            //    Console.WriteLine(calculateWESTTIME(degree));
            //}
            //else
            //{
            //    Console.WriteLine(calculateeasttime(degree));
            //}

            Console.WriteLine(calculateeasttime(degree));
            //Console.WriteLine("enter minutes");
            //int minutes = int.Parse( Console.ReadLine());
            //Console.WriteLine("enter seconds");
            //double sec =double.Parse( Console.ReadLine());


            Console.ReadLine();


        }
        static DateTime calculateeasttime(int a)
        {
            DateTime dt = DateTime.UtcNow;
            double output = a * 4;
            return dt.AddMinutes(output);
        }
        static DateTime calculateWESTTIME(int a)
        {
            DateTime dt = DateTime.UtcNow;
            int output = a * 4;

            return dt.Add(new TimeSpan(0,- output, 0));
        }
    }
}
