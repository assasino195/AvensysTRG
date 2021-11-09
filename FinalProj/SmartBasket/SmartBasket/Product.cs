using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class Product
    {
        private string productName;
        public string ProductName { get {return productName; } set { productName = value ; } }

        private string ProductCategory;
        public string productCategory { get { return ProductCategory; } set { ProductCategory = value; } }

        private string ProductID;
        public string productID { get { return ProductID; } set { ProductID = value; } }

        private int ProductCount;
        public int productCount { get { return ProductCount; } set { ProductCount = value; } }

        private double ProductPrice;
        public double productPrice { get { return ProductPrice; } set { ProductPrice = value; } }
        public DateTime dtadded { get; set; }
        public Product() { }
        public Product(string pid,string pn,int pc,double pp,string prodcat)
        {
            ProductName = pn;
            productID = pid;
            productCount = pc;
            productPrice = pp;
            productCategory = prodcat;
        }
        public Product(string pid, string pn, int pc, double pp, string prodcat,DateTime dt)
        {
            ProductName = pn;
            productID = pid;
            productCount = pc;
            productPrice = pp;
            productCategory = prodcat;
            dtadded = dt;
        }
        public Product(Dictionary<string,Product> dic,string i,int c)
        {
            ProductName = dic[i].ProductName;
            productID = dic[i].productID;
            productCount = c;
            productPrice = dic[i].productPrice;
            productCategory = dic[i].productCategory;
        }
        public override string ToString()
        {
            return $"{productID},{ProductName},{productCategory},{productCount},{productPrice}";
        }
    }
}
