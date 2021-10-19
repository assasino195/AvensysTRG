using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class Basket
    {
        
        public bool isCheckedOut { get; set; }
        private List<Product> itembasket = new List<Product>();
        public List<Product> Itembasket
        {
            get { return itembasket; }
            set { itembasket = value; }
        }
        public Basket() { }
       public Basket(bool checkedout)
        {
            isCheckedOut = checkedout;
        }
        public void addtocart(Product p)
        {
            itembasket.Add(p);
        }
        public double calculatetotal()
        {
            double temp = 0;
           foreach(var prod in itembasket)
            {
                temp += prod.productCount * prod.productPrice;
            }
            return temp*1.07;
        }
       
    }
}
