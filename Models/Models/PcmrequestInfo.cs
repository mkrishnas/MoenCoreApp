using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    [Table("PCMRequestInfo")]
    public partial class PcmrequestInfo
    {
        public PcmrequestInfo()
        {
            Pcmcost = new HashSet<Pcmcost>();
        }

        [Key]
        public int ProductInstanceId { get; set; }
        [Column("PCMRequestId")]
        public int? PcmrequestId { get; set; }
        public int? ProductId { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [Column("InputJSON")]
        [StringLength(100)]
        public string InputJson { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey(nameof(PcmrequestId))]
        [InverseProperty("PcmrequestInfo")]
        public virtual Pcmrequest Pcmrequest { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("PcmrequestInfo")]
        public virtual Product Product { get; set; }
        [InverseProperty("ProductInstance")]
        public virtual ICollection<Pcmcost> Pcmcost { get; set; }
    }
}
