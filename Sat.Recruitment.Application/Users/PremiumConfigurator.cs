using System;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Dtos.Enums;

namespace Sat.Recruitment.Application.Users
{
    public class PremiumConfigurator : IUserConfigurator
    {
        UserTypes IUserConfigurator.UserType => UserTypes.Premium;

        void IUserConfigurator.ConfigureMoney(UserDto user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            user.Money += user.Money * 2;
        }

    }
}
