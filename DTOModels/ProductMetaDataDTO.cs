using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DTOModels
{
    public class ProductMetaDataDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int? SupplierId { get; set; }
        [JsonIgnore]
        public int? ProductId { get; set; }
        
        public string ReferenceName { get; set; }
        
        public string ReferenceParm { get; set; }
        
        public string ReferenceParmVal { get; set; }
    }
}
