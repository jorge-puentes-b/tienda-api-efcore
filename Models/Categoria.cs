namespace tienda_api_efcore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public bool EstaActiva { get; set; }

        // Navegation properties
        public ICollection<Producto> Productos { get; set; } = new HashSet<Producto>();
    }
}
