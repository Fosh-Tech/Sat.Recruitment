using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Infrastructure.Data;
using Sat.Recruitment.Shared.Models.Configuration.Interfaces;

namespace Sat.Recruitment.Infrastructure
{
    public static class DefaultDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IApplicationSettings applicationSettings)
        {
            services.AddInfrastructureData(applicationSettings);

            return services;
        }
    }
}