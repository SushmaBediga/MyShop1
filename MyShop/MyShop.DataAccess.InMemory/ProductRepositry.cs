using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class ProductRepositry
    {
        ObjectCache cache=  MemoryCache.Default;
        List<Product> Products;
        public ProductRepositry()
        {
            Products = cache["products"] as List<Product>;
            if(Products ==null)
            {
                Products = new List<Product>();

            }
        }
        public void Commit()  //similar to save in helloworld
        {
            cache["products"] = Products;
        }

        public void Insert(Product p)
        {
            Products.Add(p);
        }
        public void Update(Product product)
        {
            Product productToUpdate = Products.Find(p => p.Id == product.Id);
            if(productToUpdate!=null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }
        public Product Find(string Id)
        {
            Product product = Products.Find(p => p.Id == Id);
            if(product!= null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public IQueryable<Product>collection()  //Iquerable returns the List
        {
            return Products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = Products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
