using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class AddToCartViewModel
    {
        public Caf_MenuItemModel MenuItem { get; set; }
        public string SpecialInstructions { get; set; }
        public int Quantity { get; set; }
    }
}