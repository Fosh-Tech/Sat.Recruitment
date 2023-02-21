using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Application.Common.Behaviours
{
    internal static class DefaultDI
    {
        public static IServiceCollection AddSharedBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }     
    }
}
