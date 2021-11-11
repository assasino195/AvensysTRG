using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Basket
    {
        //[Key]
        //[ForeignKey("Customer")]
        //public string basketid { get; set; }

        //public bool isCheckedOut { get; set; }

        public virtual List<Product> products { get; set; }

        //public virtual Customer customer { get; set; }


        // public Basket() { }
        //public Basket(bool checkedout)
        // {
        //     isCheckedOut = checkedout;
        // }
        //public void addtocart(Product p)
        //{
        //    itembasket.Add(p);
        //}


    }
}
