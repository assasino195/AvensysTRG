using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class CalculateTotalPrice
    {
        public double calculatetotal(List<Product> itembasket)
        {
            double temp = 0;
            foreach (var prod in itembasket)
            {
                temp += prod.productCount * prod.productPrice;
            }
            return temp * 1.07;
        }
    }
}
