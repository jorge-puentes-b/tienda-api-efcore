using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase{
        private readonly IStockService _stockService;

        public StockController(IStockService stockService){
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAllAsync(){
            return Ok(await _stockService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock?>> GetByIdAsync(int id){
            var stock = await _stockService.GetByIdAsync(id);
            if(stock == null){
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public async Task<ActionResult<Stock>> CreateAsync(CrearStockDto dto){
            var stockCreado = await _stockService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockCreado.Id }, stockCreado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarStockDto dto){
            await _stockService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id){
            await _stockService.DeleteAsync(id);
            return NoContent();
        }
    }
}