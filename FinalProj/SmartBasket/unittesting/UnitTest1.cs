using System;
using Xunit;
using WebAPI.Interface;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;

namespace unittesting
{
    public class UnitTest1
    {
        
        [Fact]
        public void LoginSuccessfully()
        {
            Customer c = new Customer() { customerName = "john", customerID = 1, customerEmail = "lol@hotmail.com", customerPhoneNo = "12345678", role = "customer" };
            var data = new List<Customer>
            {
               c
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockSet.Object);

            AccountController ac = new AccountController(mockContext.Object);
            IHttpActionResult res = ac.loginfunc(1);
           
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(c, contentResult.Content);
        }
        [Fact]
        public void LoginFailed()
        {
            Customer c = new Customer() { customerName = "john", customerID = 1, customerEmail = "lol@hotmail.com", customerPhoneNo = "12345678", role = "customer" };
            var data = new List<Customer>
            {
               c
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockSet.Object);

            AccountController ac = new AccountController(mockContext.Object);
            IHttpActionResult res = ac.loginfunc(2);

            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Null( contentResult.Content);
        }
         [Fact]
        public void SuccessfullCreatCustomer()
        {
            Customer c = new Customer() { customerName = "john", customerID = 1, customerEmail = "lol@hotmail.com", customerPhoneNo = "12345678", role = "customer" };
            var data = new List<Customer>
            {
               
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockSet.Object);

            AccountController ac = new AccountController(mockContext.Object);
            IHttpActionResult res = ac.createcustomer(c);

            var contentResult = res as OkNegotiatedContentResult<string>;
           // mockContext.Verify(m => m.SaveChanges(), Times.Never());
            Assert.Equal("Customer Created", contentResult.Content);
        }
        [Fact]
        public void UnsuccessfulCreationOfCustomer()
        {
            Customer c = new Customer() { customerName = "john", customerID = 1, customerEmail = "lol@hotmail.com", customerPhoneNo = "12345678", role = "customer" };
            var data = new List<Customer>
            {
               c
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockSet.Object);

            AccountController ac = new AccountController(mockContext.Object);
            
            IHttpActionResult res = ac.createcustomer(c);


            Assert.IsType<BadRequestErrorMessageResult>(res);
            //Assert.Equal("Customer ID already exist", contentResult.Content);
        }

        [Fact]
        public void SuccessfullCreateProduct()
        {
            Product c = new Product() { productID = 1 };
            var data = new List<Product>
            {
               
            }.AsQueryable();
            

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.products).Returns(mockSet.Object);

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.AddingNewProduct(c);

            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.Equal("Product Created", contentResult.Content);
        }
        [Fact]
        public void UnsuccessfulCreationOfProduct()
        {
            Product c = new Product() { productID = 1 };
            var data = new List<Product>
            {
                c
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.products).Returns(mockSet.Object);

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.AddingNewProduct(c);

            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }
        [Fact]
        public void SuccesfulGenerateSalesReport()
        {
            Product prod1 = new Product() { productID = 1,productPrice=0.5 ,ProductName="brocoli",productCategory="Vegetable",dtadded=DateTime.UtcNow};
            psuedoproduct p = new psuedoproduct() { count = 5, ischeckedout = true, productid = 1,dt=DateTime.UtcNow,psuedoproductkey=1 };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(p);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };
            Customer cus2 = new Customer() { customerID = 2, psueoproducts = plist };
            var data = new List<Customer>
            {
                cus,
                cus2
            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1
            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);
          

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.generatesalesreport();

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            List<string> expectedtemp = new List<string>();
            expectedtemp.Add($"Product ID:{1} {"brocoli"} quantity {10} at a price of {0.5}");
            expectedtemp.Add("Total price of all products is: $" +"5");
            Assert.Equal(expectedtemp, contentResult.Content);

        }
        [Fact]
        public void unsuccesfulGenerateSalesReport()
        {
           
            var data = new List<Customer>
            {
            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.generatesalesreport();

           
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }

        [Fact]
        public void successfulReturnCustomerList()
        {
            Customer c = new Customer() { customerName = "john", customerID = 1, customerEmail = "lol@hotmail.com", customerPhoneNo = "12345678", role = "customer" };
            Customer c1 = new Customer() { customerName = "john", customerID = 2, customerEmail = "lol@hotmail.com", customerPhoneNo = "12345678", role = "customer" };
           
            var data = new List<Customer>
            {
                c,
                c1,
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockSet.Object);

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewallacc();

            var contentResult = res as OkNegotiatedContentResult<List<Customer>>;
            // mockContext.Verify(m => m.SaveChanges(), Times.Never());
            List<Customer> assertcustlist = new List<Customer>();
            assertcustlist.Add(c);
            assertcustlist.Add(c1);
            
                Assert.Contains(c, contentResult.Content);
            
           
           //Assert.Equal(assertcustlist, contentResult.Content);
        }
        [Fact]
        public void unsuccessfulReturnCustomerList()
        {
            
            var data = new List<Customer>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockSet.Object);

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewallacc();

            var contentResult = res as OkNegotiatedContentResult<List<Customer>>;
            // mockContext.Verify(m => m.SaveChanges(), Times.Never());
            

            Assert.IsType<BadRequestErrorMessageResult>(res);
            
        }

        [Fact]
        public void SuccessfullRemoveProduct()
        {
            Product c = new Product() { productID = 1 };
            var data = new List<Product>
            {
                c
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.products).Returns(mockSet.Object);

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.removeproduct(1);

            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.Equal("Product removed", contentResult.Content);
        }
        [Fact]
        public void UnsuccessfulRemoveProduct()
        {
           
            var data = new List<Product>
            {
                
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.products).Returns(mockSet.Object);

            ManagerServicesController ac = new ManagerServicesController(mockContext.Object);
            IHttpActionResult res = ac.removeproduct(1);

            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }

        [Fact]
        public void succesfulCalculateTotal()
        {
            Product prod1 = new Product() { productID = 1, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productPrice = 2.5, ProductName = "sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            psuedoproduct p = new psuedoproduct() { count = 5, ischeckedout = false, productid = 1, dt = DateTime.UtcNow, psuedoproductkey = 1 };
            psuedoproduct p1 = new psuedoproduct() { count = 10, ischeckedout = false, productid = 2, dt = DateTime.UtcNow, psuedoproductkey = 2 };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(p);
            plist.Add(p1);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };
            
            var data = new List<Customer>
            {
                cus
                
            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2
            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.calculatetotal(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            List<string> expectedtemp = new List<string>();
            expectedtemp.Add($"Product ID: {prod1.productID} {prod1.ProductName} Quantity: {p.count} at a price of ${prod1.productPrice} ");
            expectedtemp.Add($"Product ID: {prod2.productID} {prod2.ProductName} Quantity: {p1.count} at a price of ${prod2.productPrice} ");
           
            expectedtemp.Add($"Total Price of all products is 29.425 inclusive of GST of 1.925");
            Assert.Equal(expectedtemp, contentResult.Content);

        }
        [Fact]
        public void unsuccesfulCalculateTotal()
        {

            var data = new List<Customer>
            {
            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.calculatetotal(1);


            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void unsuccesfulCalculateTotalEmptyBasket()
        {
            Product prod1 = new Product() { productID = 1, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productPrice = 2.5, ProductName = "sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            psuedoproduct p = new psuedoproduct() { count = 5, ischeckedout = true, productid = 1, dt = DateTime.UtcNow, psuedoproductkey = 1 };
            psuedoproduct p1 = new psuedoproduct() { count = 10, ischeckedout = true, productid = 2, dt = DateTime.UtcNow, psuedoproductkey = 2 };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(p);
            plist.Add(p1);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2
            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.calculatetotal(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void unsuccesfulCalculateTotal0Totalprice()
        {
            Product prod1 = new Product() { productID = 1, productPrice = 0, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productPrice = 0, ProductName = "sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            psuedoproduct p = new psuedoproduct() { count = 5, ischeckedout = false, productid = 1, dt = DateTime.UtcNow, psuedoproductkey = 1 };
            psuedoproduct p1 = new psuedoproduct() { count = 10, ischeckedout = false, productid = 2, dt = DateTime.UtcNow, psuedoproductkey = 2 };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(p);
            plist.Add(p1);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2
            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.calculatetotal(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void unsuccesfulCalculateTotalEmptyPsueProductList()
        {
            Product prod1 = new Product() { productID = 1, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productPrice = 2.5, ProductName = "sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            psuedoproduct p = new psuedoproduct() { count = 5, ischeckedout = true, productid = 1, dt = DateTime.UtcNow, psuedoproductkey = 1 };
            psuedoproduct p1 = new psuedoproduct() { count = 10, ischeckedout = true, productid = 2, dt = DateTime.UtcNow, psuedoproductkey = 2 };
            List<psuedoproduct> psuedlist = new List<psuedoproduct>();
            Customer cus = new Customer() { customerID = 1,psueoproducts=psuedlist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2
            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.calculatetotal(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void succesfulAddToBasket()
        {
            Product prod1 = new Product() { productID = 1,productCount=5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            
           
            
            List<psuedoproduct> plist = new List<psuedoproduct>();
          
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1
              
            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.ShopForProduct(1,4,1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);
            Assert.Equal($"{prod1.ProductName} has been added to basket", contentResult.Content);
        }
        [Fact]
        public void succesfulAddToBasketSameItemFound()
        {
            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };

            psuedoproduct psuedo1 = new psuedoproduct() { productid = 1, psuedoproductkey = 1, count = 1, dt = DateTime.UtcNow, ischeckedout = false };

            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.ShopForProduct(1, 2, 1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);
            Assert.Equal("Updated Quantity of product", contentResult.Content);
        }
        [Fact]
        public void unsuccesfulAddToBasketMoreThanStock()
        {
            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.ShopForProduct(1, 6, 1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            Assert.IsType<BadRequestErrorMessageResult>(res);
            
        }
        [Fact]
        public void unsuccesfulAddToBasketInvalidCustomerID()
        {
            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            var data = new List<Customer>
            { 
            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.ShopForProduct(1, 1, 1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void succesfulAddToBasketInvalidProductID()
        {
            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.ShopForProduct(2, 6, 1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void succesfulRemoveProduct()
        {
            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productCount = 5, productPrice = 2.5, ProductName = "Sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };


            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            psuedoproduct psuedo2 = new psuedoproduct() { psuedoproductkey = 2, productid = 2, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            plist.Add(psuedo2);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.Removefrombasket(2,1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);
            Assert.Equal("Item Removed from basket", contentResult.Content);
        }
        [Fact]
        public void unsuccesfulRemoveFromBasketItemNotFound()
        {
           
            

            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
           
            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
          

            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.Removefrombasket(1,1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void unsuccesfulRemoveFromBasketInvalidCustomerID()
        {
            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
           


          
            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
           

            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.Removefrombasket(1, 2);

            var contentResult = res as OkNegotiatedContentResult<string>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

        }
        [Fact]
        public void succesfulViewBasket()
        {


            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productCount = 5, productPrice = 2.5, ProductName = "Sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };


            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            psuedoproduct psuedo2 = new psuedoproduct() { psuedoproductkey = 2, productid = 2, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            plist.Add(psuedo2);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewbasket( 1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);
           
            //Assert.IsType<BadRequestErrorMessageResult>(res);
            List<string> assertstring = new List<string>();
            assertstring.Add($"product ID:{prod1.productID} {prod1.ProductName} Quantity: {psuedo1.count} at price of ${prod1.productPrice}");
            assertstring.Add($"product ID:{prod2.productID} {prod2.ProductName} Quantity: {psuedo2.count} at price of ${prod2.productPrice}");
            Assert.Equal(assertstring, contentResult.Content);
        }
        [Fact]
        public void unsuccesfulViewBasketEmptyBasket()
        {


            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productCount = 5, productPrice = 2.5, ProductName = "Sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };


            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = true };
            psuedoproduct psuedo2 = new psuedoproduct() { psuedoproductkey = 2, productid = 2, count = 2, dt = DateTime.UtcNow, ischeckedout = true };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            plist.Add(psuedo2);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewbasket(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);

          
        }
        [Fact]
        public void unsuccesfulViewBasketEmptyPsuedoList()
        {


           
            List<psuedoproduct> plist = new List<psuedoproduct>();
          
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
           
            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewbasket(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void unsuccesfulViewBasketInvalidID()
        {



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);



            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewbasket(2);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void succesfulCheckingOut()
        {


            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productCount = 5, productPrice = 2.5, ProductName = "Sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };


            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            psuedoproduct psuedo2 = new psuedoproduct() { psuedoproductkey = 2, productid = 2, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            plist.Add(psuedo2);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.checkingout(1);

            var contentResult = res as OkNegotiatedContentResult<string>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);

            //Assert.IsType<BadRequestErrorMessageResult>(res);
           
            Assert.Equal("sucessfully checkedout", contentResult.Content);
        }
        [Fact]
        public void unsuccesfulCheckingOutEmptyBasket()
        {


            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productCount = 5, productPrice = 2.5, ProductName = "Sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };


            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = true };
            psuedoproduct psuedo2 = new psuedoproduct() { psuedoproductkey = 2, productid = 2, count = 2, dt = DateTime.UtcNow, ischeckedout = true };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            plist.Add(psuedo2);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1,
                prod2

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.checkingout(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void unsuccesfulCheckingOutEmptyPsuedoList()
        {



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);



            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.checkingout(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void unsuccesfulCheckOutInvalidID()
        {



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);



            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.checkingout(2);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void succesfulViewPurchaseHistory()
        {


            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
           

            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = true };
            
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);

            Customer cus = new Customer() { isCheckedOut = true,customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            var products = new List<Product>
            {
                prod1

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewpurchasehist(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);

            //Assert.IsType<BadRequestErrorMessageResult>(res);
            List<string> asserttrue = new List<string>();
            asserttrue.Add($"Product ID:{prod1.productID} {prod1.ProductName} Quantity:{psuedo1.count} purchased on {psuedo1.dt}");
            Assert.Equal(asserttrue, contentResult.Content);
        }
        [Fact]
        public void unsuccesfulViewPurchaseHistorytEmptyList()
        {
            psuedoproduct psuedo1 = new psuedoproduct() { psuedoproductkey = 1, productid = 1, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            psuedoproduct psuedo2 = new psuedoproduct() { psuedoproductkey = 2, productid = 2, count = 2, dt = DateTime.UtcNow, ischeckedout = false };
            List<psuedoproduct> plist = new List<psuedoproduct>();
            plist.Add(psuedo1);
            plist.Add(psuedo2);
            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
          

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);
          

            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewpurchasehist(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void unsuccesfulViewPurchaseHistoryEmptyPurchaseHistory()
        {



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);



            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewpurchasehist(1);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void unsuccesfulViewPurchaseHistoryInvalidID()
        {



            List<psuedoproduct> plist = new List<psuedoproduct>();

            Customer cus = new Customer() { customerID = 1, psueoproducts = plist };

            var data = new List<Customer>
            {
                cus

            }.AsQueryable();


            var mockCustomerSet = new Mock<DbSet<Customer>>();
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockCustomerSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
            mockContext.Setup(x => x.customers).Returns(mockCustomerSet.Object);



            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewpurchasehist(2);

            var contentResult = res as OkNegotiatedContentResult<List<string>>;
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
        [Fact]
        public void succesfulViewProducts()
        {


            Product prod1 = new Product() { productID = 1, productCount = 5, productPrice = 0.5, ProductName = "brocoli", productCategory = "Vegetable", dtadded = DateTime.UtcNow };
            Product prod2 = new Product() { productID = 2, productCount = 15, productPrice = 1.5, ProductName = "sprouts", productCategory = "Vegetable", dtadded = DateTime.UtcNow };



            var products = new List<Product>
            {
                prod1,
                prod2

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();
           
            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewproducts();

            var contentResult = res as OkNegotiatedContentResult<List<Product>>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);

            //Assert.IsType<BadRequestErrorMessageResult>(res);
            List<Product> asserttrue = new List<Product>();
            asserttrue.Add(prod1);
            asserttrue.Add(prod2);
            Assert.Equal(asserttrue, contentResult.Content);
        }
        [Fact]
        public void unsuccesfulViewProducts()
        {
            


            var products = new List<Product>
            {
               

            }.AsQueryable();


            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(products.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(products.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(products.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<DictionaryContext>();

            mockContext.Setup(x => x.products).Returns(mockProductSet.Object);


            BasketServicesController ac = new BasketServicesController(mockContext.Object);
            IHttpActionResult res = ac.viewproducts();

            var contentResult = res as OkNegotiatedContentResult<string>;
            //Assert.IsType<BadRequestErrorMessageResult>(res);

            //Assert.IsType<BadRequestErrorMessageResult>(res);
            
            
            Assert.IsType<BadRequestErrorMessageResult>(res);


        }
    }
}
