using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class InvoiceModel
    {
        public int InvoiceID { get; set; }
        public String Customer_name { get; set;}
        public String Customer_email { get; set; }
        public String Customer_phone { get; set; }
        public DateTime Order_date { get; set; }
        public String Order_time { get; set; }
        public Decimal Order_total { get; set; }
        public Boolean Payment_status { get; set; }
        public List<OrderItemModel> Order_items { get; set; }
    }
}