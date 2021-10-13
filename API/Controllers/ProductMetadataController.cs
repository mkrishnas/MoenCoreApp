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
    public class ProductMetadataController : ControllerBase
    {
        private readonly IProductMetadataOperations productMetadataOperations;

        public ProductMetadataController(IProductMetadataOperations productMetadataOperations, ILogger<SupplierController> logger)
            : base(logger)
        {
            this.productMetadataOperations = productMetadataOperations;
        }

        [HttpGet("[action]")]
        public List<ProductMetaDataDTO> Get(int supplierId, int productid)
        {
            return this.productMetadataOperations.GetProductMetadata(supplierId, productid);
        }
    }
}
