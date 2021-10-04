using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Q4
{

    // class MyList<T>
    // {
    // bool stay = true;
    //     public List<T> mylist { get; private set; }

    //     public MyList()
    //     {
    //         mylist = new List<T>();
    //     }

    // public void Add(T input)
    // {

    //         new Thread(() => mylist.Add(input)).Start();

    // }

    //     public void Remove(T thingtoremove)
    //     {
    //         new Thread(() =>
    //         {
    //             mylist.Remove(thingtoremove);
    //         }).Start();
    //     }
    //}
    delegate void delcal(int i, int j);
    class program
    {
        public event EventHandler send;
       public void getinput(object a,object b)
        {

        }
        public void add(int a, int b)
        {
            Console.WriteLine(a+b);         }

        public void divide(int a, int b)
        {
            Console.WriteLine(a/b);
        }

        public void modulus(int a, int b)
        {
            Console.WriteLine(a%b);
        }

        public void multiply(int a, int b)
        {
            Console.WriteLine(a*b);
        }

        public void subtract(int a, int b)
        {
            Console.WriteLine(a-b);
        }
        public void power(int a,int b)
        {
            Console.WriteLine(Math.Pow(a,b));
        }
    }
}
