public static class ControllerPessoa
{
    public static IEndpointRouteBuilder MapPessoaEndpoints(this WebApplication app)
    {
        app.MapGet("/pessoa", async (IServicosPessoa servicosPessoa) =>
        {
            var result = await servicosPessoa.ObterTodasPessoasAtivas();
            return result.Any() ? Results.Ok(result) : Results.NotFound();
        });

        app.MapGet("/pessoa/{Documento}", async (string documento, IServicosPessoa servicosPessoa) =>
        {
            var result = await servicosPessoa.ObterPessoaPorDocumento(documento);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        app.MapPost("/pessoa", async (RequestCadastraPessoa request, IServicosPessoa servicosPessoa) =>
        {
            var result = await servicosPessoa.AdicionarPessoa(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });

        app.MapPut("/pessoa", async (RequestAtualizaPessoa request, IServicosPessoa servicosPessoa) =>
        {
            var result = await servicosPessoa.AtualizarPessoa(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });

        app.MapDelete("/pessoa/{Id}", async (Guid id, IServicosPessoa servicosPessoa) =>
        {
            var result = await servicosPessoa.DeletarPessoa(id);
            return result ? Results.Ok(result) : Results.BadRequest();
        });

        return app;
    }
}