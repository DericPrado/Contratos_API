public class RepositorioPessoa : IRepositorioPessoa
{
    private List<Pessoa> pessoas = new List<Pessoa>();

    public async Task<List<Pessoa>> ObterTodasPessoasAtivas()
    {
        var result = pessoas.Where(p => p.Ativo).ToList();
        return await Task.FromResult(result);
    }

    public async Task<Pessoa?> ObterPessoaPorDocumento(string documento)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.CPF_CNPJ == documento && p.Ativo);
        return await Task.FromResult(pessoa);
    }

    public async Task<bool> AdicionarPessoa(Pessoa pessoa)
    {
        try
        {
            pessoas.Add(pessoa);
            return await Task.FromResult(true);
        }
        catch
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> AtualizarPessoa(Pessoa pessoa)
    {
        try
        {
            var pessoaExistente = pessoas.FirstOrDefault(p => p.Id == pessoa.Id);
            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.CPF_CNPJ = pessoa.CPF_CNPJ;
                pessoaExistente.Ativo = pessoa.Ativo;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch
        {
            return await Task.FromResult(false);
        }
    }


    public async Task<bool> DeletarPessoa(Guid id)
    {
        try
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa != null)
            {
                pessoa.Ativo = false;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch
        {
            return await Task.FromResult(false);
        }
    }
}