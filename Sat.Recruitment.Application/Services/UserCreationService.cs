using Sat.Recruitment.Application.Common.Interfaces.Repositories;
using Sat.Recruitment.Application.Common.Interfaces.Services;
using Sat.Recruitment.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
    public class UserCreationService : IUserCreationService
    {
        private readonly IUserRepository userRepository;

        public UserCreationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Result> CreateUserAsync(string name, string email, string address, string phone, string userTypeString, string money)
        {
            Enum.TryParse(userTypeString, out UserType userType);

            var newMoney = CalculateMoney(userType, decimal.Parse(money));

            var normalizedEmail = NormalizeEmail(email);

            var newUser = new UserViewModel
            {
                Name = name,
                Email = normalizedEmail,
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = newMoney
            };

            var users = await userRepository.GetUsersAsync();

            var isUserDuplicated = users
                .Any(u => u.Email == newUser.Email
                    || u.Phone == newUser.Phone
                    || (u.Name == newUser.Name && u.Address == newUser.Address));

            return new Result()
            {
                IsSuccess = !isUserDuplicated,
                Errors = isUserDuplicated ? new List<string>() { "The user is duplicated" } : new List<string>()
            };
        }

        private static decimal CalculateMoney(UserType userType, decimal money)
        {
            decimal percentage = 0;

            switch (userType)
            {
                case UserType.Normal:
                    if (money > 100) {
                        percentage = Convert.ToDecimal(0.12);
                    } 
                    else if (money > 10 && money < 100)
                    {
                        percentage = Convert.ToDecimal(0.8);
                    }
                    break;
                case UserType.SuperUser:
                    percentage = money > 100 ? Convert.ToDecimal(0.2) : 0;
                    break;
                case UserType.Premium:
                    percentage = money > 100 ? 2 : 0;
                    break;
                default:
                    break;
            }

            var gif = money * percentage;

            return money + gif;
        }

        private static string NormalizeEmail(string email)
        {
            var splittedEmail = email.Split('@', StringSplitOptions.RemoveEmptyEntries);
            
            var localPart = splittedEmail[0];
            var domain = splittedEmail[1];

            var plusIndex = localPart.IndexOf("+", StringComparison.Ordinal);

            var normalizedLocalPart = localPart.Replace(".", "");
            
            normalizedLocalPart = plusIndex < 0 ? normalizedLocalPart : normalizedLocalPart.Remove(plusIndex);

            return normalizedLocalPart + "@" + domain;
        }
    }
}