using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class psuedoproduct
    {
        [Key]
        public int psuedoproductkey { get; set; }

        public int productid { get; set; }
        public int count { get; set; }
        public bool ischeckedout { get; set; }
        public DateTime dt { get; set; }
    }
}