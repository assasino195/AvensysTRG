using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datetime_stringBCL_Examples
{



    class Program
    {
        static void Main(string[] args)
        {
            //String_UpperLower_Examples();
            //String_Bcl_Examples();
            //NullorEmptyConcateTrimExamples();
            //DateTimeExamples();

            var input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime test) == true)
            {
                Console.WriteLine("Valid datetime");
                Console.WriteLine("Hours difference: " + Math.Abs((test - DateTime.Now).TotalHours));
                Console.WriteLine("Days difference: " + Math.Abs((test - DateTime.Now).TotalDays));
                Console.WriteLine("Months difference: " + Math.Abs((test - DateTime.Now).TotalDays) / 30);
                Console.WriteLine("Years difference: " + Math.Abs((test - DateTime.Now).TotalDays) / 365);
            }
            else
            {
                Console.WriteLine("Invalid datetime");
            }

            Console.ReadLine();
        }

        static void String_Bcl_Examples()
        {
            List<String> lst = new List<string>();

            //compare
            string str1 = "SampleDemo"; //S 083
            string str2 = "sampleDemo"; //s 115

            lst.Add(str1);
            lst.Add(str2);

            Console.WriteLine("Before sorting");
            foreach (string temp in lst)
            {
                Console.WriteLine(temp);
            }
            var arr = lst.ToArray();
            Array.Sort(arr);
            Console.WriteLine("After sorting");
            foreach (string temp in arr)
            {
                Console.WriteLine(temp);
            }


            int res = str1.CompareTo(str2);

            Console.WriteLine("result of string compare is : " + res);

            string str3 = "a";  //a 065
            string str4 = "b";  //b 066

            int res2 = str3.CompareTo(str4);
            int res_2 = string.Compare(str3, str4);

            Console.WriteLine("result of compareTo is : " + res2);
            Console.WriteLine("result of string compare is : " + res_2);

            string str5 = "b";  //b 066
            string str6 = "a";  //a 065


            int res3 = str5.CompareTo(str6);
            int res_3 = string.Compare(str5, str6);

            Console.WriteLine("result of compareTo is : " + res3);
            Console.WriteLine("result of string compare is : " + res_3);

        }

        static void String_UpperLower_Examples()
        {
            //Console.WriteLine("Enter any string");
            //var usr_input = Console.ReadLine();
            //Console.WriteLine("String in lower case" + usr_input.ToLower());
            //Console.WriteLine("String in upper case" + usr_input.ToUpper());

            //var str1 = "this_Is_a_SAMple_seSSION.";

            //Console.WriteLine("The string in correct format");
            //Console.WriteLine(char.ToUpper(str1[0]) + str1.Substring(1).ToLower());

            var str2 = "I love to code in c#";
            var lst = str2.Split(' ');

            for (int i = lst.Length - 1; i >= 0; i--)
            {
                Console.Write(Char.ToUpper(lst[i][0]) + lst[i].Substring(1));
                Console.Write(' ');
            }
        }

        static void NullorEmptyConcateTrimExamples()
        {
            string str1 = "SampleDemo";

            if (string.IsNullOrEmpty(str1))
            {
                Console.WriteLine("str1 is null or empty");
            }

            string str3 = null;
            if (string.IsNullOrEmpty(str3))
            {
                Console.WriteLine("str3 is null or empty");
            }

            var str2 = " ";
            if (string.IsNullOrEmpty(str2))
            {
                Console.WriteLine("Is null or empty");
            }
            if (string.IsNullOrWhiteSpace(str2))
            {
                Console.WriteLine("Is null or whitespace");
            }


            string str4 = "This is";
            string str5 = " sample program";
            Console.WriteLine(string.Concat(str4, str5));

            string str7 = "      This is a sample string 2    ";
            string str6 = "//****     This is a sample string       ****//";
            char[] chartoremove = { '*', '/', ' ' };
            var trimmedString = str7.Trim(' ');
            var trimmedString2 = str6.Trim(chartoremove);
            Console.WriteLine("Removed all whitespaces: " + trimmedString);
            Console.WriteLine("Removed all char: " + trimmedString2);
        }

        static void DateTimeExamples()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.WriteLine(dateTime.Date);
            Console.WriteLine(dateTime.Month);
            Console.WriteLine(dateTime.Year);

            Console.WriteLine(dateTime.ToShortDateString());
            Console.WriteLine(dateTime.ToShortTimeString());

            Console.WriteLine(dateTime.ToLongDateString());
            Console.WriteLine(dateTime.ToLongTimeString());

            Console.WriteLine(dateTime.ToString("dd-MM-yyyy"));
            Console.WriteLine(dateTime.ToString("dddd-dd-MMM-yy"));
            Console.WriteLine(dateTime.ToString("dd-MMMM-yyyy"));

            string str = "10/07/2021 23:05";
            DateTime.TryParse(str, out DateTime datetimeObj);
            Console.WriteLine(datetimeObj);

            DateTime datetimeObj1 = new DateTime(21, 10, 07, 22, 10, 10);
            DateTime datetimeObj2 = DateTime.Now;
            DateTime datetimeObj3 = DateTime.Now;
            var datetimeObj4 = DateTime.Now.ToShortDateString();
            var datetimeObj5 = DateTime.Now.AddDays(10);
            Console.WriteLine(DateTime.MaxValue);
            Console.WriteLine(DateTime.MinValue);

            Console.WriteLine(DateTime.DaysInMonth(2021, 10));
            Console.WriteLine(DateTime.IsLeapYear(2022));

            if (datetimeObj1.Equals(datetimeObj3))
            {
                Console.WriteLine("equal.");
            }
            else
            {
                Console.WriteLine("not equal.");
            }

            if (datetimeObj3.Equals(datetimeObj2))
            {
                Console.WriteLine("equal.");
            }
            else
            {
                Console.WriteLine("not equal.");
            }
        }
    }
}