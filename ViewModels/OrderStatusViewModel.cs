using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.ViewModels
{
    public class OrderStatusViewModel
    {
        [Required(ErrorMessage = "You must enter an order identification number. This can be found in the confirmation email sent to you.")]
        [Range(0, int.MaxValue, ErrorMessage = "Order number cannot be negative")]
        [DisplayName("Order Number")]
        public int Id { get; set; }
    }
}