using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Sat.Recruitment.Shared.Security.CORS;
using Sat.Recruitment.Shared.Swagger;

namespace Sat.Recruitment.Shared
{
    public static class Builder
    {
        public static IApplicationBuilder UseShared(this IApplicationBuilder app, IWebHostEnvironment webHostEnvironment, IApiVersionDescriptionProvider provider)
        {
            _ = app.UseSharedCORS(webHostEnvironment);
            _ = app.UseSharedSwagger(provider);

            return app;
        }
    }
}