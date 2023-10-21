using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class VentaDto
{
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public int EmpleadoId  { get; set; }
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int FormaPagoId { get; set; }

}