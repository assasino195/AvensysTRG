using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_delegate_send_alert_msg__to_subscribers
{
    class publisher
    {
        List<string> lst = new List<string>();
        public event EventHandler alertadded;
        public string this[int i]
        {
            get
            {
                return lst[i];
            }
            set
            {
                lst.Add(value);
                if(alertadded!=null)
                {
                    alertadded?.Invoke(this, null);
                }
            }
        }
    }
}
