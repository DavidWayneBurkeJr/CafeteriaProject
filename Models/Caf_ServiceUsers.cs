using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class Caf_ServiceUsers
    {
        [Key]
        public int ServiceUsersId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string MachineName { get; set; }
        [Required]
        public string DomainName { get; set; }
        [Required]
        public bool IsBanned { get; set; }
    }
}