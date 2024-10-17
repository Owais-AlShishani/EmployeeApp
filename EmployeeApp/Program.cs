using EmployeeApp;
using EmployeeApp.Data;
using EmployeeApp.Repositories;
using EmployeeApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeContext")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//Vid  7/14
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<GlobalErrorHandling>();

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
app.UseMiddleware<GlobalErrorHandling>();

app.Run();
