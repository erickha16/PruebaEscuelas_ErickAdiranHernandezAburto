using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Agregar DbContext para la aplicaicón principal
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

//Agregar servicios de la aplicación
builder.Services.AddScoped<IAlumnoServicio, AlumnoServicio>();

builder.Services.AddScoped<IEscuelaServicio, EscuelaServicio>();

builder.Services.AddScoped<IProfesorServicio, ProfesorServicio>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
