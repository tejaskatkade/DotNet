using System.Text;
using HealthBuddyApp.Context;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.Entity;
using HealthBuddyApp.Repository;
using HealthBuddyApp.Repository.Implementation;
using HealthBuddyApp.Service;
using HealthBuddyApp.Service.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IEmailService,EmailServiceImpl>();
builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IDoctorService,DoctorServiceImpl>();
builder.Services.AddScoped<IHospitalRepository,HospitalRepository>();
builder.Services.AddScoped<IHospitalService,HospitalServiceImpl>();
builder.Services.AddScoped<IPatientRepository,PatientRepository>();
builder.Services.AddScoped<IPatientService,PatientServiceImpl>();
builder.Services.AddScoped<IAppointmentRepository,AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService,AppointmentServiceImpl>();
builder.Services.AddScoped<ITimeSlotService,TimeSlotServiceImpl>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors( options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
}
);

builder.Services.AddDbContext<AppDBContext>(Options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
        ValidAudience = builder.Configuration["AppSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JWTSecret"]!))
    };
});




var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseHttpsRedirection ();
app.UseRouting ();

app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
app.Run();
