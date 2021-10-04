using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Q5
{
    class MyList<T>
    {
        public List<T> mylist { get; private set; }

        public MyList()
        {
            mylist = new List<T>();
        }

        public void Add(T i)
        {
            mylist.Add(i);
        }

        public void Remove(T e)
        {
            
                mylist.Remove(e);
            
        }
        public void removeat(T a)
        {
            
                mylist.RemoveAt(int.Parse(a.ToString()));
           
        }
        public void  removeall()
        {
            mylist.Clear();
            //for(int i=mylist.Count;i<0;i--)
            //{
            //    mylist.RemoveAt(i);
            //}
        }
        public void indexoff(T o)
        {

            Console.WriteLine(mylist.IndexOf(o)); 
            
        }
    }
}
