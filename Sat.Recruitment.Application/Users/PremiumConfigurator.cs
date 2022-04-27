using System;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Entities.Enums;

namespace Sat.Recruitment.Application.Users
{
    public class PremiumConfigurator : IUserConfigurator
    {
        UserTypes IUserConfigurator.UserType => UserTypes.Premium;

        void IUserConfigurator.ConfigureMoney(User user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            user.Money += user.Money * 2;
        }

    }
}
