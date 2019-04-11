using BatemanCafeteria.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

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

        [Authorize(Roles = "Caf_Admin, Caf_Secretary")]
        public ActionResult Create()
        {
            var categories = applicationDbContext.Caf_FoodCategories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Category");
            return View();
        }

        [Authorize(Roles = "Caf_Admin, Caf_Secretary")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caf_MenuItemModel menuItem)
        {
            var categories = applicationDbContext.Caf_FoodCategories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Category");

            if (ModelState.IsValid)
            {

                string filename = menuItem.Title;
                string extension = Path.GetExtension(menuItem.ImageFile.FileName);
                string category = applicationDbContext.Caf_FoodCategories.Find(menuItem.CategoryId).Category;
                
                if (!string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("", "Selected file must be an image of type .png, .jpg");

                    return View(menuItem);
                }

                try
                {
                    if (!menuItem.ImageFile.InputStream.CanRead)
                    {
                        ModelState.AddModelError("", "Selected file must be an image of type .png, .jpg");
                        return View(menuItem);
                    }

                    if(menuItem.ImageFile.ContentLength < 512)
                    {
                        ModelState.AddModelError("", "Selected file must be an image of type .png, .jpg");

                        return View(menuItem);
                    }

                    byte[] buffer = new byte[512];
                    menuItem.ImageFile.InputStream.Read(buffer, 0, 512);
                    string content = System.Text.Encoding.UTF8.GetString(buffer);
                    if(Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                    {
                        ModelState.AddModelError("", "Selected file must be an image of type .png, .jpg");

                        return View(menuItem);
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Selected file must be an image of type .png, .jpg");

                    return View(menuItem);
                }
                filename = filename + extension;
                menuItem.ImgLocation = "/Images/MenuItems/" + filename;
                filename = Path.Combine(Server.MapPath("/Images/MenuItems"), filename);
                menuItem.ImageFile.SaveAs(filename);
                try
                {
                    applicationDbContext.Caf_MenuItems.Add(menuItem);
                    applicationDbContext.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    ModelState.AddModelError("", menuItem.Title + " already exists.");
                    return View(menuItem);
                }
                return RedirectToAction("Menu", "Home", new { category = category });
            }
            
            return View(menuItem);
        }

        [HttpGet]
        [Authorize(Roles = "Caf_Admin, Caf_Secretary")]
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Caf_MenuItemModel menuItem = applicationDbContext.Caf_MenuItems.Find(id);
                if(menuItem == null)
                {
                    return HttpNotFound();
                }
                return View(menuItem);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Caf_Admin, Caf_Secretary")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Caf_MenuItemModel menuItemModel = applicationDbContext.Caf_MenuItems.Find(id);
            string category = menuItemModel.FoodCategory.Category;
            try
            {
                applicationDbContext.Caf_MenuItems.Remove(menuItemModel);
                applicationDbContext.SaveChanges();
            }
            catch(DataException dex)
            {
                return View();
            }
            Debug.Write(category);
            return RedirectToAction("Menu", "Home", new { category = category });
        }
    }
}