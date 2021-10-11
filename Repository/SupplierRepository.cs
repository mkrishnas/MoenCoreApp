using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Repository.IRepository;

namespace Repository
{
    public class SupplierRepository : RepositoryAsync<Supplier>, ISupplierRepository
    {
        private readonly MOENPCMContext _context;
        public SupplierRepository(MOENPCMContext context) : base(context)
        {
            this._context = context;
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> lststring = new List<Supplier>();
            lststring = _context.Supplier.ToList();
            return lststring;
        }

        public List<Supplier> GetAllSuppliersInfo()
        {
            using (var ctx = _context)
            {
                var cq = ctx.Supplier
                .Include(p => p.SupplierProduct).ThenInclude(pi => pi.Product)
                .Include(p => p.ProductMetaData).ThenInclude(pi => pi.Product)                
                .AsNoTracking();
                 return cq.ToList();   
            }
        }
    }
}
