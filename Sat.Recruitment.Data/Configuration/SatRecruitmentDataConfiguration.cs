using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Data.Services;

namespace Sat.Recruitment.Data.Configuration
{
    public static class SatRecruitmentDataConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserReaderService, UserReaderService>();

            return services;
        }
    }
}
