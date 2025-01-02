using EmployeeApplication.Context;
using EmployeeApplication.Repository;
using EmployeeApplication.Repository.Implementation;
using EmployeeApplication.Service;
using EmployeeApplication.Service.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentServiceImpl>();

builder.Services.AddDbContext<EmployeeDbContext>(Options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
