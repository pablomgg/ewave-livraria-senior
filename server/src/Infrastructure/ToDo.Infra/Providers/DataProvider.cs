using Microsoft.Extensions.Configuration;
using ToDo.Infra.Settings;

namespace ToDo.Infra.Providers
{
    public class DataProvider
    {
        public string ToDo { get; } 

        public DataProvider(IConfiguration configuration)
        {
            ToDo = configuration.GetSection(AppSettingKeys.Data.ToDo)?.Value;
        }
    }
}