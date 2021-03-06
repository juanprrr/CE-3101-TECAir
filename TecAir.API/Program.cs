using System;
using Microsoft.EntityFrameworkCore;
using TecAir.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ToDoDbContext>(options => options.UseInMemoryDatabase("todo"));

var configuration = builder.Configuration;

builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Database"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200/", "http://127.0.0.1:4200/")
            .AllowAnyHeader()
            .WithMethods("POST", "GET");
        });
});

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
