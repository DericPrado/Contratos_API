public interface IServicosTrabalho
{
    public Task<Trabalho?> AdicionarTrabalho(RequestCadastraTrabalho trabalho);
    public Task<ResponseAtualizaTrabalho> AtualizarTrabalho(RequestAtualizaTrabalho trabalho);
    public Task<bool> DeletarTrabalho(Guid id);
    public Task<Trabalho?> ObterTrabalhoPorId(Guid id);
    public Task<List<Trabalho>> ObterTodosTrabalhosAtivos();
}   