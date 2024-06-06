using BibliotecaPessoal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.IO; // Adicionado para usar a classe Directory

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("LivroConnection");

builder.Services.AddDbContext<BibliotecaContext>(options => options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(l => l.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "Projeto Biblioteca Pessoal",
    Description = "Projeto Biblioteca Pessoal - ASP .NET 6.0",
    Contact = new OpenApiContact
    {
        Name = "Vitória França",
        Url = new Uri("https://github.com/VitoriaFrancaS")
    }
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Environment.IsDevelopment();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
