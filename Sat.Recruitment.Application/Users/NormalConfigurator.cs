using System;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Dtos.Enums;

namespace Sat.Recruitment.Application.Users
{
    public class NormalConfigurator : IUserConfigurator
    {
        UserTypes IUserConfigurator.UserType => UserTypes.Normal;

        void IUserConfigurator.ConfigureMoney(UserDto user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            decimal percentage = 0;

            if (user.Money > 100)
            {
                percentage = Convert.ToDecimal(0.12);
            }
            else if (user.Money < 100)
            {
                percentage = Convert.ToDecimal(0.8);
            }

            decimal gif = user.Money * percentage;

            user.Money += gif;
        }
    }
}
