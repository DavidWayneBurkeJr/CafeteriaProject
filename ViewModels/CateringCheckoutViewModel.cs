using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime SelectedTime { get; set; }
    }
}