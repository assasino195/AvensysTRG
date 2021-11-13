using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket")]

    public class AccountController : ApiController
    {
        
           Models.DictionaryContext launchcont = new Models.DictionaryContext();
        
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
            //custDict.Add(idinput,

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