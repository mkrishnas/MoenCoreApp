using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepository
{
    public interface ISupplierRepository: IRepositoryAsync<Supplier>
    {
        //Returns supplier table data
        List<Supplier> GetAllSuppliers();

        //Returns all the tables data referenced by supplier
        List<Supplier> GetAllSuppliersInfo();
    }
}
