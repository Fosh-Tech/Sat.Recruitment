using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Service.Services;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Service
{
    public class DependencyInjectionProfile
    {
        public DependencyInjectionProfile(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();

            //Friendly DI for Gifts
            services.AddTransient<GiftNormal>();
            services.AddTransient<GiftPremium>();
            services.AddTransient<GiftSuper>();

            services.AddSingleton<IGiftFactory>(ctx =>
            {
                var factories = new Dictionary<string, Func<IGift>>()
                {
                    ["normal"] = () => ctx.GetService<GiftNormal>(),
                    ["premium"] = () => ctx.GetService<GiftPremium>(),
                    ["superuser"] = () => ctx.GetService<GiftSuper>()
                };
                return new GiftFactory(factories);
            });
        }
    }
}
