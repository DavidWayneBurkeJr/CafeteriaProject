using BatemanCafeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BatemanCafeteria.Controllers
{
    [Authorize(Roles ="Caf_Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ManageUsers()
        {
            List<ApplicationUser> users = applicationDbContext.Users.Where(x => x.Roles.Any(r => r.RoleId == applicationDbContext.Roles.Where(y => y.Name == "Caf_Secretary").FirstOrDefault().Id)).ToList();
            return View(users);
        }

        //[HttpGet]
        //public ActionResult ManageImages()
        //{

        //}

        //[HttpGet]
        //public ActionResult ManageCategories()
        //{

        //}

    }
}