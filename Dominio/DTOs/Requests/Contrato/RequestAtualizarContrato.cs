public class RequestAtualizarContrato
{
    public Guid ContratoId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }
}