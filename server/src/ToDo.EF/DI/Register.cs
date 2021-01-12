using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ToDo.EF.Data;
using ToDo.Infra.Core;
using ToDo.Infra.Providers;

namespace ToDo.EF.DI
{
    public static class Register
    {
        public static IServiceCollection Context(this IServiceCollection services, DataProvider provider)
        { 
            services
                .AddDbContext<ToDoContext>(options =>
                {
                    options
                        .UseLazyLoadingProxies()
                        .UseSqlServer(provider.ToDo);
                })
                .AddScoped<ToDoContext>(); 

            return services;
        }

        public static IServiceCollection Repositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}