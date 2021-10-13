using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using even_length_string_cehcker;
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
        [DataRow("abcabc")]
        [DataRow("testes")]
        [DataRow("tes1tes")]
        [DataRow("aabbcc")]
        [DataRow("abccba")]
        public void Testmethod2()
        {
            
        }

    }
}
