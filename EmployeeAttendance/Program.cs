using EmployeeAttendance;
using EmployeeAttendance.Data;
using EmployeeAttendance.Data.Repository;
using EmployeeAttendance.Data.Repository.Impl;
using EmployeeAttendance.Services;
using EmployeeAttendance.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


//DI
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeAttendanceService, EmployeeAttendanceService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeAttendanceRepository, EmployeeAttendanceRepository>();

//autoMapper config
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


//db configuration
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options
    .UseNpgsql(connection)
    .UseSnakeCaseNamingConvention());


var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();