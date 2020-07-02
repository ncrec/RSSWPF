using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RSSWPF.Models
{
    public class ProductStatus
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
