public interface IRepositorioTrabalho
{
    public Task<bool> AdicionarTrabalho(Trabalho trabalho);
    public Task<bool> AtualizarTrabalho(Trabalho trabalho);
    public Task<bool> DeletarTrabalho(Guid id);
    public Task<Trabalho?> ObterTrabalhoPorId(Guid id);
    public Task<List<Trabalho>> ObterTodosTrabalhosAtivos();
}