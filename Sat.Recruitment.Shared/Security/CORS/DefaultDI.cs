using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Shared.Models.Configuration.Interfaces;

namespace Sat.Recruitment.Shared.Security.CORS
{
    internal static class DefaultDI
    {
        public static IServiceCollection AddSharedCORS(this IServiceCollection services, IWebHostEnvironment webHostEnvironment, IApplicationSettings applicationSettings)
        {
            if (webHostEnvironment.IsDevelopment())
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder => builder
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin()
                    );
                });

            if (webHostEnvironment.IsProduction())
                services.AddCors(options =>
                {
                    var requiredCorsPolicy = applicationSettings.SecuritySettings.CORSSettings.Policies.FirstOrDefault();
                    options.AddPolicy(name: requiredCorsPolicy.Name,
                                      builder =>
                                      {
                                          builder.WithOrigins(requiredCorsPolicy.Origins);
                                      });
                });
            return services;
        }
    }
}
