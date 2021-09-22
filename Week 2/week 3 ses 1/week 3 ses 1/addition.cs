using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    public delegate void ops(int result);
    public delegate void operation1(int am, int bm);
    class addition
    {
        public event ops addcompletedevent;
        public event operation1 performAddEvent;
        public void Adde(int a,int b)
        {
            //long standing task
            Console.WriteLine("in addition add");
            raiseEvent(a + b);
            raisevevent1(a, b);
        }
        private void raiseEvent(int res)
        {
            if(addcompletedevent!=null)
            {
                addcompletedevent(res);
            }
        }
        private void raisevevent1(int am,int bm)
        {
            if(performAddEvent!=null)
            {
                performAddEvent(am, bm);
            }
        }
    }
}
