using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Interface;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket/Manager")]
    public class ManagerServicesController : ApiController
    {
        iContext launchcont;
        public ManagerServicesController(iContext t)
        {
            launchcont = t;
        }

        public ManagerServicesController()
        {
            launchcont = new DictionaryContext();
        }
        
           
        // GET: ManagerServices
        [HttpPost]
        [Route("addingproduct")]
        public IHttpActionResult AddingNewProduct(ProductDTO p)
        {

            Product prod = launchcont.products.Where(x => x.ProductName == p.ProductName).FirstOrDefault();
            if (prod==null)
            {
                Product targetprod = prodDTO2Prod(p);
                launchcont.products.Add(targetprod);
               
                launchcont.SaveChanges();
                //prodDict.Add(newprodID, temp);
                return Ok("Product Created");
            }
            else
            {
                prod.productCount = p.productCount + prod.productCount;
                launchcont.Entry(prod).State = EntityState.Modified;
                launchcont.SaveChanges();
                return BadRequest("Product already exist hence, we have added the quantity in it is now current quantity: "+prod.productCount);
            }
        }
       


        [HttpGet]
        [Route("salesreport")]
        public IHttpActionResult generatesalesreport()
        {
            Dictionary<int, psuedoproduct> countingdictionary = new Dictionary<int, psuedoproduct>();
            List<string> temp = new List<string>();
            double total = 0;
            foreach (var d in launchcont.customers.ToList())
            {
                
                    if (d.psueoproducts.Count > 0)
                    {
                        foreach (var a in d.psueoproducts)
                        {
                            if (a.ischeckedout)
                            {
                               
                                    if (countingdictionary.ContainsKey(a.productid))
                                    {
                                        countingdictionary[a.productid].count += a.count;
                                    }
                                    else
                                    {
                                        countingdictionary.Add(a.productid, a);
                                    }
                                

                            }
                        }
                    }
                   
                
            }
            if (countingdictionary.Count > 0)
            {
                foreach (var a in countingdictionary)
                {
                    Product p = launchcont.products.Where(x => x.productID == a.Value.productid).FirstOrDefault();
                    if (p != null)
                    {
                        temp.Add($"Product ID:{p.productID} {p.ProductName} quantity {a.Value.count} at a price of {p.productPrice}");
                        total += a.Value.count * p.productPrice;
                    }
                }
                temp.Add("Total price of all products is: $" + total);
            }
            
            if (total > 0)
            {
                return Ok(temp);
            }
            else
            {
                return BadRequest("No purchase history was found");
            }
        }









        [HttpGet]
        [Route("viewallaccounts")]
        public IHttpActionResult viewallacc()
        {
            List<CustomerDTO> cuslist = new List<CustomerDTO>();

            foreach (var cus in launchcont.customers.ToList())
            {
                CustomerDTO temp = Customer2DTO(cus);
                cuslist.Add(temp);
            }
            if (cuslist.Count > 0)
            {
                return Ok(cuslist);
            }
            else
            {
                return BadRequest("No accounts available");
            }
        }
        [HttpPost]
        [Route("removeproduct")]
        public IHttpActionResult removeproduct(int p)
        {
            Product prod = launchcont.products.Where(x => x.productID == p).FirstOrDefault();
            if(prod!=null)
            {
                launchcont.products.Remove(prod);
                launchcont.SaveChanges();
                return Ok("Product removed");
            }
            else
            {
                return BadRequest("product not found");
            }

        }

        private Product prodDTO2Prod(ProductDTO p)
        {
            Product temp = new Product(p);
            return temp;
        }

       
        private CustomerDTO Customer2DTO(Customer cDTO)
        {
            CustomerDTO c = new CustomerDTO(cDTO);
            return c;
        }
    }
}