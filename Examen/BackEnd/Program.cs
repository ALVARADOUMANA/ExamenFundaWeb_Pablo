using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using BackEnd.Service.Interface;
using BackEnd.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add CORS policy to allow all origins (adjust according to your needs)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Allows all origins
              .AllowAnyMethod()  // Allows all HTTP methods
              .AllowAnyHeader(); // Allows all headers
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region DI

builder.Services.AddDbContext<Adventureworks2016Context>();

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

builder.Services.AddScoped<ICultureDAL, CultureDALImpl>();
builder.Services.AddScoped<ICultureService, CultureService>();


#endregion


var app = builder.Build();

// Enable CORS before other middleware
app.UseCors("AllowAll");

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
