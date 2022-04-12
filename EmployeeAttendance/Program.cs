using EmployeeAttendance.Data;
using EmployeeAttendance.Repository;
using EmployeeAttendance.Repository.Impl;
using EmployeeAttendance.Repository.RepoConfig;
using EmployeeAttendance.Service;
using EmployeeAttendance.Service.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


//DI
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


//db configuration
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options
    .UseNpgsql(connection)
    .UseSnakeCaseNamingConvention());


var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
