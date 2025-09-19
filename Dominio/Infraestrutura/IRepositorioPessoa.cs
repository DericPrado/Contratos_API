public interface IRepositorioPessoa
{
    public Task<bool> AdicionarPessoa(Pessoa pessoa);
    public Task<bool> AtualizarPessoa(Pessoa pessoa);
    public Task<bool> DeletarPessoa(Guid id);
    public Task<Pessoa?> ObterPessoaPorDocumento(string documento);
    public Task<Pessoa?> ObterPessoaPorId(Guid id);
    public Task<List<Pessoa>> ObterTodasPessoasAtivas();

}