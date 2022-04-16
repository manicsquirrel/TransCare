using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransCare.Services.Abstractions;

namespace TransCare.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiKeyOptions>(configuration.GetSection("ApiKeys"));
            services.AddScoped<IHealthProviderService, HealthProviderService>();
            services.AddScoped<IStateService, StateService>();
            return services;
        }
    }
}