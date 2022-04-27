using System;
using System.Collections.Generic;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;

namespace Sat.Recruitment.Api.Applications
{
    public class UsersApplication : IUsersApplication
    {
        private readonly List<IUserConfigurator> _usersConfigurators;
        private readonly IUserValidator _userValidator;

        public UsersApplication(IUserValidator userValidator, List<IUserConfigurator> userConfigurators)
        {
            _usersConfigurators = userConfigurators ?? throw new ArgumentNullException(nameof(userConfigurators));
            _userValidator = userValidator ?? throw new ArgumentNullException(nameof(userValidator));
        }

        Result IUsersApplication.CreateUsers()
        {
            return null;
        }
    }
}
