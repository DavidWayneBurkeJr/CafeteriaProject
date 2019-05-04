using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class ViewOrderViewModel
    {
        [DisplayName("Order number")]
        public int OrderId { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DisplayName("Phone number")]
        [Required]
        public string Phone { get; set; }
        [DisplayName("Date placed")]
        public string Date { get; set; }
        [DisplayName("Time placed")]
        public string Time { get; set; }
        [DisplayName("Items")]
        public List<Caf_OrderItemModel> Items { get; set; }
        [DisplayName("Total")]
        public decimal Total { get; set; }
    }
}