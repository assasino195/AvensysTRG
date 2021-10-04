using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lst = new MyList<int>();
            for(int i=0;i<10;i++)
            {
                lst.Add(i);
            }
            foreach (int number in lst.mylist.ToList())
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("index of: ");
            lst.indexoff(int.Parse(Console.ReadLine()));
            foreach (int number in lst.mylist.ToList())
            {
                Console.Write(number+ " ");
            }
            Console.WriteLine();
            Console.WriteLine("Remove at: ");

            lst.removeat(int.Parse(Console.ReadLine()));
            foreach (int number in lst.mylist.ToList())
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Remove number: ");
            lst.Remove(int.Parse(Console.ReadLine()));
            foreach (int number in lst.mylist.ToList())
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("removing all");
            lst.removeall();

            foreach (int number in lst.mylist.ToList())
            {
                Console.Write(number + " ");
            }

            Console.ReadLine();
        }
    }
}
