using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Data;
using Sat.Recruitment.Shared.Models.Configuration.Interfaces;

namespace Sat.Recruitment.Infrastructure.Data
{
    internal static class DefaultDI
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services, IApplicationSettings applicationSettings)
        {
            services.AddSingleton<IMyDataSource>(x => new MyDataSource(applicationSettings.DataSourceFilePath));

            return services;
        }
    }
}
