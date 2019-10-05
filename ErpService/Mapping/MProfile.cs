using AutoMapper;
using ErpCore.Domain;
using ErpModels.ModelItems;
using ErpModels.Models;

namespace ErpService.Mapping
{
    public class MProfile : Profile
    {
        public MProfile()
        {
            CreateMap<Person , PersonModel>();
            CreateMap<PersonModel, Person>();
            CreateMap<Person ,PersonItem>();
            CreateMap<PersonItem, Person>();

            CreateMap<Client , ClientModel>();
            CreateMap<ClientModel, Client>();
            CreateMap<Client,ClientItem>();
            CreateMap<ClientItem, Client>();

        }
    }
}
