using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class Product
    {
        public string productName { get; set; }
        public string productCategory { get; set; }
        public string productID { get; set; }
        public int productCount { get; set; }
        public double productPrice { get; set; }
        public DateTime dtadded { get; set; }
        public Product(string pid,string pn,int pc,double pp,string prodcat)
        {
            productName = pn;
            productID = pid;
            productCount = pc;
            productPrice = pp;
            productCategory = prodcat;
        }
        public Product(Dictionary<string,Product> dic,string i,int c)
        {
            productName = dic[i].productName;
            productID = dic[i].productID;
            productCount = c;
            productPrice = dic[i].productPrice;
            productCategory = dic[i].productCategory;
        }
        public override string ToString()
        {
            return $"{productID},{productName},{productCategory},{productCount},{productPrice}";
        }
    }
}
