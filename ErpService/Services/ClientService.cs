using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ErpCore.Domain;
using ErpCore.IRepositories;
using ErpModels.ModelItems;
using ErpModels.Models;
using ErpService.IServices;
using GenericTools;
using Microsoft.EntityFrameworkCore;

namespace ErpService.Services
{
    public class ClientService : IClientService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork Work;
        readonly IClientRepository Repository;
        readonly IPersonRepository PersonRepository;

        public ClientService(
            IMapper mapper , 
            IClientRepository repository, 
            IUnitOfWork work,
            IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
            this.Work = work;
            this.Repository = repository;
            this.Mapper = mapper;
        }

        public void Add(ClientModel model)
        {
            if (model != null)
            {
                model.Id = KeyGenerator.GetNewId();
                model.IdNavigation.Id = model.Id;
                var client = Mapper.Map<Client>(model);
                Repository.Add(client);
                Work.CompleteAsync();
            }
        }

        public int Edit(string id, ClientModel model)
        {
            if (model != null)
            {
                if (!id.Equals(model.Id))
                {
                    return 1;
                }
                var client = Mapper.Map<Client>(model);
                PersonRepository.Edit(client.IdNavigation);
                try
                {
                    Work.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Repository.Exist(id))
                    {
                        return 2;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return 2;
            }
            return 3;
        }

        public async Task<ClientItem> Get(string id)
        {
            var client = await Repository.Get(id);
            var item = Mapper.Map<ClientItem>(client);
            return item;
        }

        public async Task<IEnumerable<ClientItem>> GetAll()
        {
            var clients = await Repository.GetAll();
            var items = Mapper.Map<IEnumerable<ClientItem>>(clients);
            return items;
        }

        public void Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var client = Repository.Get(id).Result;
                Repository.Remove(client);
                Work.CompleteAsync();
            }
        }
    }
}
