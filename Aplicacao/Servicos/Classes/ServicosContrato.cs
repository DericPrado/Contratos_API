public class ServicosContrato : IServicosContrato
{
    private readonly IRepositorioContrato _repositorioContrato;

    public ServicosContrato(IRepositorioContrato repositorioContrato)
    {
        _repositorioContrato = repositorioContrato;
    }

    public async Task<Contrato?> ObterContratoPorId(Guid id)
    {
        return await _repositorioContrato.ObterContratoPorId(id);
    }

    public async Task<List<Contrato>> ObterTodosContratosAtivos()
    {
        return await _repositorioContrato.ObterTodosContratosAtivos();
    }

    public async Task<bool> AdicionarContrato(RequestCadastraContrato contrato)
    {
        var novoContrato = new Contrato
        {
            TrabalhoId = contrato.TrabalhoId,
            ClienteId = contrato.ClienteId,
            PrestadorId = contrato.PrestadorId,
            Descricao = contrato.Descricao,
            DataInicio = contrato.DataInicio,
            Valor = contrato.Valor
        };
        return await _repositorioContrato.AdicionarContrato(novoContrato);
    }

    public async Task<ResponseAtualizarContrato> AtualizarContrato(RequestAtualizarContrato contrato)
    {
        var contratoExistente = await _repositorioContrato.ObterContratoPorId(contrato.ContratoId);
        if (contratoExistente == null)
        {
            throw new Exception("Contrato não encontrado.");
        }
        contratoExistente.Descricao = contrato.Descricao;
        contratoExistente.DataInicio = contrato.DataInicio;
        contratoExistente.Valor = contrato.Valor;
        contratoExistente.DataFim = contrato.DataFim;


        await _repositorioContrato.AtualizarContrato(contratoExistente);

        return new ResponseAtualizarContrato
        {
            Descricao = contratoExistente.Descricao,
            DataInicio = contratoExistente.DataInicio,
            DataFim = contratoExistente.DataFim,
            Valor = contratoExistente.Valor
        };
    }

    public async Task<bool> RemoverContrato(Guid id)
    {
        var contratoExistente = await _repositorioContrato.ObterContratoPorId(id);
        if (contratoExistente == null)
        {
            throw new Exception("Contrato não encontrado.");
        }

        return await _repositorioContrato.RemoverContrato(contratoExistente.ContratoId);
    }
}