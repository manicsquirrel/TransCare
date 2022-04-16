using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransCare.Data.Repositories;
using TransCare.Interfaces;

namespace TransCare.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHealthProviderRepository, HealthProviderRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddDbContext<TransCareContextDb>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TransCareDatabase")));

            return services;
        }
    }
}