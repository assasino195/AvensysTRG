using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valid_string_check_string
{
    public class Program
    {
        public bool checkforvalid(string a)
        {

            Stack<char> stack = new Stack<char>();
            bool valid = false;
            foreach (char c in a)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else if (c == '}' || c == ']' || c == ')')
                {
                    char tem = stack.Pop();
                    if (tem == '{' && c == '}')
                    {

                        valid = true;


                    }

                    else if (tem == '[' && c == ']')
                    {


                        valid = true;
                    }
                    else if (tem == '(' && c == ')')
                    {

                        valid = true;


                    }
                    else
                    {
                        valid = false;
                        break;

                    }
                }
            }
            return valid;
        }
        static void Main(string[] args)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();


            while (true)
            {
                Console.WriteLine("enter string");
                string a = Console.ReadLine();
                Program p = new Program();
                p.checkforvalid(a);
                //int curlybracket = 0;
                //int smileybracket = 0;
                //int supercurlybracket = 0;
                //foreach (char c in a)
                //{
                //    switch (c)
                //    {
                //        case '{':
                //            {
                //                supercurlybracket++;
                //                break;
                //            }
                //        case '[':
                //            {
                //                smileybracket++;
                //                break;
                //            }
                //        case '(':
                //            {
                //                curlybracket++;
                //                break;
                //            }
                //        case '}':
                //            {
                //                supercurlybracket--;
                //                break;
                //            }
                //        case ']':
                //            {
                //                smileybracket--;
                //                break;
                //            }
                //        case ')':
                //            {
                //                curlybracket--;
                //                break;
                //            }

                //    }
                //}
                //if (curlybracket != 0 || smileybracket != 0 || supercurlybracket != 0)
                //{
                //    Console.WriteLine("not a valid string");
                //}
                //else
                //{
                //    Console.WriteLine("Valid string");
                //}

            }

            
        }
    }
}