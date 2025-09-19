public class Contrato
{
    public int ContratoId { get; set; }
    public int ServicoId { get; set; }
    public int ClienteId { get; set; }
    public int PrestadorId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }
}