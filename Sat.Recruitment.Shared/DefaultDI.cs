using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Common.Behaviours;
using Sat.Recruitment.Shared.Cache;
using Sat.Recruitment.Shared.Models.Configuration.Interfaces;
using Sat.Recruitment.Shared.Security.CORS;
using Sat.Recruitment.Shared.Swagger;
using Sat.Recruitment.Shared.Versioning;

namespace Sat.Recruitment.Shared
{
    public static class DefaultDI
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IWebHostEnvironment webHostEnvironment, IApplicationSettings applicationSettings)
        {
            services
                .AddControllersExt()
                .AddSharedAPIVersioning()
                .AddSharedCORS(webHostEnvironment, applicationSettings)
                .AddSharedSwagger(applicationSettings.ApplicationName)
                .AddSharedBehavior(); 

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            return services;
        }
    }
}