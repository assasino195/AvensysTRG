using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket/Manager")]
    public class ManagerServicesController : ApiController
    {
        Models.DictionaryContext launchcont = new Models.DictionaryContext()
        {
            
       
        };


        
           
        // GET: ManagerServices
        [HttpPost]
        [Route("addingproduct")]
        public IHttpActionResult AddingNewProduct(Product p)
        {
            
            
            if(!launchcont.products.Any(x => x.productID == p.productID))
            {
                launchcont.products.Add(p);
               
                launchcont.SaveChanges();
                //prodDict.Add(newprodID, temp);
                return Ok("Product Created");
            }
            else
            {
                return BadRequest("Product ID already exist");
            }
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

        [HttpGet]
        [Route("salesreport")]
        public List<string> generatesalesreport()
        {
            Dictionary<int, Product> countingdictionary = new Dictionary<int, Product>();
            List<string> temp = new List<string>();
            double total = 0;
            foreach (var d in launchcont.customers)
            {
                foreach (var a in d.purchaseHist)
                {
                    if (countingdictionary.ContainsKey(a.productID))
                    {
                        countingdictionary[a.productID].productCount += a.productCount;
                    }
                    else
                    {
                        countingdictionary.Add(a.productID, a);
                    }
                    // Console.WriteLine($"Product ID:{a.productID}\t{a.productName} quantity {a.productCount} at a price of {a.productPrice}");
                    //temp.Add($"Product ID:{a.productID}\t{a.productName} quantity {a.productCount} at a price of {a.productPrice}");
                    total += a.productCount * a.productPrice;
                }
            }
            //Console.WriteLine();
            //countingdictionary.OrderByDescending

            foreach (var d in countingdictionary)
            {
                temp.Add($"ID: {d.Key}\t{d.Value.ProductName}\twas sold {d.Value.productCount}\ttimes at {d.Value.productPrice}");
            }
            temp.Add("Total Sales: " + total);
            temp.Add("Total GST Taxed: " + total * 0.07);
            return temp;
        }








        [HttpGet]
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        [HttpGet]
        public bool isvalidphoneno(string phoneno)
        {
            int count = 0;
            foreach (char a in phoneno)
            {
                if (count == 0)
                {
                    if (a == '8' || a == '9')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                count++;
            }
            if (count == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}