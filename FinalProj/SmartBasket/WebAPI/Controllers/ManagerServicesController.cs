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

            Product prod = launchcont.products.Where(x => x.ProductName == p.ProductName).FirstOrDefault();
            if (prod==null)
            {
                launchcont.products.Add(p);
               
                launchcont.SaveChanges();
                //prodDict.Add(newprodID, temp);
                return Ok("Product Created");
            }
            else
            {
                return BadRequest("Product already exist");
            }
        }
        

        [HttpGet]
        [Route("salesreport")]
        public List<string> generatesalesreport()
        {
            Dictionary<string, Product> countingdictionary = new Dictionary<string, Product>();
            List<string> temp = new List<string>();
            double total = 0;
            foreach (var d in launchcont.customers)
            {
                foreach (var a in d.purchaseHist)
                {
                    //string[] split = a.Split(' ');
                    //int.TryParse( split[2], out int countt);
                    //double.TryParse(split[3], out double price);
                    //if (countingdictionary.ContainsKey(split[0]))
                    //{
                    //    countingdictionary[split[0]].productCount +=countt;
                    //}
                    //else
                    //{
                    //    countingdictionary.Add(split[0], new Product() { productID = int.Parse(split[0]), ProductName = split[1], productCount = countt });
                    //}
                    Console.WriteLine($"Product ID:{a.productID}\t{a.ProductName} quantity {a.productCount} at a price of {a.productPrice}");
                    temp.Add($"Product ID:{a.productID}\t{a.ProductName} quantity {a.productCount} at a price of {a.productPrice}");
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