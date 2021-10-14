using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace even_length_string_cehcker
{
    public class Program
    {
        public bool result;
        public int addresult;
        static void Main(string[] args)
        {
            Console.WriteLine("enter string");
            string str = Console.ReadLine();
            Program p = new Program();
            p.checker(str);
            

            Console.ReadLine();


        }

        public bool checker(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return false;
            }
            int maxlength = str.Length;
            //int chunkSize = maxlength / 2;

            //string a = string.Empty;
            //string b = string.Empty;
            ////a = str.Substring(0, chunkSize);
            ////b = str.Substring(chunkSize,5);
            string vowels = "aeiou";
            string str1 = str.Substring(0, str.Length / 2).ToLower();
            string str2 = str.Substring(str.Length / 2).ToLower();
            if (str1.Equals(str2))
            {
                Console.WriteLine("MIRROR");
                return true;
            }
            else
            {
                Console.WriteLine("Not mirrored");
                return false;
            }
        }
        //public bool voewelcheck(string str)
        //{
        //    if (string.IsNullOrEmpty(str))
        //    {
        //        return false;
        //    }
        //    int maxlength = str.Length;
        //    //int chunkSize = maxlength / 2;
        //    Dictionary<char, int> dict = new Dictionary<char, int>();
        //    //string a = string.Empty;
        //    //string b = string.Empty;
        //    ////a = str.Substring(0, chunkSize);
        //    ////b = str.Substring(chunkSize,5);
        //    string vowels = "aeiou";
        //    string str1 = str.Substring(0, str.Length / 2).ToLower();
        //    string str2 = str.Substring(str.Length / 2).ToLower();
        //    foreach(char c in str)
        //    {
        //        if(vowels.Contains(c))
        //        {
        //            dict[c] += 1;
        //        }
        //    }
        //}

       
    }
}
