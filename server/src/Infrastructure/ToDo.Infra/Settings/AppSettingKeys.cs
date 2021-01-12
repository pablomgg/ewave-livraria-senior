namespace ToDo.Infra.Settings
{
    public struct AppSettingKeys
    {
        public struct Data
        {
            public const string ToDo = "Data:ToDo";
        }

        public struct Swagger
        {
            public const string Version = "SwaggerConfigurations:Version";
            public const string Title = "SwaggerConfigurations:Title";
            public const string Description = "SwaggerConfigurations:Description";
        }
    }
}