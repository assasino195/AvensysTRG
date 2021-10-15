using System;
using Xunit;
using valid_string_check_string;


namespace valid_string_check_string
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Program p = new Program();
            p.checkforvalid("{[]}");
            bool res = p.checkforvalid("{[]}");
            Assert.True(res);
        }
    }
}
