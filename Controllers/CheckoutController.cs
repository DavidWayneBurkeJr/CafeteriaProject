using BatemanCafeteria.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using BatemanCafeteria.ViewModels;
using System.Collections.Generic;

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

        [HttpGet]
        [Authorize(Roles = "Caf_Secretary")]
        public ActionResult CateringCheckout(int verification)
        {
            var resInfo = applicationDbContext.res_reservations.Where(x => x.ver_code == verification).First();
            Caf_InvoiceModel invoice = new Caf_InvoiceModel
            {
                Customer_email = resInfo.email_addr,
                Customer_name = resInfo.res_name,
                Customer_phone = resInfo.phone_ext,
                Order_total = 0.00M,
                Payment_status = true

            };
            CateringCheckoutViewModel cateringModel = new CateringCheckoutViewModel
            {
                Reservation = resInfo,
                Room = applicationDbContext.res_rooms.Find(resInfo.room_id),
                Invoice = invoice
            };
            return View(cateringModel);
        }

        [HttpPost]
        [Authorize(Roles = "Caf_Secretary")]
        public ActionResult CateringCheckout(CateringCheckoutViewModel cateringModel)
        {
            if (ModelState.IsValid)
            {
                Caf_Caterings catering = new Caf_Caterings
                {
                    InvoiceID = cateringModel.Invoice.InvoiceID,
                    res_id = cateringModel.Reservation.res_id,
                    Instructions = cateringModel.Instructions,
                    Time = cateringModel.SelectedTime
                };
                Caf_InvoiceModel invoice = cateringModel.Invoice;
                invoice.StatusId = 1;
                invoice.Order_date = DateTime.Now.ToShortDateString();
                invoice.Order_time = DateTime.Now.ToShortTimeString();
                var cart = ShoppingCart.GetCart(this.HttpContext);
                applicationDbContext.Caf_Invoices.Add(invoice);
                applicationDbContext.Caf_Caterings.Add(catering);
                applicationDbContext.SaveChanges();
                cart.CreateOrder(invoice);
                return RedirectToAction("Complete", new { id = invoice.InvoiceID });

            }else
            {
                ModelState.AddModelError("", "Oops! Something went wrong. Please try again.");
                return View(cateringModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Caf_Secretary")]
        public ActionResult CateringVerification()
        {
            return PartialView("_CateringVerification");
        }

        [HttpPost]
        [Authorize(Roles = "Caf_Secretary")]
        [ValidateAntiForgeryToken]
        public ActionResult CateringVerification(CateringVerficationViewModel verificationModel)
        {
            int vCode = verificationModel.VerificationCode;
            if(applicationDbContext.res_reservations.Where(x => x.ver_code == vCode).Any())
            {
                return RedirectToAction("CateringCheckout", new { verification = vCode });
            }
            else
            {
                return RedirectToAction("CartView", "ShoppingCart");
            }
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
