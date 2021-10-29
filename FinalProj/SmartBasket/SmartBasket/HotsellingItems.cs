using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class HotsellingItems
    {
        public List<Product> displayHotItems(Dictionary<string,Customer> cusdic)
        {
            List<Product> temp = new List<Product>();
            Dictionary<string, Product> countingdic = new Dictionary<string, Product>();
            foreach(var cus in cusdic)
            {
               foreach(var prodinpurc in cus.Value.PurchaseHistory)
                {
                    if(countingdic.ContainsKey(prodinpurc.productID))
                    {
                        int totalcount = countingdic[prodinpurc.productID].productCount;
                        countingdic[prodinpurc.productID].productCount = totalcount + prodinpurc.productCount;
                    }
                    else
                    {
                        countingdic.Add(prodinpurc.productID, prodinpurc);
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
                    item1 = prod.Key;
                }
                else if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount < item11)
                {
                    item3 = item2;
                    item33 = item22;

                    item22 = prod.Value.productCount;
                    item2 = prod.Key;
                }
                else if (prod.Value.productCount > item33 && prod.Value.productCount < item22 && prod.Value.productCount < item11)
                {
                    item33 = prod.Value.productCount;
                    item3 = prod.Key;
                }

            }
            temp.Add(countingdic[item1]);
            temp.Add(countingdic[item2]);
            temp.Add(countingdic[item3]);
            //temp.Add($"{countingdic[item1].productID}: {countingdic[item1].productName}\tQuantity Sold:{countingdic[item1].productCount}\tAt: ${countingdic[item1].productPrice}");
            //temp.Add($"{countingdic[item2].productID}: {countingdic[item2].productName}\tQuantity Sold:{countingdic[item2].productCount}\tAt: ${countingdic[item2].productPrice}");
            //temp.Add($"{countingdic[item3].productID}: {countingdic[item3].productName}\tQuantity Sold:{countingdic[item3].productCount}\tAt: ${countingdic[item3].productPrice}");
            //foreach(var prod in countingdic)
            //{

            //    if(prod.Value.productCount>item3 && prod.Value.productCount>item2   &&  prod.Value.productCount>item1)
            //    {

            //        item3 = item2;
            //        item2 = item1;
            //        item1 = prod.Value.productCount;
            //    }
            //    else if(prod.Value.productCount > item3 && prod.Value.productCount > item2 && prod.Value.productCount < item1)
            //    {
            //        item3 = item2;
            //        item2 = prod.Value.productCount;
            //    }
            //}
            return temp;
        }
    }
}
