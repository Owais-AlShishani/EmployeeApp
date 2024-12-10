using EmployeeApp.Repositories;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApp.Services;

namespace EmployeeApplication
{
    public static class ApplicationServiceCollectionExtentions
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
