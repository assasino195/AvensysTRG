using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class Customer
    {
        public string customerName { get; set; }
        public string customerID { get; set; }
        public string role { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNo { get; set; }
        public Basket bas = new Basket();
        //private List<Product> smartbask = new List<Product>();
        //public List<Product> Smartbask
        //{
        //    get { return smartbask; }
        //    set { smartbask = value; }
        //}
       
        private List<Product> purchasehistory = new List<Product>();
        public List<Product> PurchaseHistory
        {
            get { return purchasehistory; }
            set { purchasehistory = value; }
        }
        public Customer(string cid,string cn,string ce,string cpn,string role)
        {
            customerName = cn;
            customerID = cid;
            customerEmail = ce;
            customerPhoneNo = cpn;
            this.role = role;
        }
        public void addToPurchaseHistory(Product b)
        {
            
            purchasehistory.Add(b);
        }
        public void addtosmartbasket(Product p)
        {
            bas.Itembasket.Add(p);
        }
        public override string ToString()
        {
            return $"{customerID},{customerName},{customerEmail},{customerPhoneNo},{role}";
        }
    }
}
