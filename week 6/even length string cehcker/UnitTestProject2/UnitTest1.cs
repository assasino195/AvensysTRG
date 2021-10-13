using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace even_length_string_cehcker
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Program();
            var result = p.checker("abcdef");
        }
        [TestMethod]
        
       
        [DataRow("tes1tes")]
        [DataRow("aabbcc")]
        [DataRow("abccba")]
        [DataRow(null)]
        [DataRow("")]
        public void Testmethod2(string input)
        {
            Program p = new Program();
            var result = p.checker(input);
            Assert.IsFalse(result);
        }

    }
}
