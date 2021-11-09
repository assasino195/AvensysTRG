using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Question2.Controllers
{
    [RoutePrefix("API/Q2")]
    public class ManageEmployeeController : ApiController
    {
        
        Dictionary<string, student> studic = new Dictionary<string, student>(); 
        [HttpGet]
        [Route("")]
        public string welcome()
        {
            return "welcome";
        }
        // GET: ManageEmployee
        [HttpPost]
        [Route("Create/{id}/{name}/{desp}")]
        public string create(string id,string name,string desp)
        {
            if(!studic.ContainsKey(id))
            {
                studic.Add(id, new student() { ID = id, Name = name,Desp=desp });
                return "Student created";
            }
            else
            {
                return "student already exist";
            }
            
           
        }
        [HttpPost]
        [Route("Edit/{id}")]
        public string edit(string id,string desp)
        {
           if(studic.ContainsKey(id))
            {
                studic[desp].Desp = desp;
                return "Changed data";
                
            }
           else
            {
                return "ID not found";
            }
        }
        
        [HttpPost]
        [Route("Exit")]
        public string exit()
        {

            return "exited";
        }
    }
    public class student
    {
    private string name;
        public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string id;
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
        private string desp;
        public string Desp
        {
            get { return desp; }
            set { desp = value; }
        }
    }
}