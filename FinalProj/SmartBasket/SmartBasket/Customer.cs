﻿using System.Collections.Generic;

namespace SmartBasket
{
    public class Customer
    {
        public string customerName { get; set; }
        
        public int customerID { get; set; }

        public string role { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNo { get; set; }
        public bool isCheckedOut { get; set; }

        public virtual ICollection<Product> products { get; set; }
        public virtual ICollection<Product> purchaseHist { get; set; }

        //private Basket bas = new Basket();
        // public Basket Bas { get { return bas; } set { bas = value; } }
        //[ForeignKey("Basket")]
        // public virtual Basket Bas { get; set; }
        //private List<Product> smartbask = new List<Product>();
        //public List<Product> Smartbask
        //{
        //    get { return smartbask; }
        //    set { smartbask = value; }
        //}


        public Customer() { }
        public Customer(int cid, string cn, string ce, string cpn, string role)
        {
            customerName = cn;
            customerID = cid;
            customerEmail = ce;
            customerPhoneNo = cpn;
            this.role = role;
        }
        //public void addToPurchaseHistory(Product b)
        //{

        //    purchasehistory.Add(b);
        //}
        //public void addtosmartbasket(Product p)
        //{
        //    bas.Itembasket.Add(p);
        //}
        //public override string ToString()
        //{
        //    return $"{customerID},{customerName},{customerEmail},{customerPhoneNo},{role}";
        //}
    }
}
