using GroomingGalleryBs.Data;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.Repositories;
using GroomingGalleryBS.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DBContext to the container
builder.Services.AddDbContext<AppDBContext>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
// builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Appointment>, AppointmentRepository>();
builder.Services.AddScoped<IRepository<Service>, ServiceRepository>();
builder.Services.AddScoped<IEmployeeServiceRepository, EmployeeServiceRepository>();
builder.Services.AddScoped<AppointmentValidator>();

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
