using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace minitest.Controllers
{
    public class MathController : ApiController
    {
        // GET: Math
        [HttpGet]
        [Route("Addition/{a:int}/{b:int}")]
        public string Addition(int a,int b)
        {
            Math maths = new Math();
            return $"Addition of {a} and {b} is "+maths.Addition(a, b);
        }
        [HttpGet]
        [Route("Subtraction/{a:int}/{b:int}")]
        public string Subtraction(int a, int b)
        {
            Math maths = new Math();
            return $"Subtraction of {a} and {b} is " + maths.Subtraction(a, b);
        }
        [HttpGet]
        [Route("Divide/{a:int}/{b:int}")]
        public string Divide(int a, int b)
        {
            Math maths = new Math();
            return $"Subtraction of {a} / {b} is " + maths.Divide(a, b);
        }
        [HttpGet]
        [Route("Subtraction/{a:int}/{b:int}")]
        public string Mod(int a, int b)
        {
            Math maths = new Math();
            return $"Subtraction of {a} % {b} is " + maths.Mod(a, b);
        }

    }
    public class Math
    {
        public int Addition(int a,int b)
        {
            return a + b;
        }
        public int Subtraction(int a,int b)
        {
            return a - b;
        }
        public int Divide(int a,int b)
        {
            return a / b;
        }
        public int Mod(int a,int b)
        {
            return a % b;
        }
    }
}