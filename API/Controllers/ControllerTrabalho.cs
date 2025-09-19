public static class ControllerTrabalho
{
    public static IEndpointRouteBuilder MapTrabalhoEndpoints(this WebApplication app)
    {
        app.MapGet("/trabalho", async (IServicosTrabalho servicosTrabalho) =>
        {
            var result = await servicosTrabalho.ObterTodosTrabalhosAtivos();
            return result.Any() ? Results.Ok(result) : Results.NotFound();
        });

        app.MapGet("/trabalho/{Id}", async (Guid id, IServicosTrabalho servicosTrabalho) =>
        {
            var result = await servicosTrabalho.ObterTrabalhoPorId(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        app.MapPost("/trabalho", async (RequestCadastraTrabalho request, IServicosTrabalho servicosTrabalho) =>
        {
            var result = await servicosTrabalho.AdicionarTrabalho(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });

        app.MapPut("/trabalho", async (RequestAtualizaTrabalho request, IServicosTrabalho servicosTrabalho) =>
        {
            var result = await servicosTrabalho.AtualizarTrabalho(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });

        app.MapDelete("/trabalho/{Id}", async (Guid id, IServicosTrabalho servicosTrabalho) =>
        {
            var result = await servicosTrabalho.DeletarTrabalho(id);
            return result ? Results.Ok(result) : Results.BadRequest();
        });

        return app;
    }
}