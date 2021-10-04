using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_Ses_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Shape s1 = new Shape();
            s1.send += S1_send;
            Console.WriteLine("Enter amount of sides");
            object s = Console.ReadLine();
            Console.WriteLine("enter total degrees");
            object d = Console.ReadLine();
            s1.getinput(s, d);
            Console.ReadLine();
           
        }

        private static void S1_send(string shapes)
        {
            Console.WriteLine(shapes);
        }
    }
}
