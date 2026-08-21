using System.Collections.Generic;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Interfaces{
    public interface IClienteService{
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(CrearClienteDto dto);
        Task<bool> UpdateAsync(int id, ActualizarClienteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}