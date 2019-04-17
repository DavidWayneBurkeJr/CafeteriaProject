using BatemanCafeteria.Models;
using BatemanCafeteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BatemanCafeteria.Controllers
{
    [Authorize(Roles = "Caf_Admin, Caf_Secretary")]
    public class SecretaryController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        // GET: Secretary
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ManageOrders()
        {
            ManageOrdersViewModel manageOrders = new ManageOrdersViewModel
            {
                Received = applicationDbContext.Caf_Invoices.Where(items => items.StatusId == 1).ToList(),
                Cooking = applicationDbContext.Caf_Invoices.Where(items => items.StatusId == 2).ToList(),
                ReadyForPickup = applicationDbContext.Caf_Invoices.Where(items => items.StatusId == 3).ToList()
                
            };
            return View(manageOrders);
        }

        public ActionResult ChangeStatus(int id)
        {
            Caf_InvoiceModel invoice = applicationDbContext.Caf_Invoices.Where(item => item.InvoiceID == id).First();
            if (invoice.StatusId < 3)
            {
                invoice.StatusId++;
                applicationDbContext.SaveChanges();
            }
            return RedirectToAction("ManageOrders");
        }

        public ActionResult ChangePaymentStatus(int id)
        {
            Caf_InvoiceModel invoice = applicationDbContext.Caf_Invoices.Where(item => item.InvoiceID == id).First();
            if (invoice.Payment_status == false)
            {
                invoice.Payment_status = true;
            }
            else if (invoice.Payment_status == true)
            {
                applicationDbContext.Caf_Invoices.Remove(invoice);
            }
            applicationDbContext.SaveChanges();
            return RedirectToAction("ManageOrders");
            
        }
    }
}