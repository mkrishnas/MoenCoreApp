using System;
using Operations.IOperations;
using System.Collections.Generic;
using DTOModels;
using Repository;
using Repository.IRepository;
using AutoMapper;
using Models.Models;

namespace Operations
{
    public class ProductMetadataOperations : IProductMetadataOperations
    {
        private readonly IMapper _mapper;
        private readonly IProductMetadataRepository _productMetadataRepository;
        List<ProductMetaDataDTO> pcmRequestDTO = new List<ProductMetaDataDTO>();

        public ProductMetadataOperations(IProductMetadataRepository productMetadataRepository, IMapper mapper)
        {
            _productMetadataRepository = productMetadataRepository;
            _mapper = mapper;
        }

        public void CreateProductmetadata(ProductMetaDataDTO productMetaDataDTO)
        {
            _productMetadataRepository.CreateProductmetadata(productMetaDataDTO);            
        }

        public List<ProductMetaDataDTO> GetProductMetadata(int supplierId, int productId)
        {
            List<ProductMetaDataDTO> productMetaDataDTO = new List<ProductMetaDataDTO>();
            productMetaDataDTO = _productMetadataRepository.GetProductMetadata(supplierId, productId);
            return productMetaDataDTO;
        }
    }
}
