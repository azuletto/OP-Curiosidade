using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.AdminContext;
using Application.Repositories.AdminContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    c.MapType<InsertAdminCommand>(() => new OpenApiSchema
    {
        Description = "Comando para cadastrar um administrador",
        Required = new HashSet<string> { "Name", "Email", "Password" }, // Campos obrigatórios
        Properties = new Dictionary<string, OpenApiSchema>
        {
            ["Name"] = new()
            {
                Type = "string",
                Description = "Nome completo (mínimo 3 caracteres)",
                Example = new OpenApiString("João Silva")
            },
            ["Email"] = new()
            {
                Type = "string",
                Format = "email",
                Description = "E-mail válido",
                Example = new OpenApiString("admin@exemplo.com")
            },
            ["Password"] = new()
            {
                Type = "string",
                Format = "password",
                Description = "Senha com pelo menos 8 caracteres",
                Example = new OpenApiString("Senha@123")
            },
            ["IsDeleted"] = new()
            {
                Type = "boolean",
                Description = "Padrão: false (não excluído)",
                Default = new OpenApiBoolean(false)
            }
        }
    });
});
builder.Services.AddSingleton(new List<Admin>());
builder.Services.AddScoped<InsertAdminHandler>();
builder.Services.AddScoped<DeleteAdminHandler>();
builder.Services.AddScoped<UpdateAdminHandler>();
builder.Services.AddScoped<GetAdminHandler>();
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