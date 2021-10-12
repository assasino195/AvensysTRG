using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRead_and_append
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string extension = ".txt";

        }
        static void writetofile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            fs.Seek(0, SeekOrigin.End);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Write what you wan to enter to file");
            var str = Console.ReadLine();
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        static void readfiledata()
        {
            FileStream fs = new FileStream("File Handling Exception.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine("\nRead what was written");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

        }
    }
}
