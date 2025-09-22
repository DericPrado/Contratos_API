public class ServicosTrabalho : IServicosTrabalho
{
    private readonly IRepositorioTrabalho _repositorioTrabalho;

    public ServicosTrabalho(IRepositorioTrabalho repositorioTrabalho)
    {
        _repositorioTrabalho = repositorioTrabalho;
    }

    public async Task<List<Trabalho>> ObterTodosTrabalhosAtivos()
    {
        return await _repositorioTrabalho.ObterTodosTrabalhosAtivos();
    }

    public Task<Trabalho?> ObterTrabalhoPorId(Guid id)
    {
        return _repositorioTrabalho.ObterTrabalhoPorId(id);
    }

    public async Task<Trabalho?> AdicionarTrabalho(RequestCadastraTrabalho request)
    {
        var novoTrabalho = new Trabalho
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Descricao = request.Descricao,
            Preco = request.Preco,
            DuracaoMediaDias = request.DuracaoMediaDias,
            Ativo = true
        };

        await _repositorioTrabalho.AdicionarTrabalho(novoTrabalho);
        return novoTrabalho;
    }

    public async Task<ResponseAtualizaTrabalho> AtualizarTrabalho(RequestAtualizaTrabalho request)
    {
        var trabalhoExistente = _repositorioTrabalho.ObterTrabalhoPorId(request.Id).Result;
        if (trabalhoExistente == null)
            throw new Exception("Trabalho não encontrado");
        trabalhoExistente.Nome = request.Nome;
        trabalhoExistente.Descricao = request.Descricao;
        trabalhoExistente.Preco = request.Preco;
        trabalhoExistente.DuracaoMediaDias = request.DuracaoMediaDias;
        await _repositorioTrabalho.AtualizarTrabalho(trabalhoExistente);
        return new ResponseAtualizaTrabalho
        {
            Nome = trabalhoExistente.Nome,
            Descricao = trabalhoExistente.Descricao,
            Preco = trabalhoExistente.Preco,
            DuracaoMediaDias = trabalhoExistente.DuracaoMediaDias
        };
    }

    public Task<bool> DeletarTrabalho(Guid id)
    {
        return _repositorioTrabalho.DeletarTrabalho(id);
    }

}