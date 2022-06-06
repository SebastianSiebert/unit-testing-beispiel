using Beispiel.Anwendung.Contract;
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Mapper;
using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IDbContext, AppDbContext>(options => options.UseSqlite("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddSingleton<IExpressionMapper<Level4Model, Level4Contract>, Level4ToContractMapper>();

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

using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<IDbContext>() as AppDbContext;
  db.Database.Migrate();
}

app.Run();