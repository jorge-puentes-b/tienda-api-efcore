using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class CrearCategoriaDto{
    //Anotaciones con Data Annotation
    [StringLength(100)]
    [Required]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(250)]
    [Required]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    public bool EstaActiva { get; set; }
    }
}    
   