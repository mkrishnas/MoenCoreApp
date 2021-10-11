using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class ProductDeriveParm
    {
        [Key]
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }
        public int? ParmId { get; set; }
        [StringLength(100)]
        public string Formula { get; set; }
        public int? SequenceId { get; set; }

        [ForeignKey(nameof(ParmId))]
        [InverseProperty("ProductDeriveParm")]
        public virtual Parm Parm { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductDeriveParm")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("ProductDeriveParm")]
        public virtual Supplier Supplier { get; set; }
    }
}
