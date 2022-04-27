using System;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Entities.Enums;

namespace Sat.Recruitment.Application.Users
{
    public class SuperUserConfigurator : IUserConfigurator
    {
        UserTypes IUserConfigurator.UserType => UserTypes.SuperUser;

        void IUserConfigurator.ConfigureMoney(User user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            decimal percentage = Convert.ToDecimal(0.20);
            decimal gif = user.Money * percentage;

            user.Money += gif;
        }
    }
}
