using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class ProductMetaData
    {
        [Key]
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }
        [StringLength(100)]
        public string ReferenceName { get; set; }
        [StringLength(100)]
        public string ReferenceParm { get; set; }
        [StringLength(100)]
        public string ReferenceParmVal { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductMetaData")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("ProductMetaData")]
        public virtual Supplier Supplier { get; set; }
    }
}
