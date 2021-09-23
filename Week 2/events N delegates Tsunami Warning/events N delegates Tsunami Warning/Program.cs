using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_N_delegates_Tsunami_Warning
{
    class Program
    {
        static void Main(string[] args)
        {
            tsunami tsu = new tsunami();
            earthquake eq = new earthquake();
            eq.subscribetoevent(tsu);
            Console.WriteLine("Enter location of earthquake");
            string input = Console.ReadLine();
            Console.WriteLine("enter intensity of earthquake");
            double intens = double.Parse(Console.ReadLine());
            tsu.getInput(input, intens);
            Console.ReadLine();

        }
    }
}
