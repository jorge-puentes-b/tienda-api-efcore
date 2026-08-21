using System.ComponentModel.DataAnnotations;

namespace tienda_api_efcore.DTOs{   
    public class ActualizarProductoDto{
        //Anotaciones con Data Annotation
        [Required]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        [Required]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
    }
}
