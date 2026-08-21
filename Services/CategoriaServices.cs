using Microsoft.EntityFrameworkCore;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Data;
using tienda_api_efcore.Interfaces;
using tienda_api_efcore.Models;

namespace tienda_api_efcore.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly TiendaDbContext _context;

        public CategoriaService(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaResponseDto>> GetAll()
        {
            return await _context.Categorias.Select(c => new CategoriaResponseDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                EstaActiva = c.EstaActiva
            }).ToListAsync();
        }

        public async Task<CategoriaResponseDto?> GetById(int id)
        {
            return await _context.Categorias.Select(c => new CategoriaResponseDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                EstaActiva = c.EstaActiva
            }).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CategoriaResponseDto> Create(CrearCategoriaDto dto)
        {
            var categoria = new Categoria
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaCreacion = DateTime.Now,
                EstaActiva = true
            };
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                EstaActiva = categoria.EstaActiva
            };
        }

        public async Task<CategoriaResponseDto?> Update(int id, ActualizarCategoriaDto dto)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                categoria.Nombre = dto.Nombre;
                categoria.Descripcion = dto.Descripcion;
                categoria.EstaActiva = dto.EstaActiva;
                await _context.SaveChangesAsync();
                return new CategoriaResponseDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion,
                    EstaActiva = categoria.EstaActiva
                };
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
