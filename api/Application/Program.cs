using Application.Input.Handlers.AdminContext;
using Application.Repositories.AdminContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OpCuriosidade.Entities.PersonnelContext;

var builder = WebApplication.CreateBuilder(args);

// Configuração essencial
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new List<Admin>());
builder.Services.AddScoped<InsertAdminHandler>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

// Configuração explícita das portas
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");

var app = builder.Build();

// Middleware pipeline
app.UseCors("AllowAll"); // Usando a política "AllowAll"
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Torna o Swagger acessível na raiz
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();