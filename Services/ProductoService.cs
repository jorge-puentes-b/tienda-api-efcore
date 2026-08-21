using Microsoft.EntityFrameworkCore;
using tienda_api_efcore.Data;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Services
{
    public class ProductoService : IProductoService
    {
        private readonly TiendaDbContext _context;

        public ProductoService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductoResponseDto>> GetAllAsync()
        {
            return await _context.Productos
            .AsNoTracking() 
            .Select(p => new ProductoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria != null ? p.Categoria.Nombre : null
            })
            .ToListAsync();
        }

        public async Task<ProductoResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Productos
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new ProductoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria != null ? p.Categoria.Nombre : null
            })
            .FirstOrDefaultAsync();
        }

        public async Task<ProductoResponseDto> CreateAsync(CrearProductosDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Stock = dto.Stock,
                CategoriaId = dto.CategoriaId
            };
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return new ProductoResponseDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Precio = producto.Precio,
            Stock = producto.Stock,
            CategoriaId = producto.CategoriaId
        };
        }

        public async Task<bool> UpdateAsync(int id, ActualizarProductoDto dto)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;
                producto.Nombre = dto.Nombre;
                producto.Descripcion = dto.Descripcion;
                producto.Precio = dto.Precio;
                producto.Stock = dto.Stock;
                producto.CategoriaId = dto.CategoriaId;
            await _context.SaveChangesAsync();
            return true;
           
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}
