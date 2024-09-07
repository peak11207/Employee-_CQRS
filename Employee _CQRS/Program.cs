using Employee__CQRS.Database;
using Employee__CQRS.DTOs;
using Employee__CQRS.Features.Employees.addEmployee;
using Employee__CQRS.Features.Employees.getEmployee;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Employee__CQRS.Features.Employees.deleteEmployee;
using Employee__CQRS.Features.Employees.updateEmployee;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<addEmployeeCommandValidator>()); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("mainData"));
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IRequestHandler<addEmployeeCommand, int>, addEmployeeCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>, GetAllEmployeesHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>, GetAllEmployeesHandler>();
builder.Services.AddScoped<IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>, GetEmployeeByIdHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteEmployeeCommand, bool>, DeleteEmployeeHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateEmployeeCommand, bool>, UpdateEmployeeHandler>();

var app = builder.Build();

//สร้างข้อมูล test
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Initialize(context);
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
