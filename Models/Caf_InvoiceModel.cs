using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class Caf_InvoiceModel
    {
        [Key]
        public int InvoiceID { get; set; }
        public string Customer_name { get; set;}
        public string Customer_email { get; set; }
        public string Customer_phone { get; set; }
        public DateTime Order_date { get; set; }
        public string Order_time { get; set; }
        public decimal Order_total { get; set; }
        public bool Payment_status { get; set; }
        public List<Caf_OrderItemModel> Order_items { get; set; }
    }
}