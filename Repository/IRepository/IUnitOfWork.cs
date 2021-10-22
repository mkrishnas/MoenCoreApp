using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        ISupplierRepository Supplier { get; }

        IProductMetadataRepository ProductMetadata { get; }

        IPCMRequestRepository PCMRequest { get; }

        IEmailQueueRepository EmailQueue { get; }

    }
}
