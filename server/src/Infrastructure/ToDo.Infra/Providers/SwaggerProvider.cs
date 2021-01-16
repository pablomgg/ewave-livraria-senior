using Microsoft.Extensions.Configuration;
using ToDo.Infra.Settings;

namespace ToDo.Infra.Providers
{
    public class SwaggerProvider
    {
        public string Title { get; }
        public string Description { get; }
        public string Version { get; }

        public SwaggerProvider(IConfiguration configuration)
        {
            Title = configuration.GetSection(AppSettingKeys.Swagger.Title)?.Value;
            Description = configuration.GetSection(AppSettingKeys.Swagger.Description)?.Value;
            Version = configuration.GetSection(AppSettingKeys.Swagger.Version)?.Value;
        }
    }
}