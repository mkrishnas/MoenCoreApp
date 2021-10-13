using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DTOModels
{
    public class PCMRequestDetailsDTO
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Status { get; set; }

        [JsonIgnore]
        public int? ProductId { get; set; }

        //public string ProductName { get; set; }

        //public string CreatedBy { get; set; }

        //public string AssignedTo { get; set; }

        //public string Version { get; set; }

        [JsonPropertyName("RequestInfo")]
        public ICollection<PCMRequestInfoDTO> PCMRequestInfo { get; set; }
    }

    public class PCMRequestDetails1DTO
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Status { get; set; }

        //public string CreatedBy { get; set; }

        //public string AssignedTo { get; set; }

        //public string Version { get; set; }

        public IList<PCMRequestInfoDTO> PCMRequestInfoList { get; set; }
    }
}
