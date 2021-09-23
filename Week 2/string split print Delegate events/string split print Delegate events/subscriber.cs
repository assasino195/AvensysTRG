using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_split_print_Delegate_events
{
    class subscriber
    {
        private publisher pub;

        public void subscribetoevent(publisher publish)
        {
            pub = publish;
            pub.send += pub_stringadded;
        }
        public void pub_stringadded(string[] a,int count)
        {
            foreach(string i in a)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"count: {count}");
        }
        
    }
}
