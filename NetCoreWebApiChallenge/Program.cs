using System;
using Application.Services.Movie.CreateMovie;
using Application.Services.Movie.DeleteMovie;
using Application.Services.Movie.EditMovie;
using Application.Services.Movie.ListMovie;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));  // Using InMemoryDb for simplicity


// Add services to the container.
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IListMovie, ListMovie>();
builder.Services.AddScoped<ICreateMovie, CreateMovie>();
builder.Services.AddScoped<IEditMovie, EditMovie>();
builder.Services.AddScoped<IDeleteMovie, DeleteMovie>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Hacer un "migrado" para asegurarse de que los datos de HasData sean insertados
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
    dbContext.Database.EnsureCreated();  // Esto asegura que la base de datos se crea si no existe y agrega datos si es necesario.
}

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
