using Microsoft.Extensions.Configuration;
using ToDo.Infra.Providers;

namespace ToDo.Infra.Settings
{
    public class AppSettings
    {
        public DataProvider Data { get; set; }
        public SwaggerProvider Swagger { get; set; }

        public AppSettings() { }

        public AppSettings(IConfiguration configuration)
        {
            Data = new DataProvider(configuration);
            Swagger = new SwaggerProvider(configuration);
        }
    }
}