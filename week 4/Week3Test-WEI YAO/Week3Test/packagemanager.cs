using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Test
{
    class packagemanager
    {
        List<package> plist = new List<package>();
        public void receive(int id,params string[] allparams)
        {
            package package = new package(id, allparams[0], allparams[1], allparams[2]);
            plist.Add(package);
        }
        
    }
}
