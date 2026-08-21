using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase{
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService){
            _ventaService = ventaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Venta>>> GetAllAsync(){
            return Ok(await _ventaService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta?>> GetByIdAsync(int id){
            var venta = await _ventaService.GetByIdAsync(id);
            if(venta == null){
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> CreateAsync(CrearVentaDto dto){
            var ventaCreada = await _ventaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = ventaCreada.Id }, ventaCreada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarVentaDto dto){
            await _ventaService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id){
            await _ventaService.DeleteAsync(id);
            return NoContent();
        }
    }
}   