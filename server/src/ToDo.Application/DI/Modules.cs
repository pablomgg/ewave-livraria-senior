using Microsoft.Extensions.DependencyInjection;
using ToDo.Dapper.DI;
using ToDo.EF.DI;
using ToDo.Infra.Settings;
using ToDo.Services.DI;

namespace ToDo.Application.DI
{
    public static class Modules
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services, AppSettings appSettings)
        {
            services.Configure<AppSettings>(app =>
            {
                app.Swagger = appSettings.Swagger;
                app.Data = appSettings.Data;
            });

            services
                .Context(appSettings.Data)
                .Repositories()
                .Finders()
                .Services();
             
            return services;
        }
    }
}