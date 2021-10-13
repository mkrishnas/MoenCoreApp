namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.Logging;
    using DTOModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Operations;
    using Operations.IOperations;

    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(GlobalExceptionFilter))]
    public class PCMRequestController : ControllerBase
    {
        private readonly IPCMRequestOperations pcmRequestOperations;

        public PCMRequestController(IPCMRequestOperations pcmRequestOperations, ILogger<SupplierController> logger)
            : base(logger)
        {
            this.pcmRequestOperations = pcmRequestOperations;
        }

        [HttpGet("[action]")]
        public List<PCMRequestDetailsDTO> Get(string userId)
        {
            return this.pcmRequestOperations.GetAllPCMRequestInfo(userId);
        }

        [HttpGet("[action]")]
        public Task<List<PCMRequestDetailsDTO>> GetPCMRequestByProjectName(string projectName)
        {
            return this.pcmRequestOperations.GetPCMRequestByProjectName(projectName);
        }
    }
}
