public static class ControllerContrato
{
    public static IEndpointRouteBuilder MapContratoEndpoints(this WebApplication app)
    {
        app.MapGet("/contratos", async (IServicosContrato servicosContrato) =>
        {
            var result = await servicosContrato.ObterTodosContratosAtivos();
            return result.Any() ? Results.Ok(result) : Results.NotFound();
        });

        app.MapGet("/contrato/{Id}", async (Guid id, IServicosContrato servicosContrato) =>
        {
            var result = await servicosContrato.ObterContratoPorId(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        app.MapPost("/contrato", async (RequestCadastraContrato request, IServicosContrato servicosContrato) =>
        {
            var result = await servicosContrato.AdicionarContrato(request);
            return result ? Results.Ok(result) : Results.BadRequest();
        });

        app.MapPut("/contrato", async (RequestAtualizarContrato request, IServicosContrato servicosContrato) =>
        {
            var result = await servicosContrato.AtualizarContrato(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest();
        });

        app.MapDelete("/contrato/{Id}", async (Guid id, IServicosContrato servicosContrato) =>
        {
            var result = await servicosContrato.RemoverContrato(id);
            return result ? Results.Ok(result) : Results.BadRequest();
        });

        return app;
    }
}