using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket/basket")]
    public class BasketServicesController : ApiController
    {
        // GET: BasketServices
        Models.DictionaryContext launchcont = new Models.DictionaryContext();
        [HttpGet]
       [Route("calculatetotal")]
        public IHttpActionResult calculatetotal(int id)
        {
            double temp = 0;
            if (launchcont.customers.Any(x => x.customerID == id))
            {
                foreach (var prod in launchcont.customers)
                {
                    if(prod.customerID.Equals(id))
                    {
                        foreach (var prodd in prod.products)
                        {
                            temp += prodd.productCount * prodd.productPrice;
                        }
                        break;
                    }
                    
                }
                temp = temp * 1.07;
                return Ok($"Total Price is .{temp} ");
            }
            else
            {
                return BadRequest("ID doesn't exist");
            }
        }
        [HttpGet]
        [Route("hotsellingitems")]
        public List<string> displayHotItems()
        {
            List<Product> prodlist = new List<Product>();
            List<string> temp = new List<string>();
            Dictionary<int, Product> countingdic = new Dictionary<int, Product>();
            foreach (var prod in launchcont.customers)
            {
                foreach (var prodd in prod.purchaseHist)
                {
                    if (countingdic.ContainsKey(prodd.productID))
                    {
                        int totalcount = countingdic[prodd.productID].productCount;
                        countingdic[prodd.productID].productCount = totalcount + prodd.productCount;
                    }
                    else
                    {
                        countingdic.Add(prodd.productID, prodd);
                    }
                }
            }
                
            string item1 = string.Empty;
            string item2 = string.Empty;
            string item3 = string.Empty;
            int item11 = 0;
            int item22 = 0;
            int item33 = 0;
            foreach (var prod in countingdic)
            {
                if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount > item11)
                {
                    item3 = item2;
                    item33 = item22;
                    item2 = item1;
                    item22 = item11;
                    item11 = prod.Value.productCount;
                    item1 = prod.Key.ToString();
                }
                else if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount < item11)
                {
                    item3 = item2;
                    item33 = item22;

                    item22 = prod.Value.productCount;
                    item2 = prod.Key.ToString();
                }
                else if (prod.Value.productCount > item33 && prod.Value.productCount < item22 && prod.Value.productCount < item11)
                {
                    item33 = prod.Value.productCount;
                    item3 = prod.Key.ToString();
                }

            }
            //temp.Add($"{launchcont.prodDict[countingdic[item1].productID] } {launchcont.DictionaryCont.prodDict[countingdic[item1].ProductName] } {launchcont.DictionaryCont.prodDict[countingdic[item1].productCount.ToString()] }"+
            //    $"{launchcont.DictionaryCont.prodDict[countingdic[item1].productPrice.ToString()] }");

            //temp.Add($"{launchcont.DictionaryCont.prodDict[countingdic[item2].productID] } {launchcont.DictionaryCont.prodDict[countingdic[item2].ProductName] } {launchcont.DictionaryCont.prodDict[countingdic[item2].productCount.ToString()] }" +
            //   $"{launchcont.DictionaryCont.prodDict[countingdic[item2].productPrice.ToString()] }");
            //temp.Add($"{launchcont.DictionaryCont.prodDict[countingdic[item3].productID] } {launchcont.DictionaryCont.prodDict[countingdic[item3].ProductName] } {launchcont.DictionaryCont.prodDict[countingdic[item3].productCount.ToString()] }" +
            //   $"{launchcont.DictionaryCont.prodDict[countingdic[item3].productPrice.ToString()] }");
            
            foreach(var prod in launchcont.products)
            {
                if (prod.productID.Equals(item1)||prod.Equals(item2)||prod.Equals(item3))
                {
                    temp.Add($"{prod.productID} {prod.ProductName} quantity: {prod.productCount} price at: ${prod.productPrice}");
                }
                   
                
            }

            return temp;
        }
        [HttpGet]
        [Route("addtobasket")]
        public IHttpActionResult ShopForProduct(int prodid, int count,int customerid)
        {
            //foreach (var prodic in prodDict)
            //{
            //    if (prodic.Value.productCategory.Equals("Vegetables"))
            //    {
            //        if (prodic.Value.productCount > 0)
            //        {
            //            string temp = $"{prodic.Key}. {prodic.Value.productName}\t Price is: ${string.Format("{0:N2}", prodic.Value.productPrice)}\t " +
            //                $"In stock: {prodic.Value.productCount}";
            //            Console.WriteLine(temp);
            //        }
            //    }
            //}
            if(launchcont.products.Any(x => x.productID == prodid))
            {
                if(launchcont.customers.Any(x => x.customerID == customerid))
                {

                    Product p = launchcont.products.Where(x => x.productID == prodid).FirstOrDefault();
                    p.productCount = count;
                    launchcont.customers.Where(x=>x.customerID==customerid).FirstOrDefault().products.Add(p);
                    launchcont.SaveChanges();
                    return Ok($"{p.ProductName} {p.productCount} has been added to basket");

                }
                else
                {
                    return BadRequest("Customer ID is not valid");
                }
                
            }
            else
            {
                return BadRequest("Product ID is invalid");
            }
            
            

        }
        [HttpGet]
        [Route("removefrombasket")]
        public IHttpActionResult Removefrombasket(int prodid, int customerid)
        {
            if (launchcont.customers.Any(x => x.customerID == customerid))
            {
                Product temp = null;
                foreach (var p in launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products)
                {
                    if (p.productID.Equals(prodid))
                    {
                        temp = p;
                    }
                }
                if (temp != null)
                {
                    launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products.Remove(temp);
                    launchcont.SaveChanges();
                    return Ok($"{temp.ProductName} has been removed from basket");
                }
                else
                {
                    return BadRequest("Item does not exist in customer's item basket");
                }


            }
            else
            {
                return BadRequest("Customer ID does not exist");
            }
        }
        [HttpGet]
        [Route("viewbasket")]
        public IHttpActionResult viewbasket(int customerid)
        {
            
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
            if (c != null)
            {

                if(c.products.Count>0)
                {
                    return Ok(c.products);
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
         [HttpGet]
         [Route("checkout")]
         public IHttpActionResult checkingout(int customerid)
        {
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
          
            if (c != null)
            {

                if (c.products.Count > 0)
                {
                    //List<Product> temp = new List<Product>();
                    foreach(var prod in c.products)
                    {
                        c.purchaseHist.Add(prod);

                         
                    }
                    launchcont.SaveChanges();
                    return Ok("Successfully checked out");
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
        [HttpGet]
        [Route("viewpurchasehistory")]
        public IHttpActionResult viewpurchasehist(int customerid)
        {
            Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
            if (c != null)
            {

                if (c.purchaseHist.Count > 0)
                {
                    return Ok(c.products);
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

           
        
    }
}