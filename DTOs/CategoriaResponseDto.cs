using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs;

public class CategoriaResponseDto
{   
    //Anotaciones con Data Annotation
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Nombre { get; set; } = string.Empty;
    
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    
    [Required]
    public bool EstaActiva { get; set; }
}
