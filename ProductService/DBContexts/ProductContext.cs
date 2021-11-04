using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.DBContexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }

        public ProductContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    ID=1,
                    Name="Watches",
                    Description="Brand watches",
                },
                new Category
                {
                    ID=2,
                    Name="Laptops",
                    Description="Gaming laptops"
                },
                new Category
                {
                    ID=3,
                    Name="Smartphones",
                    Description="iPhones and Galaxies"
                }
            );
        }


    }
}
