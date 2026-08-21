using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.Data;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;
using Microsoft.EntityFrameworkCore;

namespace tienda_api_efcore.Services{
    public class DetalleVentaService : IDetalleVentaService{
        private readonly TiendaDbContext _context;

        public DetalleVentaService(TiendaDbContext context){
            _context = context;
        }

        public async Task<List<DetalleVenta>> GetAllAsync(){
            return await _context.DetalleVentas.ToListAsync();
        }

        public async Task<DetalleVenta?> GetByIdAsync(int id){
            return await _context.DetalleVentas.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DetalleVenta> CreateAsync(CrearDetalleVentaDto dto){
            var detalleVenta = new DetalleVenta{
                VentaId = dto.VentaId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario,
                Subtotal = dto.Cantidad * dto.PrecioUnitario
            };
            _context.DetalleVentas.Add(detalleVenta);
            await _context.SaveChangesAsync();
            return detalleVenta;
        }

        public async Task UpdateAsync(int id, ActualizarDetalleVentaDto dto){
            var detalleVenta = await _context.DetalleVentas.FindAsync(id);
            if (detalleVenta != null)
            {
                detalleVenta.VentaId = dto.VentaId;
                detalleVenta.ProductoId = dto.ProductoId;
                detalleVenta.Cantidad = dto.Cantidad;
                detalleVenta.PrecioUnitario = dto.PrecioUnitario;
                detalleVenta.Subtotal = dto.Cantidad * dto.PrecioUnitario;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id){
            var detalleVenta = await _context.DetalleVentas.FirstOrDefaultAsync(d => d.Id == id);
            if(detalleVenta != null){
                _context.DetalleVentas.Remove(detalleVenta);
                await _context.SaveChangesAsync();
            }
        }
    }
}