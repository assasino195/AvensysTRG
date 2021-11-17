using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket")]

    public class AccountController : ApiController
    {
        iContext launchcont;
       
        public AccountController(iContext t)
        {
            launchcont = t;
        }
        public AccountController()
        {
            launchcont = new DictionaryContext();
        }
          // DictionaryContext launchcont = new DictionaryContext();
        
        // GET: Account
        [HttpGet]
        [Route("login")]
        public IHttpActionResult loginfunc(int id)
        {
            Customer c = launchcont.customers.Where(x => x.customerID == id).FirstOrDefault();
            return Ok(c);
        }
        [HttpPost]
        [Route("addingcustomer")]
        public IHttpActionResult createcustomer(Customer c)
        {
            if (!launchcont.customers.Any(x => x.customerID == c.customerID))
            {
                launchcont.customers.Add(c);
                launchcont.SaveChanges();
                return Ok("Customer Created");
            }
            else
            {
                return BadRequest("Customer ID already exist");
            }
        }
    }
}