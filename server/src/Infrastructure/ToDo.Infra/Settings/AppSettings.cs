using Microsoft.Extensions.Configuration;
using ToDo.Infra.Providers;

namespace ToDo.Infra.Settings
{
    public class AppSettings
    {
        public DataProvider Data { get; }
        public SwaggerProvider Swagger { get; }

        public AppSettings(IConfiguration configuration)
        {
            Data = new DataProvider(configuration);
            Swagger = new SwaggerProvider(configuration);
        }
    }
}