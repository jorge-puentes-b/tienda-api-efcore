using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Interfaces{
    public interface IVentaService{
        Task<List<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int id);
        Task<Venta> CreateAsync(CrearVentaDto dto);
        Task UpdateAsync(int id, ActualizarVentaDto dto);
        Task DeleteAsync(int id);
    }
}