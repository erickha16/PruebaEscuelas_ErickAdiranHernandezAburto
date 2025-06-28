using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.Data;

var builder = WebApplication.CreateBuilder(args);

//Agregar DbContext para la aplicaic�n principal
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

//Agregar servicios de la aplicaci�n


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
