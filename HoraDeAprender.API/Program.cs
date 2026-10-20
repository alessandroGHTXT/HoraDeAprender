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