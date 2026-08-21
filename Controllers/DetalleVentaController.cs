using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : ControllerBase{
        private readonly IDetalleVentaService _detalleVentaService;

        public DetalleVentaController(IDetalleVentaService detalleVentaService){
            _detalleVentaService = detalleVentaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleVenta>>> GetAllAsync(){
            return Ok(await _detalleVentaService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta?>> GetByIdAsync(int id){
            var detalleVenta = await _detalleVentaService.GetByIdAsync(id);
            if(detalleVenta == null){
                return NotFound();
            }
            return Ok(detalleVenta);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> CreateAsync(CrearDetalleVentaDto dto){
            var detalleVentaCreado = await _detalleVentaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = detalleVentaCreado.Id }, detalleVentaCreado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarDetalleVentaDto dto){
            await _detalleVentaService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id){
            await _detalleVentaService.DeleteAsync(id);
            return NoContent();
        }
    }
}