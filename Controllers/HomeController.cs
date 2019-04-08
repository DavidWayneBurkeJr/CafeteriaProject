using BatemanCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BatemanCafeteria.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OrderStatus()
        {
            ViewBag.Message = "Your order status page.";

            return View();
        }

        public ActionResult Menu(string category)
        {
            List<Caf_MenuItemModel> menuItems = applicationDbContext.Caf_MenuItems.Where(c => c.Category == category).ToList();
            return View(menuItems);
        }
    }
}