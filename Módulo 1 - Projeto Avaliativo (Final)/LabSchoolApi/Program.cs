using System;
using AutoMapper;
using LabSchoolApi.Data;
using LabSchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using LabSchoolApi.Validators;
using LabSchoolApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<LabSchoolDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ServerConnection"),
    new MySqlServerVersion(new Version(8, 0, 26))));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register validators
builder.Services.AddValidatorsFromAssemblyContaining<AlunoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProfessorValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PedagogoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AtendimentoPedagogicoRequestValidator>();

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
