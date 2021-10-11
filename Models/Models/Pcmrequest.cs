using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    [Table("PCMRequest")]
    public partial class Pcmrequest
    {
        public Pcmrequest()
        {
            PcmrequestInfo = new HashSet<PcmrequestInfo>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string ProjectName { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [StringLength(100)]
        public string AssignedTo { get; set; }
        [StringLength(100)]
        public string Version { get; set; }

        [InverseProperty("Pcmrequest")]
        public virtual ICollection<PcmrequestInfo> PcmrequestInfo { get; set; }
    }
}
