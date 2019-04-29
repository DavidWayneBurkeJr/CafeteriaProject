using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class EditMenuViewModel
    {
        public List<Caf_MenuItemModel> Item { get; set; }
        public List<Caf_DailySpecials> DailySpecial { get; set; }
    }
}