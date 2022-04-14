using EmployeeAttendance;
using EmployeeAttendance.Data;
using EmployeeAttendance.Data.Repository;
using EmployeeAttendance.Data.Repository.Impl;
using EmployeeAttendance.Data.Repository.RepoConfig;
using EmployeeAttendance.Service;
using EmployeeAttendance.Service.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


//DI
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
//builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

//autoMapper config
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));


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