using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Repository.IRepository;
using DTOModels;
using System.Threading.Tasks;

namespace Repository
{
    public class PCMRequestRepository  : RepositoryAsync<Pcmrequest>, IPCMRequestRepository
    {
        private readonly MOENPCMContext _context;
        public PCMRequestRepository(MOENPCMContext context) : base(context)
        {
            _context = context;
        }

        public List<PCMRequestDetailsDTO> GetAllPCMRequestInfo(string userId)
        {
            List<PCMRequestDetailsDTO> lstPCMRequestDetailsDTO = new List<PCMRequestDetailsDTO>();

            using (var dbContext = _context)
            {
                lstPCMRequestDetailsDTO = (from pcmr in dbContext.Pcmrequest
                                   join pcmri in dbContext.PcmrequestInfo on pcmr.Id equals pcmri.PcmrequestId
                                   where pcmr.CreatedBy == userId
                                   select new PCMRequestDetailsDTO
                                   {
                                       Id = pcmr.Id,
                                       ProjectName = pcmr.ProjectName,
                                       Status = pcmr.Status,
                                       ProductId = pcmri.ProductId
                                       //ProductName = pcmri.ProductName
                                   }).ToList();
            }
            return lstPCMRequestDetailsDTO;          
        }

      
        public List<PCMRequestDetails1DTO> GetCustomPCMRequestInfo(string userId)
        {
            List<PCMRequestDetails1DTO> lstPCMRequestDetailsDTO = new List<PCMRequestDetails1DTO>();

            using (var dbContext = _context)
            {
                lstPCMRequestDetailsDTO = dbContext.Pcmrequest.Include("PcmrequestInfo").Select(s => new PCMRequestDetails1DTO()
                {
                    Id = s.Id,
                    ProjectName = s.ProjectName,
                    Status = s.Status,
                    //PCMRequestInfoList = new s.PcmrequestInfo
                    //{
                    //}

                    }).ToList<PCMRequestDetails1DTO>();
            }

            return lstPCMRequestDetailsDTO;
        }

        public async Task<List<Pcmrequest>> GetPCMRequestByProjectName(string ProjectName)
        {
            using (var ctx = _context)
            {
                var cq = ctx.Pcmrequest
                .Include(p => p.PcmrequestInfo).ThenInclude(p => p.Product)
                .Where(p => p.ProjectName == ProjectName)
                .AsNoTracking();
                return await cq.ToListAsync();
            }

        }
    }
}
