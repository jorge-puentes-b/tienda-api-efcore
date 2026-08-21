using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.Data;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;
using Microsoft.EntityFrameworkCore;

namespace tienda_api_efcore.Services{
    public class ClienteService : IClienteService{
        private readonly TiendaDbContext _context;

        public ClienteService(TiendaDbContext context){
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync(){
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id){
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> CreateAsync(CrearClienteDto dto){
            var cliente = new Cliente{
                Nombre = dto.Nombre,
                Email = dto.Email,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                EstaActivo = dto.EstaActivo,
                FechaCreacion = DateTime.UtcNow
            };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(int id, ActualizarClienteDto dto){
            var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return false;
    
        cliente.Nombre = dto.Nombre;
        cliente.Email = dto.Email;
        cliente.Telefono = dto.Telefono;
        cliente.Direccion = dto.Direccion;
        cliente.EstaActivo = dto.EstaActivo;

        await _context.SaveChangesAsync();
        return true;
        }

        public async Task<bool> DeleteAsync(int id){
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null) return false;
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}