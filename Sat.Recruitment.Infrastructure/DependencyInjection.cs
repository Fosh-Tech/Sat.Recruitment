using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Common.Interfaces.Readers;
using Sat.Recruitment.Application.Common.Interfaces.Repositories;
using Sat.Recruitment.Application.Common.Interfaces.Services;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Infrastructure.Persistence.Readers;
using Sat.Recruitment.Infrastructure.Persistence.Repositories;
using System.IO;
using System.Reflection;

namespace Sat.Recruitment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IUserCreationService, UserCreationService>();
            services.AddTransient<IUserValidationService, UserValidationService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserReader>(x => new UserReader(Directory.GetCurrentDirectory() + "/Files/Users.txt"));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}