using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpCore.IRepositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        bool Exist(string id);

        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Remove(TEntity entity);
    }
}
