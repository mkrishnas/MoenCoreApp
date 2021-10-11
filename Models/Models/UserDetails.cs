using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string UserPassword { get; set; }
        public int? GroupId { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        public int? ContactNumber { get; set; }
        [StringLength(100)]
        public string ContactName { get; set; }
        [StringLength(100)]
        public string UserRole { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty(nameof(GroupDetails.UserDetails))]
        public virtual GroupDetails Group { get; set; }
    }
}
