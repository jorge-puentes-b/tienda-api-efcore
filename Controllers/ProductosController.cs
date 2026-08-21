namespace tienda_api_efcore.Controllers;

using Microsoft.AspNetCore.Mvc;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoResponseDto>>> GetAll()
    {
        var productos = await _productoService.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoResponseDto>> GetById(int id)
    {
        var producto = await _productoService.GetByIdAsync(id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductoResponseDto>> Create(CrearProductosDto dto)
    {
        var createdProduct = await _productoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ActualizarProductoDto dto)
    {
        var updated = await _productoService.UpdateAsync(id, dto);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _productoService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
