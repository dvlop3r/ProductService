using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;
using ProductService.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;
        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        public void DeleteProduct(int productID)
        {
            productContext.Products.Remove(productContext.Products.Find(productID));
            Save();
        }

        public Product GetProductByID(int productID)
        {
            return productContext.Products.Find(productID);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            productContext.Add(product);
            Save();
        }

        public void Save()
        {
            productContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            productContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
