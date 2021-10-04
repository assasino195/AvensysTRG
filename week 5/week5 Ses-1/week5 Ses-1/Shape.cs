using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_Ses_1
{
    class Shape
    {
        public delegate void eventhandler(string shapes);
        public event eventhandler send;
        int side;
        double deg;
        string shape;

        public void getinput(object s,object d)
        {
            try
            {
                side = int.Parse((string)(s));
                deg = double.Parse((string)(d));
                checkdegree();
                if(send!=null)
                {
                    send(shape);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Argument Null Exception caught: {e.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FORMAT Eception raised {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Over flowed {ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("EXCEPTION CAUGHT!");
            }


        }
        private void checkdegree()
        {
           
              switch(side)
                {
                    case 1:
                        {
                            shape = "Not any shape";
                            break;
                        }
                    case 2:
                        {
                            shape = "Not any shape";
                            break;
                        }
                    case 3:
                        {
                            if(deg>180)
                            {
                                shape = "Not any shape";
                            }
                            else
                            {
                                shape = "Triangel Shape!";
                            }
                            break;
                        }
                    case 4:
                        {
                            if(deg>360)
                            {
                                shape = "Not any shape";
                            }
                            else
                            {
                                shape = "Rectangle Shape!";
                            }
                            break;
                        }
                }
            
        }

    }
}
