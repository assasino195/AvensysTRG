using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Test
{
    class exceptionhandling
    {
       public static int[] aList = new int[10] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 110 };
        public void getElementInt(string i)
        {
            try
            {
                int input = Int32.Parse(i);
                Console.WriteLine(aList[input]);

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Indexer out of range exception raised {ex}");
                Console.WriteLine("Please enter numbers from 0-9");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Invalid cast detected {ex}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FORMAT Eception raised {ex}");
                Console.WriteLine("Please only enter numbers");
            }

            finally
            {
               Console.WriteLine(":D");
            }
        }
        public void dividingtest(string a, string b)
        {
            try
            {
                int input1 = Int32.Parse(a);
                int input2 = Int32.Parse(b);
                Console.WriteLine($"{input1} / {input2} = {input1 / input2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Eception raised {ex}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Invalid cast detected {ex}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FORMAT Eception raised {ex}");
                Console.WriteLine("Please only enter numbers");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Null Eception raised {ex}");
            }
            finally
            {
                Console.WriteLine("DIVIDEES");
            }
        }
        public void arrcheck(string a,int b)
        {
            try
            {
                Console.WriteLine($"{a[b]}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Invalid cast detected {ex}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FORMAT Eception raised {ex}");
                Console.WriteLine("Please only enter numbers");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Null Eception raised {ex}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Indexer out of range exception raised {ex}");
                Console.WriteLine("Please enter numbers from 0-9");
            }
            finally
            {
                Console.WriteLine("Completed program");
            }
        }
    }
   
}
