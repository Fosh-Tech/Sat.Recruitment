using System;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Dtos.Enums;


namespace Sat.Recruitment.Application.Users
{
    public class SuperUserConfigurator : IUserConfigurator
    {
        UserTypes IUserConfigurator.UserType => UserTypes.SuperUser;

        void IUserConfigurator.ConfigureMoney(UserDto user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            decimal percentage = Convert.ToDecimal(0.20);
            decimal gif = user.Money * percentage;

            user.Money += gif;
        }
    }
}
