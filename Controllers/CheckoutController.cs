using BatemanCafeteria.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BatemanCafeteria.Controllers
{
    public class CheckoutController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        // GET: Checkout
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(Caf_InvoiceModel invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.StatusId = 1;
                invoice.Order_date = DateTime.Now.ToShortDateString();
                invoice.Order_time = DateTime.Now.ToShortTimeString();
                string pattern = @"^(?:\(?)(?<AreaCode>\d{3})(?:[\).\s]?)(\s?)(?<Prefix>\d{3})(?:[-\.\s]?)(?<Suffix>\d{4})(?!\d)";
                Match match = Regex.Match(invoice.Customer_phone, pattern);
                if (!match.Success)
                {
                    ModelState.AddModelError("", "Incorrect phone number format");
                    return View(invoice);
                }
                string phone = Regex.Replace(invoice.Customer_phone, "[^0-9]", "");
                phone = String.Format("{0:(###) ###-####}", Convert.ToInt64(phone));
                invoice.Customer_phone = phone;
                invoice.Payment_status = false;
                var cart = ShoppingCart.GetCart(this.HttpContext);
                invoice.Order_total = cart.GetTotal();
                applicationDbContext.Caf_Invoices.Add(invoice);
                applicationDbContext.SaveChanges();
                cart.CreateOrder(invoice);
                return RedirectToAction("Complete", new { id = invoice.InvoiceID });
            }
            else
            {
                return View(invoice);
            }
        }

        [HttpGet]
        public ActionResult Complete(int id)
        {
            bool isValid = applicationDbContext.Caf_Invoices.Where(x => x.InvoiceID == id).Any();
            if (isValid)
            {
                ViewBag.Id = id;
                return View();
            }
            else
            {
                return View("Error");
            }
        }

    }
}
