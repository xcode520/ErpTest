using System.Threading.Tasks;
using ErpModels.ModelItems;
using ErpModels.Models;
using ErpService.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ErpTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        readonly IClientService Service;
        public ClientController(IClientService service) 
            => this.Service = service;

        // GET: Client
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Service.GetAll();
            return Ok(result);
        }

        // GET: Client/5
        [HttpGet("{id}", Name = "GetClient")]
        public async Task<ClientItem> Get(string id) 
            => await Service.Get(id);

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] ClientModel model) 
            => Service.Add(model);

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ClientModel model)
        {
            var result = Service.Edit(id, model);
            if (result == 1)
            {
                return BadRequest();
            }
            if (result == 2)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id) 
            => Service.Remove(id);
    }
}
