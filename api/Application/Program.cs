using Application.Auth;
using Application.Input.Commands.AdminContext;
using Application.Input.Handlers.AdminContext;
using Application.Input.Handlers.PersonContext;
using Application.Repositories.AdminContext;
using Application.Repositories.PersonContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using OpCuriosidade.Entities.PersonnelContext;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront", policy =>
    {
        policy.WithOrigins(
                "http://127.0.0.1:5500",
                "http://localhost:5000",
                "https://localhost:5001",
                "https://127.0.0.1:5500"
            )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var key = Encoding.UTF8.GetBytes(Config.PrivateKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Config.PrivateKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(5)
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    c.MapType<InsertAdminCommand>(() => new OpenApiSchema
    {
        Description = "Comando para cadastrar um administrador",
        Required = new HashSet<string> { "Name", "Email", "Password" },
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
    c.MapType<LoginAdminCommand>(() => new OpenApiSchema
    {
        Description = "Comando para logar um administrador",
        Required = new HashSet<string> { "Email", "Password" },
        Properties = new Dictionary<string, OpenApiSchema>
        {
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
            }
        }
    });
});
builder.Services.AddSingleton(new List<Admin>());
builder.Services.AddSingleton(new List<Person>());
builder.Services.AddScoped<LoginAdminHandler>();
builder.Services.AddScoped<InsertAdminHandler>();
builder.Services.AddScoped<DeleteAdminHandler>();
builder.Services.AddScoped<UpdateAdminHandler>();
builder.Services.AddScoped<GetAdminHandler>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<GetAllPersonsHandler>();
builder.Services.AddScoped<GetNumberOfLastMonthPersonsHandler>();
builder.Services.AddScoped<GetNumberOfPendingPersonsHandler>();
builder.Services.AddScoped<GetNumberOfPersonsHandler>();
builder.Services.AddScoped<GetPreviewDataToDashHandler>();
builder.Services.AddScoped<InsertPersonHandler>();
builder.Services.AddScoped<DeletePersonHandler>();

builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");

var app = builder.Build();

app.UseCors("AllowFront");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();