using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class GroupDetails
    {
        public GroupDetails()
        {
            UserDetails = new HashSet<UserDetails>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string EmailId { get; set; }

        [InverseProperty("Group")]
        public virtual ICollection<UserDetails> UserDetails { get; set; }
    }
}
