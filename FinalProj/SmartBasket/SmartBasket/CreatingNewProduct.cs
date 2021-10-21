using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
   public class CreatingNewProduct
    {
        public Product AddingNewProduct(string newprodID,string newprodName,int stock,double price, string category)
        {
            Product temp = new Product(newprodID, newprodName, stock, price, category);
            return temp;
        }
    }
}
