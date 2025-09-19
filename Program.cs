var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IServicosPessoa, ServicosPessoa>();
builder.Services.AddTransient<IServicosTrabalho, ServicosTrabalho>();
builder.Services.AddTransient<IServicosContrato, ServicosContrato>();
builder.Services.AddSingleton<IRepositorioPessoa, RepositorioPessoa>();
builder.Services.AddSingleton<IRepositorioTrabalho, RepositorioTrabalho>();
builder.Services.AddSingleton<IRepositorioContrato, RepositorioContrato>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPessoaEndpoints();
app.MapTrabalhoEndpoints();
app.MapContratoEndpoints();

app.Run();
