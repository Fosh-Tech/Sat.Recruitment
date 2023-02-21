using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Sat.Recruitment.Shared.Swagger
{
    internal static class DefaultDI
    {
        public static IServiceCollection AddSharedSwagger(this IServiceCollection services, string title, string version = "v1")
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = version });
                options.CustomSchemaIds((type) => type.FullName);
                options.IgnoreObsoleteActions();
                options.IgnoreObsoleteProperties();                
                options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                    options.IncludeXmlComments(xmlPath);                

                options.OperationFilter<SwaggerDefaultValues>();
                options.SchemaFilter<EnumSchemaFilter>();
            });

            return services;
        }
    }
}
