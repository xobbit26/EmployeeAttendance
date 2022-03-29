using EmployeeRecorder.DAL;
using EmployeeRecorder.service;
using EmployeeRecorder.service.impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//DI
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


//db configuration
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EmployeeRecorderDbContext>(options => options
    .UseNpgsql(connection)
    .UseSnakeCaseNamingConvention());


var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
