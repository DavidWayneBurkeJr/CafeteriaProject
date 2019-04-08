using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.Controllers
{
    public class MenuController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Title, Price, Description, Calories, ImgLocation, Category")]Caf_MenuItemModel menuItem)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Caf_MenuItems.Add(menuItem);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Menu", "Home", menuItem.Category.ToString());
            }
            return RedirectToAction("Index", "Home");
        }
    }
}