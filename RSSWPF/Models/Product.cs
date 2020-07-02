using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RSSWPF.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ProductStatus Status { get; set; }

    }
}
