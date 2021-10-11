using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOModels
{
    public class ProductSubMetaDataDTO
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceParmName { get; set; }
        [StringLength(100)]
        public string SubParmName { get; set; }
        [StringLength(100)]
        public string SubParmValue { get; set; }
    }
}
