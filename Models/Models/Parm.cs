using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class Parm
    {
        public Parm()
        {
            ProductDeriveParm = new HashSet<ProductDeriveParm>();
            ProductInputParm = new HashSet<ProductInputParm>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [StringLength(100)]
        public string InputType { get; set; }

        [InverseProperty("Parm")]
        public virtual ICollection<ProductDeriveParm> ProductDeriveParm { get; set; }
        [InverseProperty("Parm")]
        public virtual ICollection<ProductInputParm> ProductInputParm { get; set; }
    }
}
