using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_ses2
{
    class operation
    {
        public static void performoperations(int a, int b,delcal del
            )
        {
            del(a, b);
        }

        
    }
    public delegate void EventHandler(int HCF, int LCM);
    class Operation
    {
        public event EventHandler send;
        int a;
        int b;
        int hcf;
        int lcm;

        public void GetInput(int a, int b)
        {
            this.a = a;
            this.b = b;
            calculatehcf();
            calculatelcm();
            Notify();
        }
        private void calculatehcf()
        {
            for (int i = 1; i <= a || i <= b; ++i)
            {
                if (a % i == 0 && b % i == 0)
                {
                    hcf = i;
                }
            }
        }
        public void calculatelcm()
        {
            lcm = (a * b) / hcf;
        }
        private void Notify()
        {
            if (send != null)
            {
                send(hcf, lcm);
            }
        }
    }
    class DelegateHCFandLCM
    {
        public static void print()
        {
            Console.WriteLine("Enter 1st input:");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd input:");
            int b = Int32.Parse(Console.ReadLine());
            Operation op = new Operation();
            op.send += Op_send;//subscribing
            op.GetInput(a, b);
            
            Console.ReadLine();
        }

        private static void Op_send(int HCF, int LCM)
        {
            Console.WriteLine("HCF: " + HCF);
            Console.WriteLine("LCM: " + LCM);
        }

        static void Main2(string[] args)
        {
            Console.WriteLine("Find the Highest Common Factor and Lowest Common Multiple using Delegate Events");
            print();
        }
    }
    public delegate void EventString(string input,int count);
    class DelegatePrintstring
    {
        private static void print()
        {
            Console.WriteLine("Input string");
            string a = Console.ReadLine();
            
            Ops opp = new Ops();
            opp.send += Op_Sends;
            opp.getinput(a);
            string[] i = a.Split(' ');
            foreach(string k in i)
            {
                Console.WriteLine(k);
            }
            
        }
        private static void Op_Sends(string b,int count)
        {
            Console.WriteLine(b+"\n count of string: "+count);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Printing count");

            print();
            Console.ReadLine();
        }

    }
    
    class Ops
    {
        public EventString send;
        int count;
        string a;
        
        
        public void getinput( string a)
        {
           
            this.a = a;
            countSplit();
            
        }
       
            
        public void countSplit()
        {
            string[] k = a.Split(' ');
            foreach (string i in k)
            {
                count++;
                
            }
        }
        private void Notify()
        {
            if (send != null)
            {
                send(a,count);
            }
        }
    } 
     
    
}

