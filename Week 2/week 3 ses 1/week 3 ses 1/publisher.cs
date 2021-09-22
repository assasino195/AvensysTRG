using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    class publisher
    {
        List<int> list = new List<int>();
        public event EventHandler dataAdded;

        public int this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
              
                list.Add(value);
                dataAdded?.Invoke(this, null);
            }
        }
    }
}
