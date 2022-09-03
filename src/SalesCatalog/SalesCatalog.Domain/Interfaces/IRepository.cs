using System;

namespace SalesCatalog.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
