using Microsoft.OpenApi;
using System.ComponentModel;

namespace RestWithASPNET10Erudio.Configurations
{
    public static class SwaggerConfig
    {
        private static readonly string AppName = "ASP.NET 2026 REST API´s from 0 to Azure and GCP com .NET 10, Docker e Kubernetes";
        private static readonly string AppDescription = $"API´s developed in course {AppName}";

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = AppName,
                    Version = "v1",
                    Description = AppDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Erudio",
                        Url = new Uri("https://erudio.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/license/mit/")
                    }
                });
                options.CustomSchemaIds(Type => Type.FullName);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = AppName;
            });
            return app;
        }
    }
}
