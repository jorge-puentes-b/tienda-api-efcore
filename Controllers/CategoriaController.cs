using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tienda_api_efcore.Data;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;
using tienda_api_efcore.DTOs;

namespace tienda_api_efcore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        //Get All Categorias
        [HttpGet]
        public async Task<ActionResult<List<CategoriaResponseDto>>> Get(){
            var categorias = await _service.GetAll();
            return Ok(categorias);
        }

        //Get Categoria By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponseDto>> Get(int id)
        {
            var categoria = await _service.GetById(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        //Create Categoria
        [HttpPost]
        public async Task<ActionResult<CategoriaResponseDto>> Create(CrearCategoriaDto dto)
        {
            var categoria = await _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        //Update Categoria
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaResponseDto>> Update(int id, ActualizarCategoriaDto dto)
        {
            var categoria = await _service.Update(id, dto);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        //Delete Categoria
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaResponseDto>> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
