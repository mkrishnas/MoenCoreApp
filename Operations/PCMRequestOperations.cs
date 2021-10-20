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
        private readonly IUnitOfWork _unitOfWork;
        List<PCMRequestDTO> pcmRequestDTO = new List<PCMRequestDTO>();
        

        public PCMRequestOperations(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<PCMRequestDetailsDTO> GetAllPCMRequestInfo(string userId)
        {
            List<PCMRequestDetailsDTO> pcmRequestDetailsDTO = new List<PCMRequestDetailsDTO>();
            pcmRequestDetailsDTO = _unitOfWork.PCMRequest.GetAllPCMRequestInfo(userId);

            return pcmRequestDetailsDTO;
        }

        public async Task<List<PCMRequestDetailsDTO>> GetPCMRequestByProjectName(string ProjectName)
        {
            List<PCMRequestDetailsDTO> pcmRequestDetailsDTO = new List<PCMRequestDetailsDTO>();
            var result = await _unitOfWork.PCMRequest.GetPCMRequestByProjectName(ProjectName);
            pcmRequestDetailsDTO = _mapper.Map<List<PCMRequestDetailsDTO>>(result);
            
            return pcmRequestDetailsDTO;
        }
    }
}
