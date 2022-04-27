using System;
using System.Collections.Generic;
using Sat.Recruitment.Api.Users;
using Unity;

namespace Sat.Recruitment.Api.Common
{
    public class IocContainer
    {
        UnityContainer container = new UnityContainer();

        public void Register()
        {
            container.RegisterSingleton<IUserConfigurator, NormalConfigurator>(Guid.NewGuid().ToString());
            container.RegisterSingleton<IUserConfigurator, PremiumConfigurator>(Guid.NewGuid().ToString());
            container.RegisterSingleton<IUserConfigurator, SuperUserConfigurator>(Guid.NewGuid().ToString());
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }


    }
}
