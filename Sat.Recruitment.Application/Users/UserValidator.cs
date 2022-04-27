using System;

using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Data.Services;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Application.Common;
using System.Collections.Generic;

namespace Sat.Recruitment.Application.Users
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
            _ = user ?? throw new ArgumentNullException(nameof(user));

            List<User> storedUsers = _usersService.GetAllUsers();

            for (int i = 0; i < storedUsers.Count; i++)
            {
                if (user.IsDuplicated(storedUsers[i]))
                {
                    throw new DuplicatedUserException();
                }
            }
         }
    }
}
