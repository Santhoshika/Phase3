using Laptopseller.Models;
using Laptopseller.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Laptopseller.Controllers
{
    public class CartController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();

        public IActionResult Index()

        {
            var cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Qunatity);
            return View();
        }


        public IActionResult Buy(int id)
        {
            if (SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = context.Laptops.Find(id), Qunatity = 1 });
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExists(id);
                if (index != -1)
                {
                    cart[index].Qunatity++;
                }
                else
                {
                    cart.Add(new Item { Product = context.Laptops.Find(id), Qunatity = 1 });
                }
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExists(id);
            if (index != -1)
            {
                cart.RemoveAt(index);
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }

        public IActionResult Clearcart()

        {
            List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            {
                for (int i = 0; i < cart.Count; i++)
                {
                    cart.Clear();
                    SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
                    return RedirectToAction("Index");


                }
            }
            return RedirectToAction("Index");

        }

        public int isExists(int id)
        {
            List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.LaptopID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }

}
