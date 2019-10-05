using System.Threading.Tasks;

namespace ErpCore.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
