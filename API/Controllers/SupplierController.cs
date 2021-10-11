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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierOperations _supplierOperations;

        private readonly ILogger<SupplierController> _logger;
        public SupplierController(ISupplierOperations supplierOperations, ILogger<SupplierController> logger) : base(logger)
        {
            _logger = logger;
            _supplierOperations = supplierOperations;
        }

        [HttpGet("[action]")]
        public List<SupplierDTO> Get()
        {
            return _supplierOperations.GetAllSuppliers();
        }

        [HttpGet("[action]")]
        public List<SupplierInfoDTO> GetAllSupplierInfo()
        {
            return _supplierOperations.GetAllSuppliersInfo();
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> GetSupplierById(int supplierId)
        {
            var respData = await _supplierOperations.GetSupplier(supplierId);
            return CreateResponse(respData);
            //return await _supplierOperations.GetSupplier(supplierId);
        }

        [HttpGet("[action]")]
        public async Task CreateSupplier(string name)
        {
            await _supplierOperations.AddSupplier(name);
        }

        [HttpGet("[action]")]
        public async Task UpdateSupplier(string name)
        {
            await _supplierOperations.UpdateSupplier(name);
        }

        [HttpGet("[action]")]
        public async Task RemoveSupplier(int Id)
        {
            await _supplierOperations.RemoveSupplier(Id);
        }
    }
}
