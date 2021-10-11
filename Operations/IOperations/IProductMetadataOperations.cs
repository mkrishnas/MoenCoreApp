using System;
using System.Collections.Generic;
using System.Text;
using DTOModels;
using Models.Models;

namespace Operations.IOperations
{
    public interface IProductMetadataOperations
    {
        List<ProductMetaDataDTO> GetProductMetadata(int supplierId, int productId);

        void CreateProductmetadata(ProductMetaDataDTO productMetaDataDTO);
    }
}
