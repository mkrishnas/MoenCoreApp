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
    public class ProductMetadataController : ControllerBase
    {
        private readonly IProductMetadataOperations _productMetadataOperations;
        public ProductMetadataController(IProductMetadataOperations productMetadataOperations, ILogger<SupplierController> logger) : base(logger)
        {
            _productMetadataOperations = productMetadataOperations;
        }

        [HttpGet("[action]")]
        public List<ProductMetaDataDTO> Get(int supplierId, int productid)
        {
            return _productMetadataOperations.GetProductMetadata(supplierId, productid);
        }

        [HttpGet("[action]")]
        public async Task CreateSupplier(int supplierId, int productId, string referenceName, string referenceParm, string referenceParmVal)
        {
            ProductMetaDataDTO productMetaDataDTO = new ProductMetaDataDTO();
            productMetaDataDTO.SupplierId = supplierId;
            productMetaDataDTO.ProductId = productId;
            productMetaDataDTO.ReferenceName = referenceName;
            productMetaDataDTO.ReferenceParm = referenceParm;
            productMetaDataDTO.ReferenceParmVal = referenceParmVal;

            //await _productMetadataOperations.CreateProductmetadata(productMetaDataDTO);
        }

        //[HttpGet("[action]")]
        //public List<PCMRequestDetailsDTO> Get()
        //{
        //    return _pcmRequestOperations.;
        //}
    }
}
