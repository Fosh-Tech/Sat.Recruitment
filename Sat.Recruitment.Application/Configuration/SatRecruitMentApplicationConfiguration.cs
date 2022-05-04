using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Data.Configuration;
using Sat.Recruitment.Dto.Profiles;

namespace Sat.Recruitment.Application.Configuration
{
    public static class SatRecruitMentApplicationConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SatRecruitmentProfiles));

            services.AddDataServices();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
