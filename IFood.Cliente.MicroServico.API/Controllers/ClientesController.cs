using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFood.Cliente.Domain.Cliente;
using IFood.Cliente.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace IFood.Cliente.MicroServico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> add(ClienteModel cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var _cliente = await _clienteService.add(cliente);

                return Created(
                        $"cliente/{cliente.id}",
                        cliente
                   );
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }
       
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                return Ok(_clienteService.getAll());
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> get(string id)
        {
            try
            {
                var cliente = await _clienteService.get(id);
                if (cliente is null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> update(string id, ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                    return BadRequest(ModelState);

                var _cliente = _clienteService.update(cliente);
                return Ok(_cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }
        
    }
}
