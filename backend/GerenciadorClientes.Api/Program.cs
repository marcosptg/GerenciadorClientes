using FluentValidation;
using GerenciadorClientes.Api.Middleware;
using GerenciadorClientes.Application.Behaviors;
using GerenciadorClientes.Application.Commands;
using GerenciadorClientes.Domain.IRepositories;
using GerenciadorClientes.Infrastructure.Data;
using GerenciadorClientes.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorClientes API", Version = "v1" });
});

// Configuração do DbContext para SQL Server
builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDbConnection")));
builder.Services.AddSingleton<MongoDbContext>();

// Configuração dos repositórios
builder.Services.AddScoped<IClienteAggregationRepository, ClienteAggregationRepository>();
builder.Services.AddScoped<IClienteReadOnlyRepository, ClienteReadOnlyRepository>();

// Configuração do MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CriarClienteCommandHandler).Assembly);
});

// Validações com fluent
builder.Services.AddValidatorsFromAssemblyContaining<CriarClienteCommandValidator>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
