using CleanArchEMS.Application.Extensions;
using CleanArchEMS.Domain.Common.Interfaces;
using CleanArchEMS.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CleanArchEMS.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CleanArchEMS.Application.Interfaces.IRepositories;
using CleanArchEMS.Persistance.Repositories;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<EMSDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly(typeof(EMSDbContext).Assembly.FullName)));

// Register dependencie
builder.Services.AddApplicationLayer();
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
