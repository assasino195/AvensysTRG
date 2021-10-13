using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileIO
{
    class filereader
    {
        public Dictionary<char, int> dict = new Dictionary<char, int>();
        public void Write()
        {
            Console.WriteLine("Enter file name: ");
            string filename = Console.ReadLine();

            FileStream fs = new FileStream($"{filename}.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach(var d in dict)
            {
                sw.Write($"{d.Key} count:{d.Value}\t");
            }
            //sw.WriteLine("Hello world");

            sw.Close();
            fs.Close();
        }

        public void Append()
        {
            Console.WriteLine("Enter file name: ");
            string filename = Console.ReadLine();

            FileStream fs = new FileStream($"{filename}.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Hello world");

            sw.Close();
            fs.Close();
        }

        public void Read()
        {
            Console.WriteLine("Enter file name: ");
            string filename = Console.ReadLine();

            FileStream fs = new FileStream($"{filename}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            List<string> a = new List<string>();
            
            string str = sr.ReadToEnd();
           
            for(int i=0;i<str.Length;i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    dict[str[i]] += 1;
                }
                else
                {
                    if (str[i].Equals(" "))
                    {
                       
                    }
                    else
                    {
                        dict.Add(str[i], 1);
                    }
                }
            }
            Console.WriteLine();
            str = sr.ReadLine();


            sr.Close();
            fs.Close();
            //while (str != null)
            //{
            //    foreach (char a in str)
            //    {


            //        if (dict.ContainsKey(a))
            //        {
            //            foreach (var d in dict)
            //            {
            //                if (d.Key.Equals(a))
            //                {
            //                    Console.WriteLine("added "+a);
            //                    dict[a]++;


            //                    break;
            //                }

            //            }
            //        }
            //        else
            //        {
            //            dict.Add(a, 1);
            //        }
            //    }

        }
    }
}
