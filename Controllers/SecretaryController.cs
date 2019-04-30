using BatemanCafeteria.Models;
using BatemanCafeteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data;

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

        public ActionResult RefreshOrders()
        {
            ManageOrdersViewModel manageOrders = new ManageOrdersViewModel
            {
                Received = applicationDbContext.Caf_Invoices.Where(items => items.StatusId == 1).ToList(),
                Cooking = applicationDbContext.Caf_Invoices.Where(items => items.StatusId == 2).ToList(),
                ReadyForPickup = applicationDbContext.Caf_Invoices.Where(items => items.StatusId == 3).ToList()

            };
            return PartialView("_ManageOrdersRefresh", manageOrders);
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
                EmailHelper email = new EmailHelper();
                email.sendEmail(invoice.Customer_email,
                    "Your order is ready for pickup! Be sure to bring $" + invoice.Order_total.ToString() + " with you.",
                    "Your order is ready for pickup!",
                    invoice.Customer_name);
            }
            applicationDbContext.SaveChanges();
            return RedirectToAction("ManageOrders");
            
        }

        public ActionResult ViewOrder(int id)
        {
            var invoice = applicationDbContext.Caf_Invoices.Find(id);
            var items = applicationDbContext.Caf_OrderItems.Where(x => x.InvoiceID == id).ToList();
            ViewOrderViewModel viewOrder = new ViewOrderViewModel
            {
                OrderId = invoice.InvoiceID,
                Email = invoice.Customer_email,
                Name = invoice.Customer_name,
                Phone = invoice.Customer_phone,
                Date = invoice.Order_date,
                Time = invoice.Order_time,
                Items = items,
                Total = invoice.Order_total
            };

            return PartialView("_ViewOrder", viewOrder);
        }

        [HttpGet]
        public ActionResult DeleteOrder(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var invoice = applicationDbContext.Caf_Invoices.Find(id);
                if(invoice == null)
                {
                    return HttpNotFound();
                }
                return PartialView("_Delete", invoice);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrder(int id)
        {
            var invoice = applicationDbContext.Caf_Invoices.Find(id);
            try
            {
                applicationDbContext.Caf_Invoices.Remove(invoice);
                applicationDbContext.SaveChanges();
            }
            catch(DataException)
            {
                return RedirectToAction("ManageOrders");
            }
            return RedirectToAction("ManageOrders");
        }


        [HttpGet]
        public ActionResult CateringOrder()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}