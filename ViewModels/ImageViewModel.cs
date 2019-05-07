using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.ViewModels
{
    public class ImageViewModel
    {
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public bool IsBeingUsed { get; set; }
    }
}