using System;

namespace Sat.Recruitment.Api.Users
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
