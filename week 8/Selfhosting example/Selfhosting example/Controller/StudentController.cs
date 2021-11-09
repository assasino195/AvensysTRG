using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Selfhosting_example.Controller
{
    
    class StudentController:ApiController
    {

        public List<Model.Student> studlist = new List<Model.Student>();
        [HttpGet]
        [Route("testing")]
        public string def()
        {
            return "hi";
        }
        //public string createstudent(string name,string id,string email,string add)
        //{
        //    studlist.Add(new Model.Student() { name = name, Id = id, email = email, address = add });
        //    return "Student created";
        //}


    }
}
