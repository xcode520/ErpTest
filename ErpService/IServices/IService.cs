using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpService.IServices
{
    public interface IService<Model, ModelItem>
    {
        Task<ModelItem> Get(string id);
        Task<IEnumerable<ModelItem>> GetAll();

        void Add(Model model);
        int Edit(string id, Model model);
        void Remove(string id);
    }
}
