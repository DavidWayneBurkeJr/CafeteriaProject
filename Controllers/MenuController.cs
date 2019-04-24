using BatemanCafeteria.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BatemanCafeteria.Controllers
{
    [Authorize(Roles ="Caf_Secretary")]
    public class MenuController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        public ActionResult Create()
        {
            var categories = applicationDbContext.Caf_FoodCategories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Category");
            return PartialView("_Create");
        }

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
                return PartialView("_Delete", menuItem);
            }
        }

        [HttpPost]
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
            catch(DataException)
            {
                return View();
            }
            Debug.Write(category);
            return RedirectToAction("Menu", "Home", new { category = category });
        }

        [HttpGet]
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Caf_MenuItemModel menuItem = applicationDbContext.Caf_MenuItems.Find(id);
                if (menuItem == null)
                {
                    return HttpNotFound();
                }
                var categories = applicationDbContext.Caf_FoodCategories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "Category");
                return PartialView("_Edit", menuItem);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Caf_MenuItemModel menuItem)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Entry(menuItem).State = EntityState.Modified;
                applicationDbContext.SaveChanges();
                string category = applicationDbContext.Caf_FoodCategories.Find(menuItem.CategoryId).Category;

                return RedirectToAction("Menu", "Home", new { category});
            }
            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            var jsonErrors = JsonConvert.SerializeObject(allErrors);
            return Json(allErrors);
        }
    }
}