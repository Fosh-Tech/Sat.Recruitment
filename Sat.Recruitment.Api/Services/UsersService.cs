using System;
using System.Collections.Generic;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;

namespace Sat.Recruitment.Api.Services
{
    public class UsersService : IUsersService
    {
        private readonly List<IUserConfigurator> _usersConfigurators;
        private readonly IUserValidator _userValidator;

        public UsersService(IUserValidator userValidator, List<IUserConfigurator> userConfigurators)
        {
            _usersConfigurators = userConfigurators ?? throw new ArgumentNullException(nameof(userConfigurators));
            userValidator = userValidator ?? throw new ArgumentNullException(nameof(userValidator));
        }

        Result IUsersService.CreateUsers()
        {
            return null;
        }
    }
}
