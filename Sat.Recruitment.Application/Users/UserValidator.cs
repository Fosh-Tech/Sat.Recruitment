using System;

using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Data.Services;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Application.Common;
using System.Collections.Generic;
using Sat.Recruitment.Dtos.Dtos;

namespace Sat.Recruitment.Application.Users
{
    public class UserValidator : IUserValidator
    {
        private readonly IUsersService _usersService;

        public UserValidator(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        void IUserValidator.ValidateDuplicatedUsers(UserDto user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            List<User> storedUsers = _usersService.GetAllUsers();

            // TODO conversion

            List<UserDto> users = new List<UserDto>();

            for (int i = 0; i < users.Count; i++)
            {
                if (user.IsDuplicated(users[i]))
                {
                    throw new DuplicatedUserException();
                }
            }
         }
    }
}
