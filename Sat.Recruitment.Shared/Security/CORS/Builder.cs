using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sat.Recruitment.Shared.Security.CORS
{
    internal static class Builder
    {
        public static IApplicationBuilder UseSharedCORS(this IApplicationBuilder app, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
                app.UseCors();

            return app;
        }
    }
}
