using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            new DependencyInjectionProfile(services);
        }
    }
}
