using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service
{
    public class ServiceDependencyInjectionProfile
    {
        public ServiceDependencyInjectionProfile(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
