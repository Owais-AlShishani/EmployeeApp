using EmployeeApp.Repositories;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApp.Services;
using FluentValidation;
using EmployeeApplication.Models.Entities;

namespace EmployeeApplication
{
    public static class ApplicationServiceCollectionExtentions
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);// Implementing validation Lec
            return services;
        }
    }
}
