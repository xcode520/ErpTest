using ErpCore.Domain;
using ErpCore.IRepositories;
using System.Threading.Tasks;

namespace ErpCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ErpContext Context;

        public UnitOfWork(ErpContext context)
            => this.Context = context;

        public async Task CompleteAsync()
            => await Context.SaveChangesAsync();
    }
}
