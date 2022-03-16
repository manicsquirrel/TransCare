using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransCare.Interfaces;

namespace TransCare.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddDbContext<TransCareContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TransCareDatabase")));

            return services;
        }
    }
}