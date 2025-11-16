using Fitalia.DAO;
using Fitalia.Interfaces;
using Fitalia.Services;
using Fitalia.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection")
    ?? throw new InvalidOperationException("Connection string 'SQLServerConnection' is not configured.");

builder.Services.Configure<SQLServerConfiguration>(options =>
{
    options.ConnectionString = connectionString;
});

builder.Services.AddScoped<IIniciarSesionDAO, IniciarSesionDAO>();
builder.Services.AddScoped<IIniciarSesionService, IniciarSesionService>();

builder.Services.AddScoped<IRegistrarDAO, RegistrarDAO>();
builder.Services.AddScoped<IRegistrarService, RegistrarService>();

builder.Services.AddScoped<IEstadoDeAnimoDAO, EstadoDeAnimoDAO>();
builder.Services.AddScoped<IEstadoDeAnimoService, EstadoDeAnimoService>();

builder.Services.AddScoped<ISaludFisica, SaludFisicaDAO>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontFitalia", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FrontFitalia");

app.UseAuthorization();

app.MapControllers();

app.Run();

