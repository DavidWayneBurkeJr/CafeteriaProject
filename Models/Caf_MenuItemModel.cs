using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class Caf_MenuItemModel
    {
        [Key]
        public int MenuID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int Calories { get; set; }
        [DisplayName("Upload Image")]
        public string ImgLocation { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public virtual Caf_FoodCategories FoodCategory { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}