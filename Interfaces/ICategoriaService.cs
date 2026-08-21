using tienda_api_efcore.Models;
using tienda_api_efcore.DTOs;

namespace tienda_api_efcore.Interfaces
{
    public interface ICategoriaService
    {
        //Metodos del CRUD
        Task<List<CategoriaResponseDto>> GetAll();
        Task<CategoriaResponseDto?> GetById(int id);
        Task<CategoriaResponseDto> Create(CrearCategoriaDto dto);
        Task<CategoriaResponseDto?> Update(int id, ActualizarCategoriaDto dto);
        Task<bool> Delete(int id);
    }
}