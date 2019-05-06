using BatemanCafeteria.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BatemanCafeteria.Controllers
{
    [Authorize(Roles = "Caf_Admin")]
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
            if(TempData["Errors"] != null)
            {
                ViewBag.Errors = TempData["Errors"].ToString();
            }
            List<ApplicationUser> users = applicationDbContext.Users.Where(x => x.Roles.Any(r => r.RoleId == applicationDbContext.Roles.Where(y => y.Name == "Caf_Secretary").FirstOrDefault().Id)).ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return RedirectToAction("Register", "Account");
        }
        
        [HttpGet]
        public ActionResult DeleteUser(string id)
        {
            ApplicationUser user = applicationDbContext.Users.Find(id);
            if (user != null)
            {
                return PartialView("_DeleteUser", user);
            }
            else
            {
                TempData["Errors"] = "Something went wrong. Could not find user. Please try again.";
                return RedirectToAction("ManageUsers");
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(ApplicationUser user)
        {
            applicationDbContext.Users.Attach(user);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(applicationDbContext));
            var result = userManager.Delete(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ManageUsers", "Admin");
            }
            else
            {
                TempData["Errors"] = "Error in deleting user. Please try again.";
                return RedirectToAction("ManageUsers", "Admin");
            }
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