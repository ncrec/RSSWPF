using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RSSWPF.Models
{
    public class ChangeStatusHistory
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(250)]
        public DateTime SetOn{ get; set; }
        public Guid StatusFromId { get; set; }
        [ForeignKey("StatusFromId")]
        public virtual ProductStatus StatusFrom { get; set; }
        public Guid StatusToId { get; set; }
        [ForeignKey("StatusToId")]
        public virtual ProductStatus StatusTo { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
