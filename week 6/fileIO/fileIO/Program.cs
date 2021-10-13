using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileIO
{
    class Program
    {
       
        static void Main(string[] args)
        {
            filereader fs = new filereader();
            fs.Read();
            fs.Write();
            Console.ReadLine();
        }
        
    }
}
