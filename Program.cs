using EmployeeCrudAPI.Data;
using EmployeeCrudAPI.Interfaces;
using EmployeeCrudAPI.Repositories;
using EmployeeCrudAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-Memory Database Configuration (aktifkan kembali konfigurasi ini jika ingin menggunakan In-Memory DB)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyTestDb"));

// Register services and repositories for Dependency Injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Build the app (pastikan ini dilakukan setelah semua layanan didaftarkan)
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
