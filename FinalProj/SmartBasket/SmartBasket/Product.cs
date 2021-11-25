using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class Product
    {
        
        public string ProductName { get; set; }

        
        public string productCategory { get; set; }

      
        public int productID { get; set; }

       
        public int productCount { get; set; }

        
        public double productPrice { get; set; }
        public DateTime dtadded { get; set; }
        public Product()
        {

        }
        public Product(ProductDTO p)
        {
            productCategory = p.productCategory;
            productCount = p.productCount;
            productID = p.productID;
            productPrice = p.productPrice;
            ProductName = p.ProductName;
            dtadded = p.dtadded;
        }
        //public Product() { }
        //public Product(string pid,string pn,int pc,double pp,string prodcat)
        //{
        //    ProductName = pn;
        //    productID = pid;
        //    productCount = pc;
        //    productPrice = pp;
        //    productCategory = prodcat;
        //}
        //public Product(string pid, string pn, int pc, double pp, string prodcat,DateTime dt)
        //{
        //    ProductName = pn;
        //    productID = pid;
        //    productCount = pc;
        //    productPrice = pp;
        //    productCategory = prodcat;
        //    dtadded = dt;
        //}
        //public Product(Dictionary<string,Product> dic,string i,int c)
        //{
        //    ProductName = dic[i].ProductName;
        //    productID = dic[i].productID;
        //    productCount = c;
        //    productPrice = dic[i].productPrice;
        //    productCategory = dic[i].productCategory;
        //}
        //public override string ToString()
        //{
        //    return $"{productID},{ProductName},{productCategory},{productCount},{productPrice}";
        //}
    }
}
