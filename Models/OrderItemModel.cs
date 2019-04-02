using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class OrderItemModel
    {
        public int Order_itemID { get; set; }
        public int InvoiceID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public String Special_instructions { get; set; }
    }
}