using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_and_events_password_encrypt
{
    class publisher
    {
        List<string> lst = new List<string>();
        public event EventHandler passwordadded;
        public string this[int i]
        {
            get
            {
                return lst[i];
            }
            set
            {
                lst.Add(value);
                if(passwordadded!=null)
                {
                    passwordadded.Invoke(this, null);
                }
            }
        }

    }
}
