using System;
using System.Collections.Generic;
using System.Linq;
using Sat.Recruitment.Application.Users;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Dtos.Common;
using Sat.Recruitment.Dtos.Dtos;
using Constants = Sat.Recruitment.Application.Common.Constants;

namespace Sat.Recruitment.Application.Applications
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

        UserDto IUsersApplication.CreateUsers(string name, string email, string address, string phone, string userType, string money)
        {
            UserDto newUser = new UserDto(name, email, address, phone, userType, money);

            if (!newUser.HasErrors)
            {
                _userValidator.ValidateDuplicatedUsers(newUser);

                ConfigureUser(newUser);
            }

            return newUser;
        }

        private void ConfigureUser(UserDto user)
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
