using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    [Table("PCMCost")]
    public partial class Pcmcost
    {
        [Key]
        public int Id { get; set; }
        public int? ProductInstanceId { get; set; }
        public int? SupplierId { get; set; }
        [StringLength(100)]
        public string SupplierStatus { get; set; }
        [Column("DrivedJSON")]
        [StringLength(100)]
        public string DrivedJson { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? ActualCost { get; set; }

        [ForeignKey(nameof(ProductInstanceId))]
        [InverseProperty(nameof(PcmrequestInfo.Pcmcost))]
        public virtual PcmrequestInfo ProductInstance { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Pcmcost")]
        public virtual Supplier Supplier { get; set; }
    }
}
