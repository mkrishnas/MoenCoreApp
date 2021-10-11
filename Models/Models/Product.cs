using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public partial class Product
    {
        public Product()
        {
            PcmrequestInfo = new HashSet<PcmrequestInfo>();
            ProductDeriveParm = new HashSet<ProductDeriveParm>();
            ProductInputParm = new HashSet<ProductInputParm>();
            ProductMetaData = new HashSet<ProductMetaData>();
            SupplierProduct = new HashSet<SupplierProduct>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [StringLength(100)]
        public string Status { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<PcmrequestInfo> PcmrequestInfo { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductDeriveParm> ProductDeriveParm { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductInputParm> ProductInputParm { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductMetaData> ProductMetaData { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<SupplierProduct> SupplierProduct { get; set; }
    }
}
