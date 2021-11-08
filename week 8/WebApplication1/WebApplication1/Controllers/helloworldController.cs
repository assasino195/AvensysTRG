using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class helloworldController : ApiController
    {
        // GET: helloworld
        public IEnumerable<string> Get()
        {
            IList<string> list = new List<string>();
            list.Add("Hello");
            list.Add("World");
            return list;
        }
        public string Get(int id)
        {
            return "calling this from get method" +id;
        }
    }
}