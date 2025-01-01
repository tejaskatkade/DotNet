using Employee.Services;
using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;
using MySql.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmpRepo,EmpRepo>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
