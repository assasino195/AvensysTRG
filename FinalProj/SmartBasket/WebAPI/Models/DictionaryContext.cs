using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebAPI.Models;
using WebAPI.Interface;


namespace WebAPI.Models
{
    public class DictionaryContext : DbContext,iContext
    {
        public DictionaryContext() : base(@"Data Source=DESKTOP-URQND8D\SQLEXPRESS;Initial Catalog=SmartBasketDB;Integrated Security=True") 
        {

        }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Customer> customers { get; set; }
    }
}