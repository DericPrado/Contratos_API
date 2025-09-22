public class ServicosPessoa : IServicosPessoa
{
    private readonly IRepositorioPessoa _repositorioPessoa;

    public ServicosPessoa(IRepositorioPessoa repositorioPessoa)
    {
        _repositorioPessoa = repositorioPessoa;
    }

    public async Task<Pessoa?> ObterPessoaPorDocumento(string documento)
    {
        return await _repositorioPessoa.ObterPessoaPorDocumento(documento);
    }

    public async Task<List<Pessoa>> ObterTodasPessoasAtivas()
    {
        return await _repositorioPessoa.ObterTodasPessoasAtivas();
    }

    public async Task<Pessoa?> AdicionarPessoa(RequestCadastraPessoa request)
    {
        var pessoa = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            CPF_CNPJ = request.CPF_CNPJ,
            Email = request.Email,
            Telefone = request.Telefone,
            Ativo = true
        };
        await _repositorioPessoa.AdicionarPessoa(pessoa);
        return pessoa;
    }

    public async Task<ResponseAtualizaPessoa> AtualizarPessoa(RequestAtualizaPessoa request)
    {
        var pessoa = await _repositorioPessoa.ObterPessoaPorDocumento(request.CPF_CNPJ);

        if (pessoa == null)
        {
            throw new Exception("Pessoa não encontrada.");
        }
        pessoa.Nome = request.Nome;
        pessoa.Email = request.Email;
        pessoa.Telefone = request.Telefone;

        await _repositorioPessoa.AtualizarPessoa(pessoa);
        return new ResponseAtualizaPessoa
        {
            Nome = pessoa.Nome,
            Email = pessoa.Email,
            Telefone = pessoa.Telefone
        };
    }

    public async Task<bool> DeletarPessoa(Guid id)
    {
        return await _repositorioPessoa.DeletarPessoa(id);
    }
}