﻿using System;
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
            return pcmRequestDetailsDTO;
        }
    }
}
