using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{

    class Program
    {
        
        struct book
        {
            int bookid;
        }
        class library
        {
            
        }
        class manupilateobj
        {
            public object Manupilate(object obj)
            {
                if (obj is string str)
                {
                    char[] charArray = str.ToCharArray();
                    Array.Reverse(charArray);
                    return charArray;
                }
                else if (obj is int intt)
                {
                    return intt * intt;
                }
                else if (obj is double dbl)
                {
                    return (((decimal)dbl).ToString());
                }
                else
                {
                    return "not supported";
                }
            }
        }
        static void manuobj()
        {
            manupilateobj manu = new manupilateobj();

            Console.WriteLine("enter your value");
            Console.WriteLine(manu.Manupilate(Console.ReadLine()));
            

        }
       
        delegate void customdel(string s);
        
            
        
        static void delegateexampless()
        {
            void Hello()
            {
                Console.WriteLine("Hello: ");
            }
            void Bye()  
            {
                Console.WriteLine("Bye: ");
            }
            var a = Int32.Parse(Console.ReadLine());
            var b = Int32.Parse(Console.ReadLine());
            Addition addition = new Addition();
            
            subtraction subtract = new subtraction();
            Multiply multi = new Multiply();

            delexample del = new delexample(addition.add);
            delexample del2 = new delexample(subtract.sub);
            //delexample del3 = new delexample(multi.multi);
            ////multi cas delegate
            //delexample del1 = new delexample(addition.add);
            //del1 = del + subtract.sub;
            //del1 += subtract.sub;
            //del1 += multi.multi;


            //operation.performoperations(a, b, del);
            //operation.performoperations(a, b, del2);
            //operation.performoperations(a, b, del3);

            //display temp = addition.print;
            //temp += Addition.print();

            //customdel hidel, byedel, multidel, mutliwithoutbyedel,customdel5;
            //hidel = Hello;

            //byedel = Bye;
            //multidel = hidel+ byedel;
            //mutliwithoutbyedel = multidel - byedel;




        }
        
        static void Main1(string[] args)
        {
            Console.WriteLine("enter gender");
            var tempgen = Console.ReadLine();
            Enum.TryParse<genderenum>(tempgen, out var gender);
            Console.WriteLine(gender);
            Console.WriteLine("enter genre");
            string tempgenre = Console.ReadLine();
            string[] strarr = tempgenre.Split(',');
            genreEnum genre=genreEnum.comedy;
            for(int i=0;i<strarr.Length;i++)
            {
                Enum.TryParse<genreEnum>(strarr[i], out var parsedString);
            }
            foreach(var s in strarr)
            {
                Enum.TryParse<genreEnum>(s, out var parsedString);
                if(genre.HasFlag(genreEnum.comedy))
                {
                    genre = parsedString;
                }
                else
                {
                    genre = genre | parsedString;
                }
                
            }
            Console.WriteLine(genre);
            Console.ReadKey();
        }
    }
}
