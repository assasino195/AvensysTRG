using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_a_string_without_bcl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter string");
            string a = Console.ReadLine();
            string oout= string.Empty;
            List<string> list = new List<string>();
            for(int i=a.Length-1;i>=0;i--)
            {
                if (a[i] ==' ')
                {
                    list.Add(oout);
                    //Console.Write(oout);
                    string tem = " ";
                    list.Add(tem);
                    oout = string.Empty;
                    
                }
                else if(i==0)
                {
                    oout += a[i];
                    list.Add(oout);
                }
                else
                {
                    oout += a[i];
                }
                //oout += a[i];
                //Console.Write(a[i]);
            }
            for(int i=list.Count-1;i>=0;i--)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();
            //Console.WriteLine(oout);
            Console.ReadLine();
        }
    }
}
