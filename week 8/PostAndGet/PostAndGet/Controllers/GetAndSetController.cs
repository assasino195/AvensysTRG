using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;


namespace PostAndGet.Controllers
{
    
    [RoutePrefix("API/stud")]
    public class GetAndSetController : ApiController
    {
        student temp = new student() { id = 1, name = "weiyao" };
        Dictionary<int, student> tempdict = new Dictionary<int, student>();
       

        [Route("")]
        public IEnumerable<string> Get()
        {
            List<string> list = new List<string>();
            list.Add("Welcome to");
            list.Add("Student get & post");
           
            return list;
        }
        // GET: GetAndSet
        [Route("create/{id:int}/{name}")]
        public string POST( int id,string name)
        {

            tempdict.Add(id, new student() { name = name, id = id });
            return "Added student";
            
        }
        [Route("id")]
        public string Get(int id)
        {
            tempdict.Add(1, temp);
           if(tempdict.ContainsKey(id))
            {
                return $"{tempdict[id].name} {tempdict[id].id}";
            }
           else
            {
                return "user not found";
            }
        }
    }
}