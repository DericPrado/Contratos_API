public class Trabalho
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int DuracaoMediaDias { get; set; }
    public bool Ativo { get; set; } = true;
}