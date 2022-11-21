using Sat.Recruitment.Application.Common.Interfaces.Services;
using Sat.Recruitment.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Application.Services
{
    public class UserValidationService : IUserValidationService
    {
        public Result ValidateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var errors = new List<string>();

            if (name == null)
                errors.Add("The name is required");

            if (email == null)
                errors.Add("The email is required");

            if (address == null)
                errors.Add("The address is required");

            if (phone == null)
                errors.Add("The phone is required");

            if (userType == null || !Enum.IsDefined(typeof(UserType), userType))
                errors.Add("The userType is required and has to be one of the following: Normal, SuperUser, Premium");

            if (!decimal.TryParse(money, out _)) {
                errors.Add("The money parameter should be a number");
            }

            return new Result()
            {
                IsSuccess = !errors.Any(),
                Errors = errors
            };
        }
    }
}