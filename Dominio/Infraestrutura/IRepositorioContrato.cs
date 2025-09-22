public interface IRepositorioContrato
{
    public Task<Contrato?> ObterContratoPorId(Guid id);
    public Task<List<Contrato>> ObterTodosContratosAtivos();
    public Task<bool> AdicionarContrato(Contrato contrato);
    public Task<bool> AtualizarContrato(Contrato contrato);
    public Task<bool> RemoverContrato(Guid id);
}