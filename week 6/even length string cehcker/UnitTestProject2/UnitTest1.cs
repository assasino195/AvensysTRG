using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace even_length_string_cehcker
{
    
    [TestClass]
    public class UnitTest1
    {
        Mock<checkerclass> programmock;
        [TestInitialize]
        public void initialize()
        {
            programmock = new Mock<checkerclass>(MockBehavior.Default);
            programmock.CallBase = false;
            programmock.Setup(x => x.checker("abcabc")).Returns(true);
        }
        [TestMethod]
        public void TestMethod1()
        {
            checkerclass p = new checkerclass();
            Program.chck.checker("abcabc");
            var result = p.checker("abcabc");
            Assert.IsTrue(result);
        }
        [TestMethod]
        
       
        //[DataRow("tes1tes")]
        //[DataRow("aabbcc")]
        //[DataRow("abccba")]
        //[DataRow(null)]
        //[DataRow("")]
        //public void Testmethod2(string input)
        //{
        //    Program p = new Program();
        //    var result = p.checker(input);
        //    Assert.IsFalse(result);
        //}

    }
}
