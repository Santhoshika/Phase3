using Laptopseller.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptopseller.Controllers
{
    public class LaptopController : Controller
    {
        ApplicationDBContext db = new ApplicationDBContext();
        // GET: LaptopController
        public IActionResult Index()
        {
            var id = db.Laptops.ToList();
            return View(id);
        }

        public IActionResult Details(int id)
        {
            var product = db.Laptops.Where(p => p.LaptopID == id)
                .SingleOrDefault();
            if (product == null)
                return RedirectToAction("Index");
            return View(product);
        }
    }
}
