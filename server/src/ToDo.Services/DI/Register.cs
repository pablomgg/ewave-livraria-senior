using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace ToDo.Services.DI
{
    public static class Register
    {
        public static IServiceCollection Services(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name.EndsWith("Service"))
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