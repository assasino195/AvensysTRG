using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolinterviewsys
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, interviewee> applist = new Dictionary<string, interviewee>();
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("1.Applying for job\n2.Exit");
                string inp = Console.ReadLine();
                switch(inp)
                {
                    case "1":
                        {
                            Console.WriteLine("What is your name");
                            string name = Console.ReadLine();
                            Console.WriteLine("How much teaching experience do you have?");
                            double teachexp = double.Parse(Console.ReadLine());
                            Console.WriteLine("What was ur marks post graduate");
                            double marks = double.Parse(Console.ReadLine());
                            applist.Add(name, new interviewee(name, marks, teachexp));
                            break;
                        }
                    case "2":
                        {
                            stay = false;
                            break;
                        }
                    case "999":
                        {
                            double[] best = new double[] { 0, 0 };
                            string bestname = string.Empty;
                            foreach (var d in applist)
                            {
                                if (string.IsNullOrEmpty(bestname))
                                {
                                    bestname = d.Value.name;
                                    best[0] = d.Value.teachingexp;
                                    best[1] = d.Value.marks;
                                }
                                else
                                {
                                    if (best[1] >= d.Value.teachingexp)
                                    {
                                        if (best[0] > d.Value.marks)
                                        {
                                            bestname = d.Value.name;

                                        }
                                    }
                                }
                            }
                            Console.WriteLine("best candidate is: "+bestname);
                            break;
                        }
                }
               
                
                //string temp = $"{name},{teachexp},{marks}";
            
               

            }

        }
        /*The principal need to assign the faculty members.
The candidates must have 3 years’ experience in teaching. And have a post graduate in the respective.
Apart from the interview mark the candidates must be selected on the percentage of mark they have secured academically and the years of experience.
Rule out the disqualified and unselected candidates, with proper reason.
         */
    }
}
