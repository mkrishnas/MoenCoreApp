using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Repository.IRepository;
using DTOModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Repository
{
    public class ProductMetadataRepository : IProductMetadataRepository
    {
        private readonly MOENPCMContext _context;
        public ProductMetadataRepository(MOENPCMContext context)
        {
            _context = context;
        }

        public void CreateProductmetadata(ProductMetaDataDTO productMetaDataDTO)
        {

            throw new NotImplementedException();
        }

        public List<ProductMetaDataDTO> GetProductMetadata(int supplierId, int productId)
        {
            //supplierId = !string.IsNullOrEmpty(supplierId) ? supplierId : "";
            //productId = !string.IsNullOrEmpty(productId) ? productId : "";
            List<ProductMetaDataDTO> lstProductMetadataDTO = new List<ProductMetaDataDTO>();
            var parameters = new[] {
            new SqlParameter("@SupplierId", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = supplierId },
            new SqlParameter("@ProductId", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = productId }
        };
            
            lstProductMetadataDTO = (List<ProductMetaDataDTO>)_context.ProductMetaDataDTOs.FromSqlRaw("[dbo].[SP_GetProductMetadata] @SupplierId,@ProductId", parameters).ToList();
            return lstProductMetadataDTO;            
        }
    }
}
