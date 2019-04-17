using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class ManageOrdersViewModel
    {
        public List<Caf_InvoiceModel> Received { get; set; }
        public List<Caf_InvoiceModel> Cooking { get; set; }
        public List<Caf_InvoiceModel> ReadyForPickup { get; set; }
    }
}