using System;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Exceptions;
using Sat.Recruitment.Api.Common;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Users
{
    public class UserValidator : IUserValidator
    {
        private readonly IUsersService _usersService;

        public UserValidator(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        void IUserValidator.ValidateDuplicatedUsers(User user)
        {
            List<User> storedUsers = _usersService.GetAllUsers();

            for (int i = 0; i < storedUsers.Count; i++)
            {
                if (user.IsDuplicated(storedUsers[i]))
                {
                    throw new DuplicatedUserException(Constants.DUPLICATED_USER);
                }
            }
         }
    }
}
