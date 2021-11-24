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
           
            return Ok(Customer2DTO(c));
        }
        [HttpPost]
        [Route("addingcustomer")]
        public IHttpActionResult createcustomer(CustomerDTO cDTO)
        {

            if (!launchcont.customers.Any(x => x.customerID == cDTO.customerID))
            {
                Customer c = DTO2Customer(cDTO);
                if (c.customerName == "" || c.customerPhoneNo == "" || c.customerEmail == "")
                {
                    return BadRequest("Please Fill in ur details for account creation");
                }
                else
                {
                    launchcont.customers.Add(c);
                    launchcont.SaveChanges();
                    return Ok("Customer Created");
                }
            }
            else
            {
                return BadRequest("Customer ID already exist");
            }
        }

        private Customer DTO2Customer(CustomerDTO cDTO)
        {
            Customer c = new Customer()
            {
                customerName = cDTO.customerName,
                customerEmail = cDTO.customerEmail,
                customerID = cDTO.customerID,
                customerPhoneNo = cDTO.customerPhoneNo,
                isCheckedOut = cDTO.isCheckedOut,

                psueoproducts = cDTO.psueoproducts,
                role = cDTO.role
            };
            return c;
        }
        private CustomerDTO Customer2DTO(Customer cDTO)
        {
            CustomerDTO c = new CustomerDTO(cDTO)
            {

            };
            return c;
        }
    }
}