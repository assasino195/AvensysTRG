using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Interface;



namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket/basket")]
    public class BasketServicesController : ApiController
    {
        // GET: BasketServices
        iContext launchcont;

       
        public BasketServicesController(iContext t)
        {
            launchcont = t;
        }
        public BasketServicesController()
        {
            launchcont = new DictionaryContext();
        }
        [HttpGet]
       [Route("calculatetotal")]
        public IHttpActionResult calculatetotal(int customerid)
        {
            List<string> result = new List<string>();
            double total = 0;
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
            List<psuedoproduct> psuedprods = new List<psuedoproduct>();
            if (c != null)
            {
                if (c.psueoproducts.Count > 0)
                {
                    foreach (var prod in c.psueoproducts)
                    {
                        if (!prod.ischeckedout)
                        {
                            psuedprods.Add(prod);
                        }
                    }
                    if (psuedprods.Count > 0)
                    {
                        foreach (var prod in psuedprods)
                        {
                            Product p = launchcont.products.Where(x => x.productID == prod.productid).FirstOrDefault();
                            string addtoresultstring = $"Product ID: {prod.productid} {p.ProductName} Quantity: {prod.count} at a price of ${p.productPrice} ";
                            total += prod.count * p.productPrice;
                            result.Add(addtoresultstring);
                        }
                        if (total > 0)
                        {
                            result.Add($"Total Price of all products is {total * 1.07} inclusive of GST of {total * 0.07}");
                            return Ok(result);
                        }
                        else
                        {
                            return BadRequest("No products in basket was found");
                        }
                    }
                    else
                    {
                        return BadRequest("No products in basket was found");
                    }

                }
                else
                {
                    return BadRequest("No products in basket was found");
                }
            }
            else
            {
                return BadRequest("Invalid ID");
            }    
          
        }
       
        [HttpGet]
        [Route("addtobasket")]
        public IHttpActionResult ShopForProduct(int prodid, int count, int customerid)
        {
            Product prod = launchcont.products.FirstOrDefault(x => x.productID == prodid);
            Customer c = launchcont.customers.FirstOrDefault(x => x.customerID == customerid);
            bool foundsameitem = false;
            if (prod != null)
            {
                if (c != null)
                {
                    if (prod.productCount > count)
                    {

                        foreach (var psuedoprod in c.psueoproducts)
                        {
                            if (!psuedoprod.ischeckedout)
                            {
                                if (psuedoprod.productid.Equals(prodid))
                                {
                                    foundsameitem = true;
                                    psuedoprod.count = psuedoprod.count + count;
                                    launchcont.Entry(psuedoprod).State = EntityState.Modified;
                                    launchcont.SaveChanges();
                                }

                            }
                        }
                        if (foundsameitem)
                        {
                            return Ok("Updated Quantity of product");
                        }
                        else
                        {
                            c.psueoproducts.Add(new psuedoproduct() { productid = prodid, count = count, dt = DateTime.UtcNow });

                            launchcont.SaveChanges();
                            return Ok($"{prod.ProductName} has been added to basket");
                        }




                    }
                    else
                    {
                        return BadRequest("Please lower amount of quantity to purchase");
                    }
                }
                else
                {
                    return BadRequest("customer ID doesn't exist");
                }
            }
            else
            {
                return BadRequest("Item doesn't exist");
            }
        }

        
        [HttpPost]
        [Route("removefrombasket")]
        public IHttpActionResult Removefrombasket(int prodid, int customerid)
        {
            bool founditem = false;
            
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
            if(c!=null)
            {
                foreach(var prod in c.psueoproducts)
                {
                    if(!prod.ischeckedout)
                    {
                        if (prod.productid.Equals(prodid))

                        {
                            c.psueoproducts.Remove(prod);
                            
                            founditem = true;
                            launchcont.SaveChanges();
                            break;

                        }
                    }
                }
                if(founditem)
                {
                    return Ok("Item Removed from basket");
                }
                else
                {
                    return BadRequest("Item not found in basket");
                }
            }
            else
            {
                return BadRequest("Invalid Customer ID");
            }
           


           
        }
        [HttpGet]
        [Route("viewbasket")]
        public IHttpActionResult viewbasket(int customerid)
        {
            List<string> psuedoproducts = new List<string>();
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
            if (c != null)
            {

                if (c.psueoproducts.Count > 0)
                {
                    foreach (var prod in c.psueoproducts)
                    {
                        if (!prod.ischeckedout)
                        {
                            Product p = launchcont.products.Where(x => x.productID == prod.productid).FirstOrDefault();
                            string result = $"product ID:{p.productID} {p.ProductName} Quantity: {prod.count} at price of ${p.productPrice}";
                            psuedoproducts.Add(result);
                        }
                    }
                    if (psuedoproducts.Count > 0)
                    {
                        return Ok(psuedoproducts);
                    }
                    else
                    {
                        return BadRequest("No items in basket");
                    }
                }
                else
                {
                    return BadRequest("No products in basket");
                }

            }
            else
            {
                return BadRequest("Invalid ID");
            }

        }
        [HttpPost]
         [Route("checkout")]
         public IHttpActionResult checkingout(int customerid)
        {
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();

            bool hasitem = false;
            if (c != null)
            {

                if (c.psueoproducts.Count > 0)
                {
                    foreach (var prod in c.psueoproducts)
                    {
                        if (!prod.ischeckedout)
                        {
                            var produc = launchcont.products.FirstOrDefault(x => x.productID == prod.productid);
                            if (prod.count <= produc.productCount)
                            {
                                hasitem = true;
                                prod.ischeckedout = true;
                                prod.dt = DateTime.UtcNow;
                                produc.productCount = produc.productCount - prod.count;
                                launchcont.Entry(produc).State = EntityState.Modified;
                                launchcont.SaveChanges();
                                
                                
                            }
                           
                        }
                       
                    }
                    if(hasitem)
                    {
                        return Ok("sucessfully checkedout");
                    }
                    else
                    {
                        return BadRequest("No items in basket");
                    }
                 
                }
                {
                    return BadRequest("no item in basket");
                }
            }
            {
                return BadRequest("Invalid customer ID");
            }
        }
        [HttpGet]
        [Route("viewpurchasehistory")]
        public IHttpActionResult viewpurchasehist(int customerid)
        {
            List<string> temp = new List<string>();
            
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
            if (c != null)
            {

                if (c.psueoproducts.Count > 0)
                {
                    foreach(var prod in c.psueoproducts)
                    {
                        if (prod.ischeckedout)
                        {
                            Product p = launchcont.products.Where(x => x.productID == prod.productid).FirstOrDefault();
                            string result = $"Product ID:{p.productID} {p.ProductName} Quantity:{prod.count} purchased on {prod.dt}";
                            temp.Add(result);
                        }
                    }
                    if (temp.Count > 0)
                    {
                        return Ok(temp);
                    }
                    else
                    {
                        return BadRequest("No items in list");
                    }
                }
                else
                {
                    return BadRequest("No purchase history");
                }

            }
            else
            {
                return BadRequest("Invalid ID");
            }
        }
        [HttpGet]
        [Route("viewproducts")]
        public IHttpActionResult viewproducts()
        {
            List<Product> prodlist = new List<Product>();
            foreach(var prod in launchcont.products)
            {
                if (prod.productCount > 0)
                {
                    prodlist.Add(prod);
                }
            }
            if (prodlist.Count>0)
            {
                return Ok(prodlist);
            }
            else
            {
                return BadRequest("No available items");
            }
        }


    }
}