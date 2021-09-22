using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    [Flags]
    enum genreEnum
    {
        Default=1,
        education=2,
        suspense=4,
        comic=8,
        comedy=16
    }
}
