using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sat.Recruitment.Api.Applications;
using Sat.Recruitment.Api.Users;
using Sat.Recruitment.Api.Services;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Sat.Recruitment.Api.Common
{
    public class IocContainer
    {
        static UnityContainer container = new UnityContainer();

        public static void Register()
        {
            container.RegisterSingleton<IUserConfigurator, NormalConfigurator>(Guid.NewGuid().ToString());
            container.RegisterSingleton<IUserConfigurator, PremiumConfigurator>(Guid.NewGuid().ToString());
            container.RegisterSingleton<IUserConfigurator, SuperUserConfigurator>(Guid.NewGuid().ToString());

            container.RegisterSingleton<IUsersService, UsersService>();

            container.RegisterInstance<IUserValidator>(new UserValidator(Resolve<IUsersService>()), new SingletonLifetimeManager());
            container.RegisterInstance<IUsersApplication>(new UsersApplication(Resolve<IUserValidator>(), ResolveByType<IUserConfigurator>()));
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static List<T> ResolveByType<T>()
        {
            return container.ResolveAll<T>().ToList();
        }

    }
}
