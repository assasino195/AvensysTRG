using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class ConsoleIO
    {
       
        public void displayprods(List<ProductDTO> prodlist)
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
        public ProductDTO addprod(string prodname,int count,double price,string cat)
        {
            ProductDTO p = new ProductDTO() {ProductName=prodname,productCategory=cat,productCount=count,productPrice=price,dtadded=DateTime.UtcNow };
            return p;
        }
        public void displaysalesreport(List<string> salesreport)
        {
            foreach(string s in salesreport)
            {
                Console.WriteLine(s);
            }
        }
       public CustomerDTO creatingnewcustomer(string name,string email,string phoneno)
        {

            CustomerDTO c = new CustomerDTO() { customerName = name, customerEmail = email, customerPhoneNo = phoneno, role = "customer", isCheckedOut = true, };
            return c;
        }
        public void viewallcustomers(List<CustomerDTO> cuslist)
        {
            foreach (var cus in cuslist)
            {
                Console.WriteLine($"ID: {cus.customerID}\tName: {cus.customerName}\tEmail: {cus.customerEmail}\tPhone No: {cus.customerPhoneNo}\tRole:{cus.role}");
            }
        }
        public void viewproduct(ProductDTO prod)
        {
            Console.WriteLine($"ID: {prod.productID} {prod.ProductName} {prod.productCategory} Quantity: {prod.productCount} Price: ${prod.productPrice}");
        }

        private Product prodDTO2Prod(ProductDTO p)
        {
            Product temp = new Product(p);
            return temp;
        }

        private ProductDTO prod2DTOProd(Product p)
        {
            ProductDTO temp = new ProductDTO(p);
            return temp;
        }
        public Customer DTO2Customer(CustomerDTO cDTO)
        {
            Customer c = new Customer()
            {
                customerName = cDTO.customerName,
                customerEmail = cDTO.customerEmail,
                customerID = cDTO.customerID,
                customerPhoneNo = cDTO.customerPhoneNo,
                isCheckedOut = cDTO.isCheckedOut,
                psueoproducts = cDTO.psueoproducts,
                role = cDTO.role
            };
            return c;
        }
        public CustomerDTO Customer2DTO(Customer cDTO)
        {
            CustomerDTO c = new CustomerDTO(cDTO) { };
            return c;
        }
    }
}
