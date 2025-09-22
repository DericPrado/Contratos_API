public interface IServicosPessoa
{
    public Task<Pessoa?> ObterPessoaPorDocumento(string documento);
    public Task<List<Pessoa>> ObterTodasPessoasAtivas();
    public Task<Pessoa?> AdicionarPessoa(RequestCadastraPessoa request);
    public Task<ResponseAtualizaPessoa> AtualizarPessoa(RequestAtualizaPessoa request);
    public Task<bool> DeletarPessoa(Guid id);
}