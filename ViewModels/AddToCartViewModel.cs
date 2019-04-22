using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class AddToCartViewModel
    {
        public Caf_MenuItemModel MenuItem { get; set; }
        public string SpecialInstructions { get; set; }
        [DisplayName("Quantity")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Quantity cannot be negative")]
        public int Quantity { get; set; }
    }
}