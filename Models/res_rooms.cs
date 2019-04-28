using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class res_rooms
    {
        [Key]
        public int room_id { get; set; }
        public string room_name { get; set; }
        public string location { get; set; }
    }
}