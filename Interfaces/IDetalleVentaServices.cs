using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Interfaces{
    public interface IDetalleVentaService{
        Task<List<DetalleVenta>> GetAllAsync();
        Task<DetalleVenta?> GetByIdAsync(int id);
        Task<DetalleVenta> CreateAsync(CrearDetalleVentaDto dto);
        Task UpdateAsync(int id, ActualizarDetalleVentaDto dto);
        Task DeleteAsync(int id);
    }
}