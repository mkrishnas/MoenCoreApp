using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class SupplierProduct
    {
        [Key]
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("SupplierProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("SupplierProduct")]
        public virtual Supplier Supplier { get; set; }
    }
}
