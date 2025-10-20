using Fitalia.Entities;
using Fitalia.Interfaces;
using Fitalia.Services;
using Fitalia.DAO;
using Fitalia.Utilities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection") ?? throw new InvalidOperationException("Connection string 'SQLServerConnection' is not configured.");

// Configure the SQLServerConfiguration with the connection string
builder.Services.Configure<SQLServerConfiguration>(options =>
{
    options.ConnectionString = connectionString;
});
// Add services to the container.


builder.Services.AddScoped<IIniciarSesionDAO, IniciarSesionDAO>();
builder.Services.AddScoped<IIniciarSesionService, IniciarSesionService>();

builder.Services.AddScoped<IRegistrarDAO, RegistrarDAO>();
builder.Services.AddScoped<IRegistrarService, RegistrarService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontFitalia", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7150",
            "https://localhost:7064",
            "http://localhost:5035",
            "http://127.0.0.1:5500",   
            "http://localhost:5500"     
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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
