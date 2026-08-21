using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase{
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService){
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllAsync(){
            return Ok(await _clienteService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente?>> GetByIdAsync(int id){
            var cliente = await _clienteService.GetByIdAsync(id);
            if(cliente == null){
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateAsync(CrearClienteDto dto){
            var clienteCreado = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = clienteCreado.Id }, clienteCreado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarClienteDto dto){
             var updated = await _clienteService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id){
            var deleted = await _clienteService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}