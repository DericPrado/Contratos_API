using System.ComponentModel.DataAnnotations;

public class RequestCadastraContrato
{
    [Required]
    public Guid TrabalhoId { get; set; }
    [Required]
    public Guid ClienteId { get; set; }
    [Required]
    public Guid PrestadorId { get; set; }
    [Required]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public decimal Valor { get; set; }
}