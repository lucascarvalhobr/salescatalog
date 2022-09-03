using System.Threading.Tasks;

namespace SalesCatalog.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
