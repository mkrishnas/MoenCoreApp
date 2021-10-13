using AutoMapper;
using DTOModels;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<Pcmrequest, PCMRequestDTO>();
            CreateMap<Pcmrequest, PCMRequestDetailsDTO>();
            CreateMap<PcmrequestInfo, PCMRequestInfoDTO>();
        }
    }
}
