using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;

namespace GummyBearKingdom.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepo = new EFProductRepository();
        public IActionResult Index()
        {
            List<Product> topThreeProducts = productRepo.Products.OrderByDescending(x => x.ProductId).Take(3).ToList();
            return View(topThreeProducts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
