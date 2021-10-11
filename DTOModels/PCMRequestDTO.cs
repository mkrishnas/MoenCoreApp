using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOModels
{
    public class PCMRequestDTO
    {        
        public int Id { get; set; }
        
        public string ProjectName { get; set; }
        
        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string AssignedTo { get; set; }

        public string Version { get; set; }
        public ICollection<PCMRequestInfoDTO> PCMRequestInfoList { get; set; }
    }
}
