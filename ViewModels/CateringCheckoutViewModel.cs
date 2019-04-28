using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class CateringCheckoutViewModel
    {
        public Caf_InvoiceModel Invoice { get; set; }
        public res_reservations Reservation { get; set; }
        public res_rooms Room { get; set; }
        public string Instructions { get; set; }
        public DateTime SelectedTime { get; set; }
    }
}