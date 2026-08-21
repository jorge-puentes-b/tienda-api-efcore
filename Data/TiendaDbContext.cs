using Microsoft.EntityFrameworkCore;
using tienda_api_efcore.Models;
namespace tienda_api_efcore.Data;

public class TiendaDbContext : DbContext{
    public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options){}

    public DbSet<Producto> Productos { get; set; } 
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Electronica", Descripcion = "Productos electronicos", EstaActiva = true, FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Categoria { Id = 2, Nombre = "Ropa", Descripcion = "Ropa para hombres y mujeres", EstaActiva = true, FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Categoria { Id = 3, Nombre = "Hogar", Descripcion = "Articulos para el hogar", EstaActiva = true, FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Laptop", Descripcion = "Laptop de alta calidad", Precio = 1000, Stock = 10, CategoriaId = 1 },
            new Producto { Id = 2, Nombre = "Telefono", Descripcion = "Telefono de alta calidad", Precio = 500, Stock = 20, CategoriaId = 1 },
            new Producto { Id = 3, Nombre = "Camiseta", Descripcion = "Camiseta de algodon", Precio = 10, Stock = 30, CategoriaId = 2 },
            new Producto { Id = 4, Nombre = "Pantalon", Descripcion = "Pantalon de algodon", Precio = 20, Stock = 40, CategoriaId = 2 },
            new Producto { Id = 5, Nombre = "Silla", Descripcion = "Silla de oficina", Precio = 50, Stock = 50, CategoriaId = 3 },
            new Producto { Id = 6, Nombre = "Mesa", Descripcion = "Mesa de comedor", Precio = 100, Stock = 60, CategoriaId = 3 }
        );
    }

}