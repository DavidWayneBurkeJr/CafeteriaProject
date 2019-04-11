using BatemanCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ActionResult OrderStatus(int id)
        {

            ViewBag.Message = "Your order status page.";
            var invoice = applicationDbContext.Caf_Invoices.Where(x => x.InvoiceID == id).First();
            string status = invoice.FoodStatus.Status;
            ViewBag.Status = status;
            return View();
        }

        public ActionResult Menu(string category)
        {
            int catId = applicationDbContext.Caf_FoodCategories.Where(x => x.Category == category.Trim()).First().CategoryId;
            List<Caf_MenuItemModel> menuItems = applicationDbContext.Caf_MenuItems.Where(x => x.CategoryId == catId).ToList();
            return View(menuItems);
        }
    }
}