using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class CartModel
    {
        [Key]
        public int RecordID { get; set; }
        public int CartID { get; set; }
        public int ItemID { get; set; }

    }
}