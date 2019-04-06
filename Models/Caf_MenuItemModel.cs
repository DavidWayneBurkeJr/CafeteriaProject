using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class Caf_MenuItemModel
    {
        [Key]
        public int MenuID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public string ImgLocation { get; set; }
        public string Category { get; set; }
    }
}