using CleanArchitecture.Infrastructure.DatabaseServices;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient<IProductTypeService, ProductTypeService>();
            //services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IDatabaseConnectionFactory>(e =>
            {
                return new SqlConnectionFactory(configuration["ConnectionStrings:ProductDatabase"]);
            });
            return services;
        }
    }
}
