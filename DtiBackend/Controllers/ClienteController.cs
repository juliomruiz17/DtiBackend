using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DtiBackend.Models;
using DtiBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DtiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private IClienteCollection db = new ClienteCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            return Ok(await db.GetAllClientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteDetails(string id)
        {
            return Ok(await db.GetClientById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (cliente.Nome == string.Empty)
            {
                ModelState.AddModelError("Name", "O cliente não pode ser Nulo o Vazio ");
            }
            await db.InsertCliente(cliente);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente([FromBody] Cliente cliente, string id)
        {
            if (cliente == null)
                return BadRequest();

            if (cliente.Nome == string.Empty)
            {
                ModelState.AddModelError("Name", "O cliente não pode ser Nulo o Vazio ");
            }

            cliente.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateCliente(cliente);

            return Created("Created", true);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCliente(string id)
        {
            await db.DeleteCliente(id);

            return NoContent();  //success
        }
    }
    
    
}
