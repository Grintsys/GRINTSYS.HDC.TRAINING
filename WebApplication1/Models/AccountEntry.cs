using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountEntry : Entity<long>
    {
        public long AccountId { get; set; }

        [Required]
        public String Description { get; set; }
        public Double Debit { get; set; }
        public Double Credit { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}