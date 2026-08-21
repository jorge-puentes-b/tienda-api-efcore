using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class ActualizarCategoriaDto{
    //Anotaciones con Data Annotation
    [Required]
    public int Id { get; set; }
    
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
