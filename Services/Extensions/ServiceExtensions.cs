using App.Repositories.Products;
using App.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Services.Products;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

using System.Reflection;


namespace App.Services.Extensions
{
   public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
          services.AddScoped<IProductService, ProductService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
