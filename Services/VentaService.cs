using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.Data;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;
using Microsoft.EntityFrameworkCore;

namespace tienda_api_efcore.Services{
    public class VentaService : IVentaService{
        private readonly TiendaDbContext _context;

        public VentaService(TiendaDbContext context){
            _context = context;
        }

        public async Task<List<Venta>> GetAllAsync(){
            return await _context.Ventas.ToListAsync();
        }

        public async Task<Venta?> GetByIdAsync(int id){
            return await _context.Ventas.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Venta> CreateAsync(CrearVentaDto dto){
            var venta = new Venta{
                ClienteId = dto.ClienteId,
                FechaVenta = dto.FechaVenta == default ? DateTime.UtcNow : dto.FechaVenta,
                Total = dto.Total
            };
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task UpdateAsync(int id, ActualizarVentaDto dto){
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                venta.ClienteId = dto.ClienteId;
                venta.FechaVenta = dto.FechaVenta;
                venta.Total = dto.Total;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id){
            var venta = await _context.Ventas.FirstOrDefaultAsync(v => v.Id == id);
            if(venta != null){
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }

    }
}