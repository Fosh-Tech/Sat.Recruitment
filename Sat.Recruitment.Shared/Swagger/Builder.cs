using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Sat.Recruitment.Shared.Swagger
{
    internal static class Builder
    {
        public static IApplicationBuilder UseSharedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"./swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = string.Empty;
                }

                options.ShowCommonExtensions();
                options.ShowExtensions();
                options.DisplayOperationId();
                options.DisplayRequestDuration();
                options.EnableFilter();
                options.DefaultModelRendering(ModelRendering.Example);
                options.DocExpansion(DocExpansion.List);
                options.EnableDeepLinking();
                options.EnableTryItOutByDefault();
            });
            return app;
        }
    }
}
