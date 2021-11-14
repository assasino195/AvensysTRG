using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class ConsoleIO
    {
        public void displayprods(List<Product> prodlist)
        {
            foreach (var prod in prodlist)
            {
                Console.WriteLine($"{prod.productID} {prod.ProductName} {prod.productCategory} {prod.productCount} ${prod.productPrice}");
            }
        }
        public void viewbasket(List<string> prodlist)
        {
            foreach (var prod in prodlist)
            {
                Console.WriteLine(prod);
            }
        }
        public void calculatetotal(List<string> pricelist)
        {
            Console.WriteLine(pricelist[pricelist.Count-1]);
            //foreach (var prod in pricelist)
            //{
            //    Console.WriteLine(prod);
            //}


        }
        public void displaypurchasehist(List<string> purchasehist)
        {
            foreach(string s in purchasehist)
            {
                Console.WriteLine(s);
            }
        }
        public Product addprod(string prodname,int count,double price,string cat)
        {
            Product p = new Product() {ProductName=prodname,productCategory=cat,productCount=count,productPrice=price,dtadded=DateTime.UtcNow };
            return p;
        }
        public void displaysalesreport(List<string> salesreport)
        {
            foreach(string s in salesreport)
            {
                Console.WriteLine(s);
            }
        }
       public Customer creatingnewcustomer(string name,string email,string phoneno)
        {
            Customer c = new Customer() { customerName = name, customerEmail = email, customerPhoneNo = phoneno, role = "customer", isCheckedOut = true, };
            return c;
        }
        public void viewallcustomers(List<Customer> cuslist)
        {
            foreach (var cus in cuslist)
            {
                Console.WriteLine($"ID: {cus.customerID}\tName: {cus.customerName}\tEmail: {cus.customerEmail}\tPhone No: {cus.customerPhoneNo}");
            }
        }
    }
}
