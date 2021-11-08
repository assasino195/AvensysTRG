using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;


namespace WebApplication6.Controllers
{ 
    [RoutePrefix("API/Hello")]
    public class HelloWorldController : ApiController
    {
        //Dictionary<int, student> tempdict = new Dictionary<int, student>();
        // GET: HelloWorld
        [Route("")]
        public IEnumerable<string> Get()
        {
            List<string> list = new List<string>();
            list.Add("Hello");
            list.Add("world");
            return list;
        }
        [Route("")]
        public string Get(int id)
        {
            return "This is get ID " + id;
        }
        [Route("{id:int}")]
        public string Get(int id,string name)
        {
            return "Parameteried get method with ID: " + id + " Name" + name;
        }
        //[Route("Find/{id:min(100)}")]
        //public string Get(int id, string name)
        //{
        //    return "default get method with ID: " + id + " Name" + name;
        //}
        //[Route("FindOpt/{name?}")]
        //[Route("FindOpt/{name:maxlength(3)?")]
        //[Route("FindOpt/{name:length(3,5)?")]
        [Route("Find")]
        public Student POST()
        {
            return new Student() { id = 1, name = "Wei Yao" };
        }
        [Route("Store")]
        public Student POST(Student stu,double lol)
        {
            return stu;
        }
        [Route("Store1")]
        public Dictionary<int,Student> POST(Student stu,int ID)
        {
            Dictionary<int, Student> dict = new Dictionary<int, Student>();
            dict.Add(ID, stu);
            return dict;
        }
        [Route("Store2")]
        public Student POST([FromUri]Student stu)
        {
           
            return stu;
        }
        [Route("")]
        public HttpResponseMessage POST(int id,int id1)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            if (id == 100)
            {
                message.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;

            message.ReasonPhrase = "You are calling the post with two int ARGS";
            return message;
        }
      

    }
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}