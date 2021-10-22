using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTOModels;

namespace Operations.IOperations
{
    public interface ISupplierOperations
    {
        List<SupplierDTO> GetAllSuppliers();

        List<SupplierInfoDTO> GetAllSuppliersInfo();

        Task<SupplierDTO> GetSupplier(int supplierId);

        Task AddSupplier(string name);

        Task UpdateSupplier(string name);

        Task RemoveSupplier(int Id);

        Task SendCostEmailToSupplier(int supplierId);

    }
}
