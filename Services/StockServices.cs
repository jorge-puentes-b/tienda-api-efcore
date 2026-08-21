using System.Collections.Generic;
using System.Threading.Tasks;
using tienda_api_efcore.Data;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;
using Microsoft.EntityFrameworkCore;

namespace tienda_api_efcore.Services{
    public class StockService : IStockService{
        private readonly TiendaDbContext _context;

        public StockService(TiendaDbContext context){
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync(){
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id){
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock> CreateAsync(CrearStockDto dto){
            var stock = new Stock{
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                FechaActualizacion = DateTime.UtcNow
            };
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task UpdateAsync(int id, ActualizarStockDto dto){
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                stock.ProductoId = dto.ProductoId;
                stock.Cantidad = dto.Cantidad;
                stock.FechaActualizacion = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id){
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if(stock != null){
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }
    }
}