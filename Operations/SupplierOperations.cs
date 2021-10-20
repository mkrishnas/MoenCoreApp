using System;
using Operations.IOperations;
using System.Collections.Generic;
using DTOModels;
using Repository;
using Repository.IRepository;
using AutoMapper;
using System.Threading.Tasks;
using Models.Models;

namespace Operations
{
    public class SupplierOperations : ISupplierOperations
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        List<SupplierDTO> supplierDTO = new List<SupplierDTO>();

        public SupplierOperations(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<SupplierDTO> GetAllSuppliers()
        {
            var result = _unitOfWork.Supplier.GetAllSuppliers();
            var orgDTO = _mapper.Map<List<SupplierDTO>>(result);
            return orgDTO;
        }

        public async Task<SupplierDTO> GetSupplier(int supplierId)
        {            
            var result = await _unitOfWork.Supplier.GetAsync(supplierId);
            var orgDTO = _mapper.Map<SupplierDTO>(result);
            return orgDTO;
        }

        public List<SupplierInfoDTO> GetAllSuppliersInfo()
        {
            List<SupplierInfoDTO> lst = new List<SupplierInfoDTO>();
            
            var result = _unitOfWork.Supplier.GetAllSuppliersInfo();

            
            List<SupplierInfoDTO> lstObjSupplierInfoDTO = new List<SupplierInfoDTO>();

            foreach (var item in result)
            {
                string strProductName = string.Empty;
                List<string> strProductNames = new List<string>();
                SupplierInfoDTO objSupplierInfoDTO = new SupplierInfoDTO();

                objSupplierInfoDTO.SupplierName = item.Name;
                
                foreach (var productItem in item.SupplierProduct)
                {
                    strProductName = productItem.Product.Name;
                    strProductNames.Add(strProductName);
                }
                objSupplierInfoDTO.ProductName = strProductNames;
                lstObjSupplierInfoDTO.Add(objSupplierInfoDTO);                
            }

            lst = lstObjSupplierInfoDTO;
            var orgDTO = lst; //_mapper.Map<List<SupplierDTO>>(result);
            return orgDTO;
        }

        public async Task AddSupplier(string name)
        {
            Supplier supplier = new Supplier();
            supplier.Name = name;
            //supplier.Id = 9;
            await _unitOfWork.Supplier.AddAsync(supplier);
        }

        public async Task UpdateSupplier(string name)
        {
            Supplier supplier = await _unitOfWork.Supplier.GetAsync(7);
            supplier.Name = name;
            await _unitOfWork.Supplier.Update(supplier);
        }

        public async Task RemoveSupplier(int Id)
        {
            Supplier supplier = await _unitOfWork.Supplier.GetAsync(Id);
            await _unitOfWork.Supplier.RemoveAsync(supplier);
        }
    }
}
