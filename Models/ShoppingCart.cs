using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BatemanCafeteria.ViewModels;

namespace BatemanCafeteria.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        string ShoppingCartID { get; set; }
        public const string CartSessionKey = "CartID";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartID = cart.GetCartID(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(AddToCartViewModel selectedItem)
        {
            var cartItem = applicationDbContext.Caf_Carts.SingleOrDefault(
                c => c.CartID == ShoppingCartID
                && c.MenuID == selectedItem.MenuItem.MenuID);

            if (cartItem == null)
            {
                cartItem = new Caf_CartModel
                {
                    MenuID = selectedItem.MenuItem.MenuID,
                    CartID = ShoppingCartID,
                    Quantity = selectedItem.Quantity,
                    SpecialInstructions = selectedItem.SpecialInstructions,
                    DateCreated = DateTime.Now
                };
                applicationDbContext.Caf_Carts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            applicationDbContext.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = applicationDbContext.Caf_Carts.Single(
                cart => cart.CartID == ShoppingCartID
                && cart.RecordID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    applicationDbContext.Caf_Carts.Remove(cartItem);
                }
                applicationDbContext.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = applicationDbContext.Caf_Carts.Where(
                cart => cart.CartID == ShoppingCartID);

            foreach (var cartItem in cartItems)
            {
                applicationDbContext.Caf_Carts.Remove(cartItem);
            }
            applicationDbContext.SaveChanges();
        }

        public List<Caf_CartModel> GetCartItems()
        {
            return applicationDbContext.Caf_Carts.Where(
                cart => cart.CartID == ShoppingCartID).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in applicationDbContext.Caf_Carts
                          where cartItems.CartID == ShoppingCartID
                          select (int?)cartItems.Quantity).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in applicationDbContext.Caf_Carts
                              where cartItems.CartID == ShoppingCartID
                              select (int?)cartItems.Quantity *
                              cartItems.MenuItem.Price).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Caf_InvoiceModel invoice)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new Caf_OrderItemModel
                {
                    MenuID = item.MenuID,
                    InvoiceID = invoice.InvoiceID,
                    UnitPrice = item.MenuItem.Price,
                    Quantity = item.Quantity,
                    Special_instructions = item.SpecialInstructions
                };
                orderTotal += (item.Quantity * item.MenuItem.Price);

                applicationDbContext.Caf_OrderItems.Add(orderDetail);
            }
            invoice.Order_total = orderTotal;

            applicationDbContext.SaveChanges();
            EmailHelper email = new EmailHelper();
            email.sendEmail(invoice.Customer_email,
                "Thank you for your order! Your food will start cooking shortly. Your order number is " + invoice.InvoiceID,
                "Cafeteria Order Confirmation",
                invoice.Customer_name);
            EmptyCart();
            return invoice.InvoiceID;
        }


        public string GetCartID(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
    }
}