using System;
using System.Collections.Generic;
using System.Text;
using Models.Models;
using DTOModels;

namespace Repository.IRepository
{
    public interface IProductMetadataRepository
    {
        List<ProductMetaDataDTO> GetProductMetadata(int supplierId, int productId);
        void CreateProductmetadata(ProductMetaDataDTO productMetaDataDTO);
    }
}
