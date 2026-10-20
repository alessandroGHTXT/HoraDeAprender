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
