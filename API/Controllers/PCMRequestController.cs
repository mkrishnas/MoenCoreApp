using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Operations;
using DTOModels;
using Operations.IOperations;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class PCMRequestController : ControllerBase
    {
        private readonly IPCMRequestOperations _pcmRequestOperations;
        public PCMRequestController(IPCMRequestOperations pcmRequestOperations, ILogger<SupplierController> logger) : base(logger)
        {
            _pcmRequestOperations = pcmRequestOperations;
        }

        [HttpGet("[action]")]
        public List<PCMRequestDetailsDTO> Get(string userId)
        {
            return _pcmRequestOperations.GetAllPCMRequestInfo(userId);
        }

        [HttpGet("[action]")]
        public Task<List<PCMRequestDetailsDTO>> GetPCMRequestByProjectName(string ProjectName)
        {
            return _pcmRequestOperations.GetPCMRequestByProjectName(ProjectName);
        }

        //[HttpGet("[action]")]
        //public List<PCMRequestDetailsDTO> Get()
        //{
        //    return _pcmRequestOperations.;
        //}
    }
}
