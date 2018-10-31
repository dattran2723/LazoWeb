using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LazoWeb.Models
{
    public class LazoDbContext : DbContext
    {
        public LazoDbContext () : base("DefaultConnection") { }

        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}