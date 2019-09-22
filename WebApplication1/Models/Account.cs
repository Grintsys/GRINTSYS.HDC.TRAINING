using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Account : Entity<long>
    {
        [Required]
        public String AccNumber { get; set; }
        public String AccFatherNumber { get; set; }
        [Required]
        [StringLength(200)]
        public String Name { get; set; }
        public Double Total { get; set; }
    }
}