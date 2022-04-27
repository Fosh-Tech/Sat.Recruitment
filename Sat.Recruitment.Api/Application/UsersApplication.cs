using System;
using System.Collections.Generic;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;

namespace Sat.Recruitment.Api.Application
{
    public class UsersApplication : IUsersApplication
    {
        private readonly List<IUserConfigurator> _usersConfigurators;

        public UsersApplication(List<IUserConfigurator> userConfigurators)
        {
            _usersConfigurators = userConfigurators ?? throw new ArgumentNullException(nameof(userConfigurators));
        }

        Result IUsersApplication.CreateUsers()
        {

        }
    }
}
