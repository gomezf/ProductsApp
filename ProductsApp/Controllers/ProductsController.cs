using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        private static List<Product> products = new List<Product>();

        private  ProductsController()
        {            
            if (products.Count == 0)
            {                
                {
                    products.Add(new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 });
                    products.Add(new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 });
                    products.Add(new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M });
                    //new Product { Id = 1, Name="Tomato Soup", Category = "Groceries", Price = 1 },
                    //new Product { Id = 2, Name="Yo-yo", Category = "Toys", Price = 3.75M },
                    //new Product { Id = 3, Name="Hammer", Category = "Hardware", Price = 16.99M }
                };
            }
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        public IHttpActionResult PostProducts()
        {   var newId = products.Count + 1;
            products.Add(new Product { Id = newId, Name = "TestName" + newId, Category = "Test", Price = 1.1M + 1 });
            return Ok(products);
        }
    }
}
