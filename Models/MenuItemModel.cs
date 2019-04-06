using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class MenuItemModel
    {
        [Key]
        public int MenuID { get; set; }
        public String Title { get; set; }
        public decimal Price { get; set; }
        public String Description { get; set; }
        public int Calories { get; set; }
        public String ImgLocation { get; set; }
    }
}