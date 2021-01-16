using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using ToDo.Application.DI;
using ToDo.Infra.Settings;
using ToDo.WebApi.Configurations;

namespace ToDo.WebApi
{
    public class Startup
    {
        private readonly AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            _appSettings = new AppSettings(configuration);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .SwaggerConfigure(_appSettings.Swagger)
                .RegisterModules(_appSettings)
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
                .UseCors(builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                })
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .UseSwagger()
                .UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint($"/swagger/v1/swagger.json", "ToDo - WebApi");
                    s.ConfigObject.DocExpansion = DocExpansion.None;
                });
        }
    }
}
