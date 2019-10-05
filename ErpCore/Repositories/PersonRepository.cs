using ErpCore.Domain;
using ErpCore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        readonly ErpContext Context;

        public PersonRepository(ErpContext context)
            => this.Context = context;

        public void Add(Person entity)
            => Context.People.Add(entity);

        public void Edit(Person entity)
            => Context.Entry(entity).State = EntityState.Modified;

        public bool Exist(string id)
            => Context.People.Any(e => e.Id.Equals(id) );

        public async Task<Person> Get(string id)
            => await Context.People.FindAsync(id);

        public async Task<IEnumerable<Person>> GetAll()
            => await Context.People.ToListAsync();

        public void Remove(Person entity)
            => Context.People.Remove(entity);
    }
}
