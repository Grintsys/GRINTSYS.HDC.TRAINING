using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public String ModifiedBy { get; set; }
        public bool IsEnable { get; set; }
        public bool IsDelete { get; set; }

        public Entity()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            ModifiedBy = "admin";
            IsDelete = false;
            IsEnable = true;
        }
    }
}