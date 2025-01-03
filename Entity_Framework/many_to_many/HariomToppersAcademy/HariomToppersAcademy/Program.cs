using HariomToppersAcademy.Context;
using HariomToppersAcademy.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICourseNameRepository, CourseNameRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


builder.Services.AddDbContext<ApplicationContext>(Options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
