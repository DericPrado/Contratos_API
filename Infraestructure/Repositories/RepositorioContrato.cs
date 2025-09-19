public class RepositorioContrato : IRepositorioContrato
{
    private readonly List<Contrato> _contratos;
    private readonly IRepositorioPessoa _repositorioPessoa;
    private readonly IRepositorioTrabalho _repositorioTrabalho;

    public Task<Contrato?> ObterContratoPorId(Guid id)
    {
        var contrato = _contratos.FirstOrDefault(c => c.ContratoId == id && c.Ativo);
        return Task.FromResult(contrato);
    }

    public Task<List<Contrato>> ObterTodosContratosAtivos()
    {
        var contratosAtivos = _contratos.Where(c => c.Ativo).ToList();
        return Task.FromResult(contratosAtivos);
    }

    public Task<bool> AdicionarContrato(Contrato contrato)
    {
        try
        {
            var cliente = _repositorioPessoa.ObterPessoaPorId(contrato.ClienteId).Result;
            var prestador = _repositorioPessoa.ObterPessoaPorId(contrato.PrestadorId).Result;
            var trabalho = _repositorioTrabalho.ObterTrabalhoPorId(contrato.TrabalhoId).Result;

            if (cliente == null || prestador == null || trabalho == null || !cliente.Ativo || !prestador.Ativo || !prestador.Ativo || !trabalho.Ativo)
            {
                return Task.FromResult(false);
            }

            contrato.ClienteId = cliente.Id;
            contrato.PrestadorId = prestador.Id;
            contrato.TrabalhoId = trabalho.Id;
            contrato.ContratoId = Guid.NewGuid();
            contrato.Descricao = trabalho.Descricao;
            contrato.DataInicio = DateTime.Now;
            contrato.DataFim = DateTime.Now.AddDays(trabalho.DuracaoMediaDias);
            contrato.Valor = trabalho.Preco * 1.2m; // Adiciona 20% de taxa
            _contratos.Add(contrato);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public Task<bool> AtualizarContrato(Contrato contrato)
    {
        var contratoExistente = ObterContratoPorId(contrato.ContratoId).Result;
        if (contratoExistente == null)
        {
            return Task.FromResult(false);
        }

        contratoExistente.Descricao = contrato.Descricao;
        contratoExistente.DataInicio = contrato.DataInicio;
        contratoExistente.DataFim = contrato.DataFim;
        contratoExistente.Valor = contrato.Valor;
        contratoExistente.Descricao = contrato.Descricao;
        return Task.FromResult(true);
    }

    public Task<bool> RemoverContrato(Guid id)
    {
        var contrato = ObterContratoPorId(id).Result;
        if (contrato == null)
        {
            return Task.FromResult(false);
        }
        contrato.Ativo = false;
        return Task.FromResult(true);
    }
}