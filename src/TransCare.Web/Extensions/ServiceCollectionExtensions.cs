using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TransCare.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetEntryAssembly();
            AssemblyInformationalVersionAttribute versionAttribute = assembly?
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string assemblyVersion = versionAttribute?.InformationalVersion ?? "";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "TransCare Api",
                    Version = assemblyVersion
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                //c.EnableAnnotations();
            });
            return services;
        }
    }
}