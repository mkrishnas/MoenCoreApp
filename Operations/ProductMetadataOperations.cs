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
        private readonly IUnitOfWork _unitOfWork;
        List<ProductMetaDataDTO> pcmRequestDTO = new List<ProductMetaDataDTO>();

        public ProductMetadataOperations(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void CreateProductmetadata(ProductMetaDataDTO productMetaDataDTO)
        {
            _unitOfWork.ProductMetadata.CreateProductmetadata(productMetaDataDTO);            
        }

        public List<ProductMetaDataDTO> GetProductMetadata(int supplierId, int productId)
        {
            List<ProductMetaDataDTO> productMetaDataDTO = new List<ProductMetaDataDTO>();
            productMetaDataDTO = _unitOfWork.ProductMetadata.GetProductMetadata(supplierId, productId);
            return productMetaDataDTO;
        }
    }
}
