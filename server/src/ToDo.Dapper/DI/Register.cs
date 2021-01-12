using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using ToDo.Dapper.Core;

namespace ToDo.Dapper.DI
{
    public static class Register
    {
        public static IServiceCollection Finders(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(FinderBase))
                .ToDictionary(i => i.GetInterfaces()[0], t => t)
                .ToList();

            types.ForEach(srv =>
            {
                var (service, implementation) = srv;
                services.AddTransient(service, implementation);
            });

            return services;
        }
    }
}