using System;
using Operations.IOperations;
using System.Collections.Generic;
using DTOModels;
using Repository;
using Repository.IRepository;
using AutoMapper;
using System.Threading.Tasks;

namespace Operations
{
    public class PCMRequestOperations : IPCMRequestOperations
    {
        private readonly IMapper _mapper;
        private readonly IPCMRequestRepository _pcmRequestRepository;
        List<PCMRequestDTO> pcmRequestDTO = new List<PCMRequestDTO>();

        public PCMRequestOperations(IPCMRequestRepository pcmRequestRepository, IMapper mapper)
        {
            _pcmRequestRepository = pcmRequestRepository;
            _mapper = mapper;
        }

        public List<PCMRequestDetailsDTO> GetAllPCMRequestInfo(string userId)
        {
            List<PCMRequestDetailsDTO> pcmRequestDetailsDTO = new List<PCMRequestDetailsDTO>();
            pcmRequestDetailsDTO = _pcmRequestRepository.GetAllPCMRequestInfo(userId);

            return pcmRequestDetailsDTO;
        }

        public async Task<List<PCMRequestDetailsDTO>> GetPCMRequestByProjectName(string ProjectName)
        {
            List<PCMRequestDetailsDTO> pcmRequestDetailsDTO = new List<PCMRequestDetailsDTO>();
            var result = await _pcmRequestRepository.GetPCMRequestByProjectName(ProjectName);
            pcmRequestDetailsDTO = _mapper.Map<List<PCMRequestDetailsDTO>>(result);

            //foreach (var reqItem in result)
            //{
            //    var reqdto = new PCMRequestDetailsDTO
            //    {
            //        Id = reqItem.Id,
            //        ProjectName = reqItem.ProjectName,
            //        Status = reqItem.Status
            //    };
            //    List<PCMRequestInfoDTO> requestInfoList = new List<PCMRequestInfoDTO>();
            //    foreach (var reqinfoItem in reqItem.PcmrequestInfo)
            //    {
            //        var reqinfodto = new PCMRequestInfoDTO
            //        {
            //            Quantity = reqinfoItem.Quantity,
            //            ProductId = reqinfoItem.Product.Id,
            //            ProductName = reqinfoItem.Product.Name,
            //        };
            //        requestInfoList.Add(reqinfodto);
            //    }
            //    reqdto.PCMRequestInfoList = requestInfoList;
            //    pcmRequestDetailsDTO.Add(reqdto);
            //}
            return pcmRequestDetailsDTO;
        }
    }
}
