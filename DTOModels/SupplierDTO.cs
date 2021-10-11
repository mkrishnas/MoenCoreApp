using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOModels
{
    public partial class SupplierDTO
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        //public string Pcmcost { get; set; }

        //public string ProductDeriveParm { get; set; }

        //public string ProductMetaData { get; set; }

        //public string SupplierProduct { get; set; }
    }
}
