using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ToDo.Infra.Providers;

namespace ToDo.WebApi.Configurations
{
    public static class SwaggerConfigurations
    {
        public static IServiceCollection SwaggerConfigure(this IServiceCollection services, SwaggerProvider provider)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(provider.Version, new OpenApiInfo
                {
                    Title = provider.Title,
                    Version = provider.Version,
                    Description = provider.Description
                }); ;
            });

            return services;
        }
    }
}
