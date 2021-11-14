using System;


namespace SmartBasket
{
    public class psuedoproduct
    {
       
        public int psuedoproductkey { get; set; }

        public int productid { get; set; }
        public int count { get; set; }
        public bool ischeckedout { get; set; }
        public DateTime dt { get; set; }
    }
}