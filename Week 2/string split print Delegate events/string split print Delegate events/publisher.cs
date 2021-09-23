using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_split_print_Delegate_events
{
    class publisher
    {
        //List<string> lst = new List<string>();
       // public event EventHandler stringsadded;
        public delegate void eventhandler(string[] lst1, int count);
        public event eventhandler send;
        int count;
        string[] lst;

        public void getinput(string[] lst2,int count)
        {
            this.lst = lst2;
            this.count = count;
            notify();
        }
        public void notify()
        {
            if(send!=null)
            {
                send(lst, count);
            }
        }
        //public event EventHandler counts;
        
        //public string this[int i]
        //{
        //    get
        //    {
        //        return lst[i];
        //    }
        //    set
        //    {
        //        lst.Add(value);
        //        if (stringsadded != null)
        //        {
        //            stringsadded?.Invoke(this, null);
        //        }
        //    }
        //}
        //public int count
        //{
        //    get
        //    {
        //        return count;
        //    }
        //    set
        //    {
        //        if (counts != null)
        //        {
        //            counts?.Invoke(count, null);
        //        }
        //    }
        //}
    }
}
