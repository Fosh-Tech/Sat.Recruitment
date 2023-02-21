using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Shared.Cache.Profiles;
using Sat.Recruitment.Shared.Filters;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Shared.Cache
{
    internal static class DefaultDI
    {
        internal static IServiceCollection AddControllersExt(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                var commonCacheProfile = CommonCacheProfile.GetDefault();

                var withUserAgentCacheProfile = WithUserAgentCacheProfile.GetDefault();

                options.CacheProfiles.Add(commonCacheProfile.CacheProfileName, commonCacheProfile);

                options.CacheProfiles.Add(withUserAgentCacheProfile.CacheProfileName, withUserAgentCacheProfile);

                options.Filters.Add<ApiExceptionFilterAttribute>();

            })
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;

            return services;
        }
    }
}
