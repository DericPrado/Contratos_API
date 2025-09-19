public class Pessoa
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CPF_CNPJ { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}