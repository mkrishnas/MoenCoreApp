using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DTOModels
{
    public class PCMRequestInfoDTO
    {
        [JsonIgnore]
        public int ProductInstanceId { get; set; }

        [JsonIgnore]
        public int? PcmrequestId { get; set; }

        [JsonPropertyName("ProductID")]
        public int? ProductId { get; set; }

        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }

        [JsonPropertyName("Qty")]
        public int? Quantity { get; set; }

        public string InputJson { get; set; }
    }
}
