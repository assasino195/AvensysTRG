using System.Collections.Generic;

namespace SmartBasket
{
    public class Customer
    {
        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
      
        public string customerID { get; set; }
        public string role { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNo { get; set; }
        private Basket bas = new Basket();
        public Basket Bas { get { return bas; } set { bas = value; } }
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
        public Customer() { }
        public Customer(string cid,string cn,string ce,string cpn,string role)
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
        public override string ToString()
        {
            return $"{customerID},{customerName},{customerEmail},{customerPhoneNo},{role}";
        }
    }
}
