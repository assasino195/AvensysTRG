using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SmartBasket;
using System.Collections.Generic;

namespace SmartBasket
{
    [TestClass]
    public class UnitTest1
    {
        //Product Product;
        Customer Cus;
        //Basket bask;
        CreatingNewCustomer newcus;
        GenerateSalesReport gensalesreport;

        [TestInitialize]
        public void testinitialize()
        {
            gensalesreport = new GenerateSalesReport();
            Cus = new Customer();
            newcus = new CreatingNewCustomer();
        }
        [TestMethod]
        public void TestMethod1()
        {
            Customer temp = new Customer("1", "n", "lol@gmail.com", "999", "member");
            Assert.IsNotNull(temp, "customer is not null");
        }
        [TestMethod]
        public void testmethod2()
        {
            // Assert.IsInstanceOfType(newcus.createcustomer("10"),typeof(Customer));
            //Assert.IsInstanceOfType(temp, Customer);
            Customer temp = newcus.createcustomer("1", "2", "lol@gmail.com", "999");
            Assert.ReferenceEquals(temp, Cus);
        }
        [TestMethod]
        public void testmethod3()
        {
            bool validemail = newcus.IsValidEmail("lol");
            Assert.IsFalse(validemail);
        }
        [TestMethod]
        public void testmethod4()
        {
            bool validemail = newcus.IsValidEmail("oo@gmail.com");
            Assert.IsTrue(validemail);
        }
        [TestMethod]
        public void testmethod5()
        {
            bool validphoneno = newcus.isvalidphoneno("87639283");
            Assert.IsTrue(validphoneno);
        }
        [TestMethod]
        public void testmethod6()
        {
            bool validphoneno = newcus.isvalidphoneno("94284938");
            Assert.IsTrue(validphoneno);
        }
        [TestMethod]
        public void testmethod7()
        {
            bool validphoneno = newcus.isvalidphoneno("79381731");
            Assert.IsFalse(validphoneno);
        }
        [TestMethod]
        public void testmethod8()
        {
            // Dictionary<"1",Customer > tempdic = new Dictionary<"1", Customer>();
            Dictionary<string, Customer> tempdic = new Dictionary<string, Customer>();
            tempdic.Add("1", new Customer("1", "jane", "lol@hotmail.com", "98765432", "member"));
            Basket b = new Basket();
            b.addtocart(new Product("1", "avacado", 10, 1.5, "fruit"));
            tempdic["1"].addtosmartbasket(new Product("1", "avacado", 10, 1.5, "fruit"));
            //tempdic["1"].bas.addtocart(b)
            //tempdic[1].PurchaseHistory.Add(b)
            tempdic["1"].bas.isCheckedOut = true;
            tempdic["1"].PurchaseHistory.Add(tempdic["1"].bas.Itembasket[0]);
            // List<string> temp= new System.Collections.Generic.List<string>();
            // temp.Add($"1, jane, lol@hotmail.com", "98765432", "member")
            List<string> generated = gensalesreport.generatesalesreport(tempdic);
            string a = generated[0];
            string tem = $"ID: { 1}\tavacado\twas sold { 10}\ttimes at { 1.5}";

            Assert.AreEqual(a, tem);
        }
        [TestMethod]
        public void testmethod9()
        {
            Product p = new Product("1", "avacado", 10, 1.5, "fruit");
            Assert.IsInstanceOfType(p, typeof(Product));
        }
        [TestMethod]
        public void testmethod10()
        {
            Product p = new Product("1", "avacado", 10, 1, "fruit");
            Basket b = new Basket();
            b.addtocart(p);
            // b.Itembasket.Add(p);
            double result = b.calculatetotal();
            double difference = Math.Abs(result - 10.7);
            Assert.IsTrue(difference < 0.001);
        }
        [TestMethod]
        public void testmethod11()
        {
            Product p = new Product("1", "avacado", 10, 1, "fruit");
            CreatingNewProduct newprod = new CreatingNewProduct();
            Product b = newprod.AddingNewProduct("1", "avacado", 10, 1, "fruit");
            Assert.IsInstanceOfType(b, typeof(Product));
        }
        [TestMethod]
        public void testmethod12()
        {
            Dictionary<string, Product> tempdic = new Dictionary<string, Product>();

            Product p = new Product("1", "avacado", 10, 1, "fruit");
            tempdic.Add("1", p);
            Product d = new Product(tempdic, "1", 10);
            Assert.ReferenceEquals(p, d);

        }
        [TestMethod]
        public void testmethod13()
        {
            Dictionary<string, Customer> cusdic = new Dictionary<string, Customer>();
            Customer p = new Customer();
            cusdic.Add("1", p);
            WritingToTextFile write = new WritingToTextFile();
            string result = write.writingToCustomerTxt(cusdic);
            Assert.AreEqual(result, "Completed writing to customerdict.txt");

        }
        [TestMethod]
        public void testmethod14()
        {
            Dictionary<string, Product> invendic = new Dictionary<string, Product>();
            Product p = new Product("1", "avacado", 10, 1, "fruit");
            invendic.Add("1", p);
            WritingToTextFile write = new WritingToTextFile();
            string result = write.writingToInventoryTxt(invendic);
            Assert.AreEqual(result, "Completed writing to inventory.txt");

        }
        
        
        [TestMethod]
        public void testmethod16()
        {
            Dictionary<string, Customer> cusdic = new Dictionary<string, Customer>();
            Customer cus = new Customer("1", "mar", "lol@hotmail.com", "98765432", "member");
            Product p = new Product("1", "avacado", 10, 1, "fruit");
            cusdic.Add("1", cus);
            //cusdic["1"].bas.addtocart(p);
            cusdic["1"].addToPurchaseHistory(p);
            WritingToTextFile write = new WritingToTextFile();
            string result = write.WritingToPurchaseHistory(cusdic);
            Assert.AreEqual(result, "completed writing to purchasehistory.txt");

        }
        [TestMethod]
        public void testmethod17()
        {
            selectingProducts selectprod = new selectingProducts();
            Dictionary<string, Product> invendic = new Dictionary<string, Product>();
            Product p = new Product("1", "avacado", 10, 1, "fruit");
            string t = $"{"1"}. {"avacado"}\t Price is: ${string.Format("{0:N2}", 1)}\t " +
                           $"In stock: {10}";
            invendic.Add("1", p);
            List<string> tem=selectprod.displayproducts(invendic, "fruit");
            Assert.AreEqual(tem[0], t);
        }
        [TestMethod]
        public void testmethod18()
        {
            selectingProducts selectprod = new selectingProducts();
           
            Dictionary<string, Product> invendic = new Dictionary<string, Product>();
            Product p = new Product("1", "avacado", 10, 1, "fruit");
           
            invendic.Add("1", p);
            
            Product check= selectprod.ShopForProduct(invendic, "1", 10);
            Assert.AreEqual(p,check);
        }
        [TestMethod]
        public void testmethod19()
        {
            Customer c = new Customer();
            Assert.IsInstanceOfType(c, typeof(Customer));

        }
        [TestMethod]
        public void testmethod21()
        {
            initialize init = new initialize();
            Dictionary<string, Product> cusdic = init.retrieveInventory();

            Assert.IsInstanceOfType(cusdic["1"], typeof(Product));
        }
        [TestMethod]
        public void testmethod22()
        {
            initialize init = new initialize();
            Dictionary<string, Product> cusdic = init.retrieveInventory();

            Assert.IsNotNull(cusdic["1"]);
        }
        
        [TestMethod]
        public void testmethod24()
        {
            Customer p = new Customer("1", "mary", "lol@hotmail.com", "98765432", "member");
            string result = p.ToString();
            string correctresult= $"{1},{"mary"},{"lol@hotmail.com"},{"98765432"},{"member"}";

            Assert.AreEqual(result, correctresult);
        }
        [TestMethod]
        public void testmethod25()
        {
            //Customer p = new Customer("1", "mary", "lol@hotmail.com", "6542341", "member");
            CreatingNewCustomer create = new CreatingNewCustomer();
            Customer p= create.createcustomer("1", "mary", "lol@hotmail.com", "6542341");

            Assert.IsNull(p);
        }
        [TestMethod]
        public void testmethod26()
        {
            //Customer p = new Customer("1", "mary", "lol@hotmail.com", "6542341", "member");
            CreatingNewCustomer create = new CreatingNewCustomer();
            Customer p = create.createcustomer("1", "mary", "lol@hotmail.com", "65242341");

            Assert.IsNull(p);
        }
        [TestMethod]
        public void testmethod27()
        {
            //Customer p = new Customer("1", "mary", "lol@hotmail.com", "6542341", "member");
            CreatingNewCustomer create = new CreatingNewCustomer();
            Customer p = create.createcustomer("1", "mary", "lol", "95242341");

            Assert.IsNull(p);
        }
        [TestMethod]
        public void testmethod28()
        {
            //Customer p = new Customer("1", "mary", "lol@hotmail.com", "6542341", "member");
            CreatingNewCustomer create = new CreatingNewCustomer();
            Customer p = create.createcustomer("1", "mary", "lol@hotmail.com", "98765432");

            Assert.IsInstanceOfType(p,typeof(Customer));
        }
        [TestMethod]
        public void testmethod29()
        {
            initialize init = new initialize();
            GenerateSalesReport gensales = new GenerateSalesReport();
            Dictionary<string, Customer> cusdic = init.retrievecus();
            List<string> a = gensales.generatesalesreport(cusdic);
            
            string result = a[4];
            string correct = $"ID: { 3}\tSpinach\twas sold { 9}\ttimes at { 3.3}";

            Assert.AreEqual(result, correct);


        }
        [TestMethod]
        public void testmethod30()
        {
            CreatingNewCustomer create = new CreatingNewCustomer();
            
            Dictionary<string, Customer> cusdic = new Dictionary<string, Customer>();
            Customer p = create.createcustomer("1", "mary", "lol@hotmail.com", "98765432");
            cusdic.Add("1", p);
            Product prod= new Product("1", "avacado", 10, 1, "fruit");
            cusdic["1"].addToPurchaseHistory(prod);
            cusdic["1"].addToPurchaseHistory(prod);
            //cusdic["1"].addToPurchaseHistory(prod);
            GenerateSalesReport gensales = new GenerateSalesReport();
            
            List<string>a=gensales.generatesalesreport(cusdic);


            string actualresult = $"ID: {"1"}\t{"avacado"}\twas sold {"20"}\ttimes at {"1"}";



            Assert.AreEqual(a[0], actualresult);


        }
        [TestMethod]
        public void testmethod31()
        {
            initialize init = new initialize();
            
            Dictionary<string, Customer> cusdic = init.retrievecus();
            List<Product> a = cusdic["1"].PurchaseHistory;
            Customer cus = cusdic["1"];
            cus.PurchaseHistory = cusdic["1"].PurchaseHistory;

            Assert.IsNotNull(cus.PurchaseHistory);


        }
        [TestMethod]
        public void testmethod32()
        {
            Product prod = new Product("1", "avacado", 10, 1, "fruit");
            string result = prod.ToString();
            string actualresult = $"{1},{"avacado"},{"fruit"},{"10"},{"1"}";
            Assert.AreEqual(result, actualresult);

        }
        [TestMethod]
        public void testmethod33()
        {
            Customer temp = new Customer("1", "n", "lol@gmail.com", "999", "member");
            List<string> stringy = new List<string>();
            stringy.Add("hi");
            Product prod = new Product("1", "avacado", 10, 1, "fruit");
            temp.addtosmartbasket(prod);
            List<Product> plist = new List<Product>();
            plist.Add(prod);
            List<Basket> bask = new List<Basket>();
            temp.PurchaseHistory = plist;

            Assert.AreEqual(temp.PurchaseHistory[0], plist[0]);


        }
        [TestMethod]
        public void testmethod34()
        {
            Basket b = new Basket();
            b.isCheckedOut = true;
            Assert.IsTrue(b.isCheckedOut);
        }

        [TestMethod]
        public void testmethod35()
        {
            Basket b = new Basket();
            b.isCheckedOut = false;
            Assert.IsFalse(b.isCheckedOut);
        }
        [TestMethod]
        public void testmethod36()
        {
            Basket b = new Basket(false);
            
            Assert.IsFalse(b.isCheckedOut);
        }
        [TestMethod]
        public void testmethod37()
        {
            Basket b = new Basket(true);
            
            Assert.IsTrue(b.isCheckedOut);
        }
        [TestMethod]
        public void testmethod38()
        {
            selectingProducts selectprod = new selectingProducts();
            Dictionary<string, Product> proddict = new Dictionary<string, Product>();
            proddict.Add("1", new Product("1", "avacado", 10, 1, "Vegetables"));
            proddict.Add("2", new Product("1", "bavacado", 10, 1, "Vegetables"));
            Product result=selectprod.Removefrombasket(proddict, "1");
            Assert.IsInstanceOfType(result, typeof(Product));
        }
       
        [TestMethod]
        public void testmethod90()
        {
            initialize init = new initialize();
            Dictionary<string, Customer> cusdic = init.retrievecus();

            Assert.IsInstanceOfType(cusdic["1"], typeof(Customer));
        }
        [TestMethod]
        public void testmethod91()
        {
            initialize init = new initialize();
            Dictionary<string, Customer> cusdic = init.retrievecus();

            Assert.IsInstanceOfType(cusdic["1"],typeof(Customer));
        }
        [TestMethod]
        public void testmethod93()
        {
            initialize init = new initialize();
            Dictionary<string, Customer> cusdic = init.retrievecus();
            
            Assert.IsNotNull(cusdic["1"].bas.Itembasket);
        }
        [TestMethod]
        public void testmethod95()
        {
            Dictionary<string, Customer> cusdic = new Dictionary<string, Customer>();
            Customer cus = new Customer("1", "mar", "lol@hotmail.com", "98765432", "member");
            Customer cus1 = new Customer("2", "mar", "lol@hotmail.com", "98765432", "member");
            Product p = new Product("1", "avacado", 10, 1, "fruit");
            cusdic.Add("1", cus);
            cusdic.Add("2", cus1);
            cusdic["1"].bas.addtocart(p);
            Product p1 = new Product("1", "avacado", 20, 1, "fruit");
            cusdic["1"].bas.isCheckedOut = false;
            cusdic["1"].bas.Itembasket.Add(p1);
            cusdic["1"].bas.Itembasket.Add(p1);
            cusdic["1"].bas.Itembasket.Add(p1);
            cusdic["2"].bas.Itembasket.Add(p1);
            WritingToTextFile write = new WritingToTextFile();
            write.writingToSmartBasketTxt(cusdic);
            string result = write.writingToSmartBasketTxt(cusdic);
            
            Assert.AreEqual(result, "completed writing to smartbasket.txt");
            //Assert.IsNotNull(cusdic["1"]);

        }
        [TestMethod]
        public void testmethod96()
        {
            initialize init = new initialize();
            init.retrievecus();
        }

        [TestMethod]
        public void testmethod97()
        {
            initialize init = new initialize();
            init.retrievecategories();
        }
        [TestMethod]
        public void testmethod98()
        {
            Program p = new Program();
            
        }

    }
}
