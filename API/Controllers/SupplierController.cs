namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DTOModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Operations;
    using Operations.IOperations;

    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperations supplierOperations;

        private readonly ILogger<SupplierController> logger;

        public SupplierController(ISupplierOperations supplierOperations, ILogger<SupplierController> logger)
            : base(logger)
        {
            this.logger = logger;
            this.supplierOperations = supplierOperations;
        }

        [HttpGet("[action]")]
        public List<SupplierDTO> Get()
        {
            return this.supplierOperations.GetAllSuppliers();
        }

        [HttpGet("[action]")]
        public List<SupplierInfoDTO> GetAllSupplierInfo()
        {
            return this.supplierOperations.GetAllSuppliersInfo();
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> GetSupplierById(int supplierId)
        {
            var respData = await this.supplierOperations.GetSupplier(supplierId);
            return this.CreateResponse(respData);
        }

        [HttpGet("[action]")]
        public async Task CreateSupplier(string name)
        {
            await this.supplierOperations.AddSupplier(name);
        }

        [HttpGet("[action]")]
        public async Task UpdateSupplier(string name)
        {
            await this.supplierOperations.UpdateSupplier(name);
        }

        [HttpGet("[action]")]
        public async Task RemoveSupplier(int id)
        {
            await this.supplierOperations.RemoveSupplier(id);
        }

        [HttpGet("[action]")]
        public async Task SendEmail(int supplierId)
        {
            await this.supplierOperations.SendCostEmailToSupplier(supplierId);
        }
    }
}
