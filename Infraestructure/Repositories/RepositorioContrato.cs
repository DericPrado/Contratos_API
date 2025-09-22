public class RepositorioContrato : IRepositorioContrato
{
    private List<Contrato> _contratos = new List<Contrato>();
    private readonly IRepositorioPessoa _repositorioPessoa;
    private readonly IRepositorioTrabalho _repositorioTrabalho;

    public RepositorioContrato(IRepositorioPessoa repositorioPessoa, IRepositorioTrabalho repositorioTrabalho)
    {
        _repositorioPessoa = repositorioPessoa;
        _repositorioTrabalho = repositorioTrabalho;
    }

    public async Task<Contrato?> ObterContratoPorId(Guid id)
    {
        var contrato = _contratos.FirstOrDefault(c => c.ContratoId == id && c.Ativo);
        return await Task.FromResult(contrato);
    }

    public async Task<List<Contrato>> ObterTodosContratosAtivos()
    {
        var contratosAtivos = _contratos.Where(c => c.Ativo).ToList();
        return await Task.FromResult(contratosAtivos);
    }

    public async Task<bool> AdicionarContrato(Contrato contrato)
    {
        try
        {
            var cliente = await _repositorioPessoa.ObterPessoaPorId(contrato.ClienteId);
            var prestador = await _repositorioPessoa.ObterPessoaPorId(contrato.PrestadorId);
            var trabalho = await _repositorioTrabalho.ObterTrabalhoPorId(contrato.TrabalhoId);

            if (cliente == null || prestador == null || trabalho == null || !cliente.Ativo || !prestador.Ativo || !trabalho.Ativo)
            {
                return false;
            }

            contrato.ContratoId = Guid.NewGuid();
            contrato.ClienteId = cliente.Id;
            contrato.PrestadorId = prestador.Id;
            contrato.TrabalhoId = trabalho.Id;
            contrato.DataInicio = DateTime.Now;
            contrato.DataFim = DateTime.Now.AddDays(30);
            contrato.Valor = trabalho.Preco * 1.2m; // Adiciona 20% de taxa
            _contratos.Add(contrato);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> AtualizarContrato(Contrato contrato)
    {
        var contratoExistente = await ObterContratoPorId(contrato.ContratoId);
        if (contratoExistente == null)
        {
            return false;
        }

        contratoExistente.Descricao = contrato.Descricao;
        contratoExistente.DataInicio = contrato.DataInicio;
        contratoExistente.DataFim = contrato.DataFim;
        contratoExistente.Valor = contrato.Valor;
        contratoExistente.Descricao = contrato.Descricao;
        return true;
    }

    public async Task<bool> RemoverContrato(Guid id)
    {
        var contrato = await ObterContratoPorId(id);
        if (contrato == null)
        {
            return false;
        }
        contrato.Ativo = false;
        return true;
    }
}