public class RepositorioTrabalho : IRepositorioTrabalho
{
    private readonly List<Trabalho> _trabalhos = new List<Trabalho>();

    public Task<Trabalho?> ObterTrabalhoPorId(Guid id)
    {
        var trabalho = _trabalhos.FirstOrDefault(t => t.Id == id && t.Ativo);
        return Task.FromResult(trabalho);
    }
    public Task<List<Trabalho>> ObterTodosTrabalhosAtivos()
    {
        var trabalhosAtivos = _trabalhos.Where(t => t.Ativo).ToList();
        return Task.FromResult(trabalhosAtivos);
    }

    public Task<bool> AdicionarTrabalho(Trabalho trabalho)
    {
        if (_trabalhos.Any(t => t.Nome.Equals(trabalho.Nome) && t.Ativo))
            return Task.FromResult(false);

        trabalho.Id = Guid.NewGuid();
        _trabalhos.Add(trabalho);
        return Task.FromResult(true);
    }

    public Task<bool> AtualizarTrabalho(Trabalho trabalho)
    {
        var trabalhoExistente = ObterTrabalhoPorId(trabalho.Id).Result;
        if (trabalhoExistente == null)
            return Task.FromResult(false);

        trabalhoExistente.Nome = trabalho.Nome;
        trabalhoExistente.Descricao = trabalho.Descricao;
        trabalhoExistente.Preco = trabalho.Preco;
        trabalhoExistente.DuracaoMediaDias = trabalho.DuracaoMediaDias;

        return Task.FromResult(true);
    }

    public Task<bool> DeletarTrabalho(Guid id)
    {
        var trabalhoExistente = ObterTrabalhoPorId(id).Result;
        if (trabalhoExistente == null)
            return Task.FromResult(false);

        trabalhoExistente.Ativo = false;
        return Task.FromResult(true);
    }
}