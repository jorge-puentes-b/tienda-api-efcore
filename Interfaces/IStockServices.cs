using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Interfaces{
    public interface IStockService{
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(CrearStockDto dto);
        Task UpdateAsync(int id, ActualizarStockDto dto);
        Task DeleteAsync(int id);
    }
}