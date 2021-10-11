using System;
using System.Collections.Generic;
using System.Text;
using Models.Models;
using DTOModels;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPCMRequestRepository : IRepositoryAsync<Pcmrequest>
    {
        List<PCMRequestDetailsDTO> GetAllPCMRequestInfo(string userId);

        List<PCMRequestDetails1DTO> GetCustomPCMRequestInfo(string userId);

        Task<List<Pcmrequest>> GetPCMRequestByProjectName(string ProjectName);


    }
}
