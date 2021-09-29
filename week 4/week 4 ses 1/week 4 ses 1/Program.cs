using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_4_ses_1
{
    class Program
    {
       
        public static void calculateint()
        {
            publiseher p = new publiseher();

            Console.WriteLine("interest");
            double interest = double.Parse(Console.ReadLine());
            Console.WriteLine("months");
            double year = double.Parse(Console.ReadLine());
            Console.WriteLine("amt");
            double amt = double.Parse(Console.ReadLine());
            p.numbermodifiedevent += P_numbermodifiedevent;
            p.calculateint(amt, interest, year);
        }
        public static void FUNCC()
        {
            Funcc fc = new Funcc();
            fc.practice();
            //fc.print();
        }
        
        static void Main(string[] args)
        {

            bool stay = true;
            while(stay)
            {
                Console.WriteLine("1.Simple Interest\n2.Func");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        {
                            calculateint();
                            break;
                        }
                    case "2":
                        {
                            FUNCC();
                            break;
                        }
                }
            }
            Console.ReadLine();


        }

        private static void P_numbermodifiedevent(object sender, inteventargs e)
        {
            Console.WriteLine($"Calculated number is {e.input1}");
        }
    }
    
}
