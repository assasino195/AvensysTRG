using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket/basket")]
    public class BasketServicesController : ApiController
    {
        // GET: BasketServices
        Models.DictionaryContext launchcont = new Models.DictionaryContext();

        
        public BasketServicesController()
        {

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
            //double temp = 0;
            //if (launchcont.customers.Any(x => x.customerID == id))
            //{
            //    foreach (var prod in launchcont.customers)
            //    {
            //        if(prod.customerID.Equals(id))
            //        {
            //            foreach (var prodd in prod.products)
            //            {
            //                string[] split = prodd.Split(' ');
            //                int.TryParse(split[2], out int count);
            //                double.TryParse(split[3], out double price);
            //                temp += count * price;
            //            }
            //            break;
            //        }
                    
            //    }
            //    temp = temp * 1.07;
            //    return Ok($"Total Price is .{temp} ");
            //}
            //else
            //{
            //    return BadRequest("ID doesn't exist");
            //}
        }
        //[HttpGet]
        //[Route("hotsellingitems")]
        //public List<string> displayHotItems()
        //{
        //    List<Product> prodlist = new List<Product>();
        //    List<string> temp = new List<string>();
        //    Dictionary<string, Product> countingdic = new Dictionary<string, Product>();
        //    foreach (var prod in launchcont.customers)
        //    {
        //        foreach (var prodd in prod.purchaseHist)
        //        {
        //            string[] split = prodd.Split(' ');
        //            int.TryParse(split[2], out int count);
        //           // double.TryParse(split[3], out double price);
        //            if (countingdic.ContainsKey(split[0]))
        //            {
        //                int totalcount = countingdic[split[0]].productCount;
        //                countingdic[split[0]].productCount = totalcount + count;
        //            }
        //            else
        //            {
        //                countingdic.Add(split[0], new Product() { productID=int.Parse( split[0]),ProductName=split[1],productCount=count});
        //            }
        //        }
        //    }

        //    string item1 = string.Empty;
        //    string item2 = string.Empty;
        //    string item3 = string.Empty;
        //    int item11 = 0;
        //    int item22 = 0;
        //    int item33 = 0;
        //    foreach (var prod in countingdic)
        //    {
        //        if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount > item11)
        //        {
        //            item3 = item2;
        //            item33 = item22;
        //            item2 = item1;
        //            item22 = item11;
        //            item11 = prod.Value.productCount;
        //            item1 = prod.Key.ToString();
        //        }
        //        else if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount < item11)
        //        {
        //            item3 = item2;
        //            item33 = item22;

        //            item22 = prod.Value.productCount;
        //            item2 = prod.Key.ToString();
        //        }
        //        else if (prod.Value.productCount > item33 && prod.Value.productCount < item22 && prod.Value.productCount < item11)
        //        {
        //            item33 = prod.Value.productCount;
        //            item3 = prod.Key.ToString();
        //        }

        //    }
        //    //temp.Add($"{launchcont.prodDict[countingdic[item1].productID] } {launchcont.DictionaryCont.prodDict[countingdic[item1].ProductName] } {launchcont.DictionaryCont.prodDict[countingdic[item1].productCount.ToString()] }"+
        //    //    $"{launchcont.DictionaryCont.prodDict[countingdic[item1].productPrice.ToString()] }");

        //    //temp.Add($"{launchcont.DictionaryCont.prodDict[countingdic[item2].productID] } {launchcont.DictionaryCont.prodDict[countingdic[item2].ProductName] } {launchcont.DictionaryCont.prodDict[countingdic[item2].productCount.ToString()] }" +
        //    //   $"{launchcont.DictionaryCont.prodDict[countingdic[item2].productPrice.ToString()] }");
        //    //temp.Add($"{launchcont.DictionaryCont.prodDict[countingdic[item3].productID] } {launchcont.DictionaryCont.prodDict[countingdic[item3].ProductName] } {launchcont.DictionaryCont.prodDict[countingdic[item3].productCount.ToString()] }" +
        //    //   $"{launchcont.DictionaryCont.prodDict[countingdic[item3].productPrice.ToString()] }");

        //    foreach(var prod in launchcont.products)
        //    {
        //        if (prod.productID.Equals(item1)||prod.Equals(item2)||prod.Equals(item3))
        //        {
        //            temp.Add($"{prod.productID} {prod.ProductName} quantity: {prod.productCount} price at: ${prod.productPrice}");
        //        }


        //    }

        //    return temp;
        //}
        [HttpGet]
        [Route("addtobasket")]
        public IHttpActionResult ShopForProduct(int prodid, int count, int customerid)
        {
            Product prod = launchcont.products.FirstOrDefault(x => x.productID == prodid);
            Customer c = launchcont.customers.FirstOrDefault(x => x.customerID == customerid);
            bool foundsameitem = false;
            if (prod != null)
            {
                if (prod.productCount > count)
                {
                    foreach(var psuedoprod in c.psueoproducts)
                    {
                        if(!psuedoprod.ischeckedout)
                        {
                            if(psuedoprod.productid.Equals(prodid))
                            {
                                foundsameitem = true;
                                psuedoprod.count = psuedoprod.count + count;
                                launchcont.Entry(psuedoprod).State = EntityState.Modified;
                                launchcont.SaveChanges();
                            }
                           
                        }
                    }
                    if(foundsameitem)
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
                return BadRequest("Item doesn't exist");
            }
        }

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
        //if (launchcont.products.Any(x => x.productID == prodid))
        //{
        //    if (launchcont.customers.Any(x => x.customerID == customerid))
        //    {

        //        Product p = launchcont.products.Where(x => x.productID == prodid).FirstOrDefault();
        //        Product temp = new Product() { ProductName = p.ProductName, productCount = count, productCategory = p.productCategory, productID = p.productID, productPrice = p.productPrice };
        //        //p.productCount = count;
        //        ////p.productCount = count;
        //        //launchcont.customers.Where(x=>x.customerID==customerid).FirstOrDefault().products.Add(p);

        //        //Product myModel = launchcont.products.FirstOrDefault(m => m.productID == prodid);
        //        // myModel.productCount = count; //user changed a value
        //        var prod = launchcont.products.AsNoTracking().FirstOrDefault(x => x.productID == prodid);
        //        prod.productCount = count;
        //        string s = $"{prod.productID} {prod.ProductName} {prod.productCount} {prod.productPrice}";
        //        launchcont.customers.FirstOrDefault(m => m.customerID == customerid).products.Add(s); //even though the ID of myModel exists in the database, it gets added as a new row and the ID gets auto-incremented 
        //        //launchcont.customers.FirstOrDefault(m => m.customerID == customerid).products.Add(p);

        //        launchcont.SaveChanges();
        //        //return Ok($"{p.ProductName} {p.productCount} has been added to basket");
        //        return Ok(launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products);

        //    }
        //    else
        //    {
        //        return BadRequest("Customer ID is not valid");
        //    }

        //}
        //else
        //{
        //    return BadRequest("Product ID is invalid");
        //}



        //}
        //[HttpGet]
        //[Route("addtobaskett")]
        //public IHttpActionResult addtobaskett(int prodid, int count, int customerid)
        //{
        //    var prod = launchcont.products.AsNoTracking().FirstOrDefault(x => x.productID == prodid);

        //   // Product temp =prod;
        //    //temp.productID = prodid;
        //    //prod.productCount = count;
        //    //temp.dtadded = DateTime.UtcNow;

        //    Customer c = launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault();
        //    bool foundprod = false;
        //    if (c.products != null)
        //    {
        //        foreach (var p in c.products)
        //        {
        //            string[] split = p.Split(' ');
        //            if (split[1].Equals(prod.ProductName))
        //            {
        //                int.TryParse(split[2], out int countt);
        //                countt += prod.productCount;
        //                foundprod = true;
        //                prod.productCount = countt;
        //                c.products.Remove(p);
        //                break;
        //            }
        //        }

        //            string s = $"{prod.productID} {prod.ProductName} {prod.productCount} {prod.productPrice}";
        //            launchcont.customers.FirstOrDefault(m => m.customerID == customerid).products.Add(s);



        //        launchcont.SaveChanges();
        //        return Ok(launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products);
        //    }
        //    else
        //    {
        //        string s = $"{prod.productID} {prod.ProductName} {prod.productCount} {prod.productPrice}";
        //        List<string> temp = new List<string>();
        //        temp.Add(s);
        //        launchcont.customers.FirstOrDefault(m => m.customerID == customerid).products=temp;
        //        launchcont.SaveChanges();
        //        return Ok(launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products);
        //    }
        //}
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
            //string itemname = string.Empty;
            //if (launchcont.customers.Any(x => x.customerID == customerid))
            //{
            //    // Product temp = null;
            //    foreach (var p in launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products)
            //    {
            //        string[] split = p.Split(' ');
            //        if (split[0].Equals(prodid))
            //        {
            //            launchcont.customers.Where(x => x.customerID == customerid).FirstOrDefault().products.Remove(p);
            //            founditem = true;
            //            itemname = ($"{split[1]} has been removed from basket");

            //            launchcont.SaveChanges();

            //        }
            //    }
            //    if (!founditem)
            //    {
            //        return BadRequest("Item does not exist in customer's item basket");
            //    }
            //    else
            //    {
            //        return Ok(itemname);
            //    }



           
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
                    //List<Product> temp = new List<Product>();

                    //Product p=launchcont.products.Where()
                    //prod.dtadded = DateTime.UtcNow;

                    //            var produt = launchcont.products.AsNoTracking().FirstOrDefault(x => x.productID == p.productID);
                    //            if (produt.productCount>p.productCount)
                    //            {
                    //                c.purchaseHist.Add(produt);
                    //            }


                    //        c.psueoproducts.Clear();
                    //        //c.products.Clear();
                    //        launchcont.SaveChanges();
                    //        return Ok("Successfully checked out");
                    //    }
                    //    else
                    //    {
                    //        return BadRequest("No products in basket");
                    //    }

                    //}
                    //else
                    //{
                    //    return BadRequest("Invalid ID");
                    //}}
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
                    if (temp.Count >= 0)
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
            if (prodlist != null)
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