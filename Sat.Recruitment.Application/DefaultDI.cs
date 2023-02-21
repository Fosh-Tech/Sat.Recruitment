using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Users.Commands.CreateUser;
using System.Reflection;

namespace Sat.Recruitment.Application
{
    public static class DefaultDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddSingleton(GetConfiguredMappingConfig(executingAssembly));

            services.AddScoped<IMapper, ServiceMapper>();

            services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(executingAssembly));

            return services;
        }

        /// <summary>
        /// Mapster(Mapper) global configuration settings
        /// </summary>
        /// <returns></returns>
        private static TypeAdapterConfig GetConfiguredMappingConfig(Assembly assembly)
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.Apply(config.Scan(assembly));

            return config;
        }
    }
}
