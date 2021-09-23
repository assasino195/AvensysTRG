using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateventwithtimere
{
    class counter
    {
        public event EventHandler increasecount;
        public int Count
        {
            get
            {
                return Count;
            }
            set
            {
                if(increasecount !=null)
                {
                    increasecount?.Invoke(Count, null);
                }
            }
        }
    }
}
