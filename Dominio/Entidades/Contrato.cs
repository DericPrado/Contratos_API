public class Contrato
{
    public Guid ContratoId { get; set; }
    public Guid TrabalhoId { get; set; }
    public Guid ClienteId { get; set; }
    public Guid PrestadorId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }
    public bool Ativo { get; set; } = true;
}