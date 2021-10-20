using System;
using System.Collections.Generic;
using System.Text;
using Models.Models;
using Repository.IRepository;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MOENPCMContext _db;

        public UnitOfWork(MOENPCMContext db)
        {
            _db = db;
            Supplier = new SupplierRepository(_db);
            ProductMetadata = new ProductMetadataRepository(_db);
            PCMRequest = new PCMRequestRepository(_db);
        }

        public ISupplierRepository Supplier { get; private set; }

        public IProductMetadataRepository ProductMetadata { get; private set; }

        public IPCMRequestRepository PCMRequest { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
