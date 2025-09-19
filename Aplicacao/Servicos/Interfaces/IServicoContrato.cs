public interface IServicoContrato
{
    public Task<Contrato?> ObterContratoPorId(Guid id);
    public Task<List<Contrato>> ObterTodosContratosAtivos();
    public Task<bool> AdicionarContrato(RequestCadastraContrato contrato);
    public Task<ResponseAtualizarContrato> AtualizarContrato(RequestAtualizarContrato contrato);
    public Task<bool> RemoverContrato(Guid id);
}