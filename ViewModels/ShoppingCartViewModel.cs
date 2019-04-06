using System.Collections.Generic;
using BatemanCafeteria.Models;

namespace BatemanCafeteria.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Caf_CartModel> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}