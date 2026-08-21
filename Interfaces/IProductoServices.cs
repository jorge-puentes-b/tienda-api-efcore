using tienda_api_efcore.Models;
using tienda_api_efcore.DTOs;

namespace tienda_api_efcore.Interfaces;

public interface IProductoService
{
    Task<IEnumerable<ProductoResponseDto>> GetAllAsync();
    Task<ProductoResponseDto?> GetByIdAsync(int id);
    Task<ProductoResponseDto> CreateAsync(CrearProductosDto dto);
    Task<bool> UpdateAsync(int id, ActualizarProductoDto dto);
    Task<bool> DeleteAsync(int id);
}