using System;
using System.Collections.Generic;
using System.Linq;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;
using Sat.Recruitment.Api.Exceptions;

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

        User IUsersApplication.CreateUsers(string name, string email, string address, string phone, UserTypes userType, decimal money)
        {
            User newUser = new User(name, email, address, phone, userType, money);

            if (!newUser.HasErrors)
            {
                _userValidator.ValidateDuplicatedUsers(newUser);

                ConfigureUser(newUser);
            }

            return newUser;
        }

        private void ConfigureUser(User user)
        {
            IUserConfigurator userConfigurator = _usersConfigurators.FirstOrDefault(x => x.UserType == user.UserType);

            if (userConfigurator == null)
            {
                throw new IocException(Constants.IOC_EXCEPTION);
            }

            userConfigurator.ConfigureMoney(user);
        }
    }
}
