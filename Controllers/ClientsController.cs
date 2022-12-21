using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IClientService _clientsService;

        public ClientsController(IClientService clientsService)
        {
            _clientsService = clientsService;
        }

        // GET: api/Clients
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return _clientsService.GetAll();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(Guid id)
        {
            var client =  _clientsService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Client> PutClient(Guid id, Client client)
        {
            try
            {
                _clientsService.Update(id, client);
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return client;
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Client> PostClient(Client client)
        {
            client.clientId = new Guid();
            _clientsService.Create(client);
            return CreatedAtAction("GetClient",
                                   client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            try
            {
                _clientsService.Delete(id);
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}
