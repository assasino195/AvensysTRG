using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace return_2_arr_position_if_they_add_up_to_target
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            Console.WriteLine("Hello World!");
            // int.TryParse(Console.Read(), out int re);
            int result = int.Parse(Console.ReadLine());
            int[] arr = new int[] { 2, 7, 11, 15 };
            int temp = 0;
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int tem = result - arr[i];

                if (dict.ContainsKey(arr[i]))
                {
                    Console.WriteLine($"{dict[i]} {dict[temp]} ");
                }
                else
                {
                    dict.Add(tem, i);
                }
                //temp += arr[i] ;
                //if(temp==result)
                //{
                //    Console.WriteLine($"{i} and {i+1}");
                //    break;
                //}

            }
            Console.ReadLine();

        }
    }
    }
}
