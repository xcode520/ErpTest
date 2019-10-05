using ErpCore.Domain;
using ErpCore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly ErpContext Context;

        public ClientRepository(ErpContext context)
            => this.Context = context;

        public void Add(Client entity)
            => Context.Clients.Add(entity);

        public void Edit(Client entity)
            => Context.Entry(entity).State = EntityState.Modified;

        public bool Exist(string id)
            => Context.Clients.Any(e => e.Id.Equals(id)  );

        public async Task<Client> Get(string id)
            => await Context.Clients
            .Include(client => client.IdNavigation)
            .FirstOrDefaultAsync(client => client.Id.Equals(id));

        public async Task<IEnumerable<Client>> GetAll()
            => await Context.Clients
            .Include(client => client.IdNavigation)
            .ToListAsync();

        public void Remove(Client entity)
            => Context.Clients.Remove(entity);
    }
}
