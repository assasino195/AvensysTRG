using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examsys
{
    class question
    {
         string questionname { get; set; }
        string questionid { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string correc { get; set; }
        public string actualquestion { get; set; }
        List<string> queslst = new List<string>();
        public question(string actualquestion,string a,string b,string c)
        {
            A = a;
            B = b;
            correc = c;
            this.actualquestion = actualquestion;
          
            queslst.Add(this.actualquestion);
        }
        public string getquestion(int i)
        {
            return queslst[i];
        }
        public void displayallquestions()
        {
            for(int i=0;i<queslst.Count;i++)
            {
                Console.WriteLine($"{i+1}. {queslst[i]}");
            }
        }
        public void removeques(int i)
        {
            displayallquestions();
            Console.WriteLine("Which question do you wish to remove?");
            try
            {
                int a = int.Parse(Console.ReadLine());
                queslst.RemoveAt(a);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine($"Argument null exception caught: {e.Message}");
            }
            catch(FormatException e)
            {
                Console.WriteLine($"Format exception caught: {e.Message}");
            }
            catch(OverflowException e)
            {
                Console.WriteLine($"Overflow exception caught: {e.Message}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        
    }
}
