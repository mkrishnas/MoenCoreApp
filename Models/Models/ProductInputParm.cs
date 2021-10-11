using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class ProductInputParm
    {
        [Key]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ParmId { get; set; }
        public int? InputSeqId { get; set; }
        [StringLength(100)]
        public string InputSource { get; set; }
        [StringLength(100)]
        public string FieldType { get; set; }
        [StringLength(100)]
        public string DefualtVal { get; set; }

        [ForeignKey(nameof(ParmId))]
        [InverseProperty("ProductInputParm")]
        public virtual Parm Parm { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductInputParm")]
        public virtual Product Product { get; set; }
    }
}
