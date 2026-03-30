using Microsoft.AspNetCore.Mvc;
using HandsOnMVCModels.Models;
using System.Collections.Generic;

namespace HandsOnMVCModels.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Initializing a list of products
            List<Product> products = new List<Product>()
            {
                new Product(){ProductId=23, Name="Mouse", Price=500, Description="E-I"},
                new Product(){ProductId=22, Name="Keyboard", Price=800, Description="I"},
                new Product(){ProductId=29, Name="Headset", Price=1500, Description="I"},
                new Product(){ProductId=26, Name="Earbuds", Price=2500, Description="I"}
            };

            // Passing the entire list as the Model to the View
            return View(products);
        }

        public IActionResult Details()
        {
            Product product = new Product()
            {
                ProductId = 33,
                Name = "Laptop",
                Price = 56000,
                Description = "Electronic Gadget"
            };
            return View(product);
        }
    }
}