<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos Serviços
builder.Services.AddControllers();

// Configuração da Base de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? "Data Source=horadeaprender.db"));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>(); // Substitui AppDbContext pelo nome do teu DbContext
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrações na base de dados.");
    }
}

// Configuração do Pipeline HTTP (Swagger na raiz "/")
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HoraDeAprender API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
=======
var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contentor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o Swagger para funcionar em Produção e na Raiz
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HoraDeAprender API V1");
    c.RoutePrefix = string.Empty; // Faz o Swagger abrir diretamente na raiz (ex: horadeaprender.onrender.com)
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
>>>>>>> de2ee822d0f036437a66da93cefb029b32823161
