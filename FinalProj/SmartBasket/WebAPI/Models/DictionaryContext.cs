using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class DictionaryContext : DbContext
    {
        public DictionaryContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Customer>().HasMany(s => s.products);
            //modelBuilder.Entity<purchasehist>().HasMany(s => s.PurchaseHistory);
        }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Customer> customers { get; set; }
       // public virtual DbSet<psuedoproduct> psuedoproducts { get; set; }
        
        
       // public virtual DbSet<Basket> baskets { get; set; }
        //public virtual DbSet<purchasehist> purchasehistorys { get; set; }
        //public virtual DbSet<string> catDict { get; set; }

    }
}