using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Pcmcost = new HashSet<Pcmcost>();
            ProductDeriveParm = new HashSet<ProductDeriveParm>();
            ProductMetaData = new HashSet<ProductMetaData>();
            SupplierProduct = new HashSet<SupplierProduct>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<Pcmcost> Pcmcost { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<ProductDeriveParm> ProductDeriveParm { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<ProductMetaData> ProductMetaData { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<SupplierProduct> SupplierProduct { get; set; }
    }
}
