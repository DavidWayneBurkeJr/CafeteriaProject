using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Name { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone number")]
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